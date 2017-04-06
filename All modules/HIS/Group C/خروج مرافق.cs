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
    public partial class خروج_مرافق : Form
    {
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();
        public خروج_مرافق()
        {
            InitializeComponent();
        }
  public خروج_مرافق(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void خروج_مرافق_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            cmd = new SqlCommand("data_of_patient");
            try
            {
                cmd.Connection = con.con;
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
                var n = cmd.Parameters.Add("@age", SqlDbType.Int);
                n.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@birth_date", SqlDbType.VarChar, 40);
                g.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox4.Text = f.Value.ToString();
                textBox8.Text = b.Value.ToString();
                textBox2.Text = a.Value.ToString();
                textBox3.Text = c.Value.ToString();
                textBox7.Text = g.Value.ToString();
                textBox6.Text = n.Value.ToString();
                textBox1.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            try
            {
                SqlCommand cmd = new SqlCommand("exit_par", con.con);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ssn", textBox9.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف المرافق");
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
