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
    public partial class AnaForm2 : Form
    {
        public AnaForm2()
        {
            InitializeComponent();
        }
        private void FabrikalarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FabrikaForm frm = new FabrikaForm();
            frm.MdiParent = this;
            frm.Show();
        }
        // private void YonetimButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //   // YtKurulForm frm = new YtKurulForm();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}
        private void MusterilerButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AlisverisForm frm = new AlisverisForm();
            frm.ShowDialog();
        }
        private void IletisimButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IletisimForm frm = new IletisimForm();
            frm.MdiParent = this;
            frm.Show();
        }
        private void SikayetButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SikayetForm frm = new SikayetForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PolitikalarButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PolitikalarForm frm = new PolitikalarForm();
            frm.MdiParent = this;
            frm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
      

        private void AnaForm2_Load(object sender, EventArgs e)
        {
         //   this.IsMdiContainer = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void UrunlerButon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    UrunlerForm frm = new UrunlerForm();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}
    }
}
