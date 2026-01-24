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
            this.adminToolCardButton1 = new PUP_RMS.Controls.AdminToolCardButton();
            this.adminToolCardButton2 = new PUP_RMS.Controls.AdminToolCardButton();
            this.adminToolCardButton3 = new PUP_RMS.Controls.AdminToolCardButton();
            this.adminToolCardButton4 = new PUP_RMS.Controls.AdminToolCardButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.adminToolCardButton1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.adminToolCardButton2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.adminToolCardButton3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.adminToolCardButton4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 749);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 10;
            this.roundedPanel3.BorderSize = 0;
            this.tableLayoutPanel1.SetColumnSpan(this.roundedPanel3, 2);
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
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 6);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(177, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Admin Tools";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Manage Records";
            // 
            // adminToolCardButton1
            // 
            this.adminToolCardButton1.BackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton1.BorderRadius = 20;
            this.adminToolCardButton1.BorderSize = 3;
            this.adminToolCardButton1.CardBackColor = System.Drawing.Color.White;
            this.adminToolCardButton1.FlatAppearance.BorderSize = 0;
            this.adminToolCardButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminToolCardButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.adminToolCardButton1.IconImage = ((System.Drawing.Image)(resources.GetObject("adminToolCardButton1.IconImage")));
            this.adminToolCardButton1.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton1.LabelFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.adminToolCardButton1.LabelText = "Manage Programs";
            this.adminToolCardButton1.Location = new System.Drawing.Point(50, 100);
            this.adminToolCardButton1.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.adminToolCardButton1.Name = "adminToolCardButton1";
            this.adminToolCardButton1.Size = new System.Drawing.Size(460, 294);
            this.adminToolCardButton1.TabIndex = 16;
            this.adminToolCardButton1.UseVisualStyleBackColor = false;
            // 
            // adminToolCardButton2
            // 
            this.adminToolCardButton2.BackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton2.BorderRadius = 20;
            this.adminToolCardButton2.BorderSize = 3;
            this.adminToolCardButton2.CardBackColor = System.Drawing.Color.White;
            this.adminToolCardButton2.FlatAppearance.BorderSize = 0;
            this.adminToolCardButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminToolCardButton2.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.adminToolCardButton2.IconImage = ((System.Drawing.Image)(resources.GetObject("adminToolCardButton2.IconImage")));
            this.adminToolCardButton2.Image = ((System.Drawing.Image)(resources.GetObject("adminToolCardButton2.Image")));
            this.adminToolCardButton2.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton2.LabelFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.adminToolCardButton2.LabelText = "Manage Courses";
            this.adminToolCardButton2.Location = new System.Drawing.Point(610, 100);
            this.adminToolCardButton2.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.adminToolCardButton2.Name = "adminToolCardButton2";
            this.adminToolCardButton2.Size = new System.Drawing.Size(460, 294);
            this.adminToolCardButton2.TabIndex = 17;
            this.adminToolCardButton2.UseVisualStyleBackColor = false;
            this.adminToolCardButton2.Click += new System.EventHandler(this.adminToolCardButton2_Click);
            // 
            // adminToolCardButton3
            // 
            this.adminToolCardButton3.BackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton3.BorderRadius = 20;
            this.adminToolCardButton3.BorderSize = 3;
            this.adminToolCardButton3.CardBackColor = System.Drawing.Color.White;
            this.adminToolCardButton3.FlatAppearance.BorderSize = 0;
            this.adminToolCardButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminToolCardButton3.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.adminToolCardButton3.IconImage = ((System.Drawing.Image)(resources.GetObject("adminToolCardButton3.IconImage")));
            this.adminToolCardButton3.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton3.LabelFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.adminToolCardButton3.LabelText = "Manage Faculty";
            this.adminToolCardButton3.Location = new System.Drawing.Point(50, 434);
            this.adminToolCardButton3.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.adminToolCardButton3.Name = "adminToolCardButton3";
            this.adminToolCardButton3.Size = new System.Drawing.Size(460, 295);
            this.adminToolCardButton3.TabIndex = 18;
            this.adminToolCardButton3.UseVisualStyleBackColor = false;
            // 
            // adminToolCardButton4
            // 
            this.adminToolCardButton4.BackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton4.BorderRadius = 20;
            this.adminToolCardButton4.BorderSize = 3;
            this.adminToolCardButton4.CardBackColor = System.Drawing.Color.White;
            this.adminToolCardButton4.FlatAppearance.BorderSize = 0;
            this.adminToolCardButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.adminToolCardButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminToolCardButton4.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.adminToolCardButton4.IconImage = ((System.Drawing.Image)(resources.GetObject("adminToolCardButton4.IconImage")));
            this.adminToolCardButton4.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.adminToolCardButton4.LabelFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.adminToolCardButton4.LabelText = "Manage Curriculum";
            this.adminToolCardButton4.Location = new System.Drawing.Point(610, 434);
            this.adminToolCardButton4.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.adminToolCardButton4.Name = "adminToolCardButton4";
            this.adminToolCardButton4.Size = new System.Drawing.Size(460, 295);
            this.adminToolCardButton4.TabIndex = 19;
            this.adminToolCardButton4.UseVisualStyleBackColor = false;
            // 
            // frmAdminTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAdminTool";
            this.Text = "frmAdminTool";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPanel roundedPanel3;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private Controls.AdminToolCardButton adminToolCardButton1;
        private Controls.AdminToolCardButton adminToolCardButton2;
        private Controls.AdminToolCardButton adminToolCardButton3;
        private Controls.AdminToolCardButton adminToolCardButton4;
    }
}