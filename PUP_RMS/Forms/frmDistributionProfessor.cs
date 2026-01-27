using PUP_RMS.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionProfessor : Form
    {
        // Theme Colors
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrStandoutBack = Color.FromArgb(224, 227, 231);
        private readonly Color ClrCardWhite = Color.White;
        private readonly Color ClrIconGray = Color.FromArgb(180, 180, 180);

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Rectangle _closeBtnRect, _maxBtnRect;
        private bool _isHoveringClose, _isHoveringMax;
        private FlowLayoutPanel listContainer;

        // Filter Controls
        private Label lblFilterYear;
        private ComboBox cmbSchoolYear;

        // NEW: Curriculum Controls
        private Label lblFilterCurriculum;
        private ComboBox cmbCurriculum;

        private const int CS_DROPSHADOW = 0x00020000;

        public frmDistributionProfessor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            SetupFormDesign();
            SetupFilterControls();

            // Load initial data
            LoadFacultyData();
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

        public static void ShowWithDimmer(Form parent, Form child)
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
            this.Size = new Size(950, 560); // Slightly wider to fit two filters
            this.BackColor = ClrStandoutBack;

            listContainer = new FlowLayoutPanel
            {
                Location = new Point(0, 50),
                Size = new Size(this.Width, this.Height - 50),
                AutoScroll = true,
                Padding = new Padding(30, 20, 30, 20),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            // Double Buffer Fix
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, listContainer, new object[] { true });

            this.Controls.Add(listContainer);

            this.Resize += (s, e) =>
            {
                listContainer.Size = new Size(this.Width, this.Height - 50);
                foreach (Control ctrl in listContainer.Controls)
                {
                    if (ctrl is Panel row)
                        row.Width = listContainer.ClientSize.Width - (listContainer.Padding.Left + listContainer.Padding.Right);
                }
                RepositionFilterControls();
                this.Invalidate();
            };

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        // =========================================================
        // SETUP FILTER CONTROLS
        // =========================================================
        private void SetupFilterControls()
        {
            // --- 1. School Year Filter ---
            lblFilterYear = new Label
            {
                Text = "School Year:",
                ForeColor = ClrGold,
                BackColor = ClrMaroon,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true
            };

            cmbSchoolYear = new ComboBox
            {
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 120,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Load School Years
            cmbSchoolYear.Items.Add("All");
            try
            {
                DataTable dt = DashboardHelper.GetSchoolYears();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                        cmbSchoolYear.Items.Add(row["SchoolYear"].ToString());
                }
            }
            catch { }
            if (cmbSchoolYear.Items.Count > 0) cmbSchoolYear.SelectedIndex = 0;
            cmbSchoolYear.SelectedIndexChanged += (s, e) => LoadFacultyData();


            // --- 2. Curriculum Filter (NEW) ---
            lblFilterCurriculum = new Label
            {
                Text = "Curriculum:",
                ForeColor = ClrGold,
                BackColor = ClrMaroon,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true
            };

            cmbCurriculum = new ComboBox
            {
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 100,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Load Curriculum Years
            cmbCurriculum.Items.Add("All");
            try
            {
                // Ensure you have DashboardHelper.GetCurriculumYears() implemented
                DataTable dtCurr = DashboardHelper.GetCurriculums();
                if (dtCurr != null)
                {
                    foreach (DataRow row in dtCurr.Rows)
                        cmbCurriculum.Items.Add(row["CurriculumYear"].ToString());
                }
            }
            catch { }
            if (cmbCurriculum.Items.Count > 0) cmbCurriculum.SelectedIndex = 0;
            cmbCurriculum.SelectedIndexChanged += (s, e) => LoadFacultyData();

            // Add to form
            this.Controls.Add(cmbSchoolYear);
            this.Controls.Add(lblFilterYear);
            this.Controls.Add(cmbCurriculum);
            this.Controls.Add(lblFilterCurriculum);

            RepositionFilterControls();
        }

        private void RepositionFilterControls()
        {
            if (lblFilterYear == null || cmbSchoolYear == null || lblFilterCurriculum == null || cmbCurriculum == null) return;

            int headerHeight = 50;
            int gap = 10;
            int sectionGap = 20; // Space between the two filters

            // Right margin to avoid window buttons (Close/Max)
            int startX = this.Width - 90;
            int comboY = (headerHeight - cmbSchoolYear.Height) / 2;
            int labelY = (headerHeight - lblFilterYear.Height) / 2;

            // 1. Position School Year (Rightmost)
            cmbSchoolYear.Location = new Point(startX - cmbSchoolYear.Width, comboY);
            lblFilterYear.Location = new Point(cmbSchoolYear.Left - lblFilterYear.Width - gap, labelY);

            // 2. Position Curriculum (To the left of School Year)
            cmbCurriculum.Location = new Point(lblFilterYear.Left - cmbCurriculum.Width - sectionGap, comboY);
            lblFilterCurriculum.Location = new Point(cmbCurriculum.Left - lblFilterCurriculum.Width - gap, labelY);

            cmbSchoolYear.BringToFront();
            lblFilterYear.BringToFront();
            cmbCurriculum.BringToFront();
            lblFilterCurriculum.BringToFront();
        }

        // =========================================================
        // DATA LOADING
        // =========================================================
        private void LoadFacultyData()
        {
            listContainer.Controls.Clear();

            string selectedSchoolYear = null;
            string selectedCurriculum = null;

            // Get School Year Value
            if (cmbSchoolYear != null && cmbSchoolYear.SelectedItem != null)
                selectedSchoolYear = cmbSchoolYear.SelectedItem.ToString();

            // Get Curriculum Value
            if (cmbCurriculum != null && cmbCurriculum.SelectedItem != null)
                selectedCurriculum = cmbCurriculum.SelectedItem.ToString();

            // Call Helper with BOTH filters
            // Make sure your Helper method accepts two arguments now: GetFacultyDistribution(schoolYear, curriculumYear)
            DataTable dt = DashboardHelper.GetFacultyDistribution(selectedSchoolYear, selectedCurriculum);

            if (dt == null || dt.Rows.Count == 0)
            {
                // Optional: Show "No Records" label
                Label lblNoData = new Label
                {
                    Text = "No records found for this filter.",
                    AutoSize = true,
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 12),
                    Padding = new Padding(20)
                };
                listContainer.Controls.Add(lblNoData);
                return;
            }

            int maxRecords = Convert.ToInt32(dt.Rows[0]["RecordCount"]);
            if (maxRecords == 0) maxRecords = 1;

            foreach (DataRow row in dt.Rows)
            {
                string name = row["Name"].ToString();
                int records = Convert.ToInt32(row["RecordCount"]);
                int progress = (int)((double)records / maxRecords * 100);

                listContainer.Controls.Add(CreateFacultyRow(name, progress, records));
            }
        }

        private Panel CreateFacultyRow(string name, int progress, int records)
        {
            Panel row = new Panel
            {
                Width = listContainer.ClientSize.Width - (listContainer.Padding.Left + listContainer.Padding.Right),
                Height = 100,
                Margin = new Padding(0, 0, 0, 15),
                BackColor = ClrCardWhite,
                Cursor = Cursors.Hand // Change cursor to indicate clickability
            };

            PictureBox picAvatar = new PictureBox { Size = new Size(65, 65), Location = new Point(20, 17), BackColor = Color.Transparent };
            picAvatar.Paint += (s, e) => DrawProfileWithStar(e.Graphics, picAvatar.ClientRectangle);

            Label lblName = new Label
            {
                Text = name,
                Location = new Point(100, 22),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12f),
                ForeColor = Color.FromArgb(45, 45, 45)
            };

            Panel progressBar = new Panel
            {
                Location = new Point(100, 58),
                Height = 10,
                BackColor = Color.FromArgb(230, 230, 230),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            progressBar.Width = row.Width - 250;

            progressBar.Paint += (s, e) => {
                float fillWidth = (progress / 100f) * progressBar.Width;
                if (fillWidth > 0)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, (int)fillWidth, 10), ClrMaroon, ClrGold, 0f))
                        e.Graphics.FillRectangle(brush, 0, 0, fillWidth, 10);
                }
            };

            Label lblRecords = new Label
            {
                Text = $"{records} Grade Sheets",
                AutoSize = true,
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.Gray,
                Anchor = AnchorStyles.Right
            };
            lblRecords.Location = new Point(progressBar.Right + 15, 54);

            row.Controls.Add(picAvatar);
            row.Controls.Add(lblName);
            row.Controls.Add(progressBar);
            row.Controls.Add(lblRecords);

            // --- CLICK EVENT HANDLER (Drill Down) ---
            EventHandler openDetails = (s, e) =>
            {
                // 1. Get current filter values
                string selectedSY = (cmbSchoolYear.SelectedItem != null) ? cmbSchoolYear.SelectedItem.ToString() : null;
                string selectedCurr = (cmbCurriculum.SelectedItem != null) ? cmbCurriculum.SelectedItem.ToString() : null;

                // 2. Open the Drill Down Form
                frmProfessorDrillDown detailsForm = new frmProfessorDrillDown(name, selectedSY, selectedCurr);

                // 3. Show with Dimmer (Reuse your existing dimmer method logic)
                ShowWithDimmer(this, detailsForm);
            };

            // Attach event to ALL controls in the row so clicking anywhere works
            row.Click += openDetails;
            lblName.Click += openDetails;
            picAvatar.Click += openDetails;
            lblRecords.Click += openDetails;
            progressBar.Click += openDetails;

            // --- End Click Event Handler ---

            row.Resize += (s, e) =>
            {
                progressBar.Width = row.Width - 250;
                lblRecords.Location = new Point(progressBar.Right + 15, 54);
                progressBar.Invalidate();
            };

            row.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(210, 210, 210), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, row.Width - 1, row.Height - 1);
            };

            return row;
        }

        // =========================================================
        // GRAPHICS & PAINTING
        // =========================================================
        private void DrawProfileWithStar(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush bg = new SolidBrush(Color.FromArgb(245, 245, 245))) g.FillEllipse(bg, bounds);
            float cx = bounds.Width / 2f, cy = bounds.Height / 2f;
            g.FillEllipse(new SolidBrush(ClrIconGray), cx - 12, cy - 20, 24, 24);
            g.FillPie(new SolidBrush(ClrIconGray), cx - 25, cy + 5, 50, 45, 180, 180);
            DrawStar(g, new PointF(bounds.Right - 12, bounds.Top + 12), 16);
        }

        private void DrawStar(Graphics g, PointF center, float size)
        {
            GraphicsPath path = new GraphicsPath();
            int points = 5;
            float oR = size / 2f, iR = oR * 0.45f;
            PointF[] p = new PointF[points * 2];
            for (int i = 0; i < points * 2; i++)
            {
                float r = (i % 2 == 0) ? oR : iR;
                double a = (Math.PI * i / points) - (Math.PI / 2);
                p[i] = new PointF(center.X + (float)(r * Math.Cos(a)), center.Y + (float)(r * Math.Sin(a)));
            }
            path.AddLines(p); path.CloseFigure();
            g.FillPath(new SolidBrush(ClrGold), path);
            g.DrawPath(new Pen(ClrMaroon, 1.2f), path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush brush = new SolidBrush(ClrMaroon)) e.Graphics.FillRectangle(brush, 0, 0, Width, 50);
            using (Font f = new Font("Segoe UI Semibold", 12))
                e.Graphics.DrawString("Grade Sheets by Professor", f, new SolidBrush(ClrGold), 20, 14);
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
            if (_closeBtnRect.Contains(e.Location))
            {
                this.Close();
                return;
            }

            if (_maxBtnRect.Contains(e.Location))
            {
                this.WindowState = (this.WindowState == FormWindowState.Maximized)
                                   ? FormWindowState.Normal
                                   : FormWindowState.Maximized;
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

        private void Form_MouseUp(object sender, MouseEventArgs e) => dragging = false;

        private void frmDistributionProfessor_Load(object sender, EventArgs e) { }
    }
}