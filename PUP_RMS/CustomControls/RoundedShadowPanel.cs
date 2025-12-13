using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS
{
    public class RoundedShadowPanel : Panel
    {
        // --- APPEARANCE PROPERTIES ---
        [Category("Appearance")]
        public int BorderRadius { get; set; } = 20;

        [Category("Appearance")]
        [Description("The background color (used if no image is set).")]
        public Color PanelColor { get; set; } = Color.White;

        [Category("Appearance")]
        [Description("Set an image here to use as the background.")]
        public Image PanelImage { get; set; } // <--- NEW PROPERTY

        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.Transparent;

        [Category("Appearance")]
        public int BorderSize { get; set; } = 0;

        // --- SHADOW PROPERTIES ---
        [Category("Shadow")]
        public bool ShadowEnabled { get; set; } = true;

        [Category("Shadow")]
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 200, 200, 200);

        [Category("Shadow")]
        public int ShadowShift { get; set; } = 5;

        [Category("Shadow")]
        public int ShadowDepth { get; set; } = 10;

        public RoundedShadowPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int margin = ShadowEnabled ? (ShadowDepth + ShadowShift) : 0;

            // The rectangle where the card is drawn
            Rectangle rectCard = new Rectangle(
                margin / 2,
                margin / 2,
                this.Width - margin - 1,
                this.Height - margin - 1
            );

            // 1. Draw Shadow
            if (ShadowEnabled && ShadowDepth > 0)
            {
                for (int i = 0; i < ShadowDepth; i++)
                {
                    using (GraphicsPath shadowPath = GetRoundedPath(
                        new Rectangle(
                            rectCard.X + (i / 3) - (ShadowShift / 2),
                            rectCard.Y + (i / 3) + (ShadowShift / 2),
                            rectCard.Width + i,
                            rectCard.Height + i
                        ),
                        BorderRadius))
                    {
                        int alpha = 20 - (i * 20 / ShadowDepth);
                        if (alpha < 0) alpha = 0;
                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, ShadowColor)))
                        {
                            e.Graphics.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }

            // 2. Draw Background (Image OR Color)
            using (GraphicsPath path = GetRoundedPath(rectCard, BorderRadius))
            {
                // CHECK: Is there an image?
                if (PanelImage != null)
                {
                    // This command ensures the image is cut (clipped) to the rounded shape
                    e.Graphics.SetClip(path);
                    // Draw the image stretched to fill the card
                    e.Graphics.DrawImage(PanelImage, rectCard);
                    // Stop clipping so we can draw the border later
                    e.Graphics.ResetClip();
                }
                else
                {
                    // If no image, fill with the solid color
                    using (SolidBrush brush = new SolidBrush(PanelColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                // 3. Draw Border
                if (BorderSize > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2.0F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}