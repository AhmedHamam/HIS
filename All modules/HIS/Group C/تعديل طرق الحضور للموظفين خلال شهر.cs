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
    public partial class تعديل_طرق_الحضور_للموظفين_خلال_شهر : Form
    {
        Connection con = new Connection();
        
        public تعديل_طرق_الحضور_للموظفين_خلال_شهر()
        {
            InitializeComponent();
        }
        public تعديل_طرق_الحضور_للموظفين_خلال_شهر(int d,string ss,string s33,string s4)
        {
            InitializeComponent();

            textBox3.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            textBox2.Text = s4.ToString();

        }
        
        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
         
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet10.DataTable1' table. You can move, or remove it, as needed.

            //this.reportViewer2.RefreshReport();
          
        }

        private void button1_Click(object sender, EventArgs e)

        {
            string d = dateTimePicker1.Text.ToString();
            if ((checkBox1.Checked == true & d.Length !=0) &  textBox3.Text.Length != 0)
            {


                string[] s = new string[] { "@x","@y" };
                string[] s2 = new string[] { textBox3.Text, d };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int,SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_rewrite_attending_leaving_p1", s, s2, s3);

               
               //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration ,register_attending_leaving as q where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and employee.emp_id=q.employee_id and employee.emp_id=@x and  q.register_attending =@y", con);
               //cmd.Parameters.AddWithValue("@x", textBox3.Text);
               //cmd.Parameters.AddWithValue("@y",d);
               // MySqlDataReader dr = cmd.ExecuteReader();
               // DataTable dt = new DataTable();
               // dt.Load(dr);


            }
            else if ((checkBox1.Checked == true & d.Length !=0) &  textBox3.Text.Length == 0)
            {
                string[] s = new string[] { "@y" };
                string[] s2 = new string[] {  d };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_rewrite_attending_leaving_p2", s, s2, s3);

               
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration,register_attending_leaving as q where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and employee.emp_id=q.employee_id  and  q.register_attending=@y", con);
                //cmd.Parameters.AddWithValue("@y", d);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            else
            {
                string[] s = new string[] { "@x" };
                string[] s2 = new string[] { textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_rewrite_attending_leaving_p3", s, s2, s3);

               
               
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and emp_id=@x", con);
                //cmd.Parameters.AddWithValue("@x",textBox3.Text);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
        //    string d = dateTimePicker1.Text.ToString();
        //    if(textBox3.Text.Length !=0 & textBox5.Text.Length !=0)
        //{
        //    MessageBox.Show("1");
        //    cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration ,register_attending_leaving as q where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and employee.emp_id=q.employee_id and employee.emp_id='" + textBox3.Text +"' and  q.register_attending ='" + textBox5.Text + "'", con);

        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
    
        //    dataGridView1.DataSource = dt;
            
            
        // }
        //    else if (textBox3.Text.Length !=0)
        //    {
        //        MessageBox.Show("2");
        //    cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and emp_id='"+textBox3.Text+"'", con);

        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
        //    dataGridView1.DataSource = dt;
        //    }
        //    else
        //    {
        //        MessageBox.Show("3");
        //    cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', dep_name  as'القسم',adm_name as'الادارة',career_name as 'الوظيفة' from employee,department,adminstration,register_attending_leaving as q where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id and employee.emp_id=q.employee_id  and  q.register_attending='"+d+"'", con);

        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
        //    dataGridView1.DataSource = dt;
        //    }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين8 d = new عرض_بيانات_الموظفين8();
            d.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1, dateTimePicker1.Text.ToString());
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox3.Text = null;
                return;
            }
        }

       

        
    }
}
