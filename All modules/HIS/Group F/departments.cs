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
    public partial class departments : Form
    {


        Connection con = new Connection();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public departments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("add_departement", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", textBox3.Text);
                cmd.Parameters.AddWithValue("manager", textBox4.Text);
                cmd.Parameters.AddWithValue("phone", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال القسم بنجاح");
                textBox1.Text="";
                    textBox3.Text="";
                        textBox4.Text="";
                        textBox5.Text = "";

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
            con.CloseConnection();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void departments_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("update_departement", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("code", Int32.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("name", textBox3.Text);
                cmd.Parameters.AddWithValue("manager", textBox4.Text);
                cmd.Parameters.AddWithValue("phone", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تعديل القسم بنجاح");
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;
            string name = this.textBox3.Text;
            departements_search frm = new departements_search();
            frm.showdi(ref code, ref name);
            this.textBox3.Text = name;
            this.textBox1.Text = code;
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("fill_departement", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("code", Int32.Parse(textBox1.Text));
                var b = cmd.Parameters.Add("name", SqlDbType.VarChar, 255);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("manager", SqlDbType.VarChar, 255);
                c.Direction = ParameterDirection.Output;
                var d = cmd.Parameters.Add("phone", SqlDbType.VarChar, 255);
                d.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox3.Text = b.Value.ToString();
                textBox4.Text = c.Value.ToString();
                textBox5.Text = d.Value.ToString();
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }



            con.CloseConnection();
        }

        
    }
}
