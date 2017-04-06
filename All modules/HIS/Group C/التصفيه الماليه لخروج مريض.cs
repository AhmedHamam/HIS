using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class التصفيه_الماليه_لخروج_مريض : Form
    {


        SqlCommand cmd;

        private int id;
        Connection con = new Connection();

        public التصفيه_الماليه_لخروج_مريض()
        {
            InitializeComponent();
        }

        public التصفيه_الماليه_لخروج_مريض(int id)
        {
            
            InitializeComponent();
            this.id = id;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void التصفيه_الماليه_لخروج_مريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("settle_finance", con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);
                var k = cmd.Parameters.Add("@pa_id22", SqlDbType.Int);
                k.Direction = ParameterDirection.Output;
                var a = cmd.Parameters.Add("@direc", SqlDbType.VarChar, 40);
                a.Direction = ParameterDirection.Output;
                var b = cmd.Parameters.Add("@nationality", SqlDbType.VarChar, 40);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("@gender", SqlDbType.VarChar, 40);
                c.Direction = ParameterDirection.Output;
                var n = cmd.Parameters.Add("@age", SqlDbType.VarChar, 40);
                n.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@birth_date", SqlDbType.VarChar, 40);
                g.Direction = ParameterDirection.Output;
                var ll = cmd.Parameters.Add("@nu_station", SqlDbType.VarChar, 40);
                ll.Direction = ParameterDirection.Output;
                var lm = cmd.Parameters.Add("@n_of_room", SqlDbType.VarChar, 40);
                lm.Direction = ParameterDirection.Output;
                var lo = cmd.Parameters.Add("@cat_id", SqlDbType.VarChar, 40);
                lo.Direction = ParameterDirection.Output;
                var lu = cmd.Parameters.Add("@pa_name", SqlDbType.VarChar, 40);
                lu.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                textBox12.Text = f.Value.ToString();
                textBox7.Text = k.Value.ToString();
                textBox8.Text = a.Value.ToString();
                textBox9.Text = b.Value.ToString();
                textBox10.Text = c.Value.ToString();
                textBox15.Text = g.Value.ToString();
                textBox14.Text = n.Value.ToString();
                 textBox4.Text = ll.Value.ToString();
                textBox3.Text = lo.Value.ToString();
                textBox5.Text = lu.Value.ToString();
                textBox6.Text = lm.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //con.OpenConection();
            //SqlCommand cmd = new SqlCommand("settle_finance", con.con);
            //try
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
                
               

            //    cmd.ExecuteNonQuery();
            ////}

            ////catch (Exception ee)
            ////{
            ////    MessageBox.Show(ee.Message);
            ////}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            SqlCommand cmd = new SqlCommand("s_f", con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);


                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت التصفيه الماليه");
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
