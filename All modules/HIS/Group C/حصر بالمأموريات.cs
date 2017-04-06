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
    public partial class حصر_بالماموريات : Form
    {
        Connection con = new Connection();
        public حصر_بالماموريات()
        {
            InitializeComponent();
        }
        public حصر_بالماموريات(string d,string ss,string s33)
        {
          
            InitializeComponent();

            textBox11.Text = d.ToString();
            textBox12.Text = ss.ToString();
            textBox9.Text = s33.ToString();
            

     
        }
       
       
        private void button9_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if ((checkBox1.Checked==true & d.Length !=0 & d2.Length !=0)&(textBox5.Text.Length !=0 & textBox10.Text.Length !=0))
            {
                try
                {
                    string[] s = new string[] { "@l","@m","@x","@y" };
                    string[] s2 = new string[] {textBox5.Text, textBox10.Text,d,d2 };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_mission1", s, s2, s3);
                    
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', no_missions  as'عدد المأموريات ' from employee as e ,attending_leaving_mission as m ,register_attending_leaving as r where e.emp_id=m.employee_id and e.emp_id=r.employee_id and e.emp_id between @l and @m and r.register_attending between @x and @y", con);
                    //cmd.Parameters.AddWithValue("@x", d);
                    //cmd.Parameters.AddWithValue("@y", d2);
                    //cmd.Parameters.AddWithValue("@l", textBox5.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox10.Text);
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
            else if (textBox5.Text.Length !=0 & textBox10.Text.Length !=0)
            {
                try
                {
                    string[] s = new string[] { "@l", "@m"};
                    string[] s2 = new string[] { textBox5.Text, textBox10.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_mission2", s, s2, s3);
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', no_missions  as'عدد المأموريات ' from employee as e ,attending_leaving_mission as m  where e.emp_id=m.employee_id and e.emp_id between @l and @m ", con);
                    //cmd.Parameters.AddWithValue("@l", textBox5.Text);
                    //cmd.Parameters.AddWithValue("@m", textBox10.Text);
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
             else if ((checkBox1.Checked==true & d.Length !=0 & d2.Length !=0)&(textBox5.Text.Length ==0 & textBox10.Text.Length ==0))
             {
                 string[] s = new string[] { "@x", "@y" };
                 string[] s2 = new string[] {d, d2 };
                 SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                 dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_mission3", s, s2, s3);
                //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', no_missions  as'عدد المأموريات ' from employee as e ,attending_leaving_mission as m,register_attending_leaving as r  where e.emp_id=m.employee_id and e.emp_id=r.employee_id and r.register_attending between @x and @y ", con);
                //cmd.Parameters.AddWithValue("@x", d);
                //cmd.Parameters.AddWithValue("@y", d2);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
             else 
            {
               
                try
                {
                    string[] s = new string[] { "@x"};
                    string[] s2 = new string[] { textBox11.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_count_mission4", s, s2, s3);
                    //cmd = new MySqlCommand("select emp_id as 'الكود',name as'الاسم', no_missions  as'عدد المأموريات ' from employee as e ,attending_leaving_mission as m where e.emp_id=m.employee_id  and career_name=@x ", con);
                    //cmd.Parameters.AddWithValue("@x",textBox11.Text);
                   
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

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet5.DataTable1' table. You can move, or remove it, as needed.
           
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet6.DataTable1' table. You can move, or remove it, as needed.
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين12 f = new عرض_بيانات_الموظفين12();
            f.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox5.Text = null;
            textBox9.Text =null;
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.DataTable1TableAdapter.Fill(this.DataSet5.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());

            //this.DataTable1TableAdapter.Fill(this.DataSet5.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());
          //  this.reportViewer1.RefreshReport();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox5.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox5.Text = null;
                return;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox10.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox10.Text = null;
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
