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
        public frmCourse(string courseCode = null, string courseDesc = null, int courseID = 0)
        {
            // Anti-flicker settings
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            ApplyDoubleBufferingRecursively(this.Controls);

            // Start hidden (important for child forms)
            this.Visible = false;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000;  // WS_CLIPCHILDREN
                return cp;
            }
        }

        private void ApplyDoubleBufferingRecursively(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (System.Windows.Forms.Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren)
                    ApplyDoubleBufferingRecursively(c.Controls);
            }
        }

        private static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo prop = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop?.SetValue(c, true, null);
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
            txtSubDesc.Text = courseDesc;

            panelSubInfo.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
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

            cbxCurriculum.DisplayMember = "CurriculumYear";
            cbxCurriculum.ValueMember = "CurriculumID";
            cbxCurriculum.DataSource = CourseHelper.GetAllCurriculum();
            cbxCurriculum.SelectedIndex = -1;


            cbxProgram.DisplayMember = "ProgramCode";
            cbxProgram.ValueMember = "ProgramID";
            cbxProgram.DataSource = CourseHelper.GetProgramByCurriculum();
            cbxProgram.SelectedIndex = -1;



            dgvCourse.DataSource = CourseHelper.GetAllCourse();
            dgvCourse.ClearSelection();
            dgvCourse.CurrentCell = null;
            dgvCourse.Columns["CourseID"].Visible = false;
            dgvCourse.Columns["CourseCode"].Visible = false;
        }

        private void Reset()
        {
            txtCrsCode.Text = "";
            txtSubDesc.Text = "";
            panelSubInfo.Enabled = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = false;
            RefreshGrid();
        }

       

        private void btnCreate_Click(object sender, EventArgs e)
        {
            panelSubInfo.Enabled = true;
            txtCrsCode.Focus();
            btnClickState = 1; // CREATE
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnEdit.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                return;
            }

            string searchTerm = txtSearch.Text.Trim();
            string curriculum = string.IsNullOrWhiteSpace(cbxCurriculum.Text) ? null : cbxCurriculum.Text;

            // Safely obtain programID
            int? programID = null;
            var sel = cbxProgram.SelectedValue;
            if (sel != null && sel != DBNull.Value)
            {
                if (sel is DataRowView)
                {
                    var drv = cbxProgram.SelectedItem as DataRowView;
                    programID = drv?.Row.Field<int?>("ProgramID");
                }
                else
                {
                    // Covers boxed numeric types (int, long, short, etc.)
                    programID = Convert.ToInt32(sel);
                }
            }

            // EXECUTE QUERY
            dgvCourse.DataSource = CourseHelper.SearchCourse(searchTerm, curriculum, programID);
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
          
                selectedRow = dgvCourse.Rows[e.RowIndex];

                if (selectedRow != null)
                {
                    btnEdit.Visible = true;
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
            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtCrsCode.Text = selectedRow.Cells["CourseCode"].Value.ToString();
            txtSubDesc.Text = selectedRow.Cells["CourseDescription"].Value.ToString();

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtCrsCode.Text) || string.IsNullOrEmpty(txtSubDesc.Text))
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

   

     

        private void cbxCurriculum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvCourse.DataSource = CourseHelper.GetCourseByCurriculumYear(cbxCurriculum.Text);
            dgvCourse.Columns["CourseID"].Visible = false;
            dgvCourse.Columns["CourseCode"].Visible = false;
            dgvCourse.Columns["CurriculumID"].Visible = false;
            dgvCourse.Columns["CurriculumYear"].Visible = false;
            dgvCourse.Columns["ProgramID"].Visible = false;
            dgvCourse.Columns["YearLevel"].Visible = false;
            dgvCourse.Columns["Semester"].Visible = false;


            cbxProgram.DataSource = CourseHelper.GetProgramByCurriculum(cbxCurriculum.Text);
            cbxProgram.DisplayMember = "ProgramCode";
            cbxProgram.ValueMember = "ProgramID";
            cbxProgram.SelectedIndex = -1;
        }

        private void cbxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drv = cbxProgram.SelectedItem as DataRowView;
            if (drv == null) return;

            // safe and handles DBNull if you use nullable:
            int? programID = drv.Row.Field<int?>("ProgramID");
            if (!programID.HasValue) return;

            dgvCourse.DataSource = CourseHelper.GetAllCourseByProgram(programID.Value);
            dgvCourse.Columns["CourseID"].Visible = false;
            dgvCourse.Columns["CourseCode"].Visible = false;
            dgvCourse.Columns["CurriculumID"].Visible = false;
            dgvCourse.Columns["CurriculumYear"].Visible = false;
            dgvCourse.Columns["YearLevel"].Visible = false;
            dgvCourse.Columns["Semester"].Visible = false;
        }

        private void cbxProgram_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
          
        }
    }
}
