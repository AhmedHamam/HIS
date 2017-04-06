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
    public partial class تسجيل_انصراف : Form
    {
        //Connection v = new Connection();
        //SqlConnection con;
        //SqlCommand cmd;
        Connection con = new Connection();
        public تسجيل_انصراف(int s1, string s2)
        {
            InitializeComponent();
            textBox2.Text = s1.ToString();
            textBox3.Text = s2.ToString();

        }


        public تسجيل_انصراف()
        {
            InitializeComponent();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void حفظToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
            if (textBox2.Text.Length == 0)
                MessageBox.Show("قم بادخال كود الموظف");
            try {
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("register_leaving_in", s, s2, s3);
               
              //  cmd = new SqlCommand("register_leaving_in ", con);
              //  cmd.CommandType = CommandType.StoredProcedure;
              //cmd.Parameters.AddWithValue("@x", textBox1.Text);
              //cmd.Parameters.AddWithValue("@y", textBox2.Text);
              //  cmd.ExecuteNonQuery();
                if (textBox2.Text.Length != 0)
                {
                    موافق f = new موافق();
                    f.Show();
                }
            }
            catch(Exception ee){
                MessageBox.Show(ee.Message);
            }

        }

        private void تسجيل_انصراف_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            textBox1.Text = d.ToString("MM/dd/yyyy");
            //con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
           con.OpenConection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين20 f = new عرض_بيانات_الموظفين20();
            f.Show();
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox2.Text = null;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox2.Text = null;
                return;
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                MessageBox.Show("قم بادخال كود الموظف");
            try
            {

                string[] s = new string[] {"@y" };
                string[] s2 = new string[] {textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_leaving_in", s, s2, s3);
                //cmd = new SqlCommand("delete_leaving_in ", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@y", textBox2.Text);
                //cmd.ExecuteNonQuery();
                if (textBox2.Text.Length != 0)
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

