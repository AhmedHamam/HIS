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

    public partial class البطاقة_العلاجية1 : Form
    {


        Connection con = new Connection();
        //MySqlCommand cmd;
        //MySqlConnection con;
        //MySqlDataAdapter da;
        //MySqlDataReader dr;
        BindingSource bs;
        DataSet ds = new DataSet();
        DataTable dt;
        //direction_code;

        public البطاقة_العلاجية1()
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
            InitializeComponent();

        }
        public البطاقة_العلاجية1(string s)
        {
            InitializeComponent();
            textBox3.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            con.OpenConection();
            if (textBox2.Text.Length != 0 || textBox1.Text.Length != 0 )
            {


                try
                {
                    string[] s = new string[] { "@x","@y" };
                    string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("medical_card", s, s2, s3);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }




                MessageBox.Show("1");
                ////select * from Registeration_medicalCard where card_id=@x and policy_id=@y and direction_code=@z
                //cmd = new MySqlCommand("select * from Registeration_medicalCard where card_id='" + textBox1.Text + "' and policy_id='" + textBox2.Text + "' and direction_code='" + textBox3.Text + "'", con);
                //da = new MySqlDataAdapter(cmd);

                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(ds);
                //bs = new BindingSource();
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs;

            }
            else if (checkBox1.Checked == true & d.Length != 0)
            {



                try
                {
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] {d.ToString()};
                    
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("medical_card12", s, s2, s3);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }


                //MessageBox.Show("2");
                //cmd = new MySqlCommand("select * from Registeration_medicalCard where start_date=@x", con);
                //da = new MySqlDataAdapter(cmd);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //cmd.Parameters.AddWithValue("@x", d);
                //da.Fill(ds);
                //bs = new BindingSource();
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs;

            }
            else if (checkBox2.Checked == true & d2.Length != 0)
            {






                try
                {
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { d2.ToString() };

                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("medical_card_end", s, s2, s3);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                //MessageBox.Show("3");
                //cmd = new MySqlCommand("select * from Registeration_medicalCard where end_date=@x", con);
                //da = new MySqlDataAdapter(cmd);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //cmd.Parameters.AddWithValue("@x", d2);
                //da.Fill(ds);
                //bs = new BindingSource();
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs;

            }
            else
            {
                dataGridView1.DataSource = null;
                ds.Tables.Clear();





                try
                {

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("medical_card_all");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                //da = new MySqlDataAdapter("select * from Registeration_medicalCard", con);
                //da.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];

            }
            con.CloseConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked =false;
            checkBox2.Checked = false;
        }
        public void setValue4(String name)
        {
            textBox3.Text = name;

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("لا يوجد بيانات ");
            }
            else
            {
                try
                {
                   ////int d = "select patient_id from Registeration_patientRegisteration where patient_name=@pat";
                   // string name = "select patient_id from Registeration _patientRegisteration where patient_name=@na";
                   // int id = int.Parse(name.ToString());
                   // string s = "insert into Registeration_medicalCard (card_id,policy_id,direction,start_date,end_date,patient_id) values(@x,@y,@z,@s,@w,@d)";
                   // //cmd.Parameters.AddWithValue("@pat", textBox4.Text);
                   // cmd.Parameters.AddWithValue("@na", textBox4.Text);
                   // cmd.Parameters.AddWithValue("@x", textBox1.Text);
                   // cmd.Parameters.AddWithValue("@y", textBox2.Text);
                   // cmd.Parameters.AddWithValue("@z", textBox3.Text);
                   // cmd.Parameters.AddWithValue("@s", checkBox1.Checked);
                   // cmd.Parameters.AddWithValue("@w", checkBox2.Checked);
                   // cmd.Parameters.AddWithValue("@d",id);
                    
                   // //cmd = new MySqlCommand(s, con);
                   // cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حفظ البيانات بنجاح");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
               // حفظ d = new حفظ();
               // d.Show();
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {

            الجهات00 d = new الجهات00(this);
            d.Show();

        }

        private void البطاقة_العلاجية1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox2.Text = null;
                return;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox2.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox2.Text = null;
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض_تقرير d = new محرك_البحث_عن_مريض_تقرير();
            d.Show();
        }

    }
}

