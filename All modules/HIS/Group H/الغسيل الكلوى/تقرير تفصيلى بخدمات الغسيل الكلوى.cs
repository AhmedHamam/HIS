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
    public partial class تقرير_تفصيلى_بخدمات_HIS : Form
    {
        public تقرير_تفصيلى_بخدمات_HIS()
        {
            InitializeComponent();
        }

        private void تقرير_تفصيلى_بخدمات_HIS_Load(object sender, EventArgs e)
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
                query = @"SELECT        entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, tb_Second_Level_Service.SLS_Aname, 
                         Hemodialysis_Plan.Excuation_date
                        FROM            Hemodialysis_PatientReception INNER JOIN
                         Hemodialysis_Plan ON Hemodialysis_PatientReception.Code = Hemodialysis_Plan.patient_id INNER JOIN
                         tb_Second_Level_Service ON Hemodialysis_Plan.Service_Code = tb_Second_Level_Service.SLS_id INNER JOIN
                         entranceoffice_visit ON Hemodialysis_PatientReception.patient_id = entranceoffice_visit.visit_id INNER JOIN
                         Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id INNER JOIN
                         tb_Frist_Level_Service ON tb_Second_Level_Service.SLS_FLS_id = tb_Frist_Level_Service.FLS_id";
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            reportViewer1.Clear();
        }
    }
}
