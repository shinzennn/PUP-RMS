using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    [ToolboxItem(true)]
    [Description("A rounded dashboard card with a left accent bar, labels, and a circular icon container.")]
    public class DashboardCard : Panel
    {
        #region Private Fields
        private int _borderRadius = 15;
        private Color _panelBackColor = Color.White;

        private string _headerText = "TOTAL GRADE SHEETS";
        private Color _headerForeColor = Color.FromArgb(64, 86, 106);
        private float _headerFontSize = 9f;

        private string _valueText = "0";
        private Color _valueForeColor = Color.Black;
        private float _valueFontSize = 24f;

        private Image _iconImage = null;
        private Color _iconBackColor = Color.FromArgb(253, 247, 228);
        private int _iconCircleSize = 50;

        private Color _sideBarColor = Color.FromArgb(212, 175, 55);
        private int _sideBarWidth = 5;
        #endregion

        #region Public Properties
        [Category("PUP_RMS Appearance")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = value; Invalidate(); } }

        [Category("PUP_RMS Appearance")]
        public Color PanelBackColor { get => _panelBackColor; set { _panelBackColor = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public string HeaderText { get => _headerText; set { _headerText = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public Color HeaderForeColor { get => _headerForeColor; set { _headerForeColor = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public float HeaderFontSize { get => _headerFontSize; set { _headerFontSize = value; Invalidate(); } }

        [Category("PUP_RMS Value")]
        public string ValueText { get => _valueText; set { _valueText = value; Invalidate(); } }

        [Category("PUP_RMS Value")]
        public Color ValueForeColor { get => _valueForeColor; set { _valueForeColor = value; Invalidate(); } }

        [Category("PUP_RMS Value")]
        public float ValueFontSize { get => _valueFontSize; set { _valueFontSize = value; Invalidate(); } }

        [Category("PUP_RMS Icon")]
        public Image IconImage { get => _iconImage; set { _iconImage = value; Invalidate(); } }

        [Category("PUP_RMS Icon")]
        public Color IconBackColor { get => _iconBackColor; set { _iconBackColor = value; Invalidate(); } }

        [Category("PUP_RMS Icon")]
        public int IconCircleSize { get => _iconCircleSize; set { _iconCircleSize = value; Invalidate(); } }

        [Category("PUP_RMS Side Bar")]
        public Color SideBarColor { get => _sideBarColor; set { _sideBarColor = value; Invalidate(); } }

        [Category("PUP_RMS Side Bar")]
        public int SideBarWidth { get => _sideBarWidth; set { _sideBarWidth = value; Invalidate(); } }
        #endregion

        public DashboardCard()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(250, 100);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            float radius = Math.Max(1, _borderRadius);

            // 1. Draw Main Rounded Background
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush bgBrush = new SolidBrush(_panelBackColor))
                {
                    g.FillPath(bgBrush, path);
                }

                // 2. Draw Left Side Accent Bar
                // We clip to the rounded path so the bar follows the curve on the left
                g.SetClip(path);
                Rectangle sideBarRect = new Rectangle(0, 0, _sideBarWidth, Height);
                using (SolidBrush sideBrush = new SolidBrush(_sideBarColor))
                {
                    g.FillRectangle(sideBrush, sideBarRect);
                }
                g.ResetClip();
            }

            // 3. Draw Icon Circle Container (Center-Right)
            int circleX = Width - _iconCircleSize - 20;
            int circleY = (Height - _iconCircleSize) / 2;
            Rectangle circleRect = new Rectangle(circleX, circleY, _iconCircleSize, _iconCircleSize);

            using (SolidBrush circleBrush = new SolidBrush(_iconBackColor))
            {
                g.FillEllipse(circleBrush, circleRect);
            }

            // 4. Draw Icon Image
            if (_iconImage != null)
            {
                int imgSize = (int)(_iconCircleSize * 0.5); // Icon takes 50% of circle area
                int imgX = circleX + (_iconCircleSize - imgSize) / 2;
                int imgY = circleY + (_iconCircleSize - imgSize) / 2;
                g.DrawImage(_iconImage, imgX, imgY, imgSize, imgSize);
            }

            // 5. Draw Header Text
            int textLeftPadding = _sideBarWidth + 15;
            using (Font hFont = new Font("Segoe UI", _headerFontSize, FontStyle.Bold))
            using (SolidBrush hBrush = new SolidBrush(_headerForeColor))
            {
                g.DrawString(_headerText, hFont, hBrush, textLeftPadding, 20);
            }

            // 6. Draw Value Text
            using (Font vFont = new Font("Segoe UI", _valueFontSize, FontStyle.Bold))
            using (SolidBrush vBrush = new SolidBrush(_valueForeColor))
            {
                g.DrawString(_valueText, vFont, vBrush, textLeftPadding - 2, 40);
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }
    }
}