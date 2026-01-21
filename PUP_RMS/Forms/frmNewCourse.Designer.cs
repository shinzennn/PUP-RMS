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
            this.panelSubInfo = new PUP_RMS.RoundedShadowPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtCrsCode = new System.Windows.Forms.TextBox();
            this.roundedShadowPanel3 = new PUP_RMS.RoundedShadowPanel();
            this.txtCuryear = new System.Windows.Forms.TextBox();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel5 = new PUP_RMS.RoundedShadowPanel();
            this.txtSubDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSubInfo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.roundedShadowPanel3.SuspendLayout();
            this.roundedShadowPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSubInfo
            // 
            this.panelSubInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSubInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelSubInfo.BorderColor = System.Drawing.Color.Transparent;
            this.panelSubInfo.BorderRadius = 20;
            this.panelSubInfo.BorderSize = 0;
            this.panelSubInfo.Controls.Add(this.tableLayoutPanel4);
            this.panelSubInfo.Controls.Add(this.btnCancel);
            this.panelSubInfo.Controls.Add(this.btnSave);
            this.panelSubInfo.Controls.Add(this.roundedShadowPanel5);
            this.panelSubInfo.Controls.Add(this.label5);
            this.panelSubInfo.Controls.Add(this.label2);
            this.panelSubInfo.Location = new System.Drawing.Point(15, 32);
            this.panelSubInfo.Margin = new System.Windows.Forms.Padding(25, 3, 0, 3);
            this.panelSubInfo.Name = "panelSubInfo";
            this.panelSubInfo.PanelColor = System.Drawing.Color.White;
            this.panelSubInfo.PanelImage = null;
            this.panelSubInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSubInfo.ShadowDepth = 10;
            this.panelSubInfo.ShadowEnabled = true;
            this.panelSubInfo.ShadowShift = 5;
            this.panelSubInfo.Size = new System.Drawing.Size(470, 398);
            this.panelSubInfo.TabIndex = 22;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.roundedShadowPanel4, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.roundedShadowPanel3, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(31, 84);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(412, 93);
            this.tableLayoutPanel4.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(209, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = ":Course Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(126, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Curriculum Year:";
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtCrsCode);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(206, 18);
            this.roundedShadowPanel4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(196, 64);
            this.roundedShadowPanel4.TabIndex = 23;
            // 
            // txtCrsCode
            // 
            this.txtCrsCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrsCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCrsCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCrsCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrsCode.Location = new System.Drawing.Point(24, 21);
            this.txtCrsCode.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtCrsCode.Name = "txtCrsCode";
            this.txtCrsCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCrsCode.Size = new System.Drawing.Size(155, 19);
            this.txtCrsCode.TabIndex = 20;
            // 
            // roundedShadowPanel3
            // 
            this.roundedShadowPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderRadius = 20;
            this.roundedShadowPanel3.BorderSize = 0;
            this.roundedShadowPanel3.Controls.Add(this.txtCuryear);
            this.roundedShadowPanel3.Location = new System.Drawing.Point(0, 18);
            this.roundedShadowPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.roundedShadowPanel3.Name = "roundedShadowPanel3";
            this.roundedShadowPanel3.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel3.PanelImage = null;
            this.roundedShadowPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel3.ShadowDepth = 10;
            this.roundedShadowPanel3.ShadowEnabled = true;
            this.roundedShadowPanel3.ShadowShift = 5;
            this.roundedShadowPanel3.Size = new System.Drawing.Size(196, 64);
            this.roundedShadowPanel3.TabIndex = 25;
            // 
            // txtCuryear
            // 
            this.txtCuryear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuryear.BackColor = System.Drawing.Color.LightGray;
            this.txtCuryear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCuryear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuryear.Location = new System.Drawing.Point(24, 21);
            this.txtCuryear.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtCuryear.Name = "txtCuryear";
            this.txtCuryear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCuryear.Size = new System.Drawing.Size(155, 19);
            this.txtCuryear.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(250, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 40);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
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
            this.btnSave.Location = new System.Drawing.Point(76, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // roundedShadowPanel5
            // 
            this.roundedShadowPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderRadius = 20;
            this.roundedShadowPanel5.BorderSize = 0;
            this.roundedShadowPanel5.Controls.Add(this.txtSubDesc);
            this.roundedShadowPanel5.Location = new System.Drawing.Point(31, 244);
            this.roundedShadowPanel5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel5.Name = "roundedShadowPanel5";
            this.roundedShadowPanel5.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel5.PanelImage = null;
            this.roundedShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel5.ShadowDepth = 10;
            this.roundedShadowPanel5.ShadowEnabled = true;
            this.roundedShadowPanel5.ShadowShift = 5;
            this.roundedShadowPanel5.Size = new System.Drawing.Size(412, 64);
            this.roundedShadowPanel5.TabIndex = 27;
            // 
            // txtSubDesc
            // 
            this.txtSubDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtSubDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubDesc.Location = new System.Drawing.Point(24, 21);
            this.txtSubDesc.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtSubDesc.Name = "txtSubDesc";
            this.txtSubDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubDesc.Size = new System.Drawing.Size(366, 19);
            this.txtSubDesc.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = ":Subject Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Subject Information";
            // 
            // frmNewCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 463);
            this.Controls.Add(this.panelSubInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNewCourse";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNewCourse_Load);
            this.panelSubInfo.ResumeLayout(false);
            this.panelSubInfo.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.roundedShadowPanel3.ResumeLayout(false);
            this.roundedShadowPanel3.PerformLayout();
            this.roundedShadowPanel5.ResumeLayout(false);
            this.roundedShadowPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedShadowPanel panelSubInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtCrsCode;
        private RoundedShadowPanel roundedShadowPanel3;
        private System.Windows.Forms.TextBox txtCuryear;
        private RoundedButton btnCancel;
        private RoundedButton btnSave;
        private RoundedShadowPanel roundedShadowPanel5;
        private System.Windows.Forms.TextBox txtSubDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}