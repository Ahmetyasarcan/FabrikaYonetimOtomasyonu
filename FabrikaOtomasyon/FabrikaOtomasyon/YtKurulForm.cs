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
    public partial class YtKurulForm : Form
    {
        private string kullaniciRol; // Kullanıcı rolünü saklamak için bir değişken

        public YtKurulForm(string rol)
        {
            InitializeComponent();
            kullaniciRol = rol; // Rol bilgisini al
            VerileriYukle();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True");

        private void VerileriYukle()
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from YonetimKurulu", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt; // GridControl'e bağlama
                baglanti.Close();
            }
        }

        private void YtKurulForm_Load(object sender, EventArgs e)
        {
            // Eğer müşteri ise, simpleButton1'i devre dışı bırak
            if (kullaniciRol == "Müşteri")
            {
                simpleButton1.Enabled = false; // Buton tıklanamaz hale geliyor
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into YonetimKurulu(YKIsim,YKSoyisim,YKPozisyon,HisseYüzdesi) values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            baglanti.Close();
            VerileriYukle();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            // GridControl işlemleri burada yapılabilir
        }
    }
}
