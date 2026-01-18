using PUP_RMS.Helper;
using PUP_RMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = MainDashboard.CurrentAccount.FirstName;
            txtLastName.Text = MainDashboard.CurrentAccount.LastName;
            txtUsername.Text = MainDashboard.CurrentAccount.Username;
            txtPassword.Text = MainDashboard.CurrentAccount.Password;

            if(MainDashboard.CurrentAccount.AccountType == "Admin")
            {
                btnCreateAccount.Visible = true;
                btnAccountList.Visible = true;
                btnActivityLog.Visible = true;
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountList_Click(object sender, EventArgs e)
        {
            frmAccountList frmAccountList = new frmAccountList();
            frmAccountList.ShowDialog();
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            frmActivityLogs activityLogs = new frmActivityLogs();
            activityLogs.ShowDialog();
        }

        private void btnEditProfileInfo_Click(object sender, EventArgs e)
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;

            btnEditAccountInfo.Visible = false;
            btnEditProfileInfo.Visible = false;
            btnSaveProfileInfo.Visible = true;
            btnCancelProfile.Visible = true;
        }

        private void btnEditAccountInfo_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;

            btnEditProfileInfo.Visible = false;
            btnEditAccountInfo.Visible = false;
            btnSaveAccountInfo.Visible = true;
            btnCancelAccount.Visible = true;
        }

        private void btnSaveProfileInfo_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if(string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UPDATE CURRENT ACCOUNT OBJECT
            MainDashboard.CurrentAccount.FirstName = txtFirstName.Text.Trim();
            MainDashboard.CurrentAccount.LastName = txtLastName.Text.Trim();

            //EXECUTE QUERY
            if(MainDashboard.CurrentAccount != null)
            {
                AccountHelper.UpdateAccount(MainDashboard.CurrentAccount);
            }

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;

            btnEditAccountInfo.Visible = true;
            btnEditProfileInfo.Visible = true;
            btnCancelProfile.Visible = false;
            btnSaveProfileInfo.Visible = false;
        }

        private void btnSaveAccountInfo_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UPDATE CURRENT ACCOUNT OBJECT
            MainDashboard.CurrentAccount.Username = txtUsername.Text.Trim();
            MainDashboard.CurrentAccount.Password = txtPassword.Text.Trim();

            //EXECUTE QUERY
            if (MainDashboard.CurrentAccount != null)
            {
                AccountHelper.UpdateAccount(MainDashboard.CurrentAccount);
            }

            txtPassword.Enabled = false;
            txtUsername.Enabled = false;

            btnEditProfileInfo.Visible = true;
            btnEditAccountInfo.Visible = true;
            btnSaveAccountInfo.Visible = false;
            btnCancelAccount.Visible = false;
        }

        private void btnCancelProfile_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = MainDashboard.CurrentAccount.FirstName;
            txtLastName.Text = MainDashboard.CurrentAccount.LastName;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;

            btnEditAccountInfo.Visible = true;
            btnEditProfileInfo.Visible = true;
            btnCancelProfile.Visible = false;
            btnSaveProfileInfo.Visible = false;
        }

        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            txtUsername.Text = MainDashboard.CurrentAccount.Username;
            txtPassword.Text = MainDashboard.CurrentAccount.Password;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;


            btnEditProfileInfo.Visible = true;
            btnEditAccountInfo.Visible = true;
            btnSaveAccountInfo.Visible = false;
            btnCancelAccount.Visible = false;
        }


    }
}
