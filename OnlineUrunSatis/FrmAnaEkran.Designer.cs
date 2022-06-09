
namespace OnlineUrunSatis
{
    partial class FrmAnaEkran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaEkran));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnUrunler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnStoklar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMusteriler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnGiderler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSatislar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnKasa = new DevExpress.XtraBars.BarButtonItem();
            this.BtnHareketler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRaporlar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAyarlar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnWeb = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
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
            this.BtnUrunler,
            this.BtnStoklar,
            this.BtnMusteriler,
            this.BtnGiderler,
            this.BtnSatislar,
            this.BtnKasa,
            this.BtnHareketler,
            this.BtnRaporlar,
            this.BtnAyarlar,
            this.BtnWeb});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(1478, 156);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // BtnUrunler
            // 
            this.BtnUrunler.Caption = "Ürünler";
            this.BtnUrunler.Id = 4;
            this.BtnUrunler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnUrunler.ImageOptions.Image")));
            this.BtnUrunler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnUrunler.ImageOptions.LargeImage")));
            this.BtnUrunler.Name = "BtnUrunler";
            this.BtnUrunler.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnUrunler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnUrunler_ItemClick);
            // 
            // BtnStoklar
            // 
            this.BtnStoklar.Caption = "Kategoriler";
            this.BtnStoklar.Id = 5;
            this.BtnStoklar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnStoklar.ImageOptions.Image")));
            this.BtnStoklar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnStoklar.ImageOptions.LargeImage")));
            this.BtnStoklar.Name = "BtnStoklar";
            this.BtnStoklar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnStoklar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnStoklar_ItemClick);
            // 
            // BtnMusteriler
            // 
            this.BtnMusteriler.Caption = "Müşteriler";
            this.BtnMusteriler.Id = 9;
            this.BtnMusteriler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnMusteriler.ImageOptions.Image")));
            this.BtnMusteriler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnMusteriler.ImageOptions.LargeImage")));
            this.BtnMusteriler.Name = "BtnMusteriler";
            this.BtnMusteriler.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnMusteriler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMusteriler_ItemClick);
            // 
            // BtnGiderler
            // 
            this.BtnGiderler.Caption = "Giderler";
            this.BtnGiderler.Id = 10;
            this.BtnGiderler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGiderler.ImageOptions.Image")));
            this.BtnGiderler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnGiderler.ImageOptions.LargeImage")));
            this.BtnGiderler.Name = "BtnGiderler";
            this.BtnGiderler.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnGiderler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnGiderler_ItemClick);
            // 
            // BtnSatislar
            // 
            this.BtnSatislar.Caption = "Siparişler";
            this.BtnSatislar.Id = 11;
            this.BtnSatislar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSatislar.ImageOptions.Image")));
            this.BtnSatislar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnSatislar.ImageOptions.LargeImage")));
            this.BtnSatislar.Name = "BtnSatislar";
            this.BtnSatislar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnSatislar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSatislar_ItemClick);
            // 
            // BtnKasa
            // 
            this.BtnKasa.Caption = "Kasa";
            this.BtnKasa.Id = 12;
            this.BtnKasa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKasa.ImageOptions.Image")));
            this.BtnKasa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnKasa.ImageOptions.LargeImage")));
            this.BtnKasa.Name = "BtnKasa";
            this.BtnKasa.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnKasa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnKasa_ItemClick);
            // 
            // BtnHareketler
            // 
            this.BtnHareketler.Caption = "Hareketler";
            this.BtnHareketler.Id = 13;
            this.BtnHareketler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnHareketler.ImageOptions.Image")));
            this.BtnHareketler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnHareketler.ImageOptions.LargeImage")));
            this.BtnHareketler.Name = "BtnHareketler";
            this.BtnHareketler.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnHareketler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnHareketler_ItemClick);
            // 
            // BtnRaporlar
            // 
            this.BtnRaporlar.Caption = "Raporlar";
            this.BtnRaporlar.Id = 14;
            this.BtnRaporlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRaporlar.ImageOptions.Image")));
            this.BtnRaporlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnRaporlar.ImageOptions.LargeImage")));
            this.BtnRaporlar.Name = "BtnRaporlar";
            this.BtnRaporlar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnRaporlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRaporlar_ItemClick);
            // 
            // BtnAyarlar
            // 
            this.BtnAyarlar.Caption = "Ayarlar";
            this.BtnAyarlar.Enabled = false;
            this.BtnAyarlar.Id = 15;
            this.BtnAyarlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAyarlar.ImageOptions.Image")));
            this.BtnAyarlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnAyarlar.ImageOptions.LargeImage")));
            this.BtnAyarlar.Name = "BtnAyarlar";
            this.BtnAyarlar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // BtnWeb
            // 
            this.BtnWeb.Caption = "Web";
            this.BtnWeb.Id = 20;
            this.BtnWeb.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnWeb.ImageOptions.Image")));
            this.BtnWeb.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnWeb.ImageOptions.LargeImage")));
            this.BtnWeb.Name = "BtnWeb";
            this.BtnWeb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnWeb_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Yönetici Paneli";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSatislar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnUrunler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnStoklar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMusteriler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnGiderler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnKasa);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnHareketler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnRaporlar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnAyarlar);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnWeb);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Müşteriler";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Giderler";
            this.barButtonItem5.Id = 7;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Kasa";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Kapat";
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Yenile";
            this.barButtonItem1.Id = 17;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FrmAnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Ürün Satış Otomasyon Sistemi";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem BtnUrunler;
        private DevExpress.XtraBars.BarButtonItem BtnStoklar;
        private DevExpress.XtraBars.BarButtonItem BtnMusteriler;
        private DevExpress.XtraBars.BarButtonItem BtnGiderler;
        private DevExpress.XtraBars.BarButtonItem BtnSatislar;
        private DevExpress.XtraBars.BarButtonItem BtnKasa;
        private DevExpress.XtraBars.BarButtonItem BtnHareketler;
        private DevExpress.XtraBars.BarButtonItem BtnRaporlar;
        private DevExpress.XtraBars.BarButtonItem BtnAyarlar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BtnWeb;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}

