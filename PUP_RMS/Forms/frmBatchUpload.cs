using Dapper;
using PUP_RMS.Core;
using PUP_RMS.Helper;
using PUP_RMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PUP_RMS.Forms
{
    public partial class frmBatchUpload : Form
    {
        private int loggedInAdminId = 1;
        private readonly string baseImagePath = Path.Combine(Application.StartupPath, "GradeSheets");
        private Stack<UndoItem> undoHistory = new Stack<UndoItem>();
        private ImageList uploadImageList;

        public frmBatchUpload()
        {
            // Anti-flicker settings
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            this.Load += frmBatchUpload_Load;

            // FOR FILE NAME UPDATING

            yearCmbox.TextChanged += UpdateFileName;
            semesterCmbox.SelectedIndexChanged += UpdateFileName;
            programCmbox.SelectedIndexChanged += UpdateFileName;
            yearLevelCmbox.SelectedIndexChanged += UpdateFileName;
            courseCmbox.SelectedIndexChanged += UpdateFileName;
            professorCmbox.SelectedIndexChanged += UpdateFileName;
            pageCmbox.SelectedIndexChanged += UpdateFileName;
            curriculumCmbox.SelectedIndexChanged += UpdateFileName;
            sectionCmbox.SelectedIndexChanged += UpdateFileName;

            // FOR RIGHT CLICK CONTEXT MENU

            toUpload.SelectedIndexChanged += toUpload_SelectedIndexChanged;
            removeItemMenu.Click += removeItemMenu_Click;
            toUpload.MouseDown += toUpload_MouseDown;
            uploadBtn.Click += uploadBtn_Click;
            saveBtn.Click += saveBtn_Click;
            undoBtn.Click += undoBtn_Click;
            

            if (currentImage.Image == null)
            {
                currentImage.Visible = false;
            }

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

        private void frmBatchUpload_Load(object sender, EventArgs e)
        {
            LoadProfessors();
            LoadSemester();
            InitializeImageList();
            LoadPrograms();
            LoadYearLevels();

            
            LoadPageNumber();
            LoadAcademicYears();
            yearCmbox.Text = ""; 
            LoadSection();

        }

        private void InitializeImageList()
        {
            uploadImageList = new ImageList { ImageSize = new Size(96, 96), ColorDepth = ColorDepth.Depth32Bit };
            toUpload.View = View.LargeIcon;
            toUpload.LargeImageList = uploadImageList;

            toUpload.AllowDrop = true;
            toUpload.DragEnter += toUpload_DragEnter;
            toUpload.DragDrop += toUpload_DragDrop;

        }

        // =========================
        // DATA LOADING
        // =========================

        private void LoadProfessors()
        {
            professorCmbox.DataSource = DbControl.GetProfessors();
            professorCmbox.DisplayMember = "DisplayName";
            professorCmbox.ValueMember = "FacultyID";
            professorCmbox.SelectedIndex = -1;
        }

        private void LoadSemester()
        {
            semesterCmbox.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1st Semester", Value = 1, Code = "A" },
                new ComboItem { Text = "2nd Semester", Value = 2, Code = "B" },
                new ComboItem { Text = "Summer", Value = 3, Code = "C" }
            };
            semesterCmbox.DisplayMember = "Text";
            semesterCmbox.ValueMember = "Value";
            semesterCmbox.SelectedIndex = -1;
        }

        private void LoadYearLevels()
        {
            yearLevelCmbox.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1st Year", Value = 1 },
                new ComboItem { Text = "2nd Year", Value = 2 },
                new ComboItem { Text = "3rd Year", Value = 3 },
                new ComboItem { Text = "4th Year", Value = 4 },
                new ComboItem { Text = "5th Year", Value = 5 }
            };
            yearLevelCmbox.DisplayMember = "Text";
            yearLevelCmbox.ValueMember = "Value";
            yearLevelCmbox.SelectedIndex = -1;
        }
        private void LoadSection()
        {
            sectionCmbox.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1", Value = 1 },
                new ComboItem { Text = "2", Value = 2 },
                new ComboItem { Text = "3", Value = 3 }
            };
            sectionCmbox.DisplayMember = "Text";
            sectionCmbox.ValueMember = "Value";
            sectionCmbox.SelectedIndex = -1;
        }

        private void LoadPageNumber()
        {
            pageCmbox.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1", Value = 1 },
                new ComboItem { Text = "2", Value = 2 },
                new ComboItem { Text = "3", Value = 3 }
            };
            pageCmbox.DisplayMember = "Text";
            pageCmbox.ValueMember = "Value";
            pageCmbox.SelectedIndex = -1;
        }

        private void LoadPrograms()
        {
            programCmbox.DataSource = DbControl.GetPrograms();
            programCmbox.DisplayMember = "ProgramCode";
            programCmbox.ValueMember = "ProgramID";
            programCmbox.SelectedIndex = -1;
        }

        private void LoadCurriculum()
        {
            if (programCmbox.SelectedValue == null)
                return;

            int programId = Convert.ToInt32(programCmbox.SelectedValue);

            curriculumCmbox.DataSource = DbControl.GetCurriculumsByProgram(programId);
            curriculumCmbox.DisplayMember = "CurriculumYear";
            curriculumCmbox.ValueMember = "CurriculumID";
            curriculumCmbox.SelectedIndex = -1;
        }

        private void LoadAcademicYears()
        {
            yearCmbox.Items.Clear();

            int startYear = 1970;
            int currentAYStart = GetCurrentAcademicYearStart();

            for (int year = currentAYStart; year >= startYear; year--)
            {
                string academicYear = $"{year}-{year + 1}";
                yearCmbox.Items.Add(academicYear);
            }

            yearCmbox.SelectedItem = $"{currentAYStart}-{currentAYStart + 1}";
        }


        private int GetCurrentAcademicYearStart()
        {
            DateTime now = DateTime.Now;

            return now.Month >= 6
                ? now.Year
                : now.Year - 1;
        }






        // filter program based on selected curriculum year
        

        // =========================
        // NAMING CONVENTION LOGIC
        // =========================
        private void UpdateFileName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(yearCmbox.Text) ||
                pageCmbox.SelectedValue == null ||
                curriculumCmbox.SelectedValue == null ||
                semesterCmbox.SelectedItem == null ||
                programCmbox.SelectedItem == null ||
                sectionCmbox.SelectedValue == null ||
                yearLevelCmbox.SelectedItem == null ||
                courseCmbox.SelectedItem == null)// ||
               // professorCmbox.SelectedItem == null)
            {
                return;
            }

            try
            {
                string rawYear = yearCmbox.Text.Replace("-", "").Replace(" ", "");
                string shortYear = rawYear.Length >= 8
                    ? rawYear.Substring(2, 2) + rawYear.Substring(6, 2)
                    : rawYear;

                string semCode = (semesterCmbox.SelectedItem as ComboItem)?.Code ?? "X";
                string progCode = programCmbox.Text;
                string yrLevel = (yearLevelCmbox.SelectedItem as ComboItem)?.Value.ToString() ?? "0";
                string section = sectionCmbox.Text;
                string courseCode = courseCmbox.Text;
                string facultyInitials = (professorCmbox.SelectedValue as Faculty)?.Initials ?? "UNK";
                string pageNum = "P" + pageCmbox.SelectedValue;

                string initials = getFacultyIntials(Convert.ToInt32(professorCmbox.SelectedValue));



                filenameTxtbox.Text =
                    $"PUPLQ_GRSH_{shortYear}_{semCode}_{progCode}_{yrLevel}_{section}_{courseCode}_{initials}_{pageNum}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating filename: " + ex.Message);
            }

        }

        private Image CreateThumbnail(string path)
        {
            using (Image img = Image.FromFile(path))
            {
                return img.GetThumbnailImage(96, 96, () => false, IntPtr.Zero);
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (toUpload.Items.Count < 0)
            {
                toUpload.Items.Clear();
                uploadImageList.Images.Clear();
                undoHistory.Clear();
            }


            foreach (string file in ofd.FileNames)
            {
                Image thumb = CreateThumbnail(file);
                uploadImageList.Images.Add(file, thumb);
                ListViewItem item = new ListViewItem(Path.GetFileName(file))
                {
                    Tag = file,
                    ImageKey = file
                };

                toUpload.Items.Add(item);
            }
            DisplayCurrentImage();




        }
        private void DisplayCurrentImage()
        {
            if (toUpload.Items.Count == 0)
            {
                currentImage.Image?.Dispose();
                currentImage.Image = null;
                return;
            }

            string path = toUpload.Items[0].Tag.ToString();
            currentImage.Image?.Dispose();
            using (Bitmap bmp = new Bitmap(path)) { currentImage.Image = new Bitmap(bmp); }

            if (currentImage.Image != null)
            {
                imagePanel.Visible = true;
                currentImage.Visible = true;
            }
            else
            {
                imagePanel.Visible = false;
                currentImage.Visible = false;
            }
        }

        // =========================
        // DRAG AND DROP LOGIC
        // =========================

        private void toUpload_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }


        private void toUpload_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (!IsImageFile(file)) continue;

                // Prevent duplicates
                if (toUpload.Items.Cast<ListViewItem>()
                    .Any(i => i.Tag.ToString().Equals(file, StringComparison.OrdinalIgnoreCase)))
                    continue;

                Image thumb = CreateThumbnail(file);
                uploadImageList.Images.Add(file, thumb);

                ListViewItem item = new ListViewItem(Path.GetFileName(file))
                {
                    Tag = file,
                    ImageKey = file
                };

                toUpload.Items.Add(item);
            }

            DisplayCurrentImage();
        }

        private bool IsImageFile(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp";
        }



        // =========================
        // RIGHT CLICK LOGIC
        // 
        private void removeItemMenu_Click(object sender, EventArgs e)
        {
            if (toUpload.SelectedItems.Count == 0) return;

            ListViewItem item = toUpload.SelectedItems[0];

            // Remove thumbnail
            uploadImageList.Images.RemoveByKey(item.ImageKey);

            // Remove item
            toUpload.Items.Remove(item);



            DisplayCurrentImage();
        }

        private void toUpload_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toUpload.SelectedItems.Count == 0) return;

            string path = toUpload.SelectedItems[0].Tag.ToString();

            currentImage.Image?.Dispose();
            using (Bitmap bmp = new Bitmap(path))
            {
                currentImage.Image = new Bitmap(bmp);
            }
        }

        private void toUpload_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var item = toUpload.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                item.Selected = true;
                toUpload.FocusedItem = item;
            }
        }



        // =========================

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string curriculumYear = curriculumCmbox.Text;
            int progID = programCmbox.SelectedValue != null ? Convert.ToInt32(programCmbox.SelectedValue) : 0;
            int yearLevel = yearLevelCmbox.SelectedValue != null ? Convert.ToInt32(yearLevelCmbox.SelectedValue) : 0;
            int sem = semesterCmbox.SelectedValue != null ? Convert.ToInt32(semesterCmbox.SelectedValue) : 0;

            if (yearCmbox.SelectedItem == null ||
                pageCmbox.SelectedValue == null ||
                semesterCmbox.SelectedItem == null ||
                programCmbox.SelectedItem == null ||
                yearLevelCmbox.SelectedItem == null ||
                courseCmbox.SelectedItem == null ||
                professorCmbox.SelectedItem == null)
            {
                MessageBox.Show("Complete All Fields.");
                return;
            }
            if (string.IsNullOrWhiteSpace(filenameTxtbox.Text))
            {
                MessageBox.Show("Filename is required.");
                return;
            }
            if (currentImage.Image == null)
            {
                MessageBox.Show("Image is required.");
                return;
            }

            try
            {
                string sourcePath = toUpload.Items[0].Tag.ToString();
                string extension = Path.GetExtension(sourcePath);
                string folderPath = BuildImageFolderPath();
                Directory.CreateDirectory(folderPath);

                string savedFileName = filenameTxtbox.Text + extension;
                string savedFilePath = Path.Combine(folderPath, savedFileName);


                if (checkGradeSheetDuplicate(filenameTxtbox.Text))
                {
                    MessageBox.Show(
                    "Duplicated Filename Detected. Please change the filename.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);



                    filenameTxtbox.Focus();
                    filenameTxtbox.SelectAll();
                    return;
                }

                File.Copy(sourcePath, savedFilePath, true);

                int gradeSheetId = DbControl.InsertGradeSheet(
                    savedFileName, folderPath, yearCmbox.Text,
                    getCurriculumID(curriculumYear, progID, yearLevel, sem),
                    Convert.ToInt32(sectionCmbox.SelectedValue),
                    Convert.ToInt32(courseCmbox.SelectedValue),
                    Convert.ToInt32(professorCmbox.SelectedValue),
                    Convert.ToInt32(pageCmbox.SelectedValue), loggedInAdminId
                );



                if (gradeSheetId == -1)
                {
                    MessageBox.Show(
                        "Duplicated Filename Detected. Please change the filename.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );


                    filenameTxtbox.Focus();
                    filenameTxtbox.SelectAll();
                    return;
                };

                undoHistory.Push(new UndoItem
                {
                    GradeSheetID = gradeSheetId,
                    SourceFilePath = sourcePath,
                    SavedFilePath = savedFilePath
                });

                toUpload.Items.RemoveAt(0);
                DisplayCurrentImage();
                MessageBox.Show("Grade sheet saved successfully.");

                ActivityLogger.LogGradesheetUpload(yearCmbox.Text, semesterCmbox.Text, courseCmbox.Text, professorCmbox.Text);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }



            if (!KeepCheckbox.Checked)
            {
                yearCmbox.Text = "";
                semesterCmbox.SelectedIndex = -1;
                courseCmbox.Text = "";
                professorCmbox.Text = "";
                yearLevelCmbox.SelectedIndex = -1;
                programCmbox.Text = "";
                pageCmbox.Text = "";
                filenameTxtbox.Text = "";

            }
        }

        private bool checkGradeSheetDuplicate (string baseFileName)
        {
            string query = "SELECT COUNT(*) AS Existing \r\nFROM GradeSheet\r\nWHERE Filename LIKE @Filename + '.%' OR Filename = @Filename;";

            DbControl.AddParameter("@Filename", baseFileName, SqlDbType.VarChar);

            DataTable dt = DbControl.GetData(query);
            if (Convert.ToInt32(dt.Rows[0]["Existing"]) > 0) {
                return true;
            }else { return false; }
            
        }

        private int getCurriculumID(string curriculumYear, int progID, int yearLevel, int sem)
        {
            int currID = 0;
            string query = "select CurriculumID from Curriculum \r\nwhere\r\n    CurriculumYear = @CurriculumYear and ProgramID = @ProgramID and YearLevel = @YearLevel and Semester = @Semester;";

            DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            DbControl.AddParameter("@ProgramID", progID, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", yearLevel, SqlDbType.Int);
            DbControl.AddParameter("@Semester", sem, SqlDbType.Int);

            DataTable dt = DbControl.GetData(query);
            if(dt != null)
            {
                
                currID = Convert.ToInt32(dt.Rows[0]["CurriculumID"]);
                
            }

            return currID;
        }

        // =========================
        // FOR BUILDING IMAGE PATH
        // =========================

        private string BuildImageFolderPath()
        {
           
            string year = SanitizePath(yearCmbox.Text);
            string semester = SanitizePath(semesterCmbox.Text);
            string program = SanitizePath(programCmbox.Text);
            string section = SanitizePath(sectionCmbox.Text);
            string course = SanitizePath(courseCmbox.Text);
            string professor = SanitizePath(professorCmbox.Text);

            return Path.Combine(
                baseImagePath,
                year,
                semester,
                program,
                section
            );
        }

        private string SanitizePath(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c.ToString(), "");
            }
            return input.Trim();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            if (currentImage.Image == null)
            {
                MessageBox.Show("Image is required.");
                return;
            }
            else
            {
                var previewForm = new currentpicturePreview();
                previewForm.PassedImage = currentImage.Image;
                previewForm.Show();
            }


        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (undoHistory.Count == 0) return;

            UndoItem undo = undoHistory.Pop();
            DbControl.DeleteGradeSheet(undo.GradeSheetID);

            if (File.Exists(undo.SavedFilePath)) File.Delete(undo.SavedFilePath);

            Image thumb = CreateThumbnail(undo.SourceFilePath);
            uploadImageList.Images.Add(undo.SourceFilePath, thumb);
            toUpload.Items.Insert(0, new ListViewItem(Path.GetFileName(undo.SourceFilePath))
            {
                Tag = undo.SourceFilePath,
                ImageKey = undo.SourceFilePath
            });

            DisplayCurrentImage();
            MessageBox.Show("Last upload undone.");
        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {

        }

        // COMBO BOX FILTERING LOGIC
        private void courseCmbox_Click(object sender, EventArgs e)
        {
            // wag na gawing stored proc tangina
            string query = "SELECT \r\n\tCO.CourseID,\r\n    CO.CourseCode AS [Description]\r\nFROM Curriculum C\r\nJOIN CurriculumCourse CC ON C.CurriculumID = CC.CurriculumID\r\nJOIN Course CO ON CC.CourseID = CO.CourseID\r\nWHERE\r\n\tc.CurriculumYear = @CurriculumYear AND c.ProgramID = @ProgramID and c.YearLevel = @YearLevel and c.Semester = @Semester\r\nORDER BY CO.CourseCode;";

            string curriculumYear = curriculumCmbox.Text;
            int programID = programCmbox.SelectedValue != null ? Convert.ToInt32(programCmbox.SelectedValue) : 0;
            int yearLevel = yearLevelCmbox.SelectedValue != null ? Convert.ToInt32(yearLevelCmbox.SelectedValue) : 0;
            int semester = semesterCmbox.SelectedValue != null ? Convert.ToInt32(semesterCmbox.SelectedValue) : 0;

            DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            DbControl.AddParameter("@ProgramID", programID, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", yearLevel, SqlDbType.Int);
            DbControl.AddParameter("@Semester", semester, SqlDbType.Int);

            DataTable dt = DbControl.GetData(query);
            courseCmbox.DisplayMember = "Description";
            courseCmbox.ValueMember = "CourseID";
            courseCmbox.DataSource = dt;


        }
        

        private void curriculumCmbox_Click(object sender, EventArgs e)
        {
            LoadCurriculum();
        }

        private void courseCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curriculumYear = curriculumCmbox.Text;
            int programID = programCmbox.SelectedValue != null ? Convert.ToInt32(programCmbox.SelectedValue) : 0;
            int yearLevel = yearLevelCmbox.SelectedValue != null ? Convert.ToInt32(yearLevelCmbox.SelectedValue) : 0;
            int semester = semesterCmbox.SelectedValue != null ? Convert.ToInt32(semesterCmbox.SelectedValue) : 0;
            
            int curriculumID = getCurriculumID(curriculumYear, programID, yearLevel, semester);
            int courseID = courseCmbox.SelectedValue != null ? Convert.ToInt32(courseCmbox.SelectedValue) : 0;
            
            // wag na gawing stored proc
            string query = "select\r\n    F.LastName + ', ' + F.FirstName + ' ' + F.MiddleName AS FullName, F.FacultyID \r\nFROM\r\n    CurriculumCourse CC\r\nJOIN Faculty F ON CC.FacultyID = F.FacultyID\r\nWhere \r\n    CurriculumID = @CurriculumID and CourseID = @CourseID";

            DbControl.AddParameter("@CurriculumID", curriculumID, SqlDbType.Int);
            DbControl.AddParameter("@CourseID", courseID, SqlDbType.Int);
            DataTable dt = DbControl.GetData(query);
            //string fullname = Convert.ToString(dt.Rows[0]["FullName"]);
            //professorCmbox.Text = fullname;
            professorCmbox.DisplayMember = "Fullname";
            professorCmbox.ValueMember = "FacultyID";
            professorCmbox.DataSource = dt;
            




        }

        private static string getFacultyIntials(int facultyID)
        {
            string query = "Select Initials FROM Faculty WHERE FacultyID = @FacultyID";
            DbControl.AddParameter("@FacultyID", facultyID, SqlDbType.Int);
            DataTable dt = DbControl.ExecuteQuery(query);

            return Convert.ToString(dt.Rows[0]["Initials"]);
        }

        private void currentImage_Click(object sender, EventArgs e)
        {

        }
    }


    public class UndoItem
        {
            public int GradeSheetID { get; set; }
            public string SourceFilePath { get; set; }
            public string SavedFilePath { get; set; }
        }

        public class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public string Code { get; set; } // Used for A, B, C Semester codes

        }
}


