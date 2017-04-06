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
    public partial class الغاء_نقل_مريض_لسرير_اخر : Form
    {
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();

        public الغاء_نقل_مريض_لسرير_اخر()
        {
            InitializeComponent();
        }
        public الغاء_نقل_مريض_لسرير_اخر(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void label29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            
        }

        private void label25_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("cancel_update", con.con);
            try
            {
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@f_date",dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@n_of_room", textBox6.Text);
                cmd.Parameters.AddWithValue("@n_of_bed", textBox10.Text);
                cmd.Parameters.AddWithValue("@na_of_bed", textBox11.Text);
                cmd.Parameters.AddWithValue("@dg_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@dg_code", textBox8.Text);
                cmd.Parameters.AddWithValue("@ns", textBox7.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void الغاء_نقل_مريض_لسرير_اخر_Load(object sender, EventArgs e)
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
                // MessageBox.Show(f.Value.ToString());
                g.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox18.Text = f.Value.ToString();
                //textBox1.Text = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40).ToString();
                textBox15.Text = b.Value.ToString();
                textBox16.Text = a.Value.ToString();
                textBox14.Text = c.Value.ToString();
                textBox22.Text = g.Value.ToString();
                textBox21.Text = n.Value.ToString();
                textBox17.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();

            con.OpenConection();
            cmd = new SqlCommand("cancel_trans_p_another_bed");
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
                var f = cmd.Parameters.Add("@n_of_bed", SqlDbType.Int);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@n_of_room", SqlDbType.Int);
                g.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                textBox4.Text = c.Value.ToString();
                textBox1.Text = f.Value.ToString();
                textBox5.Text = g.Value.ToString();
                dateTimePicker2.Value = (DateTime)a.Value;
                dateTimePicker1.Value = (DateTime)b.Value;

                MessageBox.Show("  vkd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            سرير i = new سرير();
            if (i.ShowDialog() == DialogResult.OK)
            {
                textBox10.Text = سرير.Code1.ToString();
                textBox11.Text = سرير.Code2.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            الاقامهcs i = new الاقامهcs();
            if (i.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = الاقامهcs.Code1.ToString();
                textBox2.Text = الاقامهcs.Code2.ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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
