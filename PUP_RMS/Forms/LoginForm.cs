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
        // Timer for the Fade-In Effect
        private Timer tmrFadeIn;

        public LoginForm()
        {
            // 1. START INVISIBLE
            // This hides the initial "glitchy" drawing phase entirely.
            this.Opacity = 0;

            // 2. ENABLE BUFFERING
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            ApplyDoubleBufferingRecursively(this.Controls);
            InitializeFadeTimer();
        }

        // --- SETUP FADE TIMER ---
        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer();
            tmrFadeIn.Interval = 10; // Fast ticks for smoothness
            tmrFadeIn.Tick += TmrFadeIn_Tick;
        }

        private void TmrFadeIn_Tick(object sender, EventArgs e)
        {
            // Gradually increase visibility
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05; // Increase by 5% every tick
            }
            else
            {
                tmrFadeIn.Stop(); // Stop when fully visible
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000; // WS_CLIPCHILDREN
                return cp;
            }
        }

        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren) ApplyDoubleBufferingRecursively(c.Controls);
            }
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);
        }

        // ======================================================
        // FORM LOAD
        // ======================================================
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Freeze layout

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            textBox4.UseSystemPasswordChar = true;
            pictureBoxShow.Visible = true;
            pictureBoxHide.Visible = false;

            if (Properties.Settings.Default.RememberMe)
            {
                textBox3.Text = Properties.Settings.Default.SavedUsername;
                textBox4.Text = Properties.Settings.Default.SavedPassword;
                checkBoxRememberMe.Checked = true;
            }

            AdjustLayout();
            AttachClickEvent(this);
            this.MouseDown += Background_Click;

            this.ResumeLayout(true); // Draw everything

            // NOW START THE FADE IN
            // The controls are loaded, layout is fixed, but user sees nothing yet.
            // This starts the reveal.
            tmrFadeIn.Start();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
            this.Refresh();
        }

        private void AdjustLayout()
        {
            if (roundedShadowPanel2 == null) return;
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int centerOfRightSide = (w / 2) + (w / 4);
            int verticalCenter = (h - roundedShadowPanel2.Height) / 2;
            roundedShadowPanel2.Left = centerOfRightSide - (roundedShadowPanel2.Width / 2);
            roundedShadowPanel2.Top = verticalCenter;
        }

        // ======================================================
        // NAVIGATION
        // ======================================================
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

        private void linkLabelSignUp(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show(); // This will trigger the fade-in of RegisterForm
            this.Hide();
        }

        // ======================================================
        // UI HELPERS
        // ======================================================
        private void pictureBoxHide_Click_1(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            pictureBoxShow.Visible = true;
            pictureBoxHide.Visible = false;
        }

        private void pictureBoxShow_Click_1(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
            pictureBoxShow.Visible = false;
            pictureBoxHide.Visible = true;
        }

        private void AttachClickEvent(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.MouseDown += Background_Click;
                if (c.HasChildren) AttachClickEvent(c);
            }
        }

        private void Background_Click(object sender, MouseEventArgs e)
        {
            if (sender is Button || sender is CheckBox || sender is LinkLabel || sender is TextBox || sender is PictureBox) return;
            if (sender is Panel pnl) { foreach (Control child in pnl.Controls) if (child.Focused) return; }
            ResetBorders();
            this.ActiveControl = null;
        }

        private void ResetBorders()
        {
            if (roundedPanel2 != null) roundedPanel2.SetBorderHover(false);
            if (roundedPanel3 != null) roundedPanel3.SetBorderHover(false);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanel2 != null) roundedPanel2.SetBorderHover(true);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanel3 != null) roundedPanel3.SetBorderHover(true);
        }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = checkBoxRememberMe.Checked;
            Properties.Settings.Default.Save();
        }

        // Placeholders
        private void roundedPanel1_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanel2_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanel3_Paint(object sender, PaintEventArgs e) { }
        private void roundedShadowPanel2_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { textBox4.Focus(); }
        private void label3_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void userIcon_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void passIcon_click(object sender, EventArgs e) { textBox4.Focus(); }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged_1(object sender, EventArgs e) { }

        private void roundedPanel2_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void roundedPanel3_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
    }
}