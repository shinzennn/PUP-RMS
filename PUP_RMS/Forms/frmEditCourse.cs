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
    public partial class frmEditCourse : Form
    {
        public frmEditCourse()
        {
            InitializeComponent();
        }

        public int courseID;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmEditCourse_Load(object sender, EventArgs e)
        {
            lblID.Text = courseID.ToString();

            if (courseID > 0)
            {
                SearchCourse();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCourse();
        }

        private void SearchCourse()
        {
            DataTable dt = Core.DbControl.GetData($"SELECT * FROM Course WHERE CourseID = {courseID}");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtCourseCode.Text = row["CourseCode"].ToString();
                txtCourseDesc.Text = row["CourseDecription"].ToString();
            }
        }

        private void UpdateCourse()
        {
            bool success = DbControl.SetData($"UPDATE Course SET CourseCode = '{txtCourseCode.Text}', CourseDecription = '{txtCourseDesc.Text}' WHERE CourseID = {courseID}");
            if (success)
            {
                MessageBox.Show("Course has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update course. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
