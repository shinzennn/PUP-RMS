using System;
using System.Collections.Generic;
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

        // Shadow and Form Styles
        private const int CS_DROPSHADOW = 0x00020000;

        public frmDistributionProfessor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            SetupFormDesign();
            LoadFacultyData();
        }

        // Native Shadow Effect
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // --- METHOD TO CALL FOR DIMMED BACKGROUND ---
        public static void ShowWithDimmer(Form parent, frmDistributionProfessor child)
        {
            using (Form dimmer = new Form())
            {
                dimmer.StartPosition = FormStartPosition.Manual;
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.AllowTransparency = true;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.45; // Adjust this for "not too dark" (0.1 to 0.5)

                // Cover the parent form or the whole screen
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
            this.Size = new Size(880, 540);
            this.BackColor = ClrStandoutBack;

            // 1. MUST Initialize the container BEFORE using it
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

            // 2. Now apply the DoubleBuffered fix using Reflection
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, listContainer, new object[] { true });

            this.Controls.Add(listContainer);

            // 3. Updated Resize logic for better scrollbar handling
            this.Resize += (s, e) =>
            {
                listContainer.Size = new Size(this.Width, this.Height - 50);

                foreach (Control ctrl in listContainer.Controls)
                {
                    if (ctrl is Panel row)
                    {
                        // Use ClientSize.Width to automatically account for the scrollbar's width
                        row.Width = listContainer.ClientSize.Width - (listContainer.Padding.Left + listContainer.Padding.Right);
                    }
                }
                this.Invalidate();
            };

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        private void LoadFacultyData()
        {
            var facultyList = new List<(string Name, int Progress, int Records)> {
                ("Prof. Maria Santos", 85, 550),
                ("Prof. John Cruz", 70, 320),
                ("Prof. David Lee", 45, 180),
                ("Prof. Anna Belen", 30, 70)
            };

            foreach (var faculty in facultyList)
                listContainer.Controls.Add(CreateFacultyRow(faculty.Name, faculty.Progress, faculty.Records));
        }

        private Panel CreateFacultyRow(string name, int progress, int records)
        {
            Panel row = new Panel
            {
                Width = listContainer.Width - 80,
                Height = 100,
                Margin = new Padding(0, 0, 0, 15),
                BackColor = ClrCardWhite
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

            Panel progressBar = new Panel { Location = new Point(100, 58), Size = new Size(400, 10), BackColor = Color.FromArgb(230, 230, 230) };
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
                Location = new Point(515, 54),
                AutoSize = true,
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.Gray
            };

            row.Controls.Add(picAvatar); row.Controls.Add(lblName); row.Controls.Add(progressBar); row.Controls.Add(lblRecords);

            row.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(210, 210, 210), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, row.Width - 1, row.Height - 1);
            };

            return row;
        }

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
                e.Graphics.DrawString("Grade Sheets Distribution by Professor", f, new SolidBrush(ClrGold), 20, 14);
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

        private void frmDistributionProfessor_Load(object sender, EventArgs e)
        {

        }

        private void frmDistributionProfessor_Load_1(object sender, EventArgs e)
        {

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
}