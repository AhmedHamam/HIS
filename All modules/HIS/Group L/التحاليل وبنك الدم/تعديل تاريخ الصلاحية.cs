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
    public partial class تعديل_تاريخ_الصلاحية : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        // bloodPackage data
        string ID = "";
        string exDate = "";
        public تعديل_تاريخ_الصلاحية()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                string date = AncExDate.Value.ToString();

                if (date != "")
                {
                    cmd = new SqlCommand("bloodBank_bloodPackage_select", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("exDate",date);
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                }
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
            exDate = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ID + exDate);

            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                connection.Open();
                cmd = new SqlCommand("bloodBank_bloodPackage_update", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("exDate", newExDate.Value);
                cmd.Parameters.AddWithValue("id", ID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم تعديل تاريخ الصلاحيه بنجاح");
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(newExDate + " " + ID);
                MessageBox.Show("من فضلك اختر العبوة المراد تعديل تاريخ الصاحية لها");
            }
            connection.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
