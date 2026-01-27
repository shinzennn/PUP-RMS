using System;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Helper;

namespace PUP_RMS.Forms
{
    public class ResponsiveForm : Form
    {
        protected float scaleFactor;
        protected Size originalFormSize;
        protected bool isResponsive = true;

        public ResponsiveForm()
        {
            InitializeComponent();
            SetupResponsiveDesign();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Set DPI awareness
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            
            // Enable double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            this.ResumeLayout(false);
        }

        protected virtual void SetupResponsiveDesign()
        {
            if (!isResponsive) return;

            // Store original size
            originalFormSize = this.Size;
            
            // Calculate current scale factor
            scaleFactor = ResponsiveHelper.GetScaleFactor(this);
            
            // Hook up events
            this.Load += ResponsiveForm_Load;
            this.Resize += ResponsiveForm_Resize;
            this.DpiChanged += ResponsiveForm_DpiChanged;
            
            // Set minimum size
            this.MinimumSize = new Size(800, 600);
        }

        protected virtual void ResponsiveForm_Load(object sender, EventArgs e)
        {
            if (!isResponsive) return;
            ApplyResponsiveScaling();
        }

        protected virtual void ResponsiveForm_Resize(object sender, EventArgs e)
        {
            if (!isResponsive || this.WindowState == FormWindowState.Minimized) return;
            ApplyResponsiveScaling();
        }

        protected virtual void ResponsiveForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            if (!isResponsive) return;
            
            // Recalculate scale factor
            scaleFactor = ResponsiveHelper.GetScaleFactor(this);
            ApplyResponsiveScaling();
        }

        protected virtual void ApplyResponsiveScaling()
        {
            if (!isResponsive) return;

            // This method can be overridden by derived forms
            // to implement specific responsive behavior
            foreach (Control control in this.Controls)
            {
                ScaleControlRecursively(control);
            }
        }

        protected virtual void ScaleControlRecursively(Control control)
        {
            if (!isResponsive || scaleFactor == 1f) return;

            // Skip top-level controls
            if (control.TopLevelControl == control) return;

            // Apply scaling based on control type
            if (control is Button btn)
            {
                ScaleButton(btn);
            }
            else if (control is TextBox txt)
            {
                ScaleTextBox(txt);
            }
            else if (control is ComboBox cmb)
            {
                ScaleComboBox(cmb);
            }
            else if (control is DataGridView dgv)
            {
                ScaleDataGridView(dgv);
            }
            else if (control is Panel pnl)
            {
                ScalePanel(pnl);
            }
            else
            {
                ScaleGenericControl(control);
            }

            // Recursively scale child controls
            foreach (Control child in control.Controls)
            {
                ScaleControlRecursively(child);
            }
        }

        protected virtual void ScaleButton(Button button)
        {
            if (scaleFactor != 1f)
            {
                button.Font = ResponsiveHelper.GetScaledFont(button.Font, scaleFactor);
                button.Padding = new Padding(
                    (int)(button.Padding.Left * scaleFactor),
                    (int)(button.Padding.Top * scaleFactor),
                    (int)(button.Padding.Right * scaleFactor),
                    (int)(button.Padding.Bottom * scaleFactor));
            }
        }

        protected virtual void ScaleTextBox(TextBox textBox)
        {
            if (scaleFactor != 1f)
            {
                textBox.Font = ResponsiveHelper.GetScaledFont(textBox.Font, scaleFactor);
            }
        }

        protected virtual void ScaleComboBox(ComboBox comboBox)
        {
            if (scaleFactor != 1f)
            {
                comboBox.Font = ResponsiveHelper.GetScaledFont(comboBox.Font, scaleFactor);
            }
        }

        protected virtual void ScaleDataGridView(DataGridView dataGridView)
        {
            if (scaleFactor != 1f)
            {
                dataGridView.Font = ResponsiveHelper.GetScaledFont(dataGridView.Font, scaleFactor);
                dataGridView.RowTemplate.Height = (int)(dataGridView.RowTemplate.Height * scaleFactor);
            }
        }

        protected virtual void ScalePanel(Panel panel)
        {
            if (scaleFactor != 1f)
            {
                panel.Padding = new Padding(
                    (int)(panel.Padding.Left * scaleFactor),
                    (int)(panel.Padding.Top * scaleFactor),
                    (int)(panel.Padding.Right * scaleFactor),
                    (int)(panel.Padding.Bottom * scaleFactor));
            }
        }

        protected virtual void ScaleGenericControl(Control control)
        {
            if (scaleFactor != 1f && control.Font != null)
            {
                control.Font = ResponsiveHelper.GetScaledFont(control.Font, scaleFactor);
            }
        }

        protected void SetResponsive(bool enabled)
        {
            isResponsive = enabled;
        }
    }
}