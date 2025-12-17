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
            this.btnUpload = new PUP_RMS.Controls.iconButton();
            this.btnBatchUpload = new PUP_RMS.Controls.iconButton();
            this.btnIndividUpload = new PUP_RMS.Controls.iconButton();
            this.btnPrint = new PUP_RMS.Controls.iconButton();
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
            this.flowLayoutPanelMain.Controls.Add(this.btnPrint);
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
            this.flowLayoutPanelUpload.Controls.Add(this.btnUpload);
            this.flowLayoutPanelUpload.Controls.Add(this.btnBatchUpload);
            this.flowLayoutPanelUpload.Controls.Add(this.btnIndividUpload);
            this.flowLayoutPanelUpload.Location = new System.Drawing.Point(3, 353);
            this.flowLayoutPanelUpload.Name = "flowLayoutPanelUpload";
            this.flowLayoutPanelUpload.Size = new System.Drawing.Size(244, 60);
            this.flowLayoutPanelUpload.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpload.BorderRadius = 10;
            this.btnUpload.BorderSize = 0;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnUpload.IconSize = 30;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.IndentLevel = 0;
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
            this.btnBatchUpload.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnBatchUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnBatchUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBatchUpload.BorderRadius = 10;
            this.btnBatchUpload.BorderSize = 0;
            this.btnBatchUpload.FlatAppearance.BorderSize = 0;
            this.btnBatchUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchUpload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchUpload.ForeColor = System.Drawing.Color.White;
            this.btnBatchUpload.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnBatchUpload.IconSize = 30;
            this.btnBatchUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchUpload.Image")));
            this.btnBatchUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchUpload.IndentLevel = 1;
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
            this.btnIndividUpload.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnIndividUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnIndividUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnIndividUpload.BorderRadius = 10;
            this.btnIndividUpload.BorderSize = 0;
            this.btnIndividUpload.FlatAppearance.BorderSize = 0;
            this.btnIndividUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndividUpload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndividUpload.ForeColor = System.Drawing.Color.White;
            this.btnIndividUpload.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnIndividUpload.IconSize = 30;
            this.btnIndividUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnIndividUpload.Image")));
            this.btnIndividUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndividUpload.IndentLevel = 1;
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
            this.btnPrint.ActiveColor = System.Drawing.Color.Goldenrod;
            this.btnPrint.BackColor = System.Drawing.Color.Maroon;
            this.btnPrint.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPrint.BorderRadius = 10;
            this.btnPrint.BorderSize = 0;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverColor = System.Drawing.Color.Goldenrod;
            this.btnPrint.IconSize = 30;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.IndentLevel = 0;
            this.btnPrint.IsActive = false;
            this.btnPrint.Location = new System.Drawing.Point(3, 419);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(244, 60);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnLogout.Location = new System.Drawing.Point(3, 485);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(244, 60);
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
        private Controls.iconButton btnUpload;
        private Controls.iconButton btnBatchUpload;
        private Controls.iconButton btnIndividUpload;
        private Controls.iconButton btnPrint;
        private Controls.iconButton btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}