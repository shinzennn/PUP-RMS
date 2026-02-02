namespace PUP_RMS.Forms
{
    partial class frmnewProgram
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProgram = new System.Windows.Forms.DataGridView();
            this.panelProginfo = new PUP_RMS.RoundedShadowPanel();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel5 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgramDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgamCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).BeginInit();
            this.panelProginfo.SuspendLayout();
            this.roundedShadowPanel5.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProgram
            // 
            this.dgvProgram.AllowUserToAddRows = false;
            this.dgvProgram.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvProgram.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProgram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgram.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProgram.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProgram.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProgram.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgram.ColumnHeadersVisible = false;
            this.dgvProgram.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProgram.Location = new System.Drawing.Point(493, 441);
            this.dgvProgram.Margin = new System.Windows.Forms.Padding(40);
            this.dgvProgram.MultiSelect = false;
            this.dgvProgram.Name = "dgvProgram";
            this.dgvProgram.ReadOnly = true;
            this.dgvProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProgram.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgram.Size = new System.Drawing.Size(0, 0);
            this.dgvProgram.TabIndex = 23;
            this.dgvProgram.Visible = false;
            // 
            // panelProginfo
            // 
            this.panelProginfo.BackColor = System.Drawing.Color.Transparent;
            this.panelProginfo.BorderColor = System.Drawing.Color.Transparent;
            this.panelProginfo.BorderRadius = 20;
            this.panelProginfo.BorderSize = 0;
            this.panelProginfo.Controls.Add(this.btnCancel);
            this.panelProginfo.Controls.Add(this.btnSave);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel5);
            this.panelProginfo.Controls.Add(this.label5);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel4);
            this.panelProginfo.Controls.Add(this.label3);
            this.panelProginfo.Controls.Add(this.label2);
            this.panelProginfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProginfo.Location = new System.Drawing.Point(0, 0);
            this.panelProginfo.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.panelProginfo.Name = "panelProginfo";
            this.panelProginfo.PanelColor = System.Drawing.Color.White;
            this.panelProginfo.PanelImage = null;
            this.panelProginfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelProginfo.ShadowDepth = 10;
            this.panelProginfo.ShadowEnabled = true;
            this.panelProginfo.ShadowShift = 5;
            this.panelProginfo.Size = new System.Drawing.Size(484, 444);
            this.panelProginfo.TabIndex = 22;
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
            this.btnCancel.Location = new System.Drawing.Point(257, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnSave.Location = new System.Drawing.Point(83, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 0;
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
            this.roundedShadowPanel5.Controls.Add(this.txtProgramDesc);
            this.roundedShadowPanel5.Location = new System.Drawing.Point(31, 244);
            this.roundedShadowPanel5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel5.Name = "roundedShadowPanel5";
            this.roundedShadowPanel5.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel5.PanelImage = null;
            this.roundedShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel5.ShadowDepth = 10;
            this.roundedShadowPanel5.ShadowEnabled = true;
            this.roundedShadowPanel5.ShadowShift = 5;
            this.roundedShadowPanel5.Size = new System.Drawing.Size(426, 64);
            this.roundedShadowPanel5.TabIndex = 27;
            // 
            // txtProgramDesc
            // 
            this.txtProgramDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgramDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtProgramDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgramDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramDesc.Location = new System.Drawing.Point(24, 21);
            this.txtProgramDesc.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtProgramDesc.Name = "txtProgramDesc";
            this.txtProgramDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProgramDesc.Size = new System.Drawing.Size(380, 19);
            this.txtProgramDesc.TabIndex = 0;
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
            this.label5.Size = new System.Drawing.Size(157, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Program Description:";
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtProgamCode);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(31, 121);
            this.roundedShadowPanel4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(426, 64);
            this.roundedShadowPanel4.TabIndex = 23;
            // 
            // txtProgamCode
            // 
            this.txtProgamCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgamCode.BackColor = System.Drawing.Color.LightGray;
            this.txtProgamCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgamCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgamCode.Location = new System.Drawing.Point(24, 21);
            this.txtProgamCode.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtProgamCode.Name = "txtProgamCode";
            this.txtProgamCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProgamCode.Size = new System.Drawing.Size(385, 19);
            this.txtProgamCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Program Code:";
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
            this.label2.Size = new System.Drawing.Size(279, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Program Information";
            // 
            // frmnewProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 444);
            this.Controls.Add(this.dgvProgram);
            this.Controls.Add(this.panelProginfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmnewProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Program";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).EndInit();
            this.panelProginfo.ResumeLayout(false);
            this.panelProginfo.PerformLayout();
            this.roundedShadowPanel5.ResumeLayout(false);
            this.roundedShadowPanel5.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedShadowPanel panelProginfo;
        private RoundedButton btnCancel;
        private RoundedButton btnSave;
        private RoundedShadowPanel roundedShadowPanel5;
        private System.Windows.Forms.TextBox txtProgramDesc;
        private System.Windows.Forms.Label label5;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtProgamCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProgram;
    }
}