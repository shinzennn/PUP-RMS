using PUP_RMS.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionSubject : Form
    {
        // ==============================
        // COLORS & VARIABLES
        // ==============================
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrStandoutBack = Color.FromArgb(224, 227, 231);
        private readonly Color ClrTextGray = Color.FromArgb(64, 64, 64);

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Rectangle _closeBtnRect;
        private Rectangle _maxBtnRect;
        private bool _isHoveringClose = false;
        private bool _isHoveringMax = false;

        private List<(string Name, int Count)> subjectData;
        private Panel treemapContainer;

        // ==============================
        // FILTER CONTROLS
        // ==============================
        private Label lblCurriculum;
        private ComboBox cmbCurriculum;

        private Label lblSchoolYear;
        private ComboBox cmbSchoolYear;

        private Label lblSemester;
        private ComboBox cmbSemester;

        private bool isLoading = true;

        private const int CS_DROPSHADOW = 0x00020000;

        public frmDistributionSubject()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            subjectData = new List<(string Name, int Count)>();

            // 1. Setup UI
            SetupFormDesign();
            SetupFilterControls(); // New Filter Setup

            // 2. Load Data
            // We start the chain: LoadCurriculum -> LoadSchoolYear -> LoadSemester -> LoadData
            LoadCurriculumCombo();
        }

        // Ensures the Treemap draws correctly after the form animation finishes
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RenderTreemap();
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

        public static void ShowWithDimmer(Form parent, frmDistributionSubject child)
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

        private void SetupFormDesign()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Size = new Size(950, 600); // Slightly larger to fit 3 filters comfortably
            this.BackColor = ClrStandoutBack;

            // TREEMAP CONTAINER
            // Pushed down to Y=100 to allow space for filters below the 50px header
            treemapContainer = new Panel
            {
                Location = new Point(0, 100),
                Size = new Size(this.Width, this.Height - 100),
                Padding = new Padding(15),
                BackColor = Color.Transparent
            };

            this.Controls.Add(treemapContainer);

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            this.Resize += (s, e) =>
            {
                treemapContainer.Size = new Size(this.Width, this.Height - 100);
                RepositionFilterControls(); // Keep filters centered on resize
                RenderTreemap();
                this.Invalidate();
            };
        }

        // =========================================================
        // 1. SETUP FILTER CONTROLS (Curriculum, Year, Semester)
        // =========================================================
        private void SetupFilterControls()
        {
            Font lblFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font cmbFont = new Font("Segoe UI", 9, FontStyle.Regular);

            // --- 1. Curriculum ---
            lblCurriculum = new Label { Text = "Curriculum:", ForeColor = ClrTextGray, BackColor = Color.Transparent, Font = lblFont, AutoSize = true };
            cmbCurriculum = new ComboBox { Font = cmbFont, DropDownStyle = ComboBoxStyle.DropDownList, Width = 130, BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            cmbCurriculum.SelectedIndexChanged += (s, e) => { LoadSchoolYearCombo(); };

            // --- 2. School Year ---
            lblSchoolYear = new Label { Text = "School Year:", ForeColor = ClrTextGray, BackColor = Color.Transparent, Font = lblFont, AutoSize = true };
            cmbSchoolYear = new ComboBox { Font = cmbFont, DropDownStyle = ComboBoxStyle.DropDownList, Width = 130, BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            cmbSchoolYear.SelectedIndexChanged += (s, e) => { LoadSemesterCombo(); };

            // --- 3. Semester ---
            lblSemester = new Label { Text = "Semester:", ForeColor = ClrTextGray, BackColor = Color.Transparent, Font = lblFont, AutoSize = true };
            cmbSemester = new ComboBox { Font = cmbFont, DropDownStyle = ComboBoxStyle.DropDownList, Width = 130, BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            cmbSemester.SelectedIndexChanged += (s, e) => { LoadData(); };

            // Add to Controls
            this.Controls.Add(lblCurriculum);
            this.Controls.Add(cmbCurriculum);
            this.Controls.Add(lblSchoolYear);
            this.Controls.Add(cmbSchoolYear);
            this.Controls.Add(lblSemester);
            this.Controls.Add(cmbSemester);

            RepositionFilterControls();
        }

        // =========================================================
        // CENTER ALIGNMENT LOGIC
        // =========================================================
        private void RepositionFilterControls()
        {
            if (lblCurriculum == null || cmbCurriculum == null) return;

            int headerHeight = 50;
            int filterAreaHeight = 50; // The area between header and treemap
            int yPos = headerHeight + 12; // Vertically centered in the filter area
            int padding = 5; // Space between Label and Combo
            int groupSpacing = 25; // Space between groups

            // Calculate Widths
            int group1W = lblCurriculum.Width + padding + cmbCurriculum.Width;
            int group2W = lblSchoolYear.Width + padding + cmbSchoolYear.Width;
            int group3W = lblSemester.Width + padding + cmbSemester.Width;

            int totalWidth = group1W + groupSpacing + group2W + groupSpacing + group3W;
            int startX = (this.Width - totalWidth) / 2;

            // Apply Positions
            // Group 1: Curriculum
            lblCurriculum.Location = new Point(startX, yPos + 3);
            cmbCurriculum.Location = new Point(lblCurriculum.Right + padding, yPos);

            // Group 2: School Year
            int startX2 = cmbCurriculum.Right + groupSpacing;
            lblSchoolYear.Location = new Point(startX2, yPos + 3);
            cmbSchoolYear.Location = new Point(lblSchoolYear.Right + padding, yPos);

            // Group 3: Semester
            int startX3 = cmbSchoolYear.Right + groupSpacing;
            lblSemester.Location = new Point(startX3, yPos + 3);
            cmbSemester.Location = new Point(lblSemester.Right + padding, yPos);
        }

        // =========================================================
        // DATA LOADING CHAIN
        // =========================================================
        private void LoadCurriculumCombo()
        {
            isLoading = true;
            cmbCurriculum.Items.Clear();
            cmbCurriculum.Items.Add("All");

            try
            {
                DataTable dt = DashboardHelper.GetCurriculums();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                        cmbCurriculum.Items.Add(row["CurriculumYear"].ToString());
                }
            }
            catch { }
            cmbCurriculum.SelectedIndex = 0; // Triggers LoadSchoolYearCombo
        }

        private void LoadSchoolYearCombo()
        {
            string selectedCurr = cmbCurriculum.SelectedItem?.ToString();
            cmbSchoolYear.Items.Clear();
            cmbSchoolYear.Items.Add("All");

            try
            {
                // Assuming helper takes curriculum as optional filter
                DataTable dt = DashboardHelper.GetSchoolYears(selectedCurr);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                        cmbSchoolYear.Items.Add(row["SchoolYear"].ToString());
                }
            }
            catch { }
            cmbSchoolYear.SelectedIndex = 0; // Triggers LoadSemesterCombo
        }

        private void LoadSemesterCombo()
        {
            // If you have a helper for semesters, use it. Otherwise, hardcode standard ones.
            cmbSemester.Items.Clear();
            cmbSemester.Items.Add("All");
            cmbSemester.Items.Add("1st Semester");
            cmbSemester.Items.Add("2nd Semester");
            cmbSemester.Items.Add("Summer");

            cmbSemester.SelectedIndex = 0; // Triggers LoadData
            isLoading = false;
            LoadData(); // Final Trigger
        }

        private void LoadData()
        {
            if (isLoading) return;

            subjectData.Clear();

            // 1. Get Values
            string selCurriculum = cmbCurriculum.SelectedItem?.ToString();
            string selYear = cmbSchoolYear.SelectedItem?.ToString();
            string selSem = cmbSemester.SelectedItem?.ToString();

            // Clean "All" values to null
            if (selCurriculum == "All") selCurriculum = null;
            if (selYear == "All") selYear = null;
            if (selSem == "All") selSem = null;

            try
            {
                // Correct Order: Curriculum, Year, Semester
                DataTable dt = DashboardHelper.GetSubjectDistribution(selCurriculum, selYear, selSem);

                int limit = 18;
                int othersCount = 0;

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        string name = row["SubjectName"].ToString();
                        int count = Convert.ToInt32(row["Count"]);

                        if (i < limit)
                        {
                            subjectData.Add((name, count));
                        }
                        else
                        {
                            othersCount += count;
                        }
                    }
                }

                if (othersCount > 0)
                {
                    subjectData.Add(("Others", othersCount));
                }

                // --- REMOVED THE "No Data Found" ADDITION HERE ---
                // We leave subjectData empty if no rows found.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Leave subjectData empty on error too
            }

            // 4. Render
            RenderTreemap();
        }   
        // ==========================================
        // PAINTING & WINDOW CONTROLS
        // ==========================================

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Draw Header Bar
            Rectangle headerRect = new Rectangle(0, 0, Width, 50);
            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                g.FillRectangle(brush, headerRect);

            // Draw Title
            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(ClrGold))
                g.DrawString("Course Distribution", titleFont, textBrush, 20, 14);

            DrawWindowButtons(g);

            // Draw Border
            using (Pen borderPen = new Pen(Color.FromArgb(150, 150, 150), 1))
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private void DrawWindowButtons(Graphics g)
        {
            int btnSize = 24;
            int margin = 13;
            // Positioned at the very right
            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
            }

            using (Pen p = new Pen(ClrGold, 1.5f))
            {
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                g.DrawLine(p, cx - 5, cy - 5, cx + 5, cy + 5);
                g.DrawLine(p, cx + 5, cy - 5, cx - 5, cy + 5);

                g.DrawEllipse(p, _maxBtnRect);
                g.DrawRectangle(p, _maxBtnRect.X + 7, _maxBtnRect.Y + 7, 10, 10);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_closeBtnRect.Contains(e.Location)) { this.Close(); return; }
            if (_maxBtnRect.Contains(e.Location))
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
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

        private void Form_MouseUp(object sender, MouseEventArgs e) => dragging = false;

        // ==========================================
        // TREEMAP LOGIC
        // ==========================================

        private void RenderTreemap()
        {
            if (treemapContainer == null || treemapContainer.Width <= 0 || treemapContainer.Height <= 0) return;

            treemapContainer.SuspendLayout();
            treemapContainer.Controls.Clear();

            // --- CHECK FOR NO DATA ---
            if (subjectData.Count == 0)
            {
                ShowNoDataMessage();
                treemapContainer.ResumeLayout();
                return;
            }

            // Reset background to Transparent if we have data
            treemapContainer.BackColor = Color.Transparent;

            var sorted = subjectData.OrderByDescending(x => x.Count).ToList();
            double totalWeight = sorted.Sum(x => x.Count);

            RectangleF drawingArea = new RectangleF(
                treemapContainer.Padding.Left,
                treemapContainer.Padding.Top,
                treemapContainer.Width - treemapContainer.Padding.Horizontal,
                treemapContainer.Height - treemapContainer.Padding.Vertical
            );

            GenerateTreemapTiles(sorted, totalWeight, drawingArea);
            treemapContainer.ResumeLayout();
        }

        // --- NEW HELPER METHOD ---
        private void ShowNoDataMessage()
        {
            // Set container background to white
            treemapContainer.BackColor = Color.White;

            Label lblNoData = new Label();
            lblNoData.Text = "No Data Found";
            lblNoData.Font = new Font("Segoe UI", 16, FontStyle.Regular); // Clean font
            lblNoData.ForeColor = Color.Gray;
            lblNoData.AutoSize = true;

            // Calculate center position
            // We use a temporary size measurement to center it perfectly before adding it
            Size textSize = TextRenderer.MeasureText(lblNoData.Text, lblNoData.Font);
            int x = (treemapContainer.Width - textSize.Width) / 2;
            int y = (treemapContainer.Height - textSize.Height) / 2;

            lblNoData.Location = new Point(x, y);

            treemapContainer.Controls.Add(lblNoData);
        }

        private void GenerateTreemapTiles(List<(string Name, int Count)> data, double total, RectangleF area)
        {
            if (data.Count == 0 || area.Width <= 5 || area.Height <= 5) return;

            var firstItem = data[0];
            double ratio = firstItem.Count / total;
            RectangleF currentTile;
            RectangleF remainingArea;

            if (area.Width > area.Height)
            {
                float width = (float)(area.Width * ratio);
                currentTile = new RectangleF(area.X, area.Y, width, area.Height);
                remainingArea = new RectangleF(area.X + width, area.Y, area.Width - width, area.Height);
            }
            else
            {
                float height = (float)(area.Height * ratio);
                currentTile = new RectangleF(area.X, area.Y, area.Width, height);
                remainingArea = new RectangleF(area.X, area.Y + height, area.Width, area.Height - height);
            }

            CreateTileControl(firstItem.Name, firstItem.Count, currentTile);

            if (data.Count > 1)
                GenerateTreemapTiles(data.Skip(1).ToList(), total - firstItem.Count, remainingArea);
        }

        private void CreateTileControl(string name, int count, RectangleF rect)
        {
            Rectangle originalBounds = Rectangle.Round(rect);
            string countText = $"{count} Grade Sheets";

            Button tile = new Button
            {
                Text = string.Empty,
                Bounds = originalBounds,
                FlatStyle = FlatStyle.Flat,
                BackColor = GetColorForValue(count),
                Cursor = Cursors.Hand,
                Tag = (name, originalBounds)
            };

            tile.FlatAppearance.BorderSize = 2;
            tile.FlatAppearance.BorderColor = ClrStandoutBack;

            tile.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                float subjectFontSize = GetMaxFontSize(g, name, tile.Width - 8, tile.Height * 0.5f, "Segoe UI", FontStyle.Bold);
                float countFontSize = Math.Max(5.5f, subjectFontSize * 0.75f);

                using (Font subjectFont = new Font("Segoe UI", subjectFontSize, FontStyle.Bold))
                using (Font countFont = new Font("Segoe UI", countFontSize, FontStyle.Regular))
                {
                    Size subSz = TextRenderer.MeasureText(name, subjectFont, new Size(tile.Width - 4, tile.Height), TextFormatFlags.WordBreak);
                    Size cntSz = TextRenderer.MeasureText(countText, countFont, new Size(tile.Width - 4, tile.Height), TextFormatFlags.WordBreak);

                    int totalH = subSz.Height + cntSz.Height;
                    int startY = (tile.Height - totalH) / 2;

                    Rectangle subRect = new Rectangle(2, startY, tile.Width - 4, subSz.Height);
                    TextRenderer.DrawText(g, name, subjectFont, subRect, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.VerticalCenter);

                    Rectangle cntRect = new Rectangle(2, startY + subSz.Height, tile.Width - 4, cntSz.Height);
                    TextRenderer.DrawText(g, countText, countFont, cntRect, Color.FromArgb(255, 230, 150),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.Top);
                }
            };

            tile.Click += Tile_Click;
            tile.MouseEnter += Tile_MouseEnter;
            tile.MouseLeave += Tile_MouseLeave;

            ApplyRoundedCorners(tile, 12);
            treemapContainer.Controls.Add(tile);
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            if (sender is Button tile && tile.Tag is ValueTuple<string, Rectangle> data)
            {
                if (data.Item1 != "No Data Found" && data.Item1 != "No Data Uploaded")
                {
                    frmSubjectDetails details = new frmSubjectDetails(data.Item1);
                    details.StartPosition = FormStartPosition.CenterParent;
                    details.ShowDialog();
                }
            }
        }

        private float GetMaxFontSize(Graphics g, string text, float maxWidth, float maxHeight, string fontName, FontStyle style)
        {
            float fontSize = 14f;
            while (fontSize > 5f)
            {
                using (Font f = new Font(fontName, fontSize, style))
                {
                    Size sz = TextRenderer.MeasureText(text, f, new Size((int)maxWidth, (int)maxHeight), TextFormatFlags.WordBreak);
                    if (sz.Width <= maxWidth && sz.Height <= maxHeight) return fontSize;
                }
                fontSize -= 0.5f;
            }
            return 5f;
        }

        private void Tile_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button tile && tile.Tag is ValueTuple<string, Rectangle> data)
            {
                Rectangle rect = data.Item2;
                int expansion = 5;
                tile.Bounds = new Rectangle(rect.X - expansion, rect.Y - expansion,
                                           rect.Width + (expansion * 2), rect.Height + (expansion * 2));
                tile.BringToFront();
                ApplyRoundedCorners(tile, 14);
            }
        }

        private void Tile_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button tile && tile.Tag is ValueTuple<string, Rectangle> data)
            {
                tile.Bounds = data.Item2;
                ApplyRoundedCorners(tile, 12);
            }
        }

        private Color GetColorForValue(int value)
        {
            if (value >= 600) return Color.FromArgb(100, 25, 25);
            if (value >= 500) return Color.FromArgb(140, 40, 40);
            if (value >= 400) return Color.FromArgb(175, 80, 50);
            if (value >= 300) return Color.FromArgb(200, 110, 60);
            if (value >= 200) return Color.FromArgb(220, 150, 70);
            return Color.FromArgb(214, 161, 46);
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            if (control.Width <= radius || control.Height <= radius) return;
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }
    }
}