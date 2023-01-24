using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Konteyner_Yerlestirme_Programı
{
    public partial class Musteri_Bilgisi : Form
    {

        public Musteri_Bilgisi()
        {
            InitializeComponent();
        }
        static string conString = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\Baglanti.txt");
        SqlConnection con = new SqlConnection(conString);
        SqlTransaction tran = null;
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        SqlDataReader reader2;
        BaseFont arial1 = BaseFont.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ekran = new Form1();
            ekran.ShowDialog();
        }

        private void btnTasarımGöster_Click(object sender, EventArgs e)
        {
            Form1 ekran = new Form1();
            ekran.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Musteri_Bilgisi_Load(object sender, EventArgs e)
        {
              
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "PDF Dosyası(*.pdf)| *.pdf";
            file.Title = "PDF Dosyası Oluşturma";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileStream dosya = File.Open(file.FileName, FileMode.Create);
                Document pdf = new Document();
                PdfWriter.GetInstance(pdf, dosya);
                pdf.Open();
                pdf.AddAuthor("Özkan Aydoğan");
                pdf.AddCreator("Deneme");
                pdf.AddTitle("PDF DOSYASI İŞLEMLERİ");
                pdf.AddSubject("KONU");
                pdf.AddKeywords("DİZİLİM PDF OLUŞTURMA");
                pdf.AddCreationDate();
                Paragraph paragraph = new Paragraph(txtUyarı.Text);
                pdf.Add(paragraph);
                pdf.Close();
                MessageBox.Show("PDF OLUŞTURULDU");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ürün_Tasarimlari ürün = new Ürün_Tasarimlari ();
            ürün.ShowDialog();
        }
    }
}
