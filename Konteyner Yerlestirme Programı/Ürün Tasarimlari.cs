using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konteyner_Yerlestirme_Programı
{
    public partial class Ürün_Tasarimlari : Form
    {
        public Ürün_Tasarimlari()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dizilim = new Form1();
            dizilim.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DizilimEkraniIBC dizilimEkraniIBC = new DizilimEkraniIBC();
            dizilimEkraniIBC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DizilimMix mix = new DizilimMix();
            mix.Show();
        }
    }
}
