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
    public partial class اسباب_تكهين_الدم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string ID = "";
        public اسباب_تكهين_الدم()
        {
            InitializeComponent();
        }

        private void اسباب_تكهين_الدم_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("select * from deleteReason", con);
                cmd = new SqlCommand("bloodBank_deleteReason_select", connection);
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
                if (txtName.Text == "" && txtLatinName.Text == "")
                    MessageBox.Show("من فضلك ادخل البيانات كاملة");
                else
                {
                    //cmd = new SqlCommand("insert into deleteReason(name,latinName) values (N'" + txtName.Text + "',N'" + txtLatinName.Text + "')", con);
                    cmd = new SqlCommand("bloodBank_deleteReason_insert", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("name", txtName.Text);
                    cmd.Parameters.AddWithValue("latinName", txtLatinName.Text);
                    //MessageBox.Show(txtName.Text + "   " + txtLatinName.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الاضافة بنجاح");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("delete from deleteReason where id=" + ID + "", con);
                cmd = new SqlCommand("bloodBank_deleteReason_delete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", ID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("تم عمليه الحذف بنجاح");
            }
            catch
            {
                MessageBox.Show("من فضلك اختر البنك المراد حذفة");
            }
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
