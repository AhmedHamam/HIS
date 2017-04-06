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
    public partial class مراجعهاشعاراتالعملاء : Form
    {
        Connection con = new Connection();
       /* sqlDataReader dataReader;
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");*/
        public مراجعهاشعاراتالعملاء()
        {
            InitializeComponent();
        }

        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox2.Text = f;
        }
        public void setValue(string e, string f)
        {
            textBox4.Text = e;
            textBox3.Text = f;
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
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الجهه و كود الجهه الفرعيه ورقم المطالبه  ");
                textBox1.Focus();
            }
            else
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("من فضلك ادخل كود الجهه");
                    textBox1.Focus();
                }
                else
                    if (textBox1.Text.Any(c => Char.IsLetter(c)))
                    {
                        MessageBox.Show("من فضلك ادخل كود الجهه بشكل صحيح");
                        textBox1.Focus();
                    }
                    else
                        if (String.IsNullOrEmpty(textBox4.Text))
                        {
                            MessageBox.Show("من فضلك ادخل كود الجهه الفرعيه ");
                            textBox4.Focus();
                        }
                        else
                            if (textBox4.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل كود الجهه الفرعيه بشكل صحيح");
                                textBox4.Focus();
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
                                        if (textBox2.Text.Any(c => Char.IsNumber(c)))
                                        {
                                            MessageBox.Show("من فضلك ادخل اسم الجهه بشكل صحيح");
                                            textBox2.Focus();
                                        }
                                        else
                                            if (textBox3.Text.Any(c => Char.IsNumber(c)))
                                            {
                                                MessageBox.Show("من فضلك ادخل اسم الجهه الفرعيه بشكل صحيح");
                                                textBox3.Focus();
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


                                                            pramvalue[0] = comboBox2.Text;
                                                            pramvalue[1] = textBox1.Text;
                                                            pramvalue[2] = comboBox1.Text;
                                                            pramvalue[3] = textBox2.Text;
                                                            pramvalue[4] = dateTimePicker4.Value.ToString();
                                                            pramvalue[5] = dateTimePicker1.Value.ToString();
                                                            pramvalue[6] = textBox3.Text;


                                                            pramtype[0] = SqlDbType.VarChar;
                                                            pramtype[1] = SqlDbType.Int;
                                                            pramtype[2] = SqlDbType.VarChar;
                                                            pramtype[3] = SqlDbType.Int;
                                                            pramtype[4] = SqlDbType.VarChar;
                                                            pramtype[5] = SqlDbType.VarChar;
                                                            pramtype[6] = SqlDbType.Int;





                                                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_customer_noticeT", pramname, pramvalue, pramtype);
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


                                                        pramvalue[0] = comboBox2.Text;
                                                        pramvalue[1] = textBox1.Text;
                                                        pramvalue[2] = comboBox1.Text;
                                                        pramvalue[3] = textBox2.Text;
                                                        pramvalue[4] = dateTimePicker4.Value.ToString();
                                                        pramvalue[5] = dateTimePicker1.Value.ToString();
                                                        pramvalue[6] = textBox3.Text;


                                                        pramtype[0] = SqlDbType.VarChar;
                                                        pramtype[1] = SqlDbType.Int;
                                                        pramtype[2] = SqlDbType.VarChar;
                                                        pramtype[3] = SqlDbType.Int;
                                                        pramtype[4] = SqlDbType.VarChar;
                                                        pramtype[5] = SqlDbType.VarChar;
                                                        pramtype[6] = SqlDbType.Int;





                                                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_customer_noticeF", pramname, pramvalue, pramtype);
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

        private void Form18_Load(object sender, EventArgs e)
        {

        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                string sql = "update notice set review=true where notice.claim_id =" + n + " and notice.notic_id = " + k;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            الجهات1 f = new الجهات1(this);
            f.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            الجهاتالفرعيه1 f = new الجهاتالفرعيه1(this);
            f.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                dataGridView1.DataSource = "";
        }
        }

        private void مراجعهاشعاراتالعملاء_Load(object sender, EventArgs e)
        {

        }
    }
}
