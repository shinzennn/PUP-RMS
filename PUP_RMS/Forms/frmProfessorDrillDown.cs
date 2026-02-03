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

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Rectangle _closeBtnRect, _maxBtnRect;
        private bool _isHoveringClose, _isHoveringMax;

        private string _headerTitle;
        private const int CS_DROPSHADOW = 0x00020000;

        public frmProfessorDrillDown(string facultyName, string sy, string curr)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(950, 600); // Widened slightly to accommodate more columns
            this.BackColor = Color.White;
            this.Padding = new Padding(2, 50, 2, 2);

            _headerTitle = $"Academic Load & Status: {facultyName}";

            InitializeUI();
            LoadData(facultyName, sy, curr);

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

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
                EnableHeadersVisualStyles = false,
                GridColor = Color.LightGray
            };

            dgvDetails.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(5),
            };

            dgvDetails.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(5),
                SelectionBackColor = ClrGold,
                SelectionForeColor = Color.Black
            };

            dgvDetails.ColumnHeadersHeight = 45;
            dgvDetails.RowTemplate.Height = 40;

            // Add CellFormatting to color-code the Status column
            dgvDetails.CellFormatting += DgvDetails_CellFormatting;

            this.Controls.Add(dgvDetails);
        }

        private void LoadData(string name, string sy, string curr)
        {
            // Assuming DashboardHelper.GetGradeSheetsByFaculty calls the updated SP
            DataTable dt = DashboardHelper.GetGradeSheetsByFaculty(name, sy, curr);
            dgvDetails.DataSource = dt;

            // Formatting columns based on new SP results
            if (dgvDetails.Columns["Status"] != null)
            {
                dgvDetails.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvDetails.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvDetails.Columns["Sem"] != null) dgvDetails.Columns["Sem"].Width = 80;
            if (dgvDetails.Columns["Year Level"] != null) dgvDetails.Columns["Year Level"].HeaderText = "Year";
        }

        private void DgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Logic to color the "Status" column
            if (dgvDetails.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Gradesheet uploaded")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (status == "No Grade Sheet")
                {
                    e.CellStyle.ForeColor = Color.Firebrick;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                e.Graphics.FillRectangle(brush, 0, 0, Width, 50);

            using (Font f = new Font("Segoe UI Semibold", 12))
                e.Graphics.DrawString(_headerTitle, f, new SolidBrush(ClrGold), 20, 14);

            DrawWindowButtons(e.Graphics);

            using (Pen innerBorder = new Pen(Color.FromArgb(180, 180, 180), 1))
                e.Graphics.DrawRectangle(innerBorder, 0, 0, Width - 1, Height - 1);
        }

        private void DrawWindowButtons(Graphics g)
        {
            _closeBtnRect = new Rectangle(Width - 37, 13, 24, 24);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - 37, 13, 24, 24);

            if (_isHoveringClose) g.FillEllipse(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), _closeBtnRect);
            if (_isHoveringMax) g.FillEllipse(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), _maxBtnRect);

            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                g.DrawEllipse(p, _closeBtnRect);
                g.DrawLine(p, _closeBtnRect.X + 7, _closeBtnRect.Y + 7, _closeBtnRect.Right - 7, _closeBtnRect.Bottom - 7);
                g.DrawLine(p, _closeBtnRect.Right - 7, _closeBtnRect.Y + 7, _closeBtnRect.X + 7, _closeBtnRect.Bottom - 7);

                g.DrawEllipse(p, _maxBtnRect);
                g.DrawRectangle(p, _maxBtnRect.X + 7, _maxBtnRect.Y + 7, 10, 10);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_closeBtnRect.Contains(e.Location)) { this.Close(); return; }

            if (_maxBtnRect.Contains(e.Location))
            {
                this.WindowState = (this.WindowState == FormWindowState.Maximized)
                                   ? FormWindowState.Normal : FormWindowState.Maximized;
                return;
            }

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

            Cursor = (hoverClose || hoverMax) ? Cursors.Hand : Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e) { dragging = false; }
    }
}