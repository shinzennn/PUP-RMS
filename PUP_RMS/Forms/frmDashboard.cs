using PUP_RMS.Core;
using PUP_RMS.Helper; 
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{

    public partial class frmDashboard : Form
    {
        // --- FADE TIMER ---
        private Timer tmrFadeIn;

        // =========================================================================
        // SECTION A: COLOR AND CONTROL DEFINITIONS
        // =========================================================================
        private readonly Color AccentMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color StatusGreen = Color.FromArgb(40, 167, 69);
        private readonly Color BackgroundLight = Color.FromArgb(240, 240, 240);
        private readonly Color ControlBaseColor = Color.White;
        private const int ZOOM_OFFSET = 4;

        // --- STORAGE MONITOR SETTINGS ---
        // Thresholds for changing color
        private const int WarningThreshold = 75;
        private const int CriticalThreshold = 90;
        private readonly Color WarningOrange = Color.FromArgb(245, 166, 35);
        private readonly Color CriticalRed = Color.FromArgb(208, 2, 27);

        // Store default colors to restore them after a warning
        private Color _defaultGradientStart;
        private Color _defaultGradientEnd;

        // =========================================================================
        // SECTION B: CONSTRUCTOR AND INITIALIZATION 
        // =========================================================================

        public frmDashboard()
        {
            // 1. START INVISIBLE (Fade Effect)
            this.Opacity = 0;

            // 2. GLOBAL FORM BUFFERING
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            if(this.cpDriveUsage != null) this.cpDriveUsage.Anchor = AnchorStyles.None;

            // Run the math every time the Dashboard resizes
            this.Resize += (s, e) => ResizeChart();

            // Also run it when the specific panel holding the chart resizes
            if (this.cpDriveUsage != null && this.cpDriveUsage.Parent != null)
            {
                this.cpDriveUsage.Parent.Resize += (s, e) => ResizeChart();
            }

            // 4. GLOBAL RECURSIVE BUFFERING
            ApplyDoubleBufferingRecursively(this.Controls);

            // 5. SETUP LOGIC
            ApplyDashboardDesign();
            InitializeFadeTimer();

            // 6. HOOK EVENTS
            this.Load += FrmDashboard_Load;

            // 7. SETUP STORAGE TIMER
            if (this.timerStorageUpdate != null)
            {
                this.timerStorageUpdate.Interval = 5000; // Update every 5 seconds
                this.timerStorageUpdate.Tick += TimerStorageUpdate_Tick;
            }
        }


        // --- PERFORMANCE FIX: WS_CLIPCHILDREN ---
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000;  // WS_CLIPCHILDREN
                return cp;
            }
        }

        // --- HELPER: ADVANCED DOUBLE BUFFERING ---
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);

            MethodInfo setStyle = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            if (setStyle != null)
            {
                setStyle.Invoke(c, new object[] { ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true });
            }
        }

        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren)
                {
                    ApplyDoubleBufferingRecursively(c.Controls);
                }
            }
        }

        private void ForceDoubleBuffer(Control parent)
        {
            if (parent == null) return;
            SetDoubleBuffered(parent);
            ApplyDoubleBufferingRecursively(parent.Controls);
        }

        // =========================================================================
        // SECTION: FADE IN LOGIC & LOADING
        // =========================================================================
        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer();
            tmrFadeIn.Interval = 10;
            tmrFadeIn.Tick += TmrFadeIn_Tick;
        }

        private void TmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                tmrFadeIn.Stop();
                return;
            }

            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                tmrFadeIn.Stop();
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();

            // Capture the Gradient Colors set in the Designer Properties
            if (this.cpDriveUsage != null)
            {
                _defaultGradientStart = this.cpDriveUsage.GradientStart;
                _defaultGradientEnd = this.cpDriveUsage.GradientEnd;
            }

            this.SuspendLayout();
            this.ResumeLayout(true);
            tmrFadeIn.Start();

            // Run storage check immediately
            UpdateDriveStatus();
            if (timerStorageUpdate != null) timerStorageUpdate.Start();

            LoadDashboardCounts();
            LoadRecentUploads();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (tmrFadeIn != null) tmrFadeIn.Stop();
            if (timerStorageUpdate != null) timerStorageUpdate.Stop();

            base.OnFormClosing(e);
        }

        // =========================================================================
        // SECTION: DESIGN & LOGIC
        // =========================================================================
        private void ApplyDashboardDesign()
        {
            // --- GRID VIEW SETUP ---
            if (this.dgvRecentUploads != null) SetupDataGridView(this.dgvRecentUploads, "Uploads");

            // --- CIRCULAR BAR SETUP (RESPECTS DESIGNER PROPERTIES) ---
            // We only enforce MIN/MAX here. Colors are left to the Designer properties.
            if (this.cpDriveUsage != null)
            {
                this.cpDriveUsage.Minimum = 0;
                this.cpDriveUsage.Maximum = 100;

                // IMPORTANT: We do NOT set ProgressColor here anymore.
                // This ensures your Gradient from the designer works.
            }

            if (this.lblStorageUsageDetails != null)
            {
                this.lblStorageUsageDetails.TextAlign = ContentAlignment.MiddleCenter;
            }
            // Attach zoom effect to your DashboardCards
            AttachHoverEffects(dcTotalGradesheets);
            AttachHoverEffects(dcTotalSubjects);
            AttachHoverEffects(dcTotalProfessors);
            AttachHoverEffects(dcTotalProgram);
            AttachHoverEffects(dcTotalProgram);

        }

        private void AttachHoverEffects(Control control)
        {
            if (control != null)
            {
                control.MouseEnter -= Panel_MouseEnter;
                control.MouseLeave -= Panel_MouseLeave;
                control.MouseEnter += Panel_MouseEnter;
                control.MouseLeave += Panel_MouseLeave;
            }
        }

        // =========================================================================
        // SECTION C: DATA GRID VIEW STYLING LOGIC
        // =========================================================================
        // 1. ADD THIS VARIABLE at the top of your class (inside frmDashboard)
        // 1. ADD THIS VARIABLE at the top of your class (inside frmDashboard)
        private Point _hoveredActionCell = new Point(-1, -1);

        // 2. REPLACE your SetupDataGridView method
        private void SetupDataGridView(DataGridView dgv, string type)
        {
            // Enable Double Buffering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.ReadOnly = true;
            dgv.MultiSelect = false;

            dgv.BackgroundColor = ControlBaseColor;
            dgv.RowTemplate.Height = 45;
            dgv.ColumnHeadersHeight = 40;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.EnableHeadersVisualStyles = false;

            // Header Style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = AccentMaroon;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(dgv.Font.FontFamily, 9, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = AccentMaroon;
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.Padding = new Padding(5);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 30;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default Cell Styles
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = ControlBaseColor;
            defaultCellStyle.ForeColor = Color.Black;
            defaultCellStyle.SelectionBackColor = ControlBaseColor;
            defaultCellStyle.SelectionForeColor = Color.Black;
            defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = BackgroundLight;
            alternatingStyle.ForeColor = Color.Black;
            alternatingStyle.SelectionBackColor = BackgroundLight;
            alternatingStyle.SelectionForeColor = Color.Black;
            alternatingStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.AlternatingRowsDefaultCellStyle = alternatingStyle;

            dgv.Columns.Clear();

            if (type == "Uploads")
            {
                dgv.Columns.Add("colFilename", "File Name");
                dgv.Columns.Add("colCourse", "Course");
                dgv.Columns.Add("colUploadedBy", "Uploaded By");

                dgv.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colAction",
                    HeaderText = "Action",
                    Text = "View",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                });

                // Sizing
                dgv.Columns["colFilename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colCourse"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colUploadedBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colAction"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv.Columns["colFilename"].FillWeight = 45;
                dgv.Columns["colUploadedBy"].FillWeight = 25;
                dgv.Columns["colCourse"].FillWeight = 15;
                dgv.Columns["colAction"].FillWeight = 15;

                // Alignment
                dgv.Columns["colFilename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns["colCourse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colUploadedBy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colAction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet;

                // --- HOOK EVENTS FOR PAINTING AND HOVER ---
                dgv.CellPainting -= dgvRecentUploads_CellPainting;
                dgv.CellPainting += dgvRecentUploads_CellPainting;

                dgv.CellMouseEnter -= dgvRecentUploads_CellMouseEnter;
                dgv.CellMouseEnter += dgvRecentUploads_CellMouseEnter;

                dgv.CellMouseLeave -= dgvRecentUploads_CellMouseLeave;
                dgv.CellMouseLeave += dgvRecentUploads_CellMouseLeave;
            }
            else if (type == "ActivityLog")
            {
                // Activity Log Logic
                dgv.Columns.Add("colActivityDate", "Date");
                dgv.Columns.Add("colActivityUser", "User");
                dgv.Columns.Add("colActivityAction", "Action");
                dgv.Columns.Add("colActivityDetails", "Details");
                dgv.Columns["colActivityDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityAction"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityDetails"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colActivityDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colActivityUser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colActivityAction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // 3. ADD Mouse Enter Event
        private void dgvRecentUploads_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                _hoveredActionCell = new Point(e.ColumnIndex, e.RowIndex);
                dgvRecentUploads.InvalidateCell(e.ColumnIndex, e.RowIndex); // Force repaint for color change
                dgvRecentUploads.Cursor = Cursors.Hand;
            }
        }

        // 4. ADD Mouse Leave Event
        private void dgvRecentUploads_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                _hoveredActionCell = new Point(-1, -1); // Reset
                dgvRecentUploads.InvalidateCell(e.ColumnIndex, e.RowIndex); // Force repaint to reset color
                dgvRecentUploads.Cursor = Cursors.Default;
            }
        }

        // 5. REPLACE CellPainting Event (Draws Text + Hover Color)
        private void dgvRecentUploads_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvRecentUploads.Columns.Contains("colAction") &&
                dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                // 1. Paint the standard cell background
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                // 2. Define the "Button" size
                // Inflate(-15, -10) shrinks the colored box so it is smaller than the cell
                Rectangle buttonBounds = e.CellBounds;
                buttonBounds.Inflate(-15, -10);

                // 3. Determine Color (Green if hovered, Maroon if not)
                bool isHovered = (e.ColumnIndex == _hoveredActionCell.X && e.RowIndex == _hoveredActionCell.Y);
                Color buttonColor = isHovered ? Color.Goldenrod: AccentMaroon;

                // 4. Draw the Colored Button Background
                using (SolidBrush brush = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillRectangle(brush, buttonBounds);
                }

                // 5. Draw the Text "View"
                // We use "View" explicitly here.
                TextRenderer.DrawText(e.Graphics,
                    "View",
                    new Font(e.CellStyle.Font.FontFamily, 8, FontStyle.Regular),
                    buttonBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; // Tell system we finished painting
            }
        }

        // =========================================================================
        // SECTION F: UI INTERACTION AND HOVER EFFECTS
        // =========================================================================
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // 1. Move it up and left slightly
                control.Location = new Point(control.Location.X - (ZOOM_OFFSET / 2), control.Location.Y - ZOOM_OFFSET);

                // 2. Make it slightly larger
                control.Size = new Size(control.Width + ZOOM_OFFSET, control.Height + ZOOM_OFFSET);

                // 3. Bring it to the front so it overlaps other cards
                control.BringToFront();

                // 4. If your card has a shadow property, you can deepen it here
                // Example: if (control is DashboardCard dc) dc.ShadowDepth += 2;
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // 1. Restore original size
                control.Size = new Size(control.Width - ZOOM_OFFSET, control.Height - ZOOM_OFFSET);

                // 2. Restore original position
                control.Location = new Point(control.Location.X + (ZOOM_OFFSET / 2), control.Location.Y + ZOOM_OFFSET);

                // Example: if (control is DashboardCard dc) dc.ShadowDepth -= 2;
            }

        }
        // =========================================================================
        // SECTION E: REAL-TIME STORAGE UPDATE LOGIC
        // =========================================================================
        private void TimerStorageUpdate_Tick(object sender, EventArgs e)
        {
            UpdateDriveStatus();
        }

        private void UpdateDriveStatus()
        {
            if (this.cpDriveUsage == null || this.lblStorageUsageDetails == null || this.IsDisposed) return;

            try
            {
                // 1. Get Drive Info directly (No external class needed)
                DriveInfo drive = new DriveInfo("C");

                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize;
                    long freeSpace = drive.TotalFreeSpace;
                    long usedSpace = totalSpace - freeSpace;

                    // 2. Calculate Percentage
                    int percent = (int)((double)usedSpace / totalSpace * 100);

                    // 3. Update Progress Bar
                    this.cpDriveUsage.Value = Math.Min(percent, 100);

                    // 4. Handle Colors (Only override if Warning/Critical)
                    // If Normal, we restore the colors captured in Load event (The Designer Properties)
                    if (percent >= CriticalThreshold)
                    {
                        this.cpDriveUsage.GradientStart = CriticalRed;
                        this.cpDriveUsage.GradientEnd = CriticalRed; // Solid Red
                    }
                    else if (percent >= WarningThreshold)
                    {
                        this.cpDriveUsage.GradientStart = WarningOrange;
                        this.cpDriveUsage.GradientEnd = WarningOrange; // Solid Orange
                    }
                    else
                    {
                        // Restore Designer Properties (Maroon Gradient)
                        this.cpDriveUsage.GradientStart = _defaultGradientStart;
                        this.cpDriveUsage.GradientEnd = _defaultGradientEnd;
                    }

                    // 5. Update Text
                    string usedText = FormatBytes(usedSpace);
                    string totalText = FormatBytes(totalSpace);
                    this.lblStorageUsageDetails.Text = $"{usedText} / {totalText}";
                }
            }
            catch
            {
                // Silent fail or set text to error
                this.lblStorageUsageDetails.Text = "Storage Error";
            }
        }
        private void LoadDashboardCounts()
        {
            // Now the Form doesn't know about SQL. It just asks the Helper.

            // 1. Grade Sheets
            if (dcTotalGradesheets != null)
            {
                dcTotalGradesheets.ValueText = DashboardHelper.GetGradeSheetCount();
            }

            // 2. Subjects
            if (dcTotalSubjects != null)
            {
                dcTotalSubjects.ValueText = DashboardHelper.GetSubjectCount();
            }

            // 3. Professors
            if (dcTotalProfessors != null)
            {
                dcTotalProfessors.ValueText = DashboardHelper.GetProfessorCount();
            }

            if (dcTotalProgram != null)
            {
                dcTotalProgram.ValueText = DashboardHelper.GetProgramCount();
            }
        }

        // Helper for formatting
        private string FormatBytes(long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }
            return String.Format("{0:0.00} {1}", dblSByte, suffix[i]);
        }

        // =========================================================================
        // EMPTY EVENTS (Keep these so Visual Studio doesn't error out)
        // =========================================================================
        private void label10_Click(object sender, EventArgs e) { }
        private void dgvRecentUploads_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns.Contains("colAction") && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                if (dgvRecentUploads.Rows[e.RowIndex].Cells["colFilename"].Value is string filename)
                {
                    MessageBox.Show($"Initiating view action for file: {filename}", "View Record");
                }
            }
        }

        private void ResizeChart()
        {
            // Safety Check: Make sure the chart exists
            if (this.cpDriveUsage == null || this.cpDriveUsage.Parent == null) return;

            // 1. Get the container (The TableLayoutPanel cell holding the chart)
            Control container = this.cpDriveUsage.Parent;

            // 2. Calculate the biggest square that fits (Width vs Height)
            // We subtract 20 to give it a little breathing room (padding)
            int size = Math.Min(container.Width, container.Height) - 60;

            // 3. Apply the new size (Only if it's a reasonable size)
            if (size > 50)
            {
                this.cpDriveUsage.Size = new Size(size, size);

                // 4. Force Center (Manually calculate middle position)
                this.cpDriveUsage.Left = (container.Width - this.cpDriveUsage.Width) / 2;
                // If you are in a TableLayout, Top centering happens automatically if Anchor is None, 
                // but this line ensures it works even in a normal Panel:
                this.cpDriveUsage.Top = (container.Height - this.cpDriveUsage.Height) / 2;
            }
        }

        private void dgvRecentActivityLog_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cpStorageCapacity_Click(object sender, EventArgs e) { }
        private void lblStorageUsageDetails_Click(object sender, EventArgs e) { }
        private void pnlTotalGradesSheets_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalSubjects_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalProfessors_Paint(object sender, PaintEventArgs e) { }
        private void pnlTotalRecentlyUploads_Paint(object sender, PaintEventArgs e) { }
        private void timerStorageUpdate_Tick_1(object sender, EventArgs e) { }
        private void frmDashboard_Load_1(object sender, EventArgs e) { }
        private void cpDriveUsage_Click(object sender, EventArgs e) { }

        private void pnlBySubject_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void pnlByProgram_Click_1(object sender, EventArgs e)
        {
            frmDistributionProgram frm = new frmDistributionProgram();
            frmDistributionProgram.ShowWithDimmer(this, frm);
        }

        private void pnlByProfessor_Click_1(object sender, EventArgs e)
        {
            frmDistributionProfessor frm = new frmDistributionProfessor();
            frmDistributionProfessor.ShowWithDimmer(this, frm);
        }


        private void pnlByYear_Sem_Click_1(object sender, EventArgs e)
        {
            frmDistributionYear_Sem frm = new frmDistributionYear_Sem();
            frmDistributionYear_Sem.ShowWithDimmer(this, frm);
        }
        private void pnlBySubject_Click_1(object sender, EventArgs e)
        {

            frmDistributionSubject frm = new frmDistributionSubject();
            frmDistributionSubject.ShowWithDimmer(this, frm);
        }

        private void dcTotalGradesheets_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dcTotalSubjects_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dcTotalProfessors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dcRecentlyUploaded_Paint(object sender, PaintEventArgs e)
        {

        }

        private void recentActivityLog1_Click(object sender, EventArgs e)
        {

        }

        private void recentActivityLog1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void headerPanelCard5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlByProgram_Paint(object sender, PaintEventArgs e)
        {

        }

   
        private void pnlBySubject_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pnlByYear_Sem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cpDriveUsage_Click_1(object sender, EventArgs e)
        {

        }

        private void dcTotalGradesheets_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dvgActivityLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timerActivityLog_Tick(object sender, EventArgs e)
        {
             // We call the public load method we created earlier
                recentActivityLog1.LoadDefaultActivities();
                LoadDashboardCounts();

        }

        public void RefreshActivityLog()
        {
            if (Application.OpenForms["frmDashboard"] is frmDashboard dash)
            {
                dash.recentActivityLog1.LoadDefaultActivities();
            }
        }

        // Add this method inside frmDashboard class
        private void LoadRecentUploads()
        {
            try
            {
                // 1. Get data from the Helper
                DataTable dt = DashboardHelper.recentlyUploads();

                // 2. Clear existing rows to prevent duplicates
                if (dgvRecentUploads != null)
                {
                    dgvRecentUploads.Rows.Clear();

                    // 3. Loop through database rows and add to Grid
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            dgvRecentUploads.Rows.Add(
                                row["Filename"].ToString(),       
                                row["CourseCode"].ToString(),     
                                row["UploadedBy"].ToString(),    
                                "View"                            
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading recent uploads: " + ex.Message);
            }
        }
        private void dgvRecentUploads_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DashboardHelper.recentlyUploads();
        }
    }
}