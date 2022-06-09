
namespace OnlineUrunSatis
{
    partial class FrmRaporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRaporlar));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.panelContainer4 = new DevExpress.XtraBars.Docking.DockPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OnlineUrunSatisWebDataSet = new OnlineUrunSatis.OnlineUrunSatisWebDataSet();
            this.OrderHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderHeadersTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.OrderHeadersTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer6 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrderLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderLogsTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.OrderLogsTableAdapter();
            this.ProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductsTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.ProductsTableAdapter();
            this.AspNetUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AspNetUsersTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.AspNetUsersTableAdapter();
            this.ExpensesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExpensesTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.ExpensesTableAdapter();
            this.DataLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataLogsTableAdapter = new OnlineUrunSatis.OnlineUrunSatisWebDataSetTableAdapters.DataLogsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineUrunSatisWebDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderLogsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspNetUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1476, 755);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage3,
            this.xtraTabPage6});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.reportViewer1);
            this.xtraTabPage1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage1.ImageOptions.SvgImage")));
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage1.Text = "Siparişler";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.reportViewer2);
            this.xtraTabPage2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage2.ImageOptions.SvgImage")));
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage2.Text = "Sipariş Hareketleri";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportViewer3);
            this.xtraTabPage4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage4.ImageOptions.SvgImage")));
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage4.Text = "Ürünler";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.reportViewer4);
            this.xtraTabPage5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage5.ImageOptions.SvgImage")));
            this.xtraTabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage5.Text = "Müşteriler";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Appearance.PageClient.BackColor = System.Drawing.Color.Tomato;
            this.xtraTabPage3.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage3.Controls.Add(this.reportViewer5);
            this.xtraTabPage3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage3.ImageOptions.SvgImage")));
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage3.Text = "Giderler";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.reportViewer6);
            this.xtraTabPage6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage6.ImageOptions.SvgImage")));
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(1474, 691);
            this.xtraTabPage6.Text = "Veri Hareketleri";
            // 
            // panelContainer4
            // 
            this.panelContainer4.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer4.ID = new System.Guid("2f90b37a-319b-4d2a-a14a-8d913583c19f");
            this.panelContainer4.Location = new System.Drawing.Point(0, 0);
            this.panelContainer4.Name = "panelContainer4";
            this.panelContainer4.Size = new System.Drawing.Size(200, 200);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OrderHeadersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_Orders.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer1.TabIndex = 0;
            // 
            // OnlineUrunSatisWebDataSet
            // 
            this.OnlineUrunSatisWebDataSet.DataSetName = "OnlineUrunSatisWebDataSet";
            this.OnlineUrunSatisWebDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OrderHeadersBindingSource
            // 
            this.OrderHeadersBindingSource.DataMember = "OrderHeaders";
            this.OrderHeadersBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // OrderHeadersTableAdapter
            // 
            this.OrderHeadersTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.OrderLogsBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_OrderLogs.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer2.TabIndex = 0;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.ProductsBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_Products.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer3.TabIndex = 0;
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.AspNetUsersBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_Customers.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(0, 0);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.ServerReport.BearerToken = null;
            this.reportViewer4.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer4.TabIndex = 0;
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = this.ExpensesBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_Expenses.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.ServerReport.BearerToken = null;
            this.reportViewer5.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer5.TabIndex = 0;
            // 
            // reportViewer6
            // 
            this.reportViewer6.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.DataLogsBindingSource;
            this.reportViewer6.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer6.LocalReport.ReportEmbeddedResource = "OnlineUrunSatis.Report_DataLogs.rdlc";
            this.reportViewer6.Location = new System.Drawing.Point(0, 0);
            this.reportViewer6.Name = "reportViewer6";
            this.reportViewer6.ServerReport.BearerToken = null;
            this.reportViewer6.Size = new System.Drawing.Size(1474, 691);
            this.reportViewer6.TabIndex = 0;
            // 
            // OrderLogsBindingSource
            // 
            this.OrderLogsBindingSource.DataMember = "OrderLogs";
            this.OrderLogsBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // OrderLogsTableAdapter
            // 
            this.OrderLogsTableAdapter.ClearBeforeFill = true;
            // 
            // ProductsBindingSource
            // 
            this.ProductsBindingSource.DataMember = "Products";
            this.ProductsBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // ProductsTableAdapter
            // 
            this.ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // AspNetUsersBindingSource
            // 
            this.AspNetUsersBindingSource.DataMember = "AspNetUsers";
            this.AspNetUsersBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // AspNetUsersTableAdapter
            // 
            this.AspNetUsersTableAdapter.ClearBeforeFill = true;
            // 
            // ExpensesBindingSource
            // 
            this.ExpensesBindingSource.DataMember = "Expenses";
            this.ExpensesBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // ExpensesTableAdapter
            // 
            this.ExpensesTableAdapter.ClearBeforeFill = true;
            // 
            // DataLogsBindingSource
            // 
            this.DataLogsBindingSource.DataMember = "DataLogs";
            this.DataLogsBindingSource.DataSource = this.OnlineUrunSatisWebDataSet;
            // 
            // DataLogsTableAdapter
            // 
            this.DataLogsTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 755);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelContainer4);
            this.Name = "FrmRaporlar";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OnlineUrunSatisWebDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderLogsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspNetUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLogsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OrderHeadersBindingSource;
        private OnlineUrunSatisWebDataSet OnlineUrunSatisWebDataSet;
        private OnlineUrunSatisWebDataSetTableAdapters.OrderHeadersTableAdapter OrderHeadersTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer6;
        private System.Windows.Forms.BindingSource OrderLogsBindingSource;
        private OnlineUrunSatisWebDataSetTableAdapters.OrderLogsTableAdapter OrderLogsTableAdapter;
        private System.Windows.Forms.BindingSource ProductsBindingSource;
        private OnlineUrunSatisWebDataSetTableAdapters.ProductsTableAdapter ProductsTableAdapter;
        private System.Windows.Forms.BindingSource AspNetUsersBindingSource;
        private OnlineUrunSatisWebDataSetTableAdapters.AspNetUsersTableAdapter AspNetUsersTableAdapter;
        private System.Windows.Forms.BindingSource ExpensesBindingSource;
        private OnlineUrunSatisWebDataSetTableAdapters.ExpensesTableAdapter ExpensesTableAdapter;
        private System.Windows.Forms.BindingSource DataLogsBindingSource;
        private OnlineUrunSatisWebDataSetTableAdapters.DataLogsTableAdapter DataLogsTableAdapter;
    }
}