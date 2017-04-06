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
    public partial class استمارهدفعلمورد : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataReader dr;
        //SqlCommand cmd;
        //DataTable dt;
        public استمارهدفعلمورد()
        {
            InitializeComponent();
        }
        public void setVal(string c)
        {
            textBox1.Text = c;
           

        }
        public void setV(string d)
        {
            textBox2.Text = d;


        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الفاتورة ");
                textBox1.Focus();
            }
            else
                if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الفاتورة بشكل صحيح");
                    textBox1.Focus();
                }

                else

                    if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("من فضلك كود الخصم ");
                        textBox2.Focus();
                    }
                    else
                        if (textBox2.Text.Any(c => Char.IsLetter(c)))
                        {
                            MessageBox.Show("من فضلك ادخل كود الخصم بشكل صحيح");
                            textBox2.Focus();
                        }
                        else
                        {
                            
                                try
                                {
                                    con.OpenConection();

                                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showbill");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { con.CloseConnection(); }
                                //con.Open();
                                //SqlCommand cmd = new SqlCommand("t33", con);
                                //cmd.CommandType = CommandType.StoredProcedure;
                                ///*cmd = new SqlCommand();
                                //cmd.Connection = con;
                                //cmd.CommandText = "select bill.bill_id as'رقم الفاتورة ',bill_date as'تاريخ الفاتورة',payment_value as 'الاجمالى',total_after_discount as'الاجمالى بعد الخصم'  from bill,discount where bill.bill_id=discount.bill_id and bill.bill_id=@id and discount_id=@i_d  ";
                                //cmd.Prepare();*/
                                //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                                //cmd.Parameters.AddWithValue("@i_d", textBox2.Text);
                                ////  cmd.Parameters.AddWithValue("@name", textBox2.Text);
                                //SqlDataReader dr = cmd.ExecuteReader();
                                //dt = new DataTable();
                                //dt.Load(dr);

                                //dataGridView1.DataSource = dt;
                           
                        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";

                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

       

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            For27 f27 = new For27(this);
            f27.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            For28 f28 = new For28(this);
            f28.Show();
        }
    }
}
