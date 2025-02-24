namespace FabrikaOtomasyon
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.UrunlerButon = new DevExpress.XtraBars.BarButtonItem();
            this.PolitikalarButon = new DevExpress.XtraBars.BarButtonItem();
            this.FabrikalarButon = new DevExpress.XtraBars.BarButtonItem();
            this.YonetimButon = new DevExpress.XtraBars.BarButtonItem();
            this.CalisanlarButon = new DevExpress.XtraBars.BarButtonItem();
            this.MusterilerButon = new DevExpress.XtraBars.BarButtonItem();
            this.IletisimButon = new DevExpress.XtraBars.BarButtonItem();
            this.SikayetButon = new DevExpress.XtraBars.BarButtonItem();
            this.FaturalarButon = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.UrunlerButon,
            this.PolitikalarButon,
            this.FabrikalarButon,
            this.YonetimButon,
            this.CalisanlarButon,
            this.MusterilerButon,
            this.IletisimButon,
            this.SikayetButon,
            this.FaturalarButon});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1132, 183);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // UrunlerButon
            // 
            this.UrunlerButon.Caption = "Ürünler Hizmetler";
            this.UrunlerButon.Id = 1;
            this.UrunlerButon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UrunlerButon.ImageOptions.Image")));
            this.UrunlerButon.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UrunlerButon.ImageOptions.LargeImage")));
            this.UrunlerButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrunlerButon.ItemAppearance.Normal.Options.UseFont = true;
            this.UrunlerButon.Name = "UrunlerButon";
            this.UrunlerButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UrunlerButon_ItemClick_1);
            // 
            // PolitikalarButon
            // 
            this.PolitikalarButon.Caption = "Politikalarımız";
            this.PolitikalarButon.Id = 3;
            this.PolitikalarButon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("PolitikalarButon.ImageOptions.SvgImage")));
            this.PolitikalarButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.PolitikalarButon.ItemAppearance.Normal.Options.UseFont = true;
            this.PolitikalarButon.Name = "PolitikalarButon";
            this.PolitikalarButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PolitikalarButon_ItemClick);
            // 
            // FabrikalarButon
            // 
            this.FabrikalarButon.Caption = "Fabrikalar Bahçeler";
            this.FabrikalarButon.Id = 4;
            this.FabrikalarButon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FabrikalarButon.ImageOptions.SvgImage")));
            this.FabrikalarButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FabrikalarButon.ItemAppearance.Normal.Options.UseFont = true;
            this.FabrikalarButon.Name = "FabrikalarButon";
            this.FabrikalarButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FabrikalarButon_ItemClick);
            // 
            // YonetimButon
            // 
            this.YonetimButon.Caption = "Yönetim Kurulu";
            this.YonetimButon.Id = 5;
            this.YonetimButon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("YonetimButon.ImageOptions.SvgImage")));
            this.YonetimButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.YonetimButon.ItemAppearance.Normal.Options.UseFont = true;
            this.YonetimButon.Name = "YonetimButon";
            this.YonetimButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YonetimButon_ItemClick);
            // 
            // CalisanlarButon
            // 
            this.CalisanlarButon.Caption = "Çalışanlar";
            this.CalisanlarButon.Id = 6;
            this.CalisanlarButon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CalisanlarButon.ImageOptions.SvgImage")));
            this.CalisanlarButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.CalisanlarButon.ItemAppearance.Normal.Options.UseFont = true;
            this.CalisanlarButon.Name = "CalisanlarButon";
            this.CalisanlarButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CalisanlarButon_ItemClick);
            // 
            // MusterilerButon
            // 
            this.MusterilerButon.Caption = "Alışveriş";
            this.MusterilerButon.Id = 7;
            this.MusterilerButon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MusterilerButon.ImageOptions.SvgImage")));
            this.MusterilerButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MusterilerButon.ItemAppearance.Normal.Options.UseFont = true;
            this.MusterilerButon.Name = "MusterilerButon";
            this.MusterilerButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MusterilerButon_ItemClick);
            // 
            // IletisimButon
            // 
            this.IletisimButon.Caption = "İletişim";
            this.IletisimButon.Id = 8;
            this.IletisimButon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("IletisimButon.ImageOptions.Image")));
            this.IletisimButon.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("IletisimButon.ImageOptions.LargeImage")));
            this.IletisimButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.IletisimButon.ItemAppearance.Normal.Options.UseFont = true;
            this.IletisimButon.Name = "IletisimButon";
            this.IletisimButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.IletisimButon_ItemClick);
            // 
            // SikayetButon
            // 
            this.SikayetButon.Caption = "Şikayet";
            this.SikayetButon.Id = 9;
            this.SikayetButon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SikayetButon.ImageOptions.Image")));
            this.SikayetButon.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SikayetButon.ImageOptions.LargeImage")));
            this.SikayetButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.SikayetButon.ItemAppearance.Normal.Options.UseFont = true;
            this.SikayetButon.Name = "SikayetButon";
            this.SikayetButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SikayetButon_ItemClick);
            // 
            // FaturalarButon
            // 
            this.FaturalarButon.Caption = "Faturalar";
            this.FaturalarButon.Id = 10;
            this.FaturalarButon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("FaturalarButon.ImageOptions.Image")));
            this.FaturalarButon.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FaturalarButon.ImageOptions.LargeImage")));
            this.FaturalarButon.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FaturalarButon.ItemAppearance.Normal.Options.UseFont = true;
            this.FaturalarButon.Name = "FaturalarButon";
            this.FaturalarButon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FaturalarButon_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Göknur Gıda";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.UrunlerButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.FabrikalarButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.YonetimButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.CalisanlarButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.MusterilerButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.PolitikalarButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.FaturalarButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.IletisimButon);
            this.ribbonPageGroup1.ItemLinks.Add(this.SikayetButon);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(888, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "SAAT VE TARİH";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "göknur gıda";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem UrunlerButon;
        private DevExpress.XtraBars.BarButtonItem PolitikalarButon;
        private DevExpress.XtraBars.BarButtonItem FabrikalarButon;
        private DevExpress.XtraBars.BarButtonItem YonetimButon;
        private DevExpress.XtraBars.BarButtonItem CalisanlarButon;
        private DevExpress.XtraBars.BarButtonItem MusterilerButon;
        private DevExpress.XtraBars.BarButtonItem IletisimButon;
        private DevExpress.XtraBars.BarButtonItem SikayetButon;
        private DevExpress.XtraBars.BarButtonItem FaturalarButon;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
    }
}

