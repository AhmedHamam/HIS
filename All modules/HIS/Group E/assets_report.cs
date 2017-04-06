using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class assets_report : Form
    {
        public assets_report()
        {
            InitializeComponent();
        }

        private void assets_report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate_reports();
        }

        public void generate_reports()
        {
            Connection sqlCon = new Connection();
            try
            {
                sqlCon.OpenConection();
                object dt= sqlCon.ShowDataInGridViewUsingStoredProc("asset_report");
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                sqlCon.CloseConnection();
 }
        }
    }
}
