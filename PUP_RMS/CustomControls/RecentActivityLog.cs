using PUP_RMS.Core;
using PUP_RMS.CustomControls;
using PUP_RMS.Helper;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RecordsManagementSystem.Controls
{
    [ToolboxItem(true)]
    [Description("A draggable activity log that inherits the PUP_RMS HeaderPanelCard styling.")]
    public class RecentActivityLog : HeaderPanelCard
    {
        private Panel _itemContainer;
        private bool _isDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private int _latestLogID = -1;

        public RecentActivityLog()
        {
            this.HeaderLabel = "Recent Activity Log";
            this.HeaderHeight = 60;
            this.Size = new Size(400, 500);
            this.ShadowPadding = 15;
            this.ShowShadow = true;
            this.EnableHoverEffect = true;

            _itemContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                Padding = new Padding(0)
            };

            this.Controls.Add(_itemContainer);

            // FIX: Prevent Database connection during Visual Studio Design Time
            if (!this.DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                LoadDefaultActivities();
            }
        }

        #region Dragging Logic
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int pad = ShowShadow ? ShadowPadding : 0;
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
        #endregion

        #region Activity Loading Logic

        public void LoadDefaultActivities()
        {
            try
            {
                // 1. Get Data from Helper
                DataTable dt = DashboardHelper.GetRecentActivities();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int currentTopID = Convert.ToInt32(dt.Rows[0]["LogID"]);
                    if (currentTopID == _latestLogID) return; // Stop if no new data

                    _latestLogID = currentTopID;

                    _itemContainer.SuspendLayout();
                    _itemContainer.Controls.Clear();

                    // UPDATED: Changed to 'for' loop to detect the first item (Index 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];

                        string rawDesc = row["ActivityDescription"].ToString();
                        string username = row["Username"].ToString();
                        DateTime dbDate = Convert.ToDateTime(row["ActivityDate"]);

                        string title = GetTitleFromDescription(rawDesc, username);
                        string timeAgo = GetRelativeTime(dbDate);
                        Color themeColor = GetColorByAction(rawDesc);

                        // CHECK: If it is the first row (i == 0), it is the most recent
                        bool isLatest = (i == 0);

                        AddActivity(title, rawDesc, timeAgo, themeColor, isLatest);
                    }
                }
                else
                {
                    _itemContainer.Controls.Clear();
                    // Pass false for 'No Activity'
                    AddActivity("No Activity", "The log is currently empty.", "", Color.LightGray, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _itemContainer.ResumeLayout();
            }
        }

        // UPDATED: Added bool 'isLatest' parameter
        public void AddActivity(string title, string desc, string time, Color themeColor, bool isLatest)
        {
            Image icon = GetIconByAction(desc);

            // Pass 'isLatest' to the Item Control
            ActivityItem row = new ActivityItem(title, desc, time, themeColor, icon, isLatest);

            row.Width = _itemContainer.Width - 20;
            row.Dock = DockStyle.Top;

            _itemContainer.Controls.Add(row);
            _itemContainer.Controls.SetChildIndex(row, 0);
        }

        #endregion

        #region Helpers & Resource Image Logic

        private Image GetIconByAction(string description)
        {
            if (string.IsNullOrEmpty(description)) return null;

            description = description.ToLower();

            if (description.Contains("login") || description.Contains("logged in") || description.Contains("access"))
                return PUP_RMS.Properties.Resources.login;

            if (description.Contains("create") || description.Contains("upload") || description.Contains("add"))
                return PUP_RMS.Properties.Resources.create;

            if (description.Contains("update") || description.Contains("modified") || description.Contains("modify"))
                return PUP_RMS.Properties.Resources.edit;

            return null;
        }

        private string GetRelativeTime(DateTime date)
        {
            TimeSpan ts = DateTime.Now - date;
            if (ts.TotalMinutes < 1) return "Just now";
            if (ts.TotalMinutes < 60) return $"{(int)ts.TotalMinutes}m ago";
            if (ts.TotalHours < 24) return $"{(int)ts.TotalHours}h ago";
            if (ts.TotalDays < 7) return $"{(int)ts.TotalDays}d ago";
            return date.ToString("MMM dd");
        }

        private Color GetColorByAction(string description)
        {
            description = description.ToLower();
            if (description.Contains("login") || description.Contains("access")) return Color.FromArgb(232, 240, 254);
            if (description.Contains("upload") || description.Contains("create")) return Color.FromArgb(232, 245, 233);
            if (description.Contains("update") || description.Contains("edit")) return Color.FromArgb(255, 248, 225);
            if (description.Contains("delete") || description.Contains("error")) return Color.FromArgb(255, 235, 238);
            return Color.WhiteSmoke;
        }

        private string GetTitleFromDescription(string desc, string username)
        {
            if (desc.ToLower().Contains("login")) return "System Login";
            if (desc.ToLower().Contains("upload")) return "File Upload";
            if (desc.ToLower().Contains("delete")) return "Data Removal";
            if (desc.ToLower().Contains("update")) return "Record Update";
            return username;
        }

        #endregion
    }

    // ---------------------------------------------------------
    // INTERNAL CONTROL: Activity Item Row
    // ---------------------------------------------------------
    internal class ActivityItem : UserControl
    {
        private readonly Image _icon;
        private readonly string _title;
        private readonly string _desc;
        private readonly string _time;
        private readonly Color _iconBackgroundColor;
        private readonly bool _isLatest; // Field to store status

        // UPDATED: Constructor accepts 'isLatest'
        public ActivityItem(string title, string desc, string time, Color iconBgColor, Image icon, bool isLatest)
        {
            _title = title;
            _desc = desc;
            _time = time;
            _iconBackgroundColor = iconBgColor;
            _icon = icon;
            _isLatest = isLatest;

            this.Dock = DockStyle.Top;
            this.Height = 65;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            this.Paint += ActivityItem_Paint;
        }

        private void ActivityItem_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 1. Draw Icon Circle Background
            using (SolidBrush b = new SolidBrush(_iconBackgroundColor))
            {
                g.FillEllipse(b, 15, 12, 40, 40);
            }

            // 2. Draw the Image (PNG) inside the Circle
            if (_icon != null)
            {
                int iconRenderSize = 40; // Kept at 40 per your previous request

                int iconX = 12 + (40 - iconRenderSize) / 2;
                int iconY = 12 + (40 - iconRenderSize) / 2;

                g.DrawImage(_icon, new Rectangle(iconX, iconY, iconRenderSize, iconRenderSize));
            }

            // 3. Text Rendering
            using (Font fBold = new Font("Segoe UI Black", 10f))
            using (Font fReg = new Font("Segoe UI", 8.5f))
            {
                // COLOR LOGIC: 
                // If _isLatest is true, use Green brush. Otherwise, use Black.
                Brush mainTextBrush = _isLatest ? new SolidBrush(Color.Black) : Brushes.Black;
                Brush timeTextBrush = _isLatest ? new SolidBrush(Color.Green) : Brushes.Black;

                // Draw Title
                g.DrawString(_title, fBold, mainTextBrush, 65, 14);

                // Draw Description (Kept Black/Gray to maintain readability)
                g.DrawString(_desc, fReg, Brushes.Black, 65, 32);

                // Draw Time
                SizeF tSize = g.MeasureString(_time, fReg);
                g.DrawString(_time, fReg, timeTextBrush, Width - tSize.Width - 15, 24);

                // Dispose of custom brushes if created
                if (_isLatest)
                {
                    mainTextBrush.Dispose();
                    timeTextBrush.Dispose();
                }
            }

            // 4. Divider Line
            using (Pen p = new Pen(Color.FromArgb(245, 245, 245)))
            {
                g.DrawLine(p, 65, Height - 1, Width - 10, Height - 1);
            }
        }
    }
}