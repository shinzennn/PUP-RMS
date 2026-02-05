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
using Dapper;
using PUP_RMS.Core;
using PUP_RMS.Helper;
using PUP_RMS.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace PUP_RMS.Forms
{
    public partial class frmBatchUpload : Form
    {
        private int loggedInAdminId = 1;
        private readonly string baseImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RecordsManagementSystem", "GradeSheets");
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
            sectionCmbox.TextChanged += UpdateFileName;

            // FOR RIGHT CLICK CONTEXT MENU

            toUpload.SelectedIndexChanged += toUpload_SelectedIndexChanged;
            removeItemMenu.Click += removeItemMenu_Click;
            toUpload.MouseDown += toUpload_MouseDown;
            //uploadBtn.Click += uploadBtn_Click;
            saveBtn.Click += saveBtn_Click;
            //undoBtn.Click += undoBtn_Click;

            // Add these to your constructor or Load method
            yearLevelCmbox.SelectedIndexChanged += (s, e) => LoadAcademicYears();
            curriculumCmbox.SelectedIndexChanged += (s, e) => LoadAcademicYears();

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
            // LoadProfessors();
            LoadSemester();
            InitializeImageList();
            LoadPrograms();
            LoadYearLevels();
            //LoadCourses();


            LoadPageNumber();
            LoadAcademicYears();
            yearCmbox.Text = "";
            //  LoadSection();

        }
        public void loadData()
        {
            filenameTxtbox.Text = "";
            //  LoadProfessors();
            LoadSemester();
            InitializeImageList();
            LoadPrograms();
            LoadYearLevels();
            //LoadCourses();

            LoadPageNumber();
            LoadAcademicYears();
            yearCmbox.Text = "";
            //  LoadSection();
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

        private void LoadCourses()
        {

            if (programCmbox.SelectedValue == null ||
                curriculumCmbox.SelectedValue == null ||
                yearLevelCmbox.SelectedValue == null ||
                semesterCmbox.SelectedValue == null)
            {
                
                courseCmbox.DataSource = null;
                return;
            }



            try
            {

                string query = @"SELECT 
                co.CourseCode,
                co.CourseID
                FROM Program p
                INNER JOIN CurriculumHeader ch ON p.ProgramID = ch.ProgramID
                INNER JOIN Curriculum c ON ch.CurriculumHeaderID = c.CurriculumHeaderID
                INNER JOIN Offering o ON c.CurriculumID = o.CurriculumID
                INNER JOIN Course co ON o.CourseID = co.CourseID
                 WHERE p.ProgramID = @ProgramID
                 AND ch.CurriculumHeaderID = @CurriculumHeaderID
                 AND c.YearLevel = @YearLevel
                 AND c.Semester = @Semester
";


                DbControl.ClearParameters();

                DbControl.AddParameter("@ProgramID", Convert.ToInt32(programCmbox.SelectedValue), SqlDbType.Int);
                DbControl.AddParameter("@CurriculumHeaderID", Convert.ToInt32(curriculumCmbox.SelectedValue), SqlDbType.Int);
                DbControl.AddParameter("@YearLevel", Convert.ToInt32(yearLevelCmbox.SelectedValue), SqlDbType.Int);
                DbControl.AddParameter("@Semester", Convert.ToInt32(semesterCmbox.SelectedValue), SqlDbType.Int);

                DataTable dt = DbControl.GetData(query);
                if (dt.Rows.Count == 0)
                {
                    courseCmbox.DataSource = null;
                    return;
                }
                courseCmbox.DataSource = dt;
                courseCmbox.DisplayMember = "CourseCode";
                courseCmbox.ValueMember = "CourseID";
                courseCmbox.SelectedIndex = -1;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
                return;
            }



        }

        private void LoadProfessors()
        {

            if (yearCmbox.Text == null ||
                sectionCmbox.Text == null ||
                courseCmbox.Text == null)
            {
                MessageBox.Show("Please make sure Year, Section, and Course are selected.");
                return;
            }


            string query = @"
            SELECT 
                F.FacultyID,
                CONCAT(F.LastName, ', ', F.FirstName) AS FullName
            FROM ClassSection CS
            INNER JOIN Faculty F ON CS.FacultyID = F.FacultyID
            INNER JOIN Offering O ON CS.OfferingID = O.OfferingID
            WHERE CS.SchoolYear = @SchoolYear
              AND CS.Section = @Section
              AND O.CourseID = @CourseID";

            DbControl.ClearParameters();
            DbControl.AddParameter("@SchoolYear", yearCmbox.Text, SqlDbType.VarChar);
            DbControl.AddParameter("@Section", Convert.ToInt32(sectionCmbox.SelectedValue), SqlDbType.Int);
            DbControl.AddParameter("@CourseID", Convert.ToInt32(courseCmbox.SelectedValue), SqlDbType.Int);

            DataTable dt = DbControl.GetData(query);

            if (dt.Rows.Count == 0)
            {
                professorCmbox.DataSource = null;
                return;
            }

            professorCmbox.DataSource = dt;
            professorCmbox.Text = dt.Rows[0]["FullName"].ToString();
            professorCmbox.DisplayMember = "FullName";
            professorCmbox.ValueMember = "FacultyID";
            // professorCmbox.SelectedIndex = -1;
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
            curriculumCmbox.ValueMember = "CurriculumHeaderID";
            curriculumCmbox.SelectedIndex = -1;

        }

        private void LoadAcademicYears()
        {


            // 1. Validation: Ensure all necessary filters are selected
            if (curriculumCmbox.SelectedValue == null ||
                courseCmbox.SelectedValue == null ||
                semesterCmbox.SelectedValue == null ||
                yearLevelCmbox.SelectedValue == null)
            {
                return;
            }

            // 2. Refined Query: Include Semester and YearLevel to find the UNIQUE Offering
            // Adjust table names/columns based on your actual schema if 'Offering' holds these
            string query = @"
           SELECT 
             OfferingID 
             FROM Offering AS O
             INNER JOIN Curriculum AS C ON O.CurriculumID = C.CurriculumID
             WHERE C.CurriculumID = @CurriculumID AND CourseID = @CourseID AND Semester = @Semester AND YearLevel = @YearLevel;";

            int curriculumid = getCurriculumID(Convert.ToInt32(curriculumCmbox.SelectedValue), Convert.ToInt32(yearLevelCmbox.SelectedValue), Convert.ToInt32(semesterCmbox.SelectedValue));
            //MessageBox.Show("Debug: Executing LoadAcademicYears with CurriculumID=" + curriculumid +
            //    ", CourseID=" + courseCmbox.SelectedValue +
            //    ", Semester=" + semesterCmbox.SelectedValue +
            //    ", YearLevel=" + yearLevelCmbox.SelectedValue);
            DbControl.ClearParameters();
            DbControl.AddParameter("@CurriculumID", curriculumid, SqlDbType.Int);
            DbControl.AddParameter("@CourseID", courseCmbox.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@Semester", semesterCmbox.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", yearLevelCmbox.SelectedValue, SqlDbType.Int);

            DataTable dt = DbControl.GetData(query);

            if (dt.Rows.Count == 0)
            {
                // Clear fields if no offering exists for this specific combination
                yearCmbox.Text = "";
                sectionCmbox.Text = "";
                return;
            }

            int offeringid = Convert.ToInt32(dt.Rows[0]["OfferingID"]);

            // 3. Get the Section and School Year
            string query2 = @" 
        SELECT SchoolYear, Section 
        FROM ClassSection 
        WHERE OfferingID = @OfferingID;";

            DbControl.ClearParameters();
            DbControl.AddParameter("@OfferingID", offeringid, SqlDbType.Int);

            DataTable ddt = DbControl.GetData(query2);
            if (ddt.Rows.Count > 0)
            {
                yearCmbox.DataSource = ddt.Rows.Cast<DataRow>()
                    .Select(r => r["SchoolYear"].ToString())
                    .Distinct()
                    .ToList();
                sectionCmbox.DataSource = ddt.Rows.Cast<DataRow>()
                    .Select(r => r["Section"].ToString())
                    .Distinct()
                    .ToList();

                //yearCmbox.Text = ddt.Rows[0]["SchoolYear"].ToString();
                //sectionCmbox.Text = ddt.Rows[0]["Section"].ToString();
                LoadProfessors();
            }
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
            // Use string.IsNullOrWhiteSpace for ComboBoxes where you set .Text manually
            if (string.IsNullOrWhiteSpace(yearCmbox.Text) ||
                string.IsNullOrWhiteSpace(sectionCmbox.Text) ||
                string.IsNullOrWhiteSpace(courseCmbox.Text) ||
                curriculumCmbox.SelectedValue == null ||
                semesterCmbox.SelectedValue == null ||
                programCmbox.SelectedValue == null ||
                yearLevelCmbox.SelectedValue == null ||
                pageCmbox.SelectedValue == null)
            {
                return; // It exits here because one of these is still 'null' during the loading phase
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


        private int GetOfferingID()
        {
            string query = @"
           SELECT 
             OfferingID 
             FROM Offering AS O
             INNER JOIN Curriculum AS C ON O.CurriculumID = C.CurriculumID
             WHERE C.CurriculumID = @CurriculumID AND CourseID = @CourseID AND Semester = @Semester AND YearLevel = @YearLevel;";

            int curriculumid = getCurriculumID(Convert.ToInt32(curriculumCmbox.SelectedValue), Convert.ToInt32(yearLevelCmbox.SelectedValue), Convert.ToInt32(semesterCmbox.SelectedValue));
            DbControl.ClearParameters();
            DbControl.AddParameter("@CurriculumID", curriculumid, SqlDbType.Int);
            DbControl.AddParameter("@CourseID", courseCmbox.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@Semester", semesterCmbox.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", yearLevelCmbox.SelectedValue, SqlDbType.Int);

            DataTable dt = DbControl.GetData(query);
            return Convert.ToInt32(dt.Rows[0]["OfferingID"]);
        }

        private int GetSectionID()
        {
            int offeringID = GetOfferingID();
            string query = @"SELECT SectionID 
                    From ClassSection 
                    WHERE Section = @Section AND FacultyID = @FacultyID AND OfferingID = @OfferingID AND SchoolYear = @SchoolYear;";
            DbControl.AddParameter("@Section", sectionCmbox.Text, SqlDbType.VarChar);
            DbControl.AddParameter("@FacultyID", professorCmbox.SelectedValue, SqlDbType.Int);
            DbControl.AddParameter("@OfferingID", offeringID, SqlDbType.Int);
            DbControl.AddParameter("@SchoolYear", yearCmbox.Text, SqlDbType.VarChar);
            DataTable dt = DbControl.GetData(query);
            return Convert.ToInt32(dt.Rows[0]["SectionID"]);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string curriculumYear = curriculumCmbox.Text;
            int progID = programCmbox.SelectedValue != null ? Convert.ToInt32(programCmbox.SelectedValue) : 0;
            int yearLevel = yearLevelCmbox.SelectedValue != null ? Convert.ToInt32(yearLevelCmbox.SelectedValue) : 0;
            int sem = semesterCmbox.SelectedValue != null ? Convert.ToInt32(semesterCmbox.SelectedValue) : 0;

            if (yearCmbox.Text == null ||
                pageCmbox.SelectedValue == null ||
                semesterCmbox.Text == null ||
                programCmbox.Text == null ||
                yearLevelCmbox.Text == null ||
                courseCmbox.Text == null ||
                professorCmbox.Text == null ||
                sectionCmbox.Text == null)
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
                int sectionid = GetSectionID();
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
                    savedFileName, folderPath,
                    sectionid,
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

        private bool checkGradeSheetDuplicate(string baseFileName)
        {
            string query = "SELECT COUNT(*) AS Existing \r\nFROM GradeSheet\r\nWHERE Filename LIKE @Filename + '.%' OR Filename = @Filename;";

            DbControl.AddParameter("@Filename", baseFileName, SqlDbType.VarChar);

            DataTable dt = DbControl.GetData(query);
            if (Convert.ToInt32(dt.Rows[0]["Existing"]) > 0) {
                return true;
            } else { return false; }

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
            if (dt != null)
            {

                currID = Convert.ToInt32(dt.Rows[0]["CurriculumID"]);

            }

            return currID;
        }

        // =========================
        // FOR BUILDING IMAGE PATH
        // =========================
        //wa
        private string BuildImageFolderPath()
        {

            string year = SanitizePath(yearCmbox.Text);
            string semester = SanitizePath(semesterCmbox.Text);
            string program = SanitizePath(programCmbox.Text);
            string yearlevel = SanitizePath(yearLevelCmbox.Text);
            string section = SanitizePath(sectionCmbox.Text);
            string course = SanitizePath(courseCmbox.Text);
            string professor = SanitizePath(professorCmbox.Text);

            return Path.Combine(
                baseImagePath,
                year,
                semester,
                program,
                yearlevel,
                section,
                course,
                professor

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
            if (undoHistory.Count == 0)
            {
                MessageBox.Show("No actions to undo.");
                return;
            }

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

            //LoadCourses();


        }


        private void curriculumCmbox_Click(object sender, EventArgs e)
        {
            LoadCurriculum();
        }

        private void courseCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private static string getFacultyIntials(int facultyID)
        {
            string query = "Select Initials FROM Faculty WHERE FacultyID = @FacultyID";
            DbControl.AddParameter("@FacultyID", facultyID, SqlDbType.Int);
            DataTable dt = DbControl.GetData(query);

            return Convert.ToString(dt.Rows[0]["Initials"]);
        }

        private void currentImage_Click(object sender, EventArgs e)
        {

        }

        private void removeAll_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Are you sure you want to remove ALL items?", "Removing All Images", MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes)
            {
                toUpload.Items.Clear();
            }
            else
            {
                return;
            }
            DisplayCurrentImage();
        }

        public static int getCurriculumID(int curriculumheader, int yearLevel, int semester)
        {
            string query = " SELECT \r\n CurriculumID\r\n FROM Curriculum as C\r\n INNER JOIN CurriculumHeader AS CH ON C.CurriculumHeaderID = CH.CurriculumHeaderID\r\n WHERE CH.CurriculumHeaderID = @CurriculumHeaderID AND C.YearLevel = @YearLevel AND C.Semester = @Semester";

            DbControl.AddParameter("@CurriculumHeaderID", curriculumheader, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", yearLevel, SqlDbType.Int);
            DbControl.AddParameter("@Semester", semester, SqlDbType.Int);
            DataTable dt = DbControl.GetData(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No CurriculumID found for the given parameters.");
                return -1;
            }
            return Convert.ToInt32(dt.Rows[0]["CurriculumID"]);

        }

        private void professorCmbox_Click(object sender, EventArgs e)
        {
            LoadProfessors();
        }

        private void sectionCmbox_Click(object sender, EventArgs e)
        {

        }

        private void sectionCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sectionCmbox_SelectedValueChanged(object sender, EventArgs e)
        {

            LoadProfessors();
        }

        private void sectionCmbox_TextUpdate(object sender, EventArgs e)
        {

           // LoadProfessors();
        }

        private void pageCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void courseCmbox_TextUpdate(object sender, EventArgs e)
        {

        }

        private void courseCmbox_SelectedValueChanged(object sender, EventArgs e)
        {

            yearCmbox.Text = "";
            sectionCmbox.Text = "";
            professorCmbox.Text = "";
            //LoadAcademicYears();
            if (courseCmbox.SelectedValue is int)
            {
                LoadAcademicYears();
            }
        }

        private void semesterCmbox_SelectedValueChanged(object sender, EventArgs e)
        {
            courseCmbox.Text = "";
            yearCmbox.Text = "";
            sectionCmbox.Text = "";
            professorCmbox.Text = "";
            LoadCourses();
        }

        private void yearCmbox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (courseCmbox.SelectedValue != null || yearCmbox.SelectedValue != null || sectionCmbox.SelectedValue != null)
            {
                LoadProfessors();
            }
                
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


