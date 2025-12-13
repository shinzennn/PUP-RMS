using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Core;
using PUP_RMS.Forms;

namespace PUP_RMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ======================================================
        // SECTION 1: FORM LOAD
        // ======================================================
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            textBox4.UseSystemPasswordChar = true;
            pictureBoxShow.Visible = true;
            pictureBoxHide.Visible = false;

            // REMEMBER ME LOAD
            if (Properties.Settings.Default.RememberMe)
            {
                textBox3.Text = Properties.Settings.Default.SavedUsername;
                textBox4.Text = Properties.Settings.Default.SavedPassword;
                checkBoxRememberMe.Checked = true;
            }
            else
            {
                checkBoxRememberMe.Checked = false;
            }

            AdjustLayout();
            // IMPORTANT: The AttachClickEvent and this.MouseDown are necessary for your custom focus logic.
            // We fix the click-blocking issue in the Background_Click method below.
            AttachClickEvent(this);
            this.MouseDown += Background_Click;
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;

            int centerOfRightSide = (w / 2) + (w / 4);
            int verticalCenter = (h - roundedShadowPanel2.Height) / 2;

            roundedShadowPanel2.Left = centerOfRightSide - (roundedShadowPanel2.Width / 2);
            roundedShadowPanel2.Top = verticalCenter;
        }

        // ======================================================
        // SECTION 2: LOGIN BUTTON
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
                if (checkBoxRememberMe.Checked)
                {
                    Properties.Settings.Default.SavedUsername = user;
                    Properties.Settings.Default.SavedPassword = pass;
                    Properties.Settings.Default.RememberMe = true;
                }
                else
                {
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.SavedPassword = "";
                    Properties.Settings.Default.RememberMe = false;
                }

                Properties.Settings.Default.Save();

                MainDashboard dash = new MainDashboard();
                dash.Show();
                this.Hide();
            }
            else
            {
                new CustomMsgBox("⚠ Wrong Username or Password!").ShowDialog(this);
            }
        }


        // ======================================================
        // SECTION 3: SHOW / HIDE PASSWORD
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

        // ======================================================
        // SECTION 4: OUTSIDE CLICK REMOVE FOCUS (FIXED LOGIC)
        // ======================================================
        private void AttachClickEvent(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.MouseDown += Background_Click;

                if (c.HasChildren)
                    AttachClickEvent(c);
            }
        }

        // *** FIX: This method now checks if the clicked control should be ignored ***
        private void Background_Click(object sender, MouseEventArgs e)
        {
            // If the sender is an interactive control, we MUST let it handle its own click,
            // otherwise, the click event will be consumed here before reaching the control.
            if (sender is Button || sender is CheckBox || sender is LinkLabel || sender is TextBox)
            {
                // Note: The click has already registered on the sender. We return immediately
                // so the following focus reset code doesn't interfere with the control's state.
                return;
            }

            // If the sender is a panel, check its children before resetting focus
            if (sender is Panel pnl)
            {
                foreach (Control child in pnl.Controls)
                {
                    if (child.Focused) return;
                }
            }

            ResetBorders();
            this.ActiveControl = null;
        }

        private void ResetBorders()
        {
            // Note: Assuming roundedPanel2 and roundedPanel3 are containers for the textboxes
            roundedPanel2.SetBorderHover(false);
            roundedPanel3.SetBorderHover(false);
        }

        // ======================================================
        // SECTION 5: TEXTBOX FOCUS EVENTS
        // ======================================================
        private void textBox3_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            roundedPanel2.SetBorderHover(true);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            roundedPanel3.SetBorderHover(true);
        }

        // ======================================================
        // SECTION 6: IGNORE
        // ======================================================
        private void roundedPanel1_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanel2_Paint(object sender, PaintEventArgs e) { }
        private void roundedPanel3_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { textBox4.Focus(); }
        private void label3_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void userIcon_click(object sender, EventArgs e) { textBox3.Focus(); }
        private void passIcon_click(object sender, EventArgs e) { textBox4.Focus(); }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = checkBoxRememberMe.Checked;
            Properties.Settings.Default.Save();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabelSignUp(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Create an instance of the new RegisterForm
           RegisterForm registerForm = new RegisterForm();

            // 2. Show the new form
            registerForm.Show();

            // 3. Hide the current LoginForm
            this.Hide();
        }

        private void roundedShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
