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
    public partial class نقل_مرافق_من_سرير_لاخر : Form
    {
        SqlCommand cmd;

        private int id;
        Connection con = new Connection();

        public نقل_مرافق_من_سرير_لاخر()
        {
            InitializeComponent();
        }

        public نقل_مرافق_من_سرير_لاخر(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void نقل_مرافق_من_سرير_لاخر_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("trans_partner_to_another_bed", con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);
                var k = cmd.Parameters.Add("@pa_id22", SqlDbType.Int);
                k.Direction = ParameterDirection.Output;
                var a = cmd.Parameters.Add("@direc", SqlDbType.VarChar, 255);
                a.Direction = ParameterDirection.Output;
                var b = cmd.Parameters.Add("@nationality", SqlDbType.VarChar, 40);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("@gender", SqlDbType.VarChar, 40);
                c.Direction = ParameterDirection.Output;
                var n = cmd.Parameters.Add("@age", SqlDbType.VarChar, 255);
                n.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 255);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@birth_date", SqlDbType.VarChar, 255);
                g.Direction = ParameterDirection.Output;
                var gg = cmd.Parameters.Add("@sn", SqlDbType.Int);
                gg.Direction = ParameterDirection.Output;
                var ggg = cmd.Parameters.Add("@pp", SqlDbType.Date);
                ggg.Direction = ParameterDirection.Output;
                var gggf = cmd.Parameters.Add("@hm", SqlDbType.VarChar,40);
                gggf.Direction = ParameterDirection.Output;
                var go = cmd.Parameters.Add("@ar", SqlDbType.VarChar,40);
                go.Direction = ParameterDirection.Output;
                var goo = cmd.Parameters.Add("@nu", SqlDbType.VarChar, 40);
                goo.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                    textBox18.Text = f.Value.ToString();
                    textBox17.Text = k.Value.ToString();
                    textBox16.Text = a.Value.ToString();
                    textBox15.Text = b.Value.ToString();
                    textBox14.Text = c.Value.ToString();
                    textBox22.Text = g.Value.ToString();
                    textBox21.Text = n.Value.ToString();

                    textBox6.Text = gg.Value.ToString();
                    dateTimePicker2.Value = (DateTime)ggg.Value;
                    textBox3.Text = gggf.Value.ToString();
                    textBox5.Text = go.Value.ToString();
                    textBox9.Text = goo.Value.ToString();
                }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();

            }
        

        private void button1_Click(object sender, EventArgs e)
        {
            سرير_مرافق f = new سرير_مرافق();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox19.Text = سرير_مرافق.Code1.ToString();
                textBox20.Text = سرير_مرافق.Code2.ToString();
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {



            con.OpenConection();
            SqlCommand cmd = new SqlCommand("trans_par_out", con.con);
            try
            {
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ssn", textBox1.Text);
                cmd.Parameters.AddWithValue("@en", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@n_of_room", textBox11.Text);
                cmd.Parameters.AddWithValue("@n_of_bed", textBox19.Text);
                cmd.Parameters.AddWithValue("@ns", textBox10.Text);
                cmd.Parameters.AddWithValue("@dg_name", textBox23.Text);
                cmd.Parameters.AddWithValue("@dg_code", textBox2.Text);
                cmd.Parameters.AddWithValue("@na_of_bed", textBox20.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            اقامه_مرافق f = new اقامه_مرافق();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = اقامه_مرافق.Code1.ToString();
                textBox23.Text = اقامه_مرافق.Code2.ToString();
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
