using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Controls
{
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public class AdminToolCardButton : Button
    {
        // --- FIELDS ---
        private int _borderSize = 3;
        private int _borderRadius = 20;
        private Color _borderColor = Color.FromArgb(218, 165, 32); // Gold

        private Color _cardBackColor = Color.White;
        private Color _cardHoverBackColor = Color.FromArgb(245, 245, 245); // Light Gray

        private string _labelText = "Label";
        private Color _labelColor = Color.FromArgb(218, 165, 32); // Gold
        private Font _labelFont = new Font("Segoe UI", 16F, FontStyle.Bold);

        private Image _iconImage = null;

        // This determines how big the icon is relative to the button height (0.45 = 45%)
        private float _iconHeightRatio = 0.45f;

        private bool _isHovered = false;

        // --- CONSTRUCTOR ---
        public AdminToolCardButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.DoubleBuffered = true;
            this.Size = new Size(250, 150);
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            base.Text = "";
        }

        // --- PROPERTIES ---

        [Category("Custom Appearance")]
        [Description("Radius of the rounded corners.")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        [Description("Thickness of the border.")]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Color CardBackColor
        {
            get { return _cardBackColor; }
            set { _cardBackColor = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Color HoverBackColor
        {
            get { return _cardHoverBackColor; }
            set { _cardHoverBackColor = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public string LabelText
        {
            get { return _labelText; }
            set { _labelText = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Color LabelColor
        {
            get { return _labelColor; }
            set { _labelColor = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Font LabelFont
        {
            get { return _labelFont; }
            set { _labelFont = value; Invalidate(); }
        }

        [Category("Custom Appearance")]
        public Image IconImage
        {
            get { return _iconImage; }
            set { _iconImage = value; Invalidate(); }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = ""; }
        }

        // --- DRAWING LOGIC ---
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic; // Smooth image scaling

            // 1. Setup Background Geometry
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 2, this.Height - 2);

            // 2. Draw Background & Border
            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - 1))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);

                    Color currentBackColor = (_isHovered && !DesignMode) ? _cardHoverBackColor : _cardBackColor;
                    using (SolidBrush brushSurface = new SolidBrush(currentBackColor))
                    {
                        g.FillPath(brushSurface, pathSurface);
                    }

                    if (_borderSize >= 1) g.DrawPath(penBorder, pathSurface);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                Color currentBackColor = (_isHovered && !DesignMode) ? _cardHoverBackColor : _cardBackColor;
                using (SolidBrush brushSurface = new SolidBrush(currentBackColor))
                    g.FillRectangle(brushSurface, rectSurface);

                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    g.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                }
            }

            // 3. RESPONSIVE LAYOUT CALCULATION

            // Calculate variables
            float contentHeight = 0;
            float iconDrawWidth = 0;
            float iconDrawHeight = 0;
            SizeF textSize = SizeF.Empty;
            float gap = this.Height * 0.05f; // Gap is 5% of height

            // A. Measure Icon (if exists)
            if (_iconImage != null)
            {
                // Dynamic size: Icon is 45% of the button height
                iconDrawHeight = this.Height * _iconHeightRatio;

                // Maintain Aspect Ratio
                float aspectRatio = (float)_iconImage.Width / _iconImage.Height;
                iconDrawWidth = iconDrawHeight * aspectRatio;

                contentHeight += iconDrawHeight;
            }

            // B. Measure Text (if exists)
            if (!string.IsNullOrEmpty(_labelText))
            {
                textSize = g.MeasureString(_labelText, _labelFont, this.Width - 10); // Check wrapped size
                if (_iconImage != null) contentHeight += gap; // Add gap only if there is also an icon
                contentHeight += textSize.Height;
            }

            // 4. DRAWING CONTENT (Vertically Centered)

            // Calculate the starting Y position to center everything vertically
            float startY = (this.Height - contentHeight) / 2;

            // A. Draw Icon
            if (_iconImage != null)
            {
                float iconX = (this.Width - iconDrawWidth) / 2; // Center horizontally

                // Draw the image
                g.DrawImage(_iconImage, iconX, startY, iconDrawWidth, iconDrawHeight);

                // Move Y down for the text
                startY += iconDrawHeight + gap;
            }

            // B. Draw Text
            if (!string.IsNullOrEmpty(_labelText))
            {
                RectangleF textRect = new RectangleF(
                    5, // Left Padding
                    startY,
                    this.Width - 10, // Width with padding
                    textSize.Height + 5 // Height with buffer
                );

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;     // Horizontal Center
                sf.LineAlignment = StringAlignment.Near;   // Top of the text rect

                using (SolidBrush textBrush = new SolidBrush(_labelColor))
                {
                    g.DrawString(_labelText, _labelFont, textBrush, textRect, sf);
                }
            }
        }

        // --- HELPER ---
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        // --- EVENTS ---
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Forces full redraw to recalculate responsive positions
        }
    }
}