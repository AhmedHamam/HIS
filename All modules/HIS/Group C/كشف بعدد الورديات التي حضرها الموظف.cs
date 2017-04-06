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
    public partial class كشف_بعدد_الورديات_التي_حضرها_الموظف : Form
    {
        Connection con = new Connection();
        public كشف_بعدد_الورديات_التي_حضرها_الموظف()
        {
            InitializeComponent();
        }

        public كشف_بعدد_الورديات_التي_حضرها_الموظف(string d, string ss, string s33, string s4, string s5, string s6)
        {
            InitializeComponent();
     
            textBox2.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox6.Text = s33.ToString();
            textBox3.Text = s4.ToString();
            textBox5.Text = s5.ToString();
            textBox4.Text = s6.ToString();

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        private void Form18_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            // TODO: This line of code loads data into the 'DataSet5.DataTable1' table. You can move, or remove it, as needed.
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();

            if ((textBox2.Text.Length != 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {

                string[] s = new string[] { "@x","@y","@l" };
                string[] s2 = new string[] { d,d2,textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_emp_rosea1", s, s2, s3);
              
               
            //    cmd = new MySqlCommand("",con);
            //    cmd.Parameters.AddWithValue("@x", d);
            //    cmd.Parameters.AddWithValue("@y", d2);
            //    cmd.Parameters.AddWithValue("@l", textBox2.Text);
               
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            }
            else if  ((textBox2.Text.Length == 0) & (checkBox1.Checked==true & d.Length != 0 & d2.Length != 0))
            {
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_emp_rosea2", s, s2, s3);

            //    cmd = new MySqlCommand("");
            //    cmd.Parameters.AddWithValue("@x", d);
            //    cmd.Parameters.AddWithValue("@y", d2);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            
            }
            else{
                string[] s = new string[] { "@l"};
                string[] s2 = new string[] { textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_report_emp_rosea3", s, s2, s3);

                //cmd = new MySqlCommand("", con);
                //cmd.Parameters.AddWithValue("@l", textBox2.Text);
             
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            
            
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين17 f = new عرض_بيانات_الموظفين17();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
          //  this.DataTable1TableAdapter.Fill(this.DataSet5.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());
           

        }

        private void reportViewer5_Load(object sender, EventArgs e)
        {

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
