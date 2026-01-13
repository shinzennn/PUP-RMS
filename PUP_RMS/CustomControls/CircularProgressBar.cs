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
    private int _minimum = 0;
    private int _maximum = 100;

    // --- NEW BETTER GRADIENT (Premium Maroon) ---
    private Color _gradientStart = Color.FromArgb(100, 0, 0);    // Deep Dark Maroon
    private Color _gradientEnd = Color.FromArgb(255, 65, 85);    // Bright Vivid Red/Pink

    // --- ADJUSTED TRACK & CENTER ---
    private Color _trackColor = Color.FromArgb(240, 240, 240);   // Very light gray (Clean look)
    private Color _centerColorStart = Color.White;
    private Color _centerColorEnd = Color.FromArgb(245, 245, 250); // Almost white, slight cool tint

    private int _barWidth = 16;   // Slightly thicker
    private int _fontSize = 14;   // Slightly larger text

    // ==========================================================
    // PROPERTIES
    // ==========================================================

    [Category("Progress Settings")]
    public int Value
    {
        get { return _value; }
        set
        {
            int newValue = value;
            if (newValue < _minimum) newValue = _minimum;
            if (newValue > _maximum) newValue = _maximum;
            _value = newValue;
            this.Invalidate();
        }
    }

    [Category("Progress Settings")]
    public int Minimum
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
    public int Maximum
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
    public Color ProgressColor
    {
        get { return _gradientStart; }
        set
        {
            _gradientStart = value;
            _gradientEnd = value;
            this.Invalidate();
        }
    }

    [Category("Appearance")]
    public Color GradientStart
    {
        get { return _gradientStart; }
        set { _gradientStart = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color GradientEnd
    {
        get { return _gradientEnd; }
        set { _gradientEnd = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color TrackColor
    {
        get { return _trackColor; }
        set { _trackColor = value; Invalidate(); }
    }

    [Category("Appearance")]
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
    public int FontSize
    {
        get { return _fontSize; }
        set
        {
            if (value < 8) value = 8;
            _fontSize = value;
            this.Font = new Font("Segoe UI", _fontSize, FontStyle.Bold);
            this.Invalidate();
        }
    }

    // ==========================================================
    // CONSTRUCTOR
    // ==========================================================
    public CircularProgressBar()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        this.BackColor = Color.Transparent;
        this.Size = new Size(140, 140);
        this.Font = new Font("Segoe UI", _fontSize, FontStyle.Bold);
        this.DoubleBuffered = true;
    }

    // ==========================================================
    // PAINTING LOGIC
    // ==========================================================
    protected override void OnPaint(PaintEventArgs e)
    {
        if (this.Width <= 0 || this.Height <= 0) return;

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Rectangle rect = this.ClientRectangle;
        Rectangle arcRect = new Rectangle(
            rect.X + _barWidth / 2,
            rect.Y + _barWidth / 2,
            rect.Width - _barWidth,
            rect.Height - _barWidth);

        if (arcRect.Width <= 0 || arcRect.Height <= 0) return;

        // 2. Draw Track
        using (Pen trackPen = new Pen(_trackColor, _barWidth))
        {
            e.Graphics.DrawEllipse(trackPen, arcRect);
        }

        // 3. Draw Gradient Progress
        if (_value > 0)
        {
            float sweepAngle = (_maximum > 0) ? 360f * _value / _maximum : 0;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, _gradientStart, _gradientEnd, 45f))
            {
                using (Pen progressPen = new Pen(brush, _barWidth))
                {
                    progressPen.StartCap = LineCap.Round;
                    progressPen.EndCap = LineCap.Round;
                    e.Graphics.DrawArc(progressPen, arcRect, -90, sweepAngle);
                }
            }
        }

        // 4. Draw Center Circle
        int innerOffset = _barWidth;
        Rectangle innerRect = new Rectangle(
            rect.X + innerOffset,
            rect.Y + innerOffset,
            rect.Width - (innerOffset * 2),
            rect.Height - (innerOffset * 2)
        );

        if (innerRect.Width > 0)
        {
            int shadowShift = 4;
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
            {
                e.Graphics.FillEllipse(shadowBrush,
                    innerRect.X + shadowShift,
                    innerRect.Y + shadowShift,
                    innerRect.Width,
                    innerRect.Height);
            }

            using (LinearGradientBrush centerBrush = new LinearGradientBrush(
                innerRect, _centerColorStart, _centerColorEnd, 65f))
            {
                e.Graphics.FillEllipse(centerBrush, innerRect);
            }
        }

        // 5. Draw Text (Percentage and "Used" Label)
        int percent = (_maximum > 0) ? (int)((float)_value / _maximum * 100) : 0;
        string mainText = $"{percent}%";
        string subText = "Used";

        // Draw Main Percentage Text
        SizeF mainTextSize = e.Graphics.MeasureString(mainText, this.Font);
        PointF mainTextPoint = new PointF(
            (this.Width - mainTextSize.Width) / 2,
            (this.Height - mainTextSize.Height) / 2 - (mainTextSize.Height / 4)); // Shift up slightly

        using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(44, 54, 79))) // Dark slate for percentage
        {
            e.Graphics.DrawString(mainText, this.Font, textBrush, mainTextPoint);
        }

        // Draw "Used" Subtext
        using (Font subFont = new Font("Segoe UI", _fontSize * 0.7f, FontStyle.Regular))
        using (SolidBrush subBrush = new SolidBrush(Color.Gray))
        {
            SizeF subTextSize = e.Graphics.MeasureString(subText, subFont);
            PointF subTextPoint = new PointF(
                (this.Width - subTextSize.Width) / 2,
                mainTextPoint.Y + mainTextSize.Height - 5); // Positioned directly under main text

            e.Graphics.DrawString(subText, subFont, subBrush, subTextPoint);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        this.Height = this.Width;
        base.OnResize(e);
    }
}