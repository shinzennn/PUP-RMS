using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace PUP_RMS
{
    public class RoundedButton : Button
    {
        // --- APPEARANCE PROPERTIES ---
        [Category("Appearance")]
        public int BorderRadius { get; set; } = 20;

        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.PaleVioletRed;

        [Category("Appearance")]
        public int BorderSize { get; set; } = 0;

        [Category("Appearance")]
        public Color ButtonColor { get; set; } = Color.Maroon; // 1. Normal Background Color

        // >>> NEW PROPERTY ADDED HERE <<<
        [Category("Appearance")]
        public Color HoverColor { get; set; } = Color.DarkRed; // 2. Dedicated Hover Color

        [Category("Appearance")]
        public Color TextColor { get; set; } = Color.White; // Default Text

        // Constructor
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);

            // Initialize BackColor with the ButtonColor property
            this.BackColor = ButtonColor;
            this.ForeColor = TextColor;

            // Optional: Add the flicker-fix code here if it's still needed:
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        // The Drawing Logic
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);

            GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius);
            GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1f);

            this.Region = new Region(pathSurface);

            // 1. Draw Surface (Uses the current this.BackColor, which is set by the mouse events)
            pevent.Graphics.FillPath(new SolidBrush(this.BackColor), pathSurface);

            // 2. Draw Border (If you set size > 0)
            if (BorderSize >= 1)
            {
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }

            // 3. Draw Text
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Helper to get the round path
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

        // --- HOVER EFFECT LOGIC (UPDATED) ---

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Action: Change to the HoverColor property value
            this.BackColor = HoverColor;
            this.Invalidate(); // Force redraw
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Action: Change back to the ButtonColor property value
            this.BackColor = ButtonColor;
            this.Invalidate(); // Force redraw
        }
    }
}