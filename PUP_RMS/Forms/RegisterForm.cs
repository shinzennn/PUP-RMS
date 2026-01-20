using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Core;
using PUP_RMS.Forms;
using PUP_RMS.Helper;
using PUP_RMS.Model;

namespace PUP_RMS.Forms
{
    public partial class RegisterForm : Form
    {
        // Timer for Fade-In
        private Timer tmrFadeIn;

        public RegisterForm()
        {
            // 1. START INVISIBLE
            this.Opacity = 0;

            // 2. BUFFERING
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
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
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                tmrFadeIn.Stop();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000;
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
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.ControlBox = true;


            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxHidePassword.Visible = false;
            pictureBoxShowPassword.Visible = true;
            




            // --- IMPORTANT: CONNECT THE EVENTS HERE ---
            // 1. Username Events
            textBoxUsername.Enter += textBoxUsername_Enter;
            textBoxUsername.Leave += textBoxUsername_Leave;

            // 2. Password Events
            textBoxPassword.Enter += textBoxPassword_Enter;
            textBoxPassword.Leave += textBoxPassword_Leave;

            //AttachClickEvent(this);
            //this.MouseDown += Background_Click;

            this.ResumeLayout(true);

            // START FADE IN AFTER LOADING IS DONE
            tmrFadeIn.Start();
        }

        private void roundedButtonSignUp_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstName.Text.Trim();
            string lastname = textBoxLastName.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string accountType = comboBoxAccountType.Text;

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || comboBoxAccountType.SelectedIndex == -1)
            {
                new CustomMsgBox("⚠ All fields are required.").ShowDialog(this);
                return;
            }

            string checkUserQuery = $"SELECT COUNT(*) FROM Account WHERE Username = '{username}'";
            DataTable dt = DbControl.GetData(checkUserQuery);
            if (dt != null && dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                new CustomMsgBox("⚠ Username already exists! Please choose another.").ShowDialog(this);
                return;
            }

            // CREATE ACCUNT OBJECT
            Account newAccount = new Account
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password,
                AccountType = accountType
            };

            // INSERT INTO DATABASE
            AccountHelper.CreateAccount(newAccount);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // --- Visual Helpers ---
        private void pictureBoxHidePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '●';
           
            

            pictureBoxHidePassword.Visible = false;
            pictureBoxShowPassword.Visible = true;
            textBoxPassword.UseSystemPasswordChar = true;
        }


        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            
            textBoxPassword.PasswordChar = '\0';

            pictureBoxShowPassword.Visible = false;
            pictureBoxHidePassword.Visible = true;
            textBoxPassword.UseSystemPasswordChar = false;


        }


        private void ResetBorders()
        {
            // Reset ALL borders to normal
            if (roundedPanelUser != null) roundedPanelUser.SetBorderHover(false);
            if (roundedPanelPass != null) roundedPanelPass.SetBorderHover(false);
            if (roundedPanelAccountType != null) roundedPanelAccountType.SetBorderHover(false);
            if (roundedPanelFirst != null) roundedPanelFirst.SetBorderHover(false);
            if (roundedPanelLast != null) roundedPanelLast.SetBorderHover(false);
        }

        // ======================================================
        // FOCUS EVENTS - BORDER COLOR CHANGE LOGIC
        // ======================================================
        // --- FIRST NAME ---
        private void roundedPanelFirst_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanelFirst != null) roundedPanelFirst.SetBorderHover(true); // Turn Maroon ON
        }

        private void roundedPanelFirst_Leave(object sender, EventArgs e)
        {
            if (roundedPanelFirst != null) roundedPanelFirst.SetBorderHover(false);
        }

        // --- LAST NAME ---
        private void roundedPanelLast_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanelLast != null) roundedPanelLast.SetBorderHover(true); // Turn Maroon ON
        }

        private void roundedPanelLast_Leave(object sender, EventArgs e)
        {
            if (roundedPanelLast != null) roundedPanelLast.SetBorderHover(false);
        }

        // --- USERNAME ---
        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanelUser != null) roundedPanelUser.SetBorderHover(true); // Turn Maroon ON
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (roundedPanelUser != null) roundedPanelUser.SetBorderHover(false); // Turn Maroon OFF
        }

        // --- PASSWORD ---
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanelPass != null) roundedPanelPass.SetBorderHover(true); // Turn Maroon ON
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (roundedPanelPass != null) roundedPanelPass.SetBorderHover(false); // Turn Maroon OFF
        }

        // --- CONFIRM PASSWORD ---
        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            if (roundedPanelAccountType != null) roundedPanelAccountType.SetBorderHover(true); // Turn Maroon ON
        }

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (roundedPanelAccountType != null) roundedPanelAccountType.SetBorderHover(false); // Turn Maroon OFF
        }

        private void pictureBoxUsername_Click(object sender, EventArgs e) { textBoxUsername.Focus(); }
        private void pictureBoxPassword_Click(object sender, EventArgs e) { textBoxPassword.Focus(); }
        private void pictureBoxFirstName_Click(object sender, EventArgs e) { textBoxFirstName.Focus(); }
        private void pictureBoxLastName_Click(object sender, EventArgs e) { textBoxLastName.Focus(); }
        
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

            // If background clicked, remove focus and reset borders
            ResetBorders();
            this.ActiveControl = null;
        }

        // Placeholders
        private void label7_Click(object sender, EventArgs e) { }
        private void textBoxUsername_TextChanged(object sender, EventArgs e) { }
        private void textBoxPassword_TextChanged(object sender, EventArgs e) { }
        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e) { }
        private void roundedPanelUser_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanelPass_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanelConfirmPass_Paint(object sender, PaintEventArgs e) { }
        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }

        private void lblUsername_Click(object sender, EventArgs e){textBoxUsername.Focus(); }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Focus();
        }

        private void roundedPanelUser_Click(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }

        private void roundedPanelPass_Click(object sender, EventArgs e)
        {
            textBoxPassword.Focus();
        }

        private void roundedShadowPanelSignUp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

    }
}