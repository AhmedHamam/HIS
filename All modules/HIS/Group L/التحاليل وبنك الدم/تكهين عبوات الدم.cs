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
    public partial class تكهين_عبوات_الدم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        // bloodpackage data
        string ID = "";

        public تكهين_عبوات_الدم()
        {
            InitializeComponent();
        }

        private void تكهين_عبوات_الدم_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                cmd = new SqlCommand("select * from bloodpackage where exDate <'" + dtNow.Value + "'", connection);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                cmd = new SqlCommand("bloodBank_bloodPackage_delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم عملية التكهين بنجاح");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
