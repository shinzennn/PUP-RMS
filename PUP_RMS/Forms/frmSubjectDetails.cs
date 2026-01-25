using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PUP_RMS.Helper; // This connects to your DashboardHelper

namespace PUP_RMS.Forms
{
    public partial class frmSubjectDetails : Form
    {
        private string _subjectName;

        // ==============================
        // COLORS & VARIABLES
        // ==============================
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);

        // Window Dragging Variables
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Button Hit Zones
        private Rectangle _closeBtnRect;
        private Rectangle _maxBtnRect;
        private bool _isHoveringClose = false;
        private bool _isHoveringMax = false;

        // Grid
        private DataGridView dgv;

        public frmSubjectDetails(string subjectName)
        {
            InitializeComponent();
            _subjectName = subjectName;

            // Enable Double Buffering for smooth rendering
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            SetupFormDesign();
        }

        private void frmSubjectDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SetupFormDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Size = new Size(700, 450); // Adjusted size to fit data better
            this.BackColor = Color.White;
            this.Padding = new Padding(0);

            // Wire up Mouse Events for dragging the window
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // --- DATA GRID SETUP ---
            dgv = new DataGridView
            {
                Name = "dgvDetails",
                Location = new Point(0, 50), // Position below the 50px header
                Size = new Size(Width, Height - 50),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                GridColor = Color.WhiteSmoke,
                RowTemplate = { Height = 35 }
            };

            // Header Style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(214, 161, 46), // Gold
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(5),
                SelectionBackColor = Color.FromArgb(214, 161, 46)
            };

            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Row Style
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = ClrMaroon, // Maroon highlight
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(5, 0, 0, 0)
            };

            dgv.DefaultCellStyle = rowStyle;

            // --- DEFINE COLUMNS ---

            // 1. Course Code
            dgv.Columns.Add("colCode", "Course Code");
            dgv.Columns["colCode"].Width = 120;

            // 2. Faculty Name (Fills remaining space)
            dgv.Columns.Add("colFaculty", "Faculty Name");
            dgv.Columns["colFaculty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // 3. Curriculum Year
            dgv.Columns.Add("colCurrYear", "Curriculum Year");
            dgv.Columns["colCurrYear"].Width = 140;
            dgv.Columns["colCurrYear"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["colCurrYear"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Controls.Add(dgv);

            // Handle Form Resize
            this.Resize += (s, e) =>
            {
                dgv.Size = new Size(Width, Height - 50);
                Invalidate(); // Redraw Header
            };
        }

        private void LoadData()
        {
            // Call the static helper method to get data from SQL
            DataTable dt = DashboardHelper.GetSubjectDetails(_subjectName);

            dgv.Rows.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(
                        row["CourseCode"].ToString(),
                        row["FacultyName"].ToString(),
                        row["CurriculumYear"].ToString()
                    );
                }
            }
            else
            {
                // Optional: You can display a "No records found" row or leave it empty
                // dgv.Rows.Add("N/A", "No records found", "-");
            }
        }

        // ==============================
        // PAINTING (CUSTOM HEADER)
        // ==============================
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. Draw Maroon Header Background
            int headerHeight = 50;
            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);
            using (SolidBrush brush = new SolidBrush(ClrMaroon))
            {
                g.FillRectangle(brush, headerRect);
            }

            // 2. Draw Title
            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(ClrGold))
            {
                // Truncate if title is too long
                string displayTitle = $"Course Details: {_subjectName}";
                if (displayTitle.Length > 60) displayTitle = displayTitle.Substring(0, 57) + "...";

                g.DrawString(displayTitle, titleFont, textBrush, 20, 14);
            }

            // 3. Draw Window Buttons (Close/Max)
            DrawWindowButtons(g);

            // 4. Draw Border around form
            ControlPaint.DrawBorder(g, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void DrawWindowButtons(Graphics g)
        {
            int btnSize = 24;
            int margin = 13;

            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            // Hover Effects
            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
            }

            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                // Close Button (X)
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                float off = 5;
                g.DrawLine(p, cx - off, cy - off, cx + off, cy + off);
                g.DrawLine(p, cx + off, cy - off, cx - off, cy + off);

                // Maximize Button (Box)
                g.DrawEllipse(p, _maxBtnRect);
                float mx = _maxBtnRect.X + _maxBtnRect.Width / 2f;
                float my = _maxBtnRect.Y + _maxBtnRect.Height / 2f;
                float box = 10;
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);
            }
        }

        // ==============================
        // MOUSE EVENTS (DRAGGING & CLICKS)
        // ==============================
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Button Clicks
            if (_closeBtnRect.Contains(e.Location))
            {
                this.Close();
                return;
            }
            if (_maxBtnRect.Contains(e.Location))
            {
                if (WindowState == FormWindowState.Normal)
                {
                    MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                }
                return;
            }

            // Dragging (Only if clicking the top header area)
            if (e.Button == MouseButtons.Left && e.Y < 50)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
                return;
            }

            bool hoverClose = _closeBtnRect.Contains(e.Location);
            bool hoverMax = _maxBtnRect.Contains(e.Location);

            if (hoverClose != _isHoveringClose || hoverMax != _isHoveringMax)
            {
                _isHoveringClose = hoverClose;
                _isHoveringMax = hoverMax;
                Invalidate(new Rectangle(0, 0, Width, 50)); 
            }

            if (hoverClose || hoverMax) Cursor = Cursors.Hand;
            else Cursor = Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}