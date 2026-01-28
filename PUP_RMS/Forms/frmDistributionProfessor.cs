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
        private Label lblFilterCurriculum;
        private ComboBox cmbCurriculum;

        // NEW: Search Controls
        private TextBox txtSearch;
        private Button btnSearch;

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
            this.Size = new Size(950, 560);
            this.BackColor = ClrStandoutBack;

            listContainer = new FlowLayoutPanel
            {
                Location = new Point(0, 100),
                Size = new Size(this.Width, this.Height - 100),
                AutoScroll = true,
                Padding = new Padding(30, 20, 30, 20),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, listContainer, new object[] { true });

            this.Controls.Add(listContainer);

            this.Resize += (s, e) =>
            {
                listContainer.Size = new Size(this.Width, this.Height - 100);
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
        // SETUP FILTER & SEARCH CONTROLS
        // =========================================================
        private void SetupFilterControls()
        {
            // 1. School Year
            lblFilterYear = new Label
            {
                Text = "School Year:",
                ForeColor = Color.FromArgb(64, 64, 64),
                BackColor = Color.Transparent,
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
            // Clear search when filter changes so we show all new results
            cmbSchoolYear.SelectedIndexChanged += (s, e) => { txtSearch.Clear(); LoadFacultyData(); };


            // 2. Curriculum
            lblFilterCurriculum = new Label
            {
                Text = "Curriculum:",
                ForeColor = Color.FromArgb(64, 64, 64),
                BackColor = Color.Transparent,
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

            cmbCurriculum.Items.Add("All");
            try
            {
                DataTable dtCurr = DashboardHelper.GetCurriculums();
                if (dtCurr != null)
                {
                    foreach (DataRow row in dtCurr.Rows)
                        cmbCurriculum.Items.Add(row["CurriculumYear"].ToString());
                }
            }
            catch { }
            if (cmbCurriculum.Items.Count > 0) cmbCurriculum.SelectedIndex = 0;
            // Clear search when filter changes
            cmbCurriculum.SelectedIndexChanged += (s, e) => { txtSearch.Clear(); LoadFacultyData(); };

            // 3. NEW SEARCH CONTROLS
            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Width = 200,
                BorderStyle = BorderStyle.FixedSingle,
                // Setup Autocomplete
                AutoCompleteMode = AutoCompleteMode.Suggest, // Shows suggestions
                AutoCompleteSource = AutoCompleteSource.CustomSource
            };

            // Trigger load on Enter key
            txtSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    LoadFacultyData(true); // true = use search filter
                    e.SuppressKeyPress = true; // prevent ding sound
                }
            };

            // Optional: Live search as you type (uncomment if desired)
            // txtSearch.TextChanged += (s, e) => LoadFacultyData(true);

            btnSearch = new Button
            {
                Text = "Search",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                BackColor = ClrMaroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 27),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) => LoadFacultyData(true);

            // Add to form
            this.Controls.Add(cmbSchoolYear);
            this.Controls.Add(lblFilterYear);
            this.Controls.Add(cmbCurriculum);
            this.Controls.Add(lblFilterCurriculum);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);

            RepositionFilterControls();
        }

        private void RepositionFilterControls()
        {
            if (lblFilterYear == null) return;

            int headerHeight = 50;
            int yPos = headerHeight + 12;
            int padding = 5;
            int groupSpacing = 20;

            // Calculate Widths
            int group1W = lblFilterCurriculum.Width + padding + cmbCurriculum.Width;
            int group2W = lblFilterYear.Width + padding + cmbSchoolYear.Width;
            int group3W = txtSearch.Width + padding + btnSearch.Width;

            int totalWidth = group1W + groupSpacing + group2W + groupSpacing + group3W;

            // Center X
            int startX = (this.Width - totalWidth) / 2;

            // Position Curriculum
            lblFilterCurriculum.Location = new Point(startX, yPos + 3);
            cmbCurriculum.Location = new Point(lblFilterCurriculum.Right + padding, yPos);

            // Position Year
            int startX2 = cmbCurriculum.Right + groupSpacing;
            lblFilterYear.Location = new Point(startX2, yPos + 3);
            cmbSchoolYear.Location = new Point(lblFilterYear.Right + padding, yPos);

            // Position Search
            int startX3 = cmbSchoolYear.Right + groupSpacing;
            txtSearch.Location = new Point(startX3, yPos);
            btnSearch.Location = new Point(txtSearch.Right + padding, yPos - 1); // -1 for visual alignment with textbox border

            // Bring to front
            foreach (Control c in new Control[] { cmbSchoolYear, lblFilterYear, cmbCurriculum, lblFilterCurriculum, txtSearch, btnSearch })
                c.BringToFront();
        }

        // =========================================================
        // DATA LOADING & SEARCH LOGIC
        // =========================================================
        /// <param name="applySearchFilter">If true, filters results based on textbox. If false, reloads all data.</param>
        private void LoadFacultyData(bool applySearchFilter = false)
        {
            listContainer.Controls.Clear();

            string selectedSchoolYear = null;
            string selectedCurriculum = null;

            if (cmbSchoolYear.SelectedItem != null) selectedSchoolYear = cmbSchoolYear.SelectedItem.ToString();
            if (cmbCurriculum.SelectedItem != null) selectedCurriculum = cmbCurriculum.SelectedItem.ToString();

            // 1. Get ALL data for the selected filters (Year/Curriculum)
            DataTable dt = DashboardHelper.GetFacultyDistribution(selectedSchoolYear, selectedCurriculum);

            if (dt == null || dt.Rows.Count == 0)
            {
                ShowNoDataLabel("No records found for this filter.");
                return;
            }

            // 2. UPDATE AUTOCOMPLETE SUGGESTIONS
            // This ensures the suggestions are "based on the filtered combobox"
            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                suggestions.Add(row["Name"].ToString());
            }
            txtSearch.AutoCompleteCustomSource = suggestions;

            // 3. APPLY SEARCH FILTER (In-Memory)
            DataView dv = dt.DefaultView;
            if (applySearchFilter && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                // Escape special characters for RowFilter if necessary, simple approach here:
                // This filters the DataTable result to only show the typed name
                string safeSearch = txtSearch.Text.Trim().Replace("'", "''");
                dv.RowFilter = $"Name LIKE '%{safeSearch}%'";
            }

            if (dv.Count == 0)
            {
                ShowNoDataLabel($"No results for '{txtSearch.Text}' in this School Year.");
                return;
            }

            // 4. RENDER UI
            // Calculate max for progress bar based on the filtered view (or original dt if you prefer relative to total)
            int maxRecords = 1;
            // Usually we want the progress bar relative to the highest visible or highest total. 
            // Let's use the highest in the current view.
            foreach (DataRowView row in dv)
            {
                int val = Convert.ToInt32(row["RecordCount"]);
                if (val > maxRecords) maxRecords = val;
            }

            foreach (DataRowView row in dv)
            {
                string name = row["Name"].ToString();
                int records = Convert.ToInt32(row["RecordCount"]);
                int progress = (int)((double)records / maxRecords * 100);

                listContainer.Controls.Add(CreateFacultyRow(name, progress, records));
            }
        }

        private void ShowNoDataLabel(string message)
        {
            Label lblNoData = new Label
            {
                Text = message,
                AutoSize = true,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 12),
                Padding = new Padding(20)
            };
            listContainer.Controls.Add(lblNoData);
        }

        private Panel CreateFacultyRow(string name, int progress, int records)
        {
            Panel row = new Panel
            {
                Width = listContainer.ClientSize.Width - (listContainer.Padding.Left + listContainer.Padding.Right),
                Height = 100,
                Margin = new Padding(0, 0, 0, 15),
                BackColor = ClrCardWhite,
                Cursor = Cursors.Hand
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

            // Click Event
            EventHandler openDetails = (s, e) =>
            {
                string selectedSY = (cmbSchoolYear.SelectedItem != null) ? cmbSchoolYear.SelectedItem.ToString() : null;
                string selectedCurr = (cmbCurriculum.SelectedItem != null) ? cmbCurriculum.SelectedItem.ToString() : null;
                frmProfessorDrillDown detailsForm = new frmProfessorDrillDown(name, selectedSY, selectedCurr);
                ShowWithDimmer(this, detailsForm);
            };

            row.Click += openDetails;
            lblName.Click += openDetails;
            picAvatar.Click += openDetails;
            lblRecords.Click += openDetails;
            progressBar.Click += openDetails;

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
    }
}