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
    public partial class طرق_الحضور_والانصراف : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        public طرق_الحضور_والانصراف()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
            //(@"server=(local);database=hospital;Integrated Security=true");
            con.OpenConection();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length == 0 & textBox1.Text.Length == 0)
                    MessageBox.Show("قم بادخال البيانات");
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox3.Text, textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("reg_method_attending_leaving1", s, s2, s3);
                //cmd = new MySqlCommand("insert into methods_attending_leaving set attending_method=@x,short_name=@y,attend_method=@z", con);
                //cmd.Parameters.AddWithValue("@x", textBox3.Text);
                //cmd.Parameters.AddWithValue("@y", textBox2.Text);
                //cmd.Parameters.AddWithValue("@z", comboBox1.SelectedItem);
                
                //cmd.ExecuteNonQuery();
                if (textBox2.Text.Length != 0 & textBox1.Text.Length != 0)
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }
    }
}
