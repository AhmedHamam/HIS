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
    public partial class Statistic_internal_rate_of_occupancy_for_patients_Monthly : Form
    {
        Connection m = new Connection();
        public Statistic_internal_rate_of_occupancy_for_patients_Monthly()
        {
            InitializeComponent();
        }

        private void Statistic_internal_rate_of_occupancy_for_patients_Monthly_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(comboBox3.SelectedItem.ToString()) > int.Parse(comboBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("بيانات خاطئة من فضلك ادخل السنة بشكل صحيح");
                    return;
                }
                m.OpenConection();
                String[] arr1 = { "@m", "@n" };
                String[] arr2 = { comboBox3.SelectedItem.ToString(), comboBox1.SelectedItem.ToString() };
                SqlDbType[] arr3 = { SqlDbType.Int, SqlDbType.Int };
                object dt = m.ShowDataInGridViewUsingStoredProc("sir1", arr1, arr2, arr3);
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