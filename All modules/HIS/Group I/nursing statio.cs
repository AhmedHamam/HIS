using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class nursing_statio : Form
    {

        SqlConnection con ;

        
        public nursing_statio()
        {
            
            InitializeComponent();
            Connection conn = new Connection();
            string constr = conn.getconstr();
            con = new SqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void nursing_statio_Load(object sender, EventArgs e)
        {

            //conn = new SqlConnection(connString);
            loodNursingplace();
        }


        private void loodNursingplace()
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            dataGridView3.DataSource = null;
            SqlCommand cmd = new SqlCommand("p16",con);
            cmd.CommandType = CommandType.StoredProcedure;
            //var select = "SELECT * FROM nursingstation";
            //var c = new SqlConnection(connString);
            // Your Connection String here
            var dataAdapter = new SqlDataAdapter(cmd);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            dataGridView3.Columns[0].HeaderText = "رقم المسلسل";
            dataGridView3.Columns[1].HeaderText = "اسم المكان";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            
            con.Open();
            try
            {
               // conn.Open();
                SqlCommand cmd = new SqlCommand("p8", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                //SqlCommand cmd = new SqlCommand("insert into nursingstation (arabic name) values ('" + textBox1.Text + "') ", conn);
                //cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("تم التسجيل بنجاح");


            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            SqlDataReader rd;

            
            string s = "select order from nursingstation order by order ;";
            SqlCommand cmd = new SqlCommand(s,con);

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                comboBox1.Items.Add(rd["order"]);

            }





            rd.Close();
            rd.Dispose();
            con.Close();


        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {
                
                SqlCommand cmd = new SqlCommand("p9",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                
                //SqlCommand c = new SqlCommand("delete from nursingstation where arabic name='" + comboBox1.ValueMember + "'  ", conn);
                //c.ExecuteNonQuery();
                //MessageBox.Show("تم الحذف");
            }
            catch (Exception)
            {


                MessageBox.Show("لم يتم الحذف");
            }
            finally
            {
                con.Close();
            }


        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nursing_statio_Load_1(object sender, EventArgs e)
        {
            //conn = new SqlConnection(connString);
            loodNursingplace();
        }

    }
}