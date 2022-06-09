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
    public partial class FrmSiparisDetay : Form
    {
        public FrmSiparisDetay()
        {
            InitializeComponent();
        }

        public string id;
        sqlcon conn = new sqlcon();

        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT OrderHeaders.Id, OrderHeaders.ApplicationUserId, OrderHeaders.OrderDate, OrderHeaders.OrderTotal, OrderHeaders.OrderStatus, OrderHeaders.Name, OrderHeaders.Surname, OrderHeaders.Phone, OrderHeaders.Email, OrderHeaders.City, OrderHeaders.District, OrderHeaders.Address, OrderHeaders.PostCode, OrderDetails.ProductId, OrderDetails.Count, OrderDetails.Price, Products.Brand, Products.Model, Products.Year, Products.Description, Products.Number, Products.Purchase, Products.Sale, Products.Image, Products.IsHome, Products.IsStock, Products.CategoryId, Categories.Name FROM OrderDetails INNER JOIN OrderHeaders ON OrderDetails.OrderId = OrderHeaders.Id INNER JOIN Products ON OrderDetails.ProductId = Products.Id INNER JOIN Categories ON Categories.Id = Products.CategoryId WHERE OrderDetails.OrderId = '" + id + "'", conn.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[3].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Caption = "Sipariş Adedi";
            gridView1.Columns[15].Visible = false;
            gridView1.Columns[16].Caption = "Marka";
            gridView1.Columns[17].Caption = "Model";
            gridView1.Columns[18].Caption = "Yıl";
            gridView1.Columns[19].Visible = false;
            gridView1.Columns[20].Visible = false;
            gridView1.Columns[21].Visible = false;
            gridView1.Columns[22].Visible = false;
            gridView1.Columns[23].Visible = false;
            gridView1.Columns[24].Visible = false;
            gridView1.Columns[25].Visible = false;
            gridView1.Columns[26].Visible = false;
            gridView1.Columns[27].Visible = false;  
        }

        private void FrmSiparisDetay_Load(object sender, EventArgs e)
        {
            list();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            RchDescription.Text = dr[19].ToString();
            Img.LoadAsync(@"..\..\..\OnlineUrunSatisWeb\wwwroot" + dr[23]);
            LblTarih.Text = dr[2].ToString();
            LblTutar.Text = "₺" + dr[3].ToString();
            //LblDurum.Text = dr[4].ToString();
            if (dr[4].ToString() == "OnHold")
            {
                LblDurum.Text = "Beklemede";
            }
            else if (dr[4].ToString() == "Confirmed")
            {
                LblDurum.Text = "Onaylandı";
            }
            else
            {
                LblDurum.Text = "Kargolandı";

            }
            LblAd.Text = dr[5].ToString();
            LblSoyad.Text = dr[6].ToString();
            LblTelefon.Text = dr[7].ToString();
            LblEposta.Text = dr[8].ToString();
            LblIl.Text = dr[9].ToString();
            LblIlce.Text = dr[10].ToString();
            RchAdres.Text = dr[11].ToString();
            LblPosta.Text = dr[12].ToString();
            LblKategori.Text = dr[27].ToString();
            LblMarka.Text = dr[16].ToString();
            LblModel.Text = dr[17].ToString();
            LblYil.Text = dr[18].ToString();
            LblAlis.Text = "₺" + dr[21].ToString();
            LblSatis.Text = "₺" + dr[22].ToString();
            LblStok.Text = dr[20].ToString();
            LblSiparisAdet.Text = dr[14].ToString();

        }
    }
}
