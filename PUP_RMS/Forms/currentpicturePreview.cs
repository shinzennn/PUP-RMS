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

        private void currentpicturePreview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
                pictureBox1.Image = Zoom(pictureBox1.Image, new Size(pictureBox1.Width - 50, pictureBox1.Height - 50));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            pictureBox1.Image = Zoom(pictureBox1.Image, new Size (a-=1, a -= 1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            pictureBox1.Image = Zoom(pictureBox1.Image, new Size(a += 1, a += 1));
        }

    }
}
