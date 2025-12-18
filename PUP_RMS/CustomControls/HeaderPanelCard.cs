using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    [ToolboxItem(true)]
    [Description("A reusable, rounded panel control with a customizable header section.")]
    public class HeaderPanelCard : Panel
    {
        #region Private Fields
        private Image _iconHeader = null;
        private int _iconSize = 22; // New Property Field
        private string _headerLabel = "Record Distribution";
        private Color _headerBackColor = Color.FromArgb(250, 251, 252);
        private Color _headerForeColor = Color.FromArgb(20, 40, 80); // New Property Field
        private float _headerFontSize = 10.5f; // New Property Field
        private int _headerHeight = 45;
        private int _borderRadius = 10;
        private Color _borderColor = Color.FromArgb(230, 233, 237);
        private int _borderThickness = 1;
        private Color _contentBackColor = Color.White;
        #endregion

        #region Public Properties
        [Category("Header"), Description("The icon image to display in the header.")]
        public Image IconHeader
        {
            get => _iconHeader;
            set { _iconHeader = value; Invalidate(); }
        }

        [Category("Header"), Description("The size (width and height) of the header icon.")]
        public int IconSize
        {
            get => _iconSize;
            set { _iconSize = value; Invalidate(); }
        }

        [Category("Header"), Description("The text to display in the header label.")]
        public string HeaderLabel
        {
            get => _headerLabel;
            set { _headerLabel = value; Invalidate(); }
        }

        [Category("Header"), Description("The color of the header text.")]
        public Color HeaderForeColor
        {
            get => _headerForeColor;
            set { _headerForeColor = value; Invalidate(); }
        }

        [Category("Header"), Description("The font size of the header text.")]
        public float HeaderFontSize
        {
            get => _headerFontSize;
            set { _headerFontSize = value; Invalidate(); }
        }

        [Category("Header"), Description("The background color of the header section.")]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; Invalidate(); }
        }

        [Category("Header"), Description("The height of the header section.")]
        public int HeaderHeight
        {
            get => _headerHeight;
            set { _headerHeight = value; Invalidate(); PerformLayout(); }
        }

        [Category("Appearance"), Description("The radius of the rounded corners.")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("Appearance"), Description("The color of the panel's outer border.")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance"), Description("The thickness of the panel's outer border.")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }

        [Category("Appearance"), Description("The background color of the content area.")]
        public Color ContentBackColor
        {
            get => _contentBackColor;
            set { _contentBackColor = value; Invalidate(); }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(
                    _borderThickness + 10,
                    _headerHeight + _borderThickness + 5,
                    Width - (_borderThickness * 2) - 20,
                    Height - _headerHeight - (_borderThickness * 2) - 15
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

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            float radius = Math.Max(1, BorderRadius);

            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                // 1. Draw Content Area Background
                using (SolidBrush contentBrush = new SolidBrush(ContentBackColor))
                {
                    g.FillPath(contentBrush, path);
                }

                // 2. Draw Header Background
                using (GraphicsPath headerPath = GetHeaderPath(rect, radius, HeaderHeight))
                {
                    using (SolidBrush headerBrush = new SolidBrush(HeaderBackColor))
                    {
                        g.FillPath(headerBrush, headerPath);
                    }
                }

                // 3. Draw Header Divider
                using (Pen dividerPen = new Pen(BorderColor, 1))
                {
                    g.DrawLine(dividerPen, 0, HeaderHeight, Width, HeaderHeight);
                }

                // 4. Draw Header Icon
                int textXOffset = 15;
                if (IconHeader != null)
                {
                    int iconY = (HeaderHeight - _iconSize) / 2;
                    g.DrawImage(IconHeader, 15, iconY, _iconSize, _iconSize);
                    textXOffset = 15 + _iconSize + 8; // Auto-spacing based on icon size
                }

                // 5. Draw Header Label
                using (SolidBrush textBrush = new SolidBrush(_headerForeColor))
                {
                    using (Font headerFont = new Font("Segoe UI Semibold", _headerFontSize))
                    {
                        StringFormat sf = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        };
                        Rectangle textRect = new Rectangle(textXOffset, 0, Width - textXOffset - 5, HeaderHeight);
                        g.DrawString(HeaderLabel, headerFont, textBrush, textRect, sf);
                    }
                }

                // 6. Draw Outer Border
                if (BorderThickness > 0)
                {
                    using (Pen borderPen = new Pen(BorderColor, BorderThickness))
                    {
                        g.DrawPath(borderPen, path);
                    }
                }
            }
        }

        #region Helper Methods
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

        private GraphicsPath GetHeaderPath(Rectangle rect, float radius, int height)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddLine(rect.Right, height, rect.X, height);
            path.CloseFigure();
            return path;
        }
        #endregion
    }
}