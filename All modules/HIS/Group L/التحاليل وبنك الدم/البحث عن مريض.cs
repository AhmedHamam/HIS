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
    public partial class البحث_عن_مريض : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public البحث_عن_مريض()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
           
            try
            {
                connection.Open();
                if (tbx_patient_number.Text ==string.Empty)
                {
                    MessageBox.Show("من فضلك ادخل الرقم القومي للبحث");
                 
                }
                else
                {
                   
                    //cmd = new SqlCommand("select*from patient where patient_number='" + tbx_patient_number.Text + "'", connection);
                   // dr = cmd.ExecuteReader();
                   cmd = new SqlCommand("labAnalysis_patient_select3", connection);
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@patient_num", tbx_patient_number.Text);
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void البحث_عن_مريض_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
    }
}
