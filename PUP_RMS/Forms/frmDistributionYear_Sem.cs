    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Data;
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

            // =========================================================
            // DATA VARIABLES
            // =========================================================
            private int _sem1Count = 0;
            private int _sem2Count = 0;
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

                // 1. Create Dropdowns
                CreateRoundedFilters();

                // 2. Load Data
                LoadChartData();

                this.MouseDown += Form_MouseDown;
                this.MouseMove += Form_MouseMove;
                this.MouseUp += Form_MouseUp;
            }

      

        private void LoadChartData()
        {
            try
            {
                // 1. Get values from the 4 Dropdowns using the helper above
                // 0=Program, 1=Professor, 2=Subject, 3=School Year
                string selProg = GetFilterValue(0);
                string selProf = GetFilterValue(1);
                string selSubj = GetFilterValue(2);
                string selYear = GetFilterValue(3);

                // 2. Call the NEW Helper method that handles filters
                // (Make sure you updated DashboardHelper with GetFilteredYearSemDistribution as discussed)
                DataTable dt = DashboardHelper.GetYearSemDistribution(selProg, selProf, selSubj, selYear);

                _sem1Count = 0;
                _sem2Count = 0;
                _latestYear = "No Data";

                if (dt.Rows.Count > 0)
                {
                    // If the user selected a specific year, use that as the label.
                    // Otherwise, use the latest year found in the database.
                    if (!string.IsNullOrEmpty(selYear))
                        _latestYear = selYear;
                    else
                        _latestYear = dt.Rows[0]["SchoolYear"].ToString();

                    foreach (DataRow row in dt.Rows)
                    {
                        // Logic: Only count numbers for the year being displayed
                        if (row["SchoolYear"].ToString() == _latestYear)
                        {
                            int sem = 0;
                            int.TryParse(row["Semester"].ToString(), out sem);

                            int count = 0;
                            int.TryParse(row["Total"].ToString(), out count);

                            if (sem == 1) _sem1Count = count;
                            if (sem == 2) _sem2Count = count;
                        }
                    }
                }

                // 3. Redraw the chart with new numbers
                this.Invalidate();
            }
            catch { }
        }


 
        private string GetFilterValue(int index)
        {
            if (filters.Count <= index) return null;

            ComboBox cb = filters[index];

            // If Index is 0, it is the Placeholder (e.g. "Program"), so return null.
            // If Index > 0, it is a real value (e.g. "BSIT"), so return the text.
            if (cb.SelectedIndex <= 0) return null;

            return cb.SelectedItem.ToString();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadChartData();
        }

        // REPLACE YOUR EXISTING METHOD WITH THIS
        private void CreateRoundedFilters()
        {
            int startX = 60;
            int width = 190;

            for (int i = 0; i < placeholders.Length; i++)
            {
                string category = placeholders[i];

                ComboBox cb = new ComboBox
                {
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 10),
                    Size = new Size(width - 25, 30),
                    Location = new Point(startX + (i * width), 85),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    Tag = category
                };

                // 1. Add Placeholder (Index 0)
                cb.Items.Add(category);
                cb.SelectedIndex = 0; // Default to placeholder

                // 2. Fill with DB Data
                PopulateDropdownFromDB(cb, category);

                cb.DrawItem += Cb_DrawItem;

                // 3. Hook up the event so the graph changes when user selects something
                cb.SelectedIndexChanged += Filter_Changed;

                // === CHANGE IS HERE ===
                // If this is the "School Year" box, select the latest year automatically.
                // We check Count > 1 because Index 0 is the placeholder.
                if (category == "School Year" && cb.Items.Count > 1)
                {
                    // Index 1 is the most recent year because SQL sorts DESC
                    cb.SelectedIndex = 1;
                }
                // ======================

                filters.Add(cb);
                this.Controls.Add(cb);
            }
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
                            foreach (DataRow row in dt.Rows)
                            {
                                string val = row["Label"].ToString();
                                if (!cb.Items.Contains(val)) cb.Items.Add(val);
                            }
                            break;
                        case "Professor":
                            dt = DashboardHelper.GetFacultyDistribution();
                            foreach (DataRow row in dt.Rows)
                            {
                                string val = row["Name"].ToString();
                                if (!cb.Items.Contains(val)) cb.Items.Add(val);
                            }
                            break;
                        case "Subject":
                            dt = DashboardHelper.GetSubjectDistribution();
                            foreach (DataRow row in dt.Rows)
                            {
                                string val = row["SubjectName"].ToString();
                                if (!cb.Items.Contains(val)) cb.Items.Add(val);
                            }
                            break;
                        case "School Year":
                            dt = DashboardHelper.GetYearSemDistribution();
                            foreach (DataRow row in dt.Rows)
                            {
                                string val = row["SchoolYear"].ToString();
                                if (!cb.Items.Contains(val)) cb.Items.Add(val);
                            }
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

                // Header
                using (SolidBrush headerBrush = new SolidBrush(ClrMaroon))
                    g.FillRectangle(headerBrush, 0, 0, Width, 50);

                using (Font f = new Font("Segoe UI", 12, FontStyle.Bold))
                    g.DrawString("Academic Year & Semester Grade Sheets Distribution", f, new SolidBrush(ClrGold), 20, 14);

                DrawWindowButtons(g);

                // Filter Borders
                foreach (var cb in filters)
                {
                    using (Pen p = new Pen(ClrGold, 1.5f))
                    {
                        Rectangle rect = new Rectangle(cb.Left - 2, cb.Top - 2, cb.Width + 4, cb.Height + 4);
                        // THIS IS THE EXTENSION METHOD
                        g.DrawRoundedRectangle(p, rect, 8);
                    }
                }

                // Chart Background
                Rectangle innerPanel = new Rectangle(100, 150, 700, 340);
                using (SolidBrush panelBrush = new SolidBrush(ClrMaroon))
                {
                    // THIS IS THE EXTENSION METHOD
                    g.FillRoundedRectangle(panelBrush, innerPanel, 20);
                }

                DrawSelectionLabel(g, innerPanel);

                // Vertical Text
                using (Font verticalFont = new Font("Segoe UI Semibold", 8))
                {
                    g.TranslateTransform(innerPanel.X + 25, innerPanel.Y + 220);
                    g.RotateTransform(-90);
                    g.DrawString("TOTAL GRADE SHEETS", verticalFont, Brushes.WhiteSmoke, 0, 0);
                    g.ResetTransform();
                }

                DrawBars(g, innerPanel);

                // Border
                using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                    g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }

            private void DrawBars(Graphics g, Rectangle container)
            {
                int maxVal = Math.Max(_sem1Count, _sem2Count);
                if (maxVal == 0) maxVal = 100;

                int chartHeight = container.Height - 140;
                int baseY = container.Y + container.Height - 60;

                int h1 = (int)((double)_sem1Count / maxVal * chartHeight);
                int h2 = (int)((double)_sem2Count / maxVal * chartHeight);

                if (_sem1Count > 0 && h1 < 10) h1 = 10;
                if (_sem2Count > 0 && h2 < 10) h2 = 10;

                Rectangle bar1 = new Rectangle(container.X + 180, baseY - h1, 75, h1);
                if (h1 > 0)
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(bar1, ClrGold, Color.Orange, 90f))
                        g.FillRoundedRectangle(lgb, bar1, 10);
                }

                Rectangle bar2 = new Rectangle(container.X + 400, baseY - h2, 75, h2);
                if (h2 > 0)
                {
                    using (SolidBrush silverBrush = new SolidBrush(ClrSilver))
                        g.FillRoundedRectangle(silverBrush, bar2, 10);
                }

                using (Font f = new Font("Segoe UI", 10, FontStyle.Bold))
                {
                    g.DrawString(_sem1Count.ToString(), f, Brushes.White, bar1.X + 18, bar1.Y - 25);
                    g.DrawString(_sem2Count.ToString(), f, Brushes.White, bar2.X + 18, bar2.Y - 25);
                    g.DrawString("1st Sem", f, Brushes.White, bar1.X + 10, baseY + 10);
                    g.DrawString("2nd Sem", f, Brushes.White, bar2.X + 10, baseY + 10);
                    using (Font yearFont = new Font("Segoe UI", 11, FontStyle.Bold))
                    {
                        g.DrawString($"School Year: {_latestYear}", yearFont, Brushes.White, container.X + 20, container.Y + 20);
                    }
                }

                using (Pen p = new Pen(Color.White, 1.5f))
                    g.DrawLine(p, container.X + 80, baseY, container.X + container.Width - 80, baseY);
            }

            private void DrawSelectionLabel(Graphics g, Rectangle container)
            {
                List<string> displayParts = new List<string>();
                foreach (var cb in filters) displayParts.Add(cb.Text.ToUpper());
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

        // =========================================================
        // THIS CLASS IS REQUIRED FOR THE EXTENSION METHODS
        // =========================================================
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

                // Top Left
                path.AddArc(arc, 180, 90);

                // Top Right
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                // Bottom Right
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // Bottom Left
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                return path;
            }
        }
    }