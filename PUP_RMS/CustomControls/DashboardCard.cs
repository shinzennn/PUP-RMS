using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    [ToolboxItem(true)]
    [Description("A rounded dashboard card with a floating bottom shadow. All shadow properties are now editable.")]
    public class DashboardCard : Panel
    {
        #region Private Fields
        private int _borderRadius = 15;
        private Color _panelBackColor = Color.White;

        private string _headerText = "TOTAL GRADE SHEETS";
        private Color _headerForeColor = Color.FromArgb(100, 116, 139);
        private float _headerFontSize = 9f;

        private string _valueText = "0";
        private Color _valueForeColor = Color.Black;
        private float _valueFontSize = 24f;

        private Image _iconImage = null;
        private Color _iconBackColor = Color.FromArgb(253, 247, 228);
        private int _iconCircleSize = 50;

        private Color _sideBarColor = Color.FromArgb(212, 175, 55);
        private int _sideBarWidth = 5;

        // Shadow Fields
        private bool _showShadow = true;
        private int _shadowDepth = 5;
        private int _shadowPadding = 10;
        private Color _shadowColor = Color.FromArgb(40, 0, 0, 0);
        #endregion

        #region Public Properties

        // --- NEW SHADOW PROPERTIES FOR PROPERTY WINDOW ---
        [Category("PUP_RMS Shadow"), Browsable(true), Description("Enable or disable the bottom shadow.")]
        public bool ShowShadow { get => _showShadow; set { _showShadow = value; Invalidate(); } }

        [Category("PUP_RMS Shadow"), Browsable(true), Description("How far the shadow extends downwards.")]
        public int ShadowDepth { get => _shadowDepth; set { _shadowDepth = value; Invalidate(); } }

        [Category("PUP_RMS Shadow"), Browsable(true), Description("Spacing around the card to prevent the shadow from being clipped.")]
        public int ShadowPadding { get => _shadowPadding; set { _shadowPadding = value; Invalidate(); } }

        [Category("PUP_RMS Shadow"), Browsable(true), Description("The color and transparency of the shadow.")]
        public Color ShadowColor { get => _shadowColor; set { _shadowColor = value; Invalidate(); } }

        // --- EXISTING PROPERTIES ---
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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Define the main card rectangle (Leaving space for shadow padding)
            // We use '5' as a small offset so the shadow isn't cut off on the top/left either
            Rectangle rect = new Rectangle(5, 2, Width - 11, Height - _shadowPadding - 2);
            float radius = Math.Max(1, _borderRadius);

            // 1. Draw Directional Bottom Shadow
            if (_showShadow)
            {
                for (int i = 1; i <= _shadowDepth; i++)
                {
                    // Shift shadow downwards by 'i' pixels
                    Rectangle shadowRect = new Rectangle(rect.X, rect.Y + i, rect.Width, rect.Height);
                    using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, radius))
                    {
                        int alpha = Math.Max(0, _shadowColor.A / (i + 1));
                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, _shadowColor)))
                        {
                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }

            // 2. Draw Main Background
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush bgBrush = new SolidBrush(_panelBackColor))
                {
                    g.FillPath(bgBrush, path);
                }

                // 3. Draw Side Bar (Clipped to left)
                g.SetClip(path);
                Rectangle sideBarRect = new Rectangle(rect.X, rect.Y, _sideBarWidth, rect.Height);
                using (SolidBrush sideBrush = new SolidBrush(_sideBarColor))
                {
                    g.FillRectangle(sideBrush, sideBarRect);
                }
                g.ResetClip();
            }

            // 4. Draw Icon Circle Container (Coordinates preserved from your layout)
            int circleX = rect.Right - _iconCircleSize - 15;
            int circleY = rect.Y + (rect.Height - _iconCircleSize) / 2;
            Rectangle circleRect = new Rectangle(circleX, circleY, _iconCircleSize, _iconCircleSize);

            using (SolidBrush circleBrush = new SolidBrush(_iconBackColor))
            {
                g.FillEllipse(circleBrush, circleRect);
            }

            // 5. Draw Icon Image
            if (_iconImage != null)
            {
                int imgSize = (int)(_iconCircleSize * 0.55);
                int imgX = circleX + (_iconCircleSize - imgSize) / 2;
                int imgY = circleY + (_iconCircleSize - imgSize) / 2;
                g.DrawImage(_iconImage, imgX, imgY, imgSize, imgSize);
            }

            // 6. Draw Text
            int textLeftPadding = rect.X + _sideBarWidth + 15;

            // Header
            using (Font hFont = new Font("Segoe UI Semibold", _headerFontSize))
            using (SolidBrush hBrush = new SolidBrush(_headerForeColor))
            {
                g.DrawString(_headerText, hFont, hBrush, textLeftPadding, rect.Y + 18);
            }

            // Value
            using (Font vFont = new Font("Segoe UI", _valueFontSize, FontStyle.Bold))
            using (SolidBrush vBrush = new SolidBrush(_valueForeColor))
            {
                g.DrawString(_valueText, vFont, vBrush, textLeftPadding - 2, rect.Y + 38);
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