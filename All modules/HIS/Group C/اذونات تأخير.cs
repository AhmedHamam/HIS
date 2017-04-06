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
    public partial class اذونات_تأخير : Form
    {
        Connection con = new Connection();
        public اذونات_تأخير()
        {
            InitializeComponent();
        }
        public اذونات_تأخير(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8)
        {
            InitializeComponent();
            textBox5.Text = s1.ToString();
            textBox1.Text = s2.ToString();
            textBox4.Text = s3.ToString();
            textBox3.Text = s4.ToString();
            textBox10.Text =s5.ToString();
            textBox8.Text = s6.ToString();
            textBox9.Text = s7.ToString();
            textBox2.Text = s8.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();


            if (textBox6.Text.Length != 0 & textBox7.Text.Length != 0)
            {

                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox6.Text, textBox7.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_permit_late", s, s2, s3);



            }
            else if ((checkBox1.Checked == true & d.Length != 0 & d2.Length != 0) & (textBox6.Text.Length != 0 & textBox7.Text.Length != 0))
            {


                string[] s = new string[] { "@x", "@y", "@l", "@m" };
                string[] s2 = new string[] { textBox6.Text, textBox7.Text, d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Date, SqlDbType.Date };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_permit_late3", s, s2, s3);

            }

            else if (checkBox1.Checked == true & d.Length != 0 & d2.Length != 0)
            {

                string[] s = new string[] { "@l", "@m" };
                string[] s2 = new string[] { d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_permit_late2", s, s2, s3);
            }

            else
            {

                string[] s = new string[] { "@z" };
                string[] s2 = new string[] { textBox5.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_permit_late4", s, s2, s3);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox6.Text = null;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox10.Text = null;
            checkBox1.Checked = false;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String d1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            String d2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show(" التاريخ الاول يجب ان يكون اقل من الثانى ");



            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox7.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox7.Text = null;
                return;
            }
        }

        private void اذونات_تأخير_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           عرض_بيانات_الموظفين6 f = new عرض_بيانات_الموظفين6();
           f.Show();
            this.Close();
        }
    }
}
