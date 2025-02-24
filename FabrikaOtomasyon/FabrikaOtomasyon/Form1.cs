using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FabrikaOtomasyon
{
    public partial class AnaForm : Form
    {
        private string kullaniciTuru;

        // Kullanıcı türünü parametre olarak alıyoruz
        public AnaForm(string kullaniciTuru)
        {
            InitializeComponent();
            this.kullaniciTuru = kullaniciTuru;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Kullanıcı türüne göre butonların erişimini ayarla
            ButonErisimAyarla();
        }

        private void ButonErisimAyarla()
        {
            if (kullaniciTuru == "Müşteri")
            {
                // Müşteri giriş yaptıysa bu butonlara erişimi engelle
                CalisanlarButon.Enabled = false;
                FaturalarButon.Enabled = false;
            }
            else if (kullaniciTuru == "Yönetim Kurulu")
            {
                // Yönetim Kurulu her şeye erişebilir, hiçbir kısıtlama yok
                CalisanlarButon.Enabled = true;
                FaturalarButon.Enabled = true;
            }
            else if (kullaniciTuru == "Çalışan")
            {
                // Çalışan her şeye erişebilir
                CalisanlarButon.Enabled = true;
                FaturalarButon.Enabled = true;
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı türü!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FabrikalarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FabrikaForm frm = new FabrikaForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void YonetimButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string girisYapanRol = GirisForm.GirisYapanRol; // Rol bilgisini al
            YtKurulForm frm = new YtKurulForm(girisYapanRol); // Rol bilgisini forma gönder
            frm.MdiParent = this;
            frm.Show();
        }

        private void CalisanlarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CalisanlarForm frm = new CalisanlarForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MusterilerButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AlisverisForm frm = new AlisverisForm();
            frm.ShowDialog();
        }

        private void FaturalarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FaturalarForm frm = new FaturalarForm();
            frm.Show();
        }

        private void IletisimButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IletisimForm frm = new IletisimForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SikayetButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SikayetForm frm = new SikayetForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PolitikalarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PolitikalarForm frm = new PolitikalarForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UrunlerButon_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string girisYapanRol = GirisForm.GirisYapanRol;
            UrunlerForm frm = new UrunlerForm(girisYapanRol);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
