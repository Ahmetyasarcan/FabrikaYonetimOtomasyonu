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




namespace FabrikaOtomasyon
{
    public partial class SikayetForm : Form
    {
        private bool kvkkMetniGoster = false;
        public SikayetForm()
        {
            InitializeComponent();

            lblKvkkMetni.Cursor = Cursors.Hand;
            pnlKvkkMetni.Visible = false;
        }


        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SikayetForm_Load(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.png|PDF Dosyaları|*.pdf|Tüm Dosyalar|*.*";
            xtraOpenFileDialog1.InitialDirectory = @"C:\";
            xtraOpenFileDialog1.Title = "Bir Dosya Seçiniz";
            xtraOpenFileDialog1.FileName = "Dosya Seç";



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = xtraOpenFileDialog1.FileName;
            }
        }

        private void lblKvkkMetni_Click(object sender, EventArgs e)
        {
            kvkkMetniGoster = !kvkkMetniGoster; // Tıklanma durumunu tersine çevirir.
            pnlKvkkMetni.Visible = kvkkMetniGoster;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (!chkKvkk.Checked)
            {
                MessageBox.Show("Lütfen KVKK Aydınlatma Metni'ni onaylayın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //textEdit1.EditValue = null;
            //textEdit2.EditValue = null;
            //maskedTextBox1.Clear();
            //textBox1.Clear();
            //textBox2.Clear();
            //textBox3.Clear();
            //chkKvkk.Checked = false;

            // TextBox2'deki şikayeti al
            //string sikayetMetni = textBox2.Text;

            string my_mail = "ahmetyasarcan123@gmail.com";
            string my_other_mail = "230541077@firat.edu.tr"; // Şikayetlerin gideceği diğer mail
            string to = textBox1.Text.Trim();
            string feedbackSubject = "Göknur Gıda";
            string feedbackMessage = "İyi Günler. Ben Göknur Gıda'dan Ahmet Yaşarcan. Şikayetinizi aldım. En kısa sürede çözülmesi için gerekli çalışmalar başlamıştır. Bilginize sunarım. Göknurlu Günler Dilerim.";
            string sikayetMetni = textBox2.Text; // Kullanıcının şikayeti

            try
            {
                // SMTP ayarları
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(my_mail, "ltna yfsg wgvi dxdr"), // Şifre
                    EnableSsl = true
                };

                // Feedback maili müşteriye gönder
                MailMessage feedbackMail = new MailMessage
                {
                    From = new MailAddress(my_mail),
                    Subject = feedbackSubject,
                    Body = feedbackMessage,
                    IsBodyHtml = false
                };
                feedbackMail.To.Add(to);
                client.Send(feedbackMail);

                // Şikayeti kendine (diğer mail adresine) gönder
                MailMessage sikayetMail = new MailMessage
                {
                    From = new MailAddress(my_mail),
                    Subject = "Yeni Şikayet Geldi",
                    Body = $"Bir müşteri şikayeti aldınız.\n\nŞikayet Detayları:\n\n{textBox2.Text}\n\nGönderilen Müşteri: {to}",
                    IsBodyHtml = false
                };
                sikayetMail.To.Add(my_other_mail);
                client.Send(sikayetMail);

                MessageBox.Show("Geri dönüş sağlandı ve şikayetiniz kayıt altına alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
