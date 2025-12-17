using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Controls
{
    // The iconButton replaces the need for a separate RoundedButton, 
    // inheriting all properties from the base Button class.
    public class iconButton : Button
    {
        // --- CUSTOM BACKCOLOR OVERRIDE ---
        // This holds the actual background color, while the base class color is set to Transparent.
        private Color _customBackColor = Color.Maroon;

        [Category("Custom Appearance")]
        // Override the base BackColor property to use our private field and trigger Redraw
        public override Color BackColor
        {
            get { return _customBackColor; }
            set { _customBackColor = value; Invalidate(); }
        }

        // --- CORE FUNCTIONALITY PROPERTIES ---

        private int _iconSize = 24;
        [Category("Custom Props")]
        public int IconSize
        {
            get { return _iconSize; }
            set { _iconSize = value; Invalidate(); }
        }

        private bool _isActive = false;
        [Category("Custom Props")]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; Invalidate(); }
        }

        private Color _activeColor = Color.FromArgb(200, 40, 40); // Bright Red for Active
        [Category("Custom Props")]
        public Color ActiveColor
        {
            get { return _activeColor; }
            set { _activeColor = value; Invalidate(); }
        }

        private Color _hoverColor = Color.FromArgb(170, 0, 0); // Lighter Maroon for Hover
        [Category("Custom Props")]
        public Color HoverColor
        {
            get { return _hoverColor; }
            set { _hoverColor = value; Invalidate(); }
        }

        // Internal tracker for hover state (used by OnPaint)
        private bool _isHovered = false;

        // --- INDENTATION PROPERTIES ---
        private int _indentLevel = 0;
        private int IndentStep = 20;

        [Category("Custom Props")]
        [Description("Shifts the icon and text to the right to visually show hierarchy.")]
        public int IndentLevel
        {
            get { return _indentLevel; }
            set
            {
                if (value >= 0)
                {
                    _indentLevel = value;
                    Invalidate();
                }
            }
        }

        // --- ROUNDED CORNER PROPERTIES ---
        // These properties control the rounding, border color, and border size.
        private int _borderRadius = 0;
        [Category("Custom Appearance")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        private Color _borderColor = Color.PaleVioletRed;
        [Category("Custom Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        private int _borderSize = 0;
        [Category("Custom Appearance")]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }


        // --- Constructor ---
        public iconButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            // The default MouseDown/MouseOver back colors are still set here for compatibility
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            this.FlatAppearance.MouseDownBackColor = Color.Maroon;
            this.FlatAppearance.MouseOverBackColor = Color.Maroon;

            // CRITICAL FIX 1: Set base BackColor to Transparent 
            // so our custom OnPaint controls the background entirely.
            base.BackColor = Color.Transparent;

            this.Size = new Size(200, 50);
            this.ForeColor = Color.White;
            this.DoubleBuffered = true;
            this.TextAlign = ContentAlignment.MiddleLeft;

            // Set styles for flicker-free drawing
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        // --- PREVENT FOCUS RECTANGLE ---
        protected override bool ShowFocusCues => false;

        // --- HELPER METHOD TO CREATE ROUNDED PATH (Safely calculates radius) ---
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // FIX: Ensure radius * 2 does not exceed the width or height, preventing "Parameter is not valid"
            float diameter = radius * 2.0f;
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            // Protection against zero size
            if (diameter < 1.0f) diameter = 1.0f;

            float arcX = rect.X + rect.Width - diameter;
            float arcY = rect.Y + rect.Height - diameter;

            // Top-Left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Top-Right arc
            path.AddArc(arcX, rect.Y, diameter, diameter, 270, 90);
            // Bottom-Right arc
            path.AddArc(arcX, arcY, diameter, diameter, 0, 90);
            // Bottom-Left arc
            path.AddArc(rect.X, arcY, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }


        // --- DRAWING LOGIC (WITH SIZE AND DESIGNER SAFETY CHECK) ---
        protected override void OnPaint(PaintEventArgs pevent)
        {
            // CRITICAL FIX 2: Check for zero size immediately to prevent GDI+ exceptions
            if (this.Width <= 0 || this.Height <= 0)
            {
                return;
            }

            Graphics g = pevent.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Determine the current background color based on state (Active or Hover)
            Color bg = this.BackColor;

            if (_isActive)
            {
                bg = _activeColor;
            }
            else if (_isHovered)
            {
                bg = _hoverColor;
            }

            // --- ROUNDING AND CLIPPING LOGIC START ---
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            // CRITICAL FIX 3: Only set Region property if NOT in DesignMode AND BorderRadius > 0
            if (BorderRadius > 0)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius);

                if (!this.DesignMode)
                {
                    this.Region = new Region(pathSurface);
                }
            }
            else
            {
                // Reset to standard rectangle if no radius is desired
                if (!this.DesignMode)
                {
                    this.Region = new Region(ClientRectangle);
                }
                g.SmoothingMode = SmoothingMode.None;
            }

            // 2. Draw Background
            using (SolidBrush brush = new SolidBrush(bg))
            {
                // Fill the path/rectangle with the determined color
                g.FillPath(brush, GetFigurePath(rectSurface, BorderRadius));
            }

            // 3. Draw Border (If size > 0)
            if (BorderSize >= 1)
            {
                // Draw a slightly inset border path
                RectangleF rectBorder = new RectangleF(0.5f, 0.5f, this.Width - 1f, this.Height - 1f);
                GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius);

                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Center;
                    g.DrawPath(penBorder, pathBorder);
                }
            }

            // --- ROUNDING AND CLIPPING LOGIC END ---

            // 4. Draw Icon and Text

            // Turn ON high quality smoothing for Images and Text 
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // ** CALCULATE INDENT SHIFT **
            int indentShift = _indentLevel * IndentStep;

            // 5. Draw the Icon
            if (this.Image != null)
            {
                int imageY = (this.Height - _iconSize) / 2;
                int imageX = 15 + indentShift;
                g.DrawImage(this.Image, new Rectangle(imageX, imageY, _iconSize, _iconSize));
            }

            // 6. Draw the Text
            if (!string.IsNullOrEmpty(this.Text))
            {
                int textX = 15 + _iconSize + 10 + indentShift;
                Rectangle textRect = new Rectangle(textX, 0, this.Width - textX, this.Height);

                TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor, flags);
            }
        }

        // --- Mouse Events ---
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
    }
}