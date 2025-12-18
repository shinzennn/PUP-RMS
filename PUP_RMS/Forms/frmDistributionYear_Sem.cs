using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmDistributionYear_Sem : Form
    {
        // Theme Colors
        private readonly Color ClrMaroon = Color.FromArgb(108, 42, 51);
        private readonly Color ClrGold = Color.FromArgb(229, 178, 66);
        private readonly Color ClrStandoutBack = Color.FromArgb(224, 227, 231);
        private readonly Color ClrSilver = Color.FromArgb(180, 190, 200);

        // Window Interaction State
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Rectangle _closeBtnRect, _maxBtnRect;
        private bool _isHoveringClose, _isHoveringMax;

        private List<ComboBox> filters = new List<ComboBox>();
        private string[] placeholders = { "Program", "Professor", "Subject", "School Year" };

        // --- SHADOW CONSTANT ---
        private const int CS_DROPSHADOW = 0x00020000;

        public frmDistributionYear_Sem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Size = new Size(880, 540);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ClrStandoutBack;

            CreateRoundedFilters();

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        // --- NATIVE SHADOW LOGIC ---
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // --- BACKGROUND DIMMER LOGIC ---
        public static void ShowWithDimmer(Form parent, frmDistributionYear_Sem child)
        {
            using (Form dimmer = new Form())
            {
                dimmer.StartPosition = FormStartPosition.Manual;
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.AllowTransparency = true;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.45; // "Slightly dark"
                dimmer.Size = parent.Size;
                dimmer.Location = parent.Location;
                dimmer.ShowInTaskbar = false;

                dimmer.Show();
                child.Owner = dimmer;
                child.ShowDialog();
                dimmer.Close();
            }
        }

        private void CreateRoundedFilters()
        {
            var sampleData = new Dictionary<string, string[]> {
                { "Program", new[] { "BSIT", "BSCS", "BSIS", "BSECE", "BSME" } },
                { "Professor", new[] { "Dr. Smith", "Prof. Jones", "Engr. Davis", "Dr. Wilson", "Prof. Brown" } },
                { "Subject", new[] { "Calculus", "Physics", "Programming 1", "Database Mgt", "Networking" } },
                { "School Year", new[] { "2021-2022", "2022-2023", "2023-2024", "2024-2025", "2025-2026" } }
            };

            int startX = 60;
            int width = 190;

            for (int i = 0; i < placeholders.Length; i++)
            {
                ComboBox cb = new ComboBox
                {
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 10),
                    Size = new Size(width - 25, 30),
                    Location = new Point(startX + (i * width), 85),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    Tag = placeholders[i]
                };

                cb.Items.Add(placeholders[i]);
                cb.Items.AddRange(sampleData[placeholders[i]]);
                cb.SelectedIndex = 0;

                cb.DrawItem += Cb_DrawItem;
                cb.SelectedIndexChanged += (s, e) => this.Invalidate();

                filters.Add(cb);
                this.Controls.Add(cb);
            }
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. Header Area
            using (SolidBrush headerBrush = new SolidBrush(ClrMaroon))
                g.FillRectangle(headerBrush, 0, 0, Width, 50);

            using (Font f = new Font("Segoe UI", 12, FontStyle.Bold))
                g.DrawString("Academic Year & Semester Grade Sheets Distribution", f, new SolidBrush(ClrGold), 20, 14);

            DrawWindowButtons(g);

            // 2. ComboBox Borders
            foreach (var cb in filters)
            {
                using (Pen p = new Pen(ClrGold, 1.5f))
                {
                    Rectangle rect = new Rectangle(cb.Left - 2, cb.Top - 2, cb.Width + 4, cb.Height + 4);
                    g.DrawRoundedRectangle(p, rect, 8);
                }
            }

            // 3. Inner Chart Panel (Maroon)
            Rectangle innerPanel = new Rectangle(100, 150, 700, 340);
            using (SolidBrush panelBrush = new SolidBrush(ClrMaroon))
                g.FillRoundedRectangle(panelBrush, innerPanel, 20);

            DrawSelectionLabel(g, innerPanel);

            // 5. Vertical Label
            using (Font verticalFont = new Font("Segoe UI Semibold", 8))
            {
                g.TranslateTransform(innerPanel.X + 25, innerPanel.Y + 220);
                g.RotateTransform(-90);
                g.DrawString("TOTAL GRADE SHEETS", verticalFont, Brushes.WhiteSmoke, 0, 0);
                g.ResetTransform();
            }

            DrawBars(g, innerPanel);

            // 6. Subtle Form Border
            using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private void DrawSelectionLabel(Graphics g, Rectangle container)
        {
            List<string> displayParts = new List<string>();
            foreach (var cb in filters) displayParts.Add(cb.Text.ToUpper());
            string display = string.Join(" | ", displayParts);

            using (Font f = new Font("Segoe UI", 9, FontStyle.Bold))
            {
                Rectangle textRect = new Rectangle(container.X, container.Y + 15, container.Width, 25);
                using (LinearGradientBrush lgb = new LinearGradientBrush(textRect, ClrGold, Color.White, 0f))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(display, f, lgb, textRect, sf);
                }
            }
        }

        private void DrawBars(Graphics g, Rectangle container)
        {
            int baseY = container.Y + container.Height - 60;
            int chartHeight = container.Height - 140;

            // 1st Sem Bar (Gold)
            Rectangle bar1 = new Rectangle(container.X + 180, baseY - chartHeight, 75, chartHeight);
            using (LinearGradientBrush lgb = new LinearGradientBrush(bar1, ClrGold, Color.Orange, 90f))
                g.FillRoundedRectangle(lgb, bar1, 10);

            // 2nd Sem Bar (Silver)
            int bar2Height = (int)(chartHeight * 0.82);
            Rectangle bar2 = new Rectangle(container.X + 400, baseY - bar2Height, 75, bar2Height);
            using (SolidBrush silverBrush = new SolidBrush(ClrSilver))
                g.FillRoundedRectangle(silverBrush, bar2, 10);

            using (Font f = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                g.DrawString("4500", f, Brushes.White, bar1.X + 18, bar1.Y - 25);
                g.DrawString("3800", f, Brushes.White, bar2.X + 18, bar2.Y - 25);
                g.DrawString("1st Sem", f, Brushes.White, bar1.X + 10, baseY + 10);
                g.DrawString("2nd Sem", f, Brushes.White, bar2.X + 10, baseY + 10);
            }

            using (Pen p = new Pen(Color.White, 1.5f))
                g.DrawLine(p, container.X + 80, baseY, container.X + container.Width - 80, baseY);
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
    }

    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle bounds, int radius)
        { using (GraphicsPath path = RoundedRect(bounds, radius)) g.DrawPath(pen, path); }
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int radius)
        { using (GraphicsPath path = RoundedRect(bounds, radius)) g.FillPath(brush, path); }
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}