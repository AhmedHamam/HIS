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
    public partial class ادارة_عربات_الاسعاف1 : Form
    {
        Connection con = new Connection();
             
    //    MySqlConnection con;
    //    MySqlCommand cmd1;
    //    MySqlCommand cmd2;
    //    MySqlCommand cmd3;
        public ادارة_عربات_الاسعاف1()
        {
            InitializeComponent();
        }

        private void ادارة_عربات_الاسعاف1_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            السائقين f = new السائقين();
            // f.Show();
            // catogrical ob = new catogrical();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = السائقين.Code.ToString();
                textBox6.Text = السائقين.name.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            التمريض g = new التمريض();
            // g.Show();
            if (g.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = التمريض.Code.ToString();
                textBox7.Text = التمريض.name.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox4.Text, out number2))
            {
               
            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
          //  con.Open();
            con.OpenConection();
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && textBox4.Text != "")
                {
                    //string s1 = "insert into emergency_ambulance_management values(@d1,@d2,@d3,@d4,@d5);";
                    //cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@d1", textBox1.Text);
                    //cmd1.Parameters.AddWithValue("@d2", textBox2.Text);
                    //cmd1.Parameters.AddWithValue("@d3", textBox3.Text);
                    //cmd1.Parameters.AddWithValue("@d4", comboBox1.SelectedItem);
                    //cmd1.Parameters.AddWithValue("@d5", textBox4.Text);
                    //cmd1.ExecuteNonQuery();
                    string[] f = new string[] { "@d1", "@d2","@d3","@d4","@d5"};
                    string[] f2 = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text};
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar};

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("adds_emmergency_cars", f, f2, f3))
                    {
                       MessageBox.Show("تم اضافة هذه السيارة من قبل");
                        return;
                    }




                    MessageBox.Show("تمت الاضافه بنجاح");
                }
                else
                {
                    MessageBox.Show("قم بادخال البيانات كامله");
                }

            }

            catch (Exception )
            {
                MessageBox.Show("تم اضافة هذه السيارة من قبل");
            }
            con.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   con.Open();
            con.OpenConection();
       
            try
            {
                if(textBox1.Text!=""&&textBox5.Text!=""){
                //string s2 = "insert into emergency_ambulance_management_drivers values(@g1,@g2);";
                //cmd2 = new MySqlCommand(s2, con);
                //cmd2.Parameters.AddWithValue("@g1", textBox1.Text);
                //cmd2.Parameters.AddWithValue("@g2", textBox5.Text);
                //cmd2.ExecuteNonQuery();
                    string[] f = new string[] { "@g1", "@g2"};
                    string[] f2 = new string[] { textBox1.Text, textBox5.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("add_emmergency_cars_driver", f, f2, f3))
                    {
                        MessageBox.Show("تم اضافة السائق لهذة السيارة من قبل");
                        return;
                    }

                MessageBox.Show("تمت الاضافة بنجاح");
                }
                else{
                    MessageBox.Show("قم بادخال البيانات كاملة");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("تم اضافة السائق لهذة السيارة من قبل");
            }
           // con.Close();
            con.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //con.Open();

            con.OpenConection();

            try
            {
                if (textBox1.Text != "" && textBox8.Text != "")
                {
                //    string s3 = "insert into  emergency_ambulance_management_nurses values(@d1,@d2);";
                //    cmd2 = new MySqlCommand(s3, con);
                //    cmd2.Parameters.AddWithValue("@d1", textBox1.Text);
                //    cmd2.Parameters.AddWithValue("@d2", textBox8.Text);
                //    cmd2.ExecuteNonQuery();
                     string[] f = new string[] { "@g1", "@g2"};
                     string[] f2 = new string[] { textBox1.Text, textBox8.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("add_emmergency_cars_nurse", f, f2, f3))
                    {
                        MessageBox.Show("تم اضافة الممرض لهذة السيارة من قبل");
                        return;
                    }
                    MessageBox.Show("تمت الاضافة بنجاح");
                }
                else
                {
                    MessageBox.Show("قم بادخال البيانات كاملة");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("تم اضافة الممرض لهذة السيارة من قبل");
            }
            //con.Close();
            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox2.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox2.Text = null;
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox3.Text = null;
                return;
            }
        }
    }
}
