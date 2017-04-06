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
   
    public partial class Statistical_patients_given_year : Form
    {
        Connection x = new Connection();
        public Statistical_patients_given_year()
        {
            InitializeComponent();
            
        }

        private void Statistical_patients_given_year_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                x.OpenConection();
                String[] arr1 = { "@z" };
                String[] arr2 = { comboBox1.SelectedItem.ToString() };
                SqlDbType[] arr3 = { SqlDbType.Int };
                object dt = x.ShowDataInGridViewUsingStoredProc("spgy", arr1, arr2, arr3);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }

            catch (Exception ex)
            { 
                MessageBox.Show(" من فضلك أدخل السنة ");
            }
        }

        
    }
}