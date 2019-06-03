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

        }

        private void OnLoadClick(Object sender, EventArgs ea)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            bitmap.SetPixel(1,1,Color.White);
            pictureBox2.Image = bitmap;
        }



        private void Generate(string name)
        {

            Bitmap image = new Bitmap(Image.FromFile(name));//load image
            Bitmap btm = new Bitmap(image.Width, image.Height);//set size of new image

            for (int y=0;y<image.Height;y++)
            {
                for (int x=0;x<image.Width;x++)
                {
                    btm.SetPixel(x,y,Color.FromArgb(image.GetPixel(x,y).A,255-image.GetPixel(x, y).R,255- image.GetPixel(x, y).G,255- image.GetPixel(x, y).B));
                }
            }
            pictureBox2.Image = btm;
        }

        private void SaveImage(string name)
        {
            Bitmap bitmap = new Bitmap(pictureBox2.Image);
            bitmap.Save(name);
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG (*.png)|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveImage(saveFileDialog.FileName);
            }


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg";


            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Generate(fileDialog.FileName);

                toolStripMenuItem3.Enabled = true;
            }
        }
    }
}
