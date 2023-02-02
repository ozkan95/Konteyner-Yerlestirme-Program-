using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Konteyner_Yerlestirme_Programı
{
   public class Helper
    {
        public static int IlkKatBaslangic = 35;
        public static int IlkKatBitis = 1420;
        public static int KatlararasiBosluk = 110;
        public static int IkinciKatBaslangic = 1525;
        public static int IkinciKatBitis = 2895;


        public Bitmap IBCGetir(string ibc)
        {
            try
            {
                string filename = Application.StartupPath + "\\Konteyner Yerleştirme Projesi\\Tasarimlar";
                Bitmap IBC = new Bitmap(filename + "\\ıbc" + ibc);
                return IBC;
            }
            catch (Exception e)
            {
                return null;
                MessageBox.Show(e.ToString());
            }

        }

    }
}
