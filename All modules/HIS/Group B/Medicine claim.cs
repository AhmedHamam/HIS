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
    public partial class Medicineclaim : Form
    {
        Connection con = new Connection();
        public Medicineclaim()
        {
            InitializeComponent();
        }
        public void setValue(string d, string c)
        {
            textBox2.Text = d;
            textBox4.Text = c;
        }

        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox5.Text = f;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                
                dateTimePicker1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
              
                dateTimePicker4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                dataGridView1.DataSource = "";
            }
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
                pramvalue[0] = comboBox2.SelectedItem.ToString() ;
                pramvalue[1] = textBox3.Text;
                pramvalue[2] = textBox1.Text;
                pramvalue[3] = comboBox1.SelectedItem.ToString();
                pramvalue[4] = dateTimePicker4.Value.ToString();
                pramvalue[5] = dateTimePicker1.Value.ToString();
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.Int;
                pramtype[3] = SqlDbType.VarChar;
                pramtype[4] = SqlDbType.VarChar;
                pramtype[5] = SqlDbType.VarChar;





                

                
                    //con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("Medicine_claim", pramname, pramvalue, pramtype);
                    //MessageBox.Show("");
                    con.CloseConnection();

                

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }

           
            
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try { con.OpenConection(); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
