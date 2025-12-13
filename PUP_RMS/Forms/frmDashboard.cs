using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PUP_RMS.Forms
{
    // NOTE: This file assumes you have fixed the CS0229 ambiguity error 
    // by removing any manual declaration of dgvRecentUploads in this file.
    public partial class frmDashboard : Form
    {
        // =========================================================================
        // SECTION A: COLOR AND CONTROL DEFINITIONS
        // =========================================================================
        private readonly Color AccentMaroon = Color.FromArgb(128, 0, 0); // Primary Accent Color
        private readonly Color StatusGreen = Color.FromArgb(40, 167, 69);
        private readonly Color BackgroundLight = Color.FromArgb(240, 240, 240); // #F0F0F0
        // --- HOVER COLORS & MOVEMENT DEFINITIONS ---
        private readonly Color HoverGray = Color.FromArgb(230, 230, 230); // Subtle hover color (#E6E6E6)
        private readonly Color ControlBaseColor = Color.White; // Base color for most white controls/panels
        private const int LIFT_OFFSET = 5; // Pixels to lift the panel by (New Constant)
        // -------------------------------------------

        // --- STORAGE MONITOR DEFINITIONS ---
        private readonly StorageMonitor _monitor = new StorageMonitor();

        private const int WarningThreshold = 75; // Orange warning above 75%
        private const int CriticalThreshold = 90; // Red warning above 90%
        private readonly Color WarningOrange = Color.FromArgb(245, 166, 35);
        private readonly Color CriticalRed = Color.FromArgb(208, 2, 27);
        // ---------------------------------------


        // =========================================================================
        // SECTION B: CONSTRUCTOR AND INITIALIZATION 
        // =========================================================================

        public frmDashboard()
        {
            InitializeComponent();
            ApplyDashboardDesign();
            InitializeStorageMonitor(); // Initialize the custom control and timer
        }

        private void ApplyDashboardDesign()
        {
            this.BackColor = BackgroundLight;

            // Apply styling to DataGridViews
            if (this.dgvRecentUploads != null)
            {
                SetupDataGridView(this.dgvRecentUploads, "Uploads");
            }
            if (this.dgvRecentActivityLog != null)
            {
                SetupDataGridView(this.dgvRecentActivityLog, "ActivityLog");
            }

            // --- INITIAL CIRCULAR PROGRESS BAR SETUP ---
            // Assuming the CircularProgressBar is named 'cpDriveUsage' in the Designer
            if (this.cpDriveUsage != null)
            {
                this.cpDriveUsage.Minimum = 0;
                this.cpDriveUsage.Maximum = 100;
                this.cpDriveUsage.ProgressColor = AccentMaroon;
                this.cpDriveUsage.TrackColor = Color.LightGray;
                this.cpDriveUsage.BarWidth = 12;
                this.cpDriveUsage.ForeColor = AccentMaroon; // Color for the % text
                this.cpDriveUsage.Value = 1; // Force an initial draw
            }

            // --- FIX: Center the text in the Storage Usage Label ---
            if (this.lblStorageUsageDetails != null)
            {
                this.lblStorageUsageDetails.TextAlign = ContentAlignment.MiddleCenter; // Sets horizontal and vertical centering
            }

            // === HOVER/LIFT EFFECT SETUP ===
            // Attach hover effects to the specific panels
            AttachHoverEffects(this.pnlTotalGradesSheets);
            AttachHoverEffects(this.pnlTotalSubjects);
            AttachHoverEffects(this.pnlTotalProfessors);
            AttachHoverEffects(this.pnlTotalRecentlyUploads);
        }

        /// <summary>
        /// Helper function to attach MouseEnter/MouseLeave events to a control.
        /// </summary>
        private void AttachHoverEffects(Control control)
        {
            if (control != null)
            {
                // Unsubscribe first to prevent double-subscription if called multiple times
                control.MouseEnter -= Panel_MouseEnter;
                control.MouseLeave -= Panel_MouseLeave;

                control.MouseEnter += Panel_MouseEnter;
                control.MouseLeave += Panel_MouseLeave;
            }
        }

        /// <summary>
        /// Initializes the Custom Progress Bar and the Timer for storage monitoring.
        /// </summary>
        private void InitializeStorageMonitor()
        {
            // Assuming timer control is named 'timerStorageUpdate'
            // NOTE: You must have a Timer component added to your form in the Designer!
            if (this.cpDriveUsage == null || this.timerStorageUpdate == null)
            {
                Console.WriteLine("Error: Storage monitoring controls are missing or misnamed (cpDriveUsage or timerStorageUpdate).");
                return;
            }

            this.timerStorageUpdate.Interval = 10000; // Update every 10 seconds

            // Attach the method that runs every time the timer ticks (must be created in the Designer)
            this.timerStorageUpdate.Tick += new EventHandler(TimerStorageUpdate_Tick);

            // Start the initial update and the timer
            UpdateDriveStatus();
            this.timerStorageUpdate.Start();
        }


        // =========================================================================
        // SECTION C: DATA GRID VIEW STYLING LOGIC (ENHANCED) 
        // =========================================================================

        private void SetupDataGridView(DataGridView dgv, string type)
        {
            // --- General Appearance and Structure ---
            dgv.BackgroundColor = ControlBaseColor; // Use ControlBaseColor for consistency
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.EnableHeadersVisualStyles = false;

            // --- Header Style (Column Headers) ---
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = AccentMaroon;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(dgv.Font.FontFamily, 9, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = AccentMaroon;
            headerStyle.Padding = new Padding(5);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 30;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // --- Data Row Style (Cells) ---
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = ControlBaseColor;
            defaultCellStyle.ForeColor = Color.Black;
            defaultCellStyle.SelectionBackColor = Color.FromArgb(215, 150, 150);
            defaultCellStyle.SelectionForeColor = Color.Black;
            defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = BackgroundLight;
            alternatingStyle.ForeColor = Color.Black;
            alternatingStyle.SelectionBackColor = Color.FromArgb(215, 150, 150);
            alternatingStyle.SelectionForeColor = Color.Black;
            alternatingStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.AlternatingRowsDefaultCellStyle = alternatingStyle;

            // --- Column Configuration ---
            dgv.Columns.Clear();

            if (type == "Uploads")
            {
                dgv.Columns.Add("colTimestamp", "Timestamp");
                dgv.Columns.Add("colFilename", "File Name");
                dgv.Columns.Add("colSubject", "Subject");
                dgv.Columns.Add("colUploadedBy", "Uploaded By");

                // Button Column for Uploads
                dgv.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colAction",
                    HeaderText = "Action",
                    Text = "View",
                    UseColumnTextForButtonValue = true
                });

                // AutoSize Modes
                dgv.Columns["colTimestamp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colFilename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colSubject"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colUploadedBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colAction"].Width = 70;
                dgv.Columns["colAction"].MinimumWidth = 60;

                // Column Specific Alignment Overrides
                dgv.Columns["colTimestamp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colSubject"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colAction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Register the CellPainting event for custom button rendering
                dgv.CellPainting -= dgvRecentUploads_CellPainting;
                dgv.CellPainting += dgvRecentUploads_CellPainting;
            }
            // Configuration for Activity Log
            else if (type == "ActivityLog")
            {
                // Display Text: Date, User, Action, Details
                dgv.Columns.Add("colActivityDate", "Date");
                dgv.Columns.Add("colActivityUser", "User");
                dgv.Columns.Add("colActivityAction", "Action");
                dgv.Columns.Add("colActivityDetails", "Details");

                // Auto Size Modes
                dgv.Columns["colActivityDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityAction"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityDetails"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Column Specific Alignment Overrides
                dgv.Columns["colActivityDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colActivityUser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colActivityAction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        // =========================================================================
        // SECTION D: CUSTOM BUTTON RENDERING FIX (For 'View' button color in Uploads DGV)
        // =========================================================================

        private void dgvRecentUploads_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvRecentUploads.Columns.Contains("colAction") &&
                dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                // 1. Paint the background and border as normal
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                // 2. Define the area for the custom-colored button
                Rectangle buttonBounds = e.CellBounds;
                buttonBounds.Inflate(-5, -5);

                // 3. Draw the custom button background color (AccentMaroon)
                using (SolidBrush brush = new SolidBrush(AccentMaroon))
                {
                    e.Graphics.FillRectangle(brush, buttonBounds);
                }

                // 4. Draw the button text ("View") in White
                TextRenderer.DrawText(e.Graphics,
                    (string)e.Value,
                    e.CellStyle.Font,
                    buttonBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // 5. Signal that the painting for this cell is complete
                e.Handled = true;
            }
        }

        // =========================================================================
        // SECTION F: UI INTERACTION AND HOVER EFFECTS (UPDATED FOR LIFT ONLY - NO COLOR CHANGE)
        // =========================================================================

        /// <summary>
        /// Lifts the panel up when the mouse enters, without changing the background color.
        /// </summary>
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // LIFT EFFECT: Move the panel up by LIFT_OFFSET pixels
                control.Location = new Point(control.Location.X, control.Location.Y - LIFT_OFFSET);

                // Bring the control to the front so it visually overlaps adjacent controls
                control.BringToFront();
            }
        }

        /// <summary>
        /// Returns the panel to its original position when the mouse leaves, without changing the background color.
        /// </summary>
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // RETURN EFFECT: Move the panel back down by LIFT_OFFSET pixels
                control.Location = new Point(control.Location.X, control.Location.Y + LIFT_OFFSET);
            }
        }

        // =========================================================================
        // SECTION E: EVENT HANDLERS AND STORAGE MONITOR LOGIC
        // =========================================================================

        /// <summary>
        /// Method called by the Timer every 10 seconds to update the storage status.
        /// </summary>
        private void TimerStorageUpdate_Tick(object sender, EventArgs e)
        {
            UpdateDriveStatus();
        }

        /// <summary>
        /// Performs the actual drive status check and updates the UI controls (CircularProgressBar and Label).
        /// </summary>
        private void UpdateDriveStatus()
        {
            // Assuming controls are named 'cpDriveUsage' and 'lblStorageUsageDetails'
            if (this.cpDriveUsage == null || this.lblStorageUsageDetails == null) return;

            var usage = _monitor.GetDriveUsage();
            int percent = (int)Math.Round(usage.UsagePercent);

            // 1. Update the CircularProgressBar (cpDriveUsage)
            this.cpDriveUsage.Value = Math.Min(percent, 100);

            // 2. Set Conditional Coloring for visual warnings
            if (percent >= CriticalThreshold)
            {
                this.cpDriveUsage.ProgressColor = CriticalRed;
                this.cpDriveUsage.ForeColor = CriticalRed; // Change text color too
            }
            else if (percent >= WarningThreshold)
            {
                this.cpDriveUsage.ProgressColor = WarningOrange;
                this.cpDriveUsage.ForeColor = WarningOrange;
            }
            else
            {
                this.cpDriveUsage.ProgressColor = AccentMaroon; // Normal state is Maroon
                this.cpDriveUsage.ForeColor = AccentMaroon;
            }

            // 3. Update the detailed text label (lblStorageUsageDetails)
            string usedText = StorageMonitor.FormatBytes(usage.UsedBytes);
            string totalText = StorageMonitor.FormatBytes(usage.TotalBytes);

            this.lblStorageUsageDetails.Text = $"{usedText} / {totalText}";
        }

        // --- Other Existing Event Handlers (Retained) ---

        private void label10_Click(object sender, EventArgs e)
        {
            // Placeholder for any click event on a label
        }

        private void dgvRecentUploads_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle a click on the 'View' button in the dgvRecentUploads
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns.Contains("colAction") && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                if (dgvRecentUploads.Rows[e.RowIndex].Cells["colFilename"].Value is string filename)
                {
                    MessageBox.Show($"Initiating view action for file: {filename}", "View Record");
                }
            }
        }

        private void dgvRecentActivityLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add specific handling for the Activity Log if needed.
        }

        private void cpStorageCapacity_Click(object sender, EventArgs e)
        {
            // Event handler for the circular progress bar click (kept as-is)
        }

        private void lblStorageUsageDetails_Click(object sender, EventArgs e)
        {
            // Event handler for the label click (kept as-is)
        }

        // Paint event handlers (left as-is, they only exist for designer purposes)
        private void pnlTotalGradesSheets_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalSubjects_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalProfessors_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalRecentlyUploads_Paint(object sender, PaintEventArgs e) { }

        private void timerStorageUpdate_Tick_1(object sender, EventArgs e)
        {

        }
    }
}