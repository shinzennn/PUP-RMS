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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDashboard = new PUP_RMS.Controls.iconButton();
            this.btnSearch = new PUP_RMS.Controls.iconButton();
            this.flowLayoutPanelUpload = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBatchUpload = new PUP_RMS.Controls.iconButton();
            this.btnCourse = new PUP_RMS.Controls.iconButton();
            this.btnProfessor = new PUP_RMS.Controls.iconButton();
            this.btnAccounts = new PUP_RMS.Controls.iconButton();
            this.btnLogout = new PUP_RMS.Controls.iconButton();
            this.tmrUploadTransition = new System.Windows.Forms.Timer(this.components);
            this.pnlContent.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlContent.Controls.Add(this.flowLayoutPanelMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1370, 749);
            this.pnlContent.TabIndex = 5;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.flowLayoutPanelMain.Controls.Add(this.pictureBox1);
            this.flowLayoutPanelMain.Controls.Add(this.pictureBox2);
            this.flowLayoutPanelMain.Controls.Add(this.panel1);
            this.flowLayoutPanelMain.Controls.Add(this.btnDashboard);
            this.flowLayoutPanelMain.Controls.Add(this.btnSearch);
            this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelUpload);
            this.flowLayoutPanelMain.Controls.Add(this.btnCourse);
            this.flowLayoutPanelMain.Controls.Add(this.btnProfessor);
            this.flowLayoutPanelMain.Controls.Add(this.btnAccounts);
            this.flowLayoutPanelMain.Controls.Add(this.btnLogout);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(250, 749);
            this.flowLayoutPanelMain.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 156);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(247, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 18);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "       ________________________________";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, -24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 29);
            this.panel2.TabIndex = 12;
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
            this.btnDashboard.Location = new System.Drawing.Point(3, 221);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(244, 60);
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
            this.btnSearch.Location = new System.Drawing.Point(3, 287);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(244, 60);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanelUpload
            // 
            this.flowLayoutPanelUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.flowLayoutPanelUpload.Controls.Add(this.btnBatchUpload);
            this.flowLayoutPanelUpload.Location = new System.Drawing.Point(3, 353);
            this.flowLayoutPanelUpload.Name = "flowLayoutPanelUpload";
            this.flowLayoutPanelUpload.Size = new System.Drawing.Size(244, 60);
            this.flowLayoutPanelUpload.TabIndex = 0;
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
            this.btnBatchUpload.Location = new System.Drawing.Point(0, 0);
            this.btnBatchUpload.Margin = new System.Windows.Forms.Padding(0);
            this.btnBatchUpload.Name = "btnBatchUpload";
            this.btnBatchUpload.Size = new System.Drawing.Size(244, 60);
            this.btnBatchUpload.TabIndex = 7;
            this.btnBatchUpload.Text = "Batch Upload";
            this.btnBatchUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBatchUpload.UseVisualStyleBackColor = false;
            this.btnBatchUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnCourse.BackColor = System.Drawing.Color.Maroon;
            this.btnCourse.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCourse.BorderRadius = 10;
            this.btnCourse.BorderSize = 0;
            this.btnCourse.FlatAppearance.BorderSize = 0;
            this.btnCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCourse.ForeColor = System.Drawing.Color.White;
            this.btnCourse.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnCourse.IconSize = 30;
            this.btnCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnCourse.Image")));
            this.btnCourse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourse.IndentLevel = 0;
            this.btnCourse.IsActive = false;
            this.btnCourse.Location = new System.Drawing.Point(3, 419);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(244, 60);
            this.btnCourse.TabIndex = 12;
            this.btnCourse.Text = "Course";
            this.btnCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCourse.UseVisualStyleBackColor = false;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // btnProfessor
            // 
            this.btnProfessor.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnProfessor.BackColor = System.Drawing.Color.Maroon;
            this.btnProfessor.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnProfessor.BorderRadius = 10;
            this.btnProfessor.BorderSize = 0;
            this.btnProfessor.FlatAppearance.BorderSize = 0;
            this.btnProfessor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfessor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnProfessor.ForeColor = System.Drawing.Color.White;
            this.btnProfessor.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnProfessor.IconSize = 30;
            this.btnProfessor.Image = ((System.Drawing.Image)(resources.GetObject("btnProfessor.Image")));
            this.btnProfessor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfessor.IndentLevel = 0;
            this.btnProfessor.IsActive = false;
            this.btnProfessor.Location = new System.Drawing.Point(3, 485);
            this.btnProfessor.Name = "btnProfessor";
            this.btnProfessor.Size = new System.Drawing.Size(244, 60);
            this.btnProfessor.TabIndex = 13;
            this.btnProfessor.Text = "Professor";
            this.btnProfessor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfessor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfessor.UseVisualStyleBackColor = false;
            this.btnProfessor.Click += new System.EventHandler(this.btnProfessor_Click);
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
            this.btnAccounts.Location = new System.Drawing.Point(3, 551);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(244, 60);
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
            this.btnLogout.Location = new System.Drawing.Point(3, 617);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(244, 60);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlContent.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanelUpload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer tmrUploadTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private Controls.iconButton btnSearch;
        private Controls.iconButton btnDashboard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUpload;
        private Controls.iconButton btnBatchUpload;
        private Controls.iconButton btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Controls.iconButton btnCourse;
        private Controls.iconButton btnProfessor;
        private Controls.iconButton btnAccounts;
    }
}