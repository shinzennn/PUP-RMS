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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxYumIcon = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new PUP_RMS.Controls.iconButton();
            this.btnSearch = new PUP_RMS.Controls.iconButton();
            this.flowLayoutPanelUpload = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpload = new PUP_RMS.Controls.iconButton();
            this.btnBatchUpload = new PUP_RMS.Controls.iconButton();
            this.btnIndividUpload = new PUP_RMS.Controls.iconButton();
            this.btnPrint = new PUP_RMS.Controls.iconButton();
            this.btnLogout = new PUP_RMS.Controls.iconButton();
            this.tmrUploadTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYumIcon)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.flowLayoutPanelUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxYumIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 70);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "GradeVault";
            // 
            // pictureBoxYumIcon
            // 
            this.pictureBoxYumIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxYumIcon.BackgroundImage")));
            this.pictureBoxYumIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxYumIcon.Location = new System.Drawing.Point(21, 17);
            this.pictureBoxYumIcon.Name = "pictureBoxYumIcon";
            this.pictureBoxYumIcon.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxYumIcon.TabIndex = 0;
            this.pictureBoxYumIcon.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.flowLayoutPanelMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1370, 679);
            this.pnlContent.TabIndex = 5;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.flowLayoutPanelMain.Controls.Add(this.btnDashboard);
            this.flowLayoutPanelMain.Controls.Add(this.btnSearch);
            this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelUpload);
            this.flowLayoutPanelMain.Controls.Add(this.btnPrint);
            this.flowLayoutPanelMain.Controls.Add(this.btnLogout);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(250, 679);
            this.flowLayoutPanelMain.TabIndex = 10;
            // 
            // btnDashboard
            // 
            this.btnDashboard.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDashboard.BackColor = System.Drawing.Color.Maroon;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDashboard.IconSize = 30;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.IsActive = false;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
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
            this.btnSearch.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.IconSize = 30;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.IsActive = false;
            this.btnSearch.Location = new System.Drawing.Point(3, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(250, 60);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanelUpload
            // 
            this.flowLayoutPanelUpload.BackColor = System.Drawing.Color.LightCoral;
            this.flowLayoutPanelUpload.Controls.Add(this.btnUpload);
            this.flowLayoutPanelUpload.Controls.Add(this.btnBatchUpload);
            this.flowLayoutPanelUpload.Controls.Add(this.btnIndividUpload);
            this.flowLayoutPanelUpload.Location = new System.Drawing.Point(3, 135);
            this.flowLayoutPanelUpload.Name = "flowLayoutPanelUpload";
            this.flowLayoutPanelUpload.Size = new System.Drawing.Size(245, 60);
            this.flowLayoutPanelUpload.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpload.IconSize = 30;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.IsActive = false;
            this.btnUpload.Location = new System.Drawing.Point(0, 0);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(244, 60);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBatchUpload
            // 
            this.btnBatchUpload.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBatchUpload.BackColor = System.Drawing.Color.LightCoral;
            this.btnBatchUpload.FlatAppearance.BorderSize = 0;
            this.btnBatchUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnBatchUpload.ForeColor = System.Drawing.Color.White;
            this.btnBatchUpload.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBatchUpload.IconSize = 30;
            this.btnBatchUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchUpload.Image")));
            this.btnBatchUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.IsActive = false;
            this.btnBatchUpload.Location = new System.Drawing.Point(0, 60);
            this.btnBatchUpload.Margin = new System.Windows.Forms.Padding(0);
            this.btnBatchUpload.Name = "btnBatchUpload";
            this.btnBatchUpload.Size = new System.Drawing.Size(244, 60);
            this.btnBatchUpload.TabIndex = 8;
            this.btnBatchUpload.Text = "Batch Upload";
            this.btnBatchUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBatchUpload.UseVisualStyleBackColor = false;
            this.btnBatchUpload.Click += new System.EventHandler(this.btnBatchUpload_Click);
            // 
            // btnIndividUpload
            // 
            this.btnIndividUpload.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnIndividUpload.BackColor = System.Drawing.Color.LightCoral;
            this.btnIndividUpload.FlatAppearance.BorderSize = 0;
            this.btnIndividUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndividUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnIndividUpload.ForeColor = System.Drawing.Color.White;
            this.btnIndividUpload.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIndividUpload.IconSize = 30;
            this.btnIndividUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnIndividUpload.Image")));
            this.btnIndividUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndividUpload.IsActive = false;
            this.btnIndividUpload.Location = new System.Drawing.Point(0, 120);
            this.btnIndividUpload.Margin = new System.Windows.Forms.Padding(0);
            this.btnIndividUpload.Name = "btnIndividUpload";
            this.btnIndividUpload.Size = new System.Drawing.Size(244, 60);
            this.btnIndividUpload.TabIndex = 9;
            this.btnIndividUpload.Text = "Individual Upload";
            this.btnIndividUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndividUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIndividUpload.UseVisualStyleBackColor = false;
            this.btnIndividUpload.Click += new System.EventHandler(this.btnIndividUpload_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPrint.BackColor = System.Drawing.Color.Maroon;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrint.IconSize = 30;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.IsActive = false;
            this.btnPrint.Location = new System.Drawing.Point(3, 201);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(250, 60);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.BackColor = System.Drawing.Color.Maroon;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.IconSize = 30;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.IsActive = false;
            this.btnLogout.Location = new System.Drawing.Point(3, 267);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 60);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tmrUploadTransition
            // 
            this.tmrUploadTransition.Interval = 10;
            this.tmrUploadTransition.Tick += new System.EventHandler(this.tmrUploadTransition_Tick);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYumIcon)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelUpload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxYumIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer tmrUploadTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private Controls.iconButton btnSearch;
        private Controls.iconButton btnDashboard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUpload;
        private Controls.iconButton btnUpload;
        private Controls.iconButton btnBatchUpload;
        private Controls.iconButton btnIndividUpload;
        private Controls.iconButton btnPrint;
        private Controls.iconButton btnLogout;
    }
}