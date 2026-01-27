using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PUP_RMS.Helper;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionYear_Sem : Form
    {
        // =========================================================
        // THEME COLORS (UNCHANGED)
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

        // Placeholders for the 5 dropdowns
        private string[] placeholders = { "Curriculum", "Program", "Professor", "Subject", "School Year" };

        private const int CS_DROPSHADOW = 0x00020000;

        // Chart Data Variables
        private int _sem1Count = 0;
        private int _sem2Count = 0;
        private int _sem3Count = 0;
        private string _displayLabel = "";

        public frmDistributionYear_Sem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Size = new Size(900, 540);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ClrStandoutBack;

            CreateRoundedFilters();

            // Initial UI State
            _displayLabel = "Please select a filter";

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
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

            int filterWidth = 160;
            int spacing = 8;
            int totalWidth = (filters.Count * filterWidth) + ((filters.Count - 1) * spacing);

            int startX = (this.Width - totalWidth) / 2;
            int fixedY = 85;

            for (int i = 0; i < filters.Count; i++)
            {
                filters[i].SetBounds(startX + (i * (filterWidth + spacing)), fixedY, filterWidth, 30);
            }
        }

        // =========================================================
        // DATA LOADING LOGIC (FIXED: BASED ON LAST VALID SELECTION)
        // =========================================================
        private void LoadChartData()
        {
            try
            {
                _sem1Count = 0;
                _sem2Count = 0;
                _sem3Count = 0;
                _displayLabel = "No Data Found";

                // Check if any filter has a selection (Index > 0)
                bool hasSelection = filters.Any(cb => cb.SelectedIndex > 0);
                if (!hasSelection)
                {
                    _displayLabel = "Please select a filter";
                    this.Invalidate();
                    return;
                }

                // Get current values
                string selCurr = GetFilterValue(0);
                string selProg = GetFilterValue(1);
                string selProf = GetFilterValue(2);
                string selSubj = GetFilterValue(3);
                string selYear = GetFilterValue(4);

                // Query Database
                DataTable dt = DashboardHelper.GetYearSemDistribution(selCurr, selProg, selProf, selSubj, selYear);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Logic to find the Label based on the LAST valid selection
                    if (selYear != null) _displayLabel = selYear;
                    else if (selSubj != null) _displayLabel = selSubj;
                    else if (selProf != null) _displayLabel = selProf;
                    else if (selProg != null) _displayLabel = selProg;
                    else if (selCurr != null) _displayLabel = selCurr;
                    else _displayLabel = "All Selected Data";

                    if (_displayLabel == "All") _displayLabel = "All Data";

                    foreach (DataRow row in dt.Rows)
                    {
                        int sem = 0; int.TryParse(row["Semester"].ToString(), out sem);
                        int count = 0; int.TryParse(row["Total"].ToString(), out count);

                        if (sem == 1) _sem1Count += count;
                        if (sem == 2) _sem2Count += count;
                        if (sem == 3) _sem3Count += count;
                    }
                }
                this.Invalidate();
            }
            catch
            {
                _displayLabel = "Error Loading Data";
                this.Invalidate();
            }
        }

        private string GetFilterValue(int index)
        {
            if (filters.Count <= index) return null;
            ComboBox cb = filters[index];

            // If Placeholder (Index 0) -> return null (treated as "no selection", SQL ignores)
            if (cb.SelectedIndex <= 0) return null;

            // If "All" (Index 1) -> return "All" (SQL Procedure handles this string specifically)
            if (cb.SelectedIndex == 1) return "All";

            return cb.SelectedItem.ToString();
        }

        // =========================================================
        // CASCADING COMBO BOX LOGIC
        // =========================================================
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
                    Size = new Size(160, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    Tag = i
                };

                cb.Items.Add(category); // Index 0 (Placeholder)
                cb.Items.Add("All");      // Index 1 (All)

                if (i == 0) PopulateInitialCurriculum(cb);

                cb.SelectedIndex = 0;
                cb.DrawItem += Cb_DrawItem;
                cb.SelectedIndexChanged += Filter_Changed;

                filters.Add(cb);
                this.Controls.Add(cb);
            }
            RepositionFilters();
        }

        private void PopulateInitialCurriculum(ComboBox cb)
        {
            try
            {
                DataTable dt = DashboardHelper.GetCurriculums();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                        cb.Items.Add(row["CurriculumYear"].ToString());
                }
            }
            catch { }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (!(sender is ComboBox changedCb)) return;
            int index = (int)changedCb.Tag;

            // Cascade: When a filter changes, update those below it
            UpdateSubsequentFilters(index);

            // Refresh chart
            LoadChartData();
        }

        private void UpdateSubsequentFilters(int changedIndex)
        {
            if (changedIndex >= 4) return;

            // Get current values to pass as filters to the next level
            string curr = GetFilterValue(0);
            string prog = GetFilterValue(1);
            string prof = GetFilterValue(2);
            string subj = GetFilterValue(3);

            for (int i = changedIndex + 1; i < filters.Count; i++)
            {
                ComboBox cb = filters[i];
                cb.SelectedIndexChanged -= Filter_Changed;

                cb.Items.Clear();
                cb.Items.Add(placeholders[i]);
                cb.Items.Add("All");

                DataTable dt = null;
                // Only attempt to populate if a valid choice (Value or All) exists in the previous step
                if (filters[i - 1].SelectedIndex > 0)
                {
                    switch (i)
                    {
                        case 1: dt = DashboardHelper.GetProgramsByFilter(curr); break;
                        case 2: dt = DashboardHelper.GetFacultyByFilter(curr, prog); break;
                        case 3: dt = DashboardHelper.GetSubjectsByFilter(curr, prog, prof); break;
                        case 4: dt = DashboardHelper.GetSchoolYearsByFilter(curr, prog, prof, subj); break;
                    }
                }

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string val = row[0].ToString();
                        if (!cb.Items.Contains(val)) cb.Items.Add(val);
                    }
                }

                cb.SelectedIndex = 0;
                cb.SelectedIndexChanged += Filter_Changed;
            }
        }

        // =========================================================
        // DRAWING & UI (UNCHANGED DESIGN)
        // =========================================================
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
            int marginX = Math.Max(50, (int)(this.Width * 0.05));
            int topY = 150;
            int bottomPadding = 50;
            int panelW = this.Width - (marginX * 2);
            int panelH = this.Height - topY - bottomPadding;

            Rectangle innerPanel = new Rectangle(marginX, topY, panelW, panelH);

            using (SolidBrush panelBrush = new SolidBrush(ClrMaroon))
                g.FillRoundedRectangle(panelBrush, innerPanel, 20);

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
            if (_sem1Count == 0 && _sem2Count == 0 && _sem3Count == 0)
            {
                using (Font f = new Font("Segoe UI", 14))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString(_displayLabel, f, Brushes.White, container, sf);
                }
                return;
            }

            int maxVal = Math.Max(_sem1Count, Math.Max(_sem2Count, _sem3Count));
            if (maxVal == 0) maxVal = 100;

            int chartBottom = container.Height - 60;
            int chartHeight = chartBottom - 80;
            int baseY = container.Y + chartBottom;

            int h1 = (int)((double)_sem1Count / maxVal * chartHeight);
            int h2 = (int)((double)_sem2Count / maxVal * chartHeight);
            int h3 = (int)((double)_sem3Count / maxVal * chartHeight);

            if (_sem1Count > 0 && h1 < 10) h1 = 10;
            if (_sem2Count > 0 && h2 < 10) h2 = 10;
            if (_sem3Count > 0 && h3 < 10) h3 = 10;

            int barWidth = Math.Max(40, Math.Min(300, (int)(container.Width * 0.22)));
            int totalBarWidth = barWidth * 3;
            int remainingSpace = container.Width - totalBarWidth;
            int gap = remainingSpace / 4;

            int x1 = container.X + gap;
            int x2 = x1 + barWidth + gap;
            int x3 = x2 + barWidth + gap;

            Rectangle bar1 = new Rectangle(x1, baseY - h1, barWidth, h1);
            Rectangle bar2 = new Rectangle(x2, baseY - h2, barWidth, h2);
            Rectangle bar3 = new Rectangle(x3, baseY - h3, barWidth, h3);

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

            using (Font f = new Font("Segoe UI", 10, FontStyle.Bold))
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center })
            {
                float center1 = x1 + (barWidth / 2f);
                float center2 = x2 + (barWidth / 2f);
                float center3 = x3 + (barWidth / 2f);

                if (_sem1Count > 0) g.DrawString(_sem1Count.ToString(), f, Brushes.White, center1, bar1.Y - 25, sf);
                if (_sem2Count > 0) g.DrawString(_sem2Count.ToString(), f, Brushes.White, center2, bar2.Y - 25, sf);
                if (_sem3Count > 0) g.DrawString(_sem3Count.ToString(), f, Brushes.White, center3, bar3.Y - 25, sf);

                g.DrawString("1st Sem", f, Brushes.White, center1, baseY + 10, sf);
                g.DrawString("2nd Sem", f, Brushes.White, center2, baseY + 10, sf);
                g.DrawString("Summer", f, Brushes.White, center3, baseY + 10, sf);

                using (Font yearFont = new Font("Segoe UI", 11, FontStyle.Bold))
                    g.DrawString($"{_displayLabel}", yearFont, Brushes.White, container.X + 20, container.Y + 20);
            }

            using (Pen p = new Pen(Color.White, 1.5f))
                g.DrawLine(p, container.X + 80, baseY, container.X + container.Width - 80, baseY);
        }

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
            get { CreateParams cp = base.CreateParams; cp.ClassStyle |= CS_DROPSHADOW; return cp; }
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