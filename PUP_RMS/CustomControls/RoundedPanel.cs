using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace PUP_RMS
{
    public class RoundedPanel : Panel
    {
        // --- CUSTOM PROPERTIES ---
        [Category("Appearance")]
        public int BorderRadius { get; set; } = 20;

        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.Black;

        [Category("Appearance")]
        public int BorderSize { get; set; } = 2;

        // HOVER BORDER COLOR (Property still exists for configuration/derived classes)
        [Category("Appearance")]
        public Color HoverBorderColor { get; set; } = Color.Maroon;

        // HOVER BACKGROUND COLOR (Property still exists for configuration/derived classes)
        [Category("Appearance")]
        public Color HoverBackColor { get; set; } = Color.FromArgb(242, 242, 242);

        // This boolean is now the *only* way to trigger hover appearance from outside
        private bool isHoverBorder = false;

        // Shadow Properties
        [Category("Shadow")]
        public bool ShadowEnabled { get; set; } = true;

        [Category("Shadow")]
        public Color ShadowColor { get; set; } = Color.FromArgb(80, 0, 0, 0);

        [Category("Shadow")]
        public int ShadowBlur { get; set; } = 15;

        [Category("Shadow")]
        public int ShadowOffset { get; set; } = 5;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White; // Default background color

            // No longer need to set Selectable if mouse events are removed.
            // But keeping it doesn't hurt.
            // this.SetStyle(ControlStyles.Selectable, true);
            // this.UpdateStyles();
        }

        // 🔥 CALL THIS FROM LoginForm TO SET BORDER HOVER (and now also background hover)
        public void SetBorderHover(bool state)
        {
            isHoverBorder = state;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            GraphicsPath path = GetRoundedPath(rect, BorderRadius);

            // DRAW SHADOW
            if (ShadowEnabled)
                DrawShadow(e.Graphics, rect);

            // FILL BACKGROUND - Use HoverBackColor ONLY if isHoverBorder is true, otherwise use default BackColor
            Color currentBackColor = isHoverBorder ? HoverBackColor : this.BackColor;
            using (SolidBrush brush = new SolidBrush(currentBackColor))
                e.Graphics.FillPath(brush, path);

            // DRAW BORDER
            if (BorderSize > 0)
            {
                // Use HoverBorderColor ONLY if isHoverBorder is true, otherwise use BorderColor
                Color drawColor = isHoverBorder ? HoverBorderColor : BorderColor;

                using (Pen pen = new Pen(drawColor, BorderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            this.Region = new Region(path);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        private void DrawShadow(Graphics g, Rectangle rect)
        {
            using (Bitmap shadowBmp = new Bitmap(rect.Width + ShadowBlur * 2, rect.Height + ShadowBlur * 2))
            using (Graphics shadowGraphics = Graphics.FromImage(shadowBmp))
            {
                shadowGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle shadowRect = new Rectangle(ShadowBlur, ShadowBlur, rect.Width, rect.Height);

                using (GraphicsPath shadowPath = GetRoundedPath(shadowRect, BorderRadius))
                using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
                {
                    shadowGraphics.FillPath(shadowBrush, shadowPath);
                }

                g.DrawImage(shadowBmp, ShadowOffset - ShadowBlur, ShadowOffset - ShadowBlur);
            }
        }

 
    }
}