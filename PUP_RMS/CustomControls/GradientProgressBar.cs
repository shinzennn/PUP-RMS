using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.CustomControls
{
    public class GradientProgressBar : Control
    {
        public int Value { get; set; } = 50;
        public int Maximum { get; set; } = 100;

        public GradientProgressBar()
        {
            this.DoubleBuffered = true;
            this.Height = 12; // Slim profile from reference
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Background (Light Gray track)
            Rectangle backRect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = GetRoundedRect(backRect, this.Height / 2))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(235, 235, 235)))
            {
                g.FillPath(brush, path);
            }

            // Foreground (Maroon to Gold Gradient)
            float progressWidth = ((float)Value / Maximum) * this.Width;
            if (progressWidth > 5)
            {
                Rectangle foreRect = new Rectangle(0, 0, (int)progressWidth, this.Height);
                using (GraphicsPath path = GetRoundedRect(foreRect, this.Height / 2))
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    foreRect,
                    Color.FromArgb(128, 0, 0), // PUP Maroon
                    Color.FromArgb(242, 201, 76), // PUP Gold
                    LinearGradientMode.Horizontal))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}