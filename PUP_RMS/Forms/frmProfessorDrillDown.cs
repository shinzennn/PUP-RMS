using PUP_RMS.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmProfessorDrillDown : Form
    {
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private DataGridView dgvDetails;
        private Label lblTitle;
        private Button btnClose;

        public frmProfessorDrillDown(string facultyName, string sy, string curr)
        {
            // Form Settings
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(800, 500);
            this.BackColor = Color.White;
            this.Padding = new Padding(2); // Border thickness

            InitializeUI(facultyName);
            LoadData(facultyName, sy, curr);
        }

        private void InitializeUI(string facultyName)
        {
            // Header Label
            lblTitle = new Label
            {
                Text = $"Files: {facultyName}",
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = ClrMaroon,
                ForeColor = ClrGold,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };

            // Close Button
            // --- CONTROL BUTTONS (Min, Max, Close) ---

            // 1. Close Button
            btnClose = new Button
            {
                Text = "✕", // Unicode Cross
                Size = new Size(30, 30),
                Location = new Point(lblTitle.Width - 35, 10), // Far Right
                Anchor = AnchorStyles.Top | AnchorStyles.Right, // Keeps it on the right when resized
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Red; // Hover effect
            btnClose.Click += (s, e) => this.Close();

            // 2. Maximize / Restore Button
            Button btnMax = new Button
            {
                Text = "☐", // Unicode Square
                Size = new Size(30, 30),
                Location = new Point(lblTitle.Width - 70, 10), // Left of Close
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMax.Text = "☐"; // Square icon
                }
                else
                {
                    // Prevent covering the taskbar when maximizing
                    this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                    this.WindowState = FormWindowState.Maximized;
                    btnMax.Text = "❐"; // Overlapping squares icon
                }
            };


            // Add buttons to the Title Label
            lblTitle.Controls.Add(btnClose);
            lblTitle.Controls.Add(btnMax);


            // DataGridView
            dgvDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false

            };

            // DGV Styling
            dgvDetails.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(5),
                WrapMode = DataGridViewTriState.True

            };


            dgvDetails.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(5),
                SelectionBackColor = ClrGold,
                SelectionForeColor = Color.Black
            };

            dgvDetails.ColumnHeadersHeight = 50;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetails.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            this.Controls.Add(dgvDetails);
            this.Controls.Add(lblTitle);
        }

        private void LoadData(string name, string sy, string curr)
        {
            DataTable dt = DashboardHelper.GetGradeSheetsByFaculty(name, sy, curr);
            dgvDetails.DataSource = dt;

            dgvDetails.RowTemplate.Height = 42;
            dgvDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            // Optional: Adjust column headers if needed
            if (dgvDetails.Columns["File Name"] != null)
                dgvDetails.Columns["File Name"].HeaderText = "Grade Sheet Filename";
        }

        // Draw a border around the form
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(ClrMaroon, 4))
            {
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
            }
        }

        private void frmProfessorDrillDown_Load(object sender, EventArgs e)
        {

        }
    }
}

