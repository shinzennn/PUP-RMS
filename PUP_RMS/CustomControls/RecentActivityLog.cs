using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using PUP_RMS.CustomControls; // Ensure this matches the namespace of your HeaderPanelCard

namespace RecordsManagementSystem.Controls
{
    [ToolboxItem(true)]
    [Description("A draggable activity log that inherits the PUP_RMS HeaderPanelCard styling.")]
    public class RecentActivityLog : HeaderPanelCard
    {
        // ==========================================================
        // FIELDS
        // ==========================================================
        private Panel _itemContainer;
        private bool _isDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        // ==========================================================
        // CONSTRUCTOR
        // ==========================================================
        public RecentActivityLog()
        {
            // Set default properties inherited from HeaderPanelCard
            this.HeaderLabel = "Recent Activity Log";
            this.HeaderHeight = 60;
            this.Size = new Size(400, 500);
            this.ShadowPadding = 15;
            this.ShowShadow = true;
            this.EnableHoverEffect = true;

            // Initialize the scrollable container
            // It automatically sits inside the DisplayRectangle of the base card
            _itemContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                Padding = new Padding(0)
            };

            this.Controls.Add(_itemContainer);

            // Load some default data for visibility
            LoadDefaultActivities();
        }

        // ==========================================================
        // DRAGGING LOGIC (Using inherited HeaderHeight)
        // ==========================================================
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // We use the 'pad' logic from the base class to detect the header click
            int pad = ShowShadow ? ShadowPadding : 0;

            // If click is within the Header area
            if (e.Button == MouseButtons.Left && e.Y >= pad && e.Y <= pad + HeaderHeight)
            {
                _isDragging = true;
                _dragCursorPoint = Cursor.Position;
                _dragFormPoint = this.Location;
                this.Cursor = Cursors.SizeAll;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            this.Cursor = Cursors.Default;
            base.OnMouseUp(e);
        }

        // ==========================================================
        // ACTIVITY LOG METHODS
        // ==========================================================
        public void AddActivity(string title, string desc, string time, Color themeColor)
        {
            ActivityItem row = new ActivityItem(title, desc, time, themeColor);
            row.Width = _itemContainer.Width - 5; // Slight offset for scrollbar
            _itemContainer.Controls.Add(row);
            row.BringToFront(); // Newest at top
        }

        private void LoadDefaultActivities()
        {
            AddActivity("System Login", "Admin J. Montante accessed the dashboard", "Just now", Color.FromArgb(232, 240, 254));
            AddActivity("Batch Upload", "Successfully uploaded 15 Grade Sheets", "10m ago", Color.FromArgb(232, 245, 233));
            AddActivity("Naming Conflict", "File 'Record_01.pdf' was renamed automatically", "1h ago", Color.FromArgb(255, 248, 225));
        }
    }

    // ==========================================================
    // THE ROW ITEM CONTROL
    // ==========================================================
    internal class ActivityItem : UserControl
    {
        public ActivityItem(string title, string desc, string time, Color iconColor)
        {
            this.Dock = DockStyle.Top;
            this.Height = 65;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            this.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Draw Icon Circle
                using (SolidBrush b = new SolidBrush(iconColor))
                    g.FillEllipse(b, 15, 12, 40, 40);

                // Text Rendering
                using (Font fBold = new Font("Segoe UI Semibold", 9.5f))
                using (Font fReg = new Font("Segoe UI", 8.5f))
                {
                    g.DrawString(title, fBold, Brushes.Black, 65, 14);
                    g.DrawString(desc, fReg, Brushes.Gray, 65, 32);

                    SizeF tSize = g.MeasureString(time, fReg);
                    g.DrawString(time, fReg, Brushes.Silver, Width - tSize.Width - 15, 24);
                }

                // Thin divider line
                using (Pen p = new Pen(Color.FromArgb(245, 245, 245)))
                    g.DrawLine(p, 65, Height - 1, Width - 10, Height - 1);
            };
        }
    }
}