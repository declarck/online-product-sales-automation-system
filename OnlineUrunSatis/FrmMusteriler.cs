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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        sqlcon conn = new sqlcon();

        void list()
        {
            //Müşterileri Veritabanından Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AspNetUsers WHERE AspNetUsers.Id != '0708fe10-56c0-4bcf-923e-dff21fb0a91f'", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[3].Caption = "E-Posta"; //E-Posta
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Caption = "Telefon"; //Telefon
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Visible = false;
            gridView1.Columns[15].Visible = false; //Adres
            gridView1.Columns[16].Visible = false; //İl
            gridView1.Columns[17].Visible = false;
            gridView1.Columns[18].Visible = false; //İlçe
            gridView1.Columns[19].Caption = "Ad"; //İsim
            gridView1.Columns[20].Visible = false; //Posta Kodu
            gridView1.Columns[21].Caption = "Soyad"; //Soyisim
        }

        void citylist()
        {
            //Veritabanından İlleri Çekme
            SqlCommand komut = new SqlCommand("SELECT City FROM Cities", conn.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbIl.Properties.Items.Add(dr[0]);
            }
            conn.baglanti().Close();
        }

        private void CbbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen İle Göre İlçeleri Listeleme
            CbbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT District FROM Districts WHERE CityId=@p1", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", CbbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbIlce.Properties.Items.Add(dr[0]);
            }
            conn.baglanti().Close();
        }

        void clear()
        {
            //İşlem Sonrası Form Temizleme
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTel.Text = "";
            MskMail.Text = "";
            CbbIl.Text = "";
            CbbIlce.Text = "";
            RchAdres.Text = "";
            TxtPostaKodu.Text = "";
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            list();
            clear();
            citylist();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Listeden Seçilen Ürünün Bilgilerini Getirme
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr[0].ToString();
            TxtAd.Text = dr[19].ToString();
            TxtSoyad.Text = dr[21].ToString();
            MskTel.Text = dr[9].ToString();
            MskMail.Text = dr[3].ToString();
            CbbIl.Text = dr[16].ToString();
            CbbIlce.Text = dr[18].ToString();
            RchAdres.Text = dr[15].ToString();
            TxtPostaKodu.Text = dr[20].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Müşteri Silme
            //SqlCommand komut = new SqlCommand("DELETE FROM AspNetUsers WHERE ID=@p1",
            //    conn.baglanti());
            //komut.Parameters.AddWithValue("@p1", TxtID.Text);
            //komut.ExecuteNonQuery();
            //conn.baglanti().Close();
            //MessageBox.Show("Müşteri bilgisi silindi!", "Bilgi", MessageBoxButtons.OK,
            //    MessageBoxIcon.Error);
            //list();
            //clear();
        }
        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Müşteri Güncelleme
            SqlCommand komut = new SqlCommand("UPDATE AspNetUsers SET " +
                "Name=@p1,Surname=@p2,PhoneNumber=@p3,City=@p4,District=@p5," +
                "Address=@p6, PostCode=@p7 WHERE ID=@p8", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel.Text);
            komut.Parameters.AddWithValue("@p4", CbbIl.Text);
            komut.Parameters.AddWithValue("@p5", CbbIlce.Text);
            komut.Parameters.AddWithValue("@p6", RchAdres.Text);
            komut.Parameters.AddWithValue("@p7", TxtPostaKodu.Text);
            komut.Parameters.AddWithValue("@p8", TxtID.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            //DataLogs
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string userid = dr[0].ToString();

            string eskiad = dr[19].ToString();
            string yeniad = TxtAd.Text;
            if (eskiad != yeniad)
            {
                SqlCommand komutad = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutad.Parameters.AddWithValue("@h1", "Müşteri");
                komutad.Parameters.AddWithValue("@h2", "Ad Güncelleme");
                komutad.Parameters.AddWithValue("@h3", TxtID.Text);
                komutad.Parameters.AddWithValue("@h4", DateTime.Now);
                komutad.Parameters.AddWithValue("@h5", eskiad);
                komutad.Parameters.AddWithValue("@h6", yeniad);
                komutad.Parameters.AddWithValue("@h7", "-");
                komutad.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "Name=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yeniad);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskisoyad = dr[21].ToString();
            string yenisoyad = TxtSoyad.Text;
            if (eskisoyad!= yenisoyad)
            {
                SqlCommand komutsoyad = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutsoyad.Parameters.AddWithValue("@h1", "Müşteri");
                komutsoyad.Parameters.AddWithValue("@h2", "Soyad Güncelleme");
                komutsoyad.Parameters.AddWithValue("@h3", TxtID.Text);
                komutsoyad.Parameters.AddWithValue("@h4", DateTime.Now);
                komutsoyad.Parameters.AddWithValue("@h5", eskisoyad);
                komutsoyad.Parameters.AddWithValue("@h6", yenisoyad);
                komutsoyad.Parameters.AddWithValue("@h7", "-");
                komutsoyad.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "Surname=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yenisoyad);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskitel = dr[9].ToString();
            string yenitel = MskTel.Text;
            if (eskitel != yenitel)
            {
                SqlCommand komuttel = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komuttel.Parameters.AddWithValue("@h1", "Müşteri");
                komuttel.Parameters.AddWithValue("@h2", "Telefon Güncelleme");
                komuttel.Parameters.AddWithValue("@h3", TxtID.Text);
                komuttel.Parameters.AddWithValue("@h4", DateTime.Now);
                komuttel.Parameters.AddWithValue("@h5", eskitel);
                komuttel.Parameters.AddWithValue("@h6", yenitel);
                komuttel.Parameters.AddWithValue("@h7", "-");
                komuttel.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "Phone=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yenitel);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskiil = dr[16].ToString();
            string yeniil = CbbIl.Text;
            if (eskiil != yeniil)
            {
                SqlCommand komutil = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutil.Parameters.AddWithValue("@h1", "Müşteri");
                komutil.Parameters.AddWithValue("@h2", "İl Güncelleme");
                komutil.Parameters.AddWithValue("@h3", TxtID.Text);
                komutil.Parameters.AddWithValue("@h4", DateTime.Now);
                komutil.Parameters.AddWithValue("@h5", eskiil);
                komutil.Parameters.AddWithValue("@h6", yeniil);
                komutil.Parameters.AddWithValue("@h7", "-");
                komutil.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "City=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yeniil);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskiilce = dr[18].ToString();
            string yeniilce = CbbIlce.Text;
            if (eskiilce != yeniilce)
            {
                SqlCommand komutilce = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutilce.Parameters.AddWithValue("@h1", "Müşteri");
                komutilce.Parameters.AddWithValue("@h2", "İlçe Güncelleme");
                komutilce.Parameters.AddWithValue("@h3", TxtID.Text);
                komutilce.Parameters.AddWithValue("@h4", DateTime.Now);
                komutilce.Parameters.AddWithValue("@h5", eskiilce);
                komutilce.Parameters.AddWithValue("@h6", yeniilce);
                komutilce.Parameters.AddWithValue("@h7", "-");
                komutilce.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "District=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yeniilce);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskiadres = dr[15].ToString();
            string yeniadres = RchAdres.Text;
            if (eskiadres != yeniadres)
            {
                SqlCommand komutadres = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutadres.Parameters.AddWithValue("@h1", "Müşteri");
                komutadres.Parameters.AddWithValue("@h2", "Adres Güncelleme");
                komutadres.Parameters.AddWithValue("@h3", TxtID.Text);
                komutadres.Parameters.AddWithValue("@h4", DateTime.Now);
                komutadres.Parameters.AddWithValue("@h5", eskiadres);
                komutadres.Parameters.AddWithValue("@h6", yeniadres);
                komutadres.Parameters.AddWithValue("@h7", "-");
                komutadres.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "Address=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yeniadres);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            string eskipostakodu = dr[20].ToString();
            string yenipostakodu = TxtPostaKodu.Text;
            if (eskipostakodu != yenipostakodu)
            {
                SqlCommand komutpostakodu = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutpostakodu.Parameters.AddWithValue("@h1", "Müşteri");
                komutpostakodu.Parameters.AddWithValue("@h2", "Posta Kodu Güncelleme");
                komutpostakodu.Parameters.AddWithValue("@h3", TxtID.Text);
                komutpostakodu.Parameters.AddWithValue("@h4", DateTime.Now);
                komutpostakodu.Parameters.AddWithValue("@h5", eskipostakodu);
                komutpostakodu.Parameters.AddWithValue("@h6", yenipostakodu);
                komutpostakodu.Parameters.AddWithValue("@h7", "-");
                komutpostakodu.ExecuteNonQuery();
                conn.baglanti().Close();

                SqlCommand komutorder = new SqlCommand("UPDATE OrderHeaders SET " +
            "PostCode=@p1 WHERE ApplicationUserId=@p2", conn.baglanti());
                komutorder.Parameters.AddWithValue("@p1", yenipostakodu);
                komutorder.Parameters.AddWithValue("@p2", userid);
                komutorder.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            MessageBox.Show("Müşteri bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            list();
            clear();
        }
    }
}
