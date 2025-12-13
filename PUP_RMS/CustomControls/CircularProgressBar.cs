using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircularProgressBar : Control
{
    // ==========================================================
    // FIELDS
    // ==========================================================

    private int _value = 0;
    private int _minimum = 0; // Added private field for minimum
    private int _maximum = 100;
    private Color _progressColor = Color.Maroon;
    private Color _trackColor = Color.FromArgb(220, 220, 220); // Light Gray background
    private int _barWidth = 10;
    private int _fontSize = 10;

    // ==========================================================
    // PROPERTIES (Updated for Missing Minimum/Maximum)
    // ==========================================================

    [Category("Progress Settings")]
    [Description("The current progress value.")]
    public int Value
    {
        get { return _value; }
        set
        {
            if (value < _minimum) value = _minimum;
            if (value > _maximum) value = _maximum;
            _value = value;
            this.Invalidate(); // Forces the control to redraw
        }
    }

    [Category("Progress Settings")]
    [Description("The minimum value (usually 0).")]
    public int Minimum // <-- FIX CS1061
    {
        get { return _minimum; }
        set
        {
            if (value < 0) value = 0;
            _minimum = value;
            this.Invalidate();
        }
    }

    [Category("Progress Settings")]
    [Description("The maximum value (usually 100).")]
    public int Maximum // <-- FIX CS1061
    {
        get { return _maximum; }
        set
        {
            if (value < _minimum) value = _minimum + 1;
            _maximum = value;
            this.Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The color of the filled progress arc (e.g., Maroon).")]
    public Color ProgressColor
    {
        get { return _progressColor; }
        set
        {
            _progressColor = value;
            this.Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The color of the track (the unfilled background circle).")]
    public Color TrackColor
    {
        get { return _trackColor; }
        set
        {
            _trackColor = value;
            this.Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The width of the progress bar line.")]
    public int BarWidth
    {
        get { return _barWidth; }
        set
        {
            if (value < 1) value = 1;
            _barWidth = value;
            this.Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The font size for the percentage text.")]
    public int FontSize
    {
        get { return _fontSize; }
        set
        {
            if (value < 8) value = 8;
            _fontSize = value;
            this.Invalidate();
        }
    }

    // ==========================================================
    // CONSTRUCTOR AND PAINTING LOGIC
    // ==========================================================

    public CircularProgressBar()
    {
        // Set styles to prevent flickering (Double Buffering)
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

        this.Size = new Size(100, 100);
        this.Font = new Font("Segoe UI", _fontSize, FontStyle.Bold);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // 1. Calculate the drawing area
        Rectangle rect = new Rectangle(
            BarWidth / 2,
            BarWidth / 2,
            this.Width - BarWidth,
            this.Height - BarWidth
        );

        // 2. Draw the background track (The full circle)
        using (Pen trackPen = new Pen(TrackColor, BarWidth))
        {
            e.Graphics.DrawEllipse(trackPen, rect);
        }

        // 3. Calculate the sweep angle for the progress arc
        // Protect against division by zero if Maximum is 0 (though we prevent this in the setter)
        float sweepAngle = (_maximum > 0) ? 360f * (float)_value / _maximum : 0f;

        // 4. Draw the progress arc (The colored fill)
        using (Pen progressPen = new Pen(ProgressColor, BarWidth))
        {
            progressPen.StartCap = LineCap.Round;
            progressPen.EndCap = LineCap.Round;

            // Start angle is -90 (the top of the circle)
            e.Graphics.DrawArc(progressPen, rect, -90, sweepAngle);
        }

        // 5. Draw the percentage text in the center
        int percent = (_maximum > 0) ? (int)Math.Round((double)this.Value / this.Maximum * 100) : 0;
        string text = $"{percent}%";

        using (StringFormat format = new StringFormat())
        {
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(text, this.Font, textBrush, this.ClientRectangle, format);
            }
        }

        base.OnPaint(e);
    }
}