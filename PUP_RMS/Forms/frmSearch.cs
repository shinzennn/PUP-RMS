using FontAwesome.Sharp;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmSearch : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["RMSDB"].ConnectionString;

        private bool isLoading = false;

        // Filter variables
        private string selectedSchoolYear = null;
        private int selectedSemester = 0;
        private int selectedProgram = 0;
        private int selectedYearLevel = 0;
        private int selectedCourse = 0;
        private int selectedProfessor = 0;

        public frmSearch()
        {
            InitializeComponent();

            // Ensure event handlers are wired
            this.btnSearch.Click += this.btnSearch_Click;
            this.btnClear.Click += this.btnClear_Click;

            this.cmbProgram.SelectedIndexChanged += this.cmbProgram_SelectedIndexChanged;
            this.cmbCourse.SelectedIndexChanged += this.cmbCourse_SelectedIndexChanged;
            this.cmbProfessor.SelectedIndexChanged += this.cmbProfessor_SelectedIndexChanged;
            this.cmbSemester.SelectedIndexChanged += this.cmbSemester_SelectedIndexChanged;
            this.cmbSchoolYear.SelectedIndexChanged += this.cmbSchoolYear_SelectedIndexChanged;
            this.cmbYearLevel.SelectedIndexChanged += this.cmbYearLevel_SelectedIndexChanged;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadPrograms();
            LoadCourses();
            LoadProfessors();
            LoadSchoolYears();
            LoadSemesters();
            LoadYearLevels();
            LoadAllGradeSheets();

            isLoading = false;
        }

        // =========================
        // LOAD ALL GRADESHEETS
        // =========================
        private void LoadAllGradeSheets()
        {
            dgvGradeSheets.DataSource =
                Core.DbControl.GetData("EXEC sp_GetAllGradeSheets");

            dgvGradeSheets.ClearSelection();
            dgvGradeSheets.CurrentCell = null;
        }

        // =========================
        // LOAD COMBOBOXES
        // =========================
        private void LoadPrograms()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ProgramID, ProgramCode FROM Program ORDER BY ProgramCode", con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                // Placeholder row
                DataRow placeholder = dt.NewRow();
                placeholder["ProgramID"] = 0;
                placeholder["ProgramCode"] = "Program";
                dt.Rows.InsertAt(placeholder, 0);

                cmbProgram.DataSource = dt;
                cmbProgram.DisplayMember = "ProgramCode";
                cmbProgram.ValueMember = "ProgramID";
                cmbProgram.SelectedIndex = 0;
            }
        }

        private void LoadCourses()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CourseID, CourseCode FROM Course ORDER BY CourseCode", con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                DataRow placeholder = dt.NewRow();
                placeholder["CourseID"] = 0;
                placeholder["CourseCode"] = "Course";
                dt.Rows.InsertAt(placeholder, 0);

                cmbCourse.DataSource = dt;
                cmbCourse.DisplayMember = "CourseCode";
                cmbCourse.ValueMember = "CourseID";
                cmbCourse.SelectedIndex = 0;
            }
        }

        private void LoadProfessors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT FacultyID, FirstName + ' ' + LastName AS FacultyName FROM Faculty ORDER BY LastName, FirstName", con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                DataRow placeholder = dt.NewRow();
                placeholder["FacultyID"] = 0;
                placeholder["FacultyName"] = "Professor";
                dt.Rows.InsertAt(placeholder, 0);

                cmbProfessor.DataSource = dt;
                cmbProfessor.DisplayMember = "FacultyName";
                cmbProfessor.ValueMember = "FacultyID";
                cmbProfessor.SelectedIndex = 0;
            }
        }

        private void LoadSchoolYears()
        {
            // Example: populate with distinct years from database
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT SchoolYear FROM GradeSheet ORDER BY SchoolYear DESC", con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                DataRow placeholder = dt.NewRow();
                placeholder["SchoolYear"] = "School Year";
                dt.Rows.InsertAt(placeholder, 0);

                cmbSchoolYear.DataSource = dt;
                cmbSchoolYear.DisplayMember = "SchoolYear";
                cmbSchoolYear.ValueMember = "SchoolYear";
                cmbSchoolYear.SelectedIndex = 0;
            }
        }

        private void LoadSemesters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(0, "Semester");   // placeholder
            dt.Rows.Add(1, "1st Semester");
            dt.Rows.Add(2, "2nd Semester");

            cmbSemester.DataSource = dt;
            cmbSemester.DisplayMember = "Name";
            cmbSemester.ValueMember = "ID";
            cmbSemester.SelectedIndex = 0;
        }

        private void LoadYearLevels()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(0, "Year Level");   // placeholder
            dt.Rows.Add(1, "1st Year");
            dt.Rows.Add(2, "2nd Year");
            dt.Rows.Add(3, "3rd Year");
            dt.Rows.Add(4, "4th Year");

            cmbYearLevel.DataSource = dt;
            cmbYearLevel.DisplayMember = "Name";
            cmbYearLevel.ValueMember = "ID";
            cmbYearLevel.SelectedIndex = 0;
        }

        // =========================
        // COMBOBOX SELECTION EVENTS
        // =========================
        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedSchoolYear = cmbSchoolYear.SelectedIndex > 0
                ? cmbSchoolYear.SelectedValue.ToString()
                : null;
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            selectedSemester = cmbSemester.SelectedValue != null
                ? Convert.ToInt32(cmbSemester.SelectedValue)
                : 0;
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            selectedYearLevel = cmbYearLevel.SelectedValue != null
                ? Convert.ToInt32(cmbYearLevel.SelectedValue)
                : 0;
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            selectedProgram = cmbProgram.SelectedValue != null
                ? Convert.ToInt32(cmbProgram.SelectedValue)
                : 0;
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            selectedCourse = cmbCourse.SelectedValue != null
                ? Convert.ToInt32(cmbCourse.SelectedValue)
                : 0;
        }

        private void cmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            selectedProfessor = cmbProfessor.SelectedValue != null
                ? Convert.ToInt32(cmbProfessor.SelectedValue)
                : 0;
        }

        // =========================
        // SEARCH BUTTON
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchGradeSheet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SchoolYear", SqlDbType.VarChar, 20)
                        .Value = string.IsNullOrEmpty(selectedSchoolYear) ? (object)DBNull.Value : selectedSchoolYear;
                    cmd.Parameters.Add("@Semester", SqlDbType.Int)
                        .Value = selectedSemester == 0 ? (object)DBNull.Value : selectedSemester;
                    cmd.Parameters.Add("@ProgramID", SqlDbType.Int)
                        .Value = selectedProgram == 0 ? (object)DBNull.Value : selectedProgram;
                    cmd.Parameters.Add("@YearLevel", SqlDbType.Int)
                        .Value = selectedYearLevel == 0 ? (object)DBNull.Value : selectedYearLevel;
                    cmd.Parameters.Add("@CourseID", SqlDbType.Int)
                        .Value = selectedCourse == 0 ? (object)DBNull.Value : selectedCourse;
                    cmd.Parameters.Add("@FacultyID", SqlDbType.Int)
                        .Value = selectedProfessor == 0 ? (object)DBNull.Value : selectedProfessor;

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                    dgvGradeSheets.DataSource = dt;
                    dgvGradeSheets.ClearSelection();
                    dgvGradeSheets.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // CLEAR BUTTON
        // =========================
        private void btnClear_Click(object sender, EventArgs e)
        {
            isLoading = true;

            // Reset all ComboBoxes to placeholder
            cmbSchoolYear.SelectedIndex = 0;
            cmbSemester.SelectedIndex = 0;
            cmbYearLevel.SelectedIndex = 0;
            cmbProgram.SelectedIndex = 0;
            cmbCourse.SelectedIndex = 0;
            cmbProfessor.SelectedIndex = 0;

            // Reset filter variables
            selectedSchoolYear = null;
            selectedSemester = 0;
            selectedYearLevel = 0;
            selectedProgram = 0;
            selectedCourse = 0;
            selectedProfessor = 0;

            LoadAllGradeSheets();
            isLoading = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvGradeSheets.CurrentRow == null) return;
            OpenGradeSheetDetailsFromGrid(dgvGradeSheets.CurrentRow.Index);
        }

        private void dgvGradeSheets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            OpenGradeSheetDetailsFromGrid(e.RowIndex);
        }

        private void OpenGradeSheetDetailsFromGrid(int rowIndex)
        {
            try
            {
                int gradeSheetID = 0;
                if (!int.TryParse(dgvGradeSheets.Rows[rowIndex].Cells["GradeSheetID"].Value.ToString(), out gradeSheetID))
                {
                    MessageBox.Show("Invalid GradeSheet selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (frmGradeSheetDetails frm = new frmGradeSheetDetails())
                {
                    frm.GradeSheetID = gradeSheetID;
                    frm.ShowDialog(); // modal
                    LoadAllGradeSheets(); // refresh grid after closing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open GradeSheet details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
