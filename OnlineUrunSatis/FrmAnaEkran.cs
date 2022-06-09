using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineUrunSatis
{
    public partial class FrmAnaEkran : Form
    {
        public FrmAnaEkran()
        {
            InitializeComponent();
        }
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        FrmUrunler fr2;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmUrunler();
                fr2.MdiParent = this;
                fr2.Show();
                //fr2.Close();
            }
            else
            {
                fr2.Close();
            }
        }

        FrmMusteriler fr3;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmMusteriler();
                fr3.MdiParent = this;
                fr3.Show();
            }
            else
            {
                fr3.Close();
            }
        }

        FrmGiderler fr4;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmGiderler();
                fr4.MdiParent = this;
                fr4.Show();
            }
            else
            {
                fr4.Close();
            }
        }

        FrmSiparisler fr5;
        private void BtnSatislar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmSiparisler();
                fr5.MdiParent = this;
                fr5.Show();
            }
            else
            {
                fr5.Close();
            }
        }

        private void BtnWeb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:44338/");

        }

        FrmKategoriler fr6;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmKategoriler();
                fr6.MdiParent = this;
                fr6.Show();
            }
            else
            {
                fr6.Close();
            }
        }
        
        FrmKasa fr7;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmKasa();
                fr7.MdiParent = this;
                fr7.Show();
            }
            else
            {
                fr7.Close();
            }
        }

        FrmHareketler fr8;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmHareketler();
                fr8.MdiParent = this;
                fr8.Show();
            }
            else
            {
                fr8.Close();
            }
        }

        FrmRaporlar fr9;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new FrmRaporlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
            else
            {
                fr9.Close();
            }
        }
    }
}
