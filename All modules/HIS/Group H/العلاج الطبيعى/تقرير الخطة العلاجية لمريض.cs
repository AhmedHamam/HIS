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
    public partial class تقرير_الخطة_العلاجية_لمريض : Form
    {
        public تقرير_الخطة_العلاجية_لمريض()
        {
            InitializeComponent();
        }

        private void تقرير_الخطة_العلاجية_لمريض_Load(object sender, EventArgs e)
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
                query = @"SELECT        tb_Frist_Level_Service.FLS_Aname, physiotherapy_Treatment_Plan.plan_start, physiotherapy_Treatment_Plan.plan_end, doctors.full_name
                        FROM            entranceoffice_visit INNER JOIN
                         Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id CROSS JOIN
                         physiotherapy_has_plan INNER JOIN
                         has_service INNER JOIN
                         physiotherapy_Treatment_Plan ON has_service.plan_code = physiotherapy_Treatment_Plan.plan_code ON 
                         physiotherapy_has_plan.plan_code = physiotherapy_Treatment_Plan.plan_code INNER JOIN
                         physiotherapy_Devices ON physiotherapy_Treatment_Plan.Device_code = physiotherapy_Devices.Device_code INNER JOIN
                         doctors ON physiotherapy_has_plan.doc_code = doctors.doc_ssn INNER JOIN
                         tb_Frist_Level_Service ON has_service.service_code = tb_Frist_Level_Service.FLS_id
                         WHERE        (physiotherapy_Treatment_Plan.plan_start >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy 00:00:00") + "') AND (physiotherapy_Treatment_Plan.plan_end <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy 23:59:59") + "') AND (entranceoffice_visit.visit_id=" + textBox1.Text + ")";
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
            عرض_المرضى op = new عرض_المرضى(this);
            op.Show();
        }
        public void SetPatient(String value1, String value2)
        {
            textBox1.Text = value1;
            textBox2.Text = value2;
        }
    }
}
