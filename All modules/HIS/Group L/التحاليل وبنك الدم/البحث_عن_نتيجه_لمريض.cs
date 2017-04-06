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
    public partial class البحث_عن_نتيجه_لمريض : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public البحث_عن_نتيجه_لمريض()
        {
            InitializeComponent();
        }

        private void البحث_عن_نتيجه_لمريض_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                if (tbx_patient_number.Text == string.Empty)
                {
                    MessageBox.Show("من فضلك ادخل الرقم القومي للبحث");

                }
                else
                {

                    //cmd = new SqlCommand("select * from analysis_result where patient_ID = " + tbx_patient_number.Text + " ", connection);
                   // dr = cmd.ExecuteReader();
                    cmd = new SqlCommand("labAnalysis_analysis_result_select11", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patient_name", tbx_patient_number.Text);
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;

                    dr.Close();
                    
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                connection.Open();
                if (tbx_patient_number.Text == string.Empty)
                {
                    MessageBox.Show(" من فضلك ادخل الرقم القومي للمريض للبحث أولا");

                }
                else
                {
                    
                    cmd = new SqlCommand("delete from analysis_result where patient_ID ='" + tbx_patient_number.Text + "'", connection);
                    dr = cmd.ExecuteReader();
             
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    
                    dataGridView1.Visible = true;
                    MessageBox.Show("لقد تمت عمليه المسح بنجاح");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
