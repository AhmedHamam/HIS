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
    public partial class حصر_تاخير_واضافي_وخروج_مبكر_للموظفين : Form
    {
        Connection con = new Connection();
        public حصر_تاخير_واضافي_وخروج_مبكر_للموظفين()
        {
            InitializeComponent();
        }
        public حصر_تاخير_واضافي_وخروج_مبكر_للموظفين(int d,string ss,string s33)
        {
          
            InitializeComponent();

            textBox6.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            

     
        }
        

        private void Form13_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if (( checkBox1.Checked==true & d.Length != 0 & d2.Length != 0) & textBox6.Text.Length != 0)
            {

                string[] s = new string[] { "@z", "@x", "@y" };
                string[] s2 = new string[] { textBox6.Text,d, d2 };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_count_early_late__leaving1", s, s2, s3);
            //    cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',type_permit  as'نوع الاذن ',dep_name  as'القسم',adm_name as'الادارة' from employee as e ,attending_leaving_permits as p ,department,adminstration,register_attending_leaving as r where e.emp_id=p.employee_id and e.emp_id=department.employee_id and e.emp_id=adminstration.employee_id and e.emp_id=r.employee_id and emp_id=@z and r.register_attending between @x and @y", con);
            //    cmd.Parameters.AddWithValue("@x", d);
            //    cmd.Parameters.AddWithValue("@y", d2);
            //    cmd.Parameters.AddWithValue("@z", textBox6.Text);

            //    MySqlDataReader dr = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            }
            else if ((checkBox1.Checked==true & d.Length != 0 & d2.Length != 0)& textBox6.Text.Length == 0)
            {

                string[] s = new string[] {"@x", "@y" };
                string[] s2 = new string[] {d, d2 };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_count_early_late__leaving2", s, s2, s3);
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',type_permit  as'نوع الاذن ',dep_name  as'القسم',adm_name as'الادارة' from employee as e ,attending_leaving_permits as p ,department,adminstration,register_attending_leaving as r  where e.emp_id=p.employee_id and e.emp_id=department.employee_id and e.emp_id=adminstration.employee_id and e.emp_id=r.employee_id  and r.register_attending between @x and @y ", con);
                //cmd.Parameters.AddWithValue("@x", d);
                //cmd.Parameters.AddWithValue("@y", d2);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }

            else
            {
                string[] s = new string[] { "@z" };
                string[] s2 = new string[] { textBox6.Text};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_count_early_late__leaving3", s, s2, s3);
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',type_permit  as'نوع الاذن ',dep_name  as'القسم',adm_name as'الادارة' from employee as e ,attending_leaving_permits as p ,department,adminstration where e.emp_id=p.employee_id and e.emp_id=department.employee_id and e.emp_id=adminstration.employee_id and emp_id =@z", con);
                //cmd.Parameters.AddWithValue("@z", textBox6.Text);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين13 f = new عرض_بيانات_الموظفين13();
            f.Show();
            this.Close();
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            checkBox1.Checked = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show("يجب ادخال رقم");
               
                textBox6.Text = null;
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
