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
    public partial class حصر_اذونات_الخروج : Form
    {
        Connection con = new Connection();
        public حصر_اذونات_الخروج()
        {
            InitializeComponent();
        }
        public حصر_اذونات_الخروج(string d,string ss,string s33)
        {
          
            InitializeComponent();

            textBox2.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            

     
        }
        public حصر_اذونات_الخروج(int s)
        {

            InitializeComponent();

            textBox6.Text = s.ToString();
   



        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }
       

        private void button9_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if ((textBox6.Text.Length != 0 & textBox3.Text.Length != 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {
               
                try
                {
                    string[] s = new string[] { "@x","@y","@l","@m" };
                    string[] s2 = new string[] { d,d2,textBox6.Text,textBox3.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.Int,SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_permits_leaving1", s, s2, s3);
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', type_permit  as'اذن خروج' from employee as e ,attending_leaving_permits as p,register_attending_leaving as rr where e.emp_id=p.employee_id and e.emp_id=rr.employee_id and  type_permit ='خروج' and rr.register_attending between @x and @y and e.emp_id between @l and @m ", con);
                    //cmd.Parameters.AddWithValue("@x", d);
                    //cmd.Parameters.AddWithValue("@y", d2);
                    //cmd.Parameters.AddWithValue("@l", textBox6.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox3.Text);
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
            else if (textBox6.Text.Length != 0 & textBox3.Text.Length != 0 )
            {
               
                try
                {
                    string[] s = new string[] {"@l", "@m" };
                    string[] s2 = new string[] {textBox6.Text, textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_permits_leaving2", s, s2, s3);
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', type_permit  as'اذن خروج' from employee as e ,attending_leaving_permits as p where e.emp_id=p.employee_id and  type_permit ='خروج' and e.emp_id between @l and @m", con);
                    //cmd.Parameters.AddWithValue("@l", textBox6.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox3.Text);
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if  ((textBox6.Text.Length == 0 & textBox3.Text.Length == 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {
               
                try
                {
                    string[] s = new string[] { "@x", "@y"};
                    string[] s2 = new string[] { d, d2};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_permits_leaving3", s, s2, s3);
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', type_permit  as'اذن خروج' from employee as e ,attending_leaving_permits as p,register_attending_leaving as rr where e.emp_id=p.employee_id and  type_permit ='خروج' and rr.register_attending between @x and @y", con);
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
             else
            {
               
                try
                {
                    string[] s = new string[] { "@x"};
                    string[] s2 = new string[] {textBox2.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_permits_leaving4", s, s2, s3);
                   
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين11 f = new عرض_بيانات_الموظفين11();
            f.Show();
            this.Close();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }


        
        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            checkBox1.Checked = false;

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
