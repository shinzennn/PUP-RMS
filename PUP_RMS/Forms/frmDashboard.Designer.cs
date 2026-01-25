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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedPanel3 = new PUP_RMS.RoundedPanel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanelCard4 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStorageUsageDetails = new System.Windows.Forms.Label();
            this.cpDriveUsage = new CircularProgressBar();
            this.headerPanelCard3 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dgvRecentUploads = new System.Windows.Forms.DataGridView();
            this.colUploadedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanelCard5 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dcTotalProgram = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalProfessors = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalSubjects = new PUP_RMS.CustomControls.DashboardCard();
            this.dcTotalGradesheets = new PUP_RMS.CustomControls.DashboardCard();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.recentActivityLog1 = new RecordsManagementSystem.Controls.RecentActivityLog();
            this.headerPanelCard1 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBySubject = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByYear_Sem = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByProfessor = new PUP_RMS.RecordDistributionPanelCard();
            this.pnlByProgram = new PUP_RMS.RecordDistributionPanelCard();
            this.timerActivityLog = new System.Windows.Forms.Timer(this.components);
            this.lblAccountName = new GradientLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.headerPanelCard4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.headerPanelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).BeginInit();
            this.headerPanelCard5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.headerPanelCard1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStorageUpdate
            // 
            this.timerStorageUpdate.Tick += new System.EventHandler(this.timerStorageUpdate_Tick_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.headerPanelCard5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 788);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 10;
            this.roundedPanel3.BorderSize = 0;
            this.roundedPanel3.Controls.Add(this.lblAccountName);
            this.roundedPanel3.Controls.Add(this.gradientLabel1);
            this.roundedPanel3.Controls.Add(this.label10);
            this.roundedPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel3.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.roundedPanel3.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel3.Location = new System.Drawing.Point(3, 3);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.ShadowBlur = 15;
            this.roundedPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel3.ShadowEnabled = true;
            this.roundedPanel3.ShadowOffset = 5;
            this.roundedPanel3.Size = new System.Drawing.Size(1114, 74);
            this.roundedPanel3.TabIndex = 15;
            this.roundedPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel3_Paint);
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(14, 9);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(194, 32);
            this.gradientLabel1.TabIndex = 7;
            this.gradientLabel1.Text = "Welcome Back, ";
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
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.headerPanelCard4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.headerPanelCard3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 263);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1114, 258);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // headerPanelCard4
            // 
            this.headerPanelCard4.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard4.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard4.BorderRadius = 20;
            this.headerPanelCard4.BorderThickness = 0;
            this.headerPanelCard4.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard4.Controls.Add(this.tableLayoutPanel6);
            this.headerPanelCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanelCard4.EnableHoverEffect = false;
            this.headerPanelCard4.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard4.HeaderFontSize = 13F;
            this.headerPanelCard4.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard4.HeaderHeight = 40;
            this.headerPanelCard4.HeaderLabel = "Local Storage Used ";
            this.headerPanelCard4.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard4.IconHeader")));
            this.headerPanelCard4.IconSize = 25;
            this.headerPanelCard4.Location = new System.Drawing.Point(727, 3);
            this.headerPanelCard4.Name = "headerPanelCard4";
            this.headerPanelCard4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard4.ShadowDepth = 4;
            this.headerPanelCard4.ShadowPadding = 5;
            this.headerPanelCard4.ShowHeaderDivider = false;
            this.headerPanelCard4.ShowShadow = true;
            this.headerPanelCard4.Size = new System.Drawing.Size(384, 252);
            this.headerPanelCard4.TabIndex = 13;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.lblStorageUsageDetails, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.cpDriveUsage, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(15, 50);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(354, 187);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // lblStorageUsageDetails
            // 
            this.lblStorageUsageDetails.AutoSize = true;
            this.lblStorageUsageDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStorageUsageDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.lblStorageUsageDetails.Location = new System.Drawing.Point(3, 157);
            this.lblStorageUsageDetails.Name = "lblStorageUsageDetails";
            this.lblStorageUsageDetails.Size = new System.Drawing.Size(348, 30);
            this.lblStorageUsageDetails.TabIndex = 11;
            this.lblStorageUsageDetails.Text = "storage";
            this.lblStorageUsageDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cpDriveUsage
            // 
            this.cpDriveUsage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpDriveUsage.BackColor = System.Drawing.Color.Transparent;
            this.cpDriveUsage.BarWidth = 20;
            this.cpDriveUsage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cpDriveUsage.FontSize = 10;
            this.cpDriveUsage.GradientEnd = System.Drawing.Color.Maroon;
            this.cpDriveUsage.GradientStart = System.Drawing.Color.Maroon;
            this.cpDriveUsage.Location = new System.Drawing.Point(122, 24);
            this.cpDriveUsage.Maximum = 100;
            this.cpDriveUsage.Minimum = 0;
            this.cpDriveUsage.Name = "cpDriveUsage";
            this.cpDriveUsage.ProgressColor = System.Drawing.Color.Maroon;
            this.cpDriveUsage.Size = new System.Drawing.Size(109, 109);
            this.cpDriveUsage.TabIndex = 10;
            this.cpDriveUsage.Text = "circularProgressBar1";
            this.cpDriveUsage.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cpDriveUsage.Value = 0;
            this.cpDriveUsage.Click += new System.EventHandler(this.cpDriveUsage_Click_1);
            // 
            // headerPanelCard3
            // 
            this.headerPanelCard3.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard3.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard3.BorderRadius = 10;
            this.headerPanelCard3.BorderThickness = 0;
            this.headerPanelCard3.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard3.Controls.Add(this.dgvRecentUploads);
            this.headerPanelCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanelCard3.EnableHoverEffect = false;
            this.headerPanelCard3.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard3.HeaderFontSize = 13F;
            this.headerPanelCard3.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard3.HeaderHeight = 40;
            this.headerPanelCard3.HeaderLabel = "Recent Uploads";
            this.headerPanelCard3.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard3.IconHeader")));
            this.headerPanelCard3.IconSize = 25;
            this.headerPanelCard3.Location = new System.Drawing.Point(3, 3);
            this.headerPanelCard3.Name = "headerPanelCard3";
            this.headerPanelCard3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard3.ShadowDepth = 4;
            this.headerPanelCard3.ShadowPadding = 5;
            this.headerPanelCard3.ShowHeaderDivider = false;
            this.headerPanelCard3.ShowShadow = true;
            this.headerPanelCard3.Size = new System.Drawing.Size(718, 252);
            this.headerPanelCard3.TabIndex = 12;
            // 
            // dgvRecentUploads
            // 
            this.dgvRecentUploads.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentUploads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentUploads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentUploads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUploadedAt,
            this.colFileName,
            this.colUploadedBy});
            this.dgvRecentUploads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentUploads.Location = new System.Drawing.Point(15, 50);
            this.dgvRecentUploads.Name = "dgvRecentUploads";
            this.dgvRecentUploads.Size = new System.Drawing.Size(688, 187);
            this.dgvRecentUploads.TabIndex = 8;
            this.dgvRecentUploads.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecentUploads_CellContentClick_1);
            // 
            // colUploadedAt
            // 
            this.colUploadedAt.HeaderText = "File Name";
            this.colUploadedAt.Name = "colUploadedAt";
            // 
            // colFileName
            // 
            this.colFileName.HeaderText = "Course Description";
            this.colFileName.Name = "colFileName";
            // 
            // colUploadedBy
            // 
            this.colUploadedBy.HeaderText = "Uploaded By";
            this.colUploadedBy.Name = "colUploadedBy";
            // 
            // headerPanelCard5
            // 
            this.headerPanelCard5.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard5.BorderColor = System.Drawing.Color.Gainsboro;
            this.headerPanelCard5.BorderRadius = 20;
            this.headerPanelCard5.BorderThickness = 1;
            this.headerPanelCard5.ContentBackColor = System.Drawing.Color.WhiteSmoke;
            this.headerPanelCard5.Controls.Add(this.tableLayoutPanel2);
            this.headerPanelCard5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanelCard5.EnableHoverEffect = false;
            this.headerPanelCard5.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard5.HeaderFontSize = 15F;
            this.headerPanelCard5.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard5.HeaderHeight = 40;
            this.headerPanelCard5.HeaderLabel = "System Dashboard";
            this.headerPanelCard5.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard5.IconHeader")));
            this.headerPanelCard5.IconSize = 30;
            this.headerPanelCard5.Location = new System.Drawing.Point(3, 83);
            this.headerPanelCard5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.headerPanelCard5.Name = "headerPanelCard5";
            this.headerPanelCard5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard5.ShadowDepth = 4;
            this.headerPanelCard5.ShadowPadding = 5;
            this.headerPanelCard5.ShowHeaderDivider = false;
            this.headerPanelCard5.ShowShadow = true;
            this.headerPanelCard5.Size = new System.Drawing.Size(1114, 177);
            this.headerPanelCard5.TabIndex = 16;
            this.headerPanelCard5.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanelCard5_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.dcTotalProgram, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.dcTotalProfessors, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dcTotalSubjects, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dcTotalGradesheets, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1082, 110);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // dcTotalProgram
            // 
            this.dcTotalProgram.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalProgram.BorderRadius = 15;
            this.dcTotalProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTotalProgram.HeaderFontSize = 9F;
            this.dcTotalProgram.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalProgram.HeaderText = "TOTAL PROGRAM";
            this.dcTotalProgram.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalProgram.IconCircleSize = 50;
            this.dcTotalProgram.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalProgram.IconImage")));
            this.dcTotalProgram.Location = new System.Drawing.Point(815, 0);
            this.dcTotalProgram.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dcTotalProgram.Name = "dcTotalProgram";
            this.dcTotalProgram.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalProgram.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalProgram.ShadowDepth = 15;
            this.dcTotalProgram.ShadowPadding = 10;
            this.dcTotalProgram.ShowShadow = true;
            this.dcTotalProgram.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalProgram.SideBarWidth = 5;
            this.dcTotalProgram.Size = new System.Drawing.Size(262, 110);
            this.dcTotalProgram.TabIndex = 12;
            this.dcTotalProgram.ValueFontSize = 24F;
            this.dcTotalProgram.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalProgram.ValueText = "0";
            // 
            // dcTotalProfessors
            // 
            this.dcTotalProfessors.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalProfessors.BorderRadius = 15;
            this.dcTotalProfessors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTotalProfessors.HeaderFontSize = 9F;
            this.dcTotalProfessors.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalProfessors.HeaderText = "TOTAL PROFESSORS";
            this.dcTotalProfessors.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalProfessors.IconCircleSize = 50;
            this.dcTotalProfessors.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalProfessors.IconImage")));
            this.dcTotalProfessors.Location = new System.Drawing.Point(545, 0);
            this.dcTotalProfessors.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dcTotalProfessors.Name = "dcTotalProfessors";
            this.dcTotalProfessors.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalProfessors.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalProfessors.ShadowDepth = 15;
            this.dcTotalProfessors.ShadowPadding = 10;
            this.dcTotalProfessors.ShowShadow = true;
            this.dcTotalProfessors.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalProfessors.SideBarWidth = 5;
            this.dcTotalProfessors.Size = new System.Drawing.Size(260, 110);
            this.dcTotalProfessors.TabIndex = 11;
            this.dcTotalProfessors.ValueFontSize = 24F;
            this.dcTotalProfessors.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalProfessors.ValueText = "0";
            // 
            // dcTotalSubjects
            // 
            this.dcTotalSubjects.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalSubjects.BorderRadius = 15;
            this.dcTotalSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTotalSubjects.HeaderFontSize = 9F;
            this.dcTotalSubjects.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalSubjects.HeaderText = "TOTAL COURSES";
            this.dcTotalSubjects.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalSubjects.IconCircleSize = 50;
            this.dcTotalSubjects.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalSubjects.IconImage")));
            this.dcTotalSubjects.Location = new System.Drawing.Point(275, 0);
            this.dcTotalSubjects.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dcTotalSubjects.Name = "dcTotalSubjects";
            this.dcTotalSubjects.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalSubjects.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalSubjects.ShadowDepth = 15;
            this.dcTotalSubjects.ShadowPadding = 10;
            this.dcTotalSubjects.ShowShadow = true;
            this.dcTotalSubjects.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalSubjects.SideBarWidth = 5;
            this.dcTotalSubjects.Size = new System.Drawing.Size(260, 110);
            this.dcTotalSubjects.TabIndex = 10;
            this.dcTotalSubjects.ValueFontSize = 24F;
            this.dcTotalSubjects.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalSubjects.ValueText = "0";
            // 
            // dcTotalGradesheets
            // 
            this.dcTotalGradesheets.BackColor = System.Drawing.Color.Transparent;
            this.dcTotalGradesheets.BorderRadius = 15;
            this.dcTotalGradesheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTotalGradesheets.HeaderFontSize = 9F;
            this.dcTotalGradesheets.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.dcTotalGradesheets.HeaderText = "TOTAL GRADE SHEETS";
            this.dcTotalGradesheets.IconBackColor = System.Drawing.Color.Goldenrod;
            this.dcTotalGradesheets.IconCircleSize = 50;
            this.dcTotalGradesheets.IconImage = ((System.Drawing.Image)(resources.GetObject("dcTotalGradesheets.IconImage")));
            this.dcTotalGradesheets.Location = new System.Drawing.Point(5, 0);
            this.dcTotalGradesheets.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dcTotalGradesheets.Name = "dcTotalGradesheets";
            this.dcTotalGradesheets.PanelBackColor = System.Drawing.Color.White;
            this.dcTotalGradesheets.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dcTotalGradesheets.ShadowDepth = 15;
            this.dcTotalGradesheets.ShadowPadding = 10;
            this.dcTotalGradesheets.ShowShadow = true;
            this.dcTotalGradesheets.SideBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.dcTotalGradesheets.SideBarWidth = 5;
            this.dcTotalGradesheets.Size = new System.Drawing.Size(260, 110);
            this.dcTotalGradesheets.TabIndex = 9;
            this.dcTotalGradesheets.ValueFontSize = 24F;
            this.dcTotalGradesheets.ValueForeColor = System.Drawing.Color.Black;
            this.dcTotalGradesheets.ValueText = "0";
            this.dcTotalGradesheets.Paint += new System.Windows.Forms.PaintEventHandler(this.dcTotalGradesheets_Paint_1);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.Controls.Add(this.recentActivityLog1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.headerPanelCard1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 527);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1114, 258);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // recentActivityLog1
            // 
            this.recentActivityLog1.BackColor = System.Drawing.Color.Transparent;
            this.recentActivityLog1.BorderColor = System.Drawing.Color.Gray;
            this.recentActivityLog1.BorderRadius = 10;
            this.recentActivityLog1.BorderThickness = 0;
            this.recentActivityLog1.ContentBackColor = System.Drawing.Color.White;
            this.recentActivityLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentActivityLog1.EnableHoverEffect = false;
            this.recentActivityLog1.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.recentActivityLog1.HeaderFontSize = 13F;
            this.recentActivityLog1.HeaderForeColor = System.Drawing.Color.Maroon;
            this.recentActivityLog1.HeaderHeight = 40;
            this.recentActivityLog1.HeaderLabel = "Recent Activity Log";
            this.recentActivityLog1.IconHeader = ((System.Drawing.Image)(resources.GetObject("recentActivityLog1.IconHeader")));
            this.recentActivityLog1.IconSize = 25;
            this.recentActivityLog1.Location = new System.Drawing.Point(3, 3);
            this.recentActivityLog1.Name = "recentActivityLog1";
            this.recentActivityLog1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.recentActivityLog1.ShadowDepth = 4;
            this.recentActivityLog1.ShadowPadding = 5;
            this.recentActivityLog1.ShowHeaderDivider = false;
            this.recentActivityLog1.ShowShadow = true;
            this.recentActivityLog1.Size = new System.Drawing.Size(718, 252);
            this.recentActivityLog1.TabIndex = 10;
            this.recentActivityLog1.Text = "recentActivityLog1";
            this.recentActivityLog1.Click += new System.EventHandler(this.recentActivityLog1_Click);
            this.recentActivityLog1.Paint += new System.Windows.Forms.PaintEventHandler(this.recentActivityLog1_Paint);
            // 
            // headerPanelCard1
            // 
            this.headerPanelCard1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard1.BorderColor = System.Drawing.Color.Gray;
            this.headerPanelCard1.BorderRadius = 20;
            this.headerPanelCard1.BorderThickness = 0;
            this.headerPanelCard1.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard1.Controls.Add(this.tableLayoutPanel5);
            this.headerPanelCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanelCard1.EnableHoverEffect = false;
            this.headerPanelCard1.HeaderBackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPanelCard1.HeaderFontSize = 13F;
            this.headerPanelCard1.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard1.HeaderHeight = 40;
            this.headerPanelCard1.HeaderLabel = "Record Distribution";
            this.headerPanelCard1.IconHeader = ((System.Drawing.Image)(resources.GetObject("headerPanelCard1.IconHeader")));
            this.headerPanelCard1.IconSize = 25;
            this.headerPanelCard1.Location = new System.Drawing.Point(727, 3);
            this.headerPanelCard1.Name = "headerPanelCard1";
            this.headerPanelCard1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard1.ShadowDepth = 4;
            this.headerPanelCard1.ShadowPadding = 5;
            this.headerPanelCard1.ShowHeaderDivider = false;
            this.headerPanelCard1.ShowShadow = true;
            this.headerPanelCard1.Size = new System.Drawing.Size(384, 252);
            this.headerPanelCard1.TabIndex = 17;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.pnlBySubject, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.pnlByYear_Sem, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.pnlByProfessor, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.pnlByProgram, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(15, 50);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(354, 187);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // pnlBySubject
            // 
            this.pnlBySubject.BackColor = System.Drawing.Color.White;
            this.pnlBySubject.BorderColor = System.Drawing.Color.LightGray;
            this.pnlBySubject.BorderRadius = 15;
            this.pnlBySubject.BorderSize = 2;
            this.pnlBySubject.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlBySubject.CardIcon")));
            this.pnlBySubject.CardLabel = "By Course";
            this.pnlBySubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBySubject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlBySubject.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlBySubject.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlBySubject.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlBySubject.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlBySubject.Location = new System.Drawing.Point(180, 96);
            this.pnlBySubject.Name = "pnlBySubject";
            this.pnlBySubject.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlBySubject.ShadowBlur = 15;
            this.pnlBySubject.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlBySubject.ShadowEnabled = true;
            this.pnlBySubject.ShadowOffset = 5;
            this.pnlBySubject.Size = new System.Drawing.Size(171, 88);
            this.pnlBySubject.TabIndex = 14;
            this.pnlBySubject.Click += new System.EventHandler(this.pnlBySubject_Click_1);
            this.pnlBySubject.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBySubject_Paint_1);
            // 
            // pnlByYear_Sem
            // 
            this.pnlByYear_Sem.BackColor = System.Drawing.Color.White;
            this.pnlByYear_Sem.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByYear_Sem.BorderRadius = 15;
            this.pnlByYear_Sem.BorderSize = 2;
            this.pnlByYear_Sem.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByYear_Sem.CardIcon")));
            this.pnlByYear_Sem.CardLabel = "By Year/Sem";
            this.pnlByYear_Sem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlByYear_Sem.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByYear_Sem.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByYear_Sem.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByYear_Sem.Location = new System.Drawing.Point(3, 96);
            this.pnlByYear_Sem.Name = "pnlByYear_Sem";
            this.pnlByYear_Sem.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByYear_Sem.ShadowBlur = 15;
            this.pnlByYear_Sem.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByYear_Sem.ShadowEnabled = true;
            this.pnlByYear_Sem.ShadowOffset = 5;
            this.pnlByYear_Sem.Size = new System.Drawing.Size(171, 88);
            this.pnlByYear_Sem.TabIndex = 13;
            this.pnlByYear_Sem.Click += new System.EventHandler(this.pnlByYear_Sem_Click_1);
            this.pnlByYear_Sem.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlByYear_Sem_Paint);
            // 
            // pnlByProfessor
            // 
            this.pnlByProfessor.BackColor = System.Drawing.Color.White;
            this.pnlByProfessor.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByProfessor.BorderRadius = 15;
            this.pnlByProfessor.BorderSize = 2;
            this.pnlByProfessor.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByProfessor.CardIcon")));
            this.pnlByProfessor.CardLabel = "By Professor";
            this.pnlByProfessor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlByProfessor.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByProfessor.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByProfessor.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByProfessor.Location = new System.Drawing.Point(180, 3);
            this.pnlByProfessor.Name = "pnlByProfessor";
            this.pnlByProfessor.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByProfessor.ShadowBlur = 15;
            this.pnlByProfessor.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByProfessor.ShadowEnabled = true;
            this.pnlByProfessor.ShadowOffset = 5;
            this.pnlByProfessor.Size = new System.Drawing.Size(171, 87);
            this.pnlByProfessor.TabIndex = 12;
            this.pnlByProfessor.Click += new System.EventHandler(this.pnlByProfessor_Click_1);
            // 
            // pnlByProgram
            // 
            this.pnlByProgram.BackColor = System.Drawing.Color.White;
            this.pnlByProgram.BorderColor = System.Drawing.Color.LightGray;
            this.pnlByProgram.BorderRadius = 15;
            this.pnlByProgram.BorderSize = 2;
            this.pnlByProgram.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlByProgram.CardIcon")));
            this.pnlByProgram.CardLabel = "By Program";
            this.pnlByProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlByProgram.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(209)))));
            this.pnlByProgram.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProgram.HoverCardBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.pnlByProgram.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlByProgram.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlByProgram.Location = new System.Drawing.Point(3, 3);
            this.pnlByProgram.Name = "pnlByProgram";
            this.pnlByProgram.NormalCardBorderColor = System.Drawing.Color.LightGray;
            this.pnlByProgram.ShadowBlur = 15;
            this.pnlByProgram.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlByProgram.ShadowEnabled = true;
            this.pnlByProgram.ShadowOffset = 5;
            this.pnlByProgram.Size = new System.Drawing.Size(171, 87);
            this.pnlByProgram.TabIndex = 11;
            this.pnlByProgram.Click += new System.EventHandler(this.pnlByProgram_Click_1);
            this.pnlByProgram.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlByProgram_Paint);
            // 
            // timerActivityLog
            // 
            this.timerActivityLog.Enabled = true;
            this.timerActivityLog.Interval = 3000;
            this.timerActivityLog.Tick += new System.EventHandler(this.timerActivityLog_Tick);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAccountName.Location = new System.Drawing.Point(200, 9);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(81, 32);
            this.lblAccountName.TabIndex = 8;
            this.lblAccountName.Text = "Name";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.ClientSize = new System.Drawing.Size(1120, 788);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.headerPanelCard4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.headerPanelCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).EndInit();
            this.headerPanelCard5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.headerPanelCard1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerStorageUpdate;
        private RecordsManagementSystem.Controls.RecentActivityLog recentActivityLog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPanel roundedPanel3;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private CustomControls.HeaderPanelCard headerPanelCard5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomControls.DashboardCard dcTotalProgram;
        private CustomControls.DashboardCard dcTotalProfessors;
        private CustomControls.DashboardCard dcTotalSubjects;
        private CustomControls.DashboardCard dcTotalGradesheets;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CustomControls.HeaderPanelCard headerPanelCard4;
        private CustomControls.HeaderPanelCard headerPanelCard3;
        private System.Windows.Forms.DataGridView dgvRecentUploads;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CustomControls.HeaderPanelCard headerPanelCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private RecordDistributionPanelCard pnlBySubject;
        private RecordDistributionPanelCard pnlByYear_Sem;
        private RecordDistributionPanelCard pnlByProfessor;
        private RecordDistributionPanelCard pnlByProgram;
        private System.Windows.Forms.Label lblStorageUsageDetails;
        private CircularProgressBar cpDriveUsage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Timer timerActivityLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedBy;
        private GradientLabel lblAccountName;
    }
}