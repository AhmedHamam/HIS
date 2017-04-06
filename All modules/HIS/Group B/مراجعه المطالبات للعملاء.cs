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
    public partial class مراجعهالمطالباتللعملاء : Form
    {
        Connection con = new Connection();
       
        public مراجعهالمطالباتللعملاء()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                textBox5.Text = "";
                comboBox2.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();   
        }
        private void ShowData()
        {
            if (String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الجهه و كود الجهه الفرعيه ورقم المطالبه  ");
                textBox1.Focus();
            }
            else
                if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("من فضلك ادخل كود الجهه");
                    textBox2.Focus();
                }
                else
                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
                    {
                        MessageBox.Show("من فضلك ادخل كود الجهه بشكل صحيح");
                        textBox2.Focus();
                    }
                    else
                        if (String.IsNullOrEmpty(textBox3.Text))
                        {
                            MessageBox.Show("من فضلك ادخل كود الجهه الفرعيه ");
                            textBox3.Focus();
                        }
                        else
                            if (textBox3.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل كود الجهه الفرعيه بشكل صحيح");
                                textBox3.Focus();
                            }
                            else
                                if (String.IsNullOrEmpty(textBox5.Text))
                                {
                                    MessageBox.Show("من فضلك ادخل رقم المطالبه ");
                                    textBox5.Focus();
                                }
                                else
                                    if (textBox5.Text.Any(c => Char.IsLetter(c)))
                                    {
                                        MessageBox.Show("من فضلك ادخل رقم المطالبه بشكل صحيح");
                                        textBox5.Focus();
                                    }
                                    else
                                        if (textBox4.Text.Any(c => Char.IsNumber(c)))
                                        {
                                            MessageBox.Show("من فضلك ادخل اسم الجهه بشكل صحيح");
                                            textBox4.Focus();
                                        }
                                        else
                                            if (textBox1.Text.Any(c => Char.IsNumber(c)))
                                            {
                                                MessageBox.Show("من فضلك ادخل اسم الجهه الفرعيه بشكل صحيح");
                                                textBox1.Focus();
                                            }
              else
              {
                  if (comboBox3.Text != null)
                  {
                      if (comboBox3.Text == "مراجع")
                      {
                           try
                           {
                               con.OpenConection();
                               //not find table [0]
                               string[] pramname = new string[4];
                               string[] pramvalue = new string[4];
                               SqlDbType[] pramtype = new SqlDbType[4];
                               pramname[0] = "@x1";
                               pramname[1] = "@x3";
                               pramname[2] = "@x4";
                               pramname[3] = "@x5";
                               pramvalue[0] = textBox2.Text;
                               pramvalue[1] = textBox5.Text;
                               pramvalue[2] = comboBox2.Text;
                               pramvalue[3] = comboBox1.Text;
                               pramtype[0] = SqlDbType.Int;
                               pramtype[1] = SqlDbType.Int;
                               pramtype[2] = SqlDbType.VarChar;
                               pramtype[3] = SqlDbType.VarChar;
                               dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_customer_claimsT", pramname, pramvalue, pramtype);
                               //MessageBox.Show("");
                               con.CloseConnection();
                            }
                               catch (Exception)
                            {
                                   MessageBox.Show("من فضلك ادخل البيانات كاملة ");                     }

                            }
                       }
                       else 
                       {
                            try
                            {
                                                        con.OpenConection();
                                                        //not find table [0]
                                                        string[] pramname = new string[4];
                                                        string[] pramvalue = new string[4];
                                                        SqlDbType[] pramtype = new SqlDbType[4];
                                                        pramname[0] = "@x1";
                                                        pramname[1] = "@x3";
                                                        pramname[2] = "@x4";
                                                        pramname[3] = "@x5";

                                                        pramvalue[0] = textBox2.Text;
                                                        pramvalue[1] = textBox5.Text;
                                                        pramvalue[2] = comboBox2.Text;
                                                        pramvalue[3] = comboBox1.Text;

                                                        pramtype[0] = SqlDbType.Int;
                                                        pramtype[1] = SqlDbType.Int;
                                                        pramtype[2] = SqlDbType.VarChar;
                                                        pramtype[3] = SqlDbType.VarChar;

                                                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_customer_claimsF", pramname, pramvalue, pramtype);
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void setV(string s, string l)
        {
            textBox2.Text = s;
            textBox4.Text = l;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            الجهات1 f = new الجهات1(this);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            الجهاتالفرعيه1 f = new الجهاتالفرعيه1(this);
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
                int k = Int32.Parse(dataGridView1[3, e.RowIndex].Value.ToString());
                string sql = "update claims set review=true where claims.claim_id =" + n + " and claims.actor_code = " + k;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }
    }
}
