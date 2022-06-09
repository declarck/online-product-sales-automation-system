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
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();
        void list()
        {
            //Ürünleri Veritabanından Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categories WHERE Categories.Id != 1", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Caption = "ID";
            gridView1.Columns[1].Caption = "Kategori Adı";
        }

        void clear()
        {
            //İşlem Sonrası Form Temizleme
            TxtID.Text = "";
            TxtKategori.Text = "";
        }

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {
            list();
            clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Listeden Seçilen Kategorinin Bilgilerini Getirme
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr[0].ToString();
            TxtKategori.Text = dr[1].ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //Kategori Ekleme
            SqlCommand komut = new SqlCommand("INSERT INTO Categories" +
                "(Name) " +
                "VALUES(@p1)", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKategori.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            //DataLogs
            SqlCommand komutnewid = new SqlCommand("SELECT MAX(Categories.Id) FROM Categories;", conn.baglanti());
            SqlDataReader newid = komutnewid.ExecuteReader();
            while (newid.Read())
            {
                SqlCommand komut2 = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komut2.Parameters.AddWithValue("@h1", "Kategori");
                komut2.Parameters.AddWithValue("@h2", "Ekleme");
                komut2.Parameters.AddWithValue("@h3", newid[0]);
                komut2.Parameters.AddWithValue("@h4", DateTime.Now);
                komut2.Parameters.AddWithValue("@h5", "-");
                komut2.Parameters.AddWithValue("@h6", TxtKategori.Text);
                komut2.Parameters.AddWithValue("@h7", "-");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
            }
            conn.baglanti().Close();

            MessageBox.Show("Kategori eklendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            list();
            clear();
        }


        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Kategori Güncelleme
            SqlCommand komut = new SqlCommand("UPDATE Categories SET " +
                "Name=@p1 WHERE Id=@p2", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p2", TxtID.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            //DataLogs
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            string eskikategori = dr[1].ToString();
            string yenikategori = TxtKategori.Text;
            if (eskikategori != yenikategori)
            {
                SqlCommand komutkategori = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komutkategori.Parameters.AddWithValue("@h1", "Kategori");
                komutkategori.Parameters.AddWithValue("@h2", "Ad Güncelleme");
                komutkategori.Parameters.AddWithValue("@h3", TxtID.Text);
                komutkategori.Parameters.AddWithValue("@h4", DateTime.Now);
                komutkategori.Parameters.AddWithValue("@h5", eskikategori);
                komutkategori.Parameters.AddWithValue("@h6", yenikategori);
                komutkategori.Parameters.AddWithValue("@h7", "-");
                komutkategori.ExecuteNonQuery();
                conn.baglanti().Close();
            }

            MessageBox.Show("Kategori güncellendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            list();
            clear();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "1")
            {
                //DataLogs
                SqlCommand komut3 = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                komut3.Parameters.AddWithValue("@h1", "Kategori");
                komut3.Parameters.AddWithValue("@h2", "Silme");
                komut3.Parameters.AddWithValue("@h3", TxtID.Text);
                komut3.Parameters.AddWithValue("@h4", DateTime.Now);
                komut3.Parameters.AddWithValue("@h5", TxtKategori.Text);
                komut3.Parameters.AddWithValue("@h6", "-");
                komut3.Parameters.AddWithValue("@h7", "Kategoriye dahil olan ürünler KATEGORİSİZ olarak seçildi.");
                komut3.ExecuteNonQuery();
                conn.baglanti().Close();

                //Ürünleri Taşıma
                SqlCommand komut = new SqlCommand("UPDATE Products SET " +
                    "CategoryId=@p1 WHERE CategoryId=@p2", conn.baglanti());
                komut.Parameters.AddWithValue("@p1", 1);
                komut.Parameters.AddWithValue("@p2", TxtID.Text);
                komut.ExecuteNonQuery();
                conn.baglanti().Close();

                //Kategori Silme
                SqlCommand komut2 = new SqlCommand("DELETE FROM Categories WHERE ID=@p1",
                    conn.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtID.Text);
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();
                MessageBox.Show("Kategori silindi!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bu kategori değildir, yalnızca kategorisiz ürünleri de görüntüleyebilmeniz içindir. Silinemez!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            list();
            clear();

        }
    }
}
