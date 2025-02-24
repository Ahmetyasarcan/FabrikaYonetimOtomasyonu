using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO; // PDF dosyasını kaydetmek için gerekli
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;







namespace FabrikaOtomasyon
{
    public partial class OdemeForm : Form
    {
        public OdemeForm()
        {
            InitializeComponent();
        }
        decimal fiyat;
        


        
        public OdemeForm(decimal toplamFiyat)
        {
            InitializeComponent();
            fiyat = toplamFiyat;
            

        }
        
        private AlisverisForm alisverisForm;

        public OdemeForm(AlisverisForm form)
        {
            InitializeComponent();
            alisverisForm = form;
        }

      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kod Gönderildi.");
        }
          
        private void OdemeForm_Load(object sender, EventArgs e)
        {
            if (alisverisForm != null)
            {
                decimal toplamFiyat = alisverisForm.ToplamFiyat; // FormA'dan fiyat al
                labelOdemeFormFiyat.Text = toplamFiyat.ToString("C"); // Formatlı fiyatı yazdır
            }
            else
            {
              
            }
        }


        //public void EpostaGonder(string faturaNo, string emailAdres)
        //{
        //    string my_mail = "ahmetyasarcan123@gmail.com";
        //    string to = textBox2.Text.Trim(); // Kullanıcının girdiği e-posta adresi
        //  //  string subject = "Göknur Gıda - Faturanız";
        //       string message = "Sayın müşterimiz,\n\nÖdeme işleminiz başarıyla tamamlanmıştır.\n\nTeşekkür ederiz!";
        //  //  string dosyaYolu = @"C:\Users\ahmet\OneDrive\Masaüstü\Otomasyon\Faturalar";

        //    // E-posta gönderme ayarları
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("your_email@example.com");
        //    mail.To.Add(emailAdres);  // Alıcı e-posta adresi
        //    mail.Subject = "Fatura - " + faturaNo;
        //    mail.Body = message;

        //    // PDF dosyasını eklenti olarak ekleyin
        //   // Attachment attachment = new Attachment(dosyaYolu);
        //    //mail.Attachments.Add(attachment);

        //    // SMTP istemcisi ayarları (Gmail örneği)
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        Credentials = new System.Net.NetworkCredential(my_mail, "ltna yfsg wgvi dxdr"), // Mail şifren
        //        EnableSsl = true
        //    };

        //    smtp.Send(mail); // E-postayı gönder
        //}


        // Veritabanına faturayı kaydetme metodu
        public void FaturaKaydet()
        {
            string connectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=FabrikaOtomasyonu;Integrated Security=True"; // Veritabanı bağlantı string'i

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Faturalar (MusteriAdi, ToplamFiyat, Tarih) VALUES (@MusteriAdi, @ToplamFiyat, @Tarih)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MusteriAdi", textEdit1.Text); // Müşteri adı
                cmd.Parameters.AddWithValue("@ToplamFiyat", fiyat); // Toplam fiyat (fiyat değişkenini kontrol edin)
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now); // Fatura tarihi

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Fatura oluşturma metodu
        public static void FaturaOlustur(string pdfPath, DataGridView dataGridView1)
        {
            // Fatura PDF belgesi oluştur
            iTextSharp.text.Document fatura = new iTextSharp.text.Document();

            // Dosya yolunu kontrol edin ve PDF yazıcısını oluşturun
            if (!Directory.Exists(Path.GetDirectoryName(pdfPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
            }

            PdfWriter.GetInstance(fatura, new FileStream(pdfPath, FileMode.Create));

            // Meta bilgiler ekleyin
            fatura.AddAuthor("Ahmet Yaşarcan");
            fatura.AddCreationDate();
            fatura.AddSubject("Göknur Gıda Faturası");

            // Fatura içeriği ekle
            fatura.Open();

            // Türkçe karakter desteği için font oluştur
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf"); // Arial font
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            // Fatura başlık bilgileri
            fatura.Add(new iTextSharp.text.Paragraph("Göknur Gıda Faturası", font));
            fatura.Add(new iTextSharp.text.Paragraph($"Fatura Tarihi: {DateTime.Now:dd/MM/yyyy}", font));
            fatura.Add(new iTextSharp.text.Paragraph("Sipariş Detayları:", font));
            fatura.Add(new iTextSharp.text.Paragraph("\n"));

            // DataGridView içeriğini PDF'e tablo olarak yazdır
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count); // Sütun sayısı
            table.WidthPercentage = 100; // Tablo genişliği

            // Tablo başlıklarını ekle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText, font));
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(headerCell);
            }

            // Tablo içeriğini ekle
            foreach (DataGridViewRow row in dataGridView1.Rows)
{
    if (row.IsNewRow) continue; // Yeni satır ekleme işlemlerini atla
    foreach (DataGridViewCell cell in row.Cells)
    {
        string cellValue = cell?.Value?.ToString() ?? "Boş"; // Hücre boş ise "Boş" yaz
        PdfPCell cellData = new PdfPCell(new Phrase(cellValue, font));
        cellData.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cellData);
    }
}

            // Tabloyu PDF'e ekle
            fatura.Add(table);

            // Fatura belgesini kapat
            fatura.Close();
        }



        // Faturayı e-posta ile gönderme metodu
        private void SendInvoiceEmail(string myMail, string appPassword, string to, string subject, string body, string pdfPath)
        {
            try
            {
                // SMTP ayarları
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(myMail, appPassword),
                    EnableSsl = true
                };

                // Mail ayarları
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(myMail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mail.To.Add(to);

                // Fatura PDF'sini maile ekle
                if (File.Exists(pdfPath))
                {
                    Attachment pdfAttachment = new Attachment(pdfPath);
                    mail.Attachments.Add(pdfAttachment);
                }
                else
                {
                    throw new FileNotFoundException("Fatura dosyası bulunamadı.");
                }

                // Mail gönderimi
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception($"Mail gönderim hatası: {ex.Message}");
            }
        }

        // Ödeme ekranındaki butona tıklama olayı
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            string pdfPath = @"C:\Users\ahmet\OneDrive\Masaüstü\Otomasyon\Faturalar\Fatura.pdf"; // PDF dosyasının yolu
            DataGridView dgv = ((AlisverisForm)Application.OpenForms["AlisverisForm"]).dataGridView1; // AlisverisForm'daki DataGridView'i al

            FaturaOlustur(pdfPath, dgv);
            string enteredCode = txtVerificationCode.Text;

            // Doğrulama kodu kontrolü
            if (enteredCode == "123456")
            {
                try
                {
                    // Veritabanına faturayı kaydet
                    FaturaKaydet();

                    // Fatura PDF dosyasını oluştur
                    FaturaOlustur(pdfPath, dgv);
                    
                    // E-posta bilgileri
                    string myMail = "ahmetyasarcan123@gmail.com";
                    string appPassword = "ltna yfsg wgvi dxdr"; // Uygulama şifresi
                    string to = textBox2.Text.Trim(); // Kullanıcının girdiği e-posta adresi
                    string subject = "Göknur Gıda - Faturanız";
                    string message = "Sayın müşterimiz,\n\nÖdeme işleminiz başarıyla tamamlanmıştır. Faturanızı ekte bulabilirsiniz.\n\nTeşekkür ederiz!";

                    // Faturayı e-posta ile gönder
                    SendInvoiceEmail(myMail, appPassword, to, subject, message, pdfPath);

                    MessageBox.Show("Kod doğrulandı! Faturanız e-posta adresinize gönderildi.\nAfiyetler dileriz!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Geçersiz kod!");
            }
        }


        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
