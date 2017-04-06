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
    public partial class حجز_مريض_داخلى : Form
    {


        SqlCommand cmd;
     
        private int id;
        Connection con = new Connection();
        
        public حجز_مريض_داخلى()
        {
          
            InitializeComponent();
        }

        public حجز_مريض_داخلى(int id)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.id = id;
          
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("reservation_show16", con.con);
            try
            {
     cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id",id);
               var k=   cmd.Parameters.Add("@pa_id22", SqlDbType.Int);
               k.Direction = ParameterDirection.Output;
            var a=    cmd.Parameters.Add("@direc",SqlDbType.VarChar,255);
            a.Direction = ParameterDirection.Output;
              var b=  cmd.Parameters.Add("@nationality",SqlDbType.VarChar,255);
                b.Direction = ParameterDirection.Output;
                var c=cmd.Parameters.Add("@gender",SqlDbType.VarChar,255);
                c.Direction = ParameterDirection.Output;
               var n = cmd.Parameters.Add("@age",SqlDbType.VarChar,255);
                n.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 255);
                f.Direction = ParameterDirection.Output;
              var g=     cmd.Parameters.Add("@birth_date",SqlDbType.VarChar,255);

                g.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox27.Text = f.Value.ToString();
                textBox21.Text = k.Value.ToString();
                textBox22.Text = a.Value.ToString();
                textBox23.Text = b.Value.ToString();
                textBox24.Text = c.Value.ToString();
                textBox32.Text = g.Value.ToString();
                textBox29.Text = n.Value.ToString();
            }
            catch (Exception ex)
               
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            con.OpenConection();
            SqlCommand cmd = new SqlCommand("reservation6", con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@an", textBox1.Text);
                cmd.Parameters.AddWithValue("@enter_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ex_leave", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@cat_id", textBox3.Text);
                cmd.Parameters.AddWithValue("@doc", textBox14.Text);
                cmd.Parameters.AddWithValue("@doc_code", textBox12.Text);
                cmd.Parameters.AddWithValue("@sec_doc", textBox15.Text);
                cmd.Parameters.AddWithValue("@sec_doc_code", textBox12.Text);
                cmd.Parameters.AddWithValue("@trans_doc", textBox18.Text);
                cmd.Parameters.AddWithValue("@trans_doc_code", textBox16.Text);
                cmd.Parameters.AddWithValue("@esta_id", textBox17.Text);
                cmd.Parameters.AddWithValue("@spe_id", textBox9.Text);
                cmd.Parameters.AddWithValue("@bed", textBox46.Text);
                cmd.Parameters.AddWithValue("@bed_num", textBox47.Text);
                cmd.Parameters.AddWithValue("@op_name", textBox42.Text);
                cmd.Parameters.AddWithValue("@prim_dig", textBox44.Text);
                cmd.Parameters.AddWithValue("@inter_source_name", textBox20.Text);
                cmd.Parameters.AddWithValue("@doc_father", textBox49.Text);
                cmd.Parameters.AddWithValue("@doc_state", comboBox3.Text);
                cmd.Parameters.AddWithValue("@learning_state", comboBox4.Text);
                cmd.Parameters.AddWithValue("@dif_state", comboBox5.Text);
                cmd.Parameters.AddWithValue("@par", comboBox6.Text);
                cmd.Parameters.AddWithValue("@blode_pre", comboBox7.Text);
                cmd.Parameters.AddWithValue("@dipec", comboBox8.Text);
                cmd.Parameters.AddWithValue("@lever", comboBox9.Text);
                cmd.Parameters.AddWithValue("@sens", comboBox13.Text);
                cmd.Parameters.AddWithValue("@heart_dis", comboBox10.Text);
                cmd.Parameters.AddWithValue("@articulat", comboBox11.Text);
                cmd.Parameters.AddWithValue("@blood_dis", comboBox12.Text);
                cmd.Parameters.AddWithValue("@manual_num", textBox41.Text);
                cmd.Parameters.AddWithValue("@regis_pri", comboBox2.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            حجز_طبيب ooo = new حجز_طبيب();
            if (ooo.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = حجز_طبيب.Code1.ToString();
                textBox15.Text = حجز_طبيب.Code2.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ااقامه ii = new ااقامه();
            if (ii.ShowDialog() == DialogResult.OK)
            {
                textBox17.Text = ااقامه.Code1.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            حجز_طبيب y = new حجز_طبيب();
            if (y.ShowDialog() == DialogResult.OK)
            {
                textBox12.Text = حجز_طبيب.Code1.ToString();
                textBox14.Text = حجز_طبيب.Code2.ToString();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            حجز_طبيب dd = new حجز_طبيب();
            if (dd.ShowDialog() == DialogResult.OK)
            {
                textBox16.Text = حجز_طبيب.Code1.ToString();
                textBox18.Text = حجز_طبيب.Code2.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
          تخصص f = new تخصص();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = تخصص.Code1.ToString();
                textBox11.Text = تخصص.Code2.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            درجه_الاقامه yu = new درجه_الاقامه();
            yu.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            حجز_سرير we = new حجز_سرير();
            if (we.ShowDialog() == DialogResult.OK)
            {
                textBox47.Text = حجز_سرير.Code1.ToString();
                textBox46.Text = حجز_سرير.Code2.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            مصادر_الدخول io = new مصادر_الدخول();
           
            if (io.ShowDialog() == DialogResult.OK)
            {
                textBox20.Text = مصادر_الدخول.Code1.ToString();
                textBox8.Text = مصادر_الدخول.Code2.ToString();
            }
        }


        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            جهاااااات we = new جهاااااات();
            if (we.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = جهاااااات.Code1.ToString();
                textBox10.Text = جهاااااات.Code2.ToString();
            }

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            جهااات_فرعيه we = new جهااات_فرعيه();
            if (we.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = جهااات_فرعيه.Code1.ToString();
                textBox11.Text = جهااات_فرعيه.Code2.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            العمليه we = new العمليه();
            if (we.ShowDialog() == DialogResult.OK)
            {
                textBox47.Text = العمليه.Code1.ToString();
                textBox46.Text = العمليه.Code2.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String d1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            String d2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show(" التاريخ الاول يجب ان يكون اقل من الثانى ");



            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox47_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

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