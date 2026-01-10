using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

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

            //// 3. TARGETED BUFFERING (Top Cards)
            //ForceDoubleBuffer(pnlTotalGradesSheets);
            //ForceDoubleBuffer(pnlTotalSubjects);
            //ForceDoubleBuffer(pnlTotalProfessors);
            //ForceDoubleBuffer(pnlTotalRecentlyUploads);

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
            AttachHoverEffects(dcRecentlyUploaded);

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
        private void SetupDataGridView(DataGridView dgv, string type)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.BackgroundColor = ControlBaseColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.EnableHeadersVisualStyles = false;

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

            dgv.Columns.Clear();

            if (type == "Uploads")
            {
                dgv.Columns.Add("colTimestamp", "Timestamp");
                dgv.Columns.Add("colFilename", "File Name");
                dgv.Columns.Add("colSubject", "Subject");
                dgv.Columns.Add("colUploadedBy", "Uploaded By");

                dgv.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colAction",
                    HeaderText = "Action",
                    Text = "View",
                    UseColumnTextForButtonValue = true
                });

                dgv.Columns["colTimestamp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colFilename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colSubject"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colUploadedBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["colAction"].Width = 70;
                dgv.Columns["colAction"].MinimumWidth = 60;

                dgv.Columns["colTimestamp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colSubject"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colAction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.CellPainting -= dgvRecentUploads_CellPainting;
                dgv.CellPainting += dgvRecentUploads_CellPainting;
            }
            else if (type == "ActivityLog")
            {
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

        // =========================================================================
        // SECTION D: CUSTOM BUTTON RENDERING
        // =========================================================================
        private void dgvRecentUploads_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvRecentUploads.Columns.Contains("colAction") &&
                dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                Rectangle buttonBounds = e.CellBounds;
                buttonBounds.Inflate(-5, -5);

                using (SolidBrush brush = new SolidBrush(AccentMaroon))
                {
                    e.Graphics.FillRectangle(brush, buttonBounds);
                }

                TextRenderer.DrawText(e.Graphics,
                    (string)e.Value,
                    e.CellStyle.Font,
                    buttonBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
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


    }
}