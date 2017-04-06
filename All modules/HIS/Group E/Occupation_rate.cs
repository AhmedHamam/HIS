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
    public partial class occupation_rate : Form
    {
        public occupation_rate()
        {
            InitializeComponent();
        }

        private void occupation_rate_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            
            try
            {

                con.OpenConection();

                String []a={"@x","@y"};
                String [] b={dateTimePicker1.Value.ToString(),dateTimePicker2.Value.ToString()};
                SqlDbType[] c = { SqlDbType.Date, SqlDbType.Date };
                object dt = con.ShowDataInGridViewUsingStoredProc("occupation_rate", a, b, c);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
          

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
