using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace HIS
{
    public partial class financial_rep : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        public financial_rep()
        {
            this.WindowState = FormWindowState.Maximized;
            con.OpenConection();
            InitializeComponent();
        }

        private void financial_rep_Load(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox2.Items.Add(dr[0].ToString());
            dr.Close();

            if (comboBox3.Items.Count > 0)
                comboBox3.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox3.Items.Add(dr[0].ToString());
            dr.Close();

            if (comboBox4.Items.Count > 0)
                comboBox4.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox4.Items.Add(dr[0].ToString());
            dr.Close();

            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox1.Items.Add(dr[0].ToString());
            dr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           con.OpenConection();

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                 con.OpenConection();
                 cmd.CommandText = ("SELECT _value as العلاوات, _date as التاريخ FROM employee inner join bonuses on bonuses.emp_id = employee.emp_id where name = '" + comboBox2.SelectedItem + "' order by bonuses._date");
                cmd.Connection = con.con;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                comboBox4.Text = "";
                comboBox3.Text = "";
               // comboBox2.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception )
            {
                MessageBox.Show("خطاء في ادخال الاسم");
            }
            con.CloseConnection();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            try
            {

                SqlCommand cmd = new SqlCommand();
                con.OpenConection();
                cmd.CommandText = ("SELECT _value as الحوافز, _date as التاريخ FROM employee inner join incentives on incentives.emp_id = employee.emp_id where name = '" + comboBox1.SelectedItem + "' order by incentives._date");
                cmd.Connection = con.con;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                comboBox4.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
              //  comboBox1.Text = "";
            }
            catch (Exception )
            {
                MessageBox.Show("خطاء في ادخال الاسم");
            }
            con.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            try
            {

                SqlCommand cmd = new SqlCommand();
                con.OpenConection();
                cmd.CommandText = ("SELECT _value as الخصومات, _date as التاريخ FROM employee inner join deductions on deductions.emp_id = employee.emp_id where name = '" + comboBox3.SelectedItem + "' order by deductions._date");
                cmd.Connection = con.con;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                comboBox4.Text = "";
              //  comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception )
            {
                MessageBox.Show("خطاء في ادخال الاسم");
            }
            con.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            try
            {

                SqlCommand cmd = new SqlCommand();
                con.OpenConection();
                cmd.CommandText = ("SELECT _value as الجزاءات, _date as التاريخ FROM employee inner join penalties on penalties.emp_id = employee.emp_id where name = '" + comboBox4.SelectedItem + "' order by penalties._date");
                cmd.Connection = con.con;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            //   comboBox4.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox1.Text= "";
            }


            catch (Exception )
            {
                MessageBox.Show("خطاء في ادخال الاسم");
            }
            con.CloseConnection();
        }


    


       
    }
}
