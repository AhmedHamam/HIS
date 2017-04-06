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
    public partial class الورديات : Form
    {
        Connection con= new Connection();

        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        public الورديات()
        {
            InitializeComponent();
        }

        public الورديات(int s)
        {

            InitializeComponent();
            textBox2.Text = s.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length ==0 & comboBox1.Text.Length==0 & comboBox2.Text.Length ==0 & comboBox3.Text.Length==0)
                    MessageBox.Show("قم بادخال البيانات");
                if (textBox2.Text.Length != 0 & comboBox1.Text.Length == 0 & comboBox2.Text.Length == 0 & comboBox3.Text.Length == 0)
                    MessageBox.Show("قم بادخال وقت الوردية ونوع الوردية وعدد الورديات");
                string[] s = new string[] { "@x", "@y", "@z", "@m" };
                string[] s2 = new string[] { comboBox2.Text, comboBox1.Text,comboBox3.Text, textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int };
                
               con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("reg_roceasa_in", s, s2, s3);
                //{
                //    MessageBox.Show("تم تسجيل وردية لهذا الموظف من قبل");
                //}
                //else
                //{
                //    موافق f = new موافق();
                //    f.Show();
                //}
                //cmd = new SqlCommand("reg_roceasa_in", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x",comboBox2.SelectedItem);
                //cmd.Parameters.AddWithValue("@y",comboBox1.SelectedItem);
                //cmd.Parameters.AddWithValue("@z",comboBox3.SelectedItem);
                //cmd.Parameters.AddWithValue("@m",textBox2.Text);
                //cmd.ExecuteNonQuery();
                if (textBox2.Text.Length != 0 & comboBox1.Text.Length != 0 & comboBox2.Text.Length != 0 & comboBox3.Text.Length != 0)
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

        private void الورديات_Load(object sender, EventArgs e)
        {
            
            //(@"server=(local);database=hospital;Integrated Security=true");
            con.OpenConection();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين21 f = new عرض_بيانات_الموظفين21();
            f.Show();
            this.Close();
        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
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
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_rosacea_in", s, s2, s3);
                //cmd = new SqlCommand("delete_rosacea_in", con);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
