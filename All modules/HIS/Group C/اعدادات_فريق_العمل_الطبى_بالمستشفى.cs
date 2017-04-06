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
    public partial class اعدادات_فريق_العمل_الطبى_بالمستشفى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand();
        public اعدادات_فريق_العمل_الطبى_بالمستشفى()
        {
            InitializeComponent();
        }

        public اعدادات_فريق_العمل_الطبى_بالمستشفى(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8)
        {
            InitializeComponent();
            textBox5.Text = s1.ToString();
            textBox1.Text = s2.ToString();
            textBox4.Text = s3.ToString();
            textBox3.Text = s4.ToString();
            textBox10.Text = s5.ToString();
            textBox8.Text = s6.ToString();
            textBox9.Text = s7.ToString();
            textBox2.Text = s8.ToString();
        }

        private void اعدادات_فريق_العمل_الطبى_بالمستشفى_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            فريق_العمل1 f = new فريق_العمل1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = فريق_العمل1.Code2.ToString();
             
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
          
            if ((checkBox1.Checked == true & d.Length != 0 & d2.Length != 0) & (textBox6.Text.Length != 0 & textBox7.Text.Length != 0))
            {

                try
                {
                    cmd = new SqlCommand("select employee.emp_id as 'الكود',employee.name as'الاسم',career_name as'الوظيفة', departement.name as'القسم' ,admin_name as'الادارة' from  employee ,departement,adminstration  where  employee.emp_id=adminstration.emp_id  and employee.emp_id between @x  and @y  and employee.date_staffing between @l and @m ", con.con);
                    cmd.Parameters.AddWithValue("@x", textBox6.Text);
                    cmd.Parameters.AddWithValue("@y", textBox7.Text);
                    cmd.Parameters.AddWithValue("@l", d);
                    cmd.Parameters.AddWithValue("@m", d2);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }

            else if (textBox6.Text.Length != 0 & textBox7.Text.Length != 0)
            {

                try
                {
                    cmd = new SqlCommand("select employee.emp_id as 'الكود',employee.name as'الاسم',career_name as'الوظيفة', departement.name as'القسم' ,admin_name as'الادارة' from  employee ,departement,adminstration where  employee.emp_id=adminstration.emp_id  and employee.emp_id between @x and @y", con.con);
                    cmd.Parameters.AddWithValue("@x", textBox6.Text);
                    cmd.Parameters.AddWithValue("@y", textBox7.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }

            else if (checkBox1.Checked == true & d.Length != 0 & d2.Length != 0)
            {

                try
                {
                    cmd = new SqlCommand("select employee.emp_id as 'الكود',employee.name as'الاسم',career_name as'الوظيفة', departement.name as'القسم' ,admin_name as'الادارة' from  employee ,departement,adminstration  where  employee.emp_id=adminstration.emp_id and  employee.date_staffing between  @l and @m ", con.con);
                    cmd.Parameters.AddWithValue("@l", d);
                    cmd.Parameters.AddWithValue("@m", d2);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
            else
            {

                try
                {
                    cmd = new SqlCommand("select employee.emp_id as 'الكود',employee.name as'الاسم',career_name as'الوظيفة', departement.name as'القسم' ,admin_name as'الادارة' from  employee ,departement,adminstration  where employee.emp_id=adminstration.emp_id  and employee.name =@z", con.con);
                    cmd.Parameters.AddWithValue("@z", textBox5.Text);

                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox7.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
