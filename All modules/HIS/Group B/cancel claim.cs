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
    public partial class cancelclaim : Form
    {
        Connection con = new Connection();
        public cancelclaim()
        {
            InitializeComponent();
        }

        public void setValue(string d, string c)
        {
            textBox3.Text = d;
            textBox4.Text = c;
        }

        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox2.Text = f;
        } 

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            الجهات f = new الجهات(this);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            الجهاتالفرعيه f = new الجهاتالفرعيه(this);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.OpenConection();
                //not find table [0]
                string[] pramname = new string[6];
                string[] pramvalue = new string[6];
                SqlDbType[] pramtype = new SqlDbType[6];
                pramname[0] = "@x1";
                pramname[1] = "@x2";
                pramname[2] = "@x3";
                pramname[3] = "@x4";
                pramname[4] = "@x5";
                pramname[5] = "@x6";
                pramvalue[0] = comboBox1.SelectedItem.ToString();
                pramvalue[1] = numericUpDown1.Text;
                pramvalue[2] = dateTimePicker1.Value.ToString();
                pramvalue[3] = dateTimePicker2.Value.ToString();
                pramvalue[4] = textBox1.Text;
                pramvalue[5] = textBox3.Text;
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                pramtype[4] = SqlDbType.Int;
                pramtype[5] = SqlDbType.Int;


                //con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("cancel_claim", pramname, pramvalue, pramtype);
                //MessageBox.Show("");
                con.CloseConnection();

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }
           
                   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                dateTimePicker2.Text = "";
                dateTimePicker1.Text = "";
                numericUpDown1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";

                dataGridView1.DataSource = "";
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void اضافهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        }   
}