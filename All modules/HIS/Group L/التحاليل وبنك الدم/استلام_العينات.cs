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
    public partial class استلام_العينات : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string patientID = "";
        
        //string doctorID = "";


        public استلام_العينات()
        {
            InitializeComponent();
        }

        //public string sendPatientID
        //{
        //    get
        //    { return txtPatientID.Text; }
        //}
        //public TextBox sendPatientID2
        //{
        //    get
        //    { return txtPatientID; }
        //}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void استلام_العينات_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {

                connection.Open();

              //  cmd = new SqlCommand("select * from analysis_request where receving_state = 'no' ", connection);
               // dr = cmd.ExecuteReader();
                cmd = new SqlCommand("labAnalysis_analysis_request_select2 ", connection);
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
            //MessageBox.Show(recevState);

            try
            {
                connection.Open();
              //  cmd = new SqlCommand("update analysis_request set receving_state = 'yes' where patient_number_patient = " + patientID + "", connection);
               // cmd.ExecuteNonQuery();
                cmd = new SqlCommand("labAnalysis_analysis_request_update2", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_number_patient", patientID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم استلام العينة بنجاح");
                //txtPatientID.Text = patientID;
                //MessageBox.Show(txtPatientID.Text);

                

            }
            catch 
            {
                MessageBox.Show("من فضلك اختر طلب اولا");
            }

            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
        }

     

        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    كتابة_النتايج nw = new كتابة_النتايج(patientID);
        //    nw.Show();
        //}
    }
}
