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
    public partial class محرك_البحث_عن_مريض_تعديل_اسم : Form
    {
        Connection con = new Connection();

        تقرير_تعديل_اسم_مريض y;
      
        int count2;
        int count;
        public محرك_البحث_عن_مريض_تعديل_اسم()
        {
            InitializeComponent();
        }
        public محرك_البحث_عن_مريض_تعديل_اسم(تقرير_تعديل_اسم_مريض   x )
        {
            InitializeComponent();
            y = x;
        }
         

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            con.OpenConection();
            if (textBox1.Text != "" && textBox3.Text == "")
            {
                try
                {
                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient2", s, s2, s3);

                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox1.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient4", s, s2, s3);



                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else if (textBox3.Text != "" && textBox1.Text == "")
            {
                try
                {
                    con.OpenConection();


                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }

            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                try
                {



                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient5", s, s2, s3);



                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox3.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3);

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else
            {
                try
                {

                    con.OpenConection();

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient10");


                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient9");



                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }


        }
        private void محرك_البحث_عن_مريض_تعديل_اسم_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            // ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            count = 0;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void fill(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int id = int.Parse(a);
            string b = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           //  string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

           
            /*  تقرير_بيانات_المريض t = new تقرير_بيانات_المريض(id,b);
              t.Show();*/

            y.setValue(id,b);
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم المريض ");
                textBox3.Text = null;
                return;
            }
        }

      
    }
}
