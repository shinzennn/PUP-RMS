using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Core;
using PUP_RMS.Forms;
using PUP_RMS.Helper;
using PUP_RMS.Model;

namespace PUP_RMS
{
    public partial class LoginForm : Form
    {
        private Timer tmrFadeIn;

        public LoginForm()
        {
            // Lock scaling to prevent the panel from moving away from (531, 40)
            this.AutoScaleMode = AutoScaleMode.None;

            this.Opacity = 0;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            ApplyDoubleBufferingRecursively(this.Controls);
            InitializeFadeTimer();
        }

        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer();
            tmrFadeIn.Interval = 10;
            tmrFadeIn.Tick += TmrFadeIn_Tick;
        }

        private void TmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0) this.Opacity += 0.05;
            else tmrFadeIn.Stop();
        }

        // ======================================================
        // FORM LOAD & EVENTS
        // ======================================================
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
           
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.ControlBox = true;

            pictureBoxHide.Visible = false;
            pictureBoxShow.Visible = true;
            textBox4.UseSystemPasswordChar = true;


            if (Properties.Settings.Default.RememberMe)
            {
                textBox3.Text = Properties.Settings.Default.SavedUsername;
                textBox4.Text = Properties.Settings.Default.SavedPassword;
                checkBoxRememberMe.Checked = true;
            }

            AttachClickEvent(this);
            this.MouseDown += Background_Click;
            this.ResumeLayout(true);
            tmrFadeIn.Start();
        }

        // Removed AdjustLayout and ScaleContents to preserve Designer-only coordinates

        private void roundedButton_Click_1(object sender, EventArgs e)
        {
            string user = textBox3.Text.Trim();
            string pass = textBox4.Text.Trim();
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                new CustomMsgBox("⚠ Please enter Username and Password.").ShowDialog(this);
                return;
            }
            if (DbControl.GetAdmin(user, pass) != null)
            {
                // SETS THE CURRENT ACCOUNT INSTANCE FROM THE DASHBOARD
                MainDashboard.CurrentAccount = DbControl.GetAdmin(user, pass);

                Properties.Settings.Default.SavedUsername = checkBoxRememberMe.Checked ? user : "";
                Properties.Settings.Default.SavedPassword = checkBoxRememberMe.Checked ? pass : "";
                Properties.Settings.Default.RememberMe = checkBoxRememberMe.Checked;
                Properties.Settings.Default.Save();

                MainDashboard dash = new MainDashboard();
                dash.Show();
                this.Hide();

                ActivityLogger.LogUserLogin();
            }
            else
            {
                new CustomMsgBox("⚠ Wrong Username or Password!").ShowDialog(this);
            }
        }

        private void linkLabelSignUp(object sender, LinkLabelLinkClickedEventArgs e) { RegisterForm rf = new RegisterForm(); rf.Show(); this.Hide(); }
        private void pictureBoxHide_Click_1(object sender, EventArgs e) { 
            textBox4.PasswordChar = '●'; 
            pictureBoxHide.Visible=false; 
            pictureBoxShow.Visible = true;
            textBox4.UseSystemPasswordChar = true;
        }
        private void pictureBoxShow_Click_1(object sender, EventArgs e) {
            textBox4.PasswordChar = '\0';
            pictureBoxShow.Visible = false; 
            pictureBoxHide.Visible = true;
            textBox4.UseSystemPasswordChar = false;
        }
        private void AttachClickEvent(Control parent) { foreach (Control c in parent.Controls) { c.MouseDown += Background_Click; if (c.HasChildren) AttachClickEvent(c); } }
        private void Background_Click(object sender, MouseEventArgs e) { if (sender is Button || sender is CheckBox || sender is LinkLabel || sender is TextBox || sender is PictureBox) return; ResetBorders(); this.ActiveControl = null; }
        private void ResetBorders() { if (roundedPanel2 != null) roundedPanel2.SetBorderHover(false); if (roundedPanel3 != null) roundedPanel3.SetBorderHover(false); }
        private void textBox3_Enter(object sender, EventArgs e) { ResetBorders(); if (roundedPanel2 != null) roundedPanel2.SetBorderHover(true); }
        private void textBox4_Enter(object sender, EventArgs e) { ResetBorders(); if (roundedPanel3 != null) roundedPanel3.SetBorderHover(true); }
        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.RememberMe = checkBoxRememberMe.Checked; Properties.Settings.Default.Save(); }
        private void label4_Click(object sender, EventArgs e) { textBox4.Focus(); }
        private void label3_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void userIcon_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void passIcon_click(object sender, EventArgs e) { textBox4.Focus(); }
        private void roundedPanel2_Click(object sender, EventArgs e) { textBox3.Focus(); }
        private void roundedPanel3_Click(object sender, EventArgs e) { textBox4.Focus(); }

        protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.Style |= 0x02000000; return cp; } }
        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls) { foreach (Control c in controls) { SetDoubleBuffered(c); if (c.HasChildren) ApplyDoubleBufferingRecursively(c.Controls); } }
        public static void SetDoubleBuffered(Control c) { if (SystemInformation.TerminalServerSession) return; System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance); if (aProp != null) aProp.SetValue(c, true, null); }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}