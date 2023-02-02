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
using System.Runtime.InteropServices;

namespace Konteyner_Yerlestirme_Programı
{
    public partial class DizilimMix : Form
    {
        public DizilimMix()
        {
            InitializeComponent();
        }
        List<DolumEkipmanlari> DesenEkipman = new List<DolumEkipmanlari>();
        PictureBox SeciliPicture;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                var Ibcsayi = Convert.ToInt16(txtIbc.Text);
                var Varilsayi = Convert.ToInt16(txtVaril.Text);
                var kalanVaril = Varilsayi % 4;
                var tamdegerVaril = Varilsayi / 4;
                var DesenList = IbcDizilim1(2, 1, new List<int>());
                pictureDispos();
                DizilimYap(false,Ibcsayi, Varilsayi);


            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public void pictureDispos()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                    picture.Image = null;
                }
             
            }
        }
        List<int> IbcDizilim1(int dikey, int yatay, List<int> dizi)
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
     

        private void DizilimMix_Load(object sender, EventArgs e)
        {
            // picture.Size = new Size(114, 114);
            //if (Desen[i,j]==2)                    
            //    picture.Size = new Size(98, 118);
            //else
            //    picture.Size = new Size(118, 98);
            txtVaril.Text=0.ToString();
            txtIbc.Text=0.ToString();
            groupBox1.Size = new Size(489, 595);
          
         //   DizilimYap();
            PictureDoubleClick();
            SeciliPicture = pictureBox00;
           
          
        }
        void PictureDoubleClick()  //DoubleClick eventi cağırmak
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                    picture.Tag = false;

                    picture.DoubleClick += Picture_DoubleClick;
                    picture.Click += Picture_Click;
                    
                }
            }
         
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            SeciliPicture=(PictureBox)sender;
            SeciliPicture.Paint += pictureBox_Paint;
            if (!ModifierKeys.HasFlag(Keys.Control))
            {
                var Secili = SeciliPictureboxlar();
                for (int i = 0; i < Secili.Count(); i++)
                {
                    var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                    picture.Tag = false;
                   // picture.Paint += pictureBox_Paint;
                    picture.Refresh();
                }
            }
            
            sayac++;
            if ((bool)SeciliPicture.Tag==true)           
                SeciliPicture.Tag = false;          
            else           
                SeciliPicture.Tag=true;
            
          
           SeciliPicture.Refresh();
            //if (pictureBox01.CanSelect==false) { pictureBox01.Tag = Color.Blue; }
            //else { pictureBox01.Tag = Color.Red; }
            //pictureBox01.Refresh();
        }

        void DizilimYap(bool desendengetir= false,int ibcsayi= 20, int varilsayi = 0)
        {
            int[,] DesenIBC = { {1,2,1,2},{2,1,2,1},{1,2,1,2},{2,1,2,1},{1,2,1,2} };

            int LocationY = 10;
            int ibcsayaci = 0;
            int varilsayaci = 0;
            var kalan = varilsayi % 4;
            var tamdeger = varilsayi / 4;
            for (int i = 0; i < 5; i++) // satir
            {
                int LocationX = 4;
              
                for (int j = 0; j < 4; j++) //sutun
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                   

                    if (desendengetir)
                    {
                        foreach (var item in DesenEkipman)
                        {
                            if (item.Konum == i.ToString() + j.ToString())
                            {
                                picture.Size = new Size(item.Genislik, item.Yukseklik);
                                picture.Image = item.Gorsel;
                                picture.Tag = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (ibcsayi != ibcsayaci)
                        {
                            if (DesenIBC[i, j] == 2)
                            {
                                picture.Size = new Size(98, 118);
                                picture.Image = IbcGetir("2.jpg");
                                ibcsayaci++;
                            }
                            else
                            {
                                picture.Size = new Size(118, 98);
                                picture.Image = IbcGetir("2.jpg");
                                ibcsayaci++;
                            }
                        }
                        else
                        {
                            if (tamdeger!=varilsayaci)
                            {
                                picture.Size = new Size(114, 114);
                                picture.Image = VarilGetir("004.jpg");
                                varilsayaci++;
                            }
                            else
                            {
                                if (kalan != 0)
                                {
                                    if (kalan != 4)
                                    {
                                        if (tamdeger == 0)
                                        {
                                            picture.Size = new Size(114, 114);
                                            if (kalan == 1)
                                            {
                                                picture.Image = VarilGetir("001.jpg");
                                                return;
                                            }
                                                
                                            else if (kalan == 2)
                                            {
                                                picture.Image = VarilGetir("002.jpg");
                                                return;
                                            }
                                               
                                            else if (kalan == 3)
                                            {
                                                picture.Image = VarilGetir("003.jpg");
                                                return;
                                            }
                                               
                                        }
                                        else
                                        {
                                            var oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                            picture.Size = new Size(114, 114);
                                            if (kalan == 1)
                                            {
                                                
                                                picture.Image = VarilGetir("002.jpg");
                                                oncekipicture.Image = VarilGetir("003.jpg");
                                                return ;
                                            }
                                            else if (kalan == 2)
                                            {
                                           
                                                oncekipicture.Image = VarilGetir("003.jpg");
                                                picture.Image = VarilGetir("003.jpg");
                                                return;
                                            }
                                            else if (kalan == 3)
                                            {
                                                picture.Image = VarilGetir("003.jpg");
                                                return;
                                            }
                                               
                                        }

                                    }
                                }
                            }
                          
                        }
                      
                    }

                    if (Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true).Count() != 0) // solda başka picturebox var ise
                    {
                        var pictureSol = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                        if (j == 2)
                        {
                            LocationX = LocationX + (pictureSol.Width + 1) + 15;//  picture.Location = new Point((j * (picture.Width + 3) + 19), 10 + (i * (picture.Height + 3)));
                        }

                        else //diğerleri 
                        {
                            LocationX = LocationX + (pictureSol.Width + 1) + 2;  //picture.Location = new Point((j * (picture.Width + 3) + 4), 10 + (i * (picture.Height + 3)));
                        }
                    }
                    if (Controls.Find("pictureBox" + (i - 1).ToString() + j.ToString(), true).Count() != 0) // yukarıda başka picturebox var ise
                    {

                        LocationY = 10;
                        for (int k = 0; k < i; k++)
                        {
                            var ustteki = (PictureBox)Controls.Find("pictureBox" + k.ToString() + j.ToString(), true)[0];
                            LocationY += ustteki.Height + 2;
                        }
                    }
                    picture.Location = new Point(LocationX, LocationY);
                }
            }
            
        }

        private void Picture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            DesenOlusturma desenform=new DesenOlusturma();
            desenform.ShowDialog();
           var dene= desenform.Secim;
            if (dene!=null)
            {
                dene.Konum = picture.Name.Substring(10);
                picture.Image = dene.Gorsel;
                picture.Size = new Size(dene.Genislik, dene.Yukseklik);
                DesenEkipman.Add(dene);
            }                   
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
                       
        }
        List<PictureBox> SeciliPictureboxlar()
        {
           return groupBox1.Controls.OfType<PictureBox>()
           .Where(x => x.Name.StartsWith("pictureBox") && (bool)x.Tag == true).ToList();
        }
        private void btnDesenKaydet_Click(object sender, EventArgs e)
        {
            //int width = groupBox1.Size.Width;
            //int height = groupBox1.Size.Height;
            //Bitmap bm = new Bitmap(width, height);
            //groupBox1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            //pictureBox1.Image = bm;
            DizilimYap(true);
            DesenEkipman.Clear();

        }
        int sayac = 0;
      
     
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //  ControlPaint.DrawBorder(e.Graphics, pictureBox01.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            // if (pictureBox01.CanSelect == true) { pictureBox01.Tag = Color.Red; } //Sets a default color            
            if ((bool)SeciliPicture.Tag==true)
            {
                ControlPaint.DrawBorder(e.Graphics, SeciliPicture.ClientRectangle, Color.Aqua, ButtonBorderStyle.Solid);              
            }
            else
            {                            
                ControlPaint.DrawBorder(e.Graphics, SeciliPicture.ClientRectangle, Color.Aqua, ButtonBorderStyle.None);                             
            }
           
        }

        private void DizilimMix_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                var Secili = SeciliPictureboxlar();
                for (int i = 0; i < Secili.Count(); i++)
                {
                 var picture= (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                    int X = picture.Location.X-3;
                    picture.Location = new Point(X, picture.Location.Y);
                }
            }
            else if (e.KeyCode==Keys.Right)
            {
                var Secili = SeciliPictureboxlar();
                for (int i = 0; i < Secili.Count(); i++)
                {
                    var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                    int X = picture.Location.X + 3;
                    picture.Location = new Point(X, picture.Location.Y);
                }
            }
            else if (e.KeyCode==Keys.Down)
            {
                var Secili = SeciliPictureboxlar();
                for (int i = 0; i < Secili.Count(); i++)
                {
                    var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                    int Y = picture.Location.Y + 3;
                    picture.Location = new Point(picture.Location.X, Y);
                }
            }
            else if (e.KeyCode==Keys.Up)
            {
                var Secili = SeciliPictureboxlar();
                for (int i = 0; i < Secili.Count(); i++)
                {
                    var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                    int Y = picture.Location.Y - 3;
                    picture.Location = new Point(picture.Location.X, Y);
                }
            }
        }

        private void DizilimMix_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                    picture.Tag = false;
                   // picture.Paint += pictureBox_Paint;
                   picture.Refresh();
                }
            }
        }

        private void btnDesenkaydet_Click_1(object sender, EventArgs e)
        {
            int width = groupBox1.Size.Width;
            int height = groupBox1.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            groupBox1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            pictureBox1.Image = bm;
            if (txtDesenAdi.Text != "")
            {
                bm.Save(Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Permütasyon Dataları\\" + txtDesenAdi.Text + ".jpg");
                MessageBox.Show(txtDesenAdi.Text + " Deseni Basarıyla Kaydedidli");
            }
                
            else
                MessageBox.Show("Desen Adi Boş Olamaz");
          
        }
    }
}
