using System;
using System.Drawing;
using System.Windows.Forms;

namespace PUP_RMS.Helper
{
    public static class ResponsiveHelper
    {
        private static float originalDpi = 96f;
        
        public static void MakeFormResponsive(Form form)
        {
            // Enable DPI awareness
            if (form != null)
            {
                // Set form to be DPI aware
                form.AutoScaleMode = AutoScaleMode.Dpi;
                
                // Handle DPI changes
                form.DpiChanged += (sender, e) =>
                {
                    ApplyResponsiveScaling(form);
                };
                
                // Handle resize
                form.Resize += (sender, e) =>
                {
                    if (form.WindowState == FormWindowState.Normal)
                    {
                        ApplyResponsiveScaling(form);
                    }
                };
            }
        }
        
        public static float GetScaleFactor(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                return g.DpiX / originalDpi;
            }
        }
        
        public static void ScaleControl(Control control, float scaleFactor)
        {
            if (scaleFactor == 1f) return;
            
            // Scale size
            control.Width = (int)(control.Width * scaleFactor);
            control.Height = (int)(control.Height * scaleFactor);
            
            // Scale font
            if (control.Font != null)
            {
                float newFontSize = control.Font.Size * scaleFactor;
                control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
            }
            
            // Scale location for child controls
            if (control.Parent != null && !(control is Form))
            {
                control.Left = (int)(control.Left * scaleFactor);
                control.Top = (int)(control.Top * scaleFactor);
            }
        }
        
        public static void ApplyResponsiveScaling(Form form)
        {
            float scaleFactor = GetScaleFactor(form);
            
            foreach (Control control in form.Controls)
            {
                ScaleControlRecursively(control, scaleFactor);
            }
        }
        
        private static void ScaleControlRecursively(Control control, float scaleFactor)
        {
            if (scaleFactor == 1f) return;
            
            // Don't scale if already scaled by the form's AutoScaleMode
            if (control.TopLevelControl == control) return;
            
            ScaleControl(control, scaleFactor);
            
            // Scale child controls
            foreach (Control child in control.Controls)
            {
                ScaleControlRecursively(child, scaleFactor);
            }
        }
        
        public static void SetResponsiveButton(Button button, float scaleFactor)
        {
            if (button != null && scaleFactor != 1f)
            {
                button.Padding = new Padding(
                    (int)(button.Padding.Left * scaleFactor),
                    (int)(button.Padding.Top * scaleFactor),
                    (int)(button.Padding.Right * scaleFactor),
                    (int)(button.Padding.Bottom * scaleFactor));
            }
        }
        
        public static Size GetScaledSize(Size originalSize, float scaleFactor)
        {
            return new Size(
                (int)(originalSize.Width * scaleFactor),
                (int)(originalSize.Height * scaleFactor));
        }
        
        public static Point GetScaledPosition(Point originalPosition, float scaleFactor)
        {
            return new Point(
                (int)(originalPosition.X * scaleFactor),
                (int)(originalPosition.Y * scaleFactor));
        }
        
        public static Font GetScaledFont(Font originalFont, float scaleFactor)
        {
            if (originalFont == null || scaleFactor == 1f) return originalFont;
            
            return new Font(
                originalFont.FontFamily,
                originalFont.Size * scaleFactor,
                originalFont.Style);
        }
    }
}