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
    public partial class حجز_وتعديل_المرافقين : Form
    {
        SqlCommand cmd;
        public int id;
        Connection con = new Connection();

        public حجز_وتعديل_المرافقين()
        {
            InitializeComponent();
        }
        public حجز_وتعديل_المرافقين(int id)
        {
            InitializeComponent();
            this.id = id;

        }

        private void حجز_وتعديل_المرافقين_Load(object sender, EventArgs e)
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
                textBox4.Text = f.Value.ToString();
                //textBox1.Text = cmd.Parameters.Add("@date_Re", SqlDbType.VarChar, 40).ToString();
                textBox8.Text = b.Value.ToString();
                textBox2.Text = a.Value.ToString();
                textBox3.Text = c.Value.ToString();
                textBox7.Text = g.Value.ToString();
                textBox6.Text = n.Value.ToString();
                textBox1.Text = k.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Connection.Close();
            con.CloseConnection();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("help!");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



            con.OpenConection();
            
            try
            {
                if (radioButton1.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("hold_partner", con.con);

                    cmd.Parameters.AddWithValue("@pa_id", id);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@medical_partner", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@entrance_date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@out_date", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@type ", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@job", textBox24.Text);
                    cmd.Parameters.AddWithValue("@SSN", textBox19.Text);
                    cmd.Parameters.AddWithValue("@name_in_English", textBox14.Text);
                    cmd.Parameters.AddWithValue("@name_in_arabic", textBox18.Text);
                    cmd.Parameters.AddWithValue("@partener_code", textBox10.Text);
                    cmd.Parameters.AddWithValue("@has_meal", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@type_of_establishment", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@diet", textBox5.Text);

                    cmd.ExecuteNonQuery();
                }
                else if (radioButton2.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("modify_partner", con.con);


                    cmd.Parameters.AddWithValue("@pa_id", id);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@medical_partner", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@entrance_date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@out_date", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@type ", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@job", textBox24.Text);
                    cmd.Parameters.AddWithValue("@SSN", textBox19.Text);
                    cmd.Parameters.AddWithValue("@name_in_English", textBox14.Text);
                    cmd.Parameters.AddWithValue("@name_in_arabic", textBox18.Text);
                    cmd.Parameters.AddWithValue("@partener_code", textBox10.Text);
                    cmd.Parameters.AddWithValue("@has_meal", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@type_of_establishment", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@diet", textBox5.Text);

                    cmd.ExecuteNonQuery();



                }

                else { MessageBox.Show("choose reservatin or modify"); }

            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }




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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String d1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            String d2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show(" التاريخ الاول يجب ان يكون اقل من الثانى ");
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل حروف !");
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل حروف !");
            }
        }

    }
}