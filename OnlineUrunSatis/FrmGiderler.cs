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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();

        void list()
        {
            //Giderleri Veritabanından Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Expenses ", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns[3].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridView1.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "Gider Tipi";
            gridView1.Columns[2].Caption = "Tutar (₺)";
            gridView1.Columns[3].Caption = "Tarih";
            gridView1.Columns[4].Caption = "Detay";
        }

        void expensetype()
        {
            //Veritabanından Gider Tiplerini Çekme
            SqlCommand komut = new SqlCommand("SELECT * FROM ExpenseType", conn.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbGiderTipi.Properties.Items.Add(dr[1]);
            }
            conn.baglanti().Close();
        }

        void clear()
        {
            //İşlem Sonrası Form Temizleme
            TxtID.Text = "";
            CbbGiderTipi.Text = "";
            MskTutar.Text = "";
            DtpTarih.Text = "";
            RchDetay.Text = "";
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            list();
            clear();
            expensetype();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Listeden Seçilen Giderin Bilgilerini Getirme
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr[0].ToString();
            CbbGiderTipi.Text = dr[1].ToString();
            MskTutar.Text = dr[2].ToString();
            DtpTarih.Text = dr[3].ToString();
            RchDetay.Text = dr[4].ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //Gider Ekleme
            SqlCommand komut = new SqlCommand("INSERT INTO Expenses" +
                "(ExpenseType,Cost,Date,Description) " +
                "VALUES(@p1,@p2,@p3,@p4)", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", CbbGiderTipi.Text);
            komut.Parameters.AddWithValue("@p2", MskTutar.Text);
            komut.Parameters.AddWithValue("@p3", DtpTarih.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            //DataLogs
            SqlCommand komutnewid = new SqlCommand("SELECT MAX(Expenses.Id) FROM Expenses;", conn.baglanti());
            SqlDataReader newid = komutnewid.ExecuteReader();
            while (newid.Read())
            {
                SqlCommand komut2 = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komut2.Parameters.AddWithValue("@h1", "Gider");
                komut2.Parameters.AddWithValue("@h2", "Ekleme");
                komut2.Parameters.AddWithValue("@h3", newid[0]);
                komut2.Parameters.AddWithValue("@h4", DateTime.Now);
                komut2.Parameters.AddWithValue("@h5", "-");
                komut2.Parameters.AddWithValue("@h6", CbbGiderTipi.Text);
                komut2.Parameters.AddWithValue("@h7", DtpTarih.Value + " tarihine ₺" + MskTutar.Text + " gider eklendi.");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            conn.baglanti().Close();

            MessageBox.Show("Gider bilgisi eklendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            list();
            clear();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //DataLogs
            SqlCommand komut2 = new SqlCommand("INSERT INTO DataLogs" +
                "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
            komut2.Parameters.AddWithValue("@h1", "Gider");
            komut2.Parameters.AddWithValue("@h2", "Silme");
            komut2.Parameters.AddWithValue("@h3", TxtID.Text);
            komut2.Parameters.AddWithValue("@h4", DateTime.Now);
            komut2.Parameters.AddWithValue("@h5", CbbGiderTipi.Text);
            komut2.Parameters.AddWithValue("@h6", "-");
            komut2.Parameters.AddWithValue("@h7", DtpTarih.Value + " tarihindeki ₺" + MskTutar.Text + " gider silindi.");
            komut2.ExecuteNonQuery();
            conn.baglanti().Close();

            //Gider Silme
            SqlCommand komut = new SqlCommand("DELETE FROM Expenses WHERE Id=@p1",
                conn.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Gider bilgisi silindi!", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            list();
            clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Gider Güncelleme
            SqlCommand komut = new SqlCommand("UPDATE Expenses SET " +
                "ExpenseType=@p1,Cost=@p2,Date=@p3,Description=@p4 WHERE Id=@p5", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", CbbGiderTipi.Text);
            komut.Parameters.AddWithValue("@p2", MskTutar.Text);
            komut.Parameters.AddWithValue("@p3", DtpTarih.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", TxtID.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            //DataLogs
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            string eskigidertipi = dr[1].ToString();
            string yenigidertipi = CbbGiderTipi.Text;
            if (eskigidertipi != yenigidertipi)
            {
                SqlCommand komutgidertipi = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutgidertipi.Parameters.AddWithValue("@h1", "Gider");
                komutgidertipi.Parameters.AddWithValue("@h2", "Tip Güncelleme");
                komutgidertipi.Parameters.AddWithValue("@h3", TxtID.Text);
                komutgidertipi.Parameters.AddWithValue("@h4", DateTime.Now);
                komutgidertipi.Parameters.AddWithValue("@h5", eskigidertipi);
                komutgidertipi.Parameters.AddWithValue("@h6", yenigidertipi);
                komutgidertipi.Parameters.AddWithValue("@h7", "-");
                komutgidertipi.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskitutar = dr[2].ToString();
            string yenitutar = MskTutar.Text;
            if (eskitutar != yenitutar)
            {
                SqlCommand komuttutar = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komuttutar.Parameters.AddWithValue("@h1", "Gider");
                komuttutar.Parameters.AddWithValue("@h2", "Tutar Güncelleme");
                komuttutar.Parameters.AddWithValue("@h3", TxtID.Text);
                komuttutar.Parameters.AddWithValue("@h4", DateTime.Now);
                komuttutar.Parameters.AddWithValue("@h5", "₺" + eskitutar);
                komuttutar.Parameters.AddWithValue("@h6", "₺" + yenitutar);
                komuttutar.Parameters.AddWithValue("@h7", "-");
                komuttutar.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskitarih = dr[3].ToString();
            string yenitarih = DtpTarih.Value.ToString();
            if (eskitarih != yenitarih)
            {
                SqlCommand komuttarih = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komuttarih.Parameters.AddWithValue("@h1", "Gider");
                komuttarih.Parameters.AddWithValue("@h2", "Tarih Güncelleme");
                komuttarih.Parameters.AddWithValue("@h3", TxtID.Text);
                komuttarih.Parameters.AddWithValue("@h4", DateTime.Now);
                komuttarih.Parameters.AddWithValue("@h5", eskitarih);
                komuttarih.Parameters.AddWithValue("@h6", yenitarih);
                komuttarih.Parameters.AddWithValue("@h7", "-");
                komuttarih.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            string eskidetay = dr[4].ToString();
            string yenidetay = RchDetay.Text;
            if (eskidetay != yenidetay)
            {
                SqlCommand komutdetay = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutdetay.Parameters.AddWithValue("@h1", "Gider");
                komutdetay.Parameters.AddWithValue("@h2", "Detay Güncelleme");
                komutdetay.Parameters.AddWithValue("@h3", TxtID.Text);
                komutdetay.Parameters.AddWithValue("@h4", DateTime.Now);
                komutdetay.Parameters.AddWithValue("@h5", eskidetay);
                komutdetay.Parameters.AddWithValue("@h6", yenidetay);
                komutdetay.Parameters.AddWithValue("@h7", "-");
                komutdetay.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            MessageBox.Show("Gider bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            list();
            clear();  
        }
    }
}
