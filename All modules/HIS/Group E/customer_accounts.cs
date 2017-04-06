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
    public partial class customer_accounts : Form
    {
        Connection con = new Connection();
        public customer_accounts()
        {
            InitializeComponent();
        }

        private void customer_accounts_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                con.OpenConection();
                String[] x = {dateTimePicker1.Value.ToString(),dateTimePicker2.Value.ToString() };
                String[] y = { "@x","@y"};
                SqlDbType []z = { SqlDbType.Date, SqlDbType.Date};
                object dt = con.ShowDataInGridViewUsingStoredProc("demand_account", y, x, z);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
            this.reportViewer1.RefreshReport();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
