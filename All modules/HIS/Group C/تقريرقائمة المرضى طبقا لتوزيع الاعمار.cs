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
    public partial class قائمة_المرضى_طبقا_لتوزيع_الاعمار : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlDataAdapter da;
        //MySqlCommand cmd;
        DataSet ds = new DataSet();
        BindingSource bs=new BindingSource();
        public قائمة_المرضى_طبقا_لتوزيع_الاعمار()
        {
            InitializeComponent();
        }

        private void قائمة_المرضى_طبقا_لتوزيع_الاعمار_Load(object sender, EventArgs e)
        {
            //con = new MSqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();
            comboBox1.Items.Add("ذكر");
            comboBox1.Items.Add("انثى");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = new string[] { "@g","@x","@y"};
                string[] s2 = new string[] { comboBox1.Text,textBox1.Text,textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.Int,SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("registration_report_list",s,s2,s3);
                //string s = "select patient_name,address_of_patient,nationality ,marital_status from Registeration_patientRegisteration where gender=@g and age between @x and @y";
                //cmd = new MySqlCommand(s, con);
                //cmd.Parameters.AddWithValue("@g", comboBox1.SelectedItem);
                //cmd.Parameters.AddWithValue("@x", textBox1.Text);
                //cmd.Parameters.AddWithValue("@y", textBox2.Text);
                //da = new MySqlDataAdapter(cmd);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(ds);
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox1.Text = null;
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

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
