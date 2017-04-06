using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient; 


namespace HIS
{
    public partial class كتابة_النتايج : Form
    {


        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

     //   string doctorID = "";

        // to get patientID from استلام العينات form
        //private استلام_العينات asd;

        string patientID = "";
        string resultNote = "";
        string chemistID = "";

        public كتابة_النتايج()
        {
            InitializeComponent();
            //patientID = a;
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void كتابة_النتايج_Load(object sender, EventArgs e)
        {


            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                
                
                connection.Open();
                //patientID = asd.txtPatientID.Text;
                //patientID = asd.sendPatientID2.Text;
                //MessageBox.Show(patientID);
                cmd = new SqlCommand("labAnalysis_analysis_request_select3 ", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //  cmd = new SqlCommand("select * from analysis_request where writing_state = 'No' ", connection);
                dr = cmd.ExecuteReader();
                //  cmd = new SqlCommand("select * from analysis_request where writing_state = 'No' ", connection);
                //  dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("من فضلك اختر طلب");

            }
            connection.Close();
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //patientID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr); 

            

            try
            {
                connection.Open();
                resultNote = txtResultNote.Text;
                chemistID = txtChemistID.Text;
             //  cmd = new SqlCommand("update analysis_request set writing_state = 'yes' where patient_number_patient = " + patientID + "", connection);
               // cmd.ExecuteNonQuery();
                cmd = new SqlCommand("labAnalysis_analysis_requuest_update3", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_number_patient", patientID);
                cmd.ExecuteNonQuery();

                //MessageBox.Show("note : " + resultNote + " and chemistID is : " + chemistID + " and patientID is : " + patientID);
                if (resultNote == "" || chemistID == "")
                    MessageBox.Show("من فضلك ادخل بيانات رقم الكيمائى والملاحظات");
                else
                {
                    cmd = new SqlCommand("insert into analysis_result (result_notices,chemist_id,doctor_analysis_id,patient_ID) values (N'" + resultNote + "'," + chemistID + ",1," + patientID + ") ", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تاكيد كتابة النتيجة");
                }
                
            }
            catch 
            {
                MessageBox.Show("من فضلك اختر الطلب");
            }

            connection.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

       

        
    }
}
