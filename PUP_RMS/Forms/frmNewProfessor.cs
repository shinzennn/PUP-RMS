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
    public partial class frmNewProfessor : Form
    {
        public frmNewProfessor()
        {
            InitializeComponent();
        }

        private void CreateProfessor() 
        { 
            bool success = Core.DbControl.SetData($"INSERT INTO Faculty (FirstName, MiddleName, LastName) VALUES ('{txtFirstName.Text}', '{txtMiddleInitial.Text}', '{txtLastName.Text}')");
            if (success)
            {
                MessageBox.Show("New Faculty has been created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create new Faculty. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateProfessor();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
