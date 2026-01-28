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
using System.Windows.Shapes;
using PUP_RMS.Helper;
using System.Windows.Controls;

namespace PUP_RMS.Forms
{
    public partial class frmCourse : Form
    {
        int courseIDFrmDesc = 0;
        public frmCourse(string courseCode = null, string curriculumYear = null, string courseDesc = null, int courseID = 0)
        {
            InitializeComponent();
         
         
        }

   public void LoadFromCourseDescription(
    string courseCode,
    string curriculumYear,
    string courseDesc,
    int courseID)
        {
            btnClickState = 3; // EDIT FROM COURSE DESC
            courseIDFrmDesc = courseID;

            txtCrsCode.Text = courseCode;
            txtCuryear.Text = curriculumYear;
            txtSubDesc.Text = courseDesc;

            panelSubInfo.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnCreate.Visible = false;
        }

        DataGridViewRow selectedRow = null;
        int btnClickState = 0; // 0 - None, 1 - Create, 2 - Edit, 3 - Edit from frmCourseDescription, 

        private void frmCourse_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            RefreshGrid();
        }

      

        // DATA GRID VIEW ROW HOVER COLOR CHANGE
        private void dgvCourse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                dgvCourse.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Goldenrod;
            }
        }
        private void dgvCourse_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvCourse.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
        }

        // CONTROL METHODS
        private void RefreshGrid()
        {
            dgvCourse.DataSource = CourseHelper.GetAllCourse();
            dgvCourse.ClearSelection();
            dgvCourse.CurrentCell = null;
            dgvCourse.Columns["CourseID"].Visible = false;
            dgvCourse.Columns["CourseCode"].Visible = false;
            dgvCourse.Columns["CurriculumYear"].Visible = false;
        }

        private void Reset()
        {
            txtCrsCode.Text = "";
            txtCuryear.Text = "";
            txtSubDesc.Text = "";
            panelSubInfo.Enabled = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = false;
            btnCreate.Visible = true;
            RefreshGrid();
        }

       

        private void btnCreate_Click(object sender, EventArgs e)
        {
            panelSubInfo.Enabled = true;
            txtCrsCode.Focus();
            btnClickState = 1; // CREATE
            btnCreate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnEdit.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                return;
            }

            string searchTerm = txtSearch.Text.Trim();

            // EXECUTE QUERY
            dgvCourse.DataSource = CourseHelper.SearchCourse(searchTerm);
            btnClickState = 4; // SEARCH
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            txtSearch.Text = "";
        }

        private void dgvCourse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

            if (e.RowIndex >= 0)
            {
                string CourseDesc = dgvCourse.Rows[e.RowIndex].Cells["CourseDescription"].Value.ToString();
                    
                frmCourseDescription courseDescfrm = new frmCourseDescription(CourseDesc);
                courseDescfrm.Show();
               
            }

            

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnClickState != 4)
            {
                selectedRow = dgvCourse.Rows[e.RowIndex];

                if (selectedRow != null)
                {
                    btnEdit.Visible = true;
                }
            }
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnClickState == 4)
            {

            }
            panelSubInfo.Enabled = true;
            txtCrsCode.Focus();
            btnClickState = 2; // EDIT
            btnCreate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtCrsCode.Text = selectedRow.Cells["CourseCode"].Value.ToString();
            txtCuryear.Text = selectedRow.Cells["CurriculumYear"].Value.ToString();
            txtSubDesc.Text = selectedRow.Cells["CourseDescription"].Value.ToString();

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtCrsCode.Text) || string.IsNullOrEmpty(txtCuryear.Text) || string.IsNullOrEmpty(txtSubDesc.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GET SELECTED COURSE ID IF EDITING
            int courseID = 0;
            if (selectedRow != null && btnClickState == 2)
            {
                courseID = Convert.ToInt32(selectedRow.Cells["CourseID"].Value);
            }
            // CREATE COURSE OBJECT
            Course Course = new Course 
            { CourseCode = txtCrsCode.Text.Trim(), 
              CourseDescription = txtSubDesc.Text.Trim() 
            };

            // CHECK BUTTON CLICK STATE
            if (btnClickState == 1)
            {
                // CALL CREATE COURSE METHOD
                CourseHelper.CreateCourse(Course);
                Reset();

            }
            if (btnClickState == 2)
            {
                // ADD COURSE ID TO OBJECT
                if (courseID != 0) Course.CourseID = courseID;

                // CALL EDIT FACULTY METHOD
                CourseHelper.UpdateCourse(Course);
                Reset();
            }
            if(btnClickState == 3)
            {
                // ADD COURSE ID TO OBJECT
                if (courseIDFrmDesc != 0) Course.CourseID = courseIDFrmDesc;
                // CALL EDIT FACULTY METHOD
                CourseHelper.UpdateCourse(Course);
                Reset();
            }
            if (btnClickState == 4) { 
            
            }
        }

        private void dgvCourse_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
