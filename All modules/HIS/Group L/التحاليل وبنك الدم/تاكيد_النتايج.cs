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
    public partial class تاكيد_النتايج : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string doctorID = "";
        string resultID = "";


        public تاكيد_النتايج()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void تاكيد_النتايج_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
           

            try
            {
                //patientID = asd.txtPatientID.Text;
                //patientID = asd.sendPatientID2.Text;
                //MessageBox.Show(patientID);

              //  cmd = new SqlCommand("select * from  analysis_result where confirm_state ='no' ", connection);
              //  dr = cmd.ExecuteReader();
                connection.Open();
                cmd = new SqlCommand("labAnalysis_analysis_result_select1", connection);
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd = new SqlCommand("select * from  analysis_result where confirm_state ='no' ", connection);
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
                doctorID = txtDoctorID.Text;

                
                if (doctorID == "")
                    MessageBox.Show("من فضلك ادخل بيانات رقم دكتور التحاليل");
                else
                {
                    //cmd = new SqlCommand("update analysis_result set confirm_state = 'yes' where id = " + resultID + "", connection);
                    //cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("labAnalysis_analysis_result_update1", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@resultID ", resultID);
                    //cmd = new SqlCommand("update analysis_result set confirm_state = 'yes' where id = " + resultID + "", connection);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resultID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
           
            if (txtResultNote.Text != "")
            {
                

                try
                {
                    connection.Open();
                    //cmd = new SqlCommand("update analysis_result set result_notices =N'" + txtResultNote.Text + "' where id = " + resultID + "", connection);
                   // cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("labAnalysis_analysis_result_update2", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@result_notices", txtResultNote.Text);
                    cmd.Parameters.AddWithValue("@resultID ", resultID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تاكيد كتابة النتيجة");
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();

            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
