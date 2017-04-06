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
    public partial class تقرير_للمرضى_المصابين_خلال_فتره_معينه : Form
    {
        public تقرير_للمرضى_المصابين_خلال_فتره_معينه()
        {
            InitializeComponent();
        }

        private void تقرير_للمرضى_المصابين_خلال_فتره_معينه_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection conn = new Connection();
                string query;
                DataTable dt = new DataTable();
                conn.OpenConection();
                query = @"SELECT        infected_Employee.code, employee.name, employee.gender,infected_Employee.vaccination_date, doctors.full_name
                         FROM         
                         employee  INNER JOIN
                         infected_Employee ON employee.emp_id = infected_Employee.Emp_code INNER JOIN
                         doctors ON employee.emp_id = doctors.emp_id AND infected_Employee.Doctor_Code = doctors.doc_ssn
                         WHERE        (infected_Employee.vaccination_date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy 00:00:00") + "') AND (infected_Employee.vaccination_date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy 23:59:59") + "') OR (doctors.full_name = '" + textBox1.Text + "')";
                dt.Clear();
                dt = (DataTable)conn.ShowDataInGridView(query);
                conn.CloseConnection();
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              try
            {
                textBox1.Clear();
                  
                reportViewer1.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
