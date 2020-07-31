using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScanPmrWinForm.ViewModel;

namespace ScanPmrWinForm.Views
{
    public partial class DetailPmrForm : Form
    {
        public DetailPmrForm(string fronte, string retro)
        {
            InitializeComponent();

            Bitmap bf = new Bitmap(fronte);
            Bitmap br = new Bitmap(retro);
            pictureBoxFronte.Image = bf;
            pictureBoxRetro.Image = br;

            //bf.Dispose();
            //br.Dispose();
        }

        public void DisposeImages()
        {
            pictureBoxFronte.Image.Dispose();
            pictureBoxRetro.Image.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image bf =  pictureBoxFronte.Image;
            bf.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            pictureBoxFronte.Image = bf;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image bf = pictureBoxRetro.Image;
            bf.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            pictureBoxRetro.Image = bf;
        }
    }
}
