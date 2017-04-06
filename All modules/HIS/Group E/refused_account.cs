using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class refused_account : Form
    {
        public refused_account()
        {
            InitializeComponent();
        }

        private void refused_account_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            try
            {

                con.OpenConection();
                String[] x = { dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString() };
                String[] y = { "@x", "@y" };
                SqlDbType[] z = { SqlDbType.Date, SqlDbType.Date };
                object dt = con.ShowDataInGridViewUsingStoredProc("refused_account", y, x, z);
                
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
