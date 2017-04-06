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
    public partial class اذونالصرفللمخازن : Form
    {
        Connection con = new Connection();
        public اذونالصرفللمخازن()
        {
            InitializeComponent();
        }
        public void setV(string s, string l)
        {
            textBox2.Text = s;
            textBox4.Text = l;
        }
        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();  
        }
        private void ShowData()
        {
            if (String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الإذن و رقم المخزن  ");
                textBox3.Focus();
            }
            else
            if (String.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم الإذن");
                    textBox3.Focus();
                }
            else
             if (textBox3.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الإذن بشكل صحيح");
                    textBox3.Focus();
                }
             else
                 if (String.IsNullOrEmpty(textBox1.Text))
                 {
                     MessageBox.Show("من فضلك ادخل رقم الإذن الاخر");
                     textBox1.Focus();
                 }
                 else
                     if (textBox1.Text.Any(c => Char.IsLetter(c)))
                     {
                         MessageBox.Show("من فضلك ادخل رقم الإذن الاخر بشكل صحيح");
                         textBox1.Focus();
                     }
            else
             if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم المخزن ");
                    textBox2.Focus();
                }
             else
               if (textBox2.Text.Any(c => Char.IsLetter(c)))
                  {
                      MessageBox.Show("من فضلك ادخل رقم المخزن بشكل صحيح");
                      textBox2.Focus();
                  }
               else
            
                    if (textBox4.Text.Any(c => Char.IsNumber(c)))
                    {
                        MessageBox.Show("من فضلك ادخل اسم المخزن بشكل صحيح");
                        textBox4.Focus();
                    }
                        else
                        {
                        
                            if (comboBox1.Text != null)
                            {
                                if (comboBox1.Text == "مراجع")
                                {
                                    try
                                    {

                                        con.OpenConection();
                                        //not find table [0]
                                        string[] pramname = new string[7];
                                        string[] pramvalue = new string[7];
                                        SqlDbType[] pramtype = new SqlDbType[7];
                                        pramname[0] = "@x1";
                                        pramname[1] = "@x2";
                                        pramname[2] = "@x3";
                                        pramname[3] = "@x4";
                                        pramname[4] = "@x5";
                                        pramname[5] = "@x6";
                                        pramname[6] = "@x7";


                                        pramvalue[0] = textBox3.Text;
                                        pramvalue[1] = textBox1.Text;
                                        pramvalue[2] = dateTimePicker1.Value.ToString();
                                        pramvalue[3] = dateTimePicker2.Value.ToString();
                                        pramvalue[4] = comboBox1.Text;
                                        pramvalue[5] = textBox2.Text;
                                        pramvalue[6] = textBox4.Text;


                                        pramtype[0] = SqlDbType.Int;
                                        pramtype[1] = SqlDbType.Int;
                                        pramtype[2] = SqlDbType.VarChar;
                                        pramtype[3] = SqlDbType.VarChar;
                                        pramtype[4] = SqlDbType.VarChar;
                                        pramtype[5] = SqlDbType.Int;
                                        pramtype[6] = SqlDbType.VarChar;
                                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_bill_inventoryT", pramname, pramvalue, pramtype);
                                        //MessageBox.Show("");
                                        con.CloseConnection();
                                    }
                                    catch (Exception)
                                    {

                                        MessageBox.Show("من فضلك ادخل البيانات كاملة ");

                                    }

                                }
                            }
                            else
                            {
                                try
                                {

                                    con.OpenConection();
                                    //not find table [0]
                                    string[] pramname = new string[7];
                                    string[] pramvalue = new string[7];
                                    SqlDbType[] pramtype = new SqlDbType[7];
                                    pramname[0] = "@x1";
                                    pramname[1] = "@x2";
                                    pramname[2] = "@x3";
                                    pramname[3] = "@x4";
                                    pramname[4] = "@x5";
                                    pramname[5] = "@x6";
                                    pramname[6] = "@x7";


                                    pramvalue[0] = textBox3.Text;
                                    pramvalue[1] = textBox1.Text;
                                    pramvalue[2] = dateTimePicker1.Value.ToString();
                                    pramvalue[3] = dateTimePicker2.Value.ToString();
                                    pramvalue[4] = comboBox1.Text;
                                    pramvalue[5] = textBox2.Text;
                                    pramvalue[6] = textBox4.Text;


                                    pramtype[0] = SqlDbType.Int;
                                    pramtype[1] = SqlDbType.Int;
                                    pramtype[2] = SqlDbType.VarChar;
                                    pramtype[3] = SqlDbType.VarChar;
                                    pramtype[4] = SqlDbType.VarChar;
                                    pramtype[5] = SqlDbType.Int;
                                    pramtype[6] = SqlDbType.VarChar;
                                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_bill_inventoryF", pramname, pramvalue, pramtype);
                                    //MessageBox.Show("");
                                    con.CloseConnection();
                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");

                                }
                            }
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
                comboBox1.Text = "";
                comboBox3.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            المخازن1 f = new المخازن1(this);
            f.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int x = dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
            if (e.RowIndex == -1)
            { return; }
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
            if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue)
            {
                int n = Int32.Parse(dataGridView1[1, e.RowIndex].Value.ToString());
                int k = Int32.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
                string sql = "update store_inventoryOperation set review=true where store_inventoryOperation.inventory_id  =" + k + " and store_inventoryOperation.operation_id  = " + n;
                try
                {
                  
                    con.OpenConection();
                    //cmd = new sqlCommand(sql, con);
                    //cmd.ExecuteNonQuery();
                    con.ExecuteQueries(sql);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.CloseConnection();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
