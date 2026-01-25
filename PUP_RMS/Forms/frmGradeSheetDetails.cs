using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private bool isEditMode = false;
        private string stagedImagePath = null;   // temp selection
        private string originalImagePath = null; // original saved image


        public frmGradeSheetDetails()
        {
            InitializeComponent();
        }

        private void frmGradeSheetDetails_Load(object sender, EventArgs e)
        {
            LoadPrograms();
            LoadCourses();
            LoadProfessors();
            LoadYearLevels();
            LoadSemesters();
            LoadSchoolYears();
            //LoadAccounts();

            LoadGradeSheetData();
            DisableEditMode();
        }

        // ========================= LOAD DATA =========================

        private void LoadGradeSheetData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT 
            gs.ProgramID,
            gs.CourseID,
            gs.FacultyID,
            gs.YearLevel,
            gs.Semester,
            gs.SchoolYear,
            gs.PageNumber,
            gs.Filename,
            gs.Filepath,
            a.LastName + ', ' + a.FirstName AS UploadedBy
          FROM GradeSheet gs
          INNER JOIN Account a ON gs.AccountID = a.AccountID
          WHERE gs.GradeSheetID = @GradeSheetID", con))
            {
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return;

                    cmbProgram.SelectedValue = dr["ProgramID"];
                    cmbCourse.SelectedValue = dr["CourseID"];
                    cmbProfessor.SelectedValue = dr["FacultyID"];
                    cmbYearLevel.SelectedValue = dr["YearLevel"];
                    cmbSemester.SelectedValue = dr["Semester"];
                    cmbSchoolYear.SelectedValue = dr["SchoolYear"];
                    txtPageNumber.Text = dr["PageNumber"].ToString();
                    txtFilename.Text = dr["Filename"].ToString();

                    // ✅ uploader (TEXTBOX)
                    txtUploader.Text = dr["UploadedBy"].ToString();

                    originalImagePath = Path.Combine(
                        dr["Filepath"].ToString(),
                        dr["Filename"].ToString()
                    );

                    currentFilePath = originalImagePath;
                    LoadThumbnail(originalImagePath);
                }
            }
        }

        private void LoadThumbnail(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                pbPreview.Image = null;
                return;
            }

            pbPreview.Image?.Dispose();

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                pbPreview.Image = Image.FromStream(fs);
            }
        }

        // ========================= IMAGE UPLOAD =========================

        private void btnUpload_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelImageChange_Click(object sender, EventArgs e)
        {
            stagedImagePath = null;
            imageChanged = false;

            LoadThumbnail(originalImagePath);

            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Enabled = true;
        }

        // ========================= EDIT MODE =========================

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableEditMode();
        }

        private void btnSaveGradeSheetDetails_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void EnableEditMode()
        {
            isEditMode = true;

            //txtPageNumber.ReadOnly = false;
            //btnEdit.Visible = false;
            //btnSaveGradeSheetDetails.Visible = true;
            //btnCancelEdit.Visible = true;
            txtPageNumber.ReadOnly = false;
            cmbSchoolYear.Enabled = true;
            cmbSemester.Enabled = true;
            cmbProgram.Enabled = true;
            cmbYearLevel.Enabled = true;
            cmbCourse.Enabled = true;
            cmbProfessor.Enabled = true;
            btnSaves.Visible = true;
            btnCancels.Visible = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
            btnUpload.Enabled = false;

        }

        private void DisableEditMode()
        {
            isEditMode = false;

            //txtPageNumber.ReadOnly = true;
            //btnEdit.Visible = true;
            //btnSaveGradeSheetDetails.Visible = false;
            //btnCancelEdit.Visible = false;
            txtPageNumber.ReadOnly = true;
            cmbSchoolYear.Enabled = false;
            cmbSemester.Enabled = false;
            cmbProgram.Enabled = false;
            cmbYearLevel.Enabled = false;
            cmbCourse.Enabled = false;
            cmbProfessor.Enabled = false;
            btnSaves.Visible = false;
            btnCancels.Visible = false;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
            btnUpload.Enabled = true;

        }

        // ========================= FILENAME GENERATION =========================

        private string GenerateFileName()
        {
            string acadYear = cmbSchoolYear.Text.Replace("-", "");
            string sem = cmbSemester.SelectedValue.ToString() == "1" ? "A" : "B";

            string program = ((DataRowView)cmbProgram.SelectedItem)["ProgramCode"].ToString();
            string course = ((DataRowView)cmbCourse.SelectedItem)["CourseCode"].ToString();

            string faculty = GetFacultyInitials();
            string yearLevel = cmbYearLevel.SelectedValue.ToString();
            string page = txtPageNumber.Text;

            return $"PUPLQ_GRSH_{acadYear}_{sem}_{program}_{yearLevel}_{course}_{faculty}_P{page}.jpg";
        }

        private string GetFacultyInitials()
        {
            string fullName = ((DataRowView)cmbProfessor.SelectedItem)["FullName"].ToString();
            string[] parts = fullName.Split(' ');

            // Added basic validation to prevent crash if parts are missing
            string initial1 = parts.Length > 0 && parts[0].Length >= 4 ? parts[0].Substring(0, 4) : parts[0];
            string initial2 = parts.Length > 1 && parts[1].Length >= 3 ? parts[1].Substring(0, 3) : (parts.Length > 1 ? parts[1] : "NA");

            return (initial1 + initial2).ToUpper();
        }

        // ========================= COMBO LOADERS =========================

        private void LoadPrograms() =>
            LoadComboBox("SELECT ProgramID, ProgramCode FROM Program", cmbProgram, "ProgramCode", "ProgramID");

        private void LoadCourses() =>
            LoadComboBox("SELECT CourseID, CourseCode FROM Course", cmbCourse, "CourseCode", "CourseID");

        private void LoadProfessors() =>
            LoadComboBox("SELECT FacultyID, FirstName + ' ' + LastName AS FullName FROM Faculty",
                cmbProfessor, "FullName", "FacultyID");

        private void LoadYearLevels()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            for (int i = 1; i <= 5; i++) dt.Rows.Add(i, $"{i} Year");
            cmbYearLevel.DataSource = dt;
            cmbYearLevel.DisplayMember = "Name";
            cmbYearLevel.ValueMember = "ID";
        }

        private void LoadSemesters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "1st Semester");
            dt.Rows.Add(2, "2nd Semester");
            cmbSemester.DataSource = dt;
            cmbSemester.DisplayMember = "Name";
            cmbSemester.ValueMember = "ID";
        }

        private void LoadSchoolYears() =>
            LoadComboBox("SELECT DISTINCT SchoolYear FROM GradeSheet ORDER BY SchoolYear DESC",
                cmbSchoolYear, "SchoolYear", "SchoolYear");

        private void LoadComboBox(string query, ComboBox cmb, string display, string value)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                cmb.DataSource = dt;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
            }
        }

     

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            EnableEditMode();
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Generate the NEW filename and Folder based on the current selections
                string newFileName = GenerateFileName();
                string newTargetFolder = BuildImageFolderPath(); // Generates path based on Year/Sem
                string newFullFilePath = Path.Combine(newTargetFolder, newFileName);

                // 2. Check if the details changed resulting in a new path/name
                if (originalImagePath != newFullFilePath)
                {
                    // A. Check if the original file actually exists before trying to move it
                    if (File.Exists(originalImagePath))
                    {
                        // B. IMPORTANT: Dispose the image in the PictureBox to unlock the file
                        if (pbPreview.Image != null)
                        {
                            pbPreview.Image.Dispose();
                            pbPreview.Image = null;
                        }

                        // Force garbage collection to ensure the file handle is released immediately
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        // C. Create the new directory if it doesn't exist (e.g. New School Year folder)
                        if (!Directory.Exists(newTargetFolder))
                        {
                            Directory.CreateDirectory(newTargetFolder);
                        }

                        // D. Move (Rename) the file to the new location
                        // This handles both renaming the file AND moving it to a new folder
                        File.Move(originalImagePath, newFullFilePath);

                        // Update internal tracking variables
                        originalImagePath = newFullFilePath;
                        currentFilePath = newFullFilePath;
                    }
                    else
                    {
                        MessageBox.Show("The original file could not be found. It may have been deleted or moved manually.",
                                        "File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // 3. Database Update
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateGradeSheet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                    cmd.Parameters.AddWithValue("@Filename", newFileName);
                    cmd.Parameters.AddWithValue("@Filepath", newTargetFolder); // Updates to the new folder path
                    cmd.Parameters.AddWithValue("@SchoolYear", cmbSchoolYear.SelectedValue);
                    cmd.Parameters.AddWithValue("@Semester", cmbSemester.SelectedValue);
                    cmd.Parameters.AddWithValue("@ProgramID", cmbProgram.SelectedValue);
                    cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.SelectedValue);
                    cmd.Parameters.AddWithValue("@CourseID", cmbCourse.SelectedValue);
                    cmd.Parameters.AddWithValue("@FacultyID", cmbProfessor.SelectedValue);
                    cmd.Parameters.AddWithValue("@PageNumber", Convert.ToInt32(txtPageNumber.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // 4. Update UI
                txtFilename.Text = newFileName;

                // Reload the image from the NEW location to verify it works
                LoadThumbnail(originalImagePath);

                DisableEditMode();
                MessageBox.Show("Grade sheet details and file location updated successfully.");
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("File Access Error (File might be open elsewhere): " + ioEx.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Attempt to reload original if move failed
                LoadThumbnail(originalImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadGradeSheetData();
            }

        }

        private void btnCancels_Click(object sender, EventArgs e)
        {
            LoadGradeSheetData();
            DisableEditMode();
        }

        private void roundedShadowPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!imageChanged || string.IsNullOrEmpty(stagedImagePath))
            {
                MessageBox.Show("No image selected.", "Info");
                return;
            }

            string fileName = GenerateFileName();
            //string targetFolder = Path.Combine(Application.StartupPath, "GradeSheets");
            string targetFolder = BuildImageFolderPath();

            Directory.CreateDirectory(targetFolder);

            string finalPath = Path.Combine(targetFolder, fileName);

            File.Copy(stagedImagePath, finalPath, true);

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE GradeSheet
          SET Filename=@Filename, Filepath=@Filepath
          WHERE GradeSheetID=@GradeSheetID", con))
            {
                cmd.Parameters.AddWithValue("@Filename", fileName);
                cmd.Parameters.AddWithValue("@Filepath", targetFolder);
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // commit state
            originalImagePath = finalPath;
            currentFilePath = finalPath;
            stagedImagePath = null;
            imageChanged = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Enabled = true;

            MessageBox.Show("Image saved successfully.");
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

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.png)|*.jpg;*.png"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return; // cancel = do nothing

                stagedImagePath = ofd.FileName; // source only

                LoadThumbnail(stagedImagePath); // preview only

                imageChanged = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
        }

        private string BuildImageFolderPath()
        {
            // Use the currently selected text from the dropdowns
            string schoolYear = SanitizePath(cmbSchoolYear.Text);
            string semester = SanitizePath(cmbSemester.Text);

            // Combine: BasePath \ SchoolYear \ Semester
            return Path.Combine(baseImagePath, schoolYear, semester);
        }

        private string SanitizePath(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Unknown";

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c.ToString(), "");
            }
            return input.Trim();
        }

        private void btnClose_Click_1(object sender, EventArgs e)=>Close();

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            if (pbPreview.Image == null)
            {
                MessageBox.Show("Image is required.");
                return;
            }
            else
            {
                var previewForm = new currentpicturePreview();
                previewForm.PassedImage = pbPreview.Image;
                previewForm.Show();
            }
        }
    }
}