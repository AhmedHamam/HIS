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
    public partial class نقل_المريض_من_سرير_لاخر : Form
    {
      SqlCommand cmd;
        public int id;
        Connection con = new Connection();

        public نقل_المريض_من_سرير_لاخر()
        {
            InitializeComponent();
        }
         public نقل_المريض_من_سرير_لاخر(int id)
        {
            InitializeComponent();
            this.id = id;
           
        }

       

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void حفظ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("pp", con.con);
            try
            {
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@doc", textBox18.Text);
                cmd.Parameters.AddWithValue("@doc_id", textBox13.Text);
                cmd.Parameters.AddWithValue("@n_of_room", textBox16.Text);
                cmd.Parameters.AddWithValue("@n_of_bed", textBox21.Text);
                cmd.Parameters.AddWithValue("@na_of_bed", textBox20.Text);
                cmd.Parameters.AddWithValue("@dg_code", textBox4.Text);
                cmd.Parameters.AddWithValue("@dg_name", textBox7.Text);
                cmd.Parameters.AddWithValue("@ns", textBox15.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            سريير f = new سريير();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox21.Text = سريير.Code1.ToString();
                textBox20.Text = سريير.Code2.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            اقاااامه f = new اقاااامه();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = اقاااامه.Code1.ToString();
                textBox7.Text = اقاااامه.Code2.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             اطباااء f = new اطباااء();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = اطباااء.Code1.ToString();
                textBox18.Text = اطباااء.Code2.ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void نقل_المريض_من_سرير_لاخر_Load(object sender, EventArgs e)
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
                textBox6.Text = f.Value.ToString();
                textBox5.Text = b.Value.ToString();
                textBox2.Text = a.Value.ToString();
                textBox3.Text = c.Value.ToString();
                textBox17.Text = g.Value.ToString();
                textBox8.Text = n.Value.ToString();
                textBox1.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();

            con.OpenConection();
            cmd = new SqlCommand("trans_p_another_bed");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);
                var a = cmd.Parameters.Add("@f_date", SqlDbType.Date);
                a.Direction = ParameterDirection.Output;
                var b = cmd.Parameters.Add("@t_date", SqlDbType.Date);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("@nur", SqlDbType.VarChar, 40);
                c.Direction = ParameterDirection.Output;
                var n = cmd.Parameters.Add("@es_deg_name", SqlDbType.VarChar, 40);
                n.Direction = ParameterDirection.Output;
                var nn = cmd.Parameters.Add("@es_deg_code", SqlDbType.Int);
                nn.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@n_of_bed", SqlDbType.Int);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@n_of_room", SqlDbType.Int);
                g.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                textBox9.Text = c.Value.ToString();
                textBox14.Text = n.Value.ToString();
                textBox12.Text = nn.Value.ToString();
                textBox11.Text = f.Value.ToString();
                textBox10.Text = g.Value.ToString();
                dateTimePicker1.Value = (DateTime)a.Value;
                dateTimePicker2.Value = (DateTime)b.Value;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }



        }
    }
}
