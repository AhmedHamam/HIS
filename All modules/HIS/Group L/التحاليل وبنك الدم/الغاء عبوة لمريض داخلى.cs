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
    public partial class الغاء_عبوة_لمريض_داخلى : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        // blood package data
        string ID = "";
        string resQun = "";
        public الغاء_عبوة_لمريض_داخلى()
        {
            InitializeComponent();
        }

        private void الغاء_عبوة_لمريض_داخلى_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {
                connection.Open();
                //cmd = new SqlCommand(" select * from bloodPackage where  reserveQuantity != 0 ", con);
                cmd = new SqlCommand("bloodBank_bloodPackage_select4", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                connection.Open();
                //cmd = new SqlCommand(" update bloodPackage set quntity +=" + resQun + " , reserveQuantity=0 where id="+ID+" ", con);
                cmd = new SqlCommand("bloodBank_bloodPackage_update4", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@quntity",resQun);
                cmd.Parameters.AddWithValue("@id", ID);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الغاء حجز العبوة بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            resQun = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
