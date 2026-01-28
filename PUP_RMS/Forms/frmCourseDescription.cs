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
    public partial class frmCourseDescription: Form
    {

        public frmCourseDescription(string CourseDesc)
        {
            InitializeComponent();
            Course course = new Course();
            txtCrsDesc.Text = CourseDesc;
            refreshGrid(CourseDesc);
        }

        DataGridViewRow selectedRow = null;

        private void frmCourseDescription_Load(object sender, EventArgs e)
        {
            selectedRow = dgvCourseYear.Rows[0];
        }
       
        private void refreshGrid(string courseDesc)
        {
            dgvCourseYear.DataSource = CourseHelper.GetAllCoursePerDescription(courseDesc);
            dgvCourseYear.ClearSelection();
            dgvCourseYear.Columns["CourseID"].Visible = false;
            selectedRow = dgvCourseYear.Rows[0];
        }

        private void dgvCourseYear_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvCourseYear.Rows[e.RowIndex];

            if (selectedRow != null)
            {
                selectedRow = dgvCourseYear.Rows[e.RowIndex];
                btnEdit.Visible = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // GET VALUES FROM SELECTED ROW
            string courseCode = selectedRow.Cells["CourseCode"].Value?.ToString();
            string courseDesc = txtCrsDesc.Text;
            int courseID = Convert.ToInt32(selectedRow.Cells["CourseID"].Value);

            // GET OPEN frmCourse
            frmCourse crsForm = Application.OpenForms
                .OfType<frmCourse>()
                .FirstOrDefault();

            if (crsForm != null)
            {
                // PASS VALUES TO OPEN FORM
                crsForm.LoadFromCourseDescription(courseCode, null, courseDesc, courseID);
                crsForm.BringToFront();
                crsForm.Focus();
            }

            // CLOSE CURRENT FORM
            this.Close();
        }
    }
}
