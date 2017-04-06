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
    public partial class مراجعة_الحضور_للموظفين_لفترة : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        public مراجعة_الحضور_للموظفين_لفترة()
        {
            InitializeComponent();
        }
          public مراجعة_الحضور_للموظفين_لفترة(int d,string ss,string s33,string s4)
        {
            InitializeComponent();

            textBox3.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            textBox2.Text = s4.ToString();

        }
          
        private void Form10_Load(object sender, EventArgs e)
          {
              // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            
              con.OpenConection();  
            // TODO: This line of code loads data into the 'DataSet11.DataTable1' table. You can move, or remove it, as needed.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            if(( checkBox1.Checked==true & d.Length !=0 & d2.Length !=0)& textBox3.Text.Length !=0)
            {
               
                string[] s = new string[] { "@x", "@y", "@z" };
                string[] s2 = new string[] { d, d2, textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_revision_attending_p1", s, s2, s3);
  
            }
           else if ((checkBox1.Checked == true & d.Length != 0 & d2.Length != 0) & textBox3.Text.Length == 0)
            {
                
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_revision_attending_p2", s, s2, s3);
                //cmd = new MySqlCommand("");
                //cmd.Parameters.AddWithValue("@x", d);
                //cmd.Parameters.AddWithValue("@y", d2);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            else{
               
                string[] s = new string[] { "@z" };
                string[] s2 = new string[] { textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_revision_attending_p3", s, s2, s3);
                //cmd = new SqlCommand("reg_revision_attending_p3",con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@z", textBox3.Text);
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين_10 d = new عرض_بيانات_الموظفين_10();
            d.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.DataTable1TableAdapter.Fill(this.DataSet10.DataTable1, dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString());
            // TODO: This line of code loads data into the 'DataSet10.DataTable1' table. You can move, or remove it, as needed.
          // this.DataTable1TableAdapter.Fill(this.DataSet10.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());

            // TODO: This line of code loads data into the 'DataSet10.DataTable1' table. You can move, or remove it, as needed.

            //this.reportViewer11.RefreshReport();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          //  this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());

            
            //this.DataTable1TableAdapter.Fill(this.DataSet11.DataTable1,dateTimePicker1.Text.ToString(),dateTimePicker2.Text.ToString());

            // TODO: This line of code loads data into the 'DataSet10.DataTable1' table. You can move, or remove it, as needed.

           
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
