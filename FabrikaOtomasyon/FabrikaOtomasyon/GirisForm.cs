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
    public partial class GirisForm : Form
    {
        private int kalanHak = 3;
        public GirisForm()
        {
            InitializeComponent();
            this.AcceptButton = btnGiris;
        }
        string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

        private void btnSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            // şifreyi görünür yap
            txtSifre.PasswordChar = '\0'; // '\0' karakteri hiçbir şey göstermiyor (şifreyi görünür yapar)
        }

        private void btnSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            // şifreyi gizli yap
            txtSifre.PasswordChar = '*'; // şifreyi gizler
        }
        private bool KullaniciAdiVeSifreDogruMu(string kullaniciAdi, string sifre)
        {
            bool dogruMu = false;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    int sonuc = (int)cmd.ExecuteScalar();
                    if (sonuc > 0)
                    {
                        dogruMu = true;  // Kullanıcı adı ve şifre doğru
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dogruMu;
        }
        public static string GirisYapanRol;

        private void btnGiris_Click(object sender, EventArgs e)
        {


            string kullaniciAdi = txtKullaniciAdi.Text.Trim(); //kullanıcı adı
            string sifre = txtSifre.Text.Trim(); //şifre
            string secilenRol = comboBox1.SelectedItem?.ToString(); // Rolü null kontrolü ekliyoruz

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(secilenRol))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcı adı ve şifre doğrulama
            if (KullaniciAdiVeSifreDogruMu(kullaniciAdi, sifre))
            {
                GirisYapanRol = secilenRol;
                MessageBox.Show("Giriş Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();  // Giriş başarılıysa ana formu aç
                AnaForm frm = new AnaForm(secilenRol);
                frm.Show();
            }
            else
            {
                kalanHak--; // Hatalı girişte hak azaltılır
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                comboBox1.SelectedIndex = -1; // Rolü de temizliyoruz

                if (kalanHak > 0)
                {
                    MessageBox.Show($"Hatalı giriş! Kalan deneme hakkınız: {kalanHak}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("3 kez hatalı giriş yaptınız. Program kapanıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HesapOlusturForm frm = new HesapOlusturForm();
            frm.ShowDialog();
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUnutForm frm = new SifreUnutForm();
            frm.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string urlYolu = "https://www.goknur.com.tr/ckfinder/userfiles/files/goknuru-taniyalim-(1).pdf";

            System.Diagnostics.Process.Start(urlYolu);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string urlYolu = "https://www.goknur.com.tr/ckfinder/userfiles/files/goknuru-taniyalim-(1).pdf";

            System.Diagnostics.Process.Start(urlYolu);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }
            