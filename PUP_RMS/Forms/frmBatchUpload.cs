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
        // TEMP: replace with real logged-in admin ID
        private int loggedInAdminId = 1;
        //FOR image path
        private readonly string baseImagePath = Path.Combine(Application.StartupPath, "GradeSheets");


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


        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmBatchUpload_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadProfessors();
            LoadSemester();
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
                $"{yearCmbox.Text}_" +
                $"{semesterCmbox.Text}_" +
                $"{courseCmbox.Text}_" +
                $"{professorCmbox.Text}";
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

            foreach (string file in ofd.FileNames)
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(file));
                item.Tag = file; // full path
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
        // SAVE CURRENT IMAGE DATA
        // =========================
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Queue check
            if (toUpload.Items.Count == 0)
            {
                MessageBox.Show("No images left in the queue.");
                return;
            }

            // Year check
            if (string.IsNullOrWhiteSpace(yearCmbox.Text))
            {
                MessageBox.Show("Please select a School Year.");
                return;
            }

            // Semester check
            if (semesterCmbox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Semester.");
                return;
            }

            // Course check
            if (courseCmbox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Course.");
                return;
            }

            // Professor check
            if (professorCmbox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Professor.");
                return;
            }

            // Filename check
            if (string.IsNullOrWhiteSpace(filenameTxtbox.Text))
            {
                MessageBox.Show("Filename is empty.");
                return;
            }

            // SAFE to use values now
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

            // =========================
            // SAVE IMAGE TO FOLDER
            // =========================

            // Get current image full path
            string sourcePath = toUpload.Items[0].Tag.ToString();

            // Build destination folder
            string destinationFolder = BuildImageFolderPath();

            // Create folder hierarchy if not exists
            Directory.CreateDirectory(destinationFolder);

            // Preserve original extension
            string extension = Path.GetExtension(sourcePath);

            // Final destination file
            string destinationFile = Path.Combine(
                destinationFolder,
                filenameTxtbox.Text + extension
            );

            // Copy image to destination
            File.Copy(sourcePath, destinationFile, true);

            filenameTxtbox.Clear();


            // Remove current image
            toUpload.Items.RemoveAt(0);

            // Show next image
            DisplayCurrentImage();

            MessageBox.Show("Saved successfully. Moving to next image.");
        }

        private string BuildImageFolderPath()
        {
            string year = SanitizePath(yearCmbox.Text);
            string semester = SanitizePath(semesterCmbox.Text);
            string course = SanitizePath(courseCmbox.Text);
            string professor = SanitizePath(professorCmbox.Text);

            return Path.Combine(
                baseImagePath,
                year,
                semester,
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


    }

    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}


