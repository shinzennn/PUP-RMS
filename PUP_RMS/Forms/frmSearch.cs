using FontAwesome.Sharp;
using PUP_RMS.Core;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmSearch : Form
    {
        // =========================
        // FIELDS / VARIABLES
        // =========================
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["RMSDB"].ConnectionString;

        private bool isLoading = false;
        private bool isFormShown = false;

        // Selected values
        private string selectedSchoolYear = null;
        private string selectedCurriculumYear = null;

        private int selectedProgramID = 0;
        private int selectedYearLevel = 0;
        private int selectedSemester = 0;
        private int selectedSection = 0;
        private int selectedCourseID = 0;
        private int selectedFacultyID = 0;
        private int selectedCurriculumID = 0;

        // =========================
        // CONSTRUCTOR
        // =========================
        public frmSearch()
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
        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren)
                    ApplyDoubleBufferingRecursively(c.Controls);
            }
        }

        private static void SetDoubleBuffered(Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop?.SetValue(c, true, null);
        }

        // =========================
        // FORM EVENTS
        // =========================
        private void frmSearch_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadPrograms();       // Program is independent
            LoadSchoolYears();    // School Year is independent
            LoadYearLevels();     // Year Level is independent
            LoadSemesters();      // Semester is independent
            LoadSections();       // Section is independent

            // Load dependent combos as empty / placeholders
            cmbCurriculum.DataSource = null;
            cmbCourse.DataSource = null;
            cmbProfessor.DataSource = null;

            LoadAllGradeSheets(); // Populate the grid with all data initially

            isLoading = false;
        }

        public void loadData()
        {
            isLoading = true;

            LoadPrograms();       // Program is independent
            LoadSchoolYears();    // School Year is independent
            LoadYearLevels();     // Year Level is independent
            LoadSemesters();      // Semester is independent
            LoadSections();       // Section is independent

            // Load dependent combos as empty / placeholders
            cmbCurriculum.DataSource = null;
            cmbCourse.DataSource = null;
            cmbProfessor.DataSource = null;

            LoadAllGradeSheets(); // Populate the grid with all data initially

            isLoading = false;
        }

        private void frmSearch_Shown(object sender, EventArgs e)
        {
        }

        // =========================
        // DATAGRID EVENTS
        // =========================
        private void dgvGradeSheets_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dgvGradeSheets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the GradeSheetID directly from the row
            object val = dgvGradeSheets.Rows[e.RowIndex].Cells["GradeSheetID"].Value;
            if (val == null || val == DBNull.Value) return;

            int selectedGradeSheetID = Convert.ToInt32(val);

            using (var frm = new frmGradeSheetDetails())
            {
                frm.GradeSheetID = selectedGradeSheetID;
                frm.ShowDialog(this);
            }

            btnSearch.PerformClick();

        }


        private void dgvGradeSheets_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!isFormShown) return;

            if (e.RowIndex >= 0)
            {
                dgvGradeSheets.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dgvGradeSheets_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore events fired during initialization before the form is shown
            if (!isFormShown) return;

            if (e.RowIndex >= 0)
            {
                dgvGradeSheets.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
        }

        private void dgvGradeSheets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // =========================
        // LOAD COMBOBOX DATA
        // =========================
        private void LoadPrograms()
        {
            var dt = DbControl.GetData("SELECT ProgramID, ProgramCode FROM Program ORDER BY ProgramCode");
            DataRow placeholder = dt.NewRow();
            placeholder["ProgramID"] = 0;
            placeholder["ProgramCode"] = "";
            dt.Rows.InsertAt(placeholder, 0);

            cmbProgram.DataSource = dt;
            cmbProgram.DisplayMember = "ProgramCode";
            cmbProgram.ValueMember = "ProgramID";
            cmbProgram.SelectedIndex = 0;
        }

        private void LoadCurriculumYears(int programID)
        {
            //if (programID == 0)
            //{
            //    cmbCurriculum.DataSource = null;
            //    return;
            //}

            //string query = $"SELECT CurriculumID, CurriculumYear FROM Curriculum WHERE ProgramID = {programID} ORDER BY CurriculumYear DESC";
            //var dt = DbControl.GetData(query);

            //DataRow placeholder = dt.NewRow();
            //placeholder["CurriculumID"] = 0;
            //placeholder["CurriculumYear"] = "Select Curriculum";
            //dt.Rows.InsertAt(placeholder, 0);

            //cmbCurriculum.DataSource = dt;
            //cmbCurriculum.DisplayMember = "CurriculumYear";
            //cmbCurriculum.ValueMember = "CurriculumID";
            //cmbCurriculum.SelectedIndex = 0;

            using (SqlConnection con = new SqlConnection(DbControl.ConnString("RMSDB")))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT CurriculumYear FROM CurriculumHeader WHERE ProgramID = @ProgramID ORDER BY CurriculumYear DESC", con))
            {
                cmd.Parameters.AddWithValue("@ProgramID", programID);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                // Add placeholder
                DataRow placeholder = dt.NewRow();
                placeholder["CurriculumYear"] = "Curriculum";
                dt.Rows.InsertAt(placeholder, 0);

                // Use CurriculumYear (string) as the ValueMember so searches use the year string.
                cmbCurriculum.DataSource = dt;
                cmbCurriculum.DisplayMember = "CurriculumYear";
                cmbCurriculum.ValueMember = "CurriculumYear";
                cmbCurriculum.SelectedIndex = 0;
            }

        }

        private void LoadSchoolYears()
        {
            var dt = DbControl.GetData("SELECT DISTINCT SchoolYear FROM ClassSection ORDER BY SchoolYear DESC");

            DataRow placeholder = dt.NewRow();
            placeholder["SchoolYear"] = "";
            dt.Rows.InsertAt(placeholder, 0);

            cmbSchoolYear.DataSource = dt;
            cmbSchoolYear.DisplayMember = "SchoolYear";
            cmbSchoolYear.ValueMember = "SchoolYear";
            cmbSchoolYear.SelectedIndex = 0;
        }

        private void LoadYearLevels()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(0, "");
            dt.Rows.Add(1, "1st Year");
            dt.Rows.Add(2, "2nd Year");
            dt.Rows.Add(3, "3rd Year");
            dt.Rows.Add(4, "4th Year");
            dt.Rows.Add(5, "5th Year");

            cmbYearLevel.DataSource = dt;
            cmbYearLevel.DisplayMember = "Name";
            cmbYearLevel.ValueMember = "ID";
            cmbYearLevel.SelectedIndex = 0;
        }

        private void LoadSemesters()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(0, "");
            dt.Rows.Add(1, "1st Semester");
            dt.Rows.Add(2, "2nd Semester");
            dt.Rows.Add(3, "Summer");

            cmbSemester.DataSource = dt;
            cmbSemester.DisplayMember = "Name";
            cmbSemester.ValueMember = "ID";
            cmbSemester.SelectedIndex = 0;
        }

        private void LoadSections()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(0, "");
            dt.Rows.Add(1, "1");
            dt.Rows.Add(2, "2");
            dt.Rows.Add(3, "3");

            cmbSection.DataSource = dt;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
            cmbSection.SelectedIndex = 0;
        }

        private void LoadCourses(int curriculumID, int yearLevel, int section)
        {
            // Require curriculum and year level
            if (curriculumID == 0 || yearLevel == 0)
            {
                cmbCourse.DataSource = null;
                return;
            }

            // Use CurriculumCourse + Curriculum to find courses for the specified curriculum/year/semester
            try
            {
                using (SqlConnection con = new SqlConnection(DbControl.ConnString("RMSDB")))
                using (SqlCommand cmd = new SqlCommand(@"
                                        SELECT DISTINCT 
                                            co.CourseID, 
                                            co.CourseCode
                                        FROM Offering o
                                        JOIN Course co 
                                            ON o.CourseID = co.CourseID
                                        JOIN Curriculum cur 
                                            ON o.CurriculumID = cur.CurriculumID
                                        WHERE cur.CurriculumID = @CurriculumID
                                          AND cur.YearLevel = @YearLevel
                                          AND cur.Semester = @Semester
                                        ORDER BY co.CourseCode;", con))
                {
                    cmd.Parameters.AddWithValue("@CurriculumID", curriculumID);
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                    cmd.Parameters.AddWithValue("@Semester", selectedSemester);

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                    DataRow placeholder = dt.NewRow();
                    placeholder["CourseID"] = 0;
                    placeholder["CourseCode"] = "";
                    dt.Rows.InsertAt(placeholder, 0);

                    cmbCourse.DataSource = dt;
                    cmbCourse.DisplayMember = "CourseCode";
                    cmbCourse.ValueMember = "CourseID";
                    cmbCourse.SelectedIndex = 0;
                }
            }
            catch
            {
                cmbCourse.DataSource = null;
            }
        }

        private void LoadProfessorForCourse(int courseID)
        {
            if (courseID == 0)
            {
                cmbProfessor.DataSource = null;
                return;
            }

            // C#
            using (SqlConnection con = new SqlConnection(DbControl.ConnString("RMSDB")))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT DISTINCT f.FacultyID,
                    f.LastName + ', ' + f.FirstName +
                    ISNULL(' ' + LEFT(f.MiddleName, 1) + '.', '') AS Professor
                FROM GradeSheet gs
                INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
                WHERE gs.CourseID = @CourseID
                ORDER BY Professor", con))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                if (!dt.Columns.Contains("FacultyID") || !dt.Columns.Contains("Professor"))
                {
                    cmbProfessor.DataSource = null;
                    return;
                }

                DataRow placeholder = dt.NewRow();
                placeholder["FacultyID"] = 0;
                placeholder["Professor"] = "Select Professor";
                dt.Rows.InsertAt(placeholder, 0);

                cmbProfessor.DataSource = dt;
                cmbProfessor.DisplayMember = "Professor";
                cmbProfessor.ValueMember = "FacultyID";
                cmbProfessor.SelectedIndex = 0;
            }
        }

        // =========================
        // COMBOBOX EVENTS
        // =========================
        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            // store selected program id in the field for later lookups
            selectedProgramID = GetSafeComboInt(cmbProgram);

            // Reset curriculum selection state
            selectedCurriculumYear = null;
            selectedCurriculumID = 0;

            // Load dependent Curriculum based on Program
            LoadCurriculumYears(selectedProgramID);

            // Reset downstream combos
            cmbCourse.DataSource = null;
            cmbProfessor.DataSource = null;

            btnSearch.PerformClick();
        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (cmbCurriculum.SelectedIndex <= 0 || cmbCurriculum.SelectedValue == null)
            {
                selectedCurriculumYear = null;
                selectedCurriculumID = 0;
                cmbCourse.DataSource = null;
                cmbProfessor.DataSource = null;
                return;
            }

            // SelectedValue is CurriculumYear (string) per new behavior
            if (cmbCurriculum.SelectedValue is DataRowView drv)
            {
                // extract CurriculumYear column from the DataRowView if binding transient state occurs
                if (drv.DataView != null && drv.DataView.Table.Columns.Contains("CurriculumYear"))
                    selectedCurriculumYear = drv["CurriculumYear"]?.ToString();
                else
                    selectedCurriculumYear = drv.Row.ItemArray.Length > 0 ? drv.Row.ItemArray[0]?.ToString() : null;
            }
            else
            {
                selectedCurriculumYear = cmbCurriculum.SelectedValue.ToString();
            }

            // Resolve numeric CurriculumID for internal operations (LoadCourses)
            selectedCurriculumID = ResolveCurriculumID();

            // Clear downstream selections
            cmbCourse.DataSource = null;
            cmbProfessor.DataSource = null;

            // If we resolved an ID and year/section are chosen, attempt to load courses
            if (selectedCurriculumID > 0)
            {
                LoadCourses(selectedCurriculumID, selectedYearLevel, selectedSection);
            }

            // Trigger search
            btnSearch.PerformClick();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            // store selected year level
            selectedYearLevel = GetSafeComboInt(cmbYearLevel);

            // Refresh Courses whenever YearLevel changes
            cmbCurriculum_SelectedIndexChanged(sender, e);
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedSemester = GetSafeComboInt(cmbSemester);
            // Semester affects resolution and search
            cmbCurriculum_SelectedIndexChanged(sender, e);
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedSection = GetSafeComboInt(cmbSection);
            // Refresh Courses whenever Section changes
            cmbCurriculum_SelectedIndexChanged(sender, e);
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedCourseID = GetSafeComboInt(cmbCourse);
            LoadProfessorForCourse(selectedCourseID);

            btnSearch.PerformClick();
        }

        private void cmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedFacultyID = GetSafeComboInt(cmbProfessor);
            btnSearch.PerformClick();
        }

        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            selectedSchoolYear = cmbSchoolYear.SelectedIndex > 0 && cmbSchoolYear.SelectedValue != null
                ? cmbSchoolYear.SelectedValue.ToString()
                : null;

            btnSearch.PerformClick();
        }

        // =========================
        // SEARCH / CLEAR
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Prepare filters (use safe helpers to avoid DataRowView -> IConvertible cast issues)
                string schoolYear = null;
                if (cmbSchoolYear.SelectedIndex > 0 && cmbSchoolYear.SelectedValue != null)
                {
                    if (cmbSchoolYear.SelectedValue is DataRowView drvSy && drvSy.DataView.Table.Columns.Contains("SchoolYear"))
                        schoolYear = drvSy["SchoolYear"]?.ToString();
                    else
                        schoolYear = cmbSchoolYear.SelectedValue.ToString();
                }

                int semester = GetSafeComboInt(cmbSemester);
                int programID = GetSafeComboInt(cmbProgram);

                string curriculumYear = null;
                if (cmbCurriculum.SelectedIndex > 0 && cmbCurriculum.SelectedValue != null)
                {
                    if (cmbCurriculum.SelectedValue is DataRowView drvCy && drvCy.DataView.Table.Columns.Contains("CurriculumYear"))
                        curriculumYear = drvCy["CurriculumYear"]?.ToString();
                    else
                        curriculumYear = cmbCurriculum.SelectedValue.ToString();
                }

                int yearLevel = GetSafeComboInt(cmbYearLevel);
                int section = GetSafeComboInt(cmbSection);
                int courseID = GetSafeComboInt(cmbCourse);
                int facultyID = GetSafeComboInt(cmbProfessor);

                // Clear previous parameters
                DbControl.ClearParameters();

                // Add parameters for stored procedure
                DbControl.AddParameter("@SchoolYear", !string.IsNullOrEmpty(schoolYear) ? (object)schoolYear : DBNull.Value, SqlDbType.VarChar);
                DbControl.AddParameter("@Semester", semester != 0 ? (object)semester : DBNull.Value, SqlDbType.Int);
                DbControl.AddParameter("@ProgramID", programID != 0 ? (object)programID : DBNull.Value, SqlDbType.Int);
                DbControl.AddParameter("@CurriculumYear", !string.IsNullOrEmpty(curriculumYear) ? (object)curriculumYear : DBNull.Value, SqlDbType.VarChar);
                DbControl.AddParameter("@YearLevel", yearLevel != 0 ? (object)yearLevel : DBNull.Value, SqlDbType.Int);
                DbControl.AddParameter("@Section", section != 0 ? (object)section : DBNull.Value, SqlDbType.Int);
                DbControl.AddParameter("@CourseID", courseID != 0 ? (object)courseID : DBNull.Value, SqlDbType.Int);
                DbControl.AddParameter("@FacultyID", facultyID != 0 ? (object)facultyID : DBNull.Value, SqlDbType.Int);

                // Execute stored procedure
                DataTable dt = DbControl.ExecuteQuery("sp_SearchGradeSheets");

                // Bind to DataGridView
                dgvGradeSheets.DataSource = dt;

                // Optional: clear selection
                dgvGradeSheets.ClearSelection();
                dgvGradeSheets.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Prevent change handlers from firing while we reset controls
                isLoading = true;

                // Reset selected state fields
                selectedSchoolYear = null;
                selectedCurriculumYear = null;
                selectedProgramID = 0;
                selectedYearLevel = 0;
                selectedSemester = 0;
                selectedSection = 0;
                selectedCourseID = 0;
                selectedFacultyID = 0;
                selectedCurriculumID = 0;

                // Safely reset combobox selections (ignore if not populated)
                try { if (cmbProgram.Items.Count > 0) cmbProgram.SelectedIndex = 0; } catch { }
                try { if (cmbSchoolYear.Items.Count > 0) cmbSchoolYear.SelectedIndex = 0; } catch { }
                try { if (cmbYearLevel.Items.Count > 0) cmbYearLevel.SelectedIndex = 0; } catch { }
                try { if (cmbSemester.Items.Count > 0) cmbSemester.SelectedIndex = 0; } catch { }
                try { if (cmbSection.Items.Count > 0) cmbSection.SelectedIndex = 0; } catch { }

                // Clear dependent combo data to match initial load state
                cmbCurriculum.DataSource = null;
                cmbCourse.DataSource = null;
                cmbProfessor.DataSource = null;

                // Ensure any displayed selection text is cleared
                DeselectComboText(cmbProgram);
                DeselectComboText(cmbSchoolYear);
                DeselectComboText(cmbCurriculum);
                DeselectComboText(cmbYearLevel);
                DeselectComboText(cmbSemester);
                DeselectComboText(cmbSection);
                DeselectComboText(cmbCourse);
                DeselectComboText(cmbProfessor);

                // Reload full dataset into the grid (same behavior as initial load)
                LoadAllGradeSheets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvGradeSheets.CurrentRow == null) return;

            object val = dgvGradeSheets.CurrentRow.Cells["GradeSheetID"].Value;
            if (val == null || val == DBNull.Value) return;

            int selectedGradeSheetID = Convert.ToInt32(val);

            using (var frm = new frmGradeSheetDetails())
            {
                frm.GradeSheetID = selectedGradeSheetID;
                frm.ShowDialog(this);
            }

            btnSearch.PerformClick();

        }


        // =========================
        // GRADESHEET DATA
        // =========================
        private void LoadAllGradeSheets()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllGradeSheets", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                    dgvGradeSheets.AutoGenerateColumns = true;
                    dgvGradeSheets.DataSource = dt;

                    DataGridDesign();

                    dgvGradeSheets.ClearSelection();
                    dgvGradeSheets.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grade sheets: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchGradeSheets()
        {
        }

        private void RefreshGrid()
        {
        }

        private void OpenGradeSheetDetails(int gradeSheetID)
        {
        }

        // =========================
        // UI / HELPERS
        // =========================

        private void OpenSelectedGradeSheet()
        {
            if (dgvGradeSheets.CurrentRow == null)
            {
                MessageBox.Show("Please select a grade sheet first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object val = dgvGradeSheets.CurrentRow.Cells["GradeSheetID"].Value;
            if (val == null || val == DBNull.Value)
            {
                MessageBox.Show("Invalid grade sheet selection.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedGradeSheetID = Convert.ToInt32(val);

            using (var frm = new frmGradeSheetDetails())
            {
                frm.GradeSheetID = selectedGradeSheetID;
                frm.ShowDialog(this);
            }
        }

        private void OpenGradeSheetDetailsFromGrid(int rowIndex)
        {
            try
            {
                // Resolve the GradeSheetID column name robustly
                string idCol = FindColumnName("GradeSheetID");
                if (string.IsNullOrEmpty(idCol))
                {
                    MessageBox.Show("GradeSheetID column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cell = dgvGradeSheets.Rows[rowIndex].Cells[idCol].Value;
                if (cell == null || !int.TryParse(cell.ToString(), out int gradeSheetID))
                {
                    MessageBox.Show("Invalid GradeSheet selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (frmGradeSheetDetails frm = new frmGradeSheetDetails())
                {
                    frm.GradeSheetID = gradeSheetID;
                    frm.ShowDialog(this); // show modal with the current form as owner
                }

                // Refresh grid according to current filters (use existing search path)
                RefreshGridUsingCurrentFilters();

                // Re-select the same grade sheet row after refresh
                for (int i = 0; i < dgvGradeSheets.Rows.Count; i++)
                {
                    var val = dgvGradeSheets.Rows[i].Cells[idCol].Value;
                    if (val != null && int.TryParse(val.ToString(), out int id) && id == gradeSheetID)
                    {
                        dgvGradeSheets.ClearSelection();
                        dgvGradeSheets.Rows[i].Selected = true;

                        string filenameCol = FindColumnName("Filename");
                        if (!string.IsNullOrEmpty(filenameCol))
                        {
                            dgvGradeSheets.CurrentCell = dgvGradeSheets.Rows[i].Cells[filenameCol];
                            dgvGradeSheets.FirstDisplayedScrollingRowIndex = Math.Max(0, i - 2);
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open GradeSheet details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGridUsingCurrentFilters()
        {
            // Re-run the current search to refresh the grid while preserving filters.
            // Using PerformClick ensures the same code path that binds the grid is executed.
            try
            {
                btnSearch.PerformClick();
            }
            catch
            {
                // swallow - refresh is best-effort
            }
        }

        private void DataGridDesign()
        {
            if (dgvGradeSheets.Columns.Count == 0) return;

            // Hide any internal/unneeded columns
            if (dgvGradeSheets.Columns["GradeSheetID"] != null)
                dgvGradeSheets.Columns["GradeSheetID"].Visible = false;

            // (In this SP we no longer have GradeSheetID/Filepath, so no need to hide them)

            // Set widths for better readability
            SafeSetColumnWidth("Filename", 220);
            SafeSetColumnWidth("SchoolYear", 80);
            SafeSetColumnWidth("Program", 80);
            SafeSetColumnWidth("Curriculum", 80);
            SafeSetColumnWidth("Section", 50);
            SafeSetColumnWidth("Semester", 60);
            SafeSetColumnWidth("YearLevel", 50);
            SafeSetColumnWidth("Course", 100);
            SafeSetColumnWidth("Professor", 150);
            SafeSetColumnWidth("PageNumber", 60);

            // Set user-friendly headers
            SafeSetHeaderText("Filename", "File Name");
            SafeSetHeaderText("SchoolYear", "School Year");
            SafeSetHeaderText("Program", "Program");
            SafeSetHeaderText("Curriculum", "Curriculum");
            SafeSetHeaderText("Section", "Section");
            SafeSetHeaderText("Semester", "Semester");
            SafeSetHeaderText("YearLevel", "Year Level");
            SafeSetHeaderText("Course", "Course");
            SafeSetHeaderText("Professor", "Professor");
            SafeSetHeaderText("PageNumber", "Page No.");

            // Optional: full row select and alternating row color for better readability
            dgvGradeSheets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGradeSheets.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private string FindColumnName(params string[] candidates)
        {
            if (dgvGradeSheets?.Columns == null) return null;
            foreach (DataGridViewColumn col in dgvGradeSheets.Columns)
            {
                foreach (var cand in candidates)
                {
                    if (string.Equals(col.Name, cand, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(col.HeaderText, cand, StringComparison.OrdinalIgnoreCase))
                    {
                        return col.Name;
                    }
                }
            }
            return null;
        }

        private void SafeSetColumnWidth(string nameCandidate, int width)
        {
            string found = FindColumnName(nameCandidate);
            if (!string.IsNullOrEmpty(found))
                dgvGradeSheets.Columns[found].Width = width;
        }

        private void SafeSetHeaderText(string nameCandidate, string header)
        {
            string found = FindColumnName(nameCandidate);
            if (!string.IsNullOrEmpty(found))
                dgvGradeSheets.Columns[found].HeaderText = header;
        }


        private void DeselectComboText(ComboBox cmb)
        {
            try
            {
                if (cmb == null) return;
                cmb.SelectionStart = 0;
                cmb.SelectionLength = 0;
            }
            catch { /* ignore if control not ready */ }
        }

        private int ResolveCurriculumID()
        {
            // Need ProgramID and selectedCurriculumYear to resolve
            if (selectedProgramID == 0 || string.IsNullOrEmpty(selectedCurriculumYear))
                return 0;

            try
            {
                using (SqlConnection con = new SqlConnection(DbControl.ConnString("RMSDB")))
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 CurriculumID
                    FROM Curriculum
                    WHERE ProgramID = @ProgramID
                      AND CurriculumYear = @CurriculumYear
                      AND (@YearLevel = 0 OR YearLevel = @YearLevel)
                      AND (@Semester = 0 OR Semester = @Semester)", con))
                {
                    cmd.Parameters.AddWithValue("@ProgramID", selectedProgramID);
                    cmd.Parameters.AddWithValue("@CurriculumYear", selectedCurriculumYear);
                    cmd.Parameters.AddWithValue("@YearLevel", selectedYearLevel);
                    cmd.Parameters.AddWithValue("@Semester", selectedSemester);

                    con.Open();
                    object val = cmd.ExecuteScalar();
                    if (val != null && val != DBNull.Value)
                        return Convert.ToInt32(val);
                }
            }
            catch
            {
                // swallow and return 0
            }

            return 0;
        }

        private int GetSafeComboInt(ComboBox cmb)
        {
            if (cmb == null) return 0;
            if (cmb.SelectedValue == null) return 0;

            // If SelectedValue is a DataRowView (binding transient state) try to extract ValueMember
            if (cmb.SelectedValue is DataRowView drv)
            {
                try
                {
                    if (!string.IsNullOrEmpty(cmb.ValueMember) && drv.DataView.Table.Columns.Contains(cmb.ValueMember))
                    {
                        var v = drv[cmb.ValueMember];
                        if (v != null && v != DBNull.Value) return Convert.ToInt32(v);
                    }

                    // fallback: find first int column
                    foreach (DataColumn col in drv.DataView.Table.Columns)
                    {
                        if (col.DataType == typeof(int))
                        {
                            var vv = drv[col.ColumnName];
                            if (vv != null && vv != DBNull.Value) return Convert.ToInt32(vv);
                        }
                    }
                }
                catch { return 0; }
            }

            try
            {
                return Convert.ToInt32(cmb.SelectedValue);
            }
            catch { return 0; }
        }
    }
}
//private void dgvGradeSheets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//{
//    if (e.RowIndex < 0) return;
//    OpenGradeSheetDetailsFromGrid(e.RowIndex);
//}

//private void btnView_Click(object sender, EventArgs e)
//{
//    if (dgvGradeSheets.CurrentRow == null) return;
//    OpenGradeSheetDetailsFromGrid(dgvGradeSheets.CurrentRow.Index);
//}

//private void OpenGradeSheetDetailsFromGrid(int rowIndex)
//{
//    try
//    {
//        // Resolve the GradeSheetID column name robustly
//        string idCol = FindColumnName("GradeSheetID");
//        if (string.IsNullOrEmpty(idCol))
//        {
//            MessageBox.Show("GradeSheetID column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            return;
//        }

//        var cell = dgvGradeSheets.Rows[rowIndex].Cells[idCol].Value;
//        if (cell == null || !int.TryParse(cell.ToString(), out int gradeSheetID))
//        {
//            MessageBox.Show("Invalid GradeSheet selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            return;
//        }

//        using (frmGradeSheetDetails frm = new frmGradeSheetDetails())
//        {
//            frm.GradeSheetID = gradeSheetID;
//            frm.ShowDialog(this); // show modal with the current form as owner
//        }

//        // Refresh grid according to current filters (use existing search path)
//        RefreshGridUsingCurrentFilters();

//        // Re-select the same grade sheet row after refresh
//        for (int i = 0; i < dgvGradeSheets.Rows.Count; i++)
//        {
//            var val = dgvGradeSheets.Rows[i].Cells[idCol].Value;
//            if (val != null && int.TryParse(val.ToString(), out int id) && id == gradeSheetID)
//            {
//                dgvGradeSheets.ClearSelection();
//                dgvGradeSheets.Rows[i].Selected = true;

//                string filenameCol = FindColumnName("Filename");
//                if (!string.IsNullOrEmpty(filenameCol))
//                {
//                    dgvGradeSheets.CurrentCell = dgvGradeSheets.Rows[i].Cells[filenameCol];
//                    dgvGradeSheets.FirstDisplayedScrollingRowIndex = Math.Max(0, i - 2);
//                }

//                break;
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Failed to open GradeSheet details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}

//private void RefreshGridUsingCurrentFilters()
//{
//    // Re-run the current search to refresh the grid while preserving filters.
//    // Using PerformClick ensures the same code path that binds the grid is executed.
//    try
//    {
//        btnSearch.PerformClick();
//    }
//    catch
//    {
//        // swallow - refresh is best-effort
//    }
//}
