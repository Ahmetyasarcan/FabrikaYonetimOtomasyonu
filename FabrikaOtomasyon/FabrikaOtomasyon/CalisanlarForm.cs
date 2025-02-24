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
    public partial class CalisanlarForm : Form
    {
        public CalisanlarForm()
        {
            InitializeComponent();
            VerileriYukle();
        }
       // string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True");

        private void VerileriYukle()
        {
            
            //silinecek string query = "SELECT MeyveAdi AS 'Meyve', Fiyat AS 'Fiyat (₺)', StokAdedi AS 'Stok Adedi' FROM Meyveler";
            
                SqlDataAdapter da = new SqlDataAdapter("select * from Calisanlar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt; // GridControl'e bağlama
                baglanti.Close();
            
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PersonelGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Calisanlar(CalisanIsim,CalisanSoyisim,CalisanPozisyon,CalisanMaas) values(@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            VerileriYukle();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("UPDATE Calisanlar SET  CalisanPozisyon = @p3, CalisanMaas = @p4 WHERE CalisanID = @id", baglanti);
           // komut.Parameters.AddWithValue("@p1", textBox1.Text);
          //  komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox6.Text);
            komut.Parameters.AddWithValue("@p4", textBox7.Text);
            komut.Parameters.AddWithValue("@id", textBox5.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            VerileriYukle();

            textBox6.Clear();
            textBox7.Clear();
            textBox5.Clear();
            

        }

        private void CalisanlarForm_Load(object sender, EventArgs e)
        {

        }
    }
}
