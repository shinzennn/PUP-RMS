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

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadPrograms();
            LoadCourses();
            LoadProfessors();
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
        // PROGRAM COMBOBOX
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

        // =========================
        // COURSE COMBOBOX
        // =========================
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

        // =========================
        // PROFESSOR (FACULTY) COMBOBOX
        // =========================
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

        string selectedSchoolYear = "";
        int selectedSemester = 0;
        int selectedProgram = 0;
        int selectedYearLevel = 0;
        int selectedCourse = 0;
        int selectedProfessor = 0;

        // =========================
        // OPTIONAL: SELECTION EVENTS
        // =========================
        // School Year: string
        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolYear.SelectedIndex > 0) // skip placeholder
                selectedSchoolYear = cmbSchoolYear.SelectedItem.ToString();
            else
                selectedSchoolYear = null;
        }

        // Semester: int
        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemester.SelectedIndex > 0) // skip placeholder
            {
                // If your ComboBox shows "1 - First Semester", take the first number
                string semString = cmbSemester.SelectedItem.ToString();
                if (int.TryParse(semString.Substring(0, 1), out int sem))
                    selectedSemester = sem;
                else
                    selectedSemester = 0;
            }
            else
                selectedSemester = 0;
        }

        // Program: int
        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && cmbProgram.SelectedValue != null)
                selectedProgram = Convert.ToInt32(cmbProgram.SelectedValue);
            else
                selectedProgram = 0;
        }

        // Year Level: int
        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYearLevel.SelectedIndex > 0)
                selectedYearLevel = Convert.ToInt32(cmbYearLevel.SelectedItem);
            else
                selectedYearLevel = 0;
        }

        // Course: int
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedIndex > 0 && cmbCourse.SelectedValue != null)
                selectedCourse = Convert.ToInt32(cmbCourse.SelectedValue);
            else
                selectedCourse = 0;
        }

        // Faculty/Professor: int
        private void cmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfessor.SelectedIndex > 0 && cmbProfessor.SelectedValue != null)
                selectedProfessor = Convert.ToInt32(cmbProfessor.SelectedValue);
            else
                selectedProfessor = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchGradeSheet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pass parameters, use DBNull.Value for unselected filters
                    cmd.Parameters.AddWithValue("@SchoolYear", string.IsNullOrEmpty(selectedSchoolYear) ? (object)DBNull.Value : selectedSchoolYear);
                    cmd.Parameters.AddWithValue("@Semester", selectedSemester == 0 ? (object)DBNull.Value : selectedSemester);
                    cmd.Parameters.AddWithValue("@ProgramID", selectedProgram == 0 ? (object)DBNull.Value : selectedProgram);
                    cmd.Parameters.AddWithValue("@YearLevel", selectedYearLevel == 0 ? (object)DBNull.Value : selectedYearLevel);
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourse == 0 ? (object)DBNull.Value : selectedCourse);
                    cmd.Parameters.AddWithValue("@FacultyID", selectedProfessor == 0 ? (object)DBNull.Value : selectedProfessor);

                    // Execute and load results
                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                    // Bind results to the DataGridView
                    dgvGradeSheets.DataSource = dt;

                    // Optional: clear selection
                    dgvGradeSheets.ClearSelection();
                    dgvGradeSheets.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
