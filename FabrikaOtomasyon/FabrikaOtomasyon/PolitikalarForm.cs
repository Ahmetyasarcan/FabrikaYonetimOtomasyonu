using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FabrikaOtomasyon
{
    public partial class PolitikalarForm : Form
    {
        public PolitikalarForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string chromeYolu = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            //string pdfYolu = @"C:\Users\ahmet\OneDrive\Masaüstü\Otomasyon\pdf\kâr_dagitim.pdf";

            string pdfUrl = "https://goknur.com.tr/public/images/politikalar/kar-dagitim.pdf";
            try
            {
              System.Diagnostics.Process.Start(pdfUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılamadı: " + ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string pdfUrl = "https://goknur.com.tr/public/images/politikalar/ucr-politikasi.pdf";

            try
            {
                System.Diagnostics.Process.Start(pdfUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılamadı: " + ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string pdfUrl = "https://goknur.com.tr/public/images/politikalar/bil_politikasi.pdf";
            

            try
            {
                System.Diagnostics.Process.Start(pdfUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılamadı: " + ex.Message);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string pdfUrl = "https://goknur.com.tr/public/images/politikalar/bagis-politikasi.pdf";

            try
            {
                System.Diagnostics.Process.Start(pdfUrl);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılamadı: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PolitikalarForm_Load(object sender, EventArgs e)
        {

        }
    }
}
