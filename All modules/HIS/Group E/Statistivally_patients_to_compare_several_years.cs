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
    public partial class Statistivally_patients_to_compare_several_years : Form
    {
        Connection t = new Connection();
        public Statistivally_patients_to_compare_several_years()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int n=0;
            if (!radioButton1.Checked && !radioButton2.Checked)
            { MessageBox.Show(" من فضلك أدخل قيمة خارجى أو داخلى");
            return ;            }
            if (radioButton1.Checked)
                n = 1;

            try
            {
                if (int.Parse(comboBox2.SelectedItem.ToString()) > int.Parse(comboBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("بيانات خاطئة من فضلك ادخل السنة بشكل صحيح");
                    return;
                }
                t.OpenConection();
                String[] arr1 = { "@z" , "@y" , "@x" };
                String[] arr2 = { comboBox2.SelectedItem.ToString() ,n.ToString(), comboBox1.SelectedItem.ToString() };
                SqlDbType[] arr3 = { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
                object dt = t.ShowDataInGridViewUsingStoredProc("spc", arr1, arr2, arr3);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }

            catch (Exception ex)
            {
                MessageBox.Show(" من فضلك أدخل السنة بشكل صحيح ");
            }
        }

        

    }
}
