using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    [ToolboxItem(true)]
    [Description("A reusable, rounded panel control with a surround-shadow 'floating' effect and toggleable hover interaction.")]
    public class HeaderPanelCard : Panel
    {
        #region Private Fields
        private Image _iconHeader = null;
        private int _iconSize = 22;
        private string _headerLabel = "Record Distribution";
        private Color _headerBackColor = Color.FromArgb(250, 251, 252);
        private Color _headerForeColor = Color.FromArgb(20, 40, 80);
        private float _headerFontSize = 10.5f;
        private int _headerHeight = 45;
        private int _borderRadius = 10;
        private Color _borderColor = Color.FromArgb(230, 233, 237);
        private int _borderThickness = 1;
        private Color _contentBackColor = Color.White;

        // Shadow and Divider Fields
        private bool _showHeaderDivider = true;
        private bool _showShadow = true;
        private Color _shadowColor = Color.FromArgb(30, 0, 0, 0);
        private int _shadowDepth = 6;
        private int _shadowPadding = 12;
        private bool _isHovered = false;
        private bool _enableHoverEffect = false;
        #endregion

        #region Public Properties

        [Category("PUP_RMS Shadow"), Description("If true, the shadow deepens when the mouse enters the card.")]
        public bool EnableHoverEffect
        {
            get => _enableHoverEffect;
            set { _enableHoverEffect = value; Invalidate(); }
        }

        [Category("PUP_RMS Shadow"), Description("Enable or disable the surround shadow effect.")]
        public bool ShowShadow
        {
            get => _showShadow;
            set { _showShadow = value; Invalidate(); }
        }

        [Category("PUP_RMS Shadow"), Description("The color and transparency (Alpha) of the shadow.")]
        public Color ShadowColor
        {
            get => _shadowColor;
            set { _shadowColor = value; Invalidate(); }
        }

        [Category("PUP_RMS Shadow"), Description("The thickness/spread of the shadow.")]
        public int ShadowDepth
        {
            get => _shadowDepth;
            set { _shadowDepth = value; Invalidate(); }
        }

        [Category("PUP_RMS Shadow"), Description("Internal spacing to prevent the shadow from being cut off at the edges.")]
        public int ShadowPadding
        {
            get => _shadowPadding;
            set { _shadowPadding = value; Invalidate(); }
        }

        [Category("PUP_RMS Header")]
        public Image IconHeader { get => _iconHeader; set { _iconHeader = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public int IconSize { get => _iconSize; set { _iconSize = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public string HeaderLabel { get => _headerLabel; set { _headerLabel = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public Color HeaderForeColor { get => _headerForeColor; set { _headerForeColor = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public float HeaderFontSize { get => _headerFontSize; set { _headerFontSize = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public Color HeaderBackColor { get => _headerBackColor; set { _headerBackColor = value; Invalidate(); } }

        [Category("PUP_RMS Header")]
        public int HeaderHeight { get => _headerHeight; set { _headerHeight = value; Invalidate(); PerformLayout(); } }

        [Category("PUP_RMS Header")]
        public bool ShowHeaderDivider { get => _showHeaderDivider; set { _showHeaderDivider = value; Invalidate(); } }

        [Category("PUP_RMS Appearance")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = value; Invalidate(); } }

        [Category("PUP_RMS Appearance")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("PUP_RMS Appearance")]
        public int BorderThickness { get => _borderThickness; set { _borderThickness = value; Invalidate(); } }

        [Category("PUP_RMS Appearance")]
        public Color ContentBackColor { get => _contentBackColor; set { _contentBackColor = value; Invalidate(); } }

        public override Rectangle DisplayRectangle
        {
            get
            {
                int offset = _showShadow ? _shadowPadding : 0;
                return new Rectangle(
                    _borderThickness + 10 + offset,
                    _headerHeight + _borderThickness + 5 + offset,
                    Width - (_borderThickness * 2) - 20 - (offset * 2),
                    Height - _headerHeight - (_borderThickness * 2) - 15 - (offset * 2)
                );
            }
        }
        #endregion

        public HeaderPanelCard()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(300, 250);
            this.BackColor = Color.Transparent;
        }

        #region Interaction Overrides
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_enableHoverEffect)
            {
                _isHovered = true;
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_enableHoverEffect)
            {
                _isHovered = false;
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int pad = _showShadow ? _shadowPadding : 0;
            Rectangle rect = new Rectangle(pad, pad, Width - 1 - (pad * 2), Height - 1 - (pad * 2));
            float radius = Math.Max(1, BorderRadius);

            // 1. Draw "Surround/Glow" Shadow logic
            if (_showShadow)
            {
                int currentDepth = (_enableHoverEffect && _isHovered) ? _shadowDepth + 2 : _shadowDepth;
                int baseAlpha = (_enableHoverEffect && _isHovered) ? _shadowColor.A + 20 : _shadowColor.A;

                for (int i = 1; i <= currentDepth; i++)
                {
                    Rectangle shadowRect = rect;
                    shadowRect.Inflate(i, i);

                    using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, radius + i))
                    {
                        int alpha = Math.Max(0, baseAlpha - (i * (baseAlpha / currentDepth)));
                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, _shadowColor)))
                        {
                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }

            // 2. Main Body
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush contentBrush = new SolidBrush(ContentBackColor))
                {
                    g.FillPath(contentBrush, path);
                }

                // 3. Header Background
                using (GraphicsPath headerPath = GetHeaderPath(rect, radius, HeaderHeight))
                {
                    using (SolidBrush headerBrush = new SolidBrush(HeaderBackColor))
                    {
                        g.FillPath(headerBrush, headerPath);
                    }
                }

                // 4. Header Divider
                if (_showHeaderDivider)
                {
                    using (Pen dividerPen = new Pen(BorderColor, 1))
                    {
                        g.DrawLine(dividerPen, rect.X, rect.Y + HeaderHeight, rect.Right, rect.Y + HeaderHeight);
                    }
                }

                // 5. Icon and Text (Coordinates preserved)
                int textXOffset = rect.X + 15;
                if (IconHeader != null)
                {
                    int iconY = rect.Y + (HeaderHeight - _iconSize) / 2;
                    g.DrawImage(IconHeader, rect.X + 15, iconY, _iconSize, _iconSize);
                    textXOffset = rect.X + 15 + _iconSize + 8;
                }

                using (SolidBrush textBrush = new SolidBrush(_headerForeColor))
                using (Font headerFont = new Font("Segoe UI Semibold", _headerFontSize))
                {
                    StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
                    Rectangle textRect = new Rectangle(textXOffset, rect.Y, rect.Width - (textXOffset - rect.X) - 5, HeaderHeight);
                    g.DrawString(HeaderLabel, headerFont, textBrush, textRect, sf);
                }

                // 6. Border
                if (BorderThickness > 0)
                {
                    using (Pen borderPen = new Pen(BorderColor, BorderThickness))
                    {
                        g.DrawPath(borderPen, path);
                    }
                }
            }
        }

        #region Helpers
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(1, radius * 2);
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetHeaderPath(Rectangle rect, float radius, int height)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(1, radius * 2);
            if (diameter > rect.Width) diameter = rect.Width;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddLine(rect.Right, rect.Y + height, rect.X, rect.Y + height);
            path.CloseFigure();
            return path;
        }
        #endregion
    }
}