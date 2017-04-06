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
    public partial class تسجيل_الوفيات : Form
    {


        SqlCommand cmd;
        public int id;
        Connection con = new Connection();
        private int id_2;

      
        public تسجيل_الوفيات()
        {
            InitializeComponent();
        }

        public تسجيل_الوفيات(int id)
        {
            InitializeComponent();
            this.id= id;
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void تسجيل_الوفيات_Load(object sender, EventArgs e)
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

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void حفظ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("death_reg", con.con);
            try
            {
                cmd.Parameters.AddWithValue("@pa_id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SSN", textBox2.Text);
                cmd.Parameters.AddWithValue("@expected_dead ", comboBox8.Text);
                cmd.Parameters.AddWithValue("@die_during_10_days_of_exit", comboBox9.Text);
                cmd.Parameters.AddWithValue("@doctor", textBox3.Text);
                cmd.Parameters.AddWithValue("@doctor_name", textBox6.Text);
                cmd.Parameters.AddWithValue("@die_related_to_operation", comboBox7.Text);
                cmd.Parameters.AddWithValue("@diagnoses", textBox4.Text);
                cmd.Parameters.AddWithValue("@direct_cause_of_die", textBox5.Text);
                cmd.Parameters.AddWithValue("@undirect_cause_of_die", textBox7.Text);
                cmd.Parameters.AddWithValue("@disease_has_relation_with_death", textBox8.Text);
                cmd.Parameters.AddWithValue("@surgery", comboBox5.Text);
                cmd.Parameters.AddWithValue("@under_hospital_manage", comboBox4.Text);
                cmd.Parameters.AddWithValue("@criminal_suspicion", comboBox1.Text);
                cmd.Parameters.AddWithValue("@reported_who_care", comboBox3.Text);
                cmd.Parameters.AddWithValue("@require_police_reported", comboBox2.Text);
                cmd.Parameters.AddWithValue("@notes", textBox1.Text);
                cmd.Parameters.AddWithValue("@nurse", textBox10.Text);
                cmd.Parameters.AddWithValue("@age", textBox11.Text);
                
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            طبيب_الوفاه f = new طبيب_الوفاه();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = طبيب_الوفاه.Code1.ToString();
                textBox6.Text = طبيب_الوفاه.Code2.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(textBox2.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(textBox11.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
