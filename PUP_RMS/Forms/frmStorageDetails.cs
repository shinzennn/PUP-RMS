using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmStorageDetails : Form
    {
        private readonly string _rootPath;

        // ==============================
        // DESIGN COLORS & VARIABLES
        // ==============================
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrTextGray = Color.DimGray; // Color for the values

        // Window Dragging Variables
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Button Hit Zones
        private Rectangle _closeBtnRect;
        private Rectangle _maxBtnRect;
        private bool _isHoveringClose = false;
        private bool _isHoveringMax = false;

        public frmStorageDetails()
        {
            InitializeComponent();

            // 1. Enable Double Buffering (Fixes flickering)
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            // 2. Define Path
            _rootPath = Path.Combine(Application.StartupPath, "GradeSheets");

            // 3. Setup Events
            this.Load += frmStorageDetails_Load;

            // 4. Setup Custom Form Design
            SetupFormDesign();
        }

        private void frmStorageDetails_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void SetupFormDesign()
        {
            // --- FORM PROPERTIES ---
            this.FormBorderStyle = FormBorderStyle.None; // Remove default Windows border
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Size = new Size(600, 500); // Default Size
            this.BackColor = Color.White;
            this.Padding = new Padding(1); // Thin border padding

            // --- MOUSE EVENTS (For Dragging & Buttons) ---
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // --- SETUP GRID ---
            SetupGrid();
        }

        private void SetupGrid()
        {
            if (dgvStorage == null) return;

            // Positioning: Leave 50px at top for the custom header
            dgvStorage.Location = new Point(1, 51);
            dgvStorage.Size = new Size(this.Width - 2, this.Height - 52);
            dgvStorage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // General Style
            dgvStorage.BackgroundColor = Color.White;
            dgvStorage.BorderStyle = BorderStyle.None;
            dgvStorage.GridColor = Color.WhiteSmoke;
            dgvStorage.RowTemplate.Height = 35;

            // Read-Only & Interaction
            dgvStorage.ReadOnly = true;
            dgvStorage.AllowUserToAddRows = false;
            dgvStorage.AllowUserToDeleteRows = false;
            dgvStorage.AllowUserToResizeRows = false;
            dgvStorage.AllowUserToResizeColumns = true;
            dgvStorage.RowHeadersVisible = false;
            dgvStorage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStorage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // --- HEADER STYLE ---
            dgvStorage.EnableHeadersVisualStyles = false; // Required to change header colors
            dgvStorage.ColumnHeadersDefaultCellStyle.BackColor = ClrGold;
            dgvStorage.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // FIX: Prevent Blue Highlight on Header Click
            dgvStorage.ColumnHeadersDefaultCellStyle.SelectionBackColor = ClrGold;
            dgvStorage.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvStorage.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStorage.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStorage.ColumnHeadersHeight = 45;
            dgvStorage.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // --- ROW STYLE (Values) ---
            dgvStorage.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStorage.DefaultCellStyle.BackColor = Color.White;
            dgvStorage.DefaultCellStyle.ForeColor = ClrTextGray; // <--- SET VALUES TO GRAY

            // Selection Colors (Maroon Background, White Text)
            dgvStorage.DefaultCellStyle.SelectionBackColor = ClrMaroon;
            dgvStorage.DefaultCellStyle.SelectionForeColor = Color.White;

            // --- COLUMNS ---
            dgvStorage.Columns.Clear();

            // Column 1: File Name
            dgvStorage.Columns.Add("colName", "File Name");
            dgvStorage.Columns["colName"].FillWeight = 70;
            dgvStorage.Columns["colName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvStorage.Columns["colName"].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvStorage.Columns["colName"].SortMode = DataGridViewColumnSortMode.NotSortable; // <--- DISABLE SORT

            // Column 2: Size
            dgvStorage.Columns.Add("colSize", "Size");
            dgvStorage.Columns["colSize"].FillWeight = 30;
            dgvStorage.Columns["colSize"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStorage.Columns["colSize"].SortMode = DataGridViewColumnSortMode.NotSortable; // <--- DISABLE SORT
        }

        private void LoadFiles()
        {
            if (dgvStorage == null) return;

            dgvStorage.Rows.Clear();

            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }

            try
            {
                DirectoryInfo dir = new DirectoryInfo(_rootPath);
                FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo f in files)
                {
                    dgvStorage.Rows.Add(
                        f.Name,
                        FormatBytes(f.Length)
                    );
                }
                dgvStorage.ClearSelection();
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
                g.DrawString("Storage Details", titleFont, textBrush, 20, 14);
            }

            // 3. Draw Window Buttons
            DrawWindowButtons(g);

            // 4. Draw Border around entire form
            ControlPaint.DrawBorder(g, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void DrawWindowButtons(Graphics g)
        {
            int btnSize = 24;
            int margin = 13;

            // Define button areas
            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            // Hover Effects Background
            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
            }

            // Draw Icons (Gold Color)
            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                // Close Button (X)
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                float off = 5;
                g.DrawLine(p, cx - off, cy - off, cx + off, cy + off);
                g.DrawLine(p, cx + off, cy - off, cx - off, cy + off);

                // Maximize Button (Square)
                g.DrawEllipse(p, _maxBtnRect);
                float mx = _maxBtnRect.X + _maxBtnRect.Width / 2f;
                float my = _maxBtnRect.Y + _maxBtnRect.Height / 2f;
                float box = 9;
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);
            }
        }

        // ==============================
        // MOUSE EVENTS (DRAG & CLICKS)
        // ==============================
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Close Button Click
            if (_closeBtnRect.Contains(e.Location))
            {
                this.Close();
                return;
            }

            // Maximize Button Click
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
                Invalidate(); // Redraw needed to update button positions
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
            // 1. Handle Dragging
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
                return;
            }

            // 2. Handle Hover Effects
            bool hoverClose = _closeBtnRect.Contains(e.Location);
            bool hoverMax = _maxBtnRect.Contains(e.Location);

            // Only redraw if state changed (Performance optimization)
            if (hoverClose != _isHoveringClose || hoverMax != _isHoveringMax)
            {
                _isHoveringClose = hoverClose;
                _isHoveringMax = hoverMax;
                Invalidate(new Rectangle(0, 0, Width, 50)); // Redraw only the header
            }

            // Change Cursor
            if (hoverClose || hoverMax) Cursor = Cursors.Hand;
            else Cursor = Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dgvStorage_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}