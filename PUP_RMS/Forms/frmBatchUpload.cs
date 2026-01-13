using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PUP_RMS.Core;
using PUP_RMS.Model;


namespace PUP_RMS.Forms
{
    public partial class frmBatchUpload : Form
    {
        private int loggedInAdminId = 1;

        private readonly string baseImagePath =
            Path.Combine(Application.StartupPath, "GradeSheets");

        // Undo stack
        private Stack<UndoItem> undoHistory = new Stack<UndoItem>();

        // ImageLists for thumbnails
        private ImageList uploadImageList;
        private ImageList uploadedImageList;

        public frmBatchUpload()
        {
            InitializeComponent();

            this.Load += frmBatchUpload_Load;

            yearCmbox.SelectedIndexChanged += UpdateFileName;
            semesterCmbox.SelectedIndexChanged += UpdateFileName;
            courseCmbox.SelectedIndexChanged += UpdateFileName;
            professorCmbox.SelectedIndexChanged += UpdateFileName;

            uploadBtn.Click += uploadBtn_Click;
            saveBtn.Click += saveBtn_Click;
            undoBtn.Click += undoBtn_Click;
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmBatchUpload_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadProfessors();
            LoadSemester();
            InitializeImageLists();
        }

        // =========================
        // IMAGE LIST INITIALIZATION
        // =========================
        private void InitializeImageLists()
        {
            uploadImageList = new ImageList
            {
                ImageSize = new Size(96, 96),
                ColorDepth = ColorDepth.Depth32Bit
            };

            uploadedImageList = new ImageList
            {
                ImageSize = new Size(96, 96),
                ColorDepth = ColorDepth.Depth32Bit
            };

            toUpload.View = View.LargeIcon;
            uploadedImgs.View = View.LargeIcon;

            toUpload.LargeImageList = uploadImageList;
            uploadedImgs.LargeImageList = uploadedImageList;
        }

        // =========================
        // LOAD COMBOBOX DATA
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
            professorCmbox.DisplayMember = "FullName";
            professorCmbox.ValueMember = "ProfessorID";
            professorCmbox.SelectedIndex = -1;
        }

        private void LoadSemester()
        {
            semesterCmbox.DataSource = new List<ComboItem>
            {
                new ComboItem { Text = "1st Semester", Value = 1 },
                new ComboItem { Text = "2nd Semester", Value = 2 },
                new ComboItem { Text = "Summer", Value = 3 }
            };

            semesterCmbox.DisplayMember = "Text";
            semesterCmbox.ValueMember = "Value";
            semesterCmbox.SelectedIndex = -1;
        }

        // =========================
        // AUTO FILENAME
        // =========================
        private void UpdateFileName(object sender, EventArgs e)
        {
            if (yearCmbox.SelectedItem == null ||
                semesterCmbox.SelectedItem == null ||
                courseCmbox.SelectedItem == null ||
                professorCmbox.SelectedItem == null)
                return;

            filenameTxtbox.Text =
                $"{yearCmbox.Text}_{semesterCmbox.Text}_{courseCmbox.Text}_{professorCmbox.Text}";
        }

        // =========================
        // CREATE THUMBNAIL
        // =========================
        private Image CreateThumbnail(string path)
        {
            using (Image img = Image.FromFile(path))
            {
                return img.GetThumbnailImage(96, 96, () => false, IntPtr.Zero);
            }
        }

        // =========================
        // UPLOAD IMAGES
        // =========================
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            toUpload.Items.Clear();
            uploadedImgs.Items.Clear();
            uploadImageList.Images.Clear();
            uploadedImageList.Images.Clear();
            undoHistory.Clear();

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

        // =========================
        // DISPLAY CURRENT IMAGE
        // =========================
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
            using (Bitmap bmp = new Bitmap(path))
            {
                currentImage.Image = new Bitmap(bmp);
            }
        }

        // =========================
        // SAVE IMAGE
        // =========================
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (toUpload.Items.Count == 0)
            {
                MessageBox.Show("No images left.");
                return;
            }

            if (semesterCmbox.SelectedValue == null ||
                courseCmbox.SelectedValue == null ||
                professorCmbox.SelectedValue == null ||
                string.IsNullOrWhiteSpace(yearCmbox.Text) ||
                string.IsNullOrWhiteSpace(filenameTxtbox.Text))
            {
                MessageBox.Show("Complete all required fields.");
                return;
            }

            bool success = DbControl.InsertGradeSheet(
                filenameTxtbox.Text,
                yearCmbox.Text,
                Convert.ToInt32(semesterCmbox.SelectedValue),
                Convert.ToInt32(courseCmbox.SelectedValue),
                Convert.ToInt32(professorCmbox.SelectedValue),
                loggedInAdminId
            );

            if (!success)
            {
                MessageBox.Show("Failed to save record.");
                return;
            }

            string sourcePath = toUpload.Items[0].Tag.ToString();
            string folder = BuildImageFolderPath();
            Directory.CreateDirectory(folder);

            string ext = Path.GetExtension(sourcePath);
            string savedPath = Path.Combine(folder, filenameTxtbox.Text + ext);

            File.Copy(sourcePath, savedPath, true);

            undoHistory.Push(new UndoItem
            {
                FileName = filenameTxtbox.Text,
                SourceFilePath = sourcePath,
                SavedFilePath = savedPath
            });

            Image thumb = CreateThumbnail(savedPath);
            uploadedImageList.Images.Add(savedPath, thumb);

            uploadedImgs.Items.Add(new ListViewItem(Path.GetFileName(savedPath))
            {
                ImageKey = savedPath
            });

            toUpload.Items.RemoveAt(0);
            filenameTxtbox.Clear();
            DisplayCurrentImage();

            MessageBox.Show("Saved successfully.");
        }

        // =========================
        // FOR UNDOING LAST UPLOAD
        // =========================
        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (undoHistory.Count == 0)
            {
                MessageBox.Show("Nothing to undo.");
                return;
            }

            UndoItem undo = undoHistory.Pop();

            DbControl.DeleteGradeSheetByFilename(undo.FileName);

            if (File.Exists(undo.SavedFilePath))
                File.Delete(undo.SavedFilePath);

            Image thumb = CreateThumbnail(undo.SourceFilePath);
            uploadImageList.Images.Add(undo.SourceFilePath, thumb);

            ListViewItem restored = new ListViewItem(
                Path.GetFileName(undo.SourceFilePath))
            {
                Tag = undo.SourceFilePath,
                ImageKey = undo.SourceFilePath
            };

            toUpload.Items.Insert(0, restored);

            if (uploadedImgs.Items.Count > 0)
                uploadedImgs.Items.RemoveAt(uploadedImgs.Items.Count - 1);

            DisplayCurrentImage();

            MessageBox.Show("Undo completed.");
        }

        // =========================
        // PATH HELPERS
        // =========================
        private string BuildImageFolderPath()
        {
            return Path.Combine(
                baseImagePath,
                SanitizePath(yearCmbox.Text),
                SanitizePath(semesterCmbox.Text),
                SanitizePath(courseCmbox.Text),
                SanitizePath(professorCmbox.Text)
            );
        }

        private string SanitizePath(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                input = input.Replace(c.ToString(), "");
            return input.Trim();
        }
    }

    // =========================
    // SUPPORT MODELS
    // =========================
    public class UndoItem
    {
        public string FileName { get; set; }
        public string SourceFilePath { get; set; }
        public string SavedFilePath { get; set; }
    }

    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}


