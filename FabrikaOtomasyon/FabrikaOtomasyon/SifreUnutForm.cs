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
    public partial class SifreUnutForm : Form
    {
        public SifreUnutForm()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

        private void SifreUnutForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnOnayla;
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string adSoyad = txtAdSoyad.Text;
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            // Şifrelerin eşleşip eşleşmediğini kontrol et
            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Girilen şifreler eşleşmiyor!");
                return;
            }

            // Kullanıcı adı ve ad soyad bilgilerine göre veritabanını sorgula
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND AdSoyad = @AdSoyad";
                    using (SqlCommand cmd = new SqlCommand(query, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@AdSoyad", adSoyad);
                        using (SqlDataReader reader = cmd.ExecuteReader())  // DataReader'ı using ile kullanıyoruz
                        {
                            if (reader.HasRows)
                            {
                                // Kullanıcı adı ve ad soyad eşleşti, şifreyi güncelle
                                reader.Close(); // DataReader'ı kapat
                                string updateQuery = "UPDATE Kullanicilar SET Sifre = @YeniSifre WHERE KullaniciAdi = @KullaniciAdi";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, baglanti))
                                {
                                    updateCmd.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                                    updateCmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                                    updateCmd.ExecuteNonQuery();
                                    MessageBox.Show("Şifreniz başarıyla güncellendi.");
                                    this.Close();  // Formu kapat
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya ad soyad hatalı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
    }
