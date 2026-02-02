namespace PUP_RMS.Forms
{
    partial class MainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new PUP_RMS.Controls.iconButton();
            this.btnSearch = new PUP_RMS.Controls.iconButton();
            this.btnBatchUpload = new PUP_RMS.Controls.iconButton();
            this.btnAdminTool = new PUP_RMS.Controls.iconButton();
            this.pnlAdminSubMenu = new System.Windows.Forms.Panel();
            this.btnProgram = new PUP_RMS.Controls.iconButton();
            this.btnSection = new PUP_RMS.Controls.iconButton();
            this.btnCurriculum = new PUP_RMS.Controls.iconButton();
            this.btnAccounts = new PUP_RMS.Controls.iconButton();
            this.btnLogout = new PUP_RMS.Controls.iconButton();
            this.tmrUploadTransition = new System.Windows.Forms.Timer(this.components);
            this.btnFaculty = new PUP_RMS.Controls.iconButton();
            this.btnCourse = new PUP_RMS.Controls.iconButton();
            this.pnlContent.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlAdminSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlContent.Controls.Add(this.flowLayoutPanelMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1443, 862);
            this.pnlContent.TabIndex = 5;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.flowLayoutPanelMain.Controls.Add(this.pictureBox1);
            this.flowLayoutPanelMain.Controls.Add(this.pictureBox2);
            this.flowLayoutPanelMain.Controls.Add(this.btnDashboard);
            this.flowLayoutPanelMain.Controls.Add(this.btnSearch);
            this.flowLayoutPanelMain.Controls.Add(this.btnBatchUpload);
            this.flowLayoutPanelMain.Controls.Add(this.btnAdminTool);
            this.flowLayoutPanelMain.Controls.Add(this.pnlAdminSubMenu);
            this.flowLayoutPanelMain.Controls.Add(this.btnAccounts);
            this.flowLayoutPanelMain.Controls.Add(this.btnLogout);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(250, 862);
            this.flowLayoutPanelMain.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PUP_RMS.Properties.Resources.Blue_Black_modern_Building_Logo_Design__Logo__removebg_preview1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 159);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(247, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnDashboard.BackColor = System.Drawing.Color.Maroon;
            this.btnDashboard.BorderColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderRadius = 10;
            this.btnDashboard.BorderSize = 0;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnDashboard.IconSize = 30;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.IndentLevel = 0;
            this.btnDashboard.IsActive = false;
            this.btnDashboard.Location = new System.Drawing.Point(0, 197);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(250, 60);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnSearch.IconSize = 30;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.IndentLevel = 0;
            this.btnSearch.IsActive = false;
            this.btnSearch.Location = new System.Drawing.Point(0, 259);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(250, 60);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBatchUpload
            // 
            this.btnBatchUpload.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnBatchUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnBatchUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBatchUpload.BorderRadius = 10;
            this.btnBatchUpload.BorderSize = 0;
            this.btnBatchUpload.FlatAppearance.BorderSize = 0;
            this.btnBatchUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnBatchUpload.ForeColor = System.Drawing.Color.White;
            this.btnBatchUpload.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnBatchUpload.IconSize = 30;
            this.btnBatchUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchUpload.Image")));
            this.btnBatchUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.IndentLevel = 0;
            this.btnBatchUpload.IsActive = false;
            this.btnBatchUpload.Location = new System.Drawing.Point(0, 321);
            this.btnBatchUpload.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnBatchUpload.Name = "btnBatchUpload";
            this.btnBatchUpload.Size = new System.Drawing.Size(250, 60);
            this.btnBatchUpload.TabIndex = 7;
            this.btnBatchUpload.Text = "Batch Upload";
            this.btnBatchUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBatchUpload.UseVisualStyleBackColor = false;
            this.btnBatchUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnAdminTool
            // 
            this.btnAdminTool.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnAdminTool.BackColor = System.Drawing.Color.Maroon;
            this.btnAdminTool.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdminTool.BorderRadius = 10;
            this.btnAdminTool.BorderSize = 0;
            this.btnAdminTool.FlatAppearance.BorderSize = 0;
            this.btnAdminTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminTool.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAdminTool.ForeColor = System.Drawing.Color.White;
            this.btnAdminTool.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnAdminTool.IconSize = 30;
            this.btnAdminTool.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminTool.Image")));
            this.btnAdminTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminTool.IndentLevel = 0;
            this.btnAdminTool.IsActive = false;
            this.btnAdminTool.Location = new System.Drawing.Point(0, 383);
            this.btnAdminTool.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnAdminTool.Name = "btnAdminTool";
            this.btnAdminTool.Size = new System.Drawing.Size(250, 60);
            this.btnAdminTool.TabIndex = 15;
            this.btnAdminTool.Text = "Admin Tool";
            this.btnAdminTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdminTool.UseVisualStyleBackColor = false;
            this.btnAdminTool.Click += new System.EventHandler(this.btnAdminTool_Click);
            // 
            // pnlAdminSubMenu
            // 
            this.pnlAdminSubMenu.Controls.Add(this.btnFaculty);
            this.pnlAdminSubMenu.Controls.Add(this.btnCourse);
            this.pnlAdminSubMenu.Controls.Add(this.btnProgram);
            this.pnlAdminSubMenu.Controls.Add(this.btnSection);
            this.pnlAdminSubMenu.Controls.Add(this.btnCurriculum);
            this.pnlAdminSubMenu.Location = new System.Drawing.Point(0, 445);
            this.pnlAdminSubMenu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlAdminSubMenu.Name = "pnlAdminSubMenu";
            this.pnlAdminSubMenu.Size = new System.Drawing.Size(250, 301);
            this.pnlAdminSubMenu.TabIndex = 17;
            this.pnlAdminSubMenu.Visible = false;
            // 
            // btnProgram
            // 
            this.btnProgram.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.btnProgram.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnProgram.BorderRadius = 10;
            this.btnProgram.BorderSize = 0;
            this.btnProgram.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProgram.FlatAppearance.BorderSize = 0;
            this.btnProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgram.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnProgram.ForeColor = System.Drawing.Color.White;
            this.btnProgram.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnProgram.IconSize = 30;
            this.btnProgram.Image = ((System.Drawing.Image)(resources.GetObject("btnProgram.Image")));
            this.btnProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgram.IndentLevel = 2;
            this.btnProgram.IsActive = false;
            this.btnProgram.Location = new System.Drawing.Point(0, 120);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(250, 60);
            this.btnProgram.TabIndex = 17;
            this.btnProgram.Text = "Program";
            this.btnProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProgram.UseVisualStyleBackColor = false;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click_1);
            // 
            // btnSection
            // 
            this.btnSection.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.btnSection.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSection.BorderRadius = 10;
            this.btnSection.BorderSize = 0;
            this.btnSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSection.FlatAppearance.BorderSize = 0;
            this.btnSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSection.ForeColor = System.Drawing.Color.White;
            this.btnSection.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnSection.IconSize = 30;
            this.btnSection.Image = ((System.Drawing.Image)(resources.GetObject("btnSection.Image")));
            this.btnSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSection.IndentLevel = 2;
            this.btnSection.IsActive = false;
            this.btnSection.Location = new System.Drawing.Point(0, 60);
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(250, 60);
            this.btnSection.TabIndex = 16;
            this.btnSection.Text = "Section";
            this.btnSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSection.UseVisualStyleBackColor = false;
            this.btnSection.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnCurriculum
            // 
            this.btnCurriculum.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnCurriculum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.btnCurriculum.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCurriculum.BorderRadius = 10;
            this.btnCurriculum.BorderSize = 0;
            this.btnCurriculum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCurriculum.FlatAppearance.BorderSize = 0;
            this.btnCurriculum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurriculum.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCurriculum.ForeColor = System.Drawing.Color.White;
            this.btnCurriculum.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnCurriculum.IconSize = 30;
            this.btnCurriculum.Image = ((System.Drawing.Image)(resources.GetObject("btnCurriculum.Image")));
            this.btnCurriculum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurriculum.IndentLevel = 2;
            this.btnCurriculum.IsActive = false;
            this.btnCurriculum.Location = new System.Drawing.Point(0, 0);
            this.btnCurriculum.Name = "btnCurriculum";
            this.btnCurriculum.Size = new System.Drawing.Size(250, 60);
            this.btnCurriculum.TabIndex = 15;
            this.btnCurriculum.Text = "Curriculum";
            this.btnCurriculum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurriculum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurriculum.UseVisualStyleBackColor = false;
            this.btnCurriculum.Click += new System.EventHandler(this.btnCurriculum_Click_1);
            // 
            // btnAccounts
            // 
            this.btnAccounts.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnAccounts.BackColor = System.Drawing.Color.Maroon;
            this.btnAccounts.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAccounts.BorderRadius = 10;
            this.btnAccounts.BorderSize = 0;
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAccounts.ForeColor = System.Drawing.Color.White;
            this.btnAccounts.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnAccounts.IconSize = 30;
            this.btnAccounts.Image = ((System.Drawing.Image)(resources.GetObject("btnAccounts.Image")));
            this.btnAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.IndentLevel = 0;
            this.btnAccounts.IsActive = false;
            this.btnAccounts.Location = new System.Drawing.Point(0, 748);
            this.btnAccounts.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(250, 60);
            this.btnAccounts.TabIndex = 14;
            this.btnAccounts.Text = "Accounts";
            this.btnAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnLogout.BackColor = System.Drawing.Color.Maroon;
            this.btnLogout.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogout.BorderRadius = 10;
            this.btnLogout.BorderSize = 0;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnLogout.IconSize = 30;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.IndentLevel = 0;
            this.btnLogout.IsActive = false;
            this.btnLogout.Location = new System.Drawing.Point(0, 810);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 60);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFaculty
            // 
            this.btnFaculty.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.btnFaculty.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFaculty.BorderRadius = 10;
            this.btnFaculty.BorderSize = 0;
            this.btnFaculty.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFaculty.FlatAppearance.BorderSize = 0;
            this.btnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnFaculty.ForeColor = System.Drawing.Color.White;
            this.btnFaculty.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnFaculty.IconSize = 30;
            this.btnFaculty.Image = ((System.Drawing.Image)(resources.GetObject("btnFaculty.Image")));
            this.btnFaculty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFaculty.IndentLevel = 2;
            this.btnFaculty.IsActive = false;
            this.btnFaculty.Location = new System.Drawing.Point(0, 240);
            this.btnFaculty.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnFaculty.Name = "btnFaculty";
            this.btnFaculty.Size = new System.Drawing.Size(250, 60);
            this.btnFaculty.TabIndex = 19;
            this.btnFaculty.Text = "Faculty";
            this.btnFaculty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFaculty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFaculty.UseVisualStyleBackColor = false;
            this.btnFaculty.Click += new System.EventHandler(this.btnFaculty_Click_1);
            // 
            // btnCourse
            // 
            this.btnCourse.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.btnCourse.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCourse.BorderRadius = 10;
            this.btnCourse.BorderSize = 0;
            this.btnCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCourse.FlatAppearance.BorderSize = 0;
            this.btnCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCourse.ForeColor = System.Drawing.Color.White;
            this.btnCourse.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnCourse.IconSize = 30;
            this.btnCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnCourse.Image")));
            this.btnCourse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourse.IndentLevel = 2;
            this.btnCourse.IsActive = false;
            this.btnCourse.Location = new System.Drawing.Point(0, 180);
            this.btnCourse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(250, 60);
            this.btnCourse.TabIndex = 18;
            this.btnCourse.Text = "Course";
            this.btnCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCourse.UseVisualStyleBackColor = false;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click_1);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1443, 862);
            this.Controls.Add(this.pnlContent);
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlContent.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlAdminSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer tmrUploadTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Controls.iconButton btnLogout;
        private Controls.iconButton btnDashboard;
        private Controls.iconButton btnSearch;
        private Controls.iconButton btnBatchUpload;
        private Controls.iconButton btnAdminTool;
        private System.Windows.Forms.Panel pnlAdminSubMenu;
        private Controls.iconButton btnProgram;
        private Controls.iconButton btnCurriculum;
        private Controls.iconButton btnAccounts;
        private Controls.iconButton btnFaculty;
        private Controls.iconButton btnCourse;
        private Controls.iconButton btnSection;
    }
}