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
    public partial class UrunlerForm : Form
    {
        public string kullaniciRol;
        public UrunlerForm(string rol)
        {
            InitializeComponent();
            kullaniciRol = rol;
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Urunler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt; // GridControl'e bağlama
                baglanti.Close();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";
            string query = "UPDATE Urunler SET UrunStokMiktari = UrunStokMiktari + @UrunStokMiktari WHERE UrunIsim = @UrunIsim";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@UrunIsim", comboBox1.Text); // Seçilen meyve ismi
                komut.Parameters.AddWithValue("@UrunStokMiktari", Convert.ToInt32(txtMiktar.Text)); // Eklemek istenen miktar

                baglanti.Open();
                komut.ExecuteNonQuery();
            }

            MessageBox.Show("Stok başarıyla güncellendi!");
            VerileriYukle(); // GridControl'ü güncelle

            txtMiktar.Clear();
            


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ÖzelÜretimForm özelform = new ÖzelÜretimForm();
            özelform.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UrunGelistirmeForm urunGelForm = new UrunGelistirmeForm();
            urunGelForm.ShowDialog();
        }

        private void UrunlerForm_Load(object sender, EventArgs e)
        {
            if (kullaniciRol == "Müşteri")
            {
                btnGuncelle.Enabled = false; // Buton tıklanamaz hale geliyor
            }
            this.AcceptButton = btnGuncelle;
        }
    }
}