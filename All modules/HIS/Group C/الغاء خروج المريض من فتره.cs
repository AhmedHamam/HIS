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
    public partial class الغاء_خروج_المريض_من_فتره : Form
    {
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();
       
        public الغاء_خروج_المريض_من_فتره()
        {
            InitializeComponent();
        }

        public الغاء_خروج_المريض_من_فتره(int id )
        {
            InitializeComponent();
            this.id = id;
        }

        private void الغاء_خروج_المريض_من_فتره_Load(object sender, EventArgs e)
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
                textBox20.Text = f.Value.ToString();
                textBox18.Text = b.Value.ToString();
                textBox17.Text = a.Value.ToString();
                textBox19.Text = c.Value.ToString();
                textBox21.Text = g.Value.ToString();
                textBox20.Text = n.Value.ToString();

                textBox16.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();
        }

        private void label26_Click(object sender, EventArgs e)
        {

         
                  con.OpenConection();
            cmd = new SqlCommand("cancel_exit_info");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pa_id", id);

                cmd.Parameters.AddWithValue("@from_period", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@exit_date", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@expected_exit_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@visit_period", textBox3.Text);
                cmd.Parameters.AddWithValue("@primary_diagnoses", textBox4.Text);
                cmd.Parameters.AddWithValue("@ICD_diagnoses", textBox5.Text);
                cmd.Parameters.AddWithValue("@final_diagnoses", textBox7.Text);
                cmd.Parameters.AddWithValue("@doctor_who_performed_to_exit_code", textBox6.Text);
                cmd.Parameters.AddWithValue("@doctor_who_performed_to_exit_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@exit_direction_code", textBox9.Text);
                cmd.Parameters.AddWithValue("@exit_direction", textBox12.Text);
                cmd.Parameters.AddWithValue("@type_of_state", textBox14.Text);
                cmd.Parameters.AddWithValue("@medical_recommend", textBox1.Text);
                cmd.Parameters.AddWithValue("@cause_of_exit", textBox10.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("saved !");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            con.CloseConnection();
        
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            الطبيب_الخروج i = new الطبيب_الخروج();
            if (i.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = الطبيب_الخروج.Code1.ToString();
                textBox2.Text = الطبيب_الخروج.Code2.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            الجهاتت y = new الجهاتت();
            if (y.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = الجهاتت.Code1.ToString();
                textBox12.Text = الجهاتت.Code2.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(textBox3.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(textBox6.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(textBox9.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            String d1 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            String d2 = dateTimePicker3.Value.ToString("dd-MM-yyyy");

            if (dateTimePicker2.Value.Date > dateTimePicker3.Value.Date)
            {
                MessageBox.Show(" التاريخ الاول يجب ان يكون اقل من الثانى ");



            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
