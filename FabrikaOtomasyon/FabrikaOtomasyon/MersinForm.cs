using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace FabrikaOtomasyon
{
    public partial class MersinForm : Form
    {
        public MersinForm()
        {
            InitializeComponent();

            gMapControl1.DragButton = MouseButtons.Left; // Harita kaydırma için mouse butonu
            gMapControl1.CanDragMap = true; // Harita sürüklenebilir olsun
            gMapControl1.MapProvider = GMapProviders.GoogleMap; // Google Harita Sağlayıcısı
            gMapControl1.Position = new PointLatLng(36.81025554533245, 34.67011029583195); // Merkez konumu (örnek: İstanbul)
            gMapControl1.MinZoom = 2; // Minimum zoom seviyesi
            gMapControl1.MaxZoom = 18; // Maksimum zoom seviyesi
            gMapControl1.Zoom = 12; // Başlangıç zoom seviyesi
            gMapControl1.AutoScroll = true;

            // Marker (İşaretçi) ekleme
            GMapOverlay markers = new GMapOverlay("markers"); // Yeni bir overlay oluştur
            GMapMarker centrumMarker = new GMarkerGoogle(
                new PointLatLng(36.81025554533245, 34.67011029583195), // Merkezin koordinatları
                GMarkerGoogleType.red_dot); // Marker tipi: kırmızı nokta

            centrumMarker.ToolTipText = "Mersin Fabrika"; // Marker üzerine metin ekleme
            centrumMarker.ToolTipMode = MarkerTooltipMode.Always; // Metin her zaman görünsün

            markers.Markers.Add(centrumMarker); // Marker'ı overlay'e ekle
            gMapControl1.Overlays.Add(markers); // Overlay'i haritaya ekle
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Gönderen nesneyi al (küçük resim PictureBox)
            PictureBox smallPictureBox = sender as PictureBox;

            // Eğer gönderici geçerli bir PictureBox ise büyük resmi değiştir
            if (smallPictureBox != null)
            {
                pictureBox1.Image = smallPictureBox.Image; // Büyük resmin Image özelliğini değiştir
            }
        }

        private void MersinForm_Load(object sender, EventArgs e)
        {
            // Küçük resim PictureBox'ların olaylarını bağla
            pictureBox3.MouseEnter += pictureBox1_MouseEnter;
            pictureBox4.MouseEnter += pictureBox1_MouseEnter;
            pictureBox5.MouseEnter += pictureBox1_MouseEnter;
            pictureBox6.MouseEnter += pictureBox1_MouseEnter;
            pictureBox7.MouseEnter += pictureBox1_MouseEnter;
            pictureBox8.MouseEnter += pictureBox1_MouseEnter;
            pictureBox9.MouseEnter += pictureBox1_MouseEnter;
            pictureBox10.MouseEnter += pictureBox1_MouseEnter;


        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // Gönderen nesneyi al (küçük resim PictureBox)
            PictureBox smallPictureBox = sender as PictureBox;

            // Eğer gönderici geçerli bir PictureBox ise büyük resmi değiştir
            if (smallPictureBox != null)
            {
                pictureBox1.Image = smallPictureBox.Image; // Büyük resmin Image özelliğini değiştir
            }
        }


    }

}
