using System.Drawing;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    partial class LoadingScreen
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
        private void InitializeComponents()
        {
            // Main Panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(mainPanel);

            // Title Label
            Label titleLabel = new Label
            {
                Text = "Loading Dashboard",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(128, 0, 0), // Maroon
                AutoSize = false,
                Height = 40,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 10, 0, 0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(titleLabel);

            // Progress Bar
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Value = 0,
                Maximum = 100,
                Height = 20,
                BackColor = Color.LightGray,
                ForeColor = Color.FromArgb(255, 215, 0) // Gold
            };
            progressBar.Left = 30;
            progressBar.Top = 70;
            progressBar.Width = 340;
            mainPanel.Controls.Add(progressBar);

            // Status Label
            statusLabel = new Label
            {
                Text = "Initializing...",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = false,
                Height = 30,
                Top = 100,
                Left = 30,
                Width = 340,
                TextAlign = ContentAlignment.TopCenter
            };
            mainPanel.Controls.Add(statusLabel);

            // Percentage Label
            //Label percentLabel = new Label
            //{
            //    Text = "0%",
            //    Font = new Font("Segoe UI", 10, FontStyle.Bold),
            //    ForeColor = Color.FromArgb(128, 0, 0),
            //    AutoSize = false,
            //    Height = 20,
            //    Top = 40,
            //    //Right = 50,
            //    //Left = 50,
            //    Width = 340,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //mainPanel.Controls.Add(percentLabel);

            // Update percentage label
            this.Shown += (s, e) =>
            {
                animationTimer = new Timer();
                animationTimer.Interval = 50;
                animationTimer.Tick += (sender, args) =>
                {
                    if (progressBar.Value < progressBar.Maximum)
                    {
                        //percentLabel.Text = progressBar.Value + "%";
                    }
                };
                animationTimer.Start();
            };
        }

        #endregion
    }
}