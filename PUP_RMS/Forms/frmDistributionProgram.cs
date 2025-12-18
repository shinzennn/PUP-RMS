using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PUP_RMS.CustomControls;

namespace PUP_RMS.Forms
{
    // ==========================================
    // MAIN FORM CLASS
    // ==========================================
    public partial class frmDistributionProgram : Form
    {
        // ==============================
        // VARIABLES
        // ==============================
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        // Colors
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrTextGray = Color.FromArgb(64, 64, 64);
        private readonly Color ClrStandoutBack = Color.FromArgb(224, 227, 231);

        // Data Storage
        private List<ChartSegment> _mainSegments = new List<ChartSegment>();
        private List<ChartSegment> _currentSegments = new List<ChartSegment>();

        // Drill-Down State
        private bool _isDrilledDown = false;
        private string _drilledProgramName = "";

        // Hit Testing
        private List<SliceHitZone> _sliceZones = new List<SliceHitZone>();
        private List<LegendHitZone> _legendZones = new List<LegendHitZone>();
        private RectangleF _lastChartBounds;

        // Button Areas
        private Rectangle _closeBtnRect;
        private Rectangle _maxBtnRect;
        private Rectangle _backBtnRect;
        private bool _isHoveringClose = false;
        private bool _isHoveringMax = false;
        private bool _isHoveringBack = false;

        // SCALING: Increased Size for 30+ Items
        private const float BASE_WIDTH = 950f;
        private const float BASE_HEIGHT = 600f;

        public frmDistributionProgram()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            SetupForm();
            LoadMainData();
        }

        private void SetupForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = ClrStandoutBack;
            // Larger Size
            MinimumSize = new Size(880, 540);
            Size = new Size(880, 540);
            Padding = new Padding(0);

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

        public static void ShowWithDimmer(Form parent, frmDistributionProgram child)
        {
            using (Form dimmer = new Form())
            {
                dimmer.StartPosition = FormStartPosition.Manual;
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.AllowTransparency = true;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.5; 
                dimmer.Size = parent.Size;
                dimmer.Location = parent.Location;
                dimmer.ShowInTaskbar = false;

                dimmer.Show();
                child.Owner = dimmer;
                child.ShowDialog();
                dimmer.Close();
            }
        }
        private void LoadMainData()
        {
            // 20+ Sample Programs
            _mainSegments = new List<ChartSegment>
            {
                new ChartSegment { Label = "BSIT", Value = 4500, Color = ClrMaroon },
                new ChartSegment { Label = "BSA", Value = 2500, Color = Color.FromArgb(180, 130, 40) },
                new ChartSegment { Label = "BSED", Value = 2000, Color = ClrGold },
                new ChartSegment { Label = "BSHM", Value = 1500, Color = Color.FromArgb(240, 190, 80) },
                new ChartSegment { Label = "BSBA", Value = 1200, Color = Color.FromArgb(210, 160, 50) },
                new ChartSegment { Label = "BSCE", Value = 900, Color = Color.CadetBlue },
                new ChartSegment { Label = "BSEE", Value = 850, Color = Color.SteelBlue },
                new ChartSegment { Label = "BSME", Value = 800, Color = Color.DarkSlateBlue },
                new ChartSegment { Label = "BSCpE", Value = 750, Color = Color.MediumPurple },
                new ChartSegment { Label = "BSIE", Value = 700, Color = Color.FromArgb(102,51,153) },
                new ChartSegment { Label = "AB English", Value = 600, Color = Color.IndianRed },
                new ChartSegment { Label = "AB PolSci", Value = 550, Color = Color.Firebrick },
                new ChartSegment { Label = "BS Psych", Value = 500, Color = Color.DarkSalmon },
                new ChartSegment { Label = "BS Bio", Value = 450, Color = Color.SeaGreen },
                new ChartSegment { Label = "BS Math", Value = 400, Color = Color.MediumSeaGreen },
                new ChartSegment { Label = "BS Stat", Value = 350, Color = Color.Teal },
                new ChartSegment { Label = "BS Arch", Value = 300, Color = Color.DimGray },
                new ChartSegment { Label = "BPE", Value = 250, Color = Color.SlateGray },
                new ChartSegment { Label = "BTLEd", Value = 200, Color = Color.DarkOliveGreen },
                new ChartSegment { Label = "DOMT", Value = 150, Color = Color.Sienna },
                // Extra items to test crowding
                new ChartSegment { Label = "BS Entrep", Value = 140, Color = Color.OrangeRed },
                new ChartSegment { Label = "BS OAd", Value = 130, Color = Color.PaleVioletRed },
                new ChartSegment { Label = "BS Nutri", Value = 120, Color = Color.LimeGreen },
                new ChartSegment { Label = "BS Chem", Value = 110, Color = Color.CornflowerBlue }
            };

            _currentSegments = new List<ChartSegment>(_mainSegments);
            _isDrilledDown = false;
            Invalidate();
        }

