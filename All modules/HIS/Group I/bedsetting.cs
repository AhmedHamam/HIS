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
    public partial class bedsetting : Form
    {
         
        SqlConnection con ;
        SqlCommand cmd = new SqlCommand();
        public bedsetting()
        {
            
            InitializeComponent();
            Connection conn = new Connection();
            string constr = conn.getconstr();
            con = new SqlConnection(constr);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            SqlCommand cmd = new SqlCommand("p5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MessageBox.Show(comboBox1.Text);
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.ExecuteNonQuery();


            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader rd;

            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            string s = "select order  from bedsetting order by order ;";
           SqlCommand cmd = new SqlCommand(s,con);
           
          rd= cmd.ExecuteReader();
          while (rd.Read())
          {
             
           comboBox1.Items.Add(rd[0]);

          }





          rd.Close();
          rd.Dispose();
          con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id_bedsetting from bedsetting where order=" + comboBox1.Text + "", con);
            DataTable t = new DataTable();
            da.Fill(t);
            dataGridView2.DataSource = t;

        }

        private void bedsetting_Load(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {
                
                dataGridView2.Rows[0].Cells[1].Value = 12;
                //SqlCommand cmd = new SqlCommand("select id_bedsetting, order,arabic name,english name from bedsetting where id_bedsetting=" + dataGridView2.Rows[i].Cells[1].Value + " ",conn);
                SqlCommand cmd = new SqlCommand("p18", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_bed", dataGridView2.Rows[0].Cells[1].Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
               // DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
               // dataGridView1.DataSource = dt;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                    dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                    //dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                    //dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                    //dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            SqlCommand cmd = new SqlCommand("p6", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", dataGridView2.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("prr", con);
            cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@order_",textBox3.Text);
                cmd.Parameters.AddWithValue("@arabic",textBox1.Text);
                cmd.Parameters.AddWithValue("@english",textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت الاضافه", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("لم يتم الاضافه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally{

                con.Close();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


 
    }
}
