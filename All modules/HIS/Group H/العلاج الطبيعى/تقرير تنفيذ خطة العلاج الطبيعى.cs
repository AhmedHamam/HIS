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
    public partial class تقرير_تنفيذ_خطة_العلاج_الطبيعى : Form
    {
        public تقرير_تنفيذ_خطة_العلاج_الطبيعى()
        {
            InitializeComponent();
        }

        private void تقرير_تنفيذ_خطة_العلاج_الطبيعى_Load(object sender, EventArgs e)
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
                query = @"SELECT        Registeration_patientRegisteration.patient_name, Registeration_patientRegisteration.patient_id
                         FROM            physiotherapy_Treatment_Plan INNER JOIN
                         physiotherapy_has_plan ON physiotherapy_Treatment_Plan.plan_code = physiotherapy_has_plan.plan_code INNER JOIN
                         doctors ON physiotherapy_has_plan.doc_code = doctors.doc_ssn INNER JOIN
                         entranceoffice_visit INNER JOIN
                         Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id INNER JOIN
                         physiotherapy_Reception ON entranceoffice_visit.visit_id = physiotherapy_Reception.patient_id ON 
                         physiotherapy_Treatment_Plan.physiotherapy_patient_code = physiotherapy_Reception.physiotherapy_patient_code
                        WHERE  (physiotherapy_Treatment_Plan.plan_start >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy 00:00:00") + "') AND (physiotherapy_Treatment_Plan.plan_end <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy 23:59:59") + "') AND (doctors.doc_ssn =" + textBox1.Text + ")";

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
            textBox1.Clear();
            textBox2.Clear();
            reportViewer1.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_موظفى_العلاج_الطبيعي op = new عرض_موظفى_العلاج_الطبيعي(this);
            op.Show();
        }
        public void SetValues(String x, String y)
        {
            textBox1.Text = x;
            textBox2.Text = y;
        
        }

      
    }
}
