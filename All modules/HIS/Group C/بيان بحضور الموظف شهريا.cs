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
    public partial class بيان_بحضور_الموظف_شهريا : Form
    {
        Connection con = new Connection();
        public بيان_بحضور_الموظف_شهريا()
        {
            InitializeComponent();
        }
        public بيان_بحضور_الموظف_شهريا(int d, string ss, string s33, string s4)
        {
            InitializeComponent();

            textBox3.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            textBox2.Text = s4.ToString();

        }
        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
                     // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
         
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dataSet2.DataTable1' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'dataSet2.DataTable1' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.


          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        
        private void button4_Click(object sender, EventArgs e)
        {
            
            عرض_بيانات_الموظفين1 d = new عرض_بيانات_الموظفين1();
            d.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين1 d = new عرض_بيانات_الموظفين1();
            d.Show();
            this.Close();
        }

      
        private void button3_Click_1(object sender, EventArgs e)
        {
            //Form46 f = new Form46(this);
            //f.Show();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            checkBox1.Checked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1,dateTimePicker1.ToString());

            //this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1,dateTimePicker1.Text.ToString());
           
          //  this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1, dateTimePicker1.Text.ToString());

            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
         
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string d = dateTimePicker1.Text.ToString();

            if (checkBox1.Checked == true & d.Length != 0 & textBox3.Text.Length != 0)
            {

                string[] s = new string[] { "@x", "@y"};
                string[] s2 = new string[] { d ,textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_month1", s, s2, s3);


            }
            else if (checkBox1.Checked == true & d.Length != 0 & textBox3.Text.Length == 0)
            {
                try
                {
                    string[] s = new string[] { "@x"};
                    string[] s2 = new string[] { d };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_month2", s, s2, s3);

                  

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
                    string[] s = new string[] { "@y" };
                    string[] s2 = new string[] { textBox3.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_attending_month3", s, s2, s3);


                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',dep_name  as'القسم',adm_name as'الادارة',no_missions as'عدد المأموريات ', holiday_date as 'تاريخ الاجازة',type_permit as'نوع الاذن' from  employee,department,adminstration,attending_leaving_mission as m ,vacation_balance as v,attending_leaving_permits as p where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and employee.emp_id=m.employee_id and  employee.emp_id=v.employee_id and employee.emp_id=p.employee_id  and employee.emp_id=@y", con);
                    //cmd.Parameters.AddWithValue("@y", textBox3.Text);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("يجب ادخال رقم");
                return;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
