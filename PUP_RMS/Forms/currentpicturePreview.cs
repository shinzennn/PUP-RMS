using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace PUP_RMS.Forms
{
    public partial class currentpicturePreview : Form
    {
        public Image PassedImage { get; set; }

        public currentpicturePreview()
        {
            InitializeComponent();
          
        }

        int picWidth = 0;
        int picHeight = 0;

        private void currentpicturePreview_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            if (PassedImage != null) { 
                pictureBox1.Image = PassedImage; 
            }
            picHeight = pictureBox1.Image.Height;
            picWidth = pictureBox1.Image.Width;


        }

        Image Zoom(Image img, Size size)
        {
            // zoom picturebox c#
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void currentpicturePreview_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width, pictureBox1.Height += 10);
                this.AutoScrollMinSize = new Size(pictureBox1.Right, pictureBox1.Bottom);
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width, pictureBox1.Height -= 10);
                this.AutoScrollMinSize = new Size(pictureBox1.Right, pictureBox1.Bottom);
            }
        }
    }
}
