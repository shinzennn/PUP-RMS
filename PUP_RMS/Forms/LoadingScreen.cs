using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class LoadingScreen : Form
    {
        private ProgressBar progressBar;
        private Label statusLabel;
        private Timer animationTimer;
        private int progress = 0;
        private bool isIndeterminate = false;

        public LoadingScreen()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 200);
            this.BackColor = Color.White;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Anti-flicker
            this.DoubleBuffered = true;

            InitializeComponents();
        }

        
        public void UpdateProgress(int value, string status = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateProgress(value, status)));
                return;
            }

            if (value < 0) value = 0;
            if (value > 100) value = 100;

            progressBar.Value = value;

            if (!string.IsNullOrEmpty(status))
            {
                statusLabel.Text = status;
                this.Refresh();
            }
        }

        public void SetIndeterminate(bool indeterminate)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetIndeterminate(indeterminate)));
                return;
            }

            isIndeterminate = indeterminate;
            if (indeterminate)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Continuous;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoadingScreen
            // 
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Name = "LoadingScreen";
            this.Text = "a";
            this.ResumeLayout(false);

        }
    }
}
