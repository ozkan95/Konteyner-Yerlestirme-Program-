using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Policy;
using System.Data;
using System.Data.SqlClient;


namespace Konteyner_Yerlestirme_Programı
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureDispos();
            var a = textBox1.Text;
            int sayi = Convert.ToInt32(a);
            var kalan = sayi % 4;
            var tamdeger = sayi / 4;
            for (int i = 1; i <= tamdeger; i++)
            {
                var picture = (PictureBox)Controls.Find("pictureBox" + i,true) [0];
                //MessageBox.Show(picture.Name);
                picture.Image = FotorafGetir("004.jpg");

            }
            if(kalan != 0)
            { 
                if (kalan != 4)
                     
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + (tamdeger + 1), true)[0];

                    if (kalan == 1)
                    {
                        var oncekipicture = (PictureBox)Controls.Find("pictureBox" + (tamdeger), true)[0];
                        picture.Image = FotorafGetir("002.png");
                        oncekipicture.Image = FotorafGetir("003.jpg");
                    }
                    if (kalan == 2)
                    {
                        var oncekipicture = (PictureBox)Controls.Find("pictureBox" + (tamdeger), true)[0];
                        oncekipicture.Image = FotorafGetir("003.jpg");
                        picture.Image = FotorafGetir("003.jpg");
                    }
                    if (kalan == 3)
                        picture.Image = FotorafGetir("003.jpg");
                }
            }   
        }
        public void pictureDispos()
        {
            for (int i = 1; i <= 20; i++)
            {
                var picture = (PictureBox)Controls.Find("pictureBox" + i, true)[0];
                picture.Image = null;
            }
        }
        
        public Image FotorafGetir(string varil)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap png2 = new Bitmap(filename + "\\VRL-" + varil );
                if (File.Exists(filename + "\\VRL-"+ varil))
                {
                    Bitmap png = new Bitmap(filename + "\\VRL-" + varil );
                    Bitmap pngtaban = new Bitmap(png, 128, 128);
                    //pictureBox1.Image = pngtaban;
                    return pngtaban;
                }
                else
                {
                   return null;     
                }
            }
            catch (Exception e)
            {
                return null;
                MessageBox.Show(e.ToString());
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureDispos();
                var a = textBox1.Text;
                int sayi = Convert.ToInt32(a);
                var kalan = sayi % 4;
                var tamdeger = sayi / 4;
                for (int i = 1; i <= tamdeger; i++)
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i, true)[0];
                    //MessageBox.Show(picture.Name);
                    picture.Image = FotorafGetir("004.jpg");

                }
                if (kalan != 0)
                {
                    if (kalan != 4)

                    {
                        var picture = (PictureBox)Controls.Find("pictureBox" + (tamdeger + 1), true)[0];

                        if (kalan == 1)
                        {
                            var oncekipicture = (PictureBox)Controls.Find("pictureBox" + (tamdeger), true)[0];
                            picture.Image = FotorafGetir("002.png");
                            oncekipicture.Image = FotorafGetir("003.jpg");
                        }
                        if (kalan == 2)
                        {
                            var oncekipicture = (PictureBox)Controls.Find("pictureBox" + (tamdeger), true)[0];
                            oncekipicture.Image = FotorafGetir("003.jpg");
                            picture.Image = FotorafGetir("003.jpg");
                        }
                        if (kalan == 3)
                            picture.Image = FotorafGetir("003.jpg");
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
