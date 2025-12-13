using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Core; // For the Database helper class
using PUP_RMS.Forms; // For LoginForm and CustomMsgBox

namespace PUP_RMS.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // ======================================================
        // SECTION 1: FORM LOAD AND SETUP
        // ======================================================
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Set up initial password mask (This hides the password)
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxConfirmPassword.UseSystemPasswordChar = true;

            // Initialize the visibility of the show/hide icons
            pictureBoxShowPassword.Visible = true;
            pictureBoxHidePassword.Visible = false;
            pictureBoxShowConfirmPass.Visible = true;
            pictureBoxHideConfirmPass.Visible = false;

            // Apply focus/click handling across the form
            AttachClickEvent(this);
            this.MouseDown += Background_Click;
        }

        // ======================================================
        // SECTION 2: REGISTRATION LOGIC
        // ======================================================
        private void roundedButtonSignUp_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();

            // 1. Input Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                new CustomMsgBox("⚠ All fields are required.").ShowDialog(this);
                return;
            }

            if (password != confirmPassword)
            {
                new CustomMsgBox("⚠ Password and Confirm Password do not match.").ShowDialog(this);
                textBoxPassword.Clear();
                textBoxConfirmPassword.Clear();
                return;
            }

            // 2. Check for Duplicate Username
            string checkUserQuery = $"SELECT COUNT(*) FROM Admin WHERE Username = '{username}'";
            DataTable dt = DbControl.GetData(checkUserQuery);

            if (dt != null && dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                new CustomMsgBox("⚠ Username already exists! Please choose another.").ShowDialog(this);
                return;
            }

            // 3. Database Insert
            string insertQuery = $"INSERT INTO Admin (Username, Password) VALUES ('{username}', '{password}')";
            bool success = DbControl.SetData(insertQuery);

            if (success)
            {
                new CustomMsgBox("Registration Successful! You can now log in.").ShowDialog(this);

                // 4. Navigation to Login Form
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                new CustomMsgBox("❌ Registration Failed. Please check your inputs or connection.").ShowDialog(this);
            }
        }


        // ======================================================
        // SECTION 3: NAVIGATION (BACK TO LOGIN)
        // ======================================================

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // ======================================================
        // SECTION 4: SHOW / HIDE PASSWORD (Password Field)
        // Handlers must match the exact PictureBox names.
        // ======================================================
        private void pictureBoxHidePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true; // Hides
            pictureBoxShowPassword.Visible = true;
            pictureBoxHidePassword.Visible = false;
        }

        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false; // Shows
            pictureBoxShowPassword.Visible = false;
            pictureBoxHidePassword.Visible = true;
        }

        // ======================================================
        // SECTION 5: SHOW / HIDE PASSWORD (Confirm Password Field)
        // Handlers must match the exact PictureBox names.
        // ======================================================
        private void pictureBoxHideConfirmPass_Click(object sender, EventArgs e)
        {
            textBoxConfirmPassword.UseSystemPasswordChar = true; // Hides
            pictureBoxShowConfirmPass.Visible = true;
            pictureBoxHideConfirmPass.Visible = false;
        }

        private void pictureBoxShowConfirmPass_Click(object sender, EventArgs e)
        {
            textBoxConfirmPassword.UseSystemPasswordChar = false; // Shows
            pictureBoxShowConfirmPass.Visible = false;
            pictureBoxHideConfirmPass.Visible = true;
        }


        // ======================================================
        // SECTION 6: TEXTBOX FOCUS AND BORDER STYLING
        // ======================================================
        private void ResetBorders()
        {
            // Reset all input panel borders to default
            roundedPanelUser.SetBorderHover(false);
            roundedPanelPass.SetBorderHover(false);
            roundedPanelConfirmPass.SetBorderHover(false);
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            roundedPanelUser.SetBorderHover(true);
        }
        // Added click event for the Username Icon to mimic your LoginForm logic
        private void pictureBoxUsername_Click(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            roundedPanelPass.SetBorderHover(true);
        }
        // Added click event for the Password Icon to mimic your LoginForm logic
        private void pictureBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Focus();
        }

        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            ResetBorders();
            roundedPanelConfirmPass.SetBorderHover(true);
        }
        // Added click event for the Confirm Password Icon
        private void pictureBoxConfirmPassword_Click(object sender, EventArgs e)
        {
            textBoxConfirmPassword.Focus();
        }


        // ======================================================
        // SECTION 7: OUTSIDE CLICK REMOVE FOCUS
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

        private void Background_Click(object sender, MouseEventArgs e)
        {
            // Ignore if the sender is an interactive control that needs its click
            if (sender is Button || sender is CheckBox || sender is LinkLabel || sender is TextBox || sender is PictureBox)
            {
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

        // ======================================================
        // SECTION 8: IGNORE / UNUSED EVENTS (Placeholders)
        // ======================================================
        private void label7_Click(object sender, EventArgs e) { }
        private void textBoxUsername_TextChanged(object sender, EventArgs e) { }
        private void textBoxPassword_TextChanged(object sender, EventArgs e) { }
        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e) { }

        // REMOVED: private void pictureBoxHidePassword(object sender, EventArgs e) { }
        // This was a duplicate definition and has been removed.
    }
}