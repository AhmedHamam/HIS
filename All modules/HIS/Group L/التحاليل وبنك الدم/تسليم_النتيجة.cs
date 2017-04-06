using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{
    public partial class تسليم_النتايج : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string resultID = "";
        string resultNote = "";
        string patienName = "";
        string patientID = "";
        

        public تسليم_النتايج()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void تسليم_النتايج_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            

            try
            {
                connection.Open();
               // cmd = new SqlCommand("select id,result_notices,chemist_id,doctor_analysis_id,patient_number,receving_state,patient_name from analysis_result,patient  where patient_number = patient_ID and  receving_state = 'No' ", connection);
               // dr = cmd.ExecuteReader();
                cmd = new SqlCommand("labAnalysis_analysis_result_select10 ", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            

            try
            {
                connection.Open();
              //  cmd = new SqlCommand("update analysis_result set receving_state = 'yes' where id=" + resultID + "", connection);
               // cmd.ExecuteNonQuery();
                cmd = new SqlCommand("labAnalysis_analysis_result_update3", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resultID ", resultID);
                cmd.ExecuteNonQuery();
                النتيجة nw = new النتيجة(resultID, resultNote,patientID,patienName);
                nw.Show();
            }
            catch
            {
                MessageBox.Show("من فضلك اختر الطلب");
            }

            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resultID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            resultNote = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            patientID = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            patienName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
    }
}
