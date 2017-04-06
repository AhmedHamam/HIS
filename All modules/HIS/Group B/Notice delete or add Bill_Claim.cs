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
    public partial class NoticedeleteoraddBillClaim : Form
    {
        Connection con = new Connection();
        public NoticedeleteoraddBillClaim()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
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
                string[] pramname = new string[5];
                string[] pramvalue = new string[5];
                SqlDbType[] pramtype = new SqlDbType[5];
                pramname[0] = "@x1";
                pramname[1] = "@x2";
                pramname[2] = "@x3";
                pramname[3] = "@x4";
                pramname[4] = "@x5";
              
                pramvalue[0] = dateTimePicker1.Value.ToString();
                pramvalue[1] = dateTimePicker2.Value.ToString();
                pramvalue[2] = textBox1.Text;
                pramvalue[3] = textBox5.Text;
                pramvalue[4] = comboBox1.SelectedItem.ToString(); 
               
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.Int;
                pramtype[3] = SqlDbType.Int;
                pramtype[4] = SqlDbType.VarChar;
          
                //con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("Notice_delete_or_add_Bill_Claim", pramname, pramvalue, pramtype);
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
                //comboBox2.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
