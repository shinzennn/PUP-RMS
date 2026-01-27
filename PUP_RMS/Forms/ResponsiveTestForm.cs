using System;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Forms;
using PUP_RMS.Helper;

namespace PUP_RMS.Forms
{
    public class ResponsiveTestForm : ResponsiveForm
    {
        public ResponsiveTestForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(800, 600);
            this.Text = "Responsive Design Test";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(600, 400);
            
            // Test controls
            Label lblTitle = new Label
            {
                Text = "Responsive Design Test",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(400, 40),
                AutoSize = false
            };
            
            Label lblInfo = new Label
            {
                Text = "This form automatically scales based on your screen DPI and resolution.\n\n" +
                      "Try changing your display scaling in Windows settings or resizing the window.",
                Font = new Font("Segoe UI", 10f),
                Location = new Point(20, 80),
                Size = new Size(400, 100),
                AutoSize = false
            };
            
            Button btnTest = new Button
            {
                Text = "Test Button",
                Font = new Font("Segoe UI", 10f),
                Location = new Point(20, 200),
                Size = new Size(150, 40),
                UseVisualStyleBackColor = true
            };
            
            TextBox txtTest = new TextBox
            {
                Font = new Font("Segoe UI", 10f),
                Location = new Point(20, 250),
                Size = new Size(300, 25),
                Text = "This textbox should scale properly"
            };
            
            ComboBox cmbTest = new ComboBox
            {
                Font = new Font("Segoe UI", 10f),
                Location = new Point(20, 290),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTest.Items.AddRange(new object[] { "Option 1", "Option 2", "Option 3" });
            cmbTest.SelectedIndex = 0;
            
            DataGridView dgvTest = new DataGridView
            {
                Font = new Font("Segoe UI", 10f),
                Location = new Point(20, 340),
                Size = new Size(400, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true
            };
            dgvTest.Columns.Add("Col1", "Column 1");
            dgvTest.Columns.Add("Col2", "Column 2");
            dgvTest.Columns.Add("Col3", "Column 3");
            dgvTest.Rows.Add("Test Data 1", "Test Data 2", "Test Data 3");
            dgvTest.Rows.Add("Test Data 4", "Test Data 5", "Test Data 6");
            
            // Add controls to form
            this.Controls.AddRange(new Control[] { lblTitle, lblInfo, btnTest, txtTest, cmbTest, dgvTest });
            
            this.ResumeLayout(false);
        }
    }
}