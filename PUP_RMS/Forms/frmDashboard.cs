
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
       
        private Timer tmrFadeIn;

       
        private readonly Color AccentMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color StatusGreen = Color.FromArgb(40, 167, 69);
        private readonly Color BackgroundLight = Color.FromArgb(240, 240, 240);
        private readonly Color ControlBaseColor = Color.White;
        private const int ZOOM_OFFSET = 4;

       
        private const int WarningThreshold = 75;
        private const int CriticalThreshold = 90;
        private readonly Color WarningOrange = Color.FromArgb(245, 166, 35);
        private readonly Color CriticalRed = Color.FromArgb(208, 2, 27);

        private Color _defaultGradientStart;
        private Color _defaultGradientEnd;

        public frmDashboard()
        {
            this.Opacity = 0;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            if (this.cpDriveUsage != null) this.cpDriveUsage.Anchor = AnchorStyles.None;
            this.Resize += (s, e) => ResizeChart();

            if (this.cpDriveUsage != null && this.cpDriveUsage.Parent != null)
            {
                this.cpDriveUsage.Parent.Resize += (s, e) => ResizeChart();
            }

            ApplyDoubleBufferingRecursively(this.Controls);

            ApplyDashboardDesign();
            InitializeFadeTimer();

            this.Load += FrmDashboard_Load;
            if (this.timerStorageUpdate != null)
            {
                this.timerStorageUpdate.Interval = 5000; 
                this.timerStorageUpdate.Tick += TimerStorageUpdate_Tick;
            }
        }

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

        // SECTION: FADE IN LOGIC & LOADING
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
            if (this.cpDriveUsage != null)
            {
                _defaultGradientStart = this.cpDriveUsage.GradientStart;
                _defaultGradientEnd = this.cpDriveUsage.GradientEnd;
            }

            this.SuspendLayout();
            this.ResumeLayout(true);
            tmrFadeIn.Start();
            UpdateDriveStatus();
            if (timerStorageUpdate != null) timerStorageUpdate.Start();

            LoadDashboardCounts();
            LoadRecentUploads();
            string fullname = MainDashboard.CurrentAccount.FirstName + " " + MainDashboard.CurrentAccount.LastName;
            LoadAccountName(fullname);
        }

        public void LoadAccountName(string fullname)
        {
            lblAccountName.Text = fullname;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (tmrFadeIn != null) tmrFadeIn.Stop();
            if (timerStorageUpdate != null) timerStorageUpdate.Stop();

            base.OnFormClosing(e);
        }

        private void ApplyDashboardDesign()
        {
            if (this.dgvRecentUploads != null) SetupDataGridView(this.dgvRecentUploads, "Uploads");
            if (this.cpDriveUsage != null)
            {
                this.cpDriveUsage.Minimum = 0;
                this.cpDriveUsage.Maximum = 100;
            }

            if (this.lblStorageUsageDetails != null)
            {
                this.lblStorageUsageDetails.TextAlign = ContentAlignment.MiddleCenter;
            }
            AttachHoverEffects(dcTotalGradesheets);
            AttachHoverEffects(dcTotalSubjects);
            AttachHoverEffects(dcTotalProfessors);
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

      
       
        private Point _hoveredActionCell = new Point(-1, -1);
        private void SetupDataGridView(DataGridView dgv, string type)
        {
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



      
                dgv.Columns["colFilename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colCourse"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["colUploadedBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                dgv.Columns["colFilename"].FillWeight = 45;
                dgv.Columns["colUploadedBy"].FillWeight = 25;
                dgv.Columns["colCourse"].FillWeight = 15;


                dgv.Columns["colFilename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns["colCourse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["colUploadedBy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                dgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet;


                dgv.CellPainting -= dgvRecentUploads_CellPainting;
                dgv.CellPainting += dgvRecentUploads_CellPainting;

                dgv.CellMouseEnter -= dgvRecentUploads_CellMouseEnter;
                dgv.CellMouseEnter += dgvRecentUploads_CellMouseEnter;

                dgv.CellMouseLeave -= dgvRecentUploads_CellMouseLeave;
                dgv.CellMouseLeave += dgvRecentUploads_CellMouseLeave;
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

        private void dgvRecentUploads_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                _hoveredActionCell = new Point(e.ColumnIndex, e.RowIndex);
                dgvRecentUploads.InvalidateCell(e.ColumnIndex, e.RowIndex); 
                dgvRecentUploads.Cursor = Cursors.Hand;
            }
        }

        private void dgvRecentUploads_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                _hoveredActionCell = new Point(-1, -1); 
                dgvRecentUploads.InvalidateCell(e.ColumnIndex, e.RowIndex); 
                dgvRecentUploads.Cursor = Cursors.Default;
            }
        }

        private void dgvRecentUploads_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvRecentUploads.Columns.Contains("colAction") &&
                dgvRecentUploads.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                Rectangle buttonBounds = e.CellBounds;
                buttonBounds.Inflate(-15, -10);
                bool isHovered = (e.ColumnIndex == _hoveredActionCell.X && e.RowIndex == _hoveredActionCell.Y);
                Color buttonColor = isHovered ? Color.Goldenrod : AccentMaroon;

                using (SolidBrush brush = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillRectangle(brush, buttonBounds);
                }
                TextRenderer.DrawText(e.Graphics,
                    "View",
                    new Font(e.CellStyle.Font.FontFamily, 8, FontStyle.Regular),
                    buttonBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; 
            }
        }
        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.Location = new Point(control.Location.X - (ZOOM_OFFSET / 2), control.Location.Y - ZOOM_OFFSET);
                control.Size = new Size(control.Width + ZOOM_OFFSET, control.Height + ZOOM_OFFSET);
                control.BringToFront();
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.Size = new Size(control.Width - ZOOM_OFFSET, control.Height - ZOOM_OFFSET);
                control.Location = new Point(control.Location.X + (ZOOM_OFFSET / 2), control.Location.Y + ZOOM_OFFSET);
            }

        }
        private void TimerStorageUpdate_Tick(object sender, EventArgs e)
        {
            UpdateDriveStatus();
        }

        private void UpdateDriveStatus()
        {
            if (this.cpDriveUsage == null || this.lblStorageUsageDetails == null || this.IsDisposed) return;

            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "GradeSheets");

                long usedSpace = GetDirectorySize(folderPath);
                string driveRoot = Path.GetPathRoot(folderPath);
                DriveInfo drive = new DriveInfo(driveRoot);

                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize;

                    
                    double percentRaw = ((double)usedSpace / totalSpace) * 100;
                    int percent = (int)percentRaw;
                    if (percent < 0) percent = 0;
                    if (percent > 100) percent = 100;

                 
                    if (usedSpace > 0 && percent == 0) percent = 1;

                    this.cpDriveUsage.Value = percent;

                 
                    if (percent >= CriticalThreshold)
                    {
                        this.cpDriveUsage.GradientStart = CriticalRed;
                        this.cpDriveUsage.GradientEnd = CriticalRed;
                    }
                    else if (percent >= WarningThreshold)
                    {
                        this.cpDriveUsage.GradientStart = WarningOrange;
                        this.cpDriveUsage.GradientEnd = WarningOrange;
                    }
                    else
                    {
                        this.cpDriveUsage.GradientStart = _defaultGradientStart;
                        this.cpDriveUsage.GradientEnd = _defaultGradientEnd;
                    }

                    
                    string usedText = FormatBytes(usedSpace);
                    this.lblStorageUsageDetails.Text = $"RMS Data: {usedText}";
                }
            }
            catch
            {
                this.lblStorageUsageDetails.Text = "Storage Error";
            }
        }

        private void LoadDashboardCounts()
        {
            
            if (dcTotalGradesheets != null)
            {
                dcTotalGradesheets.ValueText = DashboardHelper.GetGradeSheetCount();
            }

            
            if (dcTotalSubjects != null)
            {
                dcTotalSubjects.ValueText = DashboardHelper.GetSubjectCount();
            }

           
            if (dcTotalProfessors != null)
            {
                dcTotalProfessors.ValueText = DashboardHelper.GetProfessorCount();
            }

            if (dcTotalProgram != null)
            {
                dcTotalProgram.ValueText = DashboardHelper.GetProgramCount();
            }
        }

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
            
            if (this.cpDriveUsage == null || this.cpDriveUsage.Parent == null) return;
            Control container = this.cpDriveUsage.Parent;
            int size = Math.Min(container.Width, container.Height) - 60;
            if (size > 50)
            {
                this.cpDriveUsage.Size = new Size(size, size);
                this.cpDriveUsage.Left = (container.Width - this.cpDriveUsage.Width) / 2;
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

        private void LoadRecentUploads()
        {
            try
            {      
                DataTable dt = DashboardHelper.recentlyUploads();
                if (dgvRecentUploads != null)
                {
                    dgvRecentUploads.Rows.Clear();
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
        private long GetDirectorySize(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return 0;
            }

            try
            {
                long startDirectorySize = 0;
                string[] fileNames = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

                foreach (string name in fileNames)
                {
                    FileInfo info = new FileInfo(name);
                    startDirectorySize += info.Length;
                }

                return startDirectorySize;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating folder size: " + ex.Message);
                return 0;
            }
        }

        private void lnkViewStorage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form dimmer = new Form();
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.Opacity = 0.50d;
            dimmer.BackColor = Color.Black;
            dimmer.ShowInTaskbar = false;
            dimmer.Location = this.Location;
            dimmer.Size = this.Size;
            dimmer.Owner = this;
            dimmer.Show();
            frmStorageDetails frm = new frmStorageDetails();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(dimmer);
            dimmer.Dispose();
        }

        private void lblStorageUsageDetails_Click_1(object sender, EventArgs e)
        {

        }
    }
}
