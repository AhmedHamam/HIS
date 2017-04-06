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
    public partial class تعديل_بيانات_الحجز_لمريض : Form
    {
     
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();

        public تعديل_بيانات_الحجز_لمريض()
        {
            InitializeComponent();
        }
         public تعديل_بيانات_الحجز_لمريض(int id)
        {
            InitializeComponent();
             this.id=id;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            مصادر_الدخول f = new مصادر_الدخول();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = مصادر_الدخول.Code1.ToString();
                textBox5.Text = مصادر_الدخول.Code2.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            الاطباء_1 f = new الاطباء_1();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = الاطباء_1.Code1.ToString();
                textBox6.Text = الاطباء_1.Code2.ToString();
            }
        }

       

        private void تعديل_بيانات_الحجز_لمريض_Load(object sender, EventArgs e)
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
                textBox17.Text = f.Value.ToString();
                //textBox1.Text = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40).ToString();
                textBox14.Text = b.Value.ToString();
                textBox16.Text = a.Value.ToString();
                textBox15.Text = c.Value.ToString();
                textBox21.Text = g.Value.ToString();
                textBox20.Text = n.Value.ToString();
                textBox1.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                con.OpenConection();
            SqlCommand cmd = new SqlCommand("modify_res_patient", con.con);
            try
            {
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@interance_date",dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@expected_date_for_leaving ", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@source_of_entrance_code", textBox2.Text);
                cmd.Parameters.AddWithValue("@source_of_entrance_name", textBox5.Text);
                cmd.Parameters.AddWithValue("@doctor_code", textBox3.Text);
                cmd.Parameters.AddWithValue("@doctor", textBox6.Text);
                cmd.Parameters.AddWithValue("@primary_diagnoses", textBox8.Text);
                cmd.Parameters.AddWithValue("@guarantor_name", textBox9.Text);
                cmd.Parameters.AddWithValue("@guarantor_address", textBox10.Text);
                cmd.Parameters.AddWithValue("@guarantor_telephone", textBox13.Text);
                cmd.Parameters.AddWithValue("@relative_degree", comboBox1.Text);
                cmd.Parameters.AddWithValue("@last_modification_with", textBox11.Text);
                cmd.Parameters.AddWithValue("@last_modify", dateTimePicker3.Value);
               
                
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
             
            if (!char.IsLetter(e.KeyChar) || e.KeyChar==(char)Keys.Back||(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل حروف !");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& (e.KeyChar!='.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
    }
}
 