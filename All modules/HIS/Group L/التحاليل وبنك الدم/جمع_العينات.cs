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
    public partial class txt_sample_print : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string collState = "";

        //string AggCheck = "";
        public txt_sample_print()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void جمع_العينات_Load(object sender, EventArgs e)
        {
            
        }

        private void جمع_العينات_Load_1(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                cmd = new SqlCommand("labAnalysis_analysis_request_select1", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //  cmd = new SqlCommand(" select * from analysis_request where collection_state = 'no' ", connection);
                dr = cmd.ExecuteReader();
                //cmd = new SqlCommand(" select * from analysis_request where collection_state = 'no' ", connection);
               // dr = cmd.ExecuteReader();
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
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    if (bool.Parse(item.Cells[0].Value.ToString()))
            //    {
            //        MessageBox.Show("sellected item is : " + item.Cells[0].RowIndex.ToString());
            //    }
            //}

            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("update analysis_request set collection_state = 'yes' where patient_number_patient = " + collState + "", connection);
               // cmd.ExecuteNonQuery();
                cmd = new SqlCommand("labAnalysis_analysis_request_update1", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_number_patient", collState);
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم جمع العينة بنجاح");

            }
            catch
            {
                MessageBox.Show("من فضلك اختر الطلب");
            }

            connection.Close();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            collState = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            طباعه_جمع_العينات___التحاليل nw = new طباعه_جمع_العينات___التحاليل();
            nw.Show();
        }


    }
}
