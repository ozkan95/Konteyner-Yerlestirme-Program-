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
using Org.BouncyCastle.Asn1.Crmf;

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
        List<int>agirliklarList=new List<int>();
        List<Olculer> olculist = new List<Olculer>();
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                var Ibcsayi = txtIbc.Text==""?0: Convert.ToInt16(txtIbc.Text);
                var Varilsayi =txtVaril.Text==""?0: Convert.ToInt16(txtVaril.Text);
                               
                    var kalanVaril = Varilsayi % 4;
                    var tamdegerVaril = Varilsayi / 4;
                    var DesenList = IbcDizilim1(2, 1, new List<int>());
              
              
                if (Ibcsayi+tamdegerVaril+kalanVaril>20)                
                    MessageBox.Show("Yazdığınız değerler konteynıra sığmıyor", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else if (Ibcsayi > 18)
                {
                    MessageBox.Show("Yazdığınız değerler konteynıra sığmıyor", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    PictureShow();
                    pictureDispos();
                    olculist.Clear();
                    DizilimYap(false, Ibcsayi, Varilsayi);
                    // DizilimYapSirali(false, Ibcsayi, Varilsayi);
                    int deneme = groupBox1.Height / 2;
                    lblCizgiX.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y + (groupBox1.Height / 2));
                    lblCizgiY.Location = new Point(groupBox1.Location.X + (groupBox1.Width / 2) - 5, groupBox1.Location.Y);

                    lblBrut.Text = "Brüt Kilo: " + BrutKiloHesapla().ToString() + " KG";
                    lblNet.Text = "NET Kilo: " + NetKiloHesapla().ToString() + " KG";
                    // lblAgirlik.Location = AgirlikMerkeziHesapla();
                    //lblAgirlik.Parent = pictureBoxG;
                    pictureBoxG.Paint += pictureBoxG_Paint;
                    pictureBoxG.Refresh();
                    
                }
               

            }
            catch (Exception)
            {

                
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
     
        struct Olculer
        {
            public string Adi;
           public int LocationX;
          public  int LocationY;
           public int LocationOrtaX;
          public  int LocationOrtaY;
           public int Width;
          public  int Height;
          public  int Agirlik;
            public string Konum;
        }
        struct KonteynirAgirlik
        {
            public int UstToplam;
            public int AltToplam;
            public int AraToplam;
            public int SolToplam;
            public int SagToplam;
            public int ToplamAgirlik;
        }
        //Point AgirlikMerkeziHesapla()
        //{
        //    try
        //    {

        //        var OrtaX = new Point(pictureBoxG.Location.X, pictureBoxG.Location.Y + (pictureBoxG.Height / 2));
        //        var OrtaY = new Point(pictureBoxG.Location.X + (pictureBoxG.Width / 2), pictureBoxG.Location.Y);
        //       var Olculer = KonteynirToplamAgirlik();

        //        var UstG = new Point(/*pictureBoxG.Location.X+*/(pictureBoxG.Width / 2),/*pictureBoxG.Location.Y+*/(pictureBoxG.Height / 4)); 
        //        var AltG = new Point(/*pictureBoxG.Location.X + */(pictureBoxG.Width / 2), /*pictureBoxG.Location.Y +*/ (3 * pictureBoxG.Height / 4));

        //        var SolG = new Point(/*pictureBoxG.Location.X +*/ (pictureBoxG.Width / 4), /*pictureBoxG.Location.Y + */pictureBoxG.Height / 2);
        //        var SagG = new Point(/*pictureBoxG.Location.X +*/ (3 * pictureBoxG.Width / 4),/* pictureBoxG.Location.Y +*/ pictureBoxG.Height / 2);

        //        int toplamcarpilmisX =/* (Olculer.UstToplam * UstG.X) + (Olculer.AltToplam * AltG.X) +*/ (Olculer.SolToplam * SolG.X) + (Olculer.SagToplam * SagG.X);
        //        int toplamcarpilmisY = (Olculer.UstToplam * UstG.Y) + (Olculer.AltToplam * AltG.Y);// + (Olculer.SolToplam * SolG.Y) + (Olculer.SagToplam * SagG.Y);
        //        int LocationX = toplamcarpilmisX / Olculer.ToplamAgirlik;
        //        int LocationY = toplamcarpilmisY / Olculer.ToplamAgirlik;

                
        //        return new Point(LocationX, LocationY);
        //    }
        //    catch (Exception)
        //    {
        //        return new Point((pictureBoxG.Width / 2), (pictureBoxG.Height / 2));
        //    }
          
        //}
        int BrutKiloHesapla()
        {
            int toplamkilo = 0;
            for (int i = 0; i < olculist.Count; i++)
            {
                toplamkilo += olculist[i].Agirlik;
               
            }
            return toplamkilo;
        }
        int NetKiloHesapla()
        {
            int toplamkilo = 0;
            for (int i = 0; i < olculist.Count; i++)
            {
               
                if (olculist[i].Adi.Substring(0,3)=="IBC")
                {
                    toplamkilo += (olculist[i].Agirlik-65);
                }
                else
                {
                    toplamkilo += (olculist[i].Agirlik-30);
                }
               

            }
            return toplamkilo;
        }
       void KonteynirToplamAgirlik()
        {
            lblCizgiX.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y + (groupBox1.Height / 2));
            lblCizgiY.Location = new Point(groupBox1.Location.X + (groupBox1.Width / 2)-2, groupBox1.Location.Y);
            //int LocationX = groupBox1.Location.X + (groupBox1.Width / 2);
            //int LocationY = groupBox1.Location.Y + (groupBox1.Height / 2)-10;
            //int usttoplam = 0;
            //int aratoplam = 0;
            //int alttoplam = 0;
            //int soltoplam = 0;
            //int sagtoplam = 0;
            //int toplamagirlik = 0;
            
            
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //     var item= olculist.FirstOrDefault(k => k.Konum == i.ToString() + j.ToString());
            //        if (i<2)                    
            //            usttoplam += item.Agirlik;
                    
            //        else if (i==2)
            //        aratoplam+=item.Agirlik;
            //        else if (i>2)
            //        alttoplam+=item.Agirlik;

            //        if (j%2!=0) //sag kismin kilosu                   
            //            sagtoplam+=item.Agirlik;
                    
            //        else  // sol kısmın kilosu                   
            //            soltoplam+=item.Agirlik;

            //        toplamagirlik += item.Agirlik;

                 
            //    }
            //}

            for (int i = 0; i < olculist.Count; i++)
            {
                if (olculist[i].Konum[1] =='2') //sutun sayısı 1 den buyuk olunca
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + olculist[i].Konum[0]+"0", true)[0];
                    olculist[i] = new Olculer { Adi = olculist[i].Adi, Agirlik = olculist[i].Agirlik, Width = olculist[i].Width, Height = olculist[i].Height, Konum = olculist[i].Konum, LocationOrtaX = picture.Location.X + (olculist[i].Width / 2), LocationOrtaY = picture.Location.Y + (olculist[i].Height / 2) };//(picture.Location.X - groupBox1.Location.X) + (olculist[i].Width / 2);

                }
                else if(olculist[i].Konum[1] == '3')
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + olculist[i].Konum[0] + "1", true)[0];
                    olculist[i] = new Olculer { Adi = olculist[i].Adi, Agirlik = olculist[i].Agirlik, Width = olculist[i].Width, Height = olculist[i].Height, Konum = olculist[i].Konum, LocationOrtaX = picture.Location.X + (olculist[i].Width / 2), LocationOrtaY = picture.Location.Y + (olculist[i].Height / 2) };//(picture.Location.X - groupBox1.Location.X) + (olculist[i].Width / 2);

                }
                else
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + olculist[i].Konum, true)[0];

                    olculist[i] = new Olculer { Adi = olculist[i].Adi, Agirlik = olculist[i].Agirlik, Width = olculist[i].Width, Height = olculist[i].Height, Konum = olculist[i].Konum, LocationOrtaX = picture.Location.X + (olculist[i].Width / 2), LocationOrtaY = picture.Location.Y + (olculist[i].Height / 2) };//(picture.Location.X - groupBox1.Location.X) + (olculist[i].Width / 2);

                }

            }

            //for (int i = 0; i < 15; i++) // x ekseni ni hesaplamak için
            //{
            //    if (usttoplam > alttoplam + 210)
            //    {
            //        alttoplam = alttoplam + 150;
            //        usttoplam = usttoplam - 150;
            //        LocationY = LocationY - 6;
            //    }

            //  else  if (alttoplam > usttoplam + 210)
            //    {
            //        usttoplam = usttoplam + 150;
            //        alttoplam = alttoplam - 150;
            //        LocationY = LocationY + 6;
            //    }
            //    else
            //        break;
            //}
            //for (int i = 0; i < 15; i++)  // y ekseni ni hesaplamak için
            //{
            //    if (soltoplam > sagtoplam + 210)
            //    {
            //       sagtoplam = sagtoplam + 150;
            //        soltoplam = soltoplam - 150;
            //        LocationX = LocationX - 6;
            //    }

            //   else if (sagtoplam > soltoplam + 210)
            //    {
            //        soltoplam = soltoplam + 150;
            //        sagtoplam = sagtoplam - 150;
            //        LocationX = LocationX + 6;
            //    }
            //    else
            //        break;
            //}

          //  usttoplam = usttoplam + (aratoplam / 2);
          //  alttoplam = alttoplam + (aratoplam / 2);

            int toplamAgirlik = 0;
            int toplamcarpilmisAgirlikX = 0;
            int toplamcarpilmisAgirlikY = 0;
            for (int i = 0; i < olculist.Count; i++)
            {
                toplamAgirlik = toplamAgirlik + olculist[i].Agirlik;
                toplamcarpilmisAgirlikX = toplamcarpilmisAgirlikX + (olculist[i].Agirlik * olculist[i].LocationOrtaX);
                toplamcarpilmisAgirlikY = toplamcarpilmisAgirlikY + (olculist[i].Agirlik * olculist[i].LocationOrtaY);
            }
            toplamAgirlik = toplamAgirlik + 2040;
            toplamcarpilmisAgirlikX = toplamcarpilmisAgirlikX + (2040 * (pictureBoxG.Width / 2));
            toplamcarpilmisAgirlikY = toplamcarpilmisAgirlikY + (2040 *  (pictureBoxG.Height / 2));
            int x = toplamcarpilmisAgirlikX / toplamAgirlik;
            int y = toplamcarpilmisAgirlikY / toplamAgirlik;
            Nokta = new Point(x, y);
         //   return new KonteynirAgirlik { UstToplam = usttoplam, AltToplam = alttoplam, AraToplam = aratoplam, SolToplam = soltoplam, SagToplam = sagtoplam, ToplamAgirlik = toplamagirlik };
        }
        public Point Nokta;
        private void DizilimMix_Load(object sender, EventArgs e)
        {
            // picture.Size = new Size(114, 114);
            //if (Desen[i,j]==2)                    
            //    picture.Size = new Size(98, 118);
            //else
            //    picture.Size = new Size(118, 98);

            lblAgirlik.Parent = pictureBoxG;
            pictureBoxG.Image = new Bitmap(Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar\\Beyaz.jpg");
            txtVaril.Text=0.ToString();
            txtIbc.Text=0.ToString();
            groupBox1.Size = new Size(489, 595);
            groupBox1.BackColor = Color.White;
            pictureBoxG.Size = new Size(236, 595);
            lbl1.BackColor = Color.Red;
            lbl1.Width = 3;
            lbl1.Font=new Font(Label.DefaultFont, FontStyle.Bold);
            lbl1.Height = 596;
            lbl1.Location = new Point(238, 5);
            lbl2.Width = 3;
            lbl2.Font=new Font(Label.DefaultFont, FontStyle.Bold);
            lbl2.Height = 596;
            lbl2.Location = new Point(246, 5);
            lbl2.BackColor=Color.Red;
              DizilimYap();
         //   DizilimYapSirali();
            PictureDoubleClick();
            SeciliPicture = pictureBox00;
            checkAgirlik.Checked = true;
            if (checkAgirlik.Checked == false)
                lblAgirlik.Hide();

            lblCizgiX.Size = new Size(2*(pictureBoxG.Width + 7), 4);
            lblCizgiY.Size = new Size(4, pictureBoxG.Height + 2);
        
          
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
        void PictureShow()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                    picture.Show();
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
       
        void DizilimYapSirali(bool desendengetir = false, int ibcsayi = 20, int varilsayi = 0)
        {
            int[,] DesenIBCYatay = { {1,2,1,2,1 },{2,1,2,1,2 },{1,2,1,2,1 },{2,1,2,1,2 } };
            int[,] DesenIBCDikey = { { 2, 1, 2, 1 }, { 1, 2, 1, 2 }, { 2, 1, 2, 1 }, { 1, 2, 1, 2 }, { 2, 1, 2, 1 } };

          //  checkIBCdikey.Checked = true;
            int LocationX = 4;
            int ibcsayaci = 0;
            int varilsayaci = 0;
            var kalan = varilsayi % 4;
            var tamdeger = varilsayi / 4;
            int kalanvarmi = kalan == 0 ? 0 : 1;
            agirliklarList.Clear();

            for (int i = 0; i < 4; i++) //sutunlar
            {
                int LocationY = 10;

                for (int j = 0; j <5; j++) // satirlar
                {
                    var picture = (PictureBox)Controls.Find("pictureBox" + j.ToString() + i.ToString(), true)[0];
                    if (ibcsayi != ibcsayaci)
                    {
                        int[,] Desendizi = checkIBCdikey.Checked == true ? DesenIBCDikey : DesenIBCYatay;
                        if (Desendizi[i, j] == 2)
                        {
                            picture.Size = new Size(98, 118);
                            picture.Image = IbcGetir("2.jpg");
                            olculist.Add(new Olculer { Adi = "IBCDikey", Agirlik = 1000, Width = 98, Height = 118, Konum = i.ToString() + j.ToString() });
                            agirliklarList.Add(1000);
                            ibcsayaci++;
                        }
                        else
                        {
                            picture.Size = new Size(118, 98);
                            picture.Image = IbcGetir("1.jpg");
                            olculist.Add(new Olculer { Adi = "IBCYatay", Agirlik = 1000, Width = 118, Height = 98, Konum = i.ToString() + j.ToString() });
                            agirliklarList.Add(1000);
                            ibcsayaci++;
                        }
                    }
                    else
                    {
                        if (tamdeger != varilsayaci)
                        {
                            picture.Size = new Size(114, 114);
                            picture.Image = VarilGetir("004.jpg");
                            olculist.Add(new Olculer { Adi = "Palet4", Agirlik = 640, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                            agirliklarList.Add(640);
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
                                            agirliklarList.Add(160);
                                            olculist.Add(new Olculer { Adi = "Palet1", Agirlik = 160, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                            kalan = kalan - 2;

                                        }

                                        else if (kalan == 2)
                                        {
                                            picture.Image = VarilGetir("002.jpg");
                                            agirliklarList.Add(320);
                                            olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 320, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                            kalan = kalan - 3;

                                        }

                                        else if (kalan == 3)
                                        {
                                            picture.Image = VarilGetir("003.jpg");
                                            agirliklarList.Add(480);
                                            olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 480, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                            kalan = kalan - 4;

                                        }
                                        else
                                        {
                                            picture.Hide();
                                        }

                                    }
                                    else
                                    {

                                        picture.Size = new Size(114, 114);
                                        if (kalan == 1)
                                        {
                                            PictureBox oncekipicture;
                                            if (j == 0)
                                                oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + 3.ToString(), true)[0];
                                            else
                                                oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                            picture.Image = VarilGetir("002.jpg");

                                            olculist[olculist.Count - 1] = new Olculer { Adi = "Palet3", Agirlik = 480, Width = 114, Height = 114, Konum = olculist[olculist.Count - 1].Konum };
                                            olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 320, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                            agirliklarList[agirliklarList.Count - 1] = 480;
                                            agirliklarList.Add(320);
                                            oncekipicture.Image = VarilGetir("003.jpg");
                                            kalan = kalan - 2;
                                        }
                                        else if (kalan == 2)
                                        {
                                            PictureBox oncekipicture;
                                            if (j == 0)
                                                oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + 3.ToString(), true)[0];
                                            else
                                                oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                            oncekipicture.Image = VarilGetir("003.jpg");
                                            agirliklarList[agirliklarList.Count - 1] = 480;
                                            agirliklarList.Add(480);
                                            picture.Image = VarilGetir("003.jpg");
                                            kalan = kalan - 3;

                                        }
                                        else if (kalan == 3)
                                        {
                                            picture.Image = VarilGetir("003.jpg");
                                            olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 480, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                            agirliklarList.Add(480);
                                            kalan = kalan - 4;

                                        }
                                        else
                                        {
                                            picture.Hide();
                                        }

                                    }

                                }
                            }
                        }

                    }

                    //  var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                    //var pictureSol = (PictureBox)Controls.Find("pictureBox" + (i-1).ToString() + j .ToString(), true)[0];
                    if (i == 2)
                        {
                            // int genislik=(pictureSol.Width==98 && picture.Width==114) ? picture.Width : pictureSol.Width;
                            LocationX = 253; //groupBox1.Width - (LocationX+pictureSol.Width+3);//  picture.Location = new Point((j * (picture.Width + 3) + 19), 10 + (i * (picture.Height + 3)));
                        }
                        else if (i == 1)
                            LocationX = 238 - (picture.Width + 2);
                        else if (i == 3)
                        {
                                    LocationX = groupBox1.Width - picture.Width - 2;
                                    
                           // LocationX = LocationX + (pictureSol.Width) + 5; 
                        }
                    
                    if (Controls.Find("pictureBox" + i .ToString() + (j-1).ToString(), true).Count() != 0) // yukarıda başka picturebox var ise
                    {

                        LocationY = 10;
                        for (int k = 0; k < j; k++)
                        {
                            var ustteki = (PictureBox)Controls.Find("pictureBox" + k.ToString() + i.ToString(), true)[0];
                            LocationY += ustteki.Height + 2;
                        }
                    }
                    picture.Location = new Point(LocationX, LocationY);
                }           
            }
        }
        void DizilimYap(bool desendengetir= false,int ibcsayi= 20, int varilsayi = 0)
        {
            int[,] DesenIBCYatay = { {1,2,1,2},{2,1,2,1},{1,2,1,2},{2,1,2,1},{1,2,1,2} };
            int[,] DesenIBCDikey = { { 2,1,2,1}, { 1,2,1,2 }, { 2,1,2,1 }, { 1,2,1,2 }, { 2,1,2,1} };
           
            int LocationY = 10;
            int LocationX = 4;
            int ibcsayaci = 0;
            int varilsayaci = 0;
            var kalan = varilsayi % 4;
            var tamdeger = varilsayi / 4;
            int kalanvarmi = kalan == 0 ? 0 : 1;
           
            bool girdi = false;
            agirliklarList.Clear();
            //  olculist.Clear();
            for (int c = 0; c < 2; c++)
            {
             

                for (int i = 0; i < 5; i++) // satir
                {
                     LocationX = 4;

                    for (int j = 0; j < 4; j++) //sutun
                    {


                        var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                       
                        if (desendengetir)
                        {
                            // var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                            foreach (var item in DesenEkipman)
                            {
                                if (item.Konum == i.ToString() + j.ToString())
                                {

                                    picture.Size = new Size(item.Genislik, item.Yukseklik);
                                    picture.Image = item.Gorsel;
                                    agirliklarList.Add(item.agirlik);
                                    int index = olculist.FindIndex(k => k.Konum == i.ToString() + j.ToString());
                                    if (index == -1)
                                        olculist.Add(new Olculer { Adi = item.Adi, Agirlik = item.agirlik, Height = item.Yukseklik, Width = item.Genislik, LocationX = item.X, LocationY = item.Y, Konum = item.Konum });
                                    else
                                    olculist[index] = new Olculer { Adi = item.Adi, Agirlik = item.agirlik, Height = item.Yukseklik, Width = item.Genislik, LocationX = item.X, LocationY = item.Y, Konum = item.Konum };
                                    picture.Tag = false;
                                    break;
                                }
                            }
                        }
                       
                        else if ((ibcsayi + tamdeger + kalanvarmi) > 17 && c==0) //ıbc ve varil sayısı 1 katın alabileceğinden fazla ise
                        {
                            //  var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                            girdi = true;
                            if (ibcsayi != ibcsayaci)
                            {
                                int[,] Desendizi = checkIBCdikey.Checked == true ? DesenIBCDikey : DesenIBCYatay;
                                if (!(i == 4 && j > 1))
                                {

                                    if (Desendizi[i, j] == 2)
                                    {
                                        picture.Size = new Size(98, 118);
                                        picture.Image = IbcGetir("2.jpg");
                                        olculist.Add(new Olculer { Adi = "IBCDikey", Agirlik = 1165, Width = 98, Height = 118, Konum = i.ToString() + j.ToString() });
                                        agirliklarList.Add(1165);
                                        ibcsayaci++;

                                    }
                                    else
                                    {
                                        picture.Size = new Size(118, 98);
                                        picture.Image = IbcGetir("1.jpg");
                                        olculist.Add(new Olculer { Adi = "IBCYatay", Agirlik = 1165, Width = 118, Height = 98, Konum = i.ToString() + j.ToString() });
                                        agirliklarList.Add(1165);
                                        ibcsayaci++;

                                    }
                               
                                }
                                else
                                ibcsayaci++;

                                
                            }
                            else
                            {
                                if (tamdeger != varilsayaci)
                                {
                                    picture.Size = new Size(114, 114);
                                    picture.Image = VarilGetir("004.jpg");
                                    olculist.Add(new Olculer { Adi = "Palet4", Agirlik = 1018, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                    agirliklarList.Add(1018);
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
                                                    agirliklarList.Add(160);
                                                    olculist.Add(new Olculer { Adi = "Palet1", Agirlik = 277, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                    kalan = kalan - 2;

                                                }

                                                else if (kalan == 2)
                                                {
                                                    picture.Image = VarilGetir("002.jpg");
                                                    agirliklarList.Add(320);
                                                    olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 524, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                    kalan = kalan - 3;

                                                }

                                                else if (kalan == 3)
                                                {
                                                    picture.Image = VarilGetir("003.jpg");
                                                    agirliklarList.Add(480);
                                                    olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                    kalan = kalan - 4;

                                                }
                                                else
                                                {
                                                    picture.Hide();
                                                }

                                            }
                                            else
                                            {

                                                picture.Size = new Size(114, 114);
                                                if (kalan == 1)
                                                {
                                                    PictureBox oncekipicture;
                                                    if (j == 0)
                                                        oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + 3.ToString(), true)[0];
                                                    else
                                                        oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                                    picture.Image = VarilGetir("002.jpg");

                                                    olculist[olculist.Count - 1] = new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = olculist[olculist.Count - 1].Konum };
                                                    olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 524, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                    agirliklarList[agirliklarList.Count - 1] = 480;
                                                    agirliklarList.Add(320);
                                                    oncekipicture.Image = VarilGetir("003.jpg");
                                                    kalan = kalan - 2;
                                                }
                                                else if (kalan == 2)
                                                {
                                                    PictureBox oncekipicture;
                                                    if (j == 0)
                                                        oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + 3.ToString(), true)[0];
                                                    else
                                                        oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                                    oncekipicture.Image = VarilGetir("003.jpg");

                                                    olculist[olculist.Count - 1] = new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = olculist[olculist.Count - 1].Konum };
                                                    olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });

                                                    agirliklarList[agirliklarList.Count - 1] = 480;
                                                    agirliklarList.Add(480);
                                                    picture.Image = VarilGetir("003.jpg");
                                                    kalan = kalan - 3;

                                                }
                                                else if (kalan == 3)
                                                {
                                                    picture.Image = VarilGetir("003.jpg");
                                                    olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                    agirliklarList.Add(480);
                                                    kalan = kalan - 4;

                                                }
                                                else
                                                {
                                                    picture.Hide();
                                                }

                                            }

                                        }
                                    }
                                }

                            }
                           
                        }
                        else if(!girdi)// ıbc ve varil sayısı 1 katı doldurmuycak kadar az ise
                        {   bool ifade=false;
                            if(c==0 &&j<2)
                                ifade = true;
                            else if(c==1 && j>=2)
                                ifade = true;
                            if (ifade)
                            {

                                if (ibcsayi != ibcsayaci)
                                {

                                    int[,] Desendizi = checkIBCdikey.Checked == true ? DesenIBCDikey : DesenIBCYatay;
                                    if (Desendizi[i, j] == 2)
                                    {
                                        picture.Size = new Size(98, 118);
                                        picture.Image = IbcGetir("2.jpg");
                                        olculist.Add(new Olculer { Adi = "IBCDikey", Agirlik = 1165, Width = 98, Height = 118, Konum = i.ToString() + j.ToString() });
                                        agirliklarList.Add(1000);
                                        ibcsayaci++;
                                    }
                                    else
                                    {
                                        picture.Size = new Size(118, 98);
                                        picture.Image = IbcGetir("1.jpg");
                                        olculist.Add(new Olculer { Adi = "IBCYatay", Agirlik = 1165, Width = 118, Height = 98, Konum = i.ToString() + j.ToString() });
                                        agirliklarList.Add(1000);
                                        ibcsayaci++;
                                    }
                                }
                                else
                                {
                                    if (tamdeger != varilsayaci)
                                    {
                                        picture.Size = new Size(114, 114);
                                        picture.Image = VarilGetir("004.jpg");
                                        olculist.Add(new Olculer { Adi = "Palet4", Agirlik = 1018, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                        agirliklarList.Add(640);
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
                                                        olculist.Add(new Olculer { Adi = "Palet1", Agirlik = 277, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList.Add(160);
                                                        kalan = kalan - 2;

                                                    }

                                                    else if (kalan == 2)
                                                    {
                                                        picture.Image = VarilGetir("002.jpg");
                                                        olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 524, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList.Add(320);
                                                        kalan = kalan - 3;

                                                    }

                                                    else if (kalan == 3)
                                                    {
                                                        picture.Image = VarilGetir("003.jpg");
                                                        olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList.Add(480);
                                                        kalan = kalan - 4;

                                                    }
                                                    else
                                                    {
                                                       // picture.Hide();
                                                    }

                                                }
                                                else
                                                {
                                                    
                                                    picture.Size = new Size(114, 114);
                                                    if (kalan == 1)
                                                    {
                                                        PictureBox oncekipicture;
                                                        if (j == 0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + 1.ToString(), true)[0];
                                                        else if (j == 2&&i==0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (4-i).ToString() + (j - 1).ToString(), true)[0];
                                                        else if (j == 2 && i != 0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i-1).ToString() + (j+1).ToString(), true)[0];
                                                        else
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                                        picture.Image = VarilGetir("002.jpg");

                                                        olculist[olculist.Count - 1] = new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = olculist[olculist.Count - 1].Konum };
                                                        olculist.Add(new Olculer { Adi = "Palet2", Agirlik = 524, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList[agirliklarList.Count - 1] = 480;
                                                        agirliklarList.Add(320);
                                                        oncekipicture.Image = VarilGetir("003.jpg");
                                                        kalan = kalan - 2;
                                                    }
                                                    else if (kalan == 2)
                                                    {
                                                        PictureBox oncekipicture;
                                                        if (j == 0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i - 1).ToString() + (1).ToString(), true)[0];
                                                        else if (j == 2 && i != 0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (i-1).ToString() + (j+1).ToString(), true)[0];
                                                        else if(j==2 && i==0)
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + (4 - i).ToString() + (j-1).ToString(), true)[0];
                                                        else
                                                            oncekipicture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                                                        oncekipicture.Image = VarilGetir("003.jpg");

                                                        olculist[olculist.Count - 1] = new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = olculist[olculist.Count - 1].Konum };
                                                        olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList[agirliklarList.Count - 1] = 480;
                                                        agirliklarList.Add(480);
                                                        picture.Image = VarilGetir("003.jpg");
                                                        kalan = kalan - 3;

                                                    }
                                                    else if (kalan == 3)
                                                    {
                                                        picture.Image = VarilGetir("003.jpg");
                                                        olculist.Add(new Olculer { Adi = "Palet3", Agirlik = 771, Width = 114, Height = 114, Konum = i.ToString() + j.ToString() });
                                                        agirliklarList.Add(480);
                                                        kalan = kalan - 4;

                                                    }
                                                    else
                                                    {
                                                        picture.Hide();
                                                    }

                                                }

                                            }
                                        }
                                    }

                                }

                            }


                        }
                        if (Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true).Count() != 0) // solda başka picturebox var ise
                        {
                            //  var picture = (PictureBox)Controls.Find("pictureBox" + i.ToString() + j.ToString(), true)[0];
                            var pictureSol = (PictureBox)Controls.Find("pictureBox" + i.ToString() + (j - 1).ToString(), true)[0];
                            if (j == 2)
                            {
                                // int genislik=(pictureSol.Width==98 && picture.Width==114) ? picture.Width : pictureSol.Width;
                                LocationX = 253; //groupBox1.Width - (LocationX+pictureSol.Width+3);//  picture.Location = new Point((j * (picture.Width + 3) + 19), 10 + (i * (picture.Height + 3)));
                            }
                            else if (j == 3)
                                LocationX = groupBox1.Width - picture.Width - 2;
                            else if (j == 1)
                            {

                                LocationX = 238 - (picture.Width + 2);

                                // LocationX = LocationX + (pictureSol.Width) + 5; 
                            }
                        }
                        if (Controls.Find("pictureBox" + (i - 1).ToString() + j.ToString(), true).Count() != 0) // yukarıda başka picturebox var ise
                        {

                            LocationY = 10;
                            for (int l = 0; l < i; l++)
                            {
                                var ustteki = (PictureBox)Controls.Find("pictureBox" + l.ToString() + j.ToString(), true)[0];
                                LocationY += ustteki.Height + 2;
                            }
                        }
                        picture.Location = new Point(LocationX, LocationY);
                       
                    }
                }
                LocationX = 4;
                LocationY = 10;
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
            lblBrut.Text = "Brüt Kilo: " + BrutKiloHesapla().ToString() + " KG";
            lblNet.Text = "NET Kilo: " + NetKiloHesapla().ToString() + " KG";
            pictureBoxG.Paint += pictureBoxG_Paint;
            pictureBoxG.Refresh();




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
            else if (e.KeyCode == Keys.Delete)
            {
                var Secili = SeciliPictureboxlar();
                try
                {
                    for (int i = 0; i < Secili.Count(); i++)
                    {
                        var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                        
                        olculist.Remove(olculist[olculist.FindIndex(k => k.Konum == picture.Name.ToString().Substring(10))]);
                        picture.Hide();
                    }
                    lblBrut.Text = "Brüt Kilo: " + BrutKiloHesapla().ToString() + " KG";
                    lblNet.Text = "NET Kilo: " + NetKiloHesapla().ToString() + " KG";
                }
                catch (Exception)
                {

                    for (int i = 0; i < Secili.Count(); i++)
                    {
                        var picture = (PictureBox)Controls.Find(Secili[i].Name, true)[0];
                     
                        picture.Hide();
                    }
                    lblBrut.Text = "Brüt Kilo: " + BrutKiloHesapla().ToString() + " KG";
                    lblNet.Text = "NET Kilo: " + NetKiloHesapla().ToString() + " KG";
                }
               
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnHesapla.PerformClick();
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

        private void DizilimMix_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.X.ToString() + " Y: " + e.Y;
        }

        private void checkAgirlik_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAgirlik.Checked)
            {
                pictureBoxG.Show();
            }
            else
            {
                pictureBoxG.Hide();
            }
        }

        private void pictureBoxG_Paint(object sender, PaintEventArgs e)
        {
            //  e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
         KonteynirToplamAgirlik();
           

           e.Graphics.FillEllipse(new SolidBrush(Color.Red), Nokta.X-8,Nokta.Y-8 ,15, 15);
            e.Graphics.DrawLine(new Pen(Color.Blue, 3.0f), 0, (596 / 2) - 149, 250, (596 / 2) - 149);
            e.Graphics.DrawLine(new Pen(Color.Blue, 3.0f), 0, (596 / 2) +74, 250, (596 / 2) +74);
            // e.Graphics.DrawEllipse(new Pen(Color.Red,2f),100,100,5,5);
        }

        private void DizilimMix_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
