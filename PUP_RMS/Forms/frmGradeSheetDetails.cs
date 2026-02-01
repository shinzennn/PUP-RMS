//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Windows.Forms;

//csharp PUP_RMS\Forms\frmGradeSheetDetails.cs
using PUP_RMS.Core;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmGradeSheetDetails : Form
    {
        private readonly string connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["RMSDB"].ConnectionString;

        private readonly string baseImagePath = Path.Combine(Application.StartupPath, "GradeSheets");

        public int GradeSheetID { get; set; }

        private string currentFilePath = "";
        private bool imageChanged = false;
        private string stagedImagePath = null;   // temp selection
        private string originalImagePath = null; // original saved image
        private bool isEditMode = false;

        private bool isLoading = false;

        private int selectedProgramID = 0;
        private string selectedCurriculumYear = null;
        private int selectedCurriculumID = 0;
        private int selectedYearLevel = 0;
        private int selectedSemester = 0;
        private int selectedCourseID = 0;



        public frmGradeSheetDetails()
        {
            InitializeComponent();




        }

        private void frmGradeSheetDetails_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPrograms();
                LoadCourses();
                LoadProfessors();
                LoadYearLevels();
                LoadSemesters();
                LoadSchoolYears();
                LoadSections();
                LoadCurriculum();

                LoadGradeSheetData();
                DisableEditMode();

                if (MainDashboard.CurrentAccount?.AccountType != "Admin")
                {
                    btnEdit.Visible = false;   // hide the Edit button
                    btnUpload.Visible = false; // optionally hide upload button too
                }
                else
                {
                    btnEdit.Visible = true;
                    btnUpload.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================= LOAD / BIND =========================

        private void LoadGradeSheetData()
        {
            //using (var con = new SqlConnection(connectionString))
            //using (var cmd = new SqlCommand(@"
            //    SELECT 
            //      gs.GradeSheetID,
            //      gs.ProgramID,
            //      gs.CourseID,
            //      gs.FacultyID,
            //      gs.YearLevel,
            //      gs.Semester,
            //      gs.SchoolYear,
            //      gs.PageNumber,
            //      gs.Filename,
            //      gs.Filepath,
            //      a.LastName + ', ' + a.FirstName AS UploadedBy
            //    FROM GradeSheet gs
            //    LEFT JOIN Account a ON gs.AccountID = a.AccountID
            //    WHERE gs.GradeSheetID = @GradeSheetID", con))
            //{
            //    cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
            //    con.Open();
            //    using (var dr = cmd.ExecuteReader())
            //    {
            //        if (!dr.Read()) return;

            //        SafeSetComboSelectedValue(cmbProgram, dr["ProgramID"]);
            //        SafeSetComboSelectedValue(cmbCourse, dr["CourseID"]);
            //        SafeSetComboSelectedValue(cmbProfessor, dr["FacultyID"]);
            //        SafeSetComboSelectedValue(cmbYearLevel, dr["YearLevel"]);
            //        SafeSetComboSelectedValue(cmbSemester, dr["Semester"]);
            //        SafeSetComboSelectedValue(cmbSchoolYear, dr["SchoolYear"]);

            //        txtPageNumber.Text = dr["PageNumber"]?.ToString() ?? "";
            //        txtFilename.Text = dr["Filename"]?.ToString() ?? "";
            //        txtUploader.Text = dr["UploadedBy"]?.ToString() ?? "";

            //        originalImagePath = Path.Combine(
            //            dr["Filepath"]?.ToString() ?? baseImagePath,
            //            dr["Filename"]?.ToString() ?? ""
            //        );

            //        currentFilePath = originalImagePath;
            //        LoadThumbnail(originalImagePath);
            //    }
            //}

            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT 
                    GS.GradeSheetID,
                    P.ProgramID,
                    O.CourseID, 
                    F.FacultyID,
                    C.YearLevel,
                    C.Semester,
                    CS.SchoolYear,
                    GS.PageNumber,
                    GS.Filename,
                    GS.Filepath,
                    A.LastName + ', ' + A.FirstName AS UploadedBy
                FROM GradeSheet GS
                INNER JOIN ClassSection CS ON GS.SectionID = CS.SectionID
                INNER JOIN Faculty F ON CS.FacultyID = F.FacultyID
                INNER JOIN Offering O ON CS.OfferingID = O.OfferingID
                INNER JOIN Course Co ON O.CourseID = Co.CourseID
                INNER JOIN Curriculum C ON O.CurriculumID = C.CurriculumID
                INNER JOIN CurriculumHeader CH ON C.CurriculumHeaderID = CH.CurriculumHeaderID
                INNER JOIN Program P ON CH.ProgramID = P.ProgramID
                INNER JOIN Account A ON GS.AccountID = A.AccountID
                WHERE GS.GradeSheetID = @GradeSheetID;
            ", con))
            {
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                con.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return;

                    SafeSetComboSelectedValue(cmbProgram, dr["ProgramID"]);
                    SafeSetComboSelectedValue(cmbCourse, dr["CourseID"]);
                    SafeSetComboSelectedValue(cmbProfessor, dr["FacultyID"]);
                    SafeSetComboSelectedValue(cmbYearLevel, dr["YearLevel"]);
                    SafeSetComboSelectedValue(cmbSemester, dr["Semester"]);
                    SafeSetComboSelectedValue(cmbSchoolYear, dr["SchoolYear"]);

                    txtPageNumber.Text = dr["PageNumber"]?.ToString();
                    txtFilename.Text = dr["Filename"]?.ToString();
                    txtUploader.Text = dr["UploadedBy"]?.ToString();

                    originalImagePath = Path.Combine(
                        dr["Filepath"]?.ToString() ?? baseImagePath,
                        dr["Filename"]?.ToString() ?? ""
                    );

                    currentFilePath = originalImagePath;
                    LoadThumbnail(originalImagePath);
                }
            }
        }

        //private void LoadThumbnail(string filePath)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        //        {
        //            pbPreview.Image?.Dispose();
        //            pbPreview.Image = null;
        //            return;
        //        }

        //        // Dispose previous image then load a fresh stream copy
        //        pbPreview.Image?.Dispose();
        //        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            pbPreview.Image = Image.FromStream(fs);
        //        }
        //    }
        //    catch
        //    {
        //        pbPreview.Image = null;
        //    }
        //}

        private void LoadThumbnail(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    pbPreview.Image?.Dispose();
                    pbPreview.Image = null;
                    return;
                }

                // Dispose previous image then load a fresh stream copy
                pbPreview.Image?.Dispose();
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var img = Image.FromStream(fs);
                    pbPreview.Image = img;
                    pbPreview.Size = img.Size; // Important: keep full image size
                }
            }
            catch
            {
                pbPreview.Image = null;
            }
        }


        // ========================= IMAGE UPLOAD / SAVE =========================

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            // Allow selecting a replacement image (preview only)
            btnEdit.Enabled = false;
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                stagedImagePath = ofd.FileName;
                LoadThumbnail(stagedImagePath);
                imageChanged = true;

                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Commit staged image to disk and update DB Filename/Filepath
            if (!imageChanged || string.IsNullOrEmpty(stagedImagePath))
            {
                MessageBox.Show("No image selected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string fileName = GenerateFileName();
                string targetFolder = BuildImageFolderPath();
                Directory.CreateDirectory(targetFolder);
                string finalPath = Path.Combine(targetFolder, fileName);

                // Copy staged file to final destination (overwrite allowed)
                File.Copy(stagedImagePath, finalPath, true);

                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(@"UPDATE GradeSheet SET Filename=@Filename, Filepath=@Filepath WHERE GradeSheetID=@GradeSheetID", con))
                {
                    cmd.Parameters.AddWithValue("@Filename", fileName);
                    cmd.Parameters.AddWithValue("@Filepath", targetFolder);
                    cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Update local state
                originalImagePath = finalPath;
                currentFilePath = finalPath;
                stagedImagePath = null;
                imageChanged = false;

                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnEdit.Enabled = true;

                MessageBox.Show("Image saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadThumbnail(originalImagePath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            stagedImagePath = null;
            imageChanged = false;
            LoadThumbnail(originalImagePath);
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Enabled = true;
        }

        // ========================= EDIT MODE =========================

        private void roundedButton1_Click(object sender, EventArgs e) => EnableEditMode();

        private void btnSaves_Click(object sender, EventArgs e)
        {
            try
            {
                // ===================== VALIDATION =====================
                if (cmbProgram.SelectedValue == null ||
                    cmbYearLevel.SelectedValue == null ||
                    cmbSemester.SelectedValue == null)
                {
                    MessageBox.Show("Program, Year Level, and Semester are required.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int pageNum = 0;
                int.TryParse(txtPageNumber.Text, out pageNum);
                int offeringID = GetOfferingID();
                string newFileName = GenerateFileName();
                string newTargetFolder = BuildImageFolderPath();
                Directory.CreateDirectory(newTargetFolder); // ensure folder exists
                string newFullFilePath = Path.Combine(newTargetFolder, newFileName);

                // ===================== FILE MOVE / RENAME =====================
                string origFullPath = Path.GetFullPath(originalImagePath ?? "");
                string newFullPath = Path.GetFullPath(newFullFilePath);

                if (!string.Equals(origFullPath, newFullPath, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(originalImagePath) && File.Exists(originalImagePath))
                    {
                        // Release image lock
                        pbPreview.Image?.Dispose();
                        pbPreview.Image = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        // If new file already exists, delete it
                        if (File.Exists(newFullPath))
                            File.Delete(newFullPath);

                        // Move original file to new location
                        File.Move(origFullPath, newFullPath);

                        // Update paths
                        originalImagePath = newFullPath;
                        currentFilePath = newFullPath;
                    }
                    else
                    {
                        // Original file does not exist; fallback to using staged image if available
                        if (!string.IsNullOrEmpty(stagedImagePath) && File.Exists(stagedImagePath))
                        {
                            File.Copy(stagedImagePath, newFullPath, true);
                            originalImagePath = newFullPath;
                            currentFilePath = newFullPath;
                            stagedImagePath = null;
                            imageChanged = false;
                        }
                        else
                        {
                            MessageBox.Show($"Original file not found: {origFullPath}", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // ===================== DATABASE UPDATE =====================
                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("sp_UpdateGradeSheets", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradeSheetID", SqlDbType.Int).Value = GradeSheetID;
                    cmd.Parameters.Add("@Filename", SqlDbType.VarChar, 255).Value = newFileName;
                    cmd.Parameters.Add("@Filepath", SqlDbType.VarChar, 500).Value = newTargetFolder;
                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = offeringID;
                    cmd.Parameters.Add("@PageNumber", SqlDbType.Int).Value = pageNum;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // ===================== UI UPDATE =====================
                txtFilename.Text = newFileName;
                LoadThumbnail(originalImagePath);
                DisableEditMode();

                MessageBox.Show("Grade sheet updated successfully.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadGradeSheetData();
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("File access error: " + ioEx.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadThumbnail(originalImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadGradeSheetData();
            }
        }

        private int GetOfferingID()
        {
            int offeringID = 0;

            string sql = "SELECT \r\n    cs.SectionID\r\nFROM ClassSection cs\r\nINNER JOIN Faculty f ON cs.FacultyID = f.FacultyID\r\nINNER JOIN Offering o ON cs.OfferingID = o.OfferingID\r\nINNER JOIN Course c ON o.CourseID = c.CourseID\r\nINNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID\r\nINNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID\r\nINNER JOIN Program p ON ch.ProgramID = p.ProgramID\r\nWHERE p.ProgramCode = @ProgramCode\r\n  AND ch.CurriculumYear = @CurriculumYear\r\n  AND cur.YearLevel = @YearLevel\r\n  AND cur.Semester = @Semester\r\n  AND cs.SchoolYear = @SchoolYear\r\n  AND f.FacultyID = @FacultyID";

            DbControl.AddParameter("@ProgramCode", cmbProgram.Text, SqlDbType.VarChar);
            DbControl.AddParameter("@CurriculumYear", cmbCurriculum.Text, SqlDbType.VarChar);
            DbControl.AddParameter("@YearLevel", cmbYearLevel.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@Semester", cmbSemester.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@SchoolYear", cmbSchoolYear.Text, SqlDbType.VarChar);
            DbControl.AddParameter("@FacultyID", cmbProfessor.SelectedValue, SqlDbType.Int);

            DataTable dt = DbControl.GetData(sql);
            if(dt != null)
            {
                offeringID = Convert.ToInt32(dt.Rows[0]["SectionID"]);
            }

            return offeringID;
        }

        private void btnCancels_Click(object sender, EventArgs e)
        {
            LoadGradeSheetData();
            DisableEditMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableEditMode();
        }

        private void EnableEditMode()
        {
            if (MainDashboard.CurrentAccount?.AccountType != "Admin")
                return; // block non-admins

            isEditMode = true;

            txtPageNumber.ReadOnly = false;
            cmbSchoolYear.Enabled = true;
            cmbSemester.Enabled = true;
            cmbProgram.Enabled = true;
            cmbYearLevel.Enabled = true;
            cmbCourse.Enabled = true;
            cmbProfessor.Enabled = true;
            cmbCurriculum.Enabled = true;
            cmbSection.Enabled = true;

            btnSaves.Visible = true;
            btnCancels.Visible = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
            btnUpload.Enabled = false;
        }

        private void DisableEditMode()
        {
            isEditMode = false;

            txtPageNumber.ReadOnly = true;
            cmbSchoolYear.Enabled = false;
            cmbSemester.Enabled = false;
            cmbProgram.Enabled = false;
            cmbYearLevel.Enabled = false;
            cmbCourse.Enabled = false;
            cmbProfessor.Enabled = false;
            cmbCurriculum.Enabled = false;
            cmbSection.Enabled = true;

            btnSaves.Visible = false;
            btnCancels.Visible = false;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
            btnUpload.Enabled = true;
        }

        // ========================= HELPERS =========================

        private string GenerateFileName()
        {
            string rawSchoolYear = GetComboSelectedValueString(cmbSchoolYear) ?? cmbSchoolYear.Text;
            string acadYear = FormatAcademicYear(rawSchoolYear);

            int semVal = GetComboSelectedValueInt(cmbSemester);
            string sem = semVal == 1 ? "A" : (semVal == 2 ? "B" : "C");

            string program = SanitizeForFilename(GetComboSelectedText(cmbProgram) ?? "PRG");

            string yearLevel = GetComboSelectedValueString(cmbYearLevel) ?? "0";

            // ===== Add section here =====
            string section = GetComboSelectedValueString(cmbSection) ?? cmbSection.Text ?? "0";

            string rawCourse = GetComboSelectedText(cmbCourse);
            string course = FormatCourseCode(rawCourse);

            string faculty = GetFacultyInitials();

            string page = string.IsNullOrWhiteSpace(txtPageNumber.Text) ? "0" : txtPageNumber.Text.Trim();

            // Insert section after yearLevel
            return $"PUPLQ_GRSH_{acadYear}_{sem}_{program}_{yearLevel}_{section}_{course}_{faculty}_P{page}.jpg";
        }

        private string FormatAcademicYear(string schoolYear)
        {
            if (string.IsNullOrWhiteSpace(schoolYear))
                return "XXXX";

            // Expected format: YYYY-YYYY
            string[] parts = schoolYear.Split('-');

            if (parts.Length != 2)
                return SanitizeForFilename(schoolYear);

            string start = parts[0].Trim();
            string end = parts[1].Trim();

            if (start.Length < 4 || end.Length < 4)
                return SanitizeForFilename(schoolYear);

            return start.Substring(start.Length - 2) + end.Substring(end.Length - 2);
        }

        private string FormatCourseCode(string course)
        {
            if (string.IsNullOrWhiteSpace(course))
                return "COURSE";

            // Remove spaces only
            return course.Replace(" ", "");
        }


        private string GetFacultyInitials()
        {
            try
            {
                string fullName = cmbProfessor.Text;
                if (string.IsNullOrWhiteSpace(fullName))
                    return "NA";

                // Expected format: LastName, FirstName M.
                string[] nameParts = fullName.Split(',');

                if (nameParts.Length < 2)
                    return fullName.Replace(" ", "").ToUpper();

                // ----- SURNAME -----
                string surname = nameParts[0]
                    .Replace(" ", "")
                    .ToUpper();

                // ----- GIVEN NAMES -----
                string givenNames = nameParts[1]
                    .Replace(".", "")
                    .Trim();

                string[] givenParts = givenNames
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string initials = "";
                foreach (string part in givenParts)
                {
                    initials += part[0];
                }

                return surname + initials.ToUpper();
            }
            catch
            {
                return "NA";
            }
        }



        private string BuildImageFolderPath()
        {
            // Start with base folder
            string baseFolder = baseImagePath;

            // Use the existing original path as base if available
            if (!string.IsNullOrEmpty(originalImagePath))
            {
                baseFolder = Path.GetDirectoryName(originalImagePath) ?? baseImagePath;
            }

            // Only rebuild subfolders if in edit mode
            if (isEditMode)
            {
                // Use displayed text from combo boxes to preserve the readable names
                string schoolYear = SanitizePath(cmbSchoolYear.Text ?? "UnknownSchoolYear");
                string semester = SanitizePath(cmbSemester.Text ?? "UnknownSemester");
                string program = SanitizePath(cmbProgram.Text ?? "UnknownProgram");
                string yearLevel = SanitizePath(cmbYearLevel.Text ?? "UnknownYearLevel");
                string section = SanitizePath(cmbSection.Text ?? "UnknownSection");
                string course = SanitizePath(cmbCourse.Text ?? "UnknownCourse");
                string professor = SanitizePath(cmbProfessor.Text ?? "UnknownProfessor"); // full name with middle initial

                baseFolder = Path.Combine(baseImagePath, schoolYear, semester, program, yearLevel, section, course, professor);
            }

            return baseFolder;
        }





        private string SanitizePath(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Unknown";
            foreach (char c in Path.GetInvalidFileNameChars())
                input = input.Replace(c.ToString(), "");
            return input.Trim();
        }

        private string SanitizeForFilename(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "X";
            var invalid = Path.GetInvalidFileNameChars();
            foreach (var c in invalid) input = input.Replace(c.ToString(), "");
            return input.Replace(" ", "_");
        }

        // ========================= COMBO LOADERS =========================

        private void LoadPrograms() =>
            LoadComboBox("SELECT ProgramID, ProgramCode FROM Program ORDER BY ProgramCode", cmbProgram, "ProgramCode", "ProgramID");

        private void LoadCourses() =>
            LoadComboBox("SELECT CourseID, CourseCode FROM Course ORDER BY CourseCode", cmbCourse, "CourseCode", "CourseID");

        private void LoadCourses(int curriculumID, int yearLevel, int semester)
        {
            if (curriculumID == 0 || yearLevel == 0 || semester == 0)
            {
                cmbCourse.DataSource = null;
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT DISTINCT co.CourseID, co.CourseCode
                FROM CurriculumCourse cc
                JOIN Course co ON cc.CourseID = co.CourseID
                WHERE cc.CurriculumID = @CurriculumID
                ORDER BY co.CourseCode", con))
            {
                cmd.Parameters.AddWithValue("@CurriculumID", curriculumID);

                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                DataRow placeholder = dt.NewRow();
                placeholder["CourseID"] = 0;
                placeholder["CourseCode"] = "Select Course";
                dt.Rows.InsertAt(placeholder, 0);

                cmbCourse.DataSource = dt;
                cmbCourse.DisplayMember = "CourseCode";
                cmbCourse.ValueMember = "CourseID";
                cmbCourse.SelectedIndex = 0;
            }
        }

        private void LoadProfessors()
        {
            LoadComboBox(
                @"SELECT 
                      FacultyID,
                      LastName + ', ' + FirstName +
                      CASE 
                          WHEN MiddleName IS NULL OR LTRIM(RTRIM(MiddleName)) = '' 
                          THEN '' 
                          ELSE ' ' + LEFT(MiddleName, 1) + '.'
                      END AS FullName
                  FROM Faculty
                  ORDER BY LastName, FirstName",
                cmbProfessor,
                "FullName",
                "FacultyID"
            );
        }

        private void LoadYearLevels()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "1st Year");
            dt.Rows.Add(2, "2nd Year");
            dt.Rows.Add(3, "3rd Year");
            dt.Rows.Add(4, "4th Year");
            dt.Rows.Add(5, "5th Year");
            cmbYearLevel.DataSource = dt;
            cmbYearLevel.DisplayMember = "Name";
            cmbYearLevel.ValueMember = "ID";
        }
        private void LoadSections()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(1, "1");
            dt.Rows.Add(2, "2");
            dt.Rows.Add(3, "3");

            cmbSection.DataSource = dt;      // ✅ correct combo
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
        }


        private void LoadSemesters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "1st Semester");
            dt.Rows.Add(2, "2nd Semester");
            dt.Rows.Add(3, "Summer");
            cmbSemester.DataSource = dt;
            cmbSemester.DisplayMember = "Name";
            cmbSemester.ValueMember = "ID";
        }

        private void LoadSchoolYears()
        {
            LoadComboBox(
                        @"SELECT SchoolYear
                  FROM ClassSection
                  GROUP BY SchoolYear
                  ORDER BY SchoolYear DESC",
                cmbSchoolYear,
                "SchoolYear",
                "SchoolYear"
            );
        }
        private void LoadCurriculum()
        {
            LoadComboBox(
                    @"SELECT CurriculumYear
              FROM CurriculumHeader
              GROUP BY CurriculumYear
              ORDER BY CurriculumYear DESC",
                cmbCurriculum,
                "CurriculumYear",
                "CurriculumYear"
            );
        }

        private void LoadCurriculumYears(int programID)
        {
            if (programID == 0)
            {
                cmbCurriculum.DataSource = null;
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT DISTINCT CurriculumYear 
          FROM Curriculum 
          WHERE ProgramID = @ProgramID 
          ORDER BY CurriculumYear DESC", con))
            {
                cmd.Parameters.AddWithValue("@ProgramID", programID);

                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                DataRow placeholder = dt.NewRow();
                placeholder["CurriculumYear"] = "Select Curriculum";
                dt.Rows.InsertAt(placeholder, 0);

                cmbCurriculum.DataSource = dt;
                cmbCurriculum.DisplayMember = "CurriculumYear";
                cmbCurriculum.ValueMember = "CurriculumYear";
                cmbCurriculum.SelectedIndex = 0;
            }
        }



        private void LoadComboBox(string query, ComboBox cmb, string display, string value)
        {
            try
            {
                var dt = new DataTable();
                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                }

                cmb.DataSource = dt;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
            }
            catch (Exception ex)
            {
                // Best-effort: keep control empty on failure
                cmb.DataSource = null;
                MessageBox.Show("Failed to load lookup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================= SAFE COMBO HELPERS =========================

        private void SafeSetComboSelectedValue(ComboBox cmb, object value)
        {
            try
            {
                if (cmb == null) return;
                if (value == null || value == DBNull.Value)
                {
                    cmb.SelectedIndex = -1;
                    return;
                }

                // If bound to a DataTable and value is a DataRowView use lookup by value member
                var val = value is DataRowView drv ? drv.Row.ItemArray.FirstOrDefault() : value;
                if (cmb.DataSource is DataTable dt && !string.IsNullOrEmpty(cmb.ValueMember) && dt.Columns.Contains(cmb.ValueMember))
                {
                    // try to find the row and set SelectedValue
                    try
                    {
                        cmb.SelectedValue = Convert.ChangeType(value, dt.Columns[cmb.ValueMember].DataType);
                        return;
                    }
                    catch { }
                }

                // fallback
                cmb.SelectedValue = value;
            }
            catch { /* ignore selection failures */ }
        }

        private int GetComboSelectedValueInt(ComboBox cmb)
        {
            try
            {
                if (cmb == null || cmb.SelectedValue == null) return 0;
                if (cmb.SelectedValue is DataRowView drv)
                {
                    // try value member
                    if (!string.IsNullOrEmpty(cmb.ValueMember) && drv.DataView != null && drv.DataView.Table.Columns.Contains(cmb.ValueMember))
                    {
                        var v = drv[cmb.ValueMember];
                        if (v != null && v != DBNull.Value) return Convert.ToInt32(v);
                    }

                    // fallback first int column
                    foreach (DataColumn c in drv.DataView.Table.Columns)
                    {
                        if (c.DataType == typeof(int))
                        {
                            var vv = drv[c.ColumnName];
                            if (vv != null && vv != DBNull.Value) return Convert.ToInt32(vv);
                        }
                    }
                    return 0;
                }

                return Convert.ToInt32(cmb.SelectedValue);
            }
            catch { return 0; }
        }

        private string GetComboSelectedValueString(ComboBox cmb)
        {
            try
            {
                if (cmb == null || cmb.SelectedValue == null) return null;
                if (cmb.SelectedValue is DataRowView drv)
                {
                    if (!string.IsNullOrEmpty(cmb.ValueMember) && drv.DataView != null && drv.DataView.Table.Columns.Contains(cmb.ValueMember))
                        return drv[cmb.ValueMember]?.ToString();
                    return drv.Row.ItemArray.Length > 0 ? drv.Row.ItemArray[0]?.ToString() : null;
                }

                return cmb.SelectedValue.ToString();
            }
            catch { return null; }
        }

        private string GetComboSelectedText(ComboBox cmb)
        {
            try
            {
                if (cmb == null) return null;
                return cmb.Text;
            }
            catch { return null; }
        }

        // ========================= MISC UI =========================

        private void btnClose_Click_1(object sender, EventArgs e) => Close();

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            if (pbPreview.Image == null)
            {
                MessageBox.Show("Image is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var previewForm = new currentpicturePreview();
            previewForm.PassedImage = pbPreview.Image;
            previewForm.Show();
        }

        private void tlpEditControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFilename_Click(object sender, EventArgs e)
        {

        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCourse_Click(object sender, EventArgs e)
        {

        }
    }
}