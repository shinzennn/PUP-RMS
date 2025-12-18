using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

        // Window Dragging
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

            // Enable Double Buffering
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            SetupFormDesign();
        }

        private void frmSubjectDetails_Load(object sender, EventArgs e)
        {
            LoadFakeData();
        }

        private void SetupFormDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Size = new Size(580, 400); // Slightly smaller as requested
            this.BackColor = Color.White;
            this.Padding = new Padding(0);

            // Wire up Mouse Events for dragging
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // --- DATA GRID ---
            dgv = new DataGridView
            {
                Name = "dgvDetails",
                // Manually position below the painted header (50px)
                Location = new Point(0, 50),
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
                RowTemplate = { Height = 30 }
            };

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(214, 161, 46),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(5),
                SelectionBackColor = Color.FromArgb(214, 161, 46)
            };

            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.FromArgb(100, 100, 100),
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };

            dgv.DefaultCellStyle = rowStyle;

            dgv.Columns.Add("colFile", "File Name");
            dgv.Columns["colFile"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["colFile"].FillWeight = 50;

            dgv.Columns.Add("colProf", "Uploaded By");
            dgv.Columns["colProf"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["colProf"].FillWeight = 30;

            dgv.Columns.Add("colDate", "Date");
            dgv.Columns["colDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["colDate"].FillWeight = 20;

            this.Controls.Add(dgv);

            // Handle Resize to keep Grid correct
            this.Resize += (s, e) =>
            {
                dgv.Size = new Size(Width, Height - 50);
                Invalidate(); // Redraw Header
            };
        }

        private void LoadFakeData()
        {
            dgv.Rows.Add($"{_subjectName}_Midterm_Grades.pdf", "Prof. Dela Cruz", "2023-10-15");
            dgv.Rows.Add($"{_subjectName}_Final_Grades.xlsx", "Prof. Santos", "2024-01-20");
            dgv.Rows.Add($"{_subjectName}_Masterlist.csv", "Prof. Bautista", "2023-09-05");
        }

        // ==============================
        // PAINTING (HEADER & BUTTONS)
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
                g.DrawString($"Subject Records: {_subjectName}", titleFont, textBrush, 20, 14);
            }

            // 3. Draw Window Buttons
            DrawWindowButtons(g);

            // 4. Draw Border
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
                // Close
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                float off = 5;
                g.DrawLine(p, cx - off, cy - off, cx + off, cy + off);
                g.DrawLine(p, cx + off, cy - off, cx - off, cy + off);

                // Max
                g.DrawEllipse(p, _maxBtnRect);
                float mx = _maxBtnRect.X + _maxBtnRect.Width / 2f;
                float my = _maxBtnRect.Y + _maxBtnRect.Height / 2f;
                float box = 10;
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);
            }
        }

        // ==============================
        // MOUSE EVENTS
        // ==============================
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Buttons
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

            // Dragging (Top 50px)
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