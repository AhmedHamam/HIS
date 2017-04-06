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
    public partial class تعديل_في_طرق_الحضور_والانصراف_لموظف : Form
    {
        Connection con = new Connection();
        public تعديل_في_طرق_الحضور_والانصراف_لموظف()
        {
            InitializeComponent();
        }
        public تعديل_في_طرق_الحضور_والانصراف_لموظف(int d,string ss,string s33,string s4)
        { 
            InitializeComponent();

            textBox6.Text = d.ToString();
            textBox8.Text = ss.ToString();
            textBox5.Text = s33.ToString();
            textBox7.Text = s4.ToString();
     
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
        
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSet4.DataTable1' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'DataSet4.DataTable1' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DataSet5.DataTable1' table. You can move, or remove it, as needed.
          
            
            
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet5.DataTable1' table. You can move, or remove it, as needed.



            //this.reportViewer1.RefreshReport();
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين14 f=new عرض_بيانات_الموظفين14();
            f.Show();
            this.Close();
        }
        

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if (( checkBox1.Checked==true & d.Length != 0 & d2.Length != 0) & textBox6.Text.Length != 0)
             {
                 string[] s = new string[] { "@x", "@y","@z" };
                 string[] s2 = new string[] { d,d2,textBox6.Text };
                 SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar,SqlDbType.Int };
                 dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_control_method_attending_leaving1", s, s2, s3);
                 //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',register_attending  as'تاريخ الحضور ',no_rosacea  as'عدد الورديات ' from attending_leaving_rosacea as rr, register_attending_leaving as r, employee as e where e.emp_id=r.employee_id and e.emp_id=rr.employee_id and r.register_attending between @x and @y and e.emp_id=@z", con);
                 //cmd.Parameters.AddWithValue("@x", d);
                 //cmd.Parameters.AddWithValue("@y",d2);
                 //cmd.Parameters.AddWithValue("@z", textBox6.Text);
                 //MySqlDataReader dr = cmd.ExecuteReader();
                 //DataTable dt = new DataTable();
                 //dt.Load(dr);
                 //dataGridView1.DataSource = dt;
            
            
            
            }
            else if (( checkBox1.Checked==true & d.Length != 0 & d2.Length != 0) & textBox6.Text.Length == 0)
             
            {
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { d, d2};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_control_method_attending_leaving2", s, s2, s3);
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',register_attending  as'تاريخ الحضور ',no_rosacea  as'عدد الورديات ' from attending_leaving_rosacea as rr, register_attending_leaving as r, employee as e where e.emp_id=r.employee_id and e.emp_id=rr.employee_id and r.register_attending between @x and @y", con);
                //cmd.Parameters.AddWithValue("@x", d);
                //cmd.Parameters.AddWithValue("@y", d2);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                
            }
            else
            {
                string[] s = new string[] {"@x"};
                string[] s2 = new string[] {textBox6.Text };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_control_method_attending_leaving3", s, s2, s3);

                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم',register_attending  as'تاريخ الحضور ',no_rosacea  as'عدد الورديات ' from attending_leaving_rosacea as rr, register_attending_leaving as r, employee as e where e.emp_id=r.employee_id and e.emp_id=rr.employee_id and e.emp_id=@x", con);
                //cmd.Parameters.AddWithValue("@x", textBox6.Text);
                
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
              
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            checkBox1.Checked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                        
           // this.DataTable1TableAdapter.Fill(this.DataSet4.DataTable1,int.Parse(textBox6.Text));
           // this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());
           // this.DataTable1TableAdapter.Fill(this.DataSet4.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());
          //  this.reportViewer1.RefreshReport();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
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


