using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PUP_RMS.Controls;

namespace PUP_RMS.Forms
{
    public partial class MainDashboard : Form
    {
        bool uploadExpand = false;

        // Variable to track the currently loaded form
        private Form activeForm = null;

        public MainDashboard()
        {
            InitializeComponent();

            // 1. Load the Dashboard immediately on startup
            OpenChildForm(new frmDashboard());

            // 2. Set the Dashboard button to 'Active' visually so it is red on start
            btnDashboard.IsActive = true;
        }

        // --- NEW HELPER METHOD FOR COLORS ---
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                // 1. Reset ALL buttons to normal state (Not Active)
                btnDashboard.IsActive = false;
                btnSearch.IsActive = false;
                btnUpload.IsActive = false;
                btnPrint.IsActive = false;
                // Note: We usually don't make Logout 'Active', so we skip it.

                // 2. Set the CLICKED button to Active
                iconButton currentBtn = (iconButton)btnSender;
                currentBtn.IsActive = true;
            }
        }

        // --- NAVIGATION LOGIC ---
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- BUTTON EVENTS (UPDATED) ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // <--- Triggers the Color Change
            OpenChildForm(new frmDashboard());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // <--- Triggers the Color Change
            OpenChildForm(new frmSearch());
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            tmrUploadTransition.Start(); // Opens the flow layout panel
            
        }
        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // <--- Triggers the Color Change
            OpenChildForm(new frmBatchUpload());
        }

        private void btnIndividUpload_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // <--- Triggers the Color Change
            OpenChildForm(new frmIndividualUpload());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // <--- Triggers the Color Change
            OpenChildForm(new frmPrint());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        private void tmrUploadTransition_Tick(object sender, EventArgs e)
        {
            if (uploadExpand == false)
            {
                flowLayoutPanelUpload.Height += 10;

                if (flowLayoutPanelUpload.Height >= 190)
                {
                    tmrUploadTransition.Stop();
                    uploadExpand = true;
                }
            }

            if (uploadExpand == true) 
            {
                flowLayoutPanelUpload.Height -= 10;

                if (flowLayoutPanelUpload.Height <= 60) 
                {
                    tmrUploadTransition.Stop();
                    uploadExpand = false;
                }
            }
        }        
    }
}