using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class TRAINING_FRM_ADVERTISING : Form
    {
        string s, m, r, o;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        DataSet ds;
        Connection connect;
        TRAINING_FRM_CENTER_NAME f02;
        TRAINING_FRM_COURSES_NAME f1;
        TRAINING_FRM_TRAINNER_NAME f2;
        public TRAINING_FRM_ADVERTISING()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f02 = new TRAINING_FRM_CENTER_NAME();
            f02.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();
                string[] words = dt.Split(' ');
                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox2.Text = x;
            textBox1.Text = y;

        }
        public void setvalue1(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox4.Text = x;
            textBox3.Text = y;

        }
        public void setvalue2(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox5.Text = x;
            textBox6.Text = y;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            f1 = new TRAINING_FRM_COURSES_NAME();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2 = new TRAINING_FRM_TRAINNER_NAME();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TRAINING_FRM_ADVERTISING_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();
                string[] words = dt.Split(' ');
                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();
                string[] words = dt.Split(' ');
                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();
                string[] words = dt.Split(' ');
                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            //con = new SqlConnection("server=localhost;database=h;pwd=root;uid=root");
            //con.Open();
            connect.OpenConection();
            cmd = new SqlCommand();
            // cmd.Connection = connect;
            cmd.CommandText = "insert into course(center_code,course_name,startbooking,endbooking,startcourse,endcourse,trainer_code,numdayofabstence,numofhours,allcost,numberoftrainee,percentage,notes ) values('" + textBox2.Text + "','" + textBox3.Text + "','" + s + "','" + m + "','" + r + "','" + o + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox13.Text + " ')";
            // MessageBox.Show(dateTimePicker4.Value.Date.ToString());
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("insert sucess");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox7.Text = "";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox8.Text = "";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox9.Text = "";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox12.Text = "";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox11.Text = "";
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkArabicName(textBox13.Text))
            {
                MessageBox.Show("قم بادخال الاسم بالعربى");
            }
        }
    }
}
