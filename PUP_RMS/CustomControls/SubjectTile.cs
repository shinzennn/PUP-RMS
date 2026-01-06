using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// KEY FIX: This namespace must match the 'using' statement in your other form
namespace PUP_RMS.CustomControls
{
    public class SubjectTile : Control
    {
        // --- DATA PROPERTIES ---
        [Category("PUP Data")]
        public string SubjectName { get; set; } = "Subject Name";

        private int _recordCount = 0;
        [Category("PUP Data")]
        public int RecordCount
        {
            get => _recordCount;
            set { _recordCount = value; Invalidate(); }
        }

        private int _maxCount = 100;
        [Category("PUP Data")]
        public int MaxCount
        {
            get => _maxCount;
            set { _maxCount = value; Invalidate(); }
        }

        // --- APPEARANCE SETTINGS ---
        [Category("Appearance")]
        public int BorderRadius { get; set; } = 15;
        public int ShadowDepth { get; set; } = 5;
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 0, 0, 0);

        // Colors
        private readonly Color PupMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color PupGold = Color.FromArgb(242, 201, 76);

        public SubjectTile()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Size = new Size(200, 90);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int margin = ShadowDepth + 2;
            Rectangle rectCard = new Rectangle(margin / 2, margin / 2, this.Width - margin - 1, this.Height - margin - 1);

            // Draw Shadow
            if (ShadowDepth > 0)
            {
                for (int i = 0; i < ShadowDepth; i++)
                {
                    using (GraphicsPath shadowPath = GetRoundedPath(new Rectangle(rectCard.X + (i / 2), rectCard.Y + (i / 2), rectCard.Width, rectCard.Height), BorderRadius))
                    {
                        int alpha = 40 - (i * 40 / ShadowDepth);
                        if (alpha < 0) alpha = 0;
                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, ShadowColor)))
                        {
                            e.Graphics.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }

            // Draw Background (Gradient)
            Color tileColor = CalculateGradientColor();
            using (GraphicsPath path = GetRoundedPath(rectCard, BorderRadius))
            using (SolidBrush brush = new SolidBrush(tileColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Draw Text
            using (Font titleFont = new Font("Segoe UI", 11, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString(SubjectName, titleFont, textBrush, new PointF(rectCard.X + 10, rectCard.Y + 15));
            }

            using (Font countFont = new Font("Segoe UI", 9, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
            {
                e.Graphics.DrawString($"{RecordCount} Records", countFont, textBrush, new PointF(rectCard.X + 10, rectCard.Y + 40));
            }
        }

        private Color CalculateGradientColor()
        {
            if (_maxCount <= 0) _maxCount = 1;
            float percentage = (float)_recordCount / _maxCount;
            if (percentage > 1) percentage = 1; else if (percentage < 0) percentage = 0;

            int r = (int)(PupGold.R + (PupMaroon.R - PupGold.R) * percentage);
            int g = (int)(PupGold.G + (PupMaroon.G - PupGold.G) * percentage);
            int b = (int)(PupGold.B + (PupMaroon.B - PupGold.B) * percentage);

            return Color.FromArgb(r, g, b);
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