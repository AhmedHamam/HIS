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
    public partial class Statistics_Monthly_visiting_of_outed_patients : Form
    {
        Connection z = new Connection();
        public Statistics_Monthly_visiting_of_outed_patients()
        {
            InitializeComponent();
        }

        private void Statistics_Monthly_visiting_of_outed_patients_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(comboBox4.SelectedItem.ToString()) > int.Parse(comboBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("بيانات خاطئة من فضلك ادخل السنة بشكل صحيح");
                    return;
                }
                z.OpenConection();
                String[] arr1 = { "@y", "@n" };
                String[] arr2 = { comboBox4.SelectedItem.ToString(), comboBox1.SelectedItem.ToString() };
                SqlDbType[] arr3 = { SqlDbType.Int, SqlDbType.Int };
                object dt = z.ShowDataInGridViewUsingStoredProc("smo", arr1, arr2, arr3);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }

            catch (Exception ex)
            {
                MessageBox.Show(" خطاء من فضلك أدخل السنة بشكل صحيح ");
            }
        }

        
    }
}
