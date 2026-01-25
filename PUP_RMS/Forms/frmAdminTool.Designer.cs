namespace PUP_RMS.Forms
{
    partial class frmAdminTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminTool));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedPanel3 = new PUP_RMS.RoundedPanel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanelNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnManageCurriculums = new PUP_RMS.Controls.iconButton();
            this.btnManagePrograms = new PUP_RMS.Controls.iconButton();
            this.btnManageCourses = new PUP_RMS.Controls.iconButton();
            this.btnManageFaculties = new PUP_RMS.Controls.iconButton();
            this.panelMainContent = new PUP_RMS.RoundedShadowPanel();
            this.panelNavigationLine = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.tableLayoutPanelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelNavigation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelMainContent, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelNavigationLine, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1366, 768);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 10;
            this.roundedPanel3.BorderSize = 0;
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
            this.roundedPanel3.Size = new System.Drawing.Size(1360, 74);
            this.roundedPanel3.TabIndex = 15;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(14, 9);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(157, 32);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Admin Tools";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(25, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Manage Records";
            // 
            // tableLayoutPanelNavigation
            // 
            this.tableLayoutPanelNavigation.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelNavigation.ColumnCount = 7;
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelNavigation.Controls.Add(this.btnManageCurriculums, 1, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.btnManagePrograms, 2, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.btnManageCourses, 3, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.btnManageFaculties, 4, 0);
            this.tableLayoutPanelNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNavigation.Location = new System.Drawing.Point(3, 80);
            this.tableLayoutPanelNavigation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelNavigation.Name = "tableLayoutPanelNavigation";
            this.tableLayoutPanelNavigation.RowCount = 1;
            this.tableLayoutPanelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNavigation.Size = new System.Drawing.Size(1360, 50);
            this.tableLayoutPanelNavigation.TabIndex = 16;
            // 
            // btnManageCurriculums
            // 
            this.btnManageCurriculums.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageCurriculums.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageCurriculums.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnManageCurriculums.BorderRadius = 0;
            this.btnManageCurriculums.BorderSize = 2;
            this.btnManageCurriculums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCurriculums.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageCurriculums.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnManageCurriculums.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageCurriculums.IconSize = 24;
            this.btnManageCurriculums.Image = ((System.Drawing.Image)(resources.GetObject("btnManageCurriculums.Image")));
            this.btnManageCurriculums.IndentLevel = 0;
            this.btnManageCurriculums.IsActive = false;
            this.btnManageCurriculums.Location = new System.Drawing.Point(308, 3);
            this.btnManageCurriculums.Name = "btnManageCurriculums";
            this.btnManageCurriculums.Size = new System.Drawing.Size(180, 44);
            this.btnManageCurriculums.TabIndex = 0;
            this.btnManageCurriculums.Text = "Manage Curriculums";
            this.btnManageCurriculums.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCurriculums.UseVisualStyleBackColor = false;
            this.btnManageCurriculums.Click += new System.EventHandler(this.btnManageCurriculums_Click);
            // 
            // btnManagePrograms
            // 
            this.btnManagePrograms.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManagePrograms.BackColor = System.Drawing.Color.White;
            this.btnManagePrograms.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnManagePrograms.BorderRadius = 0;
            this.btnManagePrograms.BorderSize = 2;
            this.btnManagePrograms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagePrograms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManagePrograms.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnManagePrograms.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManagePrograms.IconSize = 24;
            this.btnManagePrograms.Image = ((System.Drawing.Image)(resources.GetObject("btnManagePrograms.Image")));
            this.btnManagePrograms.IndentLevel = 0;
            this.btnManagePrograms.IsActive = false;
            this.btnManagePrograms.Location = new System.Drawing.Point(494, 3);
            this.btnManagePrograms.Name = "btnManagePrograms";
            this.btnManagePrograms.Size = new System.Drawing.Size(185, 44);
            this.btnManagePrograms.TabIndex = 1;
            this.btnManagePrograms.Text = "Manage Programs";
            this.btnManagePrograms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagePrograms.UseVisualStyleBackColor = false;
            this.btnManagePrograms.Click += new System.EventHandler(this.btnManagePrograms_Click);
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageCourses.BackColor = System.Drawing.Color.White;
            this.btnManageCourses.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnManageCourses.BorderRadius = 0;
            this.btnManageCourses.BorderSize = 2;
            this.btnManageCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCourses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageCourses.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnManageCourses.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageCourses.IconSize = 24;
            this.btnManageCourses.Image = ((System.Drawing.Image)(resources.GetObject("btnManageCourses.Image")));
            this.btnManageCourses.IndentLevel = 0;
            this.btnManageCourses.IsActive = false;
            this.btnManageCourses.Location = new System.Drawing.Point(685, 3);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(180, 44);
            this.btnManageCourses.TabIndex = 2;
            this.btnManageCourses.Text = "Manage Courses";
            this.btnManageCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCourses.UseVisualStyleBackColor = false;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            // 
            // btnManageFaculties
            // 
            this.btnManageFaculties.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageFaculties.BackColor = System.Drawing.Color.White;
            this.btnManageFaculties.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnManageFaculties.BorderRadius = 0;
            this.btnManageFaculties.BorderSize = 2;
            this.btnManageFaculties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageFaculties.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageFaculties.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnManageFaculties.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.btnManageFaculties.IconSize = 24;
            this.btnManageFaculties.Image = ((System.Drawing.Image)(resources.GetObject("btnManageFaculties.Image")));
            this.btnManageFaculties.IndentLevel = 0;
            this.btnManageFaculties.IsActive = false;
            this.btnManageFaculties.Location = new System.Drawing.Point(871, 3);
            this.btnManageFaculties.Name = "btnManageFaculties";
            this.btnManageFaculties.Size = new System.Drawing.Size(180, 44);
            this.btnManageFaculties.TabIndex = 3;
            this.btnManageFaculties.Text = "Manage Faculties";
            this.btnManageFaculties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageFaculties.UseVisualStyleBackColor = false;
            this.btnManageFaculties.Click += new System.EventHandler(this.btnManageFaculties_Click);
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.Transparent;
            this.panelMainContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panelMainContent.BorderRadius = 20;
            this.panelMainContent.BorderSize = 2;
            this.panelMainContent.Location = new System.Drawing.Point(3, 143);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.PanelColor = System.Drawing.Color.Transparent;
            this.panelMainContent.PanelImage = null;
            this.panelMainContent.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelMainContent.ShadowDepth = 10;
            this.panelMainContent.ShadowEnabled = true;
            this.panelMainContent.ShadowShift = 5;
            this.panelMainContent.Size = new System.Drawing.Size(1360, 622);
            this.panelMainContent.TabIndex = 19;
            // 
            // panelNavigationLine
            // 
            this.panelNavigationLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panelNavigationLine.Location = new System.Drawing.Point(183, 133);
            this.panelNavigationLine.Margin = new System.Windows.Forms.Padding(183, 3, 160, 3);
            this.panelNavigationLine.Name = "panelNavigationLine";
            this.panelNavigationLine.Size = new System.Drawing.Size(750, 3);
            this.panelNavigationLine.TabIndex = 18;
            // 
            // frmAdminTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminTool";
            this.Text = "frmAdminTool";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.tableLayoutPanelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPanel roundedPanel3;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNavigation;
        private PUP_RMS.Controls.iconButton btnManageCurriculums;
        private PUP_RMS.Controls.iconButton btnManagePrograms;
        private PUP_RMS.Controls.iconButton btnManageCourses;
        private PUP_RMS.Controls.iconButton btnManageFaculties;
        private System.Windows.Forms.Panel panelNavigationLine;
        private RoundedShadowPanel panelMainContent;
    }
}