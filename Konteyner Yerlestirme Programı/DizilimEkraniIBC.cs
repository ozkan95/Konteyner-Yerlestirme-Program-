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

namespace Konteyner_Yerlestirme_Programı
{
    public partial class DizilimEkraniIBC : Form
    {
        public DizilimEkraniIBC()
        {
            InitializeComponent();
        }
      
       private void DizilimEkraniIBC_Load(object sender, EventArgs e)
        {
           // groupBox1.Size = Helper.TabanBoyut;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                
                pictureDispos();
                var DesenList = IbcDizilim1(1, 2, new List<int>() { });
                var a = textBox1.Text;
                int sayi = Convert.ToInt32(a);
                var kalan = sayi % 4;
                var tamdeger = sayi / 4;

                if (sayi < 19)
                {
                    for (int i = 1; i < DesenList.Count; i++)
                    {
                        var picture = (PictureBox)Controls.Find("picture" + i, true)[0];
                        picture.DoubleClick += new EventHandler(picture_DoubleClick);
                        if (DesenList[i - 1] == 2)
                        {
                            var DikeyIbc= FotorafGetir("2.jpg");  //dikeyIbc
                            var ab = DikeyIbc.Size;
                           // picture.Size = DikeyIbc.Size;
                            picture.Image = DikeyIbc;
                           

                        }
                        else if (DesenList[i - 1] == 1)
                        {
                            var YatayIbc = FotorafGetir("1.jpg");
                            var ab = YatayIbc.Size;
                           // picture.Size = YatayIbc.Size;
                            picture.Image = YatayIbc;
                        }

                        if (i == sayi)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
            
        }

        private void picture_DoubleClick(object sender, EventArgs e)
        {
            var dene = e;
            var dene2 = sender;
            var sd = groupBox1.Size;

        }

  

        public void pictureDispos()
        {
            for (int i = 1; i <= 18; i++)
            {
                var picture = (PictureBox)Controls.Find("picture" + i, true)[0];
                picture.Image = null;
            }
        }
       List<int> IbcDizilim1(int dikey,int yatay,List<int> dizi)
        {
            dizi.Add(dikey);
            for (int i = 0; i < 5; i++) // yatay ibc
            {
                dizi.Add(yatay);
               dizi.Add(yatay);
                for (int j = 0; j < 2; j++) // dikey ibc
                {
                   dizi.Add(dikey);
                }
            }
            return dizi;
        }
        public Image FotoGetirYeni(string ibc)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap Taban = new Bitmap(filename + "\\20DCTABAN.bmp");
                Bitmap Ibc = new Bitmap(filename + "\\ıbc" + ibc);
                Graphics theShot = Graphics.FromImage(Taban);
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Image FotorafGetir(string ibc)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap png2 = new Bitmap(filename + "\\ıbc" + ibc);
                if (File.Exists(filename + "\\ıbc" + ibc))
                {
                    Bitmap png = new Bitmap(filename + "\\ıbc" + ibc);
                    Bitmap pngtaban;
                    if (ibc=="1.jpg") //yatay ibc
                    {
                      
                       pngtaban = new Bitmap(png, 142, 118);
                    }
                    else     // dikey ibc
                    {
                        pngtaban=new Bitmap(png,118,142);
                    }
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
    }
}
