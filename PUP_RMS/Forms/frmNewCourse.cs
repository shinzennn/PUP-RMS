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

namespace PUP_RMS.Forms
{
    public partial class frmNewCourse : Form
    {
        public frmNewCourse()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CreateCourse()
        {
            if(txtCourseCode.Text == "" || txtCourseDesc.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = Core.DbControl.SetData($"INSERT INTO Course (CourseCode, CourseDescription) VALUES ('{txtCourseCode.Text}', '{txtCourseDesc.Text}')");

            if (success)
            {
                MessageBox.Show("New course has been created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.LogCourseAddition(txtCourseCode.Text, txtCourseDesc.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create new course. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateCourse();
            this.DialogResult = DialogResult.OK;
        }

        private void frmNewCourse_Load(object sender, EventArgs e)
        {

        }

        private void txtCourseDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
