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
     
    public partial class البحث_بالمجموعه : Form
    {

        

        Connection con = new Connection();
      البحث_بالمستخدمين y;

        public البحث_بالمجموعه()
        {
            InitializeComponent();
        }

        public البحث_بالمجموعه(البحث_بالمستخدمين x)
        {
            InitializeComponent();
            y = x;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void البحث_بالمجموعه_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            
            con.OpenConection();
            con.DataReader("groups_select_All");
            dataGridView1.DataSource = con.ShowDataInGridView("groups_select_All");


            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("الرجاء ادخال البيانات الناقصه");
            }


            if (textBox1.Text != "" || textBox3.Text != "")
            {


                if (textBox1.Text != "" && textBox1.Text.All(char.IsDigit) == true)
                {

                    try
                    {

                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@x";


                        pramvalue[0] = textBox1.Text;


                        pramtype[0] = SqlDbType.Int;

                        con.OpenConection();
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("groups_select_All_use_groupcode", pramname, pramvalue, pramtype);
                        con.CloseConnection();



                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }


                }





                else if (textBox3.Text != "" && textBox3.Text.All(char.IsDigit) == false)
                {
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@x";


                    pramvalue[0] = textBox3.Text;


                    pramtype[0] = SqlDbType.Text;

                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("groups_select_All_use_groupName", pramname, pramvalue, pramtype);
                    con.CloseConnection();
                }
                else { MessageBox.Show("الرجاء ادخال البيانات صحيحه"); }


            }
        }
             
            
        
       



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
           
            y.Setvalue(row);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
           