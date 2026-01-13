using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    [ToolboxItem(true)]
    [Description("A rounded, clickable button-like panel for creating new users, with customizable icon and text.")]
    public class CreateUserButton : Control
    {
        #region Private Fields
        private int _borderRadius = 8; // Consistent with the image
        private Color _buttonBackColor = Color.FromArgb(128, 0, 0); // Maroon
        private Color _buttonHoverColor = Color.FromArgb(150, 0, 0); // Slightly lighter maroon for hover

        private Image _iconImage; // To import the icon
        private int _iconSize = 24; // Default icon size, will scale
        private Color _iconColor = Color.White; // Color of the icon (if it's a Path-based icon, not an Image)

        private string _buttonText = "Click to Create New User";
        private Color _labelForeColor = Color.White;
        private float _labelFontSize = 14f;
        private FontStyle _labelFontStyle = FontStyle.Regular;

        private bool _isHovering = false;
        #endregion

        #region Public Properties

        [Category("PUP_RMS Appearance"), Description("The radius for the button's rounded corners.")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("PUP_RMS Appearance"), Description("The background color of the button.")]
        public Color ButtonBackColor
        {
            get => _buttonBackColor;
            set { _buttonBackColor = value; Invalidate(); }
        }

        [Category("PUP_RMS Appearance"), Description("The background color of the button when the mouse hovers over it.")]
        public Color ButtonHoverColor
        {
            get => _buttonHoverColor;
            set { _buttonHoverColor = value; Invalidate(); }
        }

        [Category("PUP_RMS Icon"), Description("The image to display as the icon.")]
        public Image IconImage
        {
            get => _iconImage;
            set { _iconImage = value; Invalidate(); }
        }

        [Category("PUP_RMS Icon"), Description("The size of the icon in pixels (width and height).")]
        public int IconSize
        {
            get => _iconSize;
            set { _iconSize = value; Invalidate(); }
        }

        [Category("PUP_RMS Icon"), Description("The color to apply to the icon (if it's a monochrome image that can be recolored, or for future path drawing).")]
        public Color IconColor // Added for future flexibility or if you use vector icons
        {
            get => _iconColor;
            set { _iconColor = value; Invalidate(); }
        }

        [Category("PUP_RMS Label"), Description("The text label displayed on the button.")]
        public string Label
        {
            get => _buttonText;
            set { _buttonText = value; Invalidate(); }
        }

        [Category("PUP_RMS Label"), Description("The foreground color of the text label.")]
        public Color LabelForeColor
        {
            get => _labelForeColor;
            set { _labelForeColor = value; Invalidate(); }
        }

        [Category("PUP_RMS Label"), Description("The font size of the text label.")]
        public float LabelFontSize
        {
            get => _labelFontSize;
            set { _labelFontSize = value; Invalidate(); }
        }

        [Category("PUP_RMS Label"), Description("The font style of the text label (e.g., Bold, Italic).")]
        public FontStyle LabelFontStyle
        {
            get => _labelFontStyle;
            set { _labelFontStyle = value; Invalidate(); }
        }
        #endregion

        public CreateUserButton()
        {
            // Set default size and ensure double buffering for smooth drawing
            this.Size = new Size(250, 60);
            this.MinimumSize = new Size(150, 40);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);
            // REMOVED: this.BackColor = Color.Transparent;
            // The control will draw its own background, so its base BackColor doesn't need to be transparent.
            // If the parent has a different background color, the custom painting handles it.

            // Mouse events for hover
            this.MouseEnter += (s, e) => { _isHovering = true; Invalidate(); };
            this.MouseLeave += (s, e) => { _isHovering = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Define the main button rectangle
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            float radius = Math.Max(1, _borderRadius);

            // Determine current background color based on hover state
            Color currentBackColor = _isHovering ? _buttonHoverColor : _buttonBackColor;

            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush bgBrush = new SolidBrush(currentBackColor))
                {
                    g.FillPath(bgBrush, path);
                }
            }

            // Calculate layout for icon and text
            int padding = 15; // Padding from left for icon, and around elements
            int iconAreaWidth = 0; // Tracks the space taken by the icon and its padding

            if (_iconImage != null)
            {
                // Draw Icon (if provided)
                // Ensure icon is always drawn with white color for consistency with the design,
                // regardless of the actual image's colors, by creating a recolored version.
                using (Bitmap recoloredIcon = RecolorImage(_iconImage, _iconColor))
                {
                    Rectangle iconRect = new Rectangle(padding, (this.Height - _iconSize) / 2, _iconSize, _iconSize);
                    g.DrawImage(recoloredIcon, iconRect);
                }
                iconAreaWidth = _iconSize + padding; // Space taken by icon + its right padding
            }


            // Draw Text
            using (Font textFont = new Font("Segoe UI", _labelFontSize, _labelFontStyle))
            using (SolidBrush textBrush = new SolidBrush(_labelForeColor))
            {
                // Measure text to determine its width
                SizeF textSize = g.MeasureString(_buttonText, textFont);

                // Calculate text position, placing it right of the icon (if icon present)
                // or centered if no icon
                float textX;
                if (_iconImage != null)
                {
                    textX = iconAreaWidth + 5; // Add a small gap between icon and text
                }
                else
                {
                    // Center text if no icon
                    textX = (this.Width - textSize.Width) / 2;
                }
                float textY = (this.Height - textSize.Height) / 2; // Vertically center text

                RectangleF textRect = new RectangleF(textX, textY, textSize.Width, textSize.Height);

                g.DrawString(_buttonText, textFont, textBrush, textRect);
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

        // Helper method to recolor a monochrome image (if needed)
        // This is useful if you import a black icon and want it to be white.
        private Bitmap RecolorImage(Image originalImage, Color newColor)
        {
            if (originalImage == null) return null;

            Bitmap recoloredBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(recoloredBitmap))
            {
                // Create a ColorMatrix that replaces white with newColor and black with transparent
                // This assumes a largely monochrome source icon (e.g., black or white on transparent)
                System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
                    new float[][]
                    {
                        new float[] {newColor.R / 255f, 0, 0, 0, 0},
                        new float[] {0, newColor.G / 255f, 0, 0, 0},
                        new float[] {0, 0, newColor.B / 255f, 0, 0},
                        new float[] {0, 0, 0, newColor.A / 255f, 0}, // Preserve original alpha for transparency
                        new float[] {0, 0, 0, 0, 1}
                    });

                using (System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);

                    g.DrawImage(originalImage,
                                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                                0, 0, originalImage.Width, originalImage.Height,
                                GraphicsUnit.Pixel, attributes);
                }
            }
            return recoloredBitmap;
        }


        // Handle resizing to redraw the control correctly
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }
    }
}