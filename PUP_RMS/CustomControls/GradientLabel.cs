using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GradientLabel : Label
{
    // Define the colors for the metallic gold gradient using hex codes
    // 1. Dark Shadow (PUP Brown-Maroon-Gold base)
    private Color _shadowColor = ColorTranslator.FromHtml("#B8860B"); // Dark Goldenrod

    // 2. Bright Highlight (The shine)
    private Color _highlightColor = ColorTranslator.FromHtml("#FFFACD"); // Lemon Chiffon (Very Bright)

    // 3. Medium Tone (Mid-reflection)
    private Color _midColor = ColorTranslator.FromHtml("#DAA520"); // Goldenrod

    // Use a vertical gradient mode for a standard metallic shine from top to bottom
    private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;

    public GradientLabel()
    {
        // Set an opaque background to ensure the drawing works correctly
        this.BackColor = Color.Transparent;
        // Make sure the label is big enough to display the gradient clearly
        this.AutoSize = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // 1. Get the rectangle of the text area
        RectangleF textRect = new RectangleF(0, 0, this.Width, this.Height);

        // 2. Create the Linear Gradient Brush
        using (LinearGradientBrush brush = new LinearGradientBrush(
            textRect,
            _shadowColor, // Start with the darker shadow color
            _shadowColor, // End with the darker shadow color (we define stops below)
            _gradientMode
        ))
        {
            // Set the Gradient Stops for the Metallic Effect:
            // This is the key to making it look shiny. We push the bright color (0.5) to the middle.
            ColorBlend colorBlend = new ColorBlend(5); // Define 5 stops for complexity
            colorBlend.Colors = new Color[] {
                _shadowColor,   // 0.0: Top edge dark
                _midColor,      // 0.25: Transitioning to medium
                _highlightColor,// 0.5: CENTER SHINE (The brightest part)
                _midColor,      // 0.75: Transitioning back down
                _shadowColor    // 1.0: Bottom edge dark
            };
            colorBlend.Positions = new float[] { 0.0f, 0.25f, 0.5f, 0.75f, 1.0f };
            brush.InterpolationColors = colorBlend;

            // 3. Define the StringFormat for alignment
            using (StringFormat format = new StringFormat())
            {
                // Align the text based on the label's TextAlign property
                // (Remaining alignment logic as before to handle all content alignments)
                format.Alignment = StringAlignment.Near; // Default alignment
                if (this.TextAlign == ContentAlignment.MiddleCenter ||
                    this.TextAlign == ContentAlignment.TopCenter ||
                    this.TextAlign == ContentAlignment.BottomCenter)
                {
                    format.Alignment = StringAlignment.Center;
                }
                else if (this.TextAlign == ContentAlignment.MiddleRight ||
                         this.TextAlign == ContentAlignment.TopRight ||
                         this.TextAlign == ContentAlignment.BottomRight)
                {
                    format.Alignment = StringAlignment.Far;
                }
                format.LineAlignment = StringAlignment.Center;

                // 4. Draw the text using the gradient brush
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(
                    this.Text,
                    this.Font,
                    brush,
                    textRect,
                    format
                );
            }
        }
    }
}