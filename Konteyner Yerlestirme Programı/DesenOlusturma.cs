using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konteyner_Yerlestirme_Programı
{
    public partial class DesenOlusturma : Form
    {
        public DolumEkipmanlari Secim;
        public DesenOlusturma()
        {
            InitializeComponent();
        }
        public Bitmap IbcGetir(string ibc)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap png2 = new Bitmap(filename + "\\ıbc" + ibc);
                if (File.Exists(filename + "\\ıbc" + ibc))
                {
                    Bitmap png = new Bitmap(filename + "\\ıbc" + ibc);
                    Bitmap pngtaban;
                    if (ibc == "1.jpg") //yatay ibc
                    {

                        pngtaban = new Bitmap(png, 118, 98);
                    }
                    else     // dikey ibc
                    {
                        pngtaban = new Bitmap(png, 98, 118);
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
        public Bitmap VarilGetir(string varil)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap png2 = new Bitmap(filename + "\\VRL-" + varil);
                if (File.Exists(filename + "\\VRL-" + varil))
                {
                    Bitmap png = new Bitmap(filename + "\\VRL-" + varil);
                    Bitmap pngtaban = new Bitmap(png, 114, 114);
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
        private void btnIbcDikey_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "IBCDikey", Genislik = 98, Yukseklik = 118, Gorsel = IbcGetir("2.jpg"),agirlik=1165 };
            this.Close();
        }

        private void btnIbcYatay_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "IBCYatay", Genislik = 118, Yukseklik = 98, Gorsel = IbcGetir("1.jpg"),agirlik=1165 };
            this.Close();
        }

        private void btnPalet1_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "Palet1", Genislik = 114, Yukseklik = 114, Gorsel = VarilGetir("001.jpg"),agirlik=277 };
            this.Close();
        }

        private void btnPalet2_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "Palet2", Genislik = 114, Yukseklik = 114, Gorsel = VarilGetir("002.jpg"),agirlik=524 };
            this.Close();
        }

        private void btnPalet3_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "Palet3", Genislik = 114, Yukseklik = 114, Gorsel = VarilGetir("003.jpg"),agirlik=771 };
            this.Close();
        }

        private void btnPalet4_Click(object sender, EventArgs e)
        {
            Secim = new DolumEkipmanlari { Adi = "Palet4", Genislik = 114, Yukseklik = 114, Gorsel = VarilGetir("004.jpg"),agirlik=1018};
            this.Close();
        }
    }
}