        private void LoadYearLevelData(ChartSegment parentProgram)
        {
            _isDrilledDown = true;
            _drilledProgramName = parentProgram.Label;

            int total = parentProgram.Value;
            int y1 = (int)(total * 0.35);
            int y2 = (int)(total * 0.25);
            int y3 = (int)(total * 0.22);
            int y4 = total - y1 - y2 - y3;

            Color c = parentProgram.Color;

            _currentSegments = new List<ChartSegment>
            {
                new ChartSegment { Label = "1st Year", Value = y1, Color = c },
                new ChartSegment { Label = "2nd Year", Value = y2, Color = ControlPaint.Light(c, 0.4f) },
                new ChartSegment { Label = "3rd Year", Value = y3, Color = ControlPaint.Light(c, 0.8f) },
                new ChartSegment { Label = "4th Year", Value = y4, Color = ControlPaint.Light(c, 1.2f) }
            };

            Invalidate();
        }

        // ==============================
        // SCALING
        // ==============================
        private float GetScaleFactor()
        {
            float scaleX = this.Width / BASE_WIDTH;
            float scaleY = this.Height / BASE_HEIGHT;
            return Math.Min(scaleX, scaleY);
        }

        // ==============================
        // PAINTING
        // ==============================
        protected override void OnPaint(PaintEventArgs e)
        {
            _sliceZones.Clear();
            _legendZones.Clear();

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float scale = GetScaleFactor();

            // 1. HEADER
            int headerHeight = (int)(50 * scale);
            if (headerHeight < 50) headerHeight = 50;
            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);

            using (SolidBrush brush = new SolidBrush(ClrMaroon))
            {
                g.FillRectangle(brush, headerRect);
            }

            string title = _isDrilledDown ? $"Program > {_drilledProgramName}" : "Grade Sheets Distribution by Program";

            using (Font titleFont = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(ClrGold))
            {
                float textX = _isDrilledDown ? (50 * scale) : (20 * scale);
                g.DrawString(title, titleFont, textBrush, textX, headerRect.Height / 2 - titleFont.Height / 2);
            }

            DrawWindowButtons(g, scale);

            // 2. CHART LAYOUT
            Rectangle contentRect = new Rectangle(0, headerHeight, Width, Height - headerHeight);
            if (contentRect.Width < 50 || contentRect.Height < 50) return;

            long total = _currentSegments.Sum(s => (long)s.Value);
            if (total == 0) return;

            // Dimensions - Adjusted for staggering
            float chartSize = 380 * scale;
            float thickness = 70 * scale;

            // Move Chart Left to allow space for staggered labels
            float chartX = 60 * scale;
            float chartY = headerHeight + (contentRect.Height - chartSize) / 2;

            _lastChartBounds = new RectangleF(chartX, chartY, chartSize, chartSize);

            // 3. DRAW
            DrawShadow(g, _lastChartBounds, scale);
            DrawDoughnutWithSpokes(g, _lastChartBounds, total, thickness, scale);

            float legendX = _lastChartBounds.Right + (80 * scale); // More space between chart and legend
            float legendY = headerHeight + (30 * scale);
            DrawLegendColumns(g, legendX, legendY, total, scale);

