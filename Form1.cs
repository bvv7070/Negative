using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Generate();
        }

        private void Generate()
        {
            string name = "";//target image directory

            Bitmap image = new Bitmap(Image.FromFile(name));//load image
            Bitmap btm = new Bitmap(image.Width, image.Height);//set size of new image

            for (int y=0;y<image.Height;y++)
            {
                for (int x=0;x<image.Width;x++)
                {
                    btm.SetPixel(x,y,Color.FromArgb(image.GetPixel(x,y).A,255-image.GetPixel(x, y).R,255- image.GetPixel(x, y).G,255- image.GetPixel(x, y).B));
                }
            }
            pictureBox1.Image = btm;

            btm.Save("");//directory where edited file is saved
        }
    }
}
