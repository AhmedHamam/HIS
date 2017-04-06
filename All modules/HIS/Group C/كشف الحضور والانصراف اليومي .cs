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
    public partial class كشف_الحضور_والانصراف_اليومي : Form
    {
        Connection con = new Connection();
        public كشف_الحضور_والانصراف_اليومي()
        {
            InitializeComponent();
        }
        public كشف_الحضور_والانصراف_اليومي(int s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();
      
       
            textBox3.Text = s1.ToString();
            textBox4.Text = s2.ToString();
            textBox1.Text = s3.ToString();
            textBox6.Text = s4.ToString();
            textBox2.Text =s5.ToString();
            textBox5.Text = s6.ToString();
            
        }
        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();

            if(( checkBox1.Checked==true & d.Length!=0 & d2.Length!=0) & textBox3.Text.Length!=0)
            {

                string[] s = new string[] { "@x", "@y", "@l" };
                string[] s2 = new string[] { d, d2, textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_leaving_daily1", s, s2, s3);

            //    cmd = new MySqlCommand("select  emp_id as 'الكود',name as'الاسم',adm_name as'الادارة',dep_name as'القسم',register_attending as'تاريخ الحضور',register_leaving as'تاريخ الانصراف' from  employee ,department,adminstration,register_attending_leaving  where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and employee.emp_id=register_attending_leaving.employee_id and employee.emp_id=@l and register_attending_leaving.register_attending between @x and @y ", con);
            //cmd.Parameters.AddWithValue("@x", d);
            //cmd.Parameters.AddWithValue("@y", d2);
            //cmd.Parameters.AddWithValue("@l", textBox3.Text);
            //    dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
           
            }
            else if (( checkBox1.Checked==true & d.Length!=0 & d2.Length!=0) & textBox3.Text.Length==0)
            {
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { d, d2};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_leaving_daily2", s, s2, s3);
            //    cmd = new MySqlCommand("select  emp_id as 'الكود',name as'الاسم',adm_name as'الادارة',dep_name as'القسم',register_attending as'تاريخ الحضور',register_leaving as'تاريخ الانصراف' from  employee ,department,adminstration,register_attending_leaving  where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and employee.emp_id=register_attending_leaving.employee_id and register_attending_leaving.register_attending between @x and @y ", con);
            //    cmd.Parameters.AddWithValue("@x", d);
            //    cmd.Parameters.AddWithValue("@y", d2);
            //dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
           
            }
            else{
                string[] s = new string[] { "@l" };
                string[] s2 = new string[] {textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_leaving_daily3", s, s2, s3);
            //    cmd = new MySqlCommand("select  emp_id as 'الكود',name as'الاسم',adm_name as'الادارة',dep_name as'القسم',register_attending as'تاريخ الحضور',register_leaving as'تاريخ الانصراف' from  employee ,department,adminstration,register_attending_leaving  where employee.emp_id=department.employee_id and  employee.emp_id=adminstration.employee_id and employee.emp_id=register_attending_leaving .employee_id and employee.emp_id=@l ", con);
            //cmd.Parameters.AddWithValue("@l", textBox3.Text);
            //dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            //this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1);
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            عرض_بيانات_المظفين15 f = new عرض_بيانات_المظفين15();
            f.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());

           //this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());
           // this.reportViewer3.RefreshReport();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("يجب ادخال رقم");
                textBox3.Text = null;
                return;
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

      
       
    }
}
