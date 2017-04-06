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
    public partial class تسجيل_حضور : Form
    {
        Connection con = new Connection();
        public تسجيل_حضور()
        {
            InitializeComponent();
        }

        public تسجيل_حضور(int s1,string s2)
        {
            InitializeComponent();
            textBox2.Text = s1.ToString();
            textBox3.Text = s2.ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            textBox1.Text = d.ToString("dd-MM-yyyy"); 
            // con = new SqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
             //(@"server=(local);database=hospital;Integrated Security=true");
            con.OpenConection();

          
            
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try {
                if (textBox2.Text.Length == 0 & comboBox3.Text.Length == 0 & comboBox4.Text.Length == 0)
                    MessageBox.Show("قم بادخال البيانات");
                if (textBox2.Text.Length != 0 & comboBox3.Text.Length == 0 & comboBox4.Text.Length == 0)
                    MessageBox.Show("قم باختيار طريقة الحضور ونوع الحضور");
                string[] s = new string[] { "@x", "@y","@z","@l" };
                string[] s2 = new string[] {textBox1.Text, textBox2.Text,comboBox3.Text,comboBox4.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("register_in", s, s2, s3);
                // { MessageBox.Show("تم تسجيل حضور لهذا الموظف من قبل"); }
                //else {موافق f = new موافق();
                //  f.Show(); }
        //        cmd = new SqlCommand("register_in", con);
        //cmd.CommandType = CommandType.StoredProcedure;

        //cmd.Parameters.AddWithValue("@x",textBox1.Text);
        //cmd.Parameters.AddWithValue("@y",textBox2.Text);
        //cmd.Parameters.AddWithValue("@z",comboBox3.SelectedItem);
        //cmd.Parameters.AddWithValue("@l", comboBox4.SelectedItem);
        //        cmd.ExecuteNonQuery();

                if (textBox2.Text.Length != 0 & comboBox3.Text.Length != 0 & comboBox4.Text.Length != 0)
                {

                    موافق f = new موافق();
                    f.Show();
                }
            }
            catch(Exception ee){
                MessageBox.Show(ee.Message);
            }
           

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime d = new DateTime();

            textBox1.Text = d.GetDateTimeFormats().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين19 f = new عرض_بيانات_الموظفين19();
            f.Show();
            this.Close();
            
            //cmd = new MySqlCommand("select name as 'الاسم'from employee where emp_id='" + textBox2.Text + "'", con);
            //MySqlDataReader dataReader = cmd.ExecuteReader();
            //dataReader.Read();
            //textBox3.Text = dataReader[0].ToString();
            //dataReader.Close();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox3.Text = null;
            textBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                MessageBox.Show("قم بادخال كود الموظف");
            try
            {
                if (textBox2.Text.Length != 0)
                {
                    MessageBox.Show("تم حذف البيانات");
                }

                string[] s = new string[] {"@y" };
                string[] s2 = new string[] { textBox2.Text};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int};
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_in", s, s2, s3);
                //cmd = new SqlCommand("delete_in ", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@y", textBox2.Text);
                //cmd.ExecuteNonQuery();
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //public void setValue(String x)
        //{
        //    textBox1.Text = x;
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Form47 f = new Form47(this);
        //    f.Show();
        //}
    }
}
