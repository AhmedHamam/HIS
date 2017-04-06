using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class opForm15 : Form
    {
        Connection connect;
        string s,x,y;
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public DataSet dss = new DataSet();
        public SqlCommand cmd;
        public SqlDataReader dr;
        public opForm15()
        {
            InitializeComponent();
            connect = new Connection();
            string ConnectionString = connect.getconstr();
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
       

        private void opForm15_Load(object sender, EventArgs e)
        {
            try
            {
                
                da = new SqlDataAdapter("select * from requests where r_status ='no';", con);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                ds.Tables[0].Clear();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
       }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_requested.Checked)
                {
                    da = new SqlDataAdapter("select * from requests where r_status ='no';", con);
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    ds.Tables[0].Clear();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }


                else if (btn_confirmed.Checked)
                {
                    da = new SqlDataAdapter("select * from requests where r_status ='yes';", con);
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    ds.Tables[0].Clear();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];

                }




            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            try
            {

                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();

                for (int i = dataGridView2.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView2.Rows[i].Selected == true)
                    {
                        string code = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        cmd = new SqlCommand("delete from requests where r_code= '" + code + "'", con);
                        dataGridView2.Rows.RemoveAt(i);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (con.State != ConnectionState.Closed)
                    if (con.State != ConnectionState.Closed) con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();

                for (int i = dataGridView2.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView2.Rows[i].Selected == true)
                    {
                        dataGridView2.Rows[i].Cells[3].Value = "yes";

                        cmd = new SqlCommand("update  requests set r_status='yes' where r_code='" + dataGridView2.Rows[i].Cells[0].Value + "';", con);
                        MessageBox.Show("operation request confirmed");
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand(); cmd2.Connection = con;
                        string ss = "insert into operations(doc_ssn,visit_id ,r_code,op_date) values ('" + dataGridView2.Rows[i].Cells[4].Value + "','" + dataGridView2.Rows[i].Cells[5].Value + "','" + dataGridView2.Rows[i].Cells[0].Value + "','"+dataGridView2.Rows[i].Cells[6].Value + "');";
                        cmd2.CommandText = ss;
                        cmd2.ExecuteNonQuery();
                    }
                }
                if (con.State != ConnectionState.Closed)
                    if (con.State != ConnectionState.Closed) con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
      
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
