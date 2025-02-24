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
    public partial class FaturalarForm : Form
    {
        public FaturalarForm()
        {
            InitializeComponent();
            VerileriYukle();
                  
        }
        public void VerileriYukle()
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlCommand komut = new SqlCommand("select * from Faturalar order BY Tarih DESC", baglanti);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                tableLayoutPanel1.Controls.Clear(); // Eski kartları temizler

                // TableLayoutPanel'in kolon ve satır sayısını ayarlamak
                tableLayoutPanel1.RowCount = 0;  // Satır sayısını sıfırlayalım
                tableLayoutPanel1.ColumnCount = 3;  // 3 sütun olacak şekilde ayarlayalım
                tableLayoutPanel1.RowStyles.Clear(); // Satır stilini temizleyelim
                tableLayoutPanel1.ColumnStyles.Clear(); // Sütun stilini temizleyelim

                // Hücre boyutlarını ayarlayalım
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // 3 sütun, her biri %33 genişliğinde
                }

                // Verileri eklerken her satır için yeni bir satır ekleyelim
                int row = 0;
                int column = 0;

                while (okuyucu.Read())
                {
                    Panel kart = new Panel
                    {
                        Size = new Size(250, 150), // Kart boyutunu belirle
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10),
                        BackColor = Color.LightBlue // Arka plan rengini belirle
                    };

                    Label faturaNoLabel = new Label
                    {
                        Text = "Fatura No: " + okuyucu["FaturaID"].ToString(),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    Label musteriAdiLabel = new Label
                    {
                        Text = "Müşteri Adı: " + okuyucu["MusteriAdi"].ToString(),
                        Location = new Point(10, 40),
                        AutoSize = true
                    };

                    Label toplamFiyatLabel = new Label
                    {
                        Text = "Toplam Fiyat: " + okuyucu["ToplamFiyat"].ToString() + " TL",
                        Location = new Point(10, 70),
                        AutoSize = true
                    };

                    Label tarihLabel = new Label
                    {
                        Text = "Tarih: " + Convert.ToDateTime(okuyucu["Tarih"]).ToString("dd.MM.yyyy HH:mm"),
                        Location = new Point(10, 100),
                        AutoSize = true
                    };

                    // Kartın içine yazma
                    kart.Controls.Add(faturaNoLabel);
                    kart.Controls.Add(musteriAdiLabel);
                    kart.Controls.Add(toplamFiyatLabel);
                    kart.Controls.Add(tarihLabel);

                    // TableLayoutPanel'a kartı ekleme
                    tableLayoutPanel1.Controls.Add(kart, column, row); // Satır ve sütun belirleyerek ekle

                    column++;
                    if (column > 2) // 3 sütun olduğunda, yeni satıra geç
                    {
                        column = 0;
                        row++;
                    }
                }

                okuyucu.Close();
                baglanti.Close();
            }
        }

        
    private void FaturalarForm_Load(object sender, EventArgs e)
        {

        }

      

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
