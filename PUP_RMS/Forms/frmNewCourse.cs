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
            // VALIDATION
            if (string.IsNullOrEmpty(txtCrsCode.Text) || string.IsNullOrEmpty(txtCuryear.Text) || string.IsNullOrEmpty(txtSubDesc.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CREATE COURSE OBJECT
            Course Course = new Course
            {
                CourseCode = txtCrsCode.Text.Trim(),
                CurriculumYear = txtCuryear.Text.Trim(),
                CourseDescription = txtSubDesc.Text.Trim()
            };

            // CALL CREATE COURSE METHOD
            CourseHelper.CreateCourse(Course);
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
