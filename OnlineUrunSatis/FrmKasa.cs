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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();

        void list()
        {
            //Onaylanmış ve/veya Kargolanmış Siparişler
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OrderHeaders INNER JOIN OrderStatus ON OrderHeaders.OrderStatus = OrderStatus.OrderStatus WHERE OrderHeaders.OrderStatus != 'OnHold'", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Caption = "Sipariş Tarihi";
            gridView1.Columns[3].Caption = "İşlem Tutarı (₺)";
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Caption = "Müşteri Ad";
            gridView1.Columns[6].Caption = "Müşteri Soyad";
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Caption = "Müşteri E-Posta";
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Visible = false;
            gridView1.Columns[15].Caption = "Sipariş Durumu";
            gridView1.Columns[16].Visible = false;
            gridView1.Columns[17].Visible = false;

            //Temin Edilen (Satın Alınan) Ürünler
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Expenses WHERE Expenses.ExpenseType = 'Ürün Temini' ", conn.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns[3].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridView2.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[2].Caption = " Satın Alım Tutarı (₺)";
            gridView2.Columns[3].Caption = "Tarih";
            gridView2.Columns[4].Caption = "Detay";
        }

        string toplamsatinalim, toplambrutgelir, toplamvergiler, toplamgider, toplamnetgelir;
         void toplamislemler()
        {
            //Toplam Satın Alım
            SqlCommand komut = new SqlCommand("SELECT SUM(Cost) FROM Expenses WHERE ExpenseType = 'Ürün Temini'", conn.baglanti());
            SqlDataReader drtoplamsatinalim = komut.ExecuteReader();
            while (drtoplamsatinalim.Read())
            {
                LblTSatinAlim.Text = "₺ " + drtoplamsatinalim[0].ToString();
                toplamsatinalim = drtoplamsatinalim[0].ToString();
            }
            conn.baglanti().Close();

            //Toplam Brüt Gelir
            SqlCommand komut2 = new SqlCommand("SELECT SUM(OrderTotal)FROM OrderHeaders WHERE OrderStatus != 'OnHold'", conn.baglanti());
            SqlDataReader drtoplambrutgelir = komut2.ExecuteReader();
            while (drtoplambrutgelir.Read())
            {
                LblTBrutGelir.Text = "₺ " + drtoplambrutgelir[0].ToString();
                toplambrutgelir = drtoplambrutgelir[0].ToString();

            }
            conn.baglanti().Close();

            //Toplam Vergiler
            SqlCommand komut3 = new SqlCommand("SELECT SUM(Cost) FROM Expenses WHERE ExpenseType = 'Vergi'", conn.baglanti());
            SqlDataReader drtoplamvergiler = komut3.ExecuteReader();
            while (drtoplamvergiler.Read())
            {
                LblTVergiler.Text = "₺ " + drtoplamvergiler[0].ToString();
                toplamvergiler = drtoplamvergiler[0].ToString();
            }
            conn.baglanti().Close();

            //Toplam Gider
            SqlCommand komut4 = new SqlCommand("SELECT SUM(Cost) FROM Expenses", conn.baglanti());
            SqlDataReader drtoplamgider = komut4.ExecuteReader();
            while (drtoplamgider.Read())
            {
                LblTGider.Text = "₺ " + drtoplamgider[0].ToString();
                toplamgider = drtoplamgider[0].ToString();
            }
            conn.baglanti().Close();

            //Toplam Net Gelir
            toplamnetgelir = (int.Parse(toplambrutgelir) - (int.Parse(toplamsatinalim) + int.Parse(toplamgider))).ToString();
            LblTNetGelir.Text = "₺ " + toplamnetgelir;
        }
        string buaysatinalim, buaybrutgelir, buayvergiler, buaygider, buaynetgelir;

        void buayislemler()
        {
            //Bu Ay Satın Alım
            SqlCommand komut = new SqlCommand("SELECT SUM(Cost) FROM Expenses WHERE ExpenseType = 'Ürün Temini' AND Date BETWEEN (DATEADD(m, DATEDIFF(m, 0, GETDATE()), 0)) AND (DATEADD(m, DATEDIFF(m, -1, GETDATE()), 0))", conn.baglanti());
            SqlDataReader drbuaysatinalim = komut.ExecuteReader();
            while (drbuaysatinalim.Read())
            {
                LblGSatinAlim.Text = "₺ " + drbuaysatinalim[0].ToString();
                buaysatinalim = drbuaysatinalim[0].ToString();
            }
            conn.baglanti().Close();

            //Bu Ay Brüt Gelir
            SqlCommand komut2 = new SqlCommand("SELECT SUM(OrderTotal)FROM OrderHeaders WHERE OrderStatus != 'OnHold' AND OrderDate BETWEEN (DATEADD(m, DATEDIFF(m, 0, GETDATE()), 0)) AND (DATEADD(m, DATEDIFF(m, -1, GETDATE()), 0))", conn.baglanti());
            SqlDataReader drbuaybrutgelir = komut2.ExecuteReader();
            while (drbuaybrutgelir.Read())
            {
                LblGBrutGelir.Text = "₺ " + drbuaybrutgelir[0].ToString();
                buaybrutgelir = drbuaybrutgelir[0].ToString();

            }
            conn.baglanti().Close();

            //Bu Ay Vergiler
            SqlCommand komut3 = new SqlCommand("SELECT SUM(Cost) FROM Expenses WHERE ExpenseType = 'Vergi' AND Date BETWEEN (DATEADD(m, DATEDIFF(m, 0, GETDATE()), 0)) AND (DATEADD(m, DATEDIFF(m, -1, GETDATE()), 0))", conn.baglanti());
            SqlDataReader drbuayvergiler = komut3.ExecuteReader();
            while (drbuayvergiler.Read())
            {
                LblGVergiler.Text = "₺ " + drbuayvergiler[0].ToString();
                buayvergiler = drbuayvergiler[0].ToString();
            }
            conn.baglanti().Close();

            //Bu Ay Toplam Gider
            SqlCommand komut4 = new SqlCommand("SELECT SUM(Cost) FROM Expenses WHERE Date BETWEEN (DATEADD(m, DATEDIFF(m, 0, GETDATE()), 0)) AND (DATEADD(m, DATEDIFF(m, -1, GETDATE()), 0))", conn.baglanti());
            SqlDataReader drbuaygider = komut4.ExecuteReader();
            while (drbuaygider.Read())
            {
                LblGGider.Text = "₺ " + drbuaygider[0].ToString();
                buaygider = drbuaygider[0].ToString();
            }
            conn.baglanti().Close();

            //Bu Ay Net Gelir
            buaynetgelir = (int.Parse(buaybrutgelir) - (int.Parse(buaysatinalim) + int.Parse(buaygider))).ToString();
            LblGNetGelir.Text = "₺ " + buaynetgelir;
        }


        private void FrmKasa_Load(object sender, EventArgs e)
        {
            list();
            toplamislemler();
            buayislemler();
        }
    }
}
