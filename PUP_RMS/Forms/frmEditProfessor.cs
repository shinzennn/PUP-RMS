using PUP_RMS.Core;
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
    public partial class frmEditProfessor : Form
    {
        public frmEditProfessor()
        {
            InitializeComponent();
        }

        public int professorID;

        private void LoadProfessor()
        {
            DataTable dt = Core.DbControl.GetData($"SELECT * FROM Faculty WHERE FacultyID = {professorID}");
            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtFirstName.Text = row["FirstName"].ToString();
                txtMiddleInitial.Text = row["MiddleName"] is DBNull ? "" : row["MiddleName"].ToString(); // CATCHES NULL VALUE
                txtLastName.Text = row["LastName"].ToString();
            }
        }

        private void UpdateProfessor() 
        { 
            bool success = Core.DbControl.SetData($"UPDATE Faculty SET FirstName = '{txtFirstName.Text}', MiddleName = '{txtMiddleInitial.Text}', LastName = '{txtLastName.Text}' WHERE FacultyID = {professorID}");
            if(success)
            {
                MessageBox.Show("Faculty has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update Faculty. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateProfessor();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditProfessor_Load(object sender, EventArgs e)
        {
            if(professorID > 0)
            {
                LoadProfessor();
            }
        }
    }
}
