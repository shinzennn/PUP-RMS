using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PUP_RMS.Helper;
using PUP_RMS.Model;

namespace PUP_RMS.Forms
{
    public partial class newFaculty : Form
    {
        public newFaculty()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
 

            string fullName = FacultyHelper.ConstructFullname(txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim());
            string initials = FacultyHelper.ConstructInitials(fullName);
            // CREATE FACULTY OBJECT
            Faculty faculty = new Faculty
            {
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = txtMiddleName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Initials = initials
            };

            FacultyHelper.CreateFaculty(faculty);


            // REFRESH FORM AND BUTTON
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
