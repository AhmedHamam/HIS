using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class expiredPackagePrint : Form
    {
        DataTable dt;
        public expiredPackagePrint()
        {
            InitializeComponent();
        }
        public expiredPackagePrint(DataTable d)
        {
            InitializeComponent();
            dt = d;
        }

        private void expiredPackagePrint_Load(object sender, EventArgs e)
        {
            try
            {
                Connection conn = new Connection();
                string query;
                DataTable dt = new DataTable();
                conn.OpenConection();
                query = @"SELECT  id, bloodType, bloodFaction, RH, quntity, bloodStoreID, exDate, reserveQuantity FROM   bloodPackage WHERE        (exDate < { fn CURDATE() })";
                dt.Clear();
                dt = (DataTable)conn.ShowDataInGridView(query);
                conn.CloseConnection();
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