            using (Pen borderPen = new Pen(Color.FromArgb(150, 150, 150), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void DrawWindowButtons(Graphics g, float scale)
        {
            int btnSize = (int)(24 * scale);
            if (btnSize > 40) btnSize = 40; if (btnSize < 24) btnSize = 24;
            int margin = (int)(13 * scale); if (margin < 10) margin = 10;

            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            if (_isDrilledDown) _backBtnRect = new Rectangle(margin, margin, btnSize, btnSize);
            else _backBtnRect = Rectangle.Empty;

            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
                if (_isHoveringBack && _isDrilledDown) g.FillEllipse(hoverBrush, _backBtnRect);
            }

            using (Pen p = new Pen(ClrGold, 1.5f * scale))
            {
                // Close
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                float off = 5 * (btnSize / 24f);
                g.DrawLine(p, cx - off, cy - off, cx + off, cy + off);
                g.DrawLine(p, cx + off, cy - off, cx - off, cy + off);

                // Max
                g.DrawEllipse(p, _maxBtnRect);
                float mx = _maxBtnRect.X + _maxBtnRect.Width / 2f;
                float my = _maxBtnRect.Y + _maxBtnRect.Height / 2f;
                float box = 10 * (btnSize / 24f);
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);

                // Back
                if (_isDrilledDown)
                {
                    g.DrawEllipse(p, _backBtnRect);
                    float bx = _backBtnRect.X + _backBtnRect.Width / 2f;
                    float by = _backBtnRect.Y + _backBtnRect.Height / 2f;
                    float arrOff = 4 * (btnSize / 24f);
                    g.DrawLine(p, bx + arrOff, by, bx - arrOff, by);
                    g.DrawLine(p, bx - arrOff, by, bx, by - arrOff);
                    g.DrawLine(p, bx - arrOff, by, bx, by + arrOff);
                }
            }
        }

        private void DrawShadow(Graphics g, RectangleF bounds, float scale)
        {
            RectangleF s = bounds; s.Inflate(-10 * scale, -10 * scale); s.Offset(0, 10 * scale);
            using (SolidBrush b = new SolidBrush(Color.FromArgb(20, 0, 0, 0))) g.FillEllipse(b, s);
            RectangleF sc = s; sc.Inflate(-10 * scale, -10 * scale);
            using (SolidBrush b = new SolidBrush(Color.FromArgb(15, 0, 0, 0))) g.FillEllipse(b, sc);
        }

        private void DrawDoughnutWithSpokes(Graphics g, RectangleF bounds, long total, float thickness, float scale)
        {
            float startAngle = -90;
            RectangleF arcRect = bounds;
            arcRect.Inflate(-thickness / 2f, -thickness / 2f);

            ChartSegment largest = _currentSegments.OrderByDescending(s => s.Value).First();

            // Use FOR LOOP to access Index for Staggering
            for (int i = 0; i < _currentSegments.Count; i++)
            {
                ChartSegment seg = _currentSegments[i];
                float sweepAngle = (float)((double)seg.Value / total * 360.0);

                // REGISTER HIT ZONE
                _sliceZones.Add(new SliceHitZone { StartAngle = startAngle, SweepAngle = sweepAngle, Segment = seg });

                using (Pen p = new Pen(seg.Color, thickness))
                {
                    p.StartCap = LineCap.Flat;
                    p.EndCap = LineCap.Flat;
                    g.DrawArc(p, arcRect, startAngle, sweepAngle);
                }

                // White separator
                float endRad = (startAngle + sweepAngle) * (float)Math.PI / 180f;
                float cx = bounds.X + bounds.Width / 2f;
                float cy = bounds.Y + bounds.Height / 2f;
                float rOut = bounds.Width / 2f;
                float rIn = rOut - thickness;

                using (Pen whitePen = new Pen(Color.White, 2f * scale))
                {
                    PointF p1 = new PointF(cx + rIn * (float)Math.Cos(endRad), cy + rIn * (float)Math.Sin(endRad));
                    PointF p2 = new PointF(cx + rOut * (float)Math.Cos(endRad), cy + rOut * (float)Math.Sin(endRad));
                    g.DrawLine(whitePen, p1, p2);
                }

                // DRAW SPOKE LABEL
                if (sweepAngle > 0)
                    DrawSpokeLabel(g, bounds, startAngle, sweepAngle, seg, total, scale, i);

                startAngle += sweepAngle;
            }

            DrawCenterText(g, bounds, largest, total, scale);
        }

