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
    public partial class تعديلامرتوريد : Form
    {
        Connection con = new Connection();
       

       
        public تعديلامرتوريد()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            con.OpenConection();
            string[] pramname = new string[1];
            string[] pramvalue = new string[1];
            SqlDbType[] pramtype = new SqlDbType[1];
            pramname[0] = "@id";
            pramvalue[0] = textBox1.Text;
            pramtype[0] = SqlDbType.VarChar;
            if (textBox1.Text == "")
                MessageBox.Show("من فضلك ادخل كود الامر");
            else
            {

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showcommandsupplaybyid", pramname, pramvalue, pramtype);

                con.CloseConnection();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {

                    textBox1.Text = "";

                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showCommand");
            con.CloseConnection();

            }

        private void button4_Click(object sender, EventArgs e)
        {
            //da.Update(ds);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }
            
        }
        }
    

