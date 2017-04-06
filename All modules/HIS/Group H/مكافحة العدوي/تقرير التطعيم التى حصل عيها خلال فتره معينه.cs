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
    public partial class تقرير_التطعيماتالتى_حصل_عيها_خلال_فتره_معينه : Form
    {
        public تقرير_التطعيماتالتى_حصل_عيها_خلال_فتره_معينه()
        {
            InitializeComponent();
        }

        private void تقرير_التطعيماتالتى_حصل_عيها_خلال_فتره_معينه_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*employee ON adminstration.id_admin = employee.id_admin INNER JOIN*/
                Connection conn = new Connection();
                string query;
                DataTable dt = new DataTable();
                conn.OpenConection();
                query = @"SELECT   vaccination.vaccination_code, vaccination.vaccination_Arabic_name, vaccination.vaccination_English_name, vaccination.vaccination_kind, 
                         vaccination.vaccination_appointment
                        FROM  departement INNER JOIN
                         
                        employee ON employee.dep_code = departement.code INNER JOIN
                         vaccination INNER JOIN
                         infected_Employee ON vaccination.vaccination_code = infected_Employee.vaccination_code ON employee.emp_id = infected_Employee.Emp_code
                         WHERE  (vaccination.vaccination_appointment >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy 00:00:00") + "') AND (vaccination.vaccination_appointment <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy 23:59:59") + @"') OR
                         (employee.name = '" + textBox3.Text + "') OR (departement.name = '" + textBox2.Text + "')";
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
               // textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                reportViewer1.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
