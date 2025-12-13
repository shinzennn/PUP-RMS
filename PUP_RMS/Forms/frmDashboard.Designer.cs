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
            this.roundedPanel6 = new PUP_RMS.RoundedPanel();
            this.iconButton5 = new PUP_RMS.Controls.iconButton();
            this.iconButton3 = new PUP_RMS.Controls.iconButton();
            this.iconButton2 = new PUP_RMS.Controls.iconButton();
            this.iconButton1 = new PUP_RMS.Controls.iconButton();
            this.label16 = new System.Windows.Forms.Label();
            this.roundedPanel5 = new PUP_RMS.RoundedPanel();
            this.lblStorageUsageDetails = new System.Windows.Forms.Label();
            this.cpDriveUsage = new CircularProgressBar();
            this.label14 = new System.Windows.Forms.Label();
            this.roundedPanel4 = new PUP_RMS.RoundedPanel();
            this.dgvRecentActivityLog = new System.Windows.Forms.DataGridView();
            this.colActivityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colActivityDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new PUP_RMS.RoundedPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new PUP_RMS.RoundedPanel();
            this.dgvRecentUploads = new System.Windows.Forms.DataGridView();
            this.colUploadedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlTotalRecentlyUploaded = new PUP_RMS.RoundedPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTotalSubjects = new PUP_RMS.DashboardCard();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTotalProfessors = new PUP_RMS.DashboardCard();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTotalRecentlyUploads = new PUP_RMS.DashboardCard();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTotalGradesSheets = new PUP_RMS.DashboardCard();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel6.SuspendLayout();
            this.roundedPanel5.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivityLog)).BeginInit();
            this.roundedPanel3.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).BeginInit();
            this.pnlTotalRecentlyUploaded.SuspendLayout();
            this.pnlTotalSubjects.SuspendLayout();
            this.pnlTotalProfessors.SuspendLayout();
            this.pnlTotalRecentlyUploads.SuspendLayout();
            this.pnlTotalGradesSheets.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStorageUpdate
            // 
            this.timerStorageUpdate.Tick += new System.EventHandler(this.timerStorageUpdate_Tick_1);
            // 
            // roundedPanel6
            // 
            this.roundedPanel6.BackColor = System.Drawing.Color.White;
            this.roundedPanel6.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel6.BorderRadius = 20;
            this.roundedPanel6.BorderSize = 0;
            this.roundedPanel6.Controls.Add(this.iconButton5);
            this.roundedPanel6.Controls.Add(this.iconButton3);
            this.roundedPanel6.Controls.Add(this.iconButton2);
            this.roundedPanel6.Controls.Add(this.iconButton1);
            this.roundedPanel6.Controls.Add(this.label16);
            this.roundedPanel6.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel6.Location = new System.Drawing.Point(743, 498);
            this.roundedPanel6.Name = "roundedPanel6";
            this.roundedPanel6.ShadowBlur = 15;
            this.roundedPanel6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel6.ShadowEnabled = true;
            this.roundedPanel6.ShadowOffset = 5;
            this.roundedPanel6.Size = new System.Drawing.Size(391, 195);
            this.roundedPanel6.TabIndex = 12;
            // 
            // iconButton5
            // 
            this.iconButton5.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.iconButton5.BackColor = System.Drawing.Color.Maroon;
            this.iconButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.iconButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.ForeColor = System.Drawing.Color.White;
            this.iconButton5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButton5.IconSize = 27;
            this.iconButton5.Image = ((System.Drawing.Image)(resources.GetObject("iconButton5.Image")));
            this.iconButton5.IsActive = false;
            this.iconButton5.Location = new System.Drawing.Point(205, 112);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(159, 35);
            this.iconButton5.TabIndex = 14;
            this.iconButton5.Text = "Print Grade Sheets";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            this.iconButton3.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.iconButton3.BackColor = System.Drawing.Color.Maroon;
            this.iconButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButton3.IconSize = 27;
            this.iconButton3.Image = ((System.Drawing.Image)(resources.GetObject("iconButton3.Image")));
            this.iconButton3.IsActive = false;
            this.iconButton3.Location = new System.Drawing.Point(23, 112);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(160, 35);
            this.iconButton3.TabIndex = 12;
            this.iconButton3.Text = "Browse Grade Sheets";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.iconButton2.BackColor = System.Drawing.Color.Maroon;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButton2.IconSize = 24;
            this.iconButton2.Image = ((System.Drawing.Image)(resources.GetObject("iconButton2.Image")));
            this.iconButton2.IsActive = false;
            this.iconButton2.Location = new System.Drawing.Point(205, 46);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(159, 35);
            this.iconButton2.TabIndex = 11;
            this.iconButton2.Text = "Batch Upload";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            this.iconButton1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.iconButton1.BackColor = System.Drawing.Color.Maroon;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButton1.IconSize = 24;
            this.iconButton1.Image = ((System.Drawing.Image)(resources.GetObject("iconButton1.Image")));
            this.iconButton1.IsActive = false;
            this.iconButton1.Location = new System.Drawing.Point(23, 46);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(159, 35);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.Text = "Single Upload";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.Location = new System.Drawing.Point(18, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 25);
            this.label16.TabIndex = 9;
            this.label16.Text = "Quick Actions";
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.BackColor = System.Drawing.Color.White;
            this.roundedPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel5.BorderRadius = 20;
            this.roundedPanel5.BorderSize = 0;
            this.roundedPanel5.Controls.Add(this.lblStorageUsageDetails);
            this.roundedPanel5.Controls.Add(this.cpDriveUsage);
            this.roundedPanel5.Controls.Add(this.label14);
            this.roundedPanel5.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel5.Location = new System.Drawing.Point(743, 297);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.ShadowBlur = 15;
            this.roundedPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel5.ShadowEnabled = true;
            this.roundedPanel5.ShadowOffset = 5;
            this.roundedPanel5.Size = new System.Drawing.Size(391, 195);
            this.roundedPanel5.TabIndex = 10;
            // 
            // lblStorageUsageDetails
            // 
            this.lblStorageUsageDetails.AutoSize = true;
            this.lblStorageUsageDetails.ForeColor = System.Drawing.Color.Maroon;
            this.lblStorageUsageDetails.Location = new System.Drawing.Point(122, 153);
            this.lblStorageUsageDetails.Name = "lblStorageUsageDetails";
            this.lblStorageUsageDetails.Size = new System.Drawing.Size(42, 13);
            this.lblStorageUsageDetails.TabIndex = 11;
            this.lblStorageUsageDetails.Text = "storage";
            this.lblStorageUsageDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStorageUsageDetails.Click += new System.EventHandler(this.lblStorageUsageDetails_Click);
            // 
            // cpDriveUsage
            // 
            this.cpDriveUsage.BarWidth = 10;
            this.cpDriveUsage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cpDriveUsage.FontSize = 10;
            this.cpDriveUsage.Location = new System.Drawing.Point(136, 45);
            this.cpDriveUsage.Maximum = 100;
            this.cpDriveUsage.Minimum = 0;
            this.cpDriveUsage.Name = "cpDriveUsage";
            this.cpDriveUsage.ProgressColor = System.Drawing.Color.Maroon;
            this.cpDriveUsage.Size = new System.Drawing.Size(99, 95);
            this.cpDriveUsage.TabIndex = 10;
            this.cpDriveUsage.Text = "circularProgressBar1";
            this.cpDriveUsage.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cpDriveUsage.Value = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(18, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 25);
            this.label14.TabIndex = 9;
            this.label14.Text = "Local Storage Used ";
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.White;
            this.roundedPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel4.BorderRadius = 20;
            this.roundedPanel4.BorderSize = 0;
            this.roundedPanel4.Controls.Add(this.dgvRecentActivityLog);
            this.roundedPanel4.Controls.Add(this.label12);
            this.roundedPanel4.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel4.Location = new System.Drawing.Point(12, 498);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.ShadowBlur = 15;
            this.roundedPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel4.ShadowEnabled = true;
            this.roundedPanel4.ShadowOffset = 5;
            this.roundedPanel4.Size = new System.Drawing.Size(697, 195);
            this.roundedPanel4.TabIndex = 9;
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
            this.dgvRecentActivityLog.Location = new System.Drawing.Point(20, 28);
            this.dgvRecentActivityLog.Name = "dgvRecentActivityLog";
            this.dgvRecentActivityLog.Size = new System.Drawing.Size(635, 86);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(15, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 25);
            this.label12.TabIndex = 7;
            this.label12.Text = "Recent Activity log";
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.White;
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 20;
            this.roundedPanel3.BorderSize = 0;
            this.roundedPanel3.Controls.Add(this.label10);
            this.roundedPanel3.Controls.Add(this.label9);
            this.roundedPanel3.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel3.Location = new System.Drawing.Point(12, 4);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.ShadowBlur = 15;
            this.roundedPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel3.ShadowEnabled = true;
            this.roundedPanel3.ShadowOffset = 5;
            this.roundedPanel3.Size = new System.Drawing.Size(1142, 73);
            this.roundedPanel3.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(25, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(216, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "Record Management Admin";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(13, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(402, 32);
            this.label9.TabIndex = 5;
            this.label9.Text = "Welcome Back, Justine Montante!";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel2.BorderRadius = 20;
            this.roundedPanel2.BorderSize = 0;
            this.roundedPanel2.Controls.Add(this.dgvRecentUploads);
            this.roundedPanel2.Controls.Add(this.label11);
            this.roundedPanel2.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel2.Location = new System.Drawing.Point(12, 297);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.ShadowBlur = 15;
            this.roundedPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel2.ShadowEnabled = true;
            this.roundedPanel2.ShadowOffset = 5;
            this.roundedPanel2.Size = new System.Drawing.Size(697, 195);
            this.roundedPanel2.TabIndex = 4;
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
            this.dgvRecentUploads.Location = new System.Drawing.Point(20, 28);
            this.dgvRecentUploads.Name = "dgvRecentUploads";
            this.dgvRecentUploads.Size = new System.Drawing.Size(635, 86);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(15, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "Recent Uploads";
            // 
            // pnlTotalRecentlyUploaded
            // 
            this.pnlTotalRecentlyUploaded.BackColor = System.Drawing.Color.White;
            this.pnlTotalRecentlyUploaded.BorderColor = System.Drawing.Color.Transparent;
            this.pnlTotalRecentlyUploaded.BorderRadius = 20;
            this.pnlTotalRecentlyUploaded.BorderSize = 0;
            this.pnlTotalRecentlyUploaded.Controls.Add(this.label13);
            this.pnlTotalRecentlyUploaded.Controls.Add(this.panel1);
            this.pnlTotalRecentlyUploaded.Controls.Add(this.pnlTotalSubjects);
            this.pnlTotalRecentlyUploaded.Controls.Add(this.pnlTotalProfessors);
            this.pnlTotalRecentlyUploaded.Controls.Add(this.pnlTotalRecentlyUploads);
            this.pnlTotalRecentlyUploaded.Controls.Add(this.pnlTotalGradesSheets);
            this.pnlTotalRecentlyUploaded.HoverBorderColor = System.Drawing.Color.Maroon;
            this.pnlTotalRecentlyUploaded.Location = new System.Drawing.Point(12, 83);
            this.pnlTotalRecentlyUploaded.Name = "pnlTotalRecentlyUploaded";
            this.pnlTotalRecentlyUploaded.ShadowBlur = 15;
            this.pnlTotalRecentlyUploaded.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlTotalRecentlyUploaded.ShadowEnabled = true;
            this.pnlTotalRecentlyUploaded.ShadowOffset = 5;
            this.pnlTotalRecentlyUploaded.Size = new System.Drawing.Size(1142, 198);
            this.pnlTotalRecentlyUploaded.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(15, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(194, 30);
            this.label13.TabIndex = 7;
            this.label13.Text = "System Dashboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(19, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 1);
            this.panel1.TabIndex = 4;
            // 
            // pnlTotalSubjects
            // 
            this.pnlTotalSubjects.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalSubjects.BorderColor = System.Drawing.Color.Transparent;
            this.pnlTotalSubjects.BorderRadius = 20;
            this.pnlTotalSubjects.BorderSize = 0;
            this.pnlTotalSubjects.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlTotalSubjects.CardIcon")));
            this.pnlTotalSubjects.CirclePosition = new System.Drawing.Point(20, 20);
            this.pnlTotalSubjects.Controls.Add(this.label7);
            this.pnlTotalSubjects.Controls.Add(this.label3);
            this.pnlTotalSubjects.DashboardAccentColor = System.Drawing.Color.Maroon;
            this.pnlTotalSubjects.IconSize = 35;
            this.pnlTotalSubjects.IsDashboardCard = true;
            this.pnlTotalSubjects.Location = new System.Drawing.Point(302, 57);
            this.pnlTotalSubjects.Name = "pnlTotalSubjects";
            this.pnlTotalSubjects.PanelColor = System.Drawing.Color.Gainsboro;
            this.pnlTotalSubjects.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlTotalSubjects.ShadowDepth = 10;
            this.pnlTotalSubjects.ShadowEnabled = true;
            this.pnlTotalSubjects.ShadowShift = 5;
            this.pnlTotalSubjects.Size = new System.Drawing.Size(245, 138);
            this.pnlTotalSubjects.TabIndex = 1;
            this.pnlTotalSubjects.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalSubjects_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(72, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total Subjects";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(119, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 47);
            this.label3.TabIndex = 5;
            this.label3.Text = "0";
            // 
            // pnlTotalProfessors
            // 
            this.pnlTotalProfessors.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalProfessors.BorderColor = System.Drawing.Color.Transparent;
            this.pnlTotalProfessors.BorderRadius = 20;
            this.pnlTotalProfessors.BorderSize = 0;
            this.pnlTotalProfessors.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlTotalProfessors.CardIcon")));
            this.pnlTotalProfessors.CirclePosition = new System.Drawing.Point(20, 20);
            this.pnlTotalProfessors.Controls.Add(this.label8);
            this.pnlTotalProfessors.Controls.Add(this.label4);
            this.pnlTotalProfessors.DashboardAccentColor = System.Drawing.Color.Maroon;
            this.pnlTotalProfessors.IconSize = 40;
            this.pnlTotalProfessors.IsDashboardCard = true;
            this.pnlTotalProfessors.Location = new System.Drawing.Point(583, 57);
            this.pnlTotalProfessors.Name = "pnlTotalProfessors";
            this.pnlTotalProfessors.PanelColor = System.Drawing.Color.Gainsboro;
            this.pnlTotalProfessors.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlTotalProfessors.ShadowDepth = 10;
            this.pnlTotalProfessors.ShadowEnabled = true;
            this.pnlTotalProfessors.ShadowShift = 5;
            this.pnlTotalProfessors.Size = new System.Drawing.Size(245, 138);
            this.pnlTotalProfessors.TabIndex = 1;
            this.pnlTotalProfessors.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalProfessors_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(66, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total Professors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(121, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 47);
            this.label4.TabIndex = 5;
            this.label4.Text = "0";
            // 
            // pnlTotalRecentlyUploads
            // 
            this.pnlTotalRecentlyUploads.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalRecentlyUploads.BorderColor = System.Drawing.Color.Transparent;
            this.pnlTotalRecentlyUploads.BorderRadius = 20;
            this.pnlTotalRecentlyUploads.BorderSize = 0;
            this.pnlTotalRecentlyUploads.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlTotalRecentlyUploads.CardIcon")));
            this.pnlTotalRecentlyUploads.CirclePosition = new System.Drawing.Point(20, 20);
            this.pnlTotalRecentlyUploads.Controls.Add(this.label6);
            this.pnlTotalRecentlyUploads.Controls.Add(this.label5);
            this.pnlTotalRecentlyUploads.DashboardAccentColor = System.Drawing.Color.Maroon;
            this.pnlTotalRecentlyUploads.IconSize = 35;
            this.pnlTotalRecentlyUploads.IsDashboardCard = true;
            this.pnlTotalRecentlyUploads.Location = new System.Drawing.Point(867, 57);
            this.pnlTotalRecentlyUploads.Name = "pnlTotalRecentlyUploads";
            this.pnlTotalRecentlyUploads.PanelColor = System.Drawing.Color.Gainsboro;
            this.pnlTotalRecentlyUploads.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlTotalRecentlyUploads.ShadowDepth = 10;
            this.pnlTotalRecentlyUploads.ShadowEnabled = true;
            this.pnlTotalRecentlyUploads.ShadowShift = 5;
            this.pnlTotalRecentlyUploads.Size = new System.Drawing.Size(245, 138);
            this.pnlTotalRecentlyUploads.TabIndex = 1;
            this.pnlTotalRecentlyUploads.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalRecentlyUploads_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(56, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Recently Uploaded";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(120, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 47);
            this.label5.TabIndex = 5;
            this.label5.Text = "0";
            // 
            // pnlTotalGradesSheets
            // 
            this.pnlTotalGradesSheets.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalGradesSheets.BorderColor = System.Drawing.Color.Transparent;
            this.pnlTotalGradesSheets.BorderRadius = 20;
            this.pnlTotalGradesSheets.BorderSize = 0;
            this.pnlTotalGradesSheets.CardIcon = ((System.Drawing.Image)(resources.GetObject("pnlTotalGradesSheets.CardIcon")));
            this.pnlTotalGradesSheets.CirclePosition = new System.Drawing.Point(20, 20);
            this.pnlTotalGradesSheets.Controls.Add(this.label2);
            this.pnlTotalGradesSheets.Controls.Add(this.label1);
            this.pnlTotalGradesSheets.DashboardAccentColor = System.Drawing.Color.Maroon;
            this.pnlTotalGradesSheets.IconSize = 35;
            this.pnlTotalGradesSheets.IsDashboardCard = true;
            this.pnlTotalGradesSheets.Location = new System.Drawing.Point(29, 57);
            this.pnlTotalGradesSheets.Name = "pnlTotalGradesSheets";
            this.pnlTotalGradesSheets.PanelColor = System.Drawing.Color.Gainsboro;
            this.pnlTotalGradesSheets.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlTotalGradesSheets.ShadowDepth = 10;
            this.pnlTotalGradesSheets.ShadowEnabled = true;
            this.pnlTotalGradesSheets.ShadowShift = 5;
            this.pnlTotalGradesSheets.Size = new System.Drawing.Size(245, 138);
            this.pnlTotalGradesSheets.TabIndex = 0;
            this.pnlTotalGradesSheets.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalGradesSheets_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(116, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 47);
            this.label2.TabIndex = 4;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Grade Sheets";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1166, 700);
            this.Controls.Add(this.roundedPanel6);
            this.Controls.Add(this.roundedPanel5);
            this.Controls.Add(this.roundedPanel4);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.pnlTotalRecentlyUploaded);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.roundedPanel6.ResumeLayout(false);
            this.roundedPanel6.PerformLayout();
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivityLog)).EndInit();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUploads)).EndInit();
            this.pnlTotalRecentlyUploaded.ResumeLayout(false);
            this.pnlTotalRecentlyUploaded.PerformLayout();
            this.pnlTotalSubjects.ResumeLayout(false);
            this.pnlTotalSubjects.PerformLayout();
            this.pnlTotalProfessors.ResumeLayout(false);
            this.pnlTotalProfessors.PerformLayout();
            this.pnlTotalRecentlyUploads.ResumeLayout(false);
            this.pnlTotalRecentlyUploads.PerformLayout();
            this.pnlTotalGradesSheets.ResumeLayout(false);
            this.pnlTotalGradesSheets.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DashboardCard pnlTotalGradesSheets;
        private System.Windows.Forms.Label label1;
        private DashboardCard pnlTotalSubjects;
        private DashboardCard pnlTotalProfessors;
        private DashboardCard pnlTotalRecentlyUploads;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RoundedPanel pnlTotalRecentlyUploaded;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private RoundedPanel roundedPanel2;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvRecentUploads;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadedBy;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
        private RoundedPanel roundedPanel4;
        private System.Windows.Forms.DataGridView dgvRecentActivityLog;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityUser;
        private System.Windows.Forms.DataGridViewButtonColumn colActivityAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityDetails;
        private System.Windows.Forms.Label label13;
        private RoundedPanel roundedPanel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timerStorageUpdate;
        private RoundedPanel roundedPanel6;
        private System.Windows.Forms.Label label16;
        private Controls.iconButton iconButton5;
        private Controls.iconButton iconButton3;
        private Controls.iconButton iconButton2;
        private Controls.iconButton iconButton1;
        private CircularProgressBar cpDriveUsage;
        private System.Windows.Forms.Label lblStorageUsageDetails;
    }
}