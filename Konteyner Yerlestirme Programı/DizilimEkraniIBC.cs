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
using System.Drawing.Imaging;
using iTextSharp.text.pdf.qrcode;

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
            FotoGetirYeni("1.jpg");

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                
              //  pictureDispos();
                var DesenList = IbcDizilim1(1, 2, new List<int>() { });
                var a = textBox1.Text;
                int sayi = Convert.ToInt32(a);
                var kalan = sayi % 4;
                var tamdeger = sayi / 4;

                pictureDispos();
                var Desen = IbcDizilim1(2, 1, new List<int>());
                if (sayi<19)
                {

                    for (int i = 1; i <= 18; i++)
                    {
                        var picture = (PictureBox)Controls.Find("picture" + i, true)[0];
                       // MessageBox.Show(picture.Width.ToString() + "X" + picture.Height.ToString());
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        if (Desen[i]==2)
                        {
                           // picture.Size = new Size(118, 142);
                            picture.Image = FotorafGetir("2.jpg");
                        }
                        else
                        {
                          //  picture.Size = new Size(142, 118);
                            picture.Image = FotorafGetir("1.jpg");
                        }
                        if (i == sayi)
                            break;
                                                  
                    }
                }
              
                //Bitmap Taban = new Bitmap(Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar" + "\\20DCTABAN.jpg");
                //Graphics theShot = Graphics.FromImage(Taban);
                //if (sayi < 19)
                //{
                //    var yerlesicekNokta = new Point(Helper.IlkKatBaslangic, 20);
                //    Bitmap DikeyIbc = FotorafGetir("296.jpg");
                //    Bitmap YatayIbc = FotorafGetir("196.jpg");
                //    for (int i = 1; i < DesenList.Count; i++)
                //    {
                //       // var picture = (PictureBox)Controls.Find("picture" + i, true)[0];
                //       // picture.DoubleClick += new EventHandler(picture_DoubleClick);
                //        if (DesenList[i - 1] == 2)
                //        {
                //            if (i<11)
                //            {
                //                theShot.DrawImage(DikeyIbc, yerlesicekNokta);
                //                if (i % 2 == 0) // x değişecek y sait
                //                {
                //                    yerlesicekNokta = new Point(yerlesicekNokta.X, YatayIbc.Height + 20);
                //                }
                //                else   // y değişecek x ikinci kat başlangıç noktasına gelicek
                //                {
                //                    yerlesicekNokta = new Point(DikeyIbc.Width + 100, yerlesicekNokta.Y);                
                //                }
                //                if (i == 10)
                //                    yerlesicekNokta = new Point(Helper.IkinciKatBaslangic, 20);
                //            }
                //            else  // ikinci kata gec Dikey
                //            {
                //                theShot.DrawImage(DikeyIbc, yerlesicekNokta);
                //                if (i%2==0)
                //                {
                //                    yerlesicekNokta = new Point(DikeyIbc.Width + 100, yerlesicekNokta.Y);
                //                }
                //                else
                //                {
                //                    yerlesicekNokta = new Point(DikeyIbc.Width+100,yerlesicekNokta.Y);
                //                }
                               
                //            }                                                                                                                                                    
                //        }
                //        else if (DesenList[i - 1] == 1)
                //        {
                //            if (i<11)
                //            {
                //                theShot.DrawImage(YatayIbc, yerlesicekNokta);
                //                if (i % 2 == 0)
                //                {
                //                    yerlesicekNokta = new Point(DikeyIbc.Width + 100, yerlesicekNokta.Y);
                //                }
                //                else
                //                {
                //                    yerlesicekNokta = new Point(yerlesicekNokta.X, YatayIbc.Height + 20);
                //                }
                //                if (i == 10)
                //                    yerlesicekNokta = new Point(Helper.IkinciKatBaslangic, 20);
                //            }
                //            else // ikinci kata geç
                //            {

                //            }
                //            if (i == 1)
                //                theShot.DrawImage(YatayIbc, Helper.IlkKatBaslangic, 20);
                //            else if(i<10)
                //            {
                //                theShot.DrawImage(YatayIbc, Helper.IlkKatBaslangic, 20);
                //            }
                            
                    
                //        }

                //        if (i == sayi)
                //        {
                //            pictureBox1.Image = ResizeImage(Taban, Taban.Width / 5, Taban.Height / 5);
                //            break;
                //        }
                //    }
                //}
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
        public static Bitmap ResizeImage(Bitmap B, int Width, int Height)
        {
            Bitmap BNew = new Bitmap(Width, Height, PixelFormat.Format16bppRgb565);
            Graphics G = Graphics.FromImage(BNew);
            float sx = (float)Width / (float)B.Width;
            float sy = (float)Height / (float)B.Height;

            G.ScaleTransform(sx, sy);
            G.DrawImage(B, 0, 0);


            return BNew;
        }
        public void FotoGetirYeni(string ibc)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap Taban = new Bitmap(filename + "\\20DCTABAN.jpg");
                Bitmap Ibc1 = new Bitmap(filename + "\\ıbc196.jpg");
                Bitmap Ibc2 = new Bitmap(filename + "\\ıbc296.jpg");
                Graphics theShot = Graphics.FromImage(Taban);
              //  theShot.CopyFromScreen(0, 0, 3, 3, Taban.Size, CopyPixelOperation.SourceCopy);
                theShot.DrawImage(Ibc1, new Point(Helper.IlkKatBaslangic, 20));
                theShot.DrawImage(Ibc2, new Point(Ibc1.Width+Helper.KatlararasiBosluk, 20));
              var yeni=  ResizeImage(Taban, Taban.Size.Width / 5, Taban.Size.Height / 5);
                pictureBox1.Size = yeni.Size;
                pictureBox1.Image = yeni;
            }
            catch (Exception)
            {

               
            }
        }
        
        public Bitmap FotorafGetir(string ibc)
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = (e.X * 5).ToString() + "  Y:" + (e.Y * 5).ToString();
        }
    }
}
