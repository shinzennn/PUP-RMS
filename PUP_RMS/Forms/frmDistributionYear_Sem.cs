using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PUP_RMS.Helper;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionYear_Sem : Form
    {
        // =========================================================
        // THEME COLORS
        // =========================================================
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrStandoutBack = Color.FromArgb(224, 227, 231);
        private readonly Color ClrSilver = Color.FromArgb(180, 190, 200);
        private readonly Color ClrBronze = Color.FromArgb(205, 127, 50);

        // =========================================================
        // INTERACTION VARIABLES
        // =========================================================
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Rectangle _closeBtnRect, _maxBtnRect;
        private bool _isHoveringClose, _isHoveringMax;

        private List<ComboBox> filters = new List<ComboBox>();
        private string[] placeholders = { "Program", "Professor", "Subject", "School Year" };
        private const int CS_DROPSHADOW = 0x00020000;

        private int _sem1Count = 0;
        private int _sem2Count = 0;
        private int _sem3Count = 0;
        private string _latestYear = "N/A";

        public frmDistributionYear_Sem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Size = new Size(880, 540);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ClrStandoutBack;

            CreateRoundedFilters();
            LoadChartData();

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // Hook up the Resize event to handle control positioning
            this.Resize += FrmDistributionYear_Sem_Resize;
        }

        private void FrmDistributionYear_Sem_Resize(object sender, EventArgs e)
        {
            RepositionFilters();
            this.Invalidate();
        }

        private void RepositionFilters()
        {
            if (filters.Count == 0) return;

            int filterWidth = 190;
            int spacing = 10;
            int totalWidth = (filters.Count * filterWidth) + ((filters.Count - 1) * spacing);

            int startX = (this.Width - totalWidth) / 2;
            int fixedY = 85;

            for (int i = 0; i < filters.Count; i++)
            {
                filters[i].SetBounds(startX + (i * (filterWidth + spacing)), fixedY, filterWidth - 25, 30);
            }
        }

        private void LoadChartData()
        {
            try
            {
                string selProg = GetFilterValue(0);
                string selProf = GetFilterValue(1);
                string selSubj = GetFilterValue(2);
                string selYear = GetFilterValue(3);

                DataTable dt = DashboardHelper.GetYearSemDistribution(selProg, selProf, selSubj, selYear);

                _sem1Count = 0; _sem2Count = 0; _sem3Count = 0;
                _latestYear = "No Data";

                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(selYear)) _latestYear = selYear;
                    else _latestYear = dt.Rows[0]["SchoolYear"].ToString();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["SchoolYear"].ToString() == _latestYear)
                        {
                            int sem = 0; int.TryParse(row["Semester"].ToString(), out sem);
                            int count = 0; int.TryParse(row["Total"].ToString(), out count);

                            if (sem == 1) _sem1Count = count;
                            if (sem == 2) _sem2Count = count;
                            if (sem == 3) _sem3Count = count;
                        }
                    }
                }
                this.Invalidate();
            }
            catch { }
        }

        private string GetFilterValue(int index)
        {
            if (filters.Count <= index) return null;
            ComboBox cb = filters[index];
            if (cb.SelectedIndex <= 0) return null;
            return cb.SelectedItem.ToString();
        }

        private void Filter_Changed(object sender, EventArgs e) => LoadChartData();

        private void CreateRoundedFilters()
        {
            for (int i = 0; i < placeholders.Length; i++)
            {
                string category = placeholders[i];
                ComboBox cb = new ComboBox
                {
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 10),
                    Size = new Size(165, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    Tag = category
                };

                cb.Items.Add(category);
                cb.SelectedIndex = 0;
                PopulateDropdownFromDB(cb, category);
                cb.DrawItem += Cb_DrawItem;
                cb.SelectedIndexChanged += Filter_Changed;

                if (category == "School Year" && cb.Items.Count > 1) cb.SelectedIndex = 1;

                filters.Add(cb);
                this.Controls.Add(cb);
            }
            RepositionFilters();
        }

        private void PopulateDropdownFromDB(ComboBox cb, string category)
        {
            try
            {
                DataTable dt;
                switch (category)
                {
                    case "Program":
                        dt = DashboardHelper.GetProgramDistribution();
                        foreach (DataRow row in dt.Rows) { string val = row["Label"].ToString(); if (!cb.Items.Contains(val)) cb.Items.Add(val); }
                        break;
                    case "Professor":
                        dt = DashboardHelper.GetFacultyDistribution();
                        foreach (DataRow row in dt.Rows) { string val = row["Name"].ToString(); if (!cb.Items.Contains(val)) cb.Items.Add(val); }
                        break;
                    case "Subject":
                        dt = DashboardHelper.GetSubjectDistribution();
                        foreach (DataRow row in dt.Rows) { string val = row["SubjectName"].ToString(); if (!cb.Items.Contains(val)) cb.Items.Add(val); }
                        break;
                    case "School Year":
                        dt = DashboardHelper.GetYearSemDistribution();
                        foreach (DataRow row in dt.Rows) { string val = row["SchoolYear"].ToString(); if (!cb.Items.Contains(val)) cb.Items.Add(val); }
                        break;
                }
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. Header
            using (SolidBrush headerBrush = new SolidBrush(ClrMaroon))
                g.FillRectangle(headerBrush, 0, 0, Width, 50);

            using (Font f = new Font("Segoe UI", 12, FontStyle.Bold))
                g.DrawString("Academic Year & Semester Grade Sheets Distribution", f, new SolidBrush(ClrGold), 20, 14);

            DrawWindowButtons(g);

            // 2. Filter Borders
            foreach (var cb in filters)
            {
                using (Pen p = new Pen(ClrGold, 1.5f))
                {
                    Rectangle rect = new Rectangle(cb.Left - 2, cb.Top - 2, cb.Width + 4, cb.Height + 4);
                    g.DrawRoundedRectangle(p, rect, 8);
                }
            }

            // 3. Dynamic Chart Background
            int marginX = (int)(this.Width * 0.05); // 5% margin
            if (marginX < 50) marginX = 50;

            int topY = 150;
            int bottomPadding = 50;
            int panelW = this.Width - (marginX * 2);
            int panelH = this.Height - topY - bottomPadding;

            Rectangle innerPanel = new Rectangle(marginX, topY, panelW, panelH);

            using (SolidBrush panelBrush = new SolidBrush(ClrMaroon))
            {
                g.FillRoundedRectangle(panelBrush, innerPanel, 20);
            }

            // 4. Vertical Text
            using (Font verticalFont = new Font("Segoe UI Semibold", 8))
            {
                g.TranslateTransform(innerPanel.X + 25, innerPanel.Y + (innerPanel.Height / 2) + 50);
                g.RotateTransform(-90);
                g.DrawString("TOTAL GRADE SHEETS", verticalFont, Brushes.WhiteSmoke, 0, 0);
                g.ResetTransform();
            }

            DrawBars(g, innerPanel);

            // 5. Border
            using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private void DrawBars(Graphics g, Rectangle container)
        {
            // 1. Max Value Calculation
            int maxVal = Math.Max(_sem1Count, Math.Max(_sem2Count, _sem3Count));
            if (maxVal == 0) maxVal = 100;

            // 2. Dimensions
            int chartBottom = container.Height - 60;
            int chartHeight = chartBottom - 80;
            int baseY = container.Y + chartBottom;

            // 3. Calculate Bar Heights
            int h1 = (int)((double)_sem1Count / maxVal * chartHeight);
            int h2 = (int)((double)_sem2Count / maxVal * chartHeight);
            int h3 = (int)((double)_sem3Count / maxVal * chartHeight);

            if (_sem1Count > 0 && h1 < 10) h1 = 10;
            if (_sem2Count > 0 && h2 < 10) h2 = 10;
            if (_sem3Count > 0 && h3 < 10) h3 = 10;

            // ==========================================
            // 4. IMPROVED RESPONSIVE LOGIC HERE
            // ==========================================

            // Calculate a responsive bar width (e.g., 22% of container width)
            int barWidth = (int)(container.Width * 0.22);

            // Apply sensible limits
            if (barWidth > 300) barWidth = 300; // Cap at 300px wide
            if (barWidth < 40) barWidth = 40;   // Minimum 40px

            // Calculate remaining space after bars are drawn
            int totalBarWidth = barWidth * 3;
            int remainingSpace = container.Width - totalBarWidth;

            // Divide remaining space into 4 gaps (Left, Mid1, Mid2, Right)
            int gap = remainingSpace / 4;

            // Calculate X Coordinates
            int x1 = container.X + gap;
            int x2 = x1 + barWidth + gap;
            int x3 = x2 + barWidth + gap;

            Rectangle bar1 = new Rectangle(x1, baseY - h1, barWidth, h1);
            Rectangle bar2 = new Rectangle(x2, baseY - h2, barWidth, h2);
            Rectangle bar3 = new Rectangle(x3, baseY - h3, barWidth, h3);

            // 5. Draw Bars
            if (h1 > 0)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(bar1, ClrGold, Color.Orange, 90f))
                    g.FillRoundedRectangle(lgb, bar1, 10);
            }
            if (h2 > 0)
            {
                using (SolidBrush silverBrush = new SolidBrush(ClrSilver))
                    g.FillRoundedRectangle(silverBrush, bar2, 10);
            }
            if (h3 > 0)
            {
                using (SolidBrush bronzeBrush = new SolidBrush(ClrBronze))
                    g.FillRoundedRectangle(bronzeBrush, bar3, 10);
            }

            // 6. Draw Text Labels
            using (Font f = new Font("Segoe UI", 10, FontStyle.Bold))
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center })
            {
                // Numbers on top (Centered based on X + half Width)
                float center1 = x1 + (barWidth / 2f);
                float center2 = x2 + (barWidth / 2f);
                float center3 = x3 + (barWidth / 2f);

                g.DrawString(_sem1Count.ToString(), f, Brushes.White, center1, bar1.Y - 25, sf);
                g.DrawString(_sem2Count.ToString(), f, Brushes.White, center2, bar2.Y - 25, sf);
                g.DrawString(_sem3Count.ToString(), f, Brushes.White, center3, bar3.Y - 25, sf);

                // Labels below
                g.DrawString("1st Sem", f, Brushes.White, center1, baseY + 10, sf);
                g.DrawString("2nd Sem", f, Brushes.White, center2, baseY + 10, sf);
                g.DrawString("Summer", f, Brushes.White, center3, baseY + 10, sf);

                // School Year Label
                using (Font yearFont = new Font("Segoe UI", 11, FontStyle.Bold))
                {
                    g.DrawString($"School Year: {_latestYear}", yearFont, Brushes.White, container.X + 20, container.Y + 20);
                }
            }

            // Baseline
            using (Pen p = new Pen(Color.White, 1.5f))
                g.DrawLine(p, container.X + 80, baseY, container.X + container.Width - 80, baseY);
        }

        // =========================================================
        // UI HELPERS
        // =========================================================
        private void Cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            ComboBox cb = (ComboBox)sender;
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);

            string text = cb.Items[e.Index].ToString();
            bool isPlaceholder = (e.Index == 0);

            Color textColor = isPlaceholder ? Color.Gray : Color.Black;
            Font textFont = isPlaceholder ? new Font(cb.Font, FontStyle.Italic) : cb.Font;

            TextRenderer.DrawText(e.Graphics, text, textFont, e.Bounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void DrawWindowButtons(Graphics g)
        {
            _closeBtnRect = new Rectangle(Width - 37, 13, 24, 24);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - 37, 13, 24, 24);

            if (_isHoveringClose) g.FillEllipse(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), _closeBtnRect);
            if (_isHoveringMax) g.FillEllipse(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), _maxBtnRect);

            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                g.DrawEllipse(p, _closeBtnRect);
                g.DrawLine(p, _closeBtnRect.X + 7, _closeBtnRect.Y + 7, _closeBtnRect.Right - 7, _closeBtnRect.Bottom - 7);
                g.DrawLine(p, _closeBtnRect.Right - 7, _closeBtnRect.Y + 7, _closeBtnRect.X + 7, _closeBtnRect.Bottom - 7);
                g.DrawEllipse(p, _maxBtnRect);
                g.DrawRectangle(p, _maxBtnRect.X + 7, _maxBtnRect.Y + 7, 10, 10);
            }
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

        public static void ShowWithDimmer(Form parent, frmDistributionYear_Sem child)
        {
            using (Form dimmer = new Form())
            {
                dimmer.StartPosition = FormStartPosition.Manual;
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.AllowTransparency = true;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.45;
                dimmer.Size = parent.Size;
                dimmer.Location = parent.Location;
                dimmer.ShowInTaskbar = false;
                dimmer.Show();
                child.Owner = dimmer;
                child.ShowDialog();
                dimmer.Close();
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_closeBtnRect.Contains(e.Location)) this.Close();
            else if (_maxBtnRect.Contains(e.Location)) this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
            else if (e.Button == MouseButtons.Left && e.Y < 50)
            { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) this.Location = Point.Add(dragFormPoint, new Size(Point.Subtract(Cursor.Position, new Size(dragCursorPoint))));
            _isHoveringClose = _closeBtnRect.Contains(e.Location);
            _isHoveringMax = _maxBtnRect.Contains(e.Location);
            Invalidate(new Rectangle(0, 0, Width, 50));
            Cursor = (_isHoveringClose || _isHoveringMax) ? Cursors.Hand : Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e) => dragging = false;

        private void frmDistributionYear_Sem_Load(object sender, EventArgs e) { }
    }

    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle bounds, int radius)
        {
            using (GraphicsPath path = RoundedRect(bounds, radius)) g.DrawPath(pen, path);
        }

        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int radius)
        {
            using (GraphicsPath path = RoundedRect(bounds, radius)) g.FillPath(brush, path);
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}