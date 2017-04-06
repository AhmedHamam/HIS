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
    public partial class البحث_عن_تحليل : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public البحث_عن_تحليل()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            

            try
            {
                connection.Open();
                if (tbx_servname.Text == string.Empty)
                {
                    MessageBox.Show("من فضلك ادخل اسم الاختبار للبحث");

                }
                else
                {
                    
                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info where serv_name='" + tbx_servname.Text + "'", connection);
                    dr = cmd.ExecuteReader();
                
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    
                    dataGridView1.Visible = true;

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
                if (tbx_servname.Text == string.Empty)
                {
                    MessageBox.Show(" من فضلك ادخل أسم الأختبار أولا  ");

                }
                else
                {
                    
                   cmd = new SqlCommand("delete from analysis_info where serv_name='" + tbx_servname.Text + "'", connection);
                   dr = cmd.ExecuteReader();
                    //cmd = new SqlCommand("labAnalysis_analysis_info_select1", connection);
                   // cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@testName", tbx_servname.Text);
                   //dr = cmd.ExecuteReader();
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

        private void البحث_عن_تحليل_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
    }
}
