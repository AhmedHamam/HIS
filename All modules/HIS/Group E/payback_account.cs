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
    public partial class payback_account : Form
    {
        public payback_account()
        {
            InitializeComponent();
        }

        private void payback_account_Load(object sender, EventArgs e)
        {
            reportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            try
            {

                con.OpenConection();
                String[] x = { dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString() };
                String[] y = { "@x", "@y" };
                SqlDbType[] z = { SqlDbType.Date, SqlDbType.Date };
                object dt = con.ShowDataInGridViewUsingStoredProc("payback_account",y,x, z);

                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
            this.reportViewer1.RefreshReport();

        }
    }
}
