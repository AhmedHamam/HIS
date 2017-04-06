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
    public partial class تسجيل_ماموريات_موظف : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        public تسجيل_ماموريات_موظف()
        {
            InitializeComponent();
        }

        public تسجيل_ماموريات_موظف(int s)
        {
            InitializeComponent();
            textBox2.Text = s.ToString();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length == 0 & textBox1.Text.Length ==0)
                    MessageBox.Show("قم بادخال البيانات");
                if (textBox2.Text.Length != 0 & textBox1.Text.Length == 0)
                
                    MessageBox.Show("قم بادخال عدد المأموريات ");
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int,SqlDbType.Int };
               con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("reg_missio_in", s, s2, s3);
                //{
                //    MessageBox.Show("تم تسجيل مأمورية لهذا الموظف من قبل");
                //}
                //else

               if (textBox2.Text.Length != 0 & textBox1.Text.Length != 0)
               {

                   موافق f = new موافق();
                   f.Show();
               } 
                //{
                //    موافق f = new موافق();
                //    f.Show();
                //}
                //cmd = new SqlCommand("reg_missio_in", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@x", textBox1.Text);
                //    cmd.Parameters.AddWithValue("@y", textBox2.Text);
                //cmd.ExecuteNonQuery();
               

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           

        }

        private void Form21_Load(object sender, EventArgs e)
        {
            
            con.OpenConection();
            
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين22 f = new عرض_بيانات_الموظفين22();
            f.Show();
            this.Close();
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

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                MessageBox.Show("قم بادخال كود الموظف");
            try
            {
                string[] s = new string[] { "@y" };
                string[] s2 = new string[] { textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_mission_in", s, s2, s3);

                //cmd = new SqlCommand("delete_mission_in ", con);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
