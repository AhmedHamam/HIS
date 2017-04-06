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
    public partial class national : Form
    {
        public national()
        {
            InitializeComponent();
        }

        private void national_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            try
            {

                con.OpenConection();
                
                object dt = con.ShowDataInGridViewUsingStoredProc("nationall");
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }

        }
    }
}
