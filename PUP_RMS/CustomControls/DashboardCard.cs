using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS
{
    public class DashboardCard : Panel
    {
        // --- APPEARANCE ---
        [Category("Appearance")]
        public int BorderRadius { get; set; } = 20;

        [Category("Appearance")]
        public Color PanelColor { get; set; } = Color.White;

        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.Transparent;

        [Category("Appearance")]
        public int BorderSize { get; set; } = 0;

        // --- SHADOW ---
        [Category("Shadow")]
        public bool ShadowEnabled { get; set; } = true;

        [Category("Shadow")]
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 200, 200, 200);

        [Category("Shadow")]
        public int ShadowShift { get; set; } = 5;

        [Category("Shadow")]
        public int ShadowDepth { get; set; } = 10;

        // --- DASHBOARD SHAPES & ICON ---

        private bool _isDashboardCard = true;
        [Category("Dashboard Card")]
        [Description("Enables the Circle, Icon, and Footer background shapes.")]
        public bool IsDashboardCard
        {
            get { return _isDashboardCard; }
            set { _isDashboardCard = value; Invalidate(); }
        }

        [Category("Dashboard Card")]
        public Color DashboardAccentColor { get; set; } = Color.Maroon;

        // --- NEW: ICON PROPERTIES ---

        private Image _cardIcon;
        [Category("Dashboard Card")]
        [Description("The icon to display inside the colored circle.")]
        public Image CardIcon
        {
            get { return _cardIcon; }
            set { _cardIcon = value; Invalidate(); }
        }

        private int _iconSize = 24;
        [Category("Dashboard Card")]
        [Description("The size of the icon inside the circle.")]
        public int IconSize
        {
            get { return _iconSize; }
            set { _iconSize = value; Invalidate(); }
        }

        // You can change X/Y in properties to move the background circle
        private Point _circlePosition = new Point(20, 20);
        [Category("Dashboard Card")]
        public Point CirclePosition
        {
            get { return _circlePosition; }
            set { _circlePosition = value; Invalidate(); }
        }

        public DashboardCard()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Size = new Size(220, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int margin = ShadowEnabled ? (ShadowDepth + ShadowShift) : 0;

            // Define the area of the actual card
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
                        ), BorderRadius))
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

            // 2. Draw Card Body
            using (GraphicsPath path = GetRoundedPath(rectCard, BorderRadius))
            {
                // A. White Background
                using (SolidBrush brush = new SolidBrush(PanelColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // B. Draw Dashboard Shapes (Circle + Footer + Icon)
                if (IsDashboardCard)
                {
                    e.Graphics.SetClip(path); // Ensure shapes stay inside rounded corners

                    // Draw Footer Strip
                    int footerHeight = 15;
                    Rectangle footerRect = new Rectangle(rectCard.X, rectCard.Bottom - footerHeight, rectCard.Width, footerHeight);
                    using (SolidBrush accentBrush = new SolidBrush(DashboardAccentColor))
                    {
                        e.Graphics.FillRectangle(accentBrush, footerRect);
                    }

                    // Draw Circle
                    int circleSize = 50;
                    // Position is relative to the card rectangle + your custom X/Y
                    int circleX = rectCard.X + _circlePosition.X;
                    int circleY = rectCard.Y + _circlePosition.Y;

                    using (SolidBrush accentBrush = new SolidBrush(DashboardAccentColor))
                    {
                        e.Graphics.FillEllipse(accentBrush, circleX, circleY, circleSize, circleSize);
                    }

                    // --- DRAW ICON (Added Here) ---
                    if (CardIcon != null)
                    {
                        // Calculate center of circle to center the icon
                        int iconX = circleX + (circleSize - _iconSize) / 2;
                        int iconY = circleY + (circleSize - _iconSize) / 2;

                        e.Graphics.DrawImage(CardIcon, new Rectangle(iconX, iconY, _iconSize, _iconSize));
                    }

                    e.Graphics.ResetClip();
                }

                // C. Draw Border
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