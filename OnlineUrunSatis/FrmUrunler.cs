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
using System.IO;

namespace OnlineUrunSatis
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        sqlcon conn = new sqlcon();

        void list()
        {
            //Ürünleri Veritabanından Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products INNER JOIN Categories ON Categories.Id = Products.CategoryId", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "Marka";
            gridView1.Columns[2].Caption = "Model";
            gridView1.Columns[3].Caption = "Yıl";
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Caption = "Adet";
            gridView1.Columns[6].Caption = "Alış Fiyatı (₺)";
            gridView1.Columns[7].Caption = "Satış Fiyatı (₺)";
            gridView1.Columns[8].Visible = false; //Görsel Linki
            gridView1.Columns[9].Caption = "Anasayfa";
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Caption = "Kategori";
        }

        void category()
        {
            //Veritabanından Kategorileri Çekme
            SqlCommand komut = new SqlCommand("SELECT * FROM Categories", conn.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CbbKategori.Properties.Items.Add(dr[1]);
                CbbKategoriId.Properties.Items.Add(dr[0]);
            }
            conn.baglanti().Close();
        }

        private void CbbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbbKategoriId.SelectedIndex = CbbKategori.SelectedIndex;
        }

        void clear()
        {
            TxtID.Text = "";
            CbbKategori.Text = "";
            CbbKategoriId.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            MskAlis.Text = "";
            MskSatis.Text = "";
            RchDetay.Text = "";
            ChAnasayfa.Checked = false;
            ImgUrun.Image = null;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            list();
            clear();
            category();
        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr[0].ToString();
            CbbKategori.Text = dr[13].ToString();
            CbbKategoriId.Text = dr[12].ToString();
            TxtMarka.Text = dr[1].ToString();
            TxtModel.Text = dr[2].ToString();
            MskYil.Text = dr[3].ToString();
            NudAdet.Value = decimal.Parse(dr[5].ToString());
            MskAlis.Text = dr[6].ToString();
            MskSatis.Text = dr[7].ToString();
            RchDetay.Text = dr[4].ToString();
            ChAnasayfa.EditValue = dr[9];
            ImgUrun.LoadAsync(@"..\..\..\OnlineUrunSatisWeb\wwwroot" + dr[8]);
        }
        private void BtnGorsel_Click(object sender, EventArgs e)
        {
            //Görsel Ekleme
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Yükleyeceğiniz görseli seçiniz.";
            openFileDialog1.Filter = "(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        LblYol.Text = path;
                        ImgUrun.Image = new Bitmap(openFileDialog1.FileName);
                        ImgUrun.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen görsel seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (int.Parse((NudAdet.Value).ToString()) == 0)
            {
                MessageBox.Show("Ürün adedi sıfır girilemez!", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                    if (filename == null)
                    {
                        MessageBox.Show("Lütfen geçerli bir görsel seçiniz.");
                    }
                    else
                    {

                        filename = Guid.NewGuid().ToString();

                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(openFileDialog1.FileName, "../../../OnlineUrunSatisWeb/wwwroot/images/product/" + filename + ".jpg");

                        SqlCommand komut = new SqlCommand("INSERT INTO Products" +
                    "(Brand, Model, Year, Description, Number, Purchase, Sale, IsHome, IsStock, CategoryId, Image) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9, @p10, @p11)", conn.baglanti());
                        komut.Parameters.AddWithValue("@p1", TxtMarka.Text);
                        komut.Parameters.AddWithValue("@p2", TxtModel.Text);
                        komut.Parameters.AddWithValue("@p3", MskYil.Text);
                        komut.Parameters.AddWithValue("@p4", RchDetay.Text);
                        komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                        komut.Parameters.AddWithValue("@p6", decimal.Parse(MskAlis.Text));
                        komut.Parameters.AddWithValue("@p7", decimal.Parse(MskSatis.Text));
                        komut.Parameters.AddWithValue("@p8", ChAnasayfa.CheckState);
                        komut.Parameters.AddWithValue("@p9", 1);
                        komut.Parameters.AddWithValue("@p10", CbbKategoriId.Text);
                        komut.Parameters.AddWithValue("@p11", "\\images\\product\\" + filename + ".jpg");
                        komut.ExecuteNonQuery();
                        conn.baglanti().Close();
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.Message, "Görsel seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SqlCommand komut = new SqlCommand("INSERT INTO Products" +
                    "(Brand, Model, Year, Description, Number, Purchase, Sale, IsHome, IsStock, CategoryId) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9, @p10)", conn.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtMarka.Text);
                    komut.Parameters.AddWithValue("@p2", TxtModel.Text);
                    komut.Parameters.AddWithValue("@p3", MskYil.Text);
                    komut.Parameters.AddWithValue("@p4", RchDetay.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(MskAlis.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(MskSatis.Text));
                    komut.Parameters.AddWithValue("@p8", ChAnasayfa.CheckState);
                    komut.Parameters.AddWithValue("@p9", 1);
                    komut.Parameters.AddWithValue("@p10", CbbKategoriId.Text);
                    komut.ExecuteNonQuery();
                    conn.baglanti().Close();
                }

                //Tutar Hesaplama
                double adet, tutar, fiyat;
                fiyat = Convert.ToDouble(MskAlis.Text);
                adet = Convert.ToDouble(NudAdet.Text);
                tutar = fiyat * adet;

                //Ürün Temini Giderini Giderler Tablosuna Ekleme
                SqlCommand komut2 = new SqlCommand("INSERT INTO Expenses" +
                    "(ExpenseType,Cost,Date,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4)", conn.baglanti());
                komut2.Parameters.AddWithValue("@h1", "Ürün Temini");
                komut2.Parameters.AddWithValue("@h2", tutar);
                komut2.Parameters.AddWithValue("@h3", DateTime.Now);
                komut2.Parameters.AddWithValue("@h4", "Stokta hiç bulunmayan " + MskYil.Text + " üretimi " + TxtMarka.Text + " " + TxtModel.Text + " ürününden " + adet + " adet temin edilmiştir.");
                komut2.ExecuteNonQuery();
                conn.baglanti().Close();

                //DataLogs
                SqlCommand komutnewid = new SqlCommand("SELECT MAX(Products.Id) FROM Products;", conn.baglanti());
                SqlDataReader newid = komutnewid.ExecuteReader();
                while (newid.Read())
                {
                    SqlCommand komut3 = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komut3.Parameters.AddWithValue("@h1", "Ürün");
                    komut3.Parameters.AddWithValue("@h2", "Ekleme");
                    komut3.Parameters.AddWithValue("@h3", newid[0]);
                    komut3.Parameters.AddWithValue("@h4", DateTime.Now);
                    komut3.Parameters.AddWithValue("@h5", 0);
                    komut3.Parameters.AddWithValue("@h6", adet);
                    komut3.Parameters.AddWithValue("@h7", MskYil.Text + " üretimi " + TxtMarka.Text + " " + TxtModel.Text + " ürününden " + adet + " adet temin edildi.");
                    komut3.ExecuteNonQuery();
                    conn.baglanti().Close();
                }
                conn.baglanti().Close();
                

                MessageBox.Show("Ürün bilgisi eklendi.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                list();
                clear();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //DataLogs
            SqlCommand komut2 = new SqlCommand("INSERT INTO DataLogs" +
                "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
            komut2.Parameters.AddWithValue("@h1", "Ürün");
            komut2.Parameters.AddWithValue("@h2", "Silme");
            komut2.Parameters.AddWithValue("@h3", TxtID.Text);
            komut2.Parameters.AddWithValue("@h4", DateTime.Now);
            komut2.Parameters.AddWithValue("@h5", NudAdet.Text);
            komut2.Parameters.AddWithValue("@h6", 0);
            komut2.Parameters.AddWithValue("@h7", MskYil.Text + " üretimi " + TxtMarka.Text + " " + TxtModel.Text + " ürününden " + NudAdet.Text + " adet eksiltilerek stok sıfırlandı.");
            komut2.ExecuteNonQuery();
            conn.baglanti().Close();

            SqlCommand komut = new SqlCommand("UPDATE Products SET " +
                "Number=@p1, IsHome=@p2, IsStock=@p3 WHERE ID=@P4", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", "0");
            komut.Parameters.AddWithValue("@p2", 0);
            komut.Parameters.AddWithValue("@p3", 0);
            komut.Parameters.AddWithValue("@p4", TxtID.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();

            MessageBox.Show("Ürün adedi sıfırlandı ve anasayfadan kaldırıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            list();
            clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (int.Parse((NudAdet.Value).ToString()) == 0)
            {
                if (ChAnasayfa.Checked == true)
                {
                    MessageBox.Show("Ürün adedi sıfırken satışa sunulamaz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ürün adedini sıfırlamak için Sil butonunu kullanınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                double yeniadet, eskiadet, adet, tutar, fiyat;

                //GridView'den Eski Ürün Adedini Çekme
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                eskiadet = double.Parse(dr[5].ToString());

                //Ürün Güncelleme
                try
                {
                    string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                    if (filename == null)
                    {
                        MessageBox.Show("Lütfen geçerli bir görsel seçiniz.");
                    }
                    else
                    {
                        filename = Guid.NewGuid().ToString();

                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(openFileDialog1.FileName, "../../../OnlineUrunSatisWeb/wwwroot/images/product/" + filename + ".jpg");

                        SqlCommand komut = new SqlCommand("UPDATE Products SET " +
                    "Brand=@p1, Model=@p2, Year=@p3, Description=@p4, Number=@p5, Purchase=@p6, Sale=@p7, IsHome=@p8, IsStock=@p9, CategoryId=@p10, Image=@p11 WHERE ID=@P12", conn.baglanti());
                        komut.Parameters.AddWithValue("@p1", TxtMarka.Text);
                        komut.Parameters.AddWithValue("@p2", TxtModel.Text);
                        komut.Parameters.AddWithValue("@p3", MskYil.Text);
                        komut.Parameters.AddWithValue("@p4", RchDetay.Text);
                        komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                        komut.Parameters.AddWithValue("@p6", decimal.Parse(MskAlis.Text));
                        komut.Parameters.AddWithValue("@p7", decimal.Parse(MskSatis.Text));
                        komut.Parameters.AddWithValue("@p8", ChAnasayfa.CheckState);
                        komut.Parameters.AddWithValue("@p9", 1);
                        komut.Parameters.AddWithValue("@p10", CbbKategoriId.Text);
                        komut.Parameters.AddWithValue("@p11", "\\images\\product\\" + filename + ".jpg");
                        komut.Parameters.AddWithValue("@p12", TxtID.Text);
                        komut.ExecuteNonQuery();
                        conn.baglanti().Close();
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.Message, "Görselsiz güncellendi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SqlCommand komut = new SqlCommand("UPDATE Products SET " +
                        "Brand=@p1, Model=@p2, Year=@p3, Description=@p4, Number=@p5, Purchase=@p6, Sale=@p7, IsHome=@p8, IsStock=@p9, CategoryId=@p10 WHERE ID=@P12", conn.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtMarka.Text);
                    komut.Parameters.AddWithValue("@p2", TxtModel.Text);
                    komut.Parameters.AddWithValue("@p3", MskYil.Text);
                    komut.Parameters.AddWithValue("@p4", RchDetay.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(MskAlis.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(MskSatis.Text));
                    komut.Parameters.AddWithValue("@p8", ChAnasayfa.CheckState);
                    komut.Parameters.AddWithValue("@p9", 1);
                    komut.Parameters.AddWithValue("@p10", CbbKategoriId.Text);
                    //komut.Parameters.AddWithValue("@p11", "\\images\\product\\" + filename + ".jpg");
                    komut.Parameters.AddWithValue("@p12", TxtID.Text);
                    komut.ExecuteNonQuery();
                    conn.baglanti().Close();
                    
                }
                ////GridView'den Yeni Ürün Adedini Çekme
                yeniadet = Convert.ToDouble(NudAdet.Text);

                ////Ürün Adedi Farkı ve Buna Bağlı Tutarı Hesaplama
                fiyat = Convert.ToDouble(MskAlis.Text);
                adet = yeniadet - eskiadet;
                tutar = fiyat * adet;

                ////Ürün Temini Giderini Giderler Tablosuna Ekleme
                if (yeniadet > eskiadet)
                {
                    //Gider tablosuna veri girişi
                    SqlCommand komut2 = new SqlCommand("INSERT INTO Expenses" +
                    "(ExpenseType,Cost,Date,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4)", conn.baglanti());
                    komut2.Parameters.AddWithValue("@h1", "Ürün Temini");
                    komut2.Parameters.AddWithValue("@h2", tutar);
                    komut2.Parameters.AddWithValue("@h3", DateTime.Now);
                    komut2.Parameters.AddWithValue("@h4", "Stokta " + eskiadet + " adet bulunan " + MskYil.Text + " üretimi " + TxtMarka.Text + " " + TxtModel.Text + ", " + adet + " adet yeni ürün teminiyle beraber " + yeniadet + " adet olmuştur.");
                    komut2.ExecuteNonQuery();
                    conn.baglanti().Close();
                }

                //DataLogs
                string eskikategori = dr[13].ToString();
                string yenikategori = CbbKategori.Text;
                if (eskikategori != yenikategori)
                {
                    SqlCommand komutkategori = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutkategori.Parameters.AddWithValue("@h1", "Ürün");
                    komutkategori.Parameters.AddWithValue("@h2", "Kategori Güncelleme");
                    komutkategori.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutkategori.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutkategori.Parameters.AddWithValue("@h5", eskikategori);
                    komutkategori.Parameters.AddWithValue("@h6", yenikategori);
                    komutkategori.Parameters.AddWithValue("@h7", "-");
                    komutkategori.ExecuteNonQuery();
                    conn.baglanti().Close();
                }

                string eskimarka = dr[1].ToString();
                string yenimarka = TxtMarka.Text;
                if (eskimarka != yenimarka)
                {
                    SqlCommand komutmarka= new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutmarka.Parameters.AddWithValue("@h1", "Ürün");
                    komutmarka.Parameters.AddWithValue("@h2", "Marka Güncelleme");
                    komutmarka.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutmarka.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutmarka.Parameters.AddWithValue("@h5", eskimarka);
                    komutmarka.Parameters.AddWithValue("@h6", yenimarka);
                    komutmarka.Parameters.AddWithValue("@h7", "-");
                    komutmarka.ExecuteNonQuery();
                    conn.baglanti().Close();
                }


                string eskimodel = dr[2].ToString();
                string yenimodel = TxtModel.Text;
                if (eskimodel != yenimodel)
                {
                    SqlCommand komutmodel = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutmodel.Parameters.AddWithValue("@h1", "Ürün");
                    komutmodel.Parameters.AddWithValue("@h2", "Model Güncelleme");
                    komutmodel.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutmodel.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutmodel.Parameters.AddWithValue("@h5", eskimodel);
                    komutmodel.Parameters.AddWithValue("@h6", yenimodel);
                    komutmodel.Parameters.AddWithValue("@h7", "-");
                    komutmodel.ExecuteNonQuery();
                    conn.baglanti().Close();
                }


                string eskiyil = dr[3].ToString();
                string yeniyil = MskYil.Text;
                if (eskiyil != yeniyil)
                {
                    SqlCommand komutyil = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutyil.Parameters.AddWithValue("@h1", "Ürün");
                    komutyil.Parameters.AddWithValue("@h2", "Yıl Güncelleme");
                    komutyil.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutyil.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutyil.Parameters.AddWithValue("@h5", eskiyil);
                    komutyil.Parameters.AddWithValue("@h6", yeniyil);
                    komutyil.Parameters.AddWithValue("@h7", "-");
                    komutyil.ExecuteNonQuery();
                    conn.baglanti().Close();
                }

                if (eskiadet != yeniadet)
                {
                    SqlCommand komutadet = new SqlCommand("INSERT INTO DataLogs" +
                    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutadet.Parameters.AddWithValue("@h1", "Ürün");
                    komutadet.Parameters.AddWithValue("@h2", "Adet Güncelleme");
                    komutadet.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutadet.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutadet.Parameters.AddWithValue("@h5", eskiadet);
                    komutadet.Parameters.AddWithValue("@h6", yeniadet);
                    komutadet.Parameters.AddWithValue("@h7", "-");
                    komutadet.ExecuteNonQuery();
                    conn.baglanti().Close();
                }
                

                string eskialis = dr[6].ToString();
                string yenialis = MskAlis.Text.ToString();
                if (eskialis != yenialis)
                {
                    SqlCommand komutalis = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutalis.Parameters.AddWithValue("@h1", "Ürün");
                    komutalis.Parameters.AddWithValue("@h2", "Alış Fiyatı Güncelleme");
                    komutalis.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutalis.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutalis.Parameters.AddWithValue("@h5", "₺" + eskialis);
                    komutalis.Parameters.AddWithValue("@h6", "₺" + yenialis);
                    komutalis.Parameters.AddWithValue("@h7", "-");
                    komutalis.ExecuteNonQuery();
                    conn.baglanti().Close();
                }


                string eskisatis = dr[7].ToString();
                string yenisatis = MskSatis.Text.ToString();
                if (eskisatis != yenisatis)
                {
                    SqlCommand komutsatis = new SqlCommand("INSERT INTO DataLogs" +
                        "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                        "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                    komutsatis.Parameters.AddWithValue("@h1", "Ürün");
                    komutsatis.Parameters.AddWithValue("@h2", "Satış Fiyatı Güncelleme");
                    komutsatis.Parameters.AddWithValue("@h3", TxtID.Text);
                    komutsatis.Parameters.AddWithValue("@h4", DateTime.Now);
                    komutsatis.Parameters.AddWithValue("@h5", "₺" + eskisatis);
                    komutsatis.Parameters.AddWithValue("@h6", "₺" + yenisatis);
                    komutsatis.Parameters.AddWithValue("@h7", "-");
                    komutsatis.ExecuteNonQuery();
                    conn.baglanti().Close();
                }


                //string eskidetay = dr[4].ToString();
                //string yenidetay = RchDetay.Text;
                //if (eskidetay != yenidetay)
                //{
                //    SqlCommand komutdetay = new SqlCommand("INSERT INTO DataLogs" +
                //    "(LogField,LogType,DataId,LogDate,OldData,NewData,Description) " +
                //    "VALUES(@h1,@h2,@h3,@h4,@h5,@h6,@h7)", conn.baglanti());
                //    komutdetay.Parameters.AddWithValue("@h1", "Ürün");
                //    komutdetay.Parameters.AddWithValue("@h2", "Detay Güncelleme");
                //    komutdetay.Parameters.AddWithValue("@h3", TxtID.Text);
                //    komutdetay.Parameters.AddWithValue("@h4", DateTime.Now);
                //    komutdetay.Parameters.AddWithValue("@h5", eskidetay);
                //    komutdetay.Parameters.AddWithValue("@h6", yenidetay);
                //    komutdetay.Parameters.AddWithValue("@h7", "-");
                //    komutdetay.ExecuteNonQuery();
                //    conn.baglanti().Close();
                //}

                MessageBox.Show("Ürün bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                list();
                clear();
            }
        }
    }
}
