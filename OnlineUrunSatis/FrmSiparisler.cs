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
    public partial class FrmSiparisler : Form
    {
        public FrmSiparisler()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();

        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OrderHeaders INNER JOIN OrderStatus ON OrderHeaders.OrderStatus = OrderStatus.OrderStatus", conn.baglanti());
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
        }

        void orderonhold()
        {
            //if (LblDurum.Text == "Beklemede")
            CbbDurum.Properties.Items.Clear();
            CbbDurum.Text = "İşlem Seçimi";
            SqlCommand komut = new SqlCommand("Select * From OrderStatus WHERE Id != 1", conn.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbDurum.Properties.Items.Add(dr[4]);
            }
            conn.baglanti().Close();
        }
        void orderconfirmed()
        {
            //else if (LblDurum.Text == "Onaylandı")
            CbbDurum.Properties.Items.Clear();
            CbbDurum.Text = "İşlem Seçimi";
            SqlCommand komut = new SqlCommand("Select * From OrderStatus WHERE Id != 2", conn.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbDurum.Properties.Items.Add(dr[3]);
            }
            conn.baglanti().Close();
        }
        void ordershipped()
        {
            //else
            CbbDurum.Properties.Items.Clear();
            CbbDurum.Text = "Ürün Kargolandı!";
        }

        void stocktrigger()
        {
            if (CbbDurum.Text == "Onayı İptal Et") //Adet Arttır
            {
                SqlCommand komut = new SqlCommand("UPDATE Products SET Number = Products.Number + OrderDetails.Count FROM Products INNER JOIN OrderDetails ON OrderDetails.ProductId = Products.Id INNER JOIN OrderHeaders ON OrderHeaders.Id = OrderDetails.OrderId WHERE OrderDetails.OrderId = @p1 ", conn.baglanti());
                komut.Parameters.AddWithValue("@p1", LblSiparisID.Text);
                komut.ExecuteNonQuery();
                conn.baglanti().Close();


            }
            else if (CbbDurum.Text == "Onayla" || CbbDurum.Text == "Onayla & Kargola") //Adet Arttır
            {
                SqlCommand komut = new SqlCommand("UPDATE Products SET Number = Products.Number - OrderDetails.Count FROM Products INNER JOIN OrderDetails ON OrderDetails.ProductId = Products.Id INNER JOIN OrderHeaders ON OrderHeaders.Id = OrderDetails.OrderId WHERE OrderDetails.OrderId = @p1 ", conn.baglanti());
                komut.Parameters.AddWithValue("@p1", LblSiparisID.Text);
                komut.ExecuteNonQuery();
                conn.baglanti().Close();
            }
        }

        void stockbitcorrector()
        {
            SqlCommand komut = new SqlCommand("UPDATE Products SET IsStock = 0 WHERE Number = 0; UPDATE Products SET IsStock = 1 WHERE Number != 0", conn.baglanti());
            komut.ExecuteNonQuery();
            conn.baglanti().Close();
        }

        public string tutar;
        void orderlog_iptal()
        {
            SqlCommand komut = new SqlCommand("SELECT OrderDate FROM OrderHeaders WHERE Id = @p1", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", LblSiparisID.Text.ToString());
            SqlDataReader datepicker = komut.ExecuteReader();
            while (datepicker.Read())
            {
                SqlCommand komut2 = new SqlCommand("INSERT INTO OrderLogs" +
                    "(LogType, LogDate, OrderDate, OrderCost, CustomerName, CustomerSurname, CustomerMail, OrderDescription) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", conn.baglanti());
                komut2.Parameters.AddWithValue("@p1", "İptal");
                komut2.Parameters.AddWithValue("@p2", DateTime.Now);
                komut2.Parameters.AddWithValue("@p3", datepicker[0]);
                komut2.Parameters.AddWithValue("@p4", tutar);
                komut2.Parameters.AddWithValue("@p5", LblAd.Text.ToString());
                komut2.Parameters.AddWithValue("@p6", LblSoyad.Text.ToString());
                komut2.Parameters.AddWithValue("@p7", LblMail.Text.ToString());
                komut2.Parameters.AddWithValue("@p8", "Siparişin onayı iptal edildi ve sipariş tutarı kasadan çıkartılıp ürün stoğu güncellendi.");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            conn.baglanti().Close();
        }

        void orderlog_onay()
        {
            SqlCommand komut = new SqlCommand("SELECT OrderDate FROM OrderHeaders WHERE Id = @p1", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", LblSiparisID.Text.ToString());
            SqlDataReader datepicker = komut.ExecuteReader();
            while (datepicker.Read())
            {
                SqlCommand komut2 = new SqlCommand("INSERT INTO OrderLogs" +
                    "(LogType, LogDate, OrderDate, OrderCost, CustomerName, CustomerSurname, CustomerMail, OrderDescription) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", conn.baglanti());
                komut2.Parameters.AddWithValue("@p1", "Onay");
                komut2.Parameters.AddWithValue("@p2", DateTime.Now);
                komut2.Parameters.AddWithValue("@p3", datepicker[0]);
                komut2.Parameters.AddWithValue("@p4", tutar);
                komut2.Parameters.AddWithValue("@p5", LblAd.Text.ToString());
                komut2.Parameters.AddWithValue("@p6", LblSoyad.Text.ToString());
                komut2.Parameters.AddWithValue("@p7", LblMail.Text.ToString());
                komut2.Parameters.AddWithValue("@p8", "Beklemedeki sipariş onaylandı ve sipariş tutarı kasaya yansıtılıp ürün stoğu güncellendi.");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            conn.baglanti().Close();
        }

        void orderlog_kargo()
        {
            SqlCommand komut = new SqlCommand("SELECT OrderDate FROM OrderHeaders WHERE Id = @p1", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", LblSiparisID.Text.ToString());
            SqlDataReader datepicker = komut.ExecuteReader();
            while (datepicker.Read())
            {
                SqlCommand komut2 = new SqlCommand("INSERT INTO OrderLogs" +
                    "(LogType, LogDate, OrderDate, OrderCost, CustomerName, CustomerSurname, CustomerMail, OrderDescription) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", conn.baglanti());
                komut2.Parameters.AddWithValue("@p1", "Kargo");
                komut2.Parameters.AddWithValue("@p2", DateTime.Now);
                komut2.Parameters.AddWithValue("@p3", datepicker[0]);
                komut2.Parameters.AddWithValue("@p4", tutar);
                komut2.Parameters.AddWithValue("@p5", LblAd.Text.ToString());
                komut2.Parameters.AddWithValue("@p6", LblSoyad.Text.ToString());
                komut2.Parameters.AddWithValue("@p7", LblMail.Text.ToString());
                komut2.Parameters.AddWithValue("@p8", "Onaylı sipariş kargolandı.");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            conn.baglanti().Close();
        }


        void clear()
        {
            LblSiparisID.Text = "";
            LblTarih.Text = "";
            LblTutar.Text = "";
            LblAd.Text = "";
            LblSoyad.Text = "";
            LblMail.Text = "";
            LblTelefon.Text = "";
            LblIl.Text = "";
            LblIlce.Text = "";
            RchAdres.Text = "";
            LblPostaKodu.Text = "";
            CbbDurum.Text = "İşlem Seçimi";
            LblDurum.Text = "";
        }

        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            list();
            clear();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BtnDurum.Enabled = true;
            //Listeden Seçilen Ürünün Bilgilerini Getirme
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LblSiparisID.Text = dr["Id"].ToString();
            LblTarih.Text = dr["OrderDate"].ToString();
            LblTutar.Text = "₺ " + dr["OrderTotal"].ToString();
            tutar = dr["OrderTotal"].ToString();
            LblAd.Text = dr["Name"].ToString();
            LblSoyad.Text = dr["Surname"].ToString();
            LblMail.Text = dr["EMail"].ToString();
            LblTelefon.Text = dr["Phone"].ToString();
            LblIl.Text = dr["City"].ToString();
            LblIlce.Text = dr["District"].ToString();
            RchAdres.Text = dr["Address"].ToString();
            LblPostaKodu.Text = dr["PostCode"].ToString();
            LblDurum.Text = dr["OrderStatusTr"].ToString();
            if (dr["OrderStatus"].ToString() == "OnHold")
            {
                orderonhold();
            }
            else if (dr["OrderStatus"].ToString() == "Confirmed")
            {
                orderconfirmed();
            }
            else
            {
                ordershipped();
                BtnDurum.Enabled = false;
            }
        }
        
        private void BtnDurum_Click(object sender, EventArgs e)
        {
            if (CbbDurum.Text != "İşlem Seçimi")
            {
                SqlCommand komut = new SqlCommand("UPDATE OrderHeaders SET " +
            "OrderStatus=@p1 WHERE Id=@p2", conn.baglanti());
                if (CbbDurum.Text == "Onayı İptal Et")
                {
                    komut.Parameters.AddWithValue("@p1", "OnHold");
                    orderlog_iptal();
                }
                else if (CbbDurum.Text == "Onayla")
                {
                    komut.Parameters.AddWithValue("@p1", "Confirmed");
                    orderlog_onay();
                }
                else if (CbbDurum.Text == "Kargola")
                {
                    komut.Parameters.AddWithValue("@p1", "Shipped");
                    orderlog_kargo();
                }
                else if (CbbDurum.Text == "Onayla & Kargola")
                {
                    komut.Parameters.AddWithValue("@p1", "Shipped");
                    orderlog_onay();
                    orderlog_kargo();
                }
                komut.Parameters.AddWithValue("@p2", LblSiparisID.Text);
                komut.ExecuteNonQuery();
                conn.baglanti().Close();

                stocktrigger();
                stockbitcorrector();

                MessageBox.Show("Sipariş durumu güncellendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                list();
                clear();
            }
            else
            {
                MessageBox.Show("Yapılacak işlemi seçiniz!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                list();
                clear();
            }

            
        }

        private void BtnDetay_Click(object sender, EventArgs e)
        {
            //FrmSiparisDetay frm = new FrmSiparisDetay();
            //frm.Show();
            FrmSiparisDetay frm = new FrmSiparisDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frm.id = dr["Id"].ToString();
            }
            frm.Show();
        }
    }
}
