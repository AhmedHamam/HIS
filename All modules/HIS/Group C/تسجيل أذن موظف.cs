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
    public partial class تسجيل_اذن_موظف : Form
    {

        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        Connection con = new Connection();
        public تسجيل_اذن_موظف()
        {
            InitializeComponent();
        }

        public تسجيل_اذن_موظف(int d,string s)
        {
            InitializeComponent();
            textBox1.Text = d.ToString();
            textBox2.Text = s.ToString();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
          
            con.OpenConection();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    cmd = new SqlCommand("select name as 'الاسم'from employee where emp_id=@x", con);
        //    cmd.Parameters.AddWithValue("@x", textBox1.Text);
        //    SqlDataReader dataReader = cmd.ExecuteReader();
        //    dataReader.Read();
        //    textBox2.Text = dataReader[0].ToString();
        //    dataReader.Close();
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("قم بادخال كود الموظف");
                }
                if (textBox1.Text.Length != 0 & comboBox2.Text.Length == 0)
                {
                    MessageBox.Show("قم باختيار نوع الاذن");
                }
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox1.Text, comboBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int, SqlDbType.VarChar };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("reg_permits_in", s, s2, s3);
               

                //cmd = new SqlCommand("reg_permits_in", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x", textBox1.Text);
                //cmd.Parameters.AddWithValue("@y", comboBox2.SelectedItem);
                //cmd.ExecuteNonQuery();

                if (textBox1.Text.Length != 0 & comboBox2.Text.Length != 0)
                {
                موافق f = new موافق();
                f.Show();
                  
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين18 f = new عرض_بيانات_الموظفين18();
            f.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox1.Text = null;
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox2.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("قم بادخال كود الموظف");
            }
            try
            {
                string[] s = new string[] { "@y" };
                string[] s2 = new string[] { textBox1.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_permit_in", s, s2, s3);
                //cmd = new SqlCommand("delete_permit_in", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@y", textBox1.Text);
                //cmd.ExecuteNonQuery();

                if (textBox1.Text.Length != 0)
                {

                    MessageBox.Show("تم حذف البيانات");

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
