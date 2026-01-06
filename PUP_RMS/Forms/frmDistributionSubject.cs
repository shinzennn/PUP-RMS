using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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

        private const int CS_DROPSHADOW = 0x00020000;

        public frmDistributionSubject()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            subjectData = new List<(string Name, int Count)>
            {
                ("Programming 1", 550), ("History", 680), ("Physics", 520),
                ("Web Dev", 410), ("Accounting", 320), ("Calculus", 250),
                ("Pathfit", 200), ("Physics 1", 180), ("Ethics", 70), ("Rizal", 40),
                ("Webdev", 200), ("Physics 2", 180), ("UTS", 70), ("Bonifacio", 40),
                ("OS", 250), ("MMW", 130), ("DSA", 210), ("DSA", 130), 
            };

            SetupFormDesign();
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

        private void frmDistributionSubject_Load(object sender, EventArgs e) => RenderTreemap();

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle headerRect = new Rectangle(0, 0, Width, 50);
            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                g.FillRectangle(brush, headerRect);

            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(ClrGold))
                g.DrawString("Grade Sheets Distribution by Subject", titleFont, textBrush, 20, 14);

            DrawWindowButtons(g);

            using (Pen borderPen = new Pen(Color.FromArgb(150, 150, 150), 1))
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private void DrawWindowButtons(Graphics g)
        {
            int btnSize = 24;
            int margin = 13;
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

        private void RenderTreemap()
        {
            if (treemapContainer == null || treemapContainer.Width == 0 || treemapContainer.Height == 0) return;
            treemapContainer.SuspendLayout();
            treemapContainer.Controls.Clear();

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

        // ============================================================
        // MODIFIED TILE CREATION WITH RESPONSIVE FONT & TEXT FORMATTING
        // ============================================================
        private void CreateTileControl(string name, int count, RectangleF rect)
        {
            Rectangle originalBounds = Rectangle.Round(rect);
            string countText = $"{count} Grade Sheets";

            Button tile = new Button
            {
                Text = string.Empty, // We draw the text manually below
                Bounds = originalBounds,
                FlatStyle = FlatStyle.Flat,
                BackColor = GetColorForValue(count),
                Cursor = Cursors.Hand,
                Tag = (name, originalBounds) // Stores both for Click and Hover events
            };

            tile.FlatAppearance.BorderSize = 2;
            tile.FlatAppearance.BorderColor = ClrStandoutBack;

            // --- RE-ADDED DRAWING LOGIC ---
            tile.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Calculate dynamic font sizes based on tile size
                float subjectFontSize = GetMaxFontSize(g, name, tile.Width - 8, tile.Height * 0.5f, "Segoe UI", FontStyle.Bold);
                float countFontSize = Math.Max(5.5f, subjectFontSize * 0.75f);

                using (Font subjectFont = new Font("Segoe UI", subjectFontSize, FontStyle.Bold))
                using (Font countFont = new Font("Segoe UI", countFontSize, FontStyle.Regular))
                {
                    // Measure text to center it vertically as a block
                    Size subSz = TextRenderer.MeasureText(name, subjectFont, new Size(tile.Width - 4, tile.Height), TextFormatFlags.WordBreak);
                    Size cntSz = TextRenderer.MeasureText(countText, countFont, new Size(tile.Width - 4, tile.Height), TextFormatFlags.WordBreak);

                    int totalH = subSz.Height + cntSz.Height;
                    int startY = (tile.Height - totalH) / 2;

                    // 1. Draw Subject Name (White)
                    Rectangle subRect = new Rectangle(2, startY, tile.Width - 4, subSz.Height);
                    TextRenderer.DrawText(g, name, subjectFont, subRect, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.VerticalCenter);

                    // 2. Draw Count (Light Gold)
                    Rectangle cntRect = new Rectangle(2, startY + subSz.Height, tile.Width - 4, cntSz.Height);
                    TextRenderer.DrawText(g, countText, countFont, cntRect, Color.FromArgb(255, 230, 150),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.Top);
                }
            };

            // Wire up the events
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
                string subjectName = data.Item1; // Extract the name

                // Show your details form with the dimmer effect
                frmSubjectDetails details = new frmSubjectDetails(subjectName);
                details.StartPosition = FormStartPosition.CenterParent;
                details.ShowDialog();
            }
        }

        // Helper to calculate the best font size for narrow tiles
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
                Rectangle rect = data.Item2; // Extract the original rectangle
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
                tile.Bounds = data.Item2; // Restore original size
                ApplyRoundedCorners(tile, 12);
            }
        }

        // Helper to get count back from the text string for color restoration
        private int ExtractCountFromText(string text)
        {
            try
            {
                string[] lines = text.Split('\n');
                string countPart = lines[1].Split(' ')[0];
                return int.Parse(countPart);
            }
            catch { return 0; }
        }
        private Font GetBestFitFont(Graphics g, string text, Size containerSize, Font baseFont)
        {
            // Start with a reasonable max size and scale down until it fits
            float fontSize = 14f;

            // Adjust starting font based on tile size to save cycles
            if (containerSize.Width < 80 || containerSize.Height < 40) fontSize = 8f;
            else if (containerSize.Width < 150) fontSize = 10f;

            while (fontSize > 5f)
            {
                using (Font f = new Font(baseFont.FontFamily, fontSize, baseFont.Style))
                {
                    Size sz = TextRenderer.MeasureText(text, f, containerSize, TextFormatFlags.WordBreak);
                    if (sz.Width <= containerSize.Width - 10 && sz.Height <= containerSize.Height - 10)
                        return new Font(baseFont.FontFamily, fontSize, baseFont.Style);
                }
                fontSize -= 0.5f;
            }
            return new Font(baseFont.FontFamily, 5f, baseFont.Style);
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

        private void frmDistributionSubject_Load_1(object sender, EventArgs e)
        {

        }
    }
}