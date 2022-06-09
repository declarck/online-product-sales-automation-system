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

namespace OnlineUrunSatis
{
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();

        void list()
        {
            //Sipariş Hareketlerini Veritabanından Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OrderLogs ", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "İşlem";
            gridView1.Columns[2].Caption = "İşlem Tarihi";
            gridView1.Columns[3].Caption = "Sipariş Tarihi";
            gridView1.Columns[4].Caption = "Tutar (₺)";
            gridView1.Columns[5].Caption = "Müşteri Ad";
            gridView1.Columns[6].Caption = "Müşteri Soyad";
            gridView1.Columns[7].Caption = "Müşteri E-Posta";
            gridView1.Columns[8].Caption = "Açıklama";

            //Veri Hareketlerini Veritabanından Çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM DataLogs ", conn.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.OptionsBehavior.Editable = false;
            
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Caption = "İşlem Alanı";
            gridView2.Columns[2].Caption = "İşlem Türü";
            gridView2.Columns[3].Caption = "Veri ID";
            gridView2.Columns[4].Caption = "İşlem Tarihi";
            gridView2.Columns[5].Caption = "Eski Veri";
            gridView2.Columns[6].Caption = "Yeni Veri";
            gridView2.Columns[7].Caption = "Açıklama";

        }

        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            list();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}
