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
    public partial class دخول_تحركات_المريض : Form
    {
        
        DataSet ds = new DataSet();
        List<string> l1 = new List<string>();

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public دخول_تحركات_المريض()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            //con.Open();
            //string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //cmd = new SqlCommand("assigne_to_thetable", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@x", textBox1.Text);
            //cmd.Parameters.AddWithValue("@y", textBox5.Text);
            //cmd.Parameters.AddWithValue("@z", textBox3.Text);
            //cmd.Parameters.AddWithValue("@f",date);
            /////////////////pro
            //cmd.ExecuteNonQuery();
           // SqlDataReader dr = cmd.ExecuteReader();


            //create procedure assigne_to_thetable(@x int,@y int,@z varchar(80) ,@f  varchar(40))
            //as
            //insert into user_patient values
            //(@x,@y,@z,@f);


            //create procedure insert_user_patient(@x int,@y int,@z datetime,@i varchar(80))
            //as
            //begin
            //            insert into user_patient values(@x,@y,@z,@i)
            //end

            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.DateTime, SqlDbType.DateTime };
            name_input = new string[] { "@x", "@y", "@z", "@i" };
            values = new string[] { textBox1.Text, textBox5.Text, textBox3.Text ,date};
            con1.ExecuteNonQueryProcedure("insert_user_patient", name_input, values, types);
            con1.CloseConnection();

            
            MessageBox.Show("تم الحفظ");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            l1.Clear();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void check_number_num_pat(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_number_emp(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_place(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

    }
}
