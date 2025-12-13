using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PUP_RMS.Controls
{
    public class iconButton : Button
    {
        // --- Properties ---
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

        // Internal tracker for hover state
        private bool _isHovered = false;

        // --- Constructor ---
        public iconButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); // Transparent
            this.FlatAppearance.MouseDownBackColor = Color.Maroon; // Prevent default flashing
            this.FlatAppearance.MouseOverBackColor = Color.Maroon; // Prevent default flashing

            this.Size = new Size(200, 50);
            this.BackColor = Color.Maroon;
            this.ForeColor = Color.White;
            this.DoubleBuffered = true;
            this.TextAlign = ContentAlignment.MiddleLeft;
        }

        // --- PREVENT FOCUS RECTANGLE ---
        protected override bool ShowFocusCues => false;

        // --- DRAWING LOGIC ---
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. Determine Background Color (INTEGRATED LOGIC)
            Color bg = this.BackColor;

            if (_isActive)
            {
                bg = _activeColor;
            }
            else if (_isHovered)
            {
                bg = _hoverColor;
            }

            // --- CRITICAL FIX START (UNCHANGED) ---

            // Step A: Turn OFF smoothing for the background to get crisp edges (No white lines!)
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            using (SolidBrush brush = new SolidBrush(bg))
            {
                // Use Width/Height directly to ensure we cover the FULL area, ignoring "ClientRectangle" padding
                g.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Step B: Turn ON smoothing for Images and Text (So they look nice)
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // --- CRITICAL FIX END ---

            // 2. Draw the Icon
            if (this.Image != null)
            {
                int imageY = (this.Height - _iconSize) / 2;
                int imageX = 15;
                g.DrawImage(this.Image, new Rectangle(imageX, imageY, _iconSize, _iconSize));
            }

            // 3. Draw the Text
            if (!string.IsNullOrEmpty(this.Text))
            {
                int textX = 15 + _iconSize + 10;
                Rectangle textRect = new Rectangle(textX, 0, this.Width - textX, this.Height);

                TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor, flags);
            }
        }

        // --- Mouse Events (Updated for Hover Logic) ---
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true; // Turn on hover color
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false; // Turn off hover color
            Invalidate();
        }
    }
}