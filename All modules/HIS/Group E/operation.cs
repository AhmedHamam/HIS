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
    public partial class operation : Form
    {
        public operation()
        {
            InitializeComponent();
        }

        private void operation_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            try
            {

                con.OpenConection();
                //SqlCommand cmd = new SqlCommand("operation", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                object dt = con.ShowDataInGridViewUsingStoredProc("operation");
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
