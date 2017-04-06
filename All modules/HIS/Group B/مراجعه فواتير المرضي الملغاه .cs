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
    public partial class فواتيرالمرضيالملغاه : Form
    {
        Connection con = new Connection();
       /* sqlDataReader dataReader;
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");*/
        public فواتيرالمرضيالملغاه()
        {
            InitializeComponent();
        }
        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox2.Text = f;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            المرضى1 f = new المرضى1(this);
            f.Show();
        }

        private void ShowData()
        {
            if (String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الفاتوره و رقم المريض ");
                textBox3.Focus();
            }
            else
                if (String.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم الفاتوره");
                    textBox3.Focus();
                }
                else
                    if (textBox3.Text.Any(c => Char.IsLetter(c)))
                    {
                        MessageBox.Show("من فضلك ادخل رقم الفاتوره بشكل صحيح");
                        textBox3.Focus();
                    }
                    else
                        if (String.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("من فضلك ادخل رقم المريض");
                            textBox1.Focus();
                        }

                        else
                            if (textBox1.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل رقم المريض بشكل صحيح");
                                textBox1.Focus();
                            }
                            else
                                if (textBox2.Text.Any(c => Char.IsNumber(c)))
                                {
                                    MessageBox.Show("من فضلك ادخل اسم المريض بشكل صحيح");
                                    textBox2.Focus();
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
                                                string[] pramname = new string[4];
                                                string[] pramvalue = new string[4];
                                                SqlDbType[] pramtype = new SqlDbType[4];
                                                pramname[0] = "@x1";
                                                pramname[1] = "@x2";
                                                pramname[2] = "@x3";
                                                pramname[3] = "@x4";

                                                pramvalue[0] = textBox3.Text;
                                                pramvalue[1] = textBox3.Text;
                                                pramvalue[2] = dateTimePicker1.Value.ToString();
                                                pramvalue[3] = dateTimePicker2.Value.ToString();

                                                pramtype[0] = SqlDbType.Int;
                                                pramtype[1] = SqlDbType.Int;
                                                pramtype[2] = SqlDbType.VarChar;
                                                pramtype[3] = SqlDbType.VarChar;

                                                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_canceled_bill_patientT", pramname, pramvalue, pramtype);
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
                                            string[] pramname = new string[4];
                                            string[] pramvalue = new string[4];
                                            SqlDbType[] pramtype = new SqlDbType[4];
                                            pramname[0] = "@x1";
                                            pramname[1] = "@x2";
                                            pramname[2] = "@x3";
                                            pramname[3] = "@x4";

                                            pramvalue[0] = textBox3.Text;
                                            pramvalue[1] = textBox3.Text;
                                            pramvalue[2] = dateTimePicker1.Value.ToString();
                                            pramvalue[3] = dateTimePicker2.Value.ToString();

                                            pramtype[0] = SqlDbType.Int;
                                            pramtype[1] = SqlDbType.Int;
                                            pramtype[2] = SqlDbType.VarChar;
                                            pramtype[3] = SqlDbType.VarChar;

                                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_canceled_bill_patientF", pramname, pramvalue, pramtype);
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
        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
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
                int k = Int32.Parse(dataGridView1[4, e.RowIndex].Value.ToString());
                string sql = "update Visit_Bill set review=true where Visit_Bill.ID =" + n + " and Visit_Bill.User_code = " + k;
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
    }
}
