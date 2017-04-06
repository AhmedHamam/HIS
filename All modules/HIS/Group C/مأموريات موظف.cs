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
    public partial class ماموريات_موظف : Form
    {
        Connection con = new Connection();
        public ماموريات_موظف()
        {
            InitializeComponent();
        }
        public ماموريات_موظف(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8)
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet8.DataTable1' table. You can move, or remove it, as needed.
            
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if ((textBox11.Text.Length != 0 & textBox7.Text.Length != 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0) & textBox5.Text.Length !=0)
            {
                
                try
                {
                  
                    string[] s = new string[] { "@x", "@y", "@l","@m","@z" };
                    string[] s2 = new string[] { d,d2,textBox11.Text,  textBox7.Text,textBox5.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date,SqlDbType.Date, SqlDbType.Int, SqlDbType.Int,SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_misson_e1", s, s2, s3);
                    //cmd = new MySqlCommand("select dep_name as'القسم' ,adm_name as'الادارة',career_name as'الوظيفة',no_missions as 'عدد المأموريات' ,name as'الاسم',emp_id as 'الكود' from  employee ,department,adminstration ,attending_leaving_mission where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and  employee.emp_id=attending_leaving_mission.employee_id and employee.emp_id between @l and @m and employee.date_staffing between @x and @y and employee.name=@z ", con);
                    //cmd.Parameters.AddWithValue("@x", d);
                    //cmd.Parameters.AddWithValue("@y", d2);
                    //cmd.Parameters.AddWithValue("@l", textBox11.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox7.Text);
                    //cmd.Parameters.AddWithValue("@z",textBox5.Text);
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if ((textBox11.Text.Length != 0 & textBox7.Text.Length != 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {
                try
                {
                   
                    string[] s = new string[] { "@x", "@y", "@l", "@m" };
                    string[] s2 = new string[] { d, d2, textBox11.Text, textBox7.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date, SqlDbType.Int, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_misson_e2", s, s2, s3);
                    //cmd = new MySqlCommand("", con);
                    //cmd.Parameters.AddWithValue("@x", d);
                    //cmd.Parameters.AddWithValue("@y", d2);
                    //cmd.Parameters.AddWithValue("@l", textBox11.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox7.Text);
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if ((textBox11.Text.Length == 0 & textBox7.Text.Length== 0) &(checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {

                try
                {

                    
                    string[] s = new string[] { "@x", "@y" };
                    string[] s2 = new string[] { d, d2 };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_misson_e3", s, s2, s3);
                    //cmd = new MySqlCommand("", con);
                    //cmd.Parameters.AddWithValue("@x", d);
                    //cmd.Parameters.AddWithValue("@y", d2);
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if (textBox11.Text.Length != 0 & textBox7.Text.Length != 0)
            {
                try
                {
                   
                    string[] s = new string[] { "@x", "@y" };
                    string[] s2 = new string[] { textBox11.Text,textBox7.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_misson_e4", s, s2, s3);
                    //cmd = new MySqlCommand("select dep_name as'القسم' ,adm_name as'الادارة',career_name as'الوظيفة',no_missions as 'عدد المأموريات' ,name as'الاسم',emp_id as 'الكود' from  employee ,department,adminstration ,attending_leaving_mission where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and  employee.emp_id=attending_leaving_mission.employee_id and employee.emp_id between'" + textBox11.Text + "' and '" + textBox7.Text + "'", con);

                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
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
                   
                    string[] s = new string[] { "@l" };
                    string[] s2 = new string[] { textBox5.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_misson_e5", s, s2, s3);
                    //cmd = new MySqlCommand("select dep_name as'القسم' ,adm_name as'الادارة',career_name as'الوظيفة',no_missions as 'عدد المأموريات' ,name as'الاسم',emp_id as 'الكود' from  employee ,department,adminstration ,attending_leaving_mission where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and  employee.emp_id=attending_leaving_mission.employee_id and name=@l", con);
                    //cmd.Parameters.AddWithValue("@l", textBox5.Text);
                   
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet8.DataTable1' table. You can move, or remove it, as needed.
      
            con.OpenConection();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين5 f = new عرض_بيانات_الموظفين5();
            f.Show();
            this.Close();
        }

      

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            checkBox1.Checked = false;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            
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

        private void button3_Click(object sender, EventArgs e)
        {
           // this.DataTable1TableAdapter.Fill(this.DataSet8.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());

     
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox11.Text, out parsedValue))
            {
              
                MessageBox.Show("قم بادخال رقم");
                textBox11.Text = null;
                return;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox7.Text, out parsedValue))
            {
               
                MessageBox.Show("قم بادخال رقم");
                textBox7.Text = null;
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
