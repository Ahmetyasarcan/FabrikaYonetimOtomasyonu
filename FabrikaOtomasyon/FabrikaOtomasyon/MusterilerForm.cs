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
    public partial class MusterilerForm : Form
    {
        public MusterilerForm()
        {
            InitializeComponent();
            VerileriYukle();
        }
        private void VerileriYukle()
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";
            //silinecek        string query = "SELECT MeyveAdi AS 'Meyve', Fiyat AS 'Fiyat (₺)', StokAdedi AS 'Stok Adedi' FROM Meyveler";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Musteriler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt; // GridControl'e bağlama
                baglanti.Close();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void MusterilerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
