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
    public partial class AlisverisForm : Form
    {
        public AlisverisForm()
        {
            InitializeComponent();
            VerileriGetir();
        }

        string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

        public class Urun
        {
            public int urunID { get; set; }
            public string UrunIsim { get; set; }
            public decimal UrunFiyat { get; set; }

          

        }
        public decimal ToplamFiyat // Toplam fiyatı döndüren bir property
        {
            get
            {
                decimal toplam = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    toplam += Convert.ToDecimal(row.Cells["UrunFiyat"].Value);
                }
                return toplam;
             }
        }

        private List<Urun> urunListesi = new List<Urun>(); // Ürün listesini saklamak için
        private decimal toplamFiyat = 0; // Sepetteki toplam fiyat

        private void VerileriGetir()
        {
            string query = "SELECT * FROM GuncelUrunler";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) // UrunID için kontrol
                        {
                            Urun yeniUrun = new Urun
                            {
                                urunID = (int)reader["urunID"],
                                UrunIsim = reader["UrunAd"]?.ToString(),
                                UrunFiyat = (decimal)reader["UrunFiyat"]
                            };

                            urunListesi.Add(yeniUrun);  // Ürünü listeye ekle
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int urunID = 1; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown1.Value; // Seçilen miktar

            // Ürün ID'sine göre ürün bilgilerini bul
            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private bool StokKontrol(int urunID, int miktar)
        {
            string query = "SELECT StokMiktari FROM GuncelUrunler WHERE urunID = @urunID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@urunID", urunID);

                try
                {
                    connection.Open();
                    int stok = (int)command.ExecuteScalar();
                    return stok >= miktar;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    return false;
                }
            }
        }

        private void StokGuncelle(int urunID, int miktar)
        {
            string query = "UPDATE GuncelUrunler SET StokMiktari = StokMiktari - @miktar WHERE urunID = @urunID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@miktar", miktar);
                command.Parameters.AddWithValue("@urunID", urunID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Form yüklendiğinde DataGridView ve toplam fiyat label'ını ayarla
        private void AlisverisForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear(); // Kolonları temizle
            dataGridView1.Columns.Add("UrunAdi", "Ürün Adı");
            dataGridView1.Columns.Add("Adet", "Adet");
            dataGridView1.Columns.Add("ToplamFiyat", "Toplam Fiyat");

            lblToplamFiyat.Text = "Toplam Fiyat: 0.00 TL"; // Başlangıçta toplam fiyat 0
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int urunID = 2; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown2.Value; // Seçilen miktar

            // Ürün ID'sine göre ürün bilgilerini bul
            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int urunID = 3; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown3.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int urunID = 4; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown4.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            int urunID = 5; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown5.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            int urunID = 6; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown6.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            int urunID = 7; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown7.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            int urunID = 8; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown8.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            int urunID = 9; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown9.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            int urunID = 10; // Seçili ürünün ID'si
            int miktar = (int)numericUpDown10.Value; // Seçilen miktar

            Urun secilenUrun = urunListesi.FirstOrDefault(u => u.urunID == urunID);

            // Eğer miktar 0 ise hata ver ve işlemi durdur
            if (miktar == 0)
            {
                MessageBox.Show("Lütfen Ürün Adedini Seçiniz!");
                return; // Kodun devam etmesini engelle
            }

            if (secilenUrun != null)
            {
                if (StokKontrol(secilenUrun.urunID, miktar))
                {
                    StokGuncelle(secilenUrun.urunID, miktar);
                    MessageBox.Show("Ürün başarıyla sepete eklendi!");

                    // Ürünün toplam fiyatını hesapla
                    decimal toplamUrunFiyati = secilenUrun.UrunFiyat * miktar;

                    // DataGridView'e yeni satır ekle
                    dataGridView1.Rows.Add(secilenUrun.UrunIsim, miktar, toplamUrunFiyati.ToString("C2"));

                    // Sepetteki toplam fiyatı güncelle
                    toplamFiyat += toplamUrunFiyati;
                    lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Stokta yeterli ürün yok!");
                }
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSepetiOnayla_Click(object sender, EventArgs e)
        {

            if (toplamFiyat > 0) // toplamTutar, sepetteki ürünlerin toplam fiyatı
            {
                DialogResult result = MessageBox.Show(
                    "Sepetinizdeki ürünleri onaylıyor musunuz?", // Mesaj
                    "Onay",  // Başlık
                    MessageBoxButtons.YesNo, // Evet ve Hayır butonları
                    MessageBoxIcon.Question); // Soru ikonu

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Sepet onaylandı! Ödeme ekranına yönlendiriliyorsunuz.", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ödeme ekranına geçiş
                    OdemeForm odemeform = new OdemeForm(toplamFiyat);
                    odemeform.ShowDialog();
                    this.Close(); // Ana formu kapat
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Alışverişe devam ediyorsunuz.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Alışverişe devam etme işlemi (Sepet sayfasını temizlemek veya başka bir işlem yapabilirsiniz)
                }
            }
            else
            {
                MessageBox.Show("Sepetiniz boş! Önce ürün ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }

        private void lblToplamFiyat_Click(object sender, EventArgs e)
        {

        }
    }


}
