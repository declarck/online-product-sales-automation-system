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
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.DataLogs' table. You can move, or remove it, as needed.
            this.DataLogsTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.DataLogs);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.Expenses' table. You can move, or remove it, as needed.
            this.ExpensesTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.Expenses);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.AspNetUsers' table. You can move, or remove it, as needed.
            this.AspNetUsersTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.AspNetUsers);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.Products' table. You can move, or remove it, as needed.
            this.ProductsTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.Products);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.OrderLogs' table. You can move, or remove it, as needed.
            this.OrderLogsTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.OrderLogs);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet.OrderHeaders' table. You can move, or remove it, as needed.
            this.OrderHeadersTableAdapter.Fill(this.OnlineUrunSatisWebDataSet.OrderHeaders);
            // TODO: This line of code loads data into the 'OnlineUrunSatisWebDataSet1.OrderHeaders' table. You can move, or remove it, as needed.
            //this.OrderHeadersTableAdapter.Fill(this.OnlineUrunSatisWebDataSet1.OrderHeaders);

            //this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
        }

    }
}
