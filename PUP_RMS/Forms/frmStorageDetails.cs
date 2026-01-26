using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmStorageDetails : Form
    {
        private readonly string _rootPath;

        public frmStorageDetails()
        {
            InitializeComponent();

            // 1. Define the path
            _rootPath = Path.Combine(Application.StartupPath, "GradeSheets");

            // 2. Setup the columns immediately
            SetupGrid();
        }

        private void frmStorageDetails_Load(object sender, EventArgs e)
        {
            // DEBUG: Uncomment the line below if the list is still empty to see the path!
            // MessageBox.Show("Looking for files in:\n" + _rootPath);

            LoadFiles();
        }

        private void SetupGrid()
        {
            // We use the grid you created in the Designer named 'dgvStorage'
            if (dgvStorage == null) return;

            dgvStorage.AllowUserToAddRows = false;
            dgvStorage.AllowUserToDeleteRows = false;
            dgvStorage.ReadOnly = true;
            dgvStorage.RowHeadersVisible = false;
            dgvStorage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStorage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStorage.BackgroundColor = Color.White;
            dgvStorage.BorderStyle = BorderStyle.None;

            // Reset Columns to ensure they are correct
            dgvStorage.Columns.Clear();
            dgvStorage.Columns.Add("colName", "File Name");
            dgvStorage.Columns.Add("colFolder", "Folder / Semester");
            dgvStorage.Columns.Add("colSize", "Size");
            dgvStorage.Columns.Add("colDate", "Date Modified");

            // Formatting
            dgvStorage.Columns["colSize"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStorage.Columns["colDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Style
            dgvStorage.EnableHeadersVisualStyles = false;
            dgvStorage.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 0, 0); // Maroon
            dgvStorage.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStorage.ColumnHeadersHeight = 35;
        }

        private void LoadFiles()
        {
            if (dgvStorage == null) return;

            dgvStorage.Rows.Clear();

            // Check if folder exists
            if (!Directory.Exists(_rootPath))
            {
                // Create it so the user doesn't get an error, but the list will be empty
                Directory.CreateDirectory(_rootPath);
                return;
            }

            try
            {
                DirectoryInfo dir = new DirectoryInfo(_rootPath);

                // Get all files
                FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo f in files)
                {
                    // Calculate Subfolder path (e.g. "2025\1st Sem")
                    string folderName = f.DirectoryName.Replace(_rootPath, "");
                    if (folderName.StartsWith("\\")) folderName = folderName.Substring(1);
                    if (string.IsNullOrEmpty(folderName)) folderName = "Root Folder";

                    dgvStorage.Rows.Add(
                        f.Name,
                        folderName,
                        FormatBytes(f.Length),
                        f.LastWriteTime.ToString("yyyy-MM-dd HH:mm")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading files: " + ex.Message);
            }
        }

        private string FormatBytes(long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }
            return String.Format("{0:0.00} {1}", dblSByte, suffix[i]);
        }
    }
}