namespace PUP_RMS.Forms
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.timerStorageUpdate = new System.Windows.Forms.Timer(this.components);
            this.headerPanelCard5 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dcRecentlyUploaded = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalGradesheets = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalProfessors = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalSubjects = new PUP_RMS.CustomControls.DashboardCard();
            this.headerPanelCard4 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.lblStorageUsageDetails = new System.Windows.Forms.Label();
            this.cpDriveUsage = new CircularProgressBar();
            this.headerPanelCard3 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dgvRecentUploads = new System.Windows.Forms.DataGridView();
            this.colUploadedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.headerPanelCard2 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dgvRecentActivityLog = new System.Windows.Forms.DataGridView();
            this.colActivityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colActivityDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanelCard1 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.pnlBySubject = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByProgram = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByYear_Sem = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByProfessor = new PUP_RMS.RecordDistributionPanelCard();
            this.roundedPanel3 = new PUP_RMS.RoundedPanel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.headerPanelCard5.SuspendLayout();
            this.headerPanelCard4.SuspendLayout();
            this.headerPanelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).BeginInit();
            this.headerPanelCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivityLog)).BeginInit();
            this.headerPanelCard1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStorageUpdate
            // 
            this.timerStorageUpdate.Tick += new System.EventHandler(this.timerStorageUpdate_Tick_1);
            // 
            // headerPanelCard5
            // 
            this.headerPanelCard5.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard5.BorderColor = System.Drawing.Color.Gainsboro;
            this.headerPanelCard5.BorderRadius = 20;
            this.headerPanelCard5.BorderThickness = 1;
            this.headerPanelCard5.ContentBackColor = System.Drawing.Color.WhiteSmoke;
            this.headerPanelCard5.Controls.Add(this.dcRecentlyUploaded);
            this.headerPanelCard5.Controls.Add(this.dcTotalGradesheets);
            this.headerPanelCard5.Controls.Add(this.dcTotalProfessors);
            this.headerPanelCard5.Controls.Add(this.dcTotalSubjects);
            this.headerPanelCard5.EnableHoverEffect = false;
            this.headerPanelCard5.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard5.HeaderFontSize = 15F;
            this.headerPanelCard5.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard5.HeaderHeight = 40;
            this.headerPanelCard5.HeaderLabel = "System Dashboard";
            this.headerPanelCard5.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard5.IconHeader")));
            this.headerPanelCard5.IconSize = 30;
            this.headerPanelCard5.Location = new System.Drawing.Point(2, 80);
            this.headerPanelCard5.Name = "headerPanelCard5";
            this.headerPanelCard5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard5.ShadowDepth = 4;
            this.headerPanelCard5.ShadowPadding = 5;
            this.headerPanelCard5.ShowHeaderDivider = false;
            this.headerPanelCard5.ShowShadow = true;
            this.headerPanelCard5.Size = new System.Drawing.Size(1114, 165);
            this.headerPanelCard5.TabIndex = 12;
            // 
            // dcRecentlyUploaded
            // 
            this.dcRecentlyUploaded.BackColor = System.Drawing.Color.Transparent;
            this.dcRecentlyUploaded.BorderRadius = 15;
            this.dcRecentlyUploaded.HeaderFontSize = 9F;
            this.dcRecentlyUploaded.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcRecentlyUploaded.HeaderText = "RECENTLY UPLOADED";
            this.dcRecentlyUploaded.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcRecentlyUploaded.IconCircleSize = 50;
            this.dcRecentlyUploaded.IconImage = ((System.Drawing.Image)(resources.GetObject("dcRecentlyUploaded.IconImage")));
            this.dcRecentlyUploaded.Location = new System.Drawing.Point(843, 54);
            this.dcRecentlyUploaded.Name = "dcRecentlyUploaded";
            this.dcRecentlyUploaded.PanelBackColor = System.Drawing.Color.White;
            this.dcRecentlyUploaded.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcRecentlyUploaded.ShadowDepth = 15;
            this.dcRecentlyUploaded.ShadowPadding = 10;
            this.dcRecentlyUploaded.ShowShadow = true;
            this.dcRecentlyUploaded.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcRecentlyUploaded.SideBarWidth = 5;
            this.dcRecentlyUploaded.Size = new System.Drawing.Size(225, 105);
            this.dcRecentlyUploaded.TabIndex = 9;
            this.dcRecentlyUploaded.ValueFontSize = 24F;
            this.dcRecentlyUploaded.ValueForeColor = System.Drawing.Color.Black;
            this.dcRecentlyUploaded.ValueText = "0";
            this.dcRecentlyUploaded.Paint += new System.Windows.Forms.PaintEventHandler(this.dcRecentlyUploaded_Paint);
            // 
            // dcTotalGradesheets
            // 
            this.dcTotalGradesheets.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalGradesheets.BorderRadius = 15;
            this.dcTotalGradesheets.HeaderFontSize = 9F;
            this.dcTotalGradesheets.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalGradesheets.HeaderText = "TOTAL GRADE SHEETS";
            this.dcTotalGradesheets.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalGradesheets.IconCircleSize = 50;
            this.dcTotalGradesheets.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalGradesheets.IconImage")));
            this.dcTotalGradesheets.Location = new System.Drawing.Point(29, 54);
            this.dcTotalGradesheets.Name = "dcTotalGradesheets";
            this.dcTotalGradesheets.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalGradesheets.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalGradesheets.ShadowDepth = 15;
            this.dcTotalGradesheets.ShadowPadding = 10;
            this.dcTotalGradesheets.ShowShadow = true;
            this.dcTotalGradesheets.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalGradesheets.SideBarWidth = 5;
            this.dcTotalGradesheets.Size = new System.Drawing.Size(225, 105);
            this.dcTotalGradesheets.TabIndex = 8;
            this.dcTotalGradesheets.ValueFontSize = 24F;
            this.dcTotalGradesheets.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalGradesheets.ValueText = "0";
            this.dcTotalGradesheets.Paint += new System.Windows.Forms.PaintEventHandler(this.dcTotalGradesheets_Paint);
            // 
            // dcTotalProfessors
            // 
            this.dcTotalProfessors.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalProfessors.BorderRadius = 15;
            this.dcTotalProfessors.HeaderFontSize = 9F;
            this.dcTotalProfessors.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalProfessors.HeaderText = "TOTAL PROFESSORS";
            this.dcTotalProfessors.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalProfessors.IconCircleSize = 50;
            this.dcTotalProfessors.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalProfessors.IconImage")));
            this.dcTotalProfessors.Location = new System.Drawing.Point(567, 54);
            this.dcTotalProfessors.Name = "dcTotalProfessors";
            this.dcTotalProfessors.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalProfessors.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalProfessors.ShadowDepth = 15;
            this.dcTotalProfessors.ShadowPadding = 10;
            this.dcTotalProfessors.ShowShadow = true;
            this.dcTotalProfessors.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalProfessors.SideBarWidth = 5;
            this.dcTotalProfessors.Size = new System.Drawing.Size(225, 105);
            this.dcTotalProfessors.TabIndex = 9;
            this.dcTotalProfessors.ValueFontSize = 24F;
            this.dcTotalProfessors.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalProfessors.ValueText = "0";
            this.dcTotalProfessors.Paint += new System.Windows.Forms.PaintEventHandler(this.dcTotalProfessors_Paint);
            // 
            // dcTotalSubjects
            // 
            this.dcTotalSubjects.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalSubjects.BorderRadius = 15;
            this.dcTotalSubjects.HeaderFontSize = 9F;
            this.dcTotalSubjects.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalSubjects.HeaderText = "TOTAL SUBJECTS";
            this.dcTotalSubjects.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalSubjects.IconCircleSize = 50;
            this.dcTotalSubjects.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalSubjects.IconImage")));
            this.dcTotalSubjects.Location = new System.Drawing.Point(297, 54);
            this.dcTotalSubjects.Name = "dcTotalSubjects";
            this.dcTotalSubjects.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalSubjects.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalSubjects.ShadowDepth = 15;
            this.dcTotalSubjects.ShadowPadding = 10;
            this.dcTotalSubjects.ShowShadow = true;
            this.dcTotalSubjects.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalSubjects.SideBarWidth = 5;
            this.dcTotalSubjects.Size = new System.Drawing.Size(225, 105);
            this.dcTotalSubjects.TabIndex = 9;
            this.dcTotalSubjects.ValueFontSize = 24F;
            this.dcTotalSubjects.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalSubjects.ValueText = "0";
            this.dcTotalSubjects.Paint += new System.Windows.Forms.PaintEventHandler(this.dcTotalSubjects_Paint);
            // 
            // headerPanelCard4
            // 
            this.headerPanelCard4.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard4.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard4.BorderRadius = 20;
            this.headerPanelCard4.BorderThickness = 0;
            this.headerPanelCard4.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard4.Controls.Add(this.lblStorageUsageDetails);
            this.headerPanelCard4.Controls.Add(this.cpDriveUsage);
            this.headerPanelCard4.EnableHoverEffect = false;
            this.headerPanelCard4.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard4.HeaderFontSize = 13F;
            this.headerPanelCard4.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard4.HeaderHeight = 40;
            this.headerPanelCard4.HeaderLabel = "Local Storage Used ";
            this.headerPanelCard4.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard4.IconHeader")));
            this.headerPanelCard4.IconSize = 25;
            this.headerPanelCard4.Location = new System.Drawing.Point(717, 245);
            this.headerPanelCard4.Name = "headerPanelCard4";
            this.headerPanelCard4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard4.ShadowDepth = 4;
            this.headerPanelCard4.ShadowPadding = 5;
            this.headerPanelCard4.ShowHeaderDivider = false;
            this.headerPanelCard4.ShowShadow = true;
            this.headerPanelCard4.Size = new System.Drawing.Size(399, 255);
            this.headerPanelCard4.TabIndex = 10;
            // 
            // lblStorageUsageDetails
            // 
            this.lblStorageUsageDetails.AutoSize = true;
            this.lblStorageUsageDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.lblStorageUsageDetails.Location = new System.Drawing.Point(85, 172);
            this.lblStorageUsageDetails.Name = "lblStorageUsageDetails";
            this.lblStorageUsageDetails.Size = new System.Drawing.Size(42, 13);
            this.lblStorageUsageDetails.TabIndex = 11;
            this.lblStorageUsageDetails.Text = "storage";
            this.lblStorageUsageDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStorageUsageDetails.Click += new System.EventHandler(this.lblStorageUsageDetails_Click);
            // 
            // cpDriveUsage
            // 
            this.cpDriveUsage.BackColor = System.Drawing.Color.Transparent;
            this.cpDriveUsage.BarWidth = 20;
            this.cpDriveUsage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cpDriveUsage.FontSize = 10;
            this.cpDriveUsage.GradientEnd = System.Drawing.Color.Maroon;
            this.cpDriveUsage.GradientStart = System.Drawing.Color.Maroon;
            this.cpDriveUsage.Location = new System.Drawing.Point(123, 49);
            this.cpDriveUsage.Maximum = 100;
            this.cpDriveUsage.Minimum = 0;
            this.cpDriveUsage.Name = "cpDriveUsage";
            this.cpDriveUsage.ProgressColor = System.Drawing.Color.Maroon;
            this.cpDriveUsage.Size = new System.Drawing.Size(109, 109);
            this.cpDriveUsage.TabIndex = 10;
            this.cpDriveUsage.Text = "circularProgressBar1";
            this.cpDriveUsage.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cpDriveUsage.Value = 0;
            this.cpDriveUsage.Click += new System.EventHandler(this.cpDriveUsage_Click);
            // 
            // headerPanelCard3
            // 
            this.headerPanelCard3.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard3.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard3.BorderRadius = 0;
            this.headerPanelCard3.BorderThickness = 0;
            this.headerPanelCard3.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard3.Controls.Add(this.dgvRecentUploads);
            this.headerPanelCard3.EnableHoverEffect = false;
            this.headerPanelCard3.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard3.HeaderFontSize = 13F;
            this.headerPanelCard3.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard3.HeaderHeight = 40;
            this.headerPanelCard3.HeaderLabel = "Recent Uploads";
            this.headerPanelCard3.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard3.IconHeader")));
            this.headerPanelCard3.IconSize = 25;
            this.headerPanelCard3.Location = new System.Drawing.Point(2, 245);
            this.headerPanelCard3.Name = "headerPanelCard3";
            this.headerPanelCard3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard3.ShadowDepth = 4;
            this.headerPanelCard3.ShadowPadding = 5;
            this.headerPanelCard3.ShowHeaderDivider = false;
            this.headerPanelCard3.ShowShadow = true;
            this.headerPanelCard3.Size = new System.Drawing.Size(717, 255);
            this.headerPanelCard3.TabIndex = 11;
            // 
            // dgvRecentUploads
            // 
            this.dgvRecentUploads.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentUploads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentUploads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentUploads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUploadedAt,
            this.colFileName,
            this.colSubject,
            this.colUploadedBy,
            this.colAction});
            this.dgvRecentUploads.Location = new System.Drawing.Point(14, 49);
            this.dgvRecentUploads.Name = "dgvRecentUploads";
            this.dgvRecentUploads.Size = new System.Drawing.Size(657, 86);
            this.dgvRecentUploads.TabIndex = 8;
            this.dgvRecentUploads.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecentUploads_CellContentClick);
            // 
            // colUploadedAt
            // 
            this.colUploadedAt.HeaderText = "Date Uploaded";
            this.colUploadedAt.Name = "colUploadedAt";
            // 
            // colFileName
            // 
            this.colFileName.HeaderText = "File Name";
            this.colFileName.Name = "colFileName";
            // 
            // colSubject
            // 
            this.colSubject.HeaderText = "Subject";
            this.colSubject.Name = "colSubject";
            // 
            // colUploadedBy
            // 
            this.colUploadedBy.HeaderText = "Uploaded By";
            this.colUploadedBy.Name = "colUploadedBy";
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            // 
            // headerPanelCard2
            // 
            this.headerPanelCard2.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard2.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard2.BorderRadius = 10;
            this.headerPanelCard2.BorderThickness = 0;
            this.headerPanelCard2.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard2.Controls.Add(this.dgvRecentActivityLog);
            this.headerPanelCard2.EnableHoverEffect = false;
            this.headerPanelCard2.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard2.HeaderFontSize = 13F;
            this.headerPanelCard2.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard2.HeaderHeight = 40;
            this.headerPanelCard2.HeaderLabel = "Recent Activity Log";
            this.headerPanelCard2.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard2.IconHeader")));
            this.headerPanelCard2.IconSize = 25;
            this.headerPanelCard2.Location = new System.Drawing.Point(2, 506);
            this.headerPanelCard2.Name = "headerPanelCard2";
            this.headerPanelCard2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard2.ShadowDepth = 4;
            this.headerPanelCard2.ShadowPadding = 5;
            this.headerPanelCard2.ShowHeaderDivider = false;
            this.headerPanelCard2.ShowShadow = true;
            this.headerPanelCard2.Size = new System.Drawing.Size(717, 255);
            this.headerPanelCard2.TabIndex = 9;
            // 
            // dgvRecentActivityLog
            // 
            this.dgvRecentActivityLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivityLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivityLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActivityDate,
            this.colActivityUser,
            this.colActivityAction,
            this.colActivityDetails});
            this.dgvRecentActivityLog.Location = new System.Drawing.Point(14, 48);
            this.dgvRecentActivityLog.Name = "dgvRecentActivityLog";
            this.dgvRecentActivityLog.Size = new System.Drawing.Size(657, 86);
            this.dgvRecentActivityLog.TabIndex = 8;
            this.dgvRecentActivityLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecentActivityLog_CellContentClick);
            // 
            // colActivityDate
            // 
            this.colActivityDate.HeaderText = "Date ";
            this.colActivityDate.Name = "colActivityDate";
            // 
            // colActivityUser
            // 
            this.colActivityUser.HeaderText = "User";
            this.colActivityUser.Name = "colActivityUser";
            // 
            // colActivityAction
            // 
            this.colActivityAction.HeaderText = "Action";
            this.colActivityAction.Name = "colActivityAction";
            // 
            // colActivityDetails
            // 
            this.colActivityDetails.HeaderText = "Details";
            this.colActivityDetails.Name = "colActivityDetails";
            // 
            // headerPanelCard1
            // 
            this.headerPanelCard1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard1.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard1.BorderRadius = 20;
            this.headerPanelCard1.BorderThickness = 0;
            this.headerPanelCard1.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard1.Controls.Add(this.pnlBySubject);
            this.headerPanelCard1.Controls.Add(this.pnlByProgram);
            this.headerPanelCard1.Controls.Add(this.pnlByYear_Sem);
            this.headerPanelCard1.Controls.Add(this.pnlByProfessor);
            this.headerPanelCard1.EnableHoverEffect = false;
            this.headerPanelCard1.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard1.HeaderFontSize = 13F;
            this.headerPanelCard1.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard1.HeaderHeight = 40;
            this.headerPanelCard1.HeaderLabel = "Record Distribution";
            this.headerPanelCard1.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard1.IconHeader")));
            this.headerPanelCard1.IconSize = 25;
            this.headerPanelCard1.Location = new System.Drawing.Point(717, 506);
            this.headerPanelCard1.Name = "headerPanelCard1";
            this.headerPanelCard1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard1.ShadowDepth = 4;
            this.headerPanelCard1.ShadowPadding = 5;
            this.headerPanelCard1.ShowHeaderDivider = false;
            this.headerPanelCard1.ShowShadow = true;
            this.headerPanelCard1.Size = new System.Drawing.Size(399, 255);
            this.headerPanelCard1.TabIndex = 9;
            // 
            // pnlBySubject
            // 
            this.pnlBySubject.BackColor = System.Drawing.Color.White;
            this.pnlBySubject.BorderColor = System.Drawing.Color.LightGray;
            this.pnlBySubject.BorderRadius = 15;
            this.pnlBySubject.BorderSize = 2;
            this.pnlBySubject.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlBySubject.CardIcon")));
            this.pnlBySubject.CardLabel = "By Subject";
            this.pnlBySubject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlBySubject.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlBySubject.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlBySubject.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlBySubject.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlBySubject.Location = new System.Drawing.Point(205, 154);
            this.pnlBySubject.Name = "pnlBySubject";
            this.pnlBySubject.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlBySubject.ShadowBlur = 15;
            this.pnlBySubject.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlBySubject.ShadowEnabled = true;
            this.pnlBySubject.ShadowOffset = 5;
            this.pnlBySubject.Size = new System.Drawing.Size(166, 82);
            this.pnlBySubject.TabIndex = 11;
            this.pnlBySubject.Click += new System.EventHandler(this.pnlBySubject_Click);
            this.pnlBySubject.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBySubject_Paint);
            // 
            // pnlByProgram
            // 
            this.pnlByProgram.BackColor = System.Drawing.Color.White;
            this.pnlByProgram.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByProgram.BorderRadius = 15;
            this.pnlByProgram.BorderSize = 2;
            this.pnlByProgram.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByProgram.CardIcon")));
            this.pnlByProgram.CardLabel = "By Program";
            this.pnlByProgram.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByProgram.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProgram.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProgram.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByProgram.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByProgram.Location = new System.Drawing.Point(21, 59);
            this.pnlByProgram.Name = "pnlByProgram";
            this.pnlByProgram.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByProgram.ShadowBlur = 15;
            this.pnlByProgram.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByProgram.ShadowEnabled = true;
            this.pnlByProgram.ShadowOffset = 5;
            this.pnlByProgram.Size = new System.Drawing.Size(166, 82);
            this.pnlByProgram.TabIndex = 10;
            this.pnlByProgram.Click += new System.EventHandler(this.pnlByProgram_Click);
            // 
            // pnlByYear_Sem
            // 
            this.pnlByYear_Sem.BackColor = System.Drawing.Color.White;
            this.pnlByYear_Sem.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByYear_Sem.BorderRadius = 15;
            this.pnlByYear_Sem.BorderSize = 2;
            this.pnlByYear_Sem.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByYear_Sem.CardIcon")));
            this.pnlByYear_Sem.CardLabel = "By Year/Sem";
            this.pnlByYear_Sem.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByYear_Sem.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByYear_Sem.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByYear_Sem.Location = new System.Drawing.Point(21, 154);
            this.pnlByYear_Sem.Name = "pnlByYear_Sem";
            this.pnlByYear_Sem.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByYear_Sem.ShadowBlur = 15;
            this.pnlByYear_Sem.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.ShadowEnabled = true;
            this.pnlByYear_Sem.ShadowOffset = 5;
            this.pnlByYear_Sem.Size = new System.Drawing.Size(166, 82);
            this.pnlByYear_Sem.TabIndex = 11;
            this.pnlByYear_Sem.Click += new System.EventHandler(this.pnlByYear_Sem_Click);
            // 
            // pnlByProfessor
            // 
            this.pnlByProfessor.BackColor = System.Drawing.Color.White;
            this.pnlByProfessor.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByProfessor.BorderRadius = 15;
            this.pnlByProfessor.BorderSize = 2;
            this.pnlByProfessor.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByProfessor.CardIcon")));
            this.pnlByProfessor.CardLabel = "By Professor";
            this.pnlByProfessor.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByProfessor.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByProfessor.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByProfessor.Location = new System.Drawing.Point(205, 59);
            this.pnlByProfessor.Name = "pnlByProfessor";
            this.pnlByProfessor.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByProfessor.ShadowBlur = 15;
            this.pnlByProfessor.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.ShadowEnabled = true;
            this.pnlByProfessor.ShadowOffset = 5;
            this.pnlByProfessor.Size = new System.Drawing.Size(166, 82);
            this.pnlByProfessor.TabIndex = 11;
            this.pnlByProfessor.Click += new System.EventHandler(this.pnlByProfessor_Click);
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 10;
            this.roundedPanel3.BorderSize = 0;
            this.roundedPanel3.Controls.Add(this.gradientLabel1);
            this.roundedPanel3.Controls.Add(this.label10);
            this.roundedPanel3.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.roundedPanel3.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel3.Location = new System.Drawing.Point(12, 4);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.ShadowBlur = 15;
            this.roundedPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel3.ShadowEnabled = true;
            this.roundedPanel3.ShadowOffset = 5;
            this.roundedPanel3.Size = new System.Drawing.Size(1096, 73);
            this.roundedPanel3.TabIndex = 5;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(14, 9);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(402, 32);
            this.gradientLabel1.TabIndex = 7;
            this.gradientLabel1.Text = "Welcome Back, Justine Montante!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(25, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(216, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "Record Management Admin";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1120, 768);
            this.Controls.Add(this.headerPanelCard5);
            this.Controls.Add(this.headerPanelCard4);
            this.Controls.Add(this.headerPanelCard3);
            this.Controls.Add(this.headerPanelCard2);
            this.Controls.Add(this.headerPanelCard1);
            this.Controls.Add(this.roundedPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load_1);
            this.headerPanelCard5.ResumeLayout(false);
            this.headerPanelCard4.ResumeLayout(false);
            this.headerPanelCard4.PerformLayout();
            this.headerPanelCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).EndInit();
            this.headerPanelCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivityLog)).EndInit();
            this.headerPanelCard1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvRecentUploads;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedBy;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
        private System.Windows.Forms.Timer timerStorageUpdate;
        private System.Windows.Forms.Label lblStorageUsageDetails;
        private GradientLabel gradientLabel1;
        private CircularProgressBar cpDriveUsage;
        private RecordDistributionPanelCard pnlByProgram;
        private RecordDistributionPanelCard pnlBySubject;
        private RecordDistributionPanelCard pnlByYear_Sem;
        private RecordDistributionPanelCard pnlByProfessor;
        private CustomControls.HeaderPanelCard headerPanelCard1;
        private CustomControls.HeaderPanelCard headerPanelCard2;
        private System.Windows.Forms.DataGridView dgvRecentActivityLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityUser;
        private System.Windows.Forms.DataGridViewButtonColumn colActivityAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityDetails;
        private CustomControls.HeaderPanelCard headerPanelCard3;
        private CustomControls.HeaderPanelCard headerPanelCard4;
        private CustomControls.HeaderPanelCard headerPanelCard5;
        private CustomControls.DashboardCard dcRecentlyUploaded;
        private CustomControls.DashboardCard dcTotalGradesheets;
        private CustomControls.DashboardCard dcTotalProfessors;
        private CustomControls.DashboardCard dcTotalSubjects;
    }
}