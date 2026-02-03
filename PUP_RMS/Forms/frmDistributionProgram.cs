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

        int _drillSubmittedCount = 0;
        int _drillTotalCount = 0;
        int _mainSubmittedCount = 0;
        int _mainTotalCount = 0;

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

        private DataGridView dgvYearReport;

        public frmDistributionProgram()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            SetupForm();
            SetupFilterControls();
            SetupYearLevelGrid();
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

        private void SetupYearLevelGrid()
        {
            dgvYearReport = new DataGridView();
            dgvYearReport.Visible = false;
            dgvYearReport.BackgroundColor = Color.White;
            dgvYearReport.BorderStyle = BorderStyle.None;
            dgvYearReport.RowHeadersVisible = false;
            dgvYearReport.AllowUserToAddRows = false;
            dgvYearReport.AllowUserToDeleteRows = false;
            dgvYearReport.AllowUserToResizeColumns = false; // Restriction: No resizing
            dgvYearReport.AllowUserToResizeRows = false;    // Restriction: No resizing
            dgvYearReport.ReadOnly = true;
            dgvYearReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvYearReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvYearReport.EnableHeadersVisualStyles = false; // Required for custom maroon color
            dgvYearReport.GridColor = Color.FromArgb(230, 230, 230);
            dgvYearReport.MultiSelect = false;

            // --- Header Styling (Light Maroon) ---
            Color lightMaroon = Color.FromArgb(140, 60, 70); // A lighter variant of your ClrMaroon
            dgvYearReport.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = lightMaroon,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = lightMaroon, // Removes highlight color when clicking header
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };
            dgvYearReport.ColumnHeadersHeight = 45;
            dgvYearReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // --- Row Styling ---
            dgvYearReport.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = ClrGold, // Row highlight
                SelectionForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // --- MANUALLY ADD COLUMNS HERE ---
            dgvYearReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Year Level",
                HeaderText = "Year",
                Width = 60
            });

            dgvYearReport.Columns.Add(new DataGridViewProgressBarColumn
            {
                DataPropertyName = "Rate",
                HeaderText = "Completion",
                Width = 120
            });

            dgvYearReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Submitted/Total",
                HeaderText = "Ratio",
                Width = 80
            });

            dgvYearReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Conditional Formatting for Status
            dgvYearReport.CellFormatting += (s, e) => {
                if (dgvYearReport.Columns[e.ColumnIndex].HeaderText == "Status" && e.Value != null)
                {
                    if (e.Value.ToString() == "Completed") e.CellStyle.ForeColor = Color.DarkGreen;
                    else if (e.Value.ToString() == "Incomplete") e.CellStyle.ForeColor = Color.Firebrick;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            };

            this.Controls.Add(dgvYearReport);
        }

        private void LoadGridData()
        {
            if (cmbCurriculum.SelectedItem == null || cmbSchoolYear.SelectedItem == null) return;
            if (string.IsNullOrEmpty(_drilledProgramName)) return;

            string prog = _drilledProgramName;
            string curr = cmbCurriculum.SelectedItem.ToString();
            string sy = cmbSchoolYear.SelectedItem.ToString();

            DataTable dtRaw = DashboardHelper.GetYearLevelAggregateStatus(prog, sy, curr);

            if (dtRaw == null || dtRaw.Rows.Count == 0)
            {
                dgvYearReport.DataSource = null;
                FillGridVerticalSpace();
                return;
            }

            DataTable dtDisplay = new DataTable();
            dtDisplay.Columns.Add("Year Level", typeof(string));
            dtDisplay.Columns.Add("Rate", typeof(double));
            dtDisplay.Columns.Add("Submitted/Total", typeof(string));
            dtDisplay.Columns.Add("Status", typeof(string));

            foreach (DataRow row in dtRaw.Rows)
            {
                double rate = Convert.ToDouble(row["YearlyCompletionRate"]);
                dtDisplay.Rows.Add(
                    "Year " + row["YearLevel"],
                    rate,
                    $"{row["TotalSubmitted"]} / {row["TotalSectionsCreated"]}",
                    rate >= 100 ? "Completed" : (rate > 0 ? "In Progress" : "Incomplete")
                );
            }

            dgvYearReport.DataSource = dtDisplay; // Bind the data
        }

        private void UpdateDGVLayout()
        {
            if (dgvYearReport == null) return;

            if (_isDrilledDown)
            {
                float scale = GetScaleFactor();
                int margin = (int)(20 * scale);
                int gridWidth = (int)(400 * scale);
                int gridHeight = (int)(280 * scale); // Fixed height for the grid area

                dgvYearReport.Size = new Size(gridWidth, gridHeight);
                dgvYearReport.Location = new Point(
                    this.Width - gridWidth - margin,
                    (this.Height / 2) - (gridHeight / 2) + (int)(30 * scale)
                );

                dgvYearReport.Visible = true;
                dgvYearReport.BringToFront();

                // Recalculate row heights for the new size
                FillGridVerticalSpace();
            }
            else
            {
                dgvYearReport.Visible = false;
            }
        }

        private void FillGridVerticalSpace()
        {
            if (dgvYearReport.Rows.Count == 0) return;

            // Calculate total available height for the data rows
            int totalHeight = dgvYearReport.Height - dgvYearReport.ColumnHeadersHeight;
            int rowCount = dgvYearReport.Rows.Count;

            // Calculate height per row
            int targetHeight = totalHeight / rowCount;

            // Set height for every row
            foreach (DataGridViewRow row in dgvYearReport.Rows)
            {
                row.Height = targetHeight;
            }
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
            UpdateDGVLayout();
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

            string selectedYear = cmbSchoolYear?.SelectedItem?.ToString();
            string selectedCurriculum = cmbCurriculum?.SelectedItem?.ToString();

            // =========================================================
            // 1. FETCH CHART DATA (THE SLICES) - THIS WAS MISSING
            // =========================================================
            try
            {
                DataTable dt = DashboardHelper.GetProgramDistribution(selectedYear, selectedCurriculum);

                if (dt != null)
                {
                    // defined colors for the slices
                    Color[] palette = {
                ClrMaroon,
                ClrGold,
                Color.FromArgb(80, 80, 80),   // Dark Gray
                Color.FromArgb(160, 160, 160), // Light Gray
                Color.FromArgb(140, 60, 70),   // Lighter Maroon
                Color.FromArgb(200, 170, 80),  // Muted Gold
                Color.CadetBlue,
                Color.DarkOliveGreen
            };

                    int colorIndex = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        // Ensure your SQL Stored Procedure returns 'Label' and 'Value'
                        string label = row["Label"].ToString();
                        int val = Convert.ToInt32(row["Value"]);

                        if (val > 0)
                        {
                            _mainSegments.Add(new ChartSegment
                            {
                                Label = label,
                                Value = val,
                                Color = palette[colorIndex % palette.Length]
                            });
                            colorIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading chart segments: " + ex.Message);
            }

            // =========================================================
            // 2. FETCH TOTALS (FOR THE CENTER TEXT)
            // =========================================================
            // Reset counts
            _mainSubmittedCount = 0;
            _mainTotalCount = 0;

            try
            {
                DataTable dtCount = DashboardHelper.GetTotalCurriculumCourses(selectedYear, selectedCurriculum);

                if (dtCount != null && dtCount.Rows.Count > 0)
                {
                    _mainSubmittedCount = Convert.ToInt32(dtCount.Rows[0]["SubmittedCount"]);
                    _mainTotalCount = Convert.ToInt32(dtCount.Rows[0]["TotalCount"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading totals: " + ex.Message);
                // Fallback: Calculate from segments if DB call fails
                if (_mainSegments.Count > 0)
                    _mainSubmittedCount = _mainSegments.Sum(s => s.Value);
                _mainTotalCount = _mainSubmittedCount;
            }

            // Update current segments and redraw
            _currentSegments = new List<ChartSegment>(_mainSegments);
            Invalidate();
        }


        private void LoadYearLevelData(ChartSegment parentProgram)
        {
            // 1. Hide Filters (as per your existing code)
            lblCurriculum.Visible = false;
            cmbCurriculum.Visible = false;
            lblFilter.Visible = false;
            cmbSchoolYear.Visible = false;

            // 2. Set State
            _drilledProgramName = parentProgram.Label;

            // 3. Load Filters for context
            LoadSchoolYearCombo(); // This refreshes the combo based on drill down

            // 4. Force DrillDown State (LoadSchoolYearCombo might reset it in some events, so set it true here)
            _isDrilledDown = true;

            string selectedYear = cmbSchoolYear.SelectedItem?.ToString();
            string selectedCurriculum = cmbCurriculum.SelectedItem?.ToString();

            // =========================================================
            // FIX: FETCH THE COUNTS (7 / 16)
            // =========================================================
            try
            {
                // Reset counts first
                _drillSubmittedCount = 0;
                _drillTotalCount = 0;

                DataTable dtCounts = DashboardHelper.GetProgramGradeSheetCounts(_drilledProgramName, selectedYear, selectedCurriculum);

                if (dtCounts != null && dtCounts.Rows.Count > 0)
                {
                    _drillSubmittedCount = Convert.ToInt32(dtCounts.Rows[0]["SubmittedCount"]);
                    _drillTotalCount = Convert.ToInt32(dtCounts.Rows[0]["TotalCurriculumCourses"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching counts: " + ex.Message);
            }
            // =========================================================

            // 5. Get Chart Data (Year Level Distribution)
            DataTable dt = DashboardHelper.GetYearLevelDistribution(_drilledProgramName, selectedYear, selectedCurriculum);

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

            // 6. Rebuild Segments (Your existing color logic)
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

            // 7. Redraw
            LoadGridData();
            UpdateDGVLayout();
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

            // 1. Draw Header Background
            int headerHeight = (int)(50 * scale);
            if (headerHeight < 50) headerHeight = 50;
            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);
            using (SolidBrush brush = new SolidBrush(ClrMaroon))
                g.FillRectangle(brush, headerRect);

            // 2. Draw Window Buttons
            DrawWindowButtons(g, scale);

            // 3. Draw Title (Conditional Alignment)
            if (_isDrilledDown)
            {
                // --- CENTERED ALIGNMENT FOR DRILL-DOWN ---
                string programCode = _drilledProgramName;
                string labelText = " – Grade Sheets Distribution by Program Year Level";

                using (Font codeFont = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                using (Font labelFont = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                {
                    // Measure widths to calculate center
                    SizeF codeSize = g.MeasureString(programCode, codeFont);
                    SizeF labelSize = g.MeasureString(labelText, labelFont);

                    float totalWidth = codeSize.Width + labelSize.Width;
                    float xPos = (Width - totalWidth) / 2f;
                    float yPos = (headerRect.Height - codeSize.Height) / 2f;

                    // Draw Program Code (Gold)
                    using (Brush codeBrush = new SolidBrush(ClrGold))
                        g.DrawString(programCode, codeFont, codeBrush, xPos, yPos);

                    // Draw Label (Goldenrod)
                    using (Brush labelBrush = new SolidBrush(Color.Goldenrod))
                        g.DrawString(labelText, labelFont, labelBrush, xPos + codeSize.Width - (4 * scale), yPos);
                }
            }
            else
            {
                // --- LEFT ALIGNMENT FOR MAIN TITLE ---
                string title = "Grade Sheets Distribution by Program";

                // Fixed left position
                float xPos = 20 * scale;

                using (Font font = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                {
                    // Vertically centered only
                    float yPos = (headerRect.Height - g.MeasureString(title, font).Height) / 2f;

                    using (Brush brush = new SolidBrush(Color.Goldenrod))
                    {
                        g.DrawString(title, font, brush, xPos, yPos);
                    }
                }
            }

            // 4. Draw Chart Content
            int filterAreaHeight = (int)(50 * scale);
            int totalTopOffset = headerHeight + filterAreaHeight;
            Rectangle contentRect = new Rectangle(0, totalTopOffset, Width, Height - totalTopOffset);

            if (contentRect.Width < 50 || contentRect.Height < 50) return;

            long total = _currentSegments.Sum(s => (long)s.Value);
            if (total == 0 && !_isDrilledDown) return;
            if (total == 0) total = 1;

            float chartSize = 380 * scale;
            float thickness = 70 * scale;

            // Shift chart to the left when drilled down to make room for DGV
            float chartX = _isDrilledDown ? (Width * 0.30f) - (chartSize / 2f) : 150 * scale;
            float chartY = totalTopOffset + (contentRect.Height - chartSize) / 2;

            _lastChartBounds = new RectangleF(chartX, chartY, chartSize, chartSize);

            DrawShadow(g, _lastChartBounds, scale);
            DrawDoughnutWithSpokes(g, _lastChartBounds, total, thickness, scale);

            // --- CHANGE HERE: Only draw the legend if we are NOT drilled down ---
            if (!_isDrilledDown)
            {
                float legendX = _lastChartBounds.Right + (60 * scale);
                float legendY = chartY + (30 * scale);
                DrawLegendColumns(g, legendX, legendY, total, scale);
            }

            // 5. Draw Border
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

            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                if (_isDrilledDown)
                {
                    // =========================================================
                    // DRILL DOWN VIEW: Show 3 Lines (Label, Ratio, Percent)
                    // =========================================================

                    // 1. Prepare Data
                    string label = _drilledProgramName;
                    string ratioText = "";
                    string percentText = "";

                    if (_drillTotalCount > 0)
                    {
                        ratioText = $"{_drillSubmittedCount} / {_drillTotalCount}";

                        // Calculate Percentage
                        double p = ((double)_drillSubmittedCount / _drillTotalCount) * 100;
                        percentText = $"{p:0}%";
                    }
                    else
                    {
                        ratioText = total.ToString(); // Fallback
                    }

                    // 2. Draw Label (Moved Up)
                    using (Font f = new Font("Segoe UI", 11 * scale, FontStyle.Bold))
                    {
                        // cy - 35 pushes it up to make room for 3 lines
                        g.DrawString(label, f, Brushes.Gray, cx, cy - (35 * scale), sf);
                    }

                    // 3. Draw Ratio (Center)
                    // Adjust font size based on length
                    float ratioFontSize = ratioText.Length > 7 ? 20 * scale : 24 * scale;
                    using (Font f = new Font("Segoe UI", ratioFontSize, FontStyle.Bold))
                    {
                        g.DrawString(ratioText, f, new SolidBrush(Color.FromArgb(40, 40, 40)), cx, cy, sf);
                    }

                    // 4. Draw Percentage (Bottom)
                    if (!string.IsNullOrEmpty(percentText))
                    {
                        using (Font f = new Font("Segoe UI", 14 * scale, FontStyle.Bold))
                        {
                            // Using Goldenrod to make the percentage stand out, or use Gray/Green
                            g.DrawString(percentText, f, new SolidBrush(Color.Goldenrod), cx, cy + (30 * scale), sf);
                        }
                    }
                }
                else
                {
                    // =========================================================
                    // MAIN VIEW: Standard 2 Lines (Highest Program & %)
                    // =========================================================
                    string label = "Total";
                    string valueText = "0%";

                    ChartSegment largest = _currentSegments.OrderByDescending(s => s.Value).FirstOrDefault();

                    if (largest != null && total > 0)
                    {
                        label = largest.Label;
                        double percentage = ((double)largest.Value / total) * 100;
                        valueText = $"{percentage:0}%";
                    }

                    // Draw Label
                    using (Font f = new Font("Segoe UI", 12 * scale, FontStyle.Bold))
                    {
                        g.DrawString(label, f, Brushes.Gray, cx, cy - (20 * scale), sf);
                    }

                    // Draw Percentage
                    using (Font f = new Font("Segoe UI", 24 * scale, FontStyle.Bold))
                    {
                        g.DrawString(valueText, f, new SolidBrush(Color.FromArgb(40, 40, 40)), cx, cy + (15 * scale), sf);
                    }
                }
            }
        }
        //asjdasdfkas
        //asdjkfadkf
        //dfajsdfd
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

            // Define Close and Maximize Rectangles (Right Side)
            _closeBtnRect = new Rectangle(Width - margin - btnSize, margin, btnSize, btnSize);
            _maxBtnRect = new Rectangle(_closeBtnRect.X - margin - btnSize, margin, btnSize, btnSize);

            // --- DRAW HOVER EFFECT FOR CLOSE & MAX ---
            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                if (_isHoveringClose) g.FillEllipse(hoverBrush, _closeBtnRect);
                if (_isHoveringMax) g.FillEllipse(hoverBrush, _maxBtnRect);
            }

            using (Pen p = new Pen(ClrGold, 2.0f * scale))
            {
                // --- DRAW CLOSE BUTTON ---
                g.DrawEllipse(p, _closeBtnRect);
                float cx = _closeBtnRect.X + _closeBtnRect.Width / 2f;
                float cy = _closeBtnRect.Y + _closeBtnRect.Height / 2f;
                float off = 5 * (btnSize / 24f);
                g.DrawLine(p, cx - off, cy - off, cx + off, cy + off);
                g.DrawLine(p, cx + off, cy - off, cx - off, cy + off);

                // --- DRAW MAXIMIZE BUTTON ---
                g.DrawEllipse(p, _maxBtnRect);
                float mx = _maxBtnRect.X + _maxBtnRect.Width / 2f;
                float my = _maxBtnRect.Y + _maxBtnRect.Height / 2f;
                float box = 9 * (btnSize / 24f);
                g.DrawRectangle(p, mx - box / 2, my - box / 2, box, box);

                // --- DRAW BACK BUTTON (Icon + Text) ---
                if (_isDrilledDown)
                {
                    string backText = "Back";

                    using (Font font = new Font("Segoe UI", 10 * scale, FontStyle.Bold))
                    {
                        // 1. Measure the text
                        SizeF textSize = g.MeasureString(backText, font);
                        int gap = (int)(5 * scale); // Space between icon and text

                        // 2. Define the Icon Rectangle (Square)
                        Rectangle iconRect = new Rectangle(margin, margin, btnSize, btnSize);

                        // 3. Define the Full Clickable Area (Icon + Gap + Text)
                        int totalWidth = btnSize + gap + (int)textSize.Width;
                        _backBtnRect = new Rectangle(margin, margin, totalWidth, btnSize);

                        // 4. Draw Hover Effect for Back Button (Rectangle covering icon and text)
                        if (_isHoveringBack)
                        {
                            using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
                            {
                                // Draw a rounded rectangle background or simple rect
                                g.FillRectangle(hoverBrush, _backBtnRect);
                            }
                        }

                        // 5. Draw the Circle Icon
                        g.DrawEllipse(p, iconRect);

                        // 6. Draw the Arrow inside the Circle
                        float bx = iconRect.X + iconRect.Width / 2f;
                        float by = iconRect.Y + iconRect.Height / 2f;
                        float arrowSize = 5 * (btnSize / 24f);

                        PointF pTip = new PointF(bx - arrowSize, by);
                        PointF pTop = new PointF(bx + arrowSize, by - arrowSize);
                        PointF pBot = new PointF(bx + arrowSize, by + arrowSize);

                        g.DrawLine(p, pTip, pTop);
                        g.DrawLine(p, pTip, pBot);

                        // 7. Draw the "Back" Label (Vertically Centered)
                        using (Brush textBrush = new SolidBrush(ClrGold))
                        {
                            float textX = iconRect.Right + gap;
                            float textY = margin + (btnSize - textSize.Height) / 2; // Middle of the header/button height
                            g.DrawString(backText, font, textBrush, textX, textY);
                        }
                    }
                }
                else
                {
                    _backBtnRect = Rectangle.Empty;
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
                dgvYearReport.Visible = false;
                _drilledProgramName = "";

                // Show the filters again
                lblCurriculum.Visible = true;
                cmbCurriculum.Visible = true;
                lblFilter.Visible = true;
                cmbSchoolYear.Visible = true;

                LoadSchoolYearCombo();
                LoadMainData(); // This will trigger Invalidate() naturally
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

    public class DataGridViewProgressBarColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressBarColumn() { CellTemplate = new DataGridViewProgressBarCell(); }
    }

    public class DataGridViewProgressBarCell : DataGridViewImageCell
    {
        // This tells the DGV: "Don't worry that the data is a number, I will handle drawing it"
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return new Bitmap(1, 1);
        }

        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // ... (Keep your existing Paint code here) ...
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);
            double progressVal = 0;
            if (value != null && value != DBNull.Value) progressVal = Convert.ToDouble(value);

            int margin = 4;
            Rectangle barRect = new Rectangle(cellBounds.X + 5, cellBounds.Y + margin, cellBounds.Width - 10, cellBounds.Height - (margin * 2));
            g.FillRectangle(Brushes.LightGray, barRect);

            float progressWidth = (float)((progressVal / 100.0) * barRect.Width);
            if (progressWidth > 0)
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(229, 178, 66)))
                    g.FillRectangle(sb, barRect.X, barRect.Y, progressWidth, barRect.Height);
            }
            TextRenderer.DrawText(g, $"{progressVal:0}%", cellStyle.Font, barRect, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}