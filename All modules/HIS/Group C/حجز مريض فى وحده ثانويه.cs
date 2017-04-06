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
    public partial class حجز_مريض_فى_وحده_ثانويه : Form
    {
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();

        public حجز_مريض_فى_وحده_ثانويه()
        {
            InitializeComponent();
        }
        public حجز_مريض_فى_وحده_ثانويه(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void حجز_مريض_فى_وحده_ثانويه_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            cmd = new SqlCommand("hold_patient_secondry_unit", con.con);
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
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("@birth_date", SqlDbType.VarChar, 40);
                g.Direction = ParameterDirection.Output;
                var y= cmd.Parameters.Add("@nursing_station", SqlDbType.VarChar, 40);
                y.Direction = ParameterDirection.Output;
                var yy = cmd.Parameters.Add("@from_date", SqlDbType.Date);
                yy.Direction = ParameterDirection.Output;
                var oy = cmd.Parameters.Add("@to_date", SqlDbType.Date);
                oy.Direction = ParameterDirection.Output;
                var p= cmd.Parameters.Add("@number_of_room", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                var t = cmd.Parameters.Add("@number_of_bed", SqlDbType.Int);
                t.Direction = ParameterDirection.Output;
                var oi = cmd.Parameters.Add("@estab_deg_code", SqlDbType.Int);
                oi.Direction = ParameterDirection.Output;

                var oii = cmd.Parameters.Add("@estab_deg_name", SqlDbType.VarChar,40);
                oii.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
              
                textBox18.Text = f.Value.ToString();
                textBox17.Text = k.Value.ToString();
                textBox16.Text = a.Value.ToString();
                textBox15.Text = b.Value.ToString();
                textBox14.Text = c.Value.ToString();
                textBox22.Text = g.Value.ToString();
                textBox21.Text = n.Value.ToString();

               
                textBox4.Text = y.Value.ToString();
                textBox5.Text = p.Value.ToString();
                textBox1.Text = t.Value.ToString();
                textBox2.Text = oi.Value.ToString();
                textBox3.Text = oii.Value.ToString();
                dateTimePicker2.Value = (DateTime)yy.Value;
               dateTimePicker1.Value = (DateTime)oy.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            cmd = new SqlCommand("cancel_exit_info");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);

                cmd.Parameters.AddWithValue("@en",dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@n_of_bed", textBox10.Text);
                cmd.Parameters.AddWithValue("@n_of_room",textBox6.Text);
                cmd.Parameters.AddWithValue("@ns", textBox7.Text);
                cmd.Parameters.AddWithValue("@dg_code", textBox8.Text);
                cmd.Parameters.AddWithValue("@dg_name", textBox9.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("saved !");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            con.CloseConnection();
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
            //textBox11.Text = null;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    الاقامهcs f = new الاقامهcs();


        //    if (f.ShowDialog() == DialogResult.OK)
        //    {
        //        textBox2.Text = الاقامهcs.Code1.ToString();
        //        textBox3.Text = الاقامهcs.Code2.ToString();
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            الاقامه1 f = new الاقامه1();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = الاقامه1.Code1.ToString();
                textBox9.Text = الاقامه1.Code2.ToString();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