        private void DrawSpokeLabel(Graphics g, RectangleF bounds, float startAngle, float sweepAngle, ChartSegment seg, long total, float scale, int index)
        {
            float midAngle = startAngle + sweepAngle / 2f;
            float rad = midAngle * (float)Math.PI / 180f;
            float cx = bounds.X + bounds.Width / 2f;
            float cy = bounds.Y + bounds.Height / 2f;
            float radius = bounds.Width / 2f;

            // ===== STAGGERING LOGIC =====
            // If index is even, short line (15px). If odd, long line (45px).
            // This prevents text labels from colliding when slices are small.
            float extension = (index % 2 == 0) ? 15 * scale : 45 * scale;

            float x1 = cx + (radius - 5 * scale) * (float)Math.Cos(rad);
            float y1 = cy + (radius - 5 * scale) * (float)Math.Sin(rad);
            float x2 = cx + (radius + extension) * (float)Math.Cos(rad);
            float y2 = cy + (radius + extension) * (float)Math.Sin(rad);

            using (Pen p = new Pen(Color.Gray, 1 * scale)) g.DrawLine(p, x1, y1, x2, y2);

            string pctText = $"{(double)seg.Value / total:P0}";

            float tx = x2;
            float ty = y2;
            float textOffset = 2 * scale;

            StringFormat sf = new StringFormat();

            // Adjust Alignment
            if (midAngle >= -90 && midAngle < 90)
            {
                sf.Alignment = StringAlignment.Near;
                tx += textOffset;
            }
            else
            {
                sf.Alignment = StringAlignment.Far;
                tx -= textOffset;
            }
            sf.LineAlignment = StringAlignment.Center;

            // Smaller font (7pt) to fit more
            using (Font f = new Font("Segoe UI", 7 * scale, FontStyle.Regular))
                g.DrawString(pctText, f, Brushes.Black, tx, ty, sf);
        }

        private void DrawCenterText(Graphics g, RectangleF bounds, ChartSegment largest, long total, float scale)
        {
            float cx = bounds.X + bounds.Width / 2f;
            float cy = bounds.Y + bounds.Height / 2f;

            string label, value;

            if (_isDrilledDown)
            {
                label = _drilledProgramName;
                value = total.ToString();
            }
            else
            {
                label = largest.Label;
                value = $"{(double)largest.Value / total * 100:0}%";
            }

            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (Font f = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                    g.DrawString(label, f, Brushes.Black, cx, cy - (15 * scale), sf);

                using (Font f = new Font("Segoe UI", 24 * scale, FontStyle.Bold))
                    g.DrawString(value, f, new SolidBrush(Color.FromArgb(40, 40, 40)), cx, cy + (18 * scale), sf);
            }
        }

