namespace PUP_RMS.Forms
{
    partial class frmNewCourse
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.txtCourseDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.roundedButton1 = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.roundedPanel1 = new PUP_RMS.RoundedPanel();
            this.roundedShadowPanel4.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(52, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Course Description";
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCourseCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCourseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseCode.Location = new System.Drawing.Point(20, 23);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(375, 15);
            this.txtCourseCode.TabIndex = 3;
            // 
            // txtCourseDesc
            // 
            this.txtCourseDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtCourseDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCourseDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseDesc.Location = new System.Drawing.Point(31, 17);
            this.txtCourseDesc.Name = "txtCourseDesc";
            this.txtCourseDesc.Size = new System.Drawing.Size(375, 15);
            this.txtCourseDesc.TabIndex = 4;
            this.txtCourseDesc.TextChanged += new System.EventHandler(this.txtCourseDesc_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(143, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "New Course";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderSize = 0;
            this.btnSave.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSave.Location = new System.Drawing.Point(68, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Create";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.roundedButton1.BackColor = System.Drawing.Color.Goldenrod;
            this.roundedButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton1.BorderRadius = 20;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.ButtonColor = System.Drawing.Color.Goldenrod;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.HoverColor = System.Drawing.Color.DarkRed;
            this.roundedButton1.Location = new System.Drawing.Point(280, 374);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(152, 40);
            this.roundedButton1.TabIndex = 30;
            this.roundedButton1.Text = "Cancel";
            this.roundedButton1.TextColor = System.Drawing.Color.White;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.White;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtCourseCode);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(37, 169);
            this.roundedShadowPanel4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(427, 64);
            this.roundedShadowPanel4.TabIndex = 31;
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.White;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.txtCourseDesc);
            this.roundedShadowPanel1.Location = new System.Drawing.Point(37, 267);
            this.roundedShadowPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(427, 64);
            this.roundedShadowPanel1.TabIndex = 32;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.roundedPanel1.BorderColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderRadius = 20;
            this.roundedPanel1.BorderSize = 2;
            this.roundedPanel1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.roundedPanel1.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel1.Location = new System.Drawing.Point(13, 13);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.ShadowBlur = 15;
            this.roundedPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel1.ShadowEnabled = true;
            this.roundedPanel1.ShadowOffset = 5;
            this.roundedPanel1.Size = new System.Drawing.Size(476, 438);
            this.roundedPanel1.TabIndex = 33;
            // 
            // frmNewCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 463);
            this.Controls.Add(this.roundedShadowPanel1);
            this.Controls.Add(this.roundedShadowPanel4);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNewCourse";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNewCourse_Load);
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.roundedShadowPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.TextBox txtCourseDesc;
        private System.Windows.Forms.Label label4;
        private RoundedButton btnSave;
        private RoundedButton roundedButton1;
        private RoundedShadowPanel roundedShadowPanel4;
        private RoundedShadowPanel roundedShadowPanel1;
        private RoundedPanel roundedPanel1;
    }
}