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
    public partial class مراجعهفواتيرالمرضى : Form
        
    {
        Connection con = new Connection();
        /*
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");*/
        public مراجعهفواتيرالمرضى()
        {
            InitializeComponent();
        }

        public void setV(string e, string f)
        {
            CodeTextBox.Text = e;
            textBox2.Text = f;
        }

        public void setValue(string s, string l)
        {
            textBox3.Text = s;
            textBox4.Text = l;
        } 

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void ShowData()
        {
            if (String.IsNullOrEmpty(CodeTextBox.Text) && String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الجهه و كود الفئه ");
                CodeTextBox.Focus();
            }
            else if (String.IsNullOrEmpty(CodeTextBox.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الجهه");
                CodeTextBox.Focus();
            }
            else if (CodeTextBox.Text.Any(c => Char.IsLetter(c)))
            {
                MessageBox.Show("من فضلك ادخل كود الجهه بشكل صحيح");
                CodeTextBox.Focus();
            }
            else if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الفئه");
                textBox3.Focus();
            }
            else if (textBox3.Text.Any(c => Char.IsLetter(c)))
            {
                MessageBox.Show("من فضلك ادخل كود الفئه بشكل صحيح");
                textBox3.Focus();
            }
            else if (textBox2.Text.Any(c => Char.IsNumber(c)))
            {
                MessageBox.Show("من فضلك ادخل اسم الجهه بشكل صحيح");
                textBox2.Focus();
            }
            else if (textBox4.Text.Any(c => Char.IsNumber(c)))
            {
                MessageBox.Show("من فضلك ادخل اسم الفئه بشكل صحيح");
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
                            string[] pramname = new string[4];
                            string[] pramvalue = new string[4];
                            SqlDbType[] pramtype = new SqlDbType[4];
                            pramname[0] = "@x1";
                            pramname[1] = "@x2";
                            pramname[2] = "@x3";
                            pramname[3] = "@x4";

                            pramvalue[0] = CodeTextBox.Text;
                            pramvalue[1] = textBox3.Text;
                            pramvalue[2] = dateTimePicker1.Value.ToString();
                            pramvalue[3] = dateTimePicker2.Value.ToString();

                            pramtype[0] = SqlDbType.Int;
                            pramtype[1] = SqlDbType.Int;
                            pramtype[2] = SqlDbType.VarChar;
                            pramtype[3] = SqlDbType.VarChar;

                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_bill_patientT", pramname, pramvalue, pramtype);
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

                        pramvalue[0] = CodeTextBox.Text;
                        pramvalue[1] = textBox3.Text;
                        pramvalue[2] = dateTimePicker1.Value.ToString();
                        pramvalue[3] = dateTimePicker2.Value.ToString();

                        pramtype[0] = SqlDbType.Int;
                        pramtype[1] = SqlDbType.Int;
                        pramtype[2] = SqlDbType.VarChar;
                        pramtype[3] = SqlDbType.VarChar;

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_bill_patientF", pramname, pramvalue, pramtype);
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
            الفئات1 f = new الفئات1(this);
            f.Show();
        }

        

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    string sql = "update Registeration_patientRegisteration set review=true where Registeration_patientRegisteration.patient_id =" + n + " and Registeration_patientRegisteration.catogrical_code = " + k;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  foreach (DataGridViewCell item in dataGridView1.SelectedCells)
            { 
                if(item.Selected)
                dataGridView1.Rows.RemoveAt(item.RowIndex); 
            }*/
           // foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
               // if (dataGridView1.SelectedRows[0].IsNewRow)
              
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);

                    dataGridView1_CellValueChanged(sender, e);

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            الفئات1 f = new الفئات1(this);
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            الجهات1 f = new الجهات1(this);
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                CodeTextBox.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                dataGridView1.DataSource = "";
            }
        
        }

    }
}
