using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace PUP_RMS
{
    public class RecordDistributionPanelCard : RoundedPanel // Inherit from your existing RoundedPanel
    {
        // --- PRIVATE FIELDS FOR CUSTOM DRAWING ---
        private Image _cardIcon;
        private string _cardLabel = "Label"; // Default label text

        // --- CUSTOM PROPERTIES FOR ICON AND LABEL ---

        [Category("Card Content")]
        [Description("The icon displayed at the top of the card.")]
        public Image CardIcon
        {
            get { return _cardIcon; }
            set
            {
                _cardIcon = value;
                this.Invalidate(); // Redraw when icon changes
            }
        }

        [Category("Card Content")]
        [Description("The text label displayed below the icon.")]
        public string CardLabel
        {
            get { return _cardLabel; }
            set
            {
                _cardLabel = value;
                this.Invalidate(); // Redraw when label changes
            }
        }

        [Category("Card Content")]
        [Description("The color of the text label.")]
        public Color LabelForeColor { get; set; } = Color.FromArgb(40, 40, 40); // Dark grey for text

        [Category("Card Content")]
        [Description("The font of the text label.")]
        public Font LabelFont { get; set; } = new Font("Segoe UI", 10F, FontStyle.Regular); // Default font

        // --- NEW PROPERTIES FOR EXPLICIT CARD BORDER COLORS ---
        [Category("Card Appearance - Borders")]
        [Description("The border color of the card when not hovered.")]
        public Color NormalCardBorderColor { get; set; } = Color.Gray; // Example default, adjust as needed

        [Category("Card Appearance - Borders")]
        [Description("The border color of the card when hovered.")]
        public Color HoverCardBorderColor { get; set; } = Color.FromArgb(242, 169, 0); // Your specified yellow/gold

        // --- CONSTRUCTOR: SET DEFAULTS ---
        public RecordDistributionPanelCard()
        {
            // Set default properties specific to this card, leveraging RoundedPanel's properties
            this.Size = new Size(120, 120); // Default size, adjust as needed
            this.BorderRadius = 15;        // Default border radius for the card
            this.ShadowEnabled = true;     // Cards usually have shadows

            // Set default background color for the card (as per your request)
            this.BackColor = Color.FromArgb(254, 243, 209);

            // Set hover background color (as per your request, usually same or slightly different)
            this.HoverBackColor = Color.FromArgb(254, 243, 209);

            // Initialize the NEW explicit border properties
            this.NormalCardBorderColor = Color.LightGray; // Example: A subtle border when not hovered
            this.HoverCardBorderColor = Color.FromArgb(242, 169, 0); // Your specified yellow/gold on hover

            // Apply the NORMAL border color and size initially
            this.BorderColor = this.NormalCardBorderColor; // Inherited from RoundedPanel
            this.BorderSize = 1;                           // Default border size for normal state

            // IMPORTANT: The inherited HoverBorderColor property must be set to the desired hover color
            // so that RoundedPanel's drawing logic picks it up when SetBorderHover(true) is called.
            this.HoverBorderColor = this.HoverCardBorderColor; // Inherited from RoundedPanel

            // Remove default panel padding to allow icon/label to draw closer to edges
            this.Padding = new Padding(0);

            // Re-enable mouse events for *this specific class*
            this.MouseEnter += RecordDistributionPanelCard_MouseEnter;
            this.MouseLeave += RecordDistributionPanelCard_MouseLeave;
        }

        // --- MOUSE HOVER EVENTS FOR THIS CARD ---
        private void RecordDistributionPanelCard_MouseEnter(object sender, EventArgs e)
        {
            // When mouse enters, set the inherited BorderColor to the HoverCardBorderColor
            // and then trigger the hover state in the base class.
            base.BorderColor = this.HoverCardBorderColor;
            base.SetBorderHover(true);
        }

        private void RecordDistributionPanelCard_MouseLeave(object sender, EventArgs e)
        {
            // When mouse leaves, revert the inherited BorderColor to the NormalCardBorderColor
            // and then trigger the normal state in the base class.
            base.BorderColor = this.NormalCardBorderColor;
            base.SetBorderHover(false);
        }

        // --- CUSTOM PAINTING FOR ICON AND LABEL ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // IMPORTANT: Call base.OnPaint to draw rounded panel, background, border, and shadow first

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Calculate positions
            RectangleF clientRect = this.ClientRectangle;

            // Draw Icon (if available)
            if (CardIcon != null)
            {
                // Calculate icon size to fit within the card (e.g., 50% of card width, centered)
                int iconWidth = (int)(clientRect.Width * 0.4); // Adjust as needed
                int iconHeight = (int)(clientRect.Height * 0.4); // Adjust as needed

                // Ensure icon doesn't exceed its natural size if it's smaller
                if (CardIcon.Width < iconWidth) iconWidth = CardIcon.Width;
                if (CardIcon.Height < iconHeight) iconHeight = CardIcon.Height;

                int iconX = (int)((clientRect.Width - iconWidth) / 2);
                int iconY = (int)(clientRect.Height * 0.2); // Position from top, adjust as needed

                g.DrawImage(CardIcon, iconX, iconY, iconWidth, iconHeight);
            }

            // Draw Label
            if (!string.IsNullOrEmpty(CardLabel))
            {
                using (Brush textBrush = new SolidBrush(LabelForeColor))
                {
                    // Center the text horizontally and place it below the icon
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center // Center vertically within its drawing area
                    };

                    // Define the rectangle for the label (below icon, taking up bottom part of card)
                    RectangleF labelRect = new RectangleF(
                        clientRect.X,
                        clientRect.Height * 0.6f, // Start label from 60% down the card
                        clientRect.Width,
                        clientRect.Height * 0.3f  // Label takes up 30% of card height
                    );

                    g.DrawString(CardLabel, LabelFont, textBrush, labelRect, sf);
                }
            }
        }
    }
}