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
    public partial class رجوع_مريض_من_اجازه : Form
    {

       public int id;

         Connection con = new Connection();
     
        public رجوع_مريض_من_اجازه()
        {
            InitializeComponent();
        }

        public رجوع_مريض_من_اجازه(int id )
        {
            InitializeComponent();
            this.id = id;
        }

        private void label19_Click(object sender, EventArgs e)
        {
        
       con.OpenConection();
            SqlCommand cmd = new SqlCommand("comeback_vacanse_in",con.con);
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



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void رجوع_مريض_من_اجازه_Load_1(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("comeback_vacanse_out", con.con);
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
            طبيب_اجازه f = new طبيب_اجازه();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = طبيب_اجازه.Code1.ToString();
                textBox2.Text = طبيب_اجازه.Code2.ToString();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
