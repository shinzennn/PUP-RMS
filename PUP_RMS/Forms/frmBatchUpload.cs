
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PUP_RMS.Core;   // Ensure this namespace exists in your project
using PUP_RMS.Model;  // Ensure this namespace exists in your project
using PUP_RMS.Helper; // Ensure this namespace exists in your project

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
            InitializeComponent();
            this.Load += frmBatchUpload_Load;

            // Wire up events for Auto-naming
            yearCmbox.TextChanged += UpdateFileName;
            semesterCmbox.SelectedIndexChanged += UpdateFileName;
            programCmbox.SelectedIndexChanged += UpdateFileName;
            yearLevelCmbox.SelectedIndexChanged += UpdateFileName;
            courseCmbox.SelectedIndexChanged += UpdateFileName;
            professorCmbox.SelectedIndexChanged += UpdateFileName;
            pageCmbox.SelectedIndexChanged += UpdateFileName;

            // Wire up Buttons
            uploadBtn.Click += uploadBtn_Click;
            saveBtn.Click += saveBtn_Click;
            undoBtn.Click += undoBtn_Click;
        }

        private void frmBatchUpload_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadProfessors();
            LoadSemester();
            InitializeImageList();
            LoadPrograms();
            LoadYearLevels();
            LoadPageNumber();
            yearCmbox.Text = "";
        }

        private void InitializeImageList()
        {
            uploadImageList = new ImageList { ImageSize = new Size(96, 96), ColorDepth = ColorDepth.Depth32Bit };
            toUpload.View = View.LargeIcon;
            toUpload.LargeImageList = uploadImageList;
        }

        // =========================
        // DATA LOADING
        // =========================
        private void LoadCourses()
        {
            courseCmbox.DataSource = DbControl.GetCourses();
            courseCmbox.DisplayMember = "CourseCode";
            courseCmbox.ValueMember = "CourseID";
            courseCmbox.SelectedIndex = -1;
        }

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
                new ComboItem { Text = "4th Year", Value = 4 }
            };
            yearLevelCmbox.DisplayMember = "Text";
            yearLevelCmbox.ValueMember = "Value";
            yearLevelCmbox.SelectedIndex = -1;
        }

        private void LoadPageNumber()
        {
            pageCmbox.DataSource = new List<ComboItem> {
                new ComboItem { Text = "Page 1", Value = 1 },
                new ComboItem { Text = "Page 2", Value = 2 },
                new ComboItem { Text = "Page 3", Value = 3 },
                new ComboItem { Text = "Page 4", Value = 4 }
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

        // =========================
        // NAMING CONVENTION LOGIC
        // =========================
        private void UpdateFileName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(yearCmbox.Text) ||
                pageCmbox.SelectedValue == null ||
                semesterCmbox.SelectedItem == null ||
                programCmbox.SelectedItem == null ||
                yearLevelCmbox.SelectedItem == null ||
                courseCmbox.SelectedItem == null ||
                professorCmbox.SelectedItem == null)
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
                string courseCode = courseCmbox.Text;
                string facultyInitials = (professorCmbox.SelectedItem as Faculty)?.Initials ?? "UNK";
                string pageNum = "P" + pageCmbox.SelectedValue;

                filenameTxtbox.Text =
                    $"PUPLQ_GRSH_{shortYear}_{semCode}_{progCode}_{yrLevel}_{courseCode}_{facultyInitials}_{pageNum}";
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

        // =========================
        // BUTTON EVENTS
        // =========================

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            // Clear previous if you only want single batch logic, or keep appending
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
            // Load via stream or new Bitmap to avoid locking the file if possible, but simple Bitmap is okay for now
            using (Bitmap bmp = new Bitmap(path)) { currentImage.Image = new Bitmap(bmp); }
        }

        // --- CORRECTED SAVE BUTTON LOGIC ---
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // 1. Validate Inputs
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
            if (toUpload.Items.Count == 0)
            {
                MessageBox.Show("No image uploaded to save.");
                return;
            }

            try
            {
                // 2. Prepare Paths
                string sourcePath = toUpload.Items[0].Tag.ToString();
                string extension = Path.GetExtension(sourcePath);
                string folderPath = BuildImageFolderPath();

                // Ensure directory exists
                Directory.CreateDirectory(folderPath);

                string savedFileName = filenameTxtbox.Text + extension;
                string savedFilePath = Path.Combine(folderPath, savedFileName);

                // 3. CHECK if file physically exists BEFORE copying
                if (File.Exists(savedFilePath))
                {
                    MessageBox.Show("A file with this name already exists in the destination folder.\nPlease rename or check your records.", "File Exists");
                    return; // Stop here. Do not copy. Do not insert.
                }

                // 4. Copy the file
                File.Copy(sourcePath, savedFilePath, true);

                // 5. Insert into Database
                int gradeSheetId = DbControl.InsertGradeSheet(
                    savedFileName, folderPath, yearCmbox.Text,
                    Convert.ToInt32(semesterCmbox.SelectedValue),
                    Convert.ToInt32(programCmbox.SelectedValue),
                    Convert.ToInt32(yearLevelCmbox.SelectedValue),
                    Convert.ToInt32(courseCmbox.SelectedValue),
                    Convert.ToInt32(professorCmbox.SelectedValue),
                    Convert.ToInt32(pageCmbox.SelectedValue), loggedInAdminId
                );

                // 6. Handle Database Error (e.g., Duplicate ID)
                if (gradeSheetId == -1)
                {
                    // CLEANUP: Delete the file we just copied because it's not valid in the DB
                    if (File.Exists(savedFilePath))
                    {
                        File.Delete(savedFilePath);
                    }

                    MessageBox.Show(
                        "Duplicated Filename Detected in Database. Please change the filename.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    filenameTxtbox.Focus();
                    filenameTxtbox.SelectAll();
                    return;
                }
                ;

                // 7. Success - Update History and UI
                undoHistory.Push(new UndoItem
                {
                    GradeSheetID = gradeSheetId,
                    SourceFilePath = sourcePath,
                    SavedFilePath = savedFilePath
                });

                toUpload.Items.RemoveAt(0);
                DisplayCurrentImage();
                MessageBox.Show("Grade sheet saved successfully.");

                // 8. Log Activity
                ActivityLogger.LogGradesheetUpload(yearCmbox.Text, semesterCmbox.Text, courseCmbox.Text, professorCmbox.Text);

                // 9. Refresh Dashboard if open (To update charts immediately)
                if (Application.OpenForms["frmDashboard"] is frmDashboard dash)
                {
                    dash.RefreshActivityLog(); // Assuming you have a public refresh method
                    // dash.LoadDashboardCounts(); // If you have this method made public
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            // 10. Reset Form if Keep is not checked
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

        // --- HELPER METHODS ---

        private string BuildImageFolderPath()
        {
            return Path.Combine(baseImagePath, SanitizePath(yearCmbox.Text), SanitizePath(semesterCmbox.Text));
        }

        private string SanitizePath(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars()) input = input.Replace(c.ToString(), "");
            return input.Trim();
        }

        // --- THESE METHODS WERE WRONGLY PLACED IN COMBOITEM BEFORE ---
        // --- NOW THEY ARE CORRECTLY INSIDE THE FORM CLASS ---
        private void btnCourse_Click(object sender, EventArgs e)
        {
            frmNewCourse openCouse = new frmNewCourse();
            openCouse.ShowDialog();

            if (openCouse.DialogResult == DialogResult.OK)
            {
                LoadCourses();
            }
        }

        private void btnProf_Click(object sender, EventArgs e)
        {
            newFaculty NewFaculty = new newFaculty();
            NewFaculty.ShowDialog();

            if (NewFaculty.DialogResult == DialogResult.OK)
            {
                LoadProfessors();
            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            frmnewProgram newPrograms = new frmnewProgram();
            newPrograms.ShowDialog();
            if (newPrograms.DialogResult == DialogResult.OK)
            {
                LoadPrograms();
            }
        }

        // Duplicate method names you had before, linking them to the same logic or removing if unused
        private void btnOpenCouse_Click(object sender, EventArgs e)
        {
            btnCourse_Click(sender, e);
        }

        private void createNewFaculty_Click(object sender, EventArgs e)
        {
            btnProf_Click(sender, e);
        }

        // Empty events (Can be removed if not linked in Designer)
        private void saveBtn_Click_1(object sender, EventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }

    } // <--- END OF FORM CLASS

    // =========================
    // HELPER CLASSES (OUTSIDE)
    // =========================

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
