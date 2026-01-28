using PUP_RMS.CustomControls;
using PUP_RMS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionProgram : Form
    {
        // ==============================
        // VARIABLES
        // ==============================
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private const int CS_DROPSHADOW = 0x00020000;

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

        // SCALING
        private const float BASE_WIDTH = 950f;
        private const float BASE_HEIGHT = 600f;

        // Filter Controls
        private Label lblFilter;      // School Year Label
        private ComboBox cmbSchoolYear;

        private Label lblCurriculum;  // Curriculum Label
        private ComboBox cmbCurriculum;

        public frmDistributionProgram()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            SetupForm();
            SetupFilterControls();
            LoadMainData();
        }

        private void SetupForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = ClrStandoutBack;
            MinimumSize = new Size(880, 540);
            Size = new Size(880, 540);
            Padding = new Padding(0);

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        // =========================================================
        // 1. SETUP FILTER CONTROLS
        // =========================================================
        private void SetupFilterControls()
        {
            // --- 1. Curriculum Controls (Left) ---
            lblCurriculum = new Label();
            lblCurriculum.Text = "Curriculum:";
            lblCurriculum.ForeColor = ClrTextGray; // CHANGED: Gray text for light background
            lblCurriculum.BackColor = Color.Transparent; // CHANGED: Transparent background
            lblCurriculum.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCurriculum.AutoSize = true;

            cmbCurriculum = new ComboBox();
            cmbCurriculum.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            cmbCurriculum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurriculum.Width = 140;
            cmbCurriculum.BackColor = Color.White;
            cmbCurriculum.FlatStyle = FlatStyle.Flat;

            // Load Curriculums
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
            cmbCurriculum.SelectedIndex = 0;

            // EVENT
            cmbCurriculum.SelectedIndexChanged += (s, e) =>
            {
                LoadSchoolYearCombo();
                LoadMainData();
            };

            // --- 2. School Year Controls (Right) ---
            lblFilter = new Label();
            lblFilter.Text = "School Year:";
            lblFilter.ForeColor = ClrTextGray; // CHANGED: Gray text
            lblFilter.BackColor = Color.Transparent; // CHANGED: Transparent
            lblFilter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFilter.AutoSize = true;

            cmbSchoolYear = new ComboBox();
            cmbSchoolYear.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            cmbSchoolYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSchoolYear.Width = 140;
            cmbSchoolYear.BackColor = Color.White;
            cmbSchoolYear.FlatStyle = FlatStyle.Flat;

            // Load Initial School Years
            LoadSchoolYearCombo();

            // EVENT
            cmbSchoolYear.SelectedIndexChanged += (s, e) => { LoadMainData(); };

            // Add Controls
            this.Controls.Add(cmbSchoolYear);
            this.Controls.Add(lblFilter);
            this.Controls.Add(cmbCurriculum);
            this.Controls.Add(lblCurriculum);

            RepositionFilterControls();
        }

        private void LoadSchoolYearCombo()
        {
            string selectedCurr = cmbCurriculum.SelectedItem?.ToString();
            string currentSelection = cmbSchoolYear.SelectedItem?.ToString();
            string filterProgram = _isDrilledDown ? _drilledProgramName : null;

            cmbSchoolYear.Items.Clear();
            cmbSchoolYear.Items.Add("All");

            try
            {
                DataTable dt = DashboardHelper.GetSchoolYears(selectedCurr, filterProgram);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbSchoolYear.Items.Add(row["SchoolYear"].ToString());
                    }
                }
            }
            catch { }
            if (currentSelection != null && cmbSchoolYear.Items.Contains(currentSelection))
                cmbSchoolYear.SelectedItem = currentSelection;
            else
                cmbSchoolYear.SelectedIndex = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RepositionFilterControls();
        }

        // =========================================================
        // REPOSITIONING LOGIC (UPDATED FOR CENTER ALIGNMENT)
        // =========================================================
        private void RepositionFilterControls()
        {
            if (lblFilter == null || cmbSchoolYear == null || lblCurriculum == null || cmbCurriculum == null) return;

            float scale = GetScaleFactor();
            int headerHeight = (int)(50 * scale);
            if (headerHeight < 50) headerHeight = 50;
            int padding = 10;
            int groupSpacing = (int)(40 * scale); 
            int yPos = headerHeight + (int)(15 * scale);

            int currGroupWidth = lblCurriculum.Width + padding + cmbCurriculum.Width;
            int yearGroupWidth = lblFilter.Width + padding + cmbSchoolYear.Width;
            int totalWidth = currGroupWidth + groupSpacing + yearGroupWidth;

            int startX = (this.Width - totalWidth) / 2;

            lblCurriculum.Location = new Point(startX, yPos + 3); 
            cmbCurriculum.Location = new Point(lblCurriculum.Right + padding, yPos);

            int yearStartX = cmbCurriculum.Right + groupSpacing;
            lblFilter.Location = new Point(yearStartX, yPos + 3);
            cmbSchoolYear.Location = new Point(lblFilter.Right + padding, yPos);

            cmbSchoolYear.BringToFront();
            lblFilter.BringToFront();
            cmbCurriculum.BringToFront();
            lblCurriculum.BringToFront();
        }

        // =========================================================
        // 2. DATA LOADING
        // =========================================================
        private void LoadMainData()
        {
            _isDrilledDown = false;
            _mainSegments = new List<ChartSegment>();

            string selectedYear = null;
            if (cmbSchoolYear != null && cmbSchoolYear.SelectedItem != null)
            {
                selectedYear = cmbSchoolYear.SelectedItem.ToString();
            }

            string selectedCurriculum = null;
            if (cmbCurriculum != null && cmbCurriculum.SelectedItem != null)
            {
                selectedCurriculum = cmbCurriculum.SelectedItem.ToString();
            }

            // Standard backend call
            DataTable dt = DashboardHelper.GetProgramDistribution(selectedYear, selectedCurriculum);

            Color[] colors = {
                ClrMaroon, ClrGold, Color.FromArgb(180, 130, 40), Color.CadetBlue,
                Color.SteelBlue, Color.DarkSlateBlue, Color.MediumPurple, Color.IndianRed,
                Color.SeaGreen, Color.Teal, Color.DimGray, Color.Sienna
            };

            int limit = 10;
            int othersCount = 0;

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    string label = row["Label"].ToString();
                    int val = Convert.ToInt32(row["Value"]);

                    if (i < limit)
                    {
                        _mainSegments.Add(new ChartSegment
                        {
                            Label = label,
                            Value = val,
                            Color = colors[i % colors.Length]
                        });
                    }
                    else
                    {
                        othersCount += val;
                    }
                }
            }

            if (othersCount > 0)
            {
                _mainSegments.Add(new ChartSegment { Label = "Others", Value = othersCount, Color = Color.Gray });
            }

            if (_mainSegments.Count == 0)
            {
                _mainSegments.Add(new ChartSegment { Label = "No Data", Value = 1, Color = Color.LightGray });
            }

            _currentSegments = new List<ChartSegment>(_mainSegments);
            Invalidate();
        }


        private void LoadYearLevelData(ChartSegment parentProgram)
        {
        
            lblCurriculum.Visible = false;
            cmbCurriculum.Visible = false;
            lblFilter.Visible = false;
            cmbSchoolYear.Visible = false;

            
            _isDrilledDown = true;
            _drilledProgramName = parentProgram.Label;

            LoadSchoolYearCombo();
            _isDrilledDown = true;

           
            string selectedYear = cmbSchoolYear.SelectedItem?.ToString();
            string selectedCurriculum = cmbCurriculum.SelectedItem?.ToString();

            DataTable dt = DashboardHelper.GetYearLevelDistribution(parentProgram.Label, selectedYear, selectedCurriculum);

            Dictionary<int, int> dbCounts = new Dictionary<int, int>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int lvl = Convert.ToInt32(row["YearLevel"]);
                    int cnt = Convert.ToInt32(row["Total"]);
                    if (!dbCounts.ContainsKey(lvl)) dbCounts.Add(lvl, cnt);
                }
            }

            _currentSegments = new List<ChartSegment>();
            Color baseColor = parentProgram.Color;
            int maxYear = 4;
            if (dbCounts.Keys.Count > 0 && dbCounts.Keys.Max() > maxYear) maxYear = dbCounts.Keys.Max();

            for (int i = 1; i <= maxYear; i++)
            {
                int count = dbCounts.ContainsKey(i) ? dbCounts[i] : 0;
                string label = GetYearLabel(i);
                float lightFactor = (i - 1) * 0.3f;
                if (lightFactor > 1.5f) lightFactor = 1.5f;
                Color yearColor = ControlPaint.Light(baseColor, lightFactor);

                _currentSegments.Add(new ChartSegment { Label = label, Value = count, Color = yearColor });
            }

            Invalidate();
        }


        private string GetYearLabel(int level)
        {
            switch (level)
            {
                case 1: return "1st Year";
                case 2: return "2nd Year";
                case 3: return "3rd Year";
                case 4: return "4th Year";
                case 5: return "5th Year";
                default: return level + "th Year"; 
            }
        }

        // =========================================================
        // 3. PAINTING & DRAWING
        // =========================================================
        protected override void OnPaint(PaintEventArgs e)
        {
            _sliceZones.Clear();
            _legendZones.Clear();

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float scale = GetScaleFactor();

            int headerHeight = (int)(50 * scale);
            if (headerHeight < 50) headerHeight = 50;
            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);
            int filterAreaHeight = (int)(50 * scale);

            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                g.FillRectangle(brush, headerRect);

            DrawWindowButtons(g, scale);

          if (_isDrilledDown)
{
    string programCode = _drilledProgramName; 
    string labelText = " – Grade Sheets Distribution by Program Year Level";

    float xPos = 60 * scale; 
    float yPos = (headerRect.Height - 24 * scale) / 2f; 

    using (Font codeFont = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
    using (Font labelFont = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
    using (Brush codeBrush = new SolidBrush(ClrGold))
    using (Brush labelBrush = new SolidBrush(Color.Goldenrod))
    {
        g.DrawString(programCode, codeFont, codeBrush, xPos, yPos);

        float codeWidth = g.MeasureString(programCode, codeFont).Width;

        g.DrawString(labelText, labelFont, labelBrush, xPos + codeWidth, yPos);
    }
}
else
{
    string title = "Grade Sheets Distribution by Program";
    float xPos = 20 * scale;
    float yPos = (headerRect.Height - 24 * scale) / 2f;

    using (Font font = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
    using (Brush brush = new SolidBrush(Color.Goldenrod))
    {
        g.DrawString(title, font, brush, xPos, yPos);
    }
}



            int totalTopOffset = headerHeight + filterAreaHeight;
            Rectangle contentRect = new Rectangle(0, totalTopOffset, Width, Height - totalTopOffset);

            if (contentRect.Width < 50 || contentRect.Height < 50) return;
            long total = _currentSegments.Sum(s => (long)s.Value);

            if (total == 0 && !_isDrilledDown) return;
            if (total == 0) total = 1;

            float chartSize = 380 * scale;
            float thickness = 70 * scale;

            float chartX = _isDrilledDown ? (Width - chartSize) / 2f : 150 * scale;
            float chartY = totalTopOffset + (contentRect.Height - chartSize) / 2;

            _lastChartBounds = new RectangleF(chartX, chartY, chartSize, chartSize);


            DrawShadow(g, _lastChartBounds, scale);
            DrawDoughnutWithSpokes(g, _lastChartBounds, total, thickness, scale);

            float legendX = _lastChartBounds.Right + (60 * scale);
            float legendY = chartY + (30 * scale);
            DrawLegendColumns(g, legendX, legendY, total, scale);

            using (Pen borderPen = new Pen(Color.FromArgb(150, 150, 150), 1))
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private void DrawDoughnutWithSpokes(Graphics g, RectangleF bounds, long total, float thickness, float scale)
        {
            float startAngle = -90;
            RectangleF arcRect = bounds;
            arcRect.Inflate(-thickness / 2f, -thickness / 2f);

            for (int i = 0; i < _currentSegments.Count; i++)
            {
                ChartSegment seg = _currentSegments[i];
                float sweepAngle = (float)((double)seg.Value / total * 360.0);

                _sliceZones.Add(new SliceHitZone { StartAngle = startAngle, SweepAngle = sweepAngle, Segment = seg });

                using (Pen p = new Pen(seg.Color, thickness))
                {
                    p.StartCap = LineCap.Flat;
                    p.EndCap = LineCap.Flat;
                    g.DrawArc(p, arcRect, startAngle, sweepAngle);
                }

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

                if (sweepAngle > 0)
                    DrawSpokeLabel(g, bounds, startAngle, sweepAngle, seg, total, scale, i);

                startAngle += sweepAngle;
            }

            DrawCenterText(g, bounds, total, scale);
        }

        private void DrawCenterText(Graphics g, RectangleF bounds, long total, float scale)
        {
            float cx = bounds.X + bounds.Width / 2f;
            float cy = bounds.Y + bounds.Height / 2f;

            string label = "";
            string value = "";

            if (_isDrilledDown)
            {
                label = _drilledProgramName;
                value = total.ToString();
            }
            else
            {
                ChartSegment largest = _currentSegments.OrderByDescending(s => s.Value).FirstOrDefault();
                if (largest != null)
                {
                    label = largest.Label;
                    value = $"{(double)largest.Value / total * 100:0}%";
                }
            }

            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (Font f = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                    g.DrawString(label, f, Brushes.Black, cx, cy - (15 * scale), sf);

                using (Font f = new Font("Segoe UI", 24 * scale, FontStyle.Bold))
                    g.DrawString(value, f, new SolidBrush(Color.FromArgb(40, 40, 40)), cx, cy + (18 * scale), sf);
            }
        }

        private void DrawSpokeLabel(Graphics g, RectangleF bounds, float startAngle, float sweepAngle, ChartSegment seg, long total, float scale, int index)
        {
            float midAngle = startAngle + sweepAngle / 2f;
            float rad = midAngle * (float)Math.PI / 180f;
            float cx = bounds.X + bounds.Width / 2f;
            float cy = bounds.Y + bounds.Height / 2f;
            float radius = bounds.Width / 2f;

            // Vary extension length to prevent text overlapping
            float extension = (index % 2 == 0) ? 15 * scale : 45 * scale;

            // Calculate line points
            float x1 = cx + (radius - 5 * scale) * (float)Math.Cos(rad);
            float y1 = cy + (radius - 5 * scale) * (float)Math.Sin(rad);
            float x2 = cx + (radius + extension) * (float)Math.Cos(rad);
            float y2 = cy + (radius + extension) * (float)Math.Sin(rad);

            using (Pen p = new Pen(Color.Gray, 1 * scale))
                g.DrawLine(p, x1, y1, x2, y2);

            string pctText = $"{(double)seg.Value / total:P0}";

            float tx = x2;
            float ty = y2;
            float textOffset = 2 * scale;

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;

            // Right side of circle
            if (midAngle >= -90 && midAngle < 90)
            {
                sf.Alignment = StringAlignment.Near;
                tx += textOffset;
            }
            // Left side of circle
            else
            {
                sf.Alignment = StringAlignment.Far;
                tx -= textOffset;
            }

            // >>> FIX: Ensure text doesn't go off-screen (Left Edge Safety) <<<
            float minX = 10 * scale;
            if (tx < minX && sf.Alignment == StringAlignment.Far)
            {
                // If the point is too far left, push it right and align Near
                tx = minX;
                sf.Alignment = StringAlignment.Near;
            }

            using (Font f = new Font("Segoe UI", 7 * scale, FontStyle.Regular))
                g.DrawString(pctText, f, Brushes.Black, tx, ty, sf);
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

                    SizeF txtSize = g.MeasureString($"{seg.Label}: {seg.Value}", fontLabel);
                    RectangleF hitRect = new RectangleF(x, y, boxSize + 20 + txtSize.Width, boxSize + 10);
                    _legendZones.Add(new LegendHitZone { Bounds = hitRect, Segment = seg });

                    using (SolidBrush b = new SolidBrush(seg.Color))
                        g.FillEllipse(b, x, y + (2 * scale), boxSize, boxSize);

                    g.DrawString($"{seg.Label}: {seg.Value}", fontLabel, textBrush, x + (18 * scale), y - (2 * scale));

                    y += vSpace;
                    count++;
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

        private void DrawWindowButtons(Graphics g, float scale)
        {
            int btnSize = (int)(24 * scale);
            if (btnSize > 40) btnSize = 40; if (btnSize < 24) btnSize = 24;
            int margin = (int)(13 * scale); if (margin < 10) margin = 10;

            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            if (_isDrilledDown)
                _backBtnRect = new Rectangle(margin, margin, btnSize, btnSize);
            else
                _backBtnRect = Rectangle.Empty;

            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
                if (_isHoveringBack && _isDrilledDown) g.FillEllipse(hoverBrush, _backBtnRect);
            }

            using (Pen p = new Pen(ClrGold, 2.0f * scale))
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
                float box = 9 * (btnSize / 24f);
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);

                // Back Button (Arrow)
                // Back Button (Circle + Arrow)
                if (_isDrilledDown)
                {
                    // Draw circle (like other buttons)
                    using (Pen backPen = new Pen(ClrGold, 2.0f * scale))
                    {
                        g.DrawEllipse(backPen, _backBtnRect);
                    }

                    // Draw arrow inside
                    float bx = _backBtnRect.X + _backBtnRect.Width / 2f;
                    float by = _backBtnRect.Y + _backBtnRect.Height / 2f;
                    float arrowSize = 5 * (btnSize / 24f);

                    using (Pen arrowPen = new Pen(ClrGold, 2.0f * scale))
                    {
                        PointF pTip = new PointF(bx - arrowSize, by);
                        PointF pTop = new PointF(bx + arrowSize, by - arrowSize);
                        PointF pBot = new PointF(bx + arrowSize, by + arrowSize);

                        g.DrawLine(arrowPen, pTip, pTop);
                        g.DrawLine(arrowPen, pTip, pBot);
                    }
                }

            }
        }

      
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Close Logic
            if (_closeBtnRect.Contains(e.Location)) { Close(); return; }

            // Maximize Logic
            if (_maxBtnRect.Contains(e.Location))
            {
                if (this.WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
                this.Invalidate();
                return;
            }

            if (_backBtnRect.Contains(e.Location) && _isDrilledDown)
            {
                _isDrilledDown = false;
                _drilledProgramName = "";

                // Show the filters again
                lblCurriculum.Visible = true;
                cmbCurriculum.Visible = true;
                lblFilter.Visible = true;
                cmbSchoolYear.Visible = true;

                LoadSchoolYearCombo();
                LoadMainData();
                return;
            }

            // Drag Window Logic
            int headerH = (int)(50 * GetScaleFactor());
            if (headerH < 50) headerH = 50;
            if (e.Button == MouseButtons.Left && e.Y < headerH)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = Location;
                return;
            }

            // Chart Click Logic
            if (e.Button == MouseButtons.Left && !_isDrilledDown)
            {
                CheckChartClick(e.Location);
                CheckLegendClick(e.Location);
            }
        }

        private void CheckLegendClick(Point p)
        {
            // Loop through all legend zones to see if the mouse clicked one
            foreach (var zone in _legendZones)
            {
                if (zone.Bounds.Contains(p))
                {
                    // If clicked, drill down into that program
                    LoadYearLevelData(zone.Segment);
                    return;
                }
            }
        }

        // You might also be missing this one, so add it just in case:
        private void CheckChartClick(Point p)
        {
            if (!_lastChartBounds.Contains(p)) return;

            // Calculate distance from center to check if click is inside the doughnut ring
            float cx = _lastChartBounds.X + _lastChartBounds.Width / 2f;
            float cy = _lastChartBounds.Y + _lastChartBounds.Height / 2f;
            float dx = p.X - cx;
            float dy = p.Y - cy;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            float radius = _lastChartBounds.Width / 2f;
            float holeRadius = radius - (70 * GetScaleFactor());

            // If outside the outer circle OR inside the empty hole, ignore
            if (dist > radius || dist < holeRadius) return;

            // Calculate Angle
            double angle = Math.Atan2(dy, dx) * 180 / Math.PI;
            if (angle < -90) angle += 360; // Normalize angle

            double clickAngle = angle + 90;
            if (clickAngle < 0) clickAngle += 360;

            // Check which slice matches the angle
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

        private float GetScaleFactor()
        {
            float scaleX = this.Width / BASE_WIDTH;
            float scaleY = this.Height / BASE_HEIGHT;
            return Math.Min(scaleX, scaleY);
        }

        private void frmDistributionProgram_Load(object sender, EventArgs e)
        {
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