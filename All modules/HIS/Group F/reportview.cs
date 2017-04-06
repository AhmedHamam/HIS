//using HIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class reportview : Form
    {
        public reportview()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportview_Load(object sender, EventArgs e)
        {

           // this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            string query = @"SELECT        applicant_data.applicant_name, applicant_data.applicant_date, applicant_data.gender, applicant_data.courses, applicant_data.languages, applicant_data.experince_years, applicant_data.qualifications, 
                         applicant_data.job_name, applicant_data.nationality, interview.interviewer_name, interview.interview_date, interview.interview_evaluate
FROM            applicant_data INNER JOIN
                         interview ON applicant_data.applicant_id = interview.applicant_id WHERE applicant_data.applicant_name='" + textBox1.Text + "'";
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridView(query);

            con.CloseConnection();
        }
    }
}
