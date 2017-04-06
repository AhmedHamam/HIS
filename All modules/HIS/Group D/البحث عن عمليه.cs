using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class opoperation : Form
    {
        public opForm02 own = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        Connection connect;
        public opoperation()
        {
            InitializeComponent();
            connect = new Connection();

        }

        public opoperation(opForm02 own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection();
        }
        private void opoperation_Load(object sender, EventArgs e)
        {
            try
            {
                //con = new SqlConnection(@"Server=DESKTOP-LSC6L8E\SQLEXPRESS; Database=phis; Integrated Security=true");
                //if (con.State != ConnectionState.Open) con.Open();
                //cmd = new SqlCommand("select op_code as 'الكود',op_name as 'اسم العملية' from operations", con);
                //dr = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                //dr.Close();


                connect.OpenConection();
                string pName = "operation_research1";
                string[] paramNames = {  };
                string[] paramValues = {  };
                SqlDbType[] paramType = {  };
                dataGridView1.DataSource= connect.ShowDataInGridViewUsingStoredProc(pName);

                /*
                 * connect.ShowDataInGridViewUsingStoredProc(pName);
                 * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                 */


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                this.own.setvalue2(x, y);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                this.own.setvalue2(x, y);
                this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                e.RowIndex.ToString();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select op_code as 'الكود',op_name as 'اسم العملية' from operations where op_name ='" + textBox2.Text + "'", con);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_language_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select op_code as 'الكود',op_name as 'اسم العملية' from operations where op_name like '" + textBox2.Text + "%'", con);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = " ";
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