        private void DrawLegendColumns(Graphics g, float x, float y, long total, float scale)
        {
            float startY = y;
            float vSpace = 28 * scale;
            float colSpace = 160 * scale;
            float boxSize = 10 * scale;
            int itemsPerCol = 10;
            int count = 0;

            using (Font fontLabel = new Font("Segoe UI", 9 * scale, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(ClrTextGray))
            {
                foreach (var seg in _currentSegments)
                {
                    if (count > 0 && count % itemsPerCol == 0)
                    {
                        x += colSpace;
                        y = startY;
                    }

                    // REGISTER HIT ZONE
                    SizeF txtSize = g.MeasureString($"{seg.Label}: {seg.Value}", fontLabel);
                    RectangleF hitRect = new RectangleF(x, y, boxSize + 20 + txtSize.Width, boxSize + 10);
                    _legendZones.Add(new LegendHitZone { Bounds = hitRect, Segment = seg });

                    // Draw
                    using (SolidBrush b = new SolidBrush(seg.Color))
                        g.FillEllipse(b, x, y + (2 * scale), boxSize, boxSize);

                    g.DrawString($"{seg.Label}: {seg.Value}", fontLabel, textBrush, x + (18 * scale), y - (2 * scale));

                    y += vSpace;
                    count++;
                }
            }
        }

        // ==============================
        // MOUSE / INTERACTION
        // ==============================
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_closeBtnRect.Contains(e.Location)) { Close(); return; }
            if (_maxBtnRect.Contains(e.Location))
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    // Use .Bounds to ignore the taskbar and go true full screen
                    this.MaximizedBounds = Screen.FromHandle(this.Handle).Bounds;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
                this.Invalidate();
                return;
            }
            if (_backBtnRect.Contains(e.Location) && _isDrilledDown)
            {
                LoadMainData();
                return;
            }

            int headerH = (int)(50 * GetScaleFactor());
            if (headerH < 50) headerH = 50;
            if (e.Button == MouseButtons.Left && e.Y < headerH)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = Location;
                return;
            }

            if (e.Button == MouseButtons.Left && !_isDrilledDown)
            {
                CheckChartClick(e.Location);
                CheckLegendClick(e.Location);
            }
        }

        private void CheckLegendClick(Point p)
        {
            foreach (var zone in _legendZones)
            {
                if (zone.Bounds.Contains(p))
                {
                    LoadYearLevelData(zone.Segment);
                    return;
                }
            }
        }

        private void CheckChartClick(Point p)
        {
            if (!_lastChartBounds.Contains(p)) return;

            float cx = _lastChartBounds.X + _lastChartBounds.Width / 2f;
            float cy = _lastChartBounds.Y + _lastChartBounds.Height / 2f;

            float dx = p.X - cx;
            float dy = p.Y - cy;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            float radius = _lastChartBounds.Width / 2f;

            // Adjust hit test for the new thickness (70)
            float holeRadius = radius - (70 * GetScaleFactor());

            if (dist > radius || dist < holeRadius) return;

            double angle = Math.Atan2(dy, dx) * 180 / Math.PI;
            if (angle < -90) angle += 360;

            double clickAngle = angle + 90;
            if (clickAngle < 0) clickAngle += 360;

            foreach (var zone in _sliceZones)
            {
                double zStart = zone.StartAngle + 90;
                if (zStart < 0) zStart += 360;

                double zEnd = zStart + zone.SweepAngle;

                bool hit = false;
                if (zEnd > 360)
                {
                    if (clickAngle >= zStart || clickAngle <= (zEnd - 360)) hit = true;
                }
                else
                {
                    if (clickAngle >= zStart && clickAngle <= zEnd) hit = true;
                }

                if (hit)
                {
                    LoadYearLevelData(zone.Segment);
                    return;
                }
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(diff));
                return;
            }

            bool hoverClose = _closeBtnRect.Contains(e.Location);
            bool hoverMax = _maxBtnRect.Contains(e.Location);
            bool hoverBack = _backBtnRect.Contains(e.Location);

            bool chartHover = false;
            if (!_isDrilledDown)
            {
                if (_legendZones.Any(z => z.Bounds.Contains(e.Location))) chartHover = true;

                float cx = _lastChartBounds.X + _lastChartBounds.Width / 2f;
                float cy = _lastChartBounds.Y + _lastChartBounds.Height / 2f;
                double d = Math.Sqrt(Math.Pow(e.X - cx, 2) + Math.Pow(e.Y - cy, 2));
                if (d < _lastChartBounds.Width / 2 && d > (_lastChartBounds.Width / 2 - 50)) chartHover = true;
            }

            if (hoverClose != _isHoveringClose || hoverMax != _isHoveringMax || hoverBack != _isHoveringBack)
            {
                _isHoveringClose = hoverClose;
                _isHoveringMax = hoverMax;
                _isHoveringBack = hoverBack;

                int headerH = (int)(50 * GetScaleFactor());
                if (headerH < 50) headerH = 50;
                Invalidate(new Rectangle(0, 0, Width, headerH));
            }

            Cursor = (hoverClose || hoverMax || hoverBack || chartHover) ? Cursors.Hand : Cursors.Default;
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void frmDistributionProgram_Load(object sender, EventArgs e)
        {

        }
    }

    // ==========================================
    // HELPER CLASSES
    // ==========================================
    public class SliceHitZone
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        public ChartSegment Segment { get; set; }
    }

    public class LegendHitZone
    {
        public RectangleF Bounds { get; set; }
        public ChartSegment Segment { get; set; }
    }
}