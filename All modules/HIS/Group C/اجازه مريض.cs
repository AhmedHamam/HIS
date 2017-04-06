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
    public partial class اجازه_مريض : Form
    {
        

        private int id;
        Connection con = new Connection();

        public اجازه_مريض()
        {
            InitializeComponent();

        }

        public اجازه_مريض(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label21_Click(object sender, EventArgs e)
        {
          //  textBox1.Text = null;
            textBox2.Text = null;
          //  textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
          //  textBox6.Text = null;
          //  textBox7.Text = null;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void اجازه_مريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("vacanse_out",con.con);
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
                var n = cmd.Parameters.Add("@age", SqlDbType.Int);
                n.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar,40);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@birth_date", SqlDbType.VarChar,40);
                g.Direction = ParameterDirection.Output;
               

                cmd.ExecuteNonQuery();
                textBox14.Text = f.Value.ToString();
                textBox8.Text = k.Value.ToString();
                textBox9.Text = a.Value.ToString();
                textBox10.Text = b.Value.ToString();
                textBox11.Text = c.Value.ToString();
                textBox16.Text = g.Value.ToString();
                textBox15.Text = n.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            الاطباء_1 f = new الاطباء_1();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = الاطباء_1.Code1.ToString();
                textBox2.Text = الاطباء_1.Code2.ToString();
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("vacanse_in",con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.Parameters.AddWithValue("@from_peri", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@to_peri", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@cause", textBox4.Text);
                cmd.Parameters.AddWithValue("@doc_code", textBox5.Text);
                cmd.Parameters.AddWithValue("@doc_name", textBox2.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            MessageBox.Show("تم الحفظ");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}