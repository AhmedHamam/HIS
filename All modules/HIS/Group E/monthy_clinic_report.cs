using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class monthy_clinic_report : Form
    {
       
        string start_date, end_date , query;
        Connection conn = new Connection();
        string month;
        public monthy_clinic_report()
        {
            InitializeComponent();
        }


        private void monthy_clinic_report_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            start_date = (comboBox2.SelectedIndex + 1).ToString() + "-1-" + comboBox1.SelectedItem;

            if (new[] { 1, 3, 5, 7, 8 ,10,12}.Contains(comboBox2.SelectedIndex + 1)) month = "-31-";
            else if (new[] { 4, 6, 9, 11 }.Contains(comboBox2.SelectedIndex + 1)) month = "-30-";
            else month = "-28-";

            end_date = (comboBox2.SelectedIndex + 1).ToString() + month + comboBox1.SelectedItem;

            query = "select count(pid) as count, arabic_name from treat_patient ,shift_time,  clinic where shift_time.start_time between'"
                + start_date + "' and '" + end_date + "' group by arabic_name";

            object dt =  conn.ShowDataInGridView(query);
            reportViewer1.LocalReport.DataSources.Clear();
            var rtds = new ReportDataSource("DataSet1",dt);
            reportViewer1.LocalReport.DataSources.Add(rtds);
            reportViewer1.RefreshReport();
            //dataGridView1.DataSource = conn.ShowDataInGridView(query) ;
        }

    }
}
