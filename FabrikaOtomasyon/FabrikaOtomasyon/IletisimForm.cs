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
    public partial class IletisimForm : Form
    {
        public IletisimForm()
        {
            InitializeComponent();

            gMapControl1.DragButton = MouseButtons.Left; // Harita kaydırma için mouse butonu
            gMapControl1.CanDragMap = true; // Harita sürüklenebilir olsun
            gMapControl1.MapProvider = GMapProviders.GoogleMap; // Google Harita Sağlayıcısı
            gMapControl1.Position = new PointLatLng(39.89873194742529, 32.68136201587933); // Merkez konumu (örnek: İstanbul)
            gMapControl1.MinZoom = 2; // Minimum zoom seviyesi
            gMapControl1.MaxZoom = 18; // Maksimum zoom seviyesi
            gMapControl1.Zoom = 12; // Başlangıç zoom seviyesi
            gMapControl1.AutoScroll = true;

            // Marker (İşaretçi) ekleme
            GMapOverlay markers = new GMapOverlay("markers"); // Yeni bir overlay oluştur
            GMapMarker centrumMarker = new GMarkerGoogle(
                new PointLatLng(39.89873194742529, 32.68136201587933), // Merkezin koordinatları
                GMarkerGoogleType.red_dot); // Marker tipi: kırmızı nokta

            centrumMarker.ToolTipText = "Göknur Ana Merkez"; // Marker üzerine metin ekleme
            centrumMarker.ToolTipMode = MarkerTooltipMode.Always; // Metin her zaman görünsün

            markers.Markers.Add(centrumMarker); // Marker'ı overlay'e ekle
            gMapControl1.Overlays.Add(markers); // Overlay'i haritaya ekle

        }

        private void IletisimForm_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
