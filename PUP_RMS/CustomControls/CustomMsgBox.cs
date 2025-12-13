using System;
using System.Drawing;
using System.Windows.Forms;

namespace PUP_RMS
{
    public partial class CustomMsgBox : Form
    {
        public CustomMsgBox(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

      

        private void CustomMsgBox_Paint(object sender, PaintEventArgs e)
        {
            // Draws a Maroon border
            e.Graphics.DrawRectangle(new Pen(Color.Maroon, 3), this.DisplayRectangle);
        }

        // --- THIS IS THE MISSING PART THAT CAUSEDa THE ERROR ---
        private void CustomMsgBox_Load(object sender, EventArgs e)
        {
            // You can leave this empty. 
            // It just needs to exist because the Designer is looking for it.
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}