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
        // --- 1. THEME COLORS & VARIABLES (Copied from Source Form) ---
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private DataGridView dgvDetails;

        // Window Dragging & Interaction Variables
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Rectangle _closeBtnRect, _maxBtnRect;
        private bool _isHoveringClose, _isHoveringMax;

        // To store the title for painting
        private string _headerTitle;

        // Shadow Constant
        private const int CS_DROPSHADOW = 0x00020000;

        public frmProfessorDrillDown(string facultyName, string sy, string curr)
        {
            // --- 2. FORM SETTINGS & OPTIMIZATION ---
            // Set double buffering for smooth rendering (prevents flickering)
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(800, 500);
            this.BackColor = Color.White;

            // Set Padding: Top 50 is reserved for the drawn header
            this.Padding = new Padding(2, 50, 2, 2);

            _headerTitle = $"Files: {facultyName}";

            InitializeUI(); // Setup DGV only
            LoadData(facultyName, sy, curr);

            // Hook up Mouse Events for dragging and custom buttons
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        // --- 3. DROP SHADOW ---
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void InitializeUI()
        {
            // We removed lblTitle, btnClose, btnMax because we will DRAW them instead.

            // DataGridView Setup
            dgvDetails = new DataGridView
            {
                Dock = DockStyle.Fill, // Fills the area inside the Padding (below the 50px header)
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
        }

        private void LoadData(string name, string sy, string curr)
        {
            DataTable dt = DashboardHelper.GetGradeSheetsByFaculty(name, sy, curr);
            dgvDetails.DataSource = dt;

            dgvDetails.RowTemplate.Height = 42;
            dgvDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvDetails.Columns["File Name"] != null)
                dgvDetails.Columns["File Name"].HeaderText = "Grade Sheet Filename";
        }

        // --- 4. CUSTOM DRAWING (HEADER & BUTTONS) ---
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            // 1. Draw Maroon Header Background
            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                e.Graphics.FillRectangle(brush, 0, 0, Width, 50);

            // 2. Draw Title Text
            using (Font f = new Font("Segoe UI Semibold", 12))
                e.Graphics.DrawString(_headerTitle, f, new SolidBrush(ClrGold), 20, 14);

            // 3. Draw Window Controls (Close/Max)
            DrawWindowButtons(e.Graphics);

            // 4. Draw Border around the rest of the form
            using (Pen innerBorder = new Pen(Color.FromArgb(180, 180, 180), 1))
                e.Graphics.DrawRectangle(innerBorder, 0, 0, Width - 1, Height - 1);
        }

        private void DrawWindowButtons(Graphics g)
        {
            _closeBtnRect = new Rectangle(Width - 37, 13, 24, 24);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - 37, 13, 24, 24);

            // Hover Effects
            if (_isHoveringClose) g.FillEllipse(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), _closeBtnRect);
            if (_isHoveringMax) g.FillEllipse(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), _maxBtnRect);

            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                // Close Button (X)
                g.DrawEllipse(p, _closeBtnRect);
                g.DrawLine(p, _closeBtnRect.X + 7, _closeBtnRect.Y + 7, _closeBtnRect.Right - 7, _closeBtnRect.Bottom - 7);
                g.DrawLine(p, _closeBtnRect.Right - 7, _closeBtnRect.Y + 7, _closeBtnRect.X + 7, _closeBtnRect.Bottom - 7);

                // Maximize Button (Square)
                g.DrawEllipse(p, _maxBtnRect);
                g.DrawRectangle(p, _maxBtnRect.X + 7, _maxBtnRect.Y + 7, 10, 10);
            }
        }

        // --- 5. MOUSE LOGIC (DRAGGING & CLICKS) ---
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Check for Close Click
            if (_closeBtnRect.Contains(e.Location))
            {
                this.Close();
                return;
            }

            // Check for Maximize Click
            if (_maxBtnRect.Contains(e.Location))
            {
                this.WindowState = (this.WindowState == FormWindowState.Maximized)
                                   ? FormWindowState.Normal
                                   : FormWindowState.Maximized;
                return;
            }

            // Check for Dragging (Left click on header area < 50px)
            if (e.Button == MouseButtons.Left && e.Y < 50)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // Handle Dragging
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
                return;
            }

            // Handle Hover Logic for Buttons
            bool hoverClose = _closeBtnRect.Contains(e.Location);
            bool hoverMax = _maxBtnRect.Contains(e.Location);

            if (hoverClose != _isHoveringClose || hoverMax != _isHoveringMax)
            {
                _isHoveringClose = hoverClose;
                _isHoveringMax = hoverMax;
                // Redraw only the header to update hover effect
                Invalidate(new Rectangle(0, 0, Width, 50));
            }

            Cursor = (hoverClose || hoverMax) ? Cursors.Hand : Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}