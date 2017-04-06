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
    public partial class For24 : Form
    {
        Connection con = new Connection();
        string c;
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");

        //DataTable dt;
        //SqlCommand cmd;
        public For24()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الفاتورة   ");
                textBox1.Focus();
            }
            else
                if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الفاتورة  بشكل صحيح");
                    textBox1.Focus();
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
                        pramvalue[0] = textBox1.Text; ;

                        pramtype[0] = SqlDbType.Int;
                        if (textBox1.Text == "")
                            MessageBox.Show("من فضلك ادخل رقم الفاتوره");
                        else
                        {

                            dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("deletbill", pramname, pramvalue, pramtype);
                            MessageBox.Show("deleted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { con.CloseConnection(); }

                }
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الفاتورة   ");
                textBox1.Focus();
            }
            else
                if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الفاتورة  بشكل صحيح");
                    textBox1.Focus();
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
                        pramvalue[0] = textBox1.Text;
                        pramtype[0] = SqlDbType.VarChar;

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc(" billsearch", pramname, pramvalue, pramtype);

                        con.CloseConnection();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
        }
        private void button3_Click(object sender, EventArgs e)
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

        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
