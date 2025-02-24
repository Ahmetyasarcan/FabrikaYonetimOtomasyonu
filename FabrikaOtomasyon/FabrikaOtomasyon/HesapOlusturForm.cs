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
    public partial class HesapOlusturForm : Form
    {
        public HesapOlusturForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True");
        string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

        private bool KullaniciAdiVarMi(string kullaniciAdi)
        {
            bool varMi = false;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                    int sonuc = (int)cmd.ExecuteScalar();

                    if (sonuc > 0)
                    {
                        varMi = true;  // Kullanıcı adı zaten var
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return varMi;
        }

      
        private void KullaniciEkle(string kullaniciAdi, string sifre, string adSoyad, string gMail, string telefonNo, string rol)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    string query = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, AdSoyad, GMail, TelefonNo, Rol) " +
                                   "VALUES (@KullaniciAdi, @Sifre, @AdSoyad, @GMail, @TelefonNo, @Rol)" +
                                   "SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);
                    cmd.Parameters.AddWithValue("@AdSoyad", adSoyad);
                    cmd.Parameters.AddWithValue("@GMail", gMail);
                    cmd.Parameters.AddWithValue("@TelefonNo", telefonNo);
                    cmd.Parameters.AddWithValue("@Rol", rol);

                    cmd.ExecuteNonQuery();

                    int kullaniciID = Convert.ToInt32(cmd.ExecuteScalar());

                    // Rol'e göre Musteriler veya Calisanlar tablosuna ekleme
                    if (rol == "Müşteri")
                    {
                        string musteriQuery = "INSERT INTO Musteriler (MusteriID, MusteriAdSoyad, MusteriGMail, MusteriTelefon) " +
                                              "VALUES (@MusteriID, @MusteriAdSoyad, @MusteriGMail, @MusteriTelefon)";

                        SqlCommand musteriCmd = new SqlCommand(musteriQuery, baglanti);
                        musteriCmd.Parameters.AddWithValue("@MusteriID", kullaniciID);
                        musteriCmd.Parameters.AddWithValue("@MusteriAdSoyad", adSoyad);
                        musteriCmd.Parameters.AddWithValue("@MusteriGMail", gMail);
                        musteriCmd.Parameters.AddWithValue("@MusteriTelefon", telefonNo);
                        musteriCmd.ExecuteNonQuery();
                    }
                   

                    MessageBox.Show("Hesap başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Hesap oluşturulunca formu kapat
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HesapOlusturForm_Load(object sender, EventArgs e)
        {

        }

        private void btnHesapOlustur_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;  // Kullanıcı adı textbox'ından
            string sifre = txtSifre.Text;  // Şifre textbox'ından
            string adSoyad = txtAdSoyad.Text;  // Ad Soyad textbox'ından
            string gMail = txtGmail.Text;  // GMail textbox'ından
            string telefonNo = maskedTxtTlfNo.Text;  // Telefon No textbox'ından
            string rol = cmbRol.SelectedItem.ToString();  // Rol combobox'ından

            // Kullanıcı adı zaten varsa, hata mesajı göster
            if (KullaniciAdiVarMi(kullaniciAdi))
            {
                MessageBox.Show("Bu kullanıcı adı zaten mevcut. Lütfen başka bir kullanıcı adı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kullanıcı adı mevcut değilse, yeni kullanıcıyı ekle
                KullaniciEkle(kullaniciAdi, sifre, adSoyad, gMail, telefonNo, rol);
            }


        }
    }
}
