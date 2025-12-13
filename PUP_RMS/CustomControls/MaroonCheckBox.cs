using System.Drawing;
using System.Windows.Forms;

public class MaroonCheckBox : CheckBox
{
    // Define the custom colors
    private Color BoxColor = Color.Maroon;
    private Color CheckColor = Color.White;
    private int BoxSize = 12; // Size of the box square

    public MaroonCheckBox()
    {
        // Set the background to transparent for a clean look
        this.BackColor = Color.Transparent;
        this.Padding = new Padding(10, 0, 0, 0); // Adjust padding to make room for the custom box
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Suppress the default checkbox drawing
        base.OnPaint(e);

        // Define the rectangle for the custom box
        Rectangle rect = new Rectangle(
            0,
            (this.Height - BoxSize) / 2, // Vertically center the box
            BoxSize,
            BoxSize
        );

        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // A. Draw the Box Background (Maroon)
        using (SolidBrush boxBrush = new SolidBrush(BoxColor))
        {
            g.FillRectangle(boxBrush, rect);
        }

        // B. Draw the Box Border (Slightly darker maroon or black)
        using (Pen borderPen = new Pen(Color.DarkRed, 1))
        {
            g.DrawRectangle(borderPen, rect);
        }

        // C. Draw the Checkmark (White) if the control is checked
        if (this.Checked)
        {
            // Simple checkmark drawing using a thick line or small ellipse
            using (Pen checkPen = new Pen(CheckColor, 2))
            {
                // Draw a simple checkmark shape (two lines)
                g.DrawLine(checkPen, rect.Left + 3, rect.Top + rect.Height / 2, rect.Left + rect.Width / 2, rect.Bottom - 3);
                g.DrawLine(checkPen, rect.Left + rect.Width / 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 2);
            }
        }
    }
}