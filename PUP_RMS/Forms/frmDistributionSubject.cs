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

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Rectangle _closeBtnRect;
        private Rectangle _maxBtnRect;
        private bool _isHoveringClose = false;
        private bool _isHoveringMax = false;

        private List<(string Name, int Count)> subjectData;
        private Panel treemapContainer;

        // FILTERS
        private ComboBox cbFilterYear;
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
            SetupFilters();

            // 2. Load Data Immediately
            LoadSchoolYears();
            isLoading = false;
            LoadData();
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
            this.Size = new Size(880, 540);
            this.BackColor = ClrStandoutBack;

            treemapContainer = new Panel
            {
                Location = new Point(0, 50),
                Size = new Size(this.Width, this.Height - 50),
                Padding = new Padding(15),
                BackColor = Color.Transparent
            };

            this.Controls.Add(treemapContainer);

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            this.Resize += (s, e) =>
            {
                treemapContainer.Size = new Size(this.Width, this.Height - 50);
                RenderTreemap();
                this.Invalidate();
            };
        }

        private void SetupFilters()
        {
            // Settings for layout
            int comboWidth = 140;
            int headerHeight = 50;
            int comboHeight = 25;
            int topMargin = (headerHeight - comboHeight) / 2; // Center Vertically (approx 12px)
            int rightMargin = 80; // Space reserved for Close/Max buttons
            int gap = 5; // Space between Label and Combo

            // 1. Setup School Year ComboBox
            cbFilterYear = new ComboBox();
            cbFilterYear.Size = new Size(comboWidth, comboHeight);
            // Position: Width - ButtonSpace - ComboWidth
            cbFilterYear.Location = new Point(this.Width - rightMargin - comboWidth, topMargin);
            cbFilterYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterYear.FlatStyle = FlatStyle.Flat;
            cbFilterYear.BackColor = Color.White;
            cbFilterYear.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // 2. Setup Label "Filter by School Year:"
            Label lblFilter = new Label();
            lblFilter.Text = "Filter by School Year:";
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFilter.ForeColor = ClrGold; // Match Title Color
            lblFilter.BackColor = ClrMaroon; // Match Header Background

            // Position: To the left of the ComboBox
            // We calculate X after creating it so we know its width, but AutoSize happens slightly later.
            // A quick measure or doing it in Paint is common, but setting location here works if AutoSize triggers.
            // For safety, we estimate or set location after adding logic.

            // Add Controls
            this.Controls.Add(cbFilterYear);
            this.Controls.Add(lblFilter);

            // Adjust Label Location now that it's added (to calculate width)
            lblFilter.Location = new Point(cbFilterYear.Left - lblFilter.PreferredWidth - gap, topMargin + 2); // +2 for visual vertical alignment
            lblFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Wire Events
            cbFilterYear.SelectedIndexChanged += Filter_Changed;
        }

        private void LoadSchoolYears()
        {
            try
            {
                DataTable dt = DashboardHelper.GetSchoolYears();
                cbFilterYear.Items.Clear();
                cbFilterYear.Items.Add("All Years");

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cbFilterYear.Items.Add(row["SchoolYear"].ToString());
                    }
                }
                cbFilterYear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Years: " + ex.Message);
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (isLoading) return;
            LoadData();
        }

        private void LoadData()
        {
            subjectData.Clear();

            // 1. Get Values from Filter
            string selectedYear = cbFilterYear.SelectedItem?.ToString();
            if (selectedYear == "All Years") selectedYear = null;

            try
            {
                // 2. Call Helper (Using the Year-Only Logic)
                // Note: Ensure DashboardHelper.GetSubjectDistribution handles a single string argument
                DataTable dt = DashboardHelper.GetSubjectDistribution(selectedYear);

                // 3. Process Data
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

                if (subjectData.Count == 0)
                    subjectData.Add(("No Data Found", 1));
            }
            catch (Exception ex)
            {
                subjectData.Add(("Error", 1));
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

            var sorted = subjectData.OrderByDescending(x => x.Count).ToList();
            double totalWeight = sorted.Sum(x => x.Count);

            if (totalWeight == 0)
            {
                treemapContainer.ResumeLayout();
                return;
            }

            RectangleF drawingArea = new RectangleF(
                treemapContainer.Padding.Left,
                treemapContainer.Padding.Top,
                treemapContainer.Width - treemapContainer.Padding.Horizontal,
                treemapContainer.Height - treemapContainer.Padding.Vertical
            );

            GenerateTreemapTiles(sorted, totalWeight, drawingArea);
            treemapContainer.ResumeLayout();
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