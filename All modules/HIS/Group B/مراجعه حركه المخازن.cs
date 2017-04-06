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
    public partial class مراجعهحركهالمخازن : Form
    {
        Connection con = new Connection();
       /* DataTable dt;
        sqlDataReader dataReader;
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");*/
        public مراجعهحركهالمخازن()
        {
            InitializeComponent();
        }
        public void setValue(string s, string l)
        {
            textBox3.Text = s;
            textBox4.Text = l;
        }

        public void setV(string s)
        {
            textBox5.Text = s;
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox4.Text = "";
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
                comboBox3.Text = "";
                textBox5.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void Form6_Load(object sender, EventArgs e)
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
             if (String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم المخزن و رقم الحركه ورقم المستخدم  ");
                textBox1.Focus();
            }
            else
            if (String.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم المخزن");
                    textBox3.Focus();
                }
            else
             if (textBox3.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم المخزن بشكل صحيح");
                    textBox3.Focus();
                }
            else
             if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم الحركه ");
                    textBox1.Focus();
                }
             else
               if (textBox1.Text.Any(c => Char.IsLetter(c)))
                  {
                      MessageBox.Show("من فضلك ادخل رقم الحركه بشكل صحيح");
                      textBox1.Focus();
                  }
               else
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم المستخدم ");
                textBox5.Focus();
            }
            else
                if (textBox5.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم المستخدم بشكل صحيح");
                    textBox5.Focus();
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
                                    pramname[2] = "@x4";
                                    pramname[3] = "@x5";
                                    pramname[4] = "@x6";
                                    pramname[5] = "@x7";
                                    pramname[6] = "@x8";


                                    pramvalue[0] = dateTimePicker1.Value.ToString();
                                    pramvalue[1] = dateTimePicker2.Value.ToString();
                                    pramvalue[2] = textBox1.Text;
                                    pramvalue[3] = comboBox1.Text;
                                    pramvalue[4] = textBox3.Text;
                                    pramvalue[5] = comboBox3.Text;
                                    pramvalue[6] = textBox5.Text;


                                    pramtype[0] = SqlDbType.VarChar;
                                    pramtype[1] = SqlDbType.VarChar;
                                    pramtype[2] = SqlDbType.Int;
                                    pramtype[3] = SqlDbType.VarChar;
                                    pramtype[4] = SqlDbType.Int;
                                    pramtype[5] = SqlDbType.VarChar;
                                    pramtype[6] = SqlDbType.VarChar;
                                    pramtype[7] = SqlDbType.VarChar;

                                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_inventory_movementT", pramname, pramvalue, pramtype);
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
                                pramname[2] = "@x4";
                                pramname[3] = "@x5";
                                pramname[4] = "@x6";
                                pramname[5] = "@x7";
                                pramname[6] = "@x8";


                                pramvalue[0] = dateTimePicker1.Value.ToString();
                                pramvalue[1] = dateTimePicker2.Value.ToString();
                                pramvalue[2] = textBox1.Text;
                                pramvalue[3] = comboBox1.Text;
                                pramvalue[4] = textBox3.Text;
                                pramvalue[5] = comboBox3.Text;
                                pramvalue[6] = textBox5.Text;


                                pramtype[0] = SqlDbType.VarChar;
                                pramtype[1] = SqlDbType.VarChar;
                                pramtype[2] = SqlDbType.Int;
                                pramtype[3] = SqlDbType.VarChar;
                                pramtype[4] = SqlDbType.Int;
                                pramtype[5] = SqlDbType.VarChar;
                                pramtype[6] = SqlDbType.VarChar;
                                pramtype[7] = SqlDbType.VarChar;

                                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_inventory_movementF", pramname, pramvalue, pramtype);
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

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            المخازن1 f = new المخازن1(this);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            المستخدميين1 f = new المستخدميين1(this);
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
                int k = Int32.Parse(dataGridView1[5, e.RowIndex].Value.ToString());
                string sql = "update movements set review=true where movements.movement_Code =" + n + " and movements.claim_id = " + k;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            المخازن1 f = new المخازن1(this);
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            المستخدميين1 f = new المستخدميين1(this);
            f.Show();
        }
    }
}
