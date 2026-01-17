namespace PUP_RMS.Forms
{
    partial class frmActivityLogs
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
            this.dgvActivityLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActivityLog
            // 
            this.dgvActivityLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLog.Location = new System.Drawing.Point(12, 12);
            this.dgvActivityLog.Name = "dgvActivityLog";
            this.dgvActivityLog.Size = new System.Drawing.Size(680, 417);
            this.dgvActivityLog.TabIndex = 0;
            // 
            // frmActivityLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.dgvActivityLog);
            this.Name = "frmActivityLogs";
            this.Text = "Activity Logs";
            this.Load += new System.EventHandler(this.frmActivityLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActivityLog;
    }
}