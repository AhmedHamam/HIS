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
    public partial class For11 : Form
    {
        Connection con = new Connection();
        public For11()
        {
            InitializeComponent();
        }
        public void setV(string c)
        {
            textBox1.Text = c;

        }
        private void Form11_Load(object sender, EventArgs e)
        {
            
            
        }






        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox7.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    // textBox8.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            For14 f14 = new For14(this);
            f14.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الفاتورة");
                textBox7.Focus();
            }
            else
                if (textBox7.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الفاتورة بشكل صحيح");
                    textBox7.Focus();
                }

                else
                {


                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@id";
                        pramvalue[0] = textBox7.Text;
                        pramtype[0] = SqlDbType.VarChar;

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("billsearch", pramname, pramvalue, pramtype);

                        con.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("bill_show");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
