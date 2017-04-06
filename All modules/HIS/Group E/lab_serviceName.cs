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
    public partial class lab_serviceName : Form
    {
        public lab_serviceName()
        {
            InitializeComponent();
        }

        private void lab_serviceName_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            try
            {

                con.OpenConection();
                //SqlCommand cmd = new SqlCommand("lab_serviceName", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                object dt = con.ShowDataInGridViewUsingStoredProc("lab_serviceName");
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
