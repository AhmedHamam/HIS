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
    public partial class For15 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        public For15()
        {
            InitializeComponent();
        }
        public void setVal(string c, string b, string d, string t)
        {
            textBox6.Text = c;
            textBox8.Text = b;
            textBox5.Text = d;
            textBox9.Text = t;



        }

        public void setVal(string c, string d)
        {
            textBox1.Text = c;
            textBox7.Text = d;

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Form16 f16 = new Form16(this);
            f16.Show();*/
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("من فضلك ادخل نوع الخصم ");
                textBox6.Focus();
            }
            else
                if (textBox6.Text.Any(c => Char.IsNumber(c)))
                {
                    MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                    textBox6.Focus();
                }

                else

                    if (String.IsNullOrEmpty(textBox8.Text))
                    {
                        MessageBox.Show("من فضلك عملية الخصم ");
                        textBox8.Focus();
                    }


                    else
                        if (String.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  ");
                            textBox1.Focus();
                        }
                        else
                            if (textBox1.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  بشكل صحيح");
                                textBox1.Focus();
                            }

                            else
                                if (String.IsNullOrEmpty(textBox5.Text))
                                {
                                    MessageBox.Show("من فضلك نسبه الخصم   ");
                                    textBox5.Focus();
                                }
                                else
                                    if (textBox5.Text.Any(c => Char.IsLetter(c)))
                                    {
                                        MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                        textBox5.Focus();
                                    }

                                    else
                                    {


                                        double a = Double.Parse(textBox5.Text) / 100.0;
                                        double c = Double.Parse(textBox1.Text);
                                        double s = (a) * c;
                                        textBox2.Text = s.ToString();
                                        double g = Double.Parse(textBox1.Text) - Double.Parse(textBox2.Text);
                                        textBox4.Text = g.ToString();






                                    }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            For17 f17 = new For17(this);
            f17.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            /*if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الخصم   ");
                textBox3.Focus();
            }
            else
                if (textBox3.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل كود الخصم بشكل صحيح");
                    textBox3.Focus();
                }

                else*/
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("من فضلك ادخل نوع الخصم ");
                textBox6.Focus();
            }
            else
                if (textBox6.Text.Any(c => Char.IsNumber(c)))
                {
                    MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                    textBox6.Focus();
                }

                else

                    if (String.IsNullOrEmpty(textBox8.Text))
                    {
                        MessageBox.Show("من فضلك عملية الخصم ");
                        textBox8.Focus();
                    }


                    else
                        if (String.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("من فضلك الاجمالى قبل الخصم   ");
                            textBox1.Focus();
                        }
                        else
                            if (textBox1.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  بشكل صحيح");
                                textBox1.Focus();
                            }

                            else
                                if (String.IsNullOrEmpty(textBox5.Text))
                                {
                                    MessageBox.Show("من فضلك نسبه الخصم   ");
                                    textBox5.Focus();
                                }
                                else
                                    if (textBox5.Text.Any(c => Char.IsLetter(c)))
                                    {
                                        MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                        textBox5.Focus();
                                    }

                                    else
                                        if (String.IsNullOrEmpty(textBox7.Text))
                                        {
                                            MessageBox.Show("من فضلك رقم الفاتورة   ");
                                            textBox7.Focus();
                                        }
                                        else
                                            if (textBox7.Text.Any(c => Char.IsLetter(c)))
                                            {
                                                MessageBox.Show("من فضلك ادخل رقم الفاتورة بشكل صحيح");
                                                textBox7.Focus();
                                            }
                                            else
                                                if (String.IsNullOrEmpty(textBox2.Text))
                                                {
                                                    MessageBox.Show("من فضلك قيمه الخصم   ");
                                                    textBox2.Focus();
                                                }
                                                else
                                                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
                                                    {
                                                        MessageBox.Show("من فضلك ادخل قيمه الخصم بشكل صحيح");
                                                        textBox2.Focus();
                                                    }
                                                    else
                                                        if (String.IsNullOrEmpty(textBox4.Text))
                                                        {
                                                            MessageBox.Show("من فضلك الاجمالى بعد الخصم   ");
                                                            textBox4.Focus();
                                                        }
                                                        else
                                                            if (textBox4.Text.Any(c => Char.IsLetter(c)))
                                                            {
                                                                MessageBox.Show("من فضلك ادخل الاجمالى بعد الخصم بشكل صحيح");
                                                                textBox4.Focus();
                                                            }

                                                            else
                                                            {
                                                                try
                                                                {
                                                                    con.OpenConection();
                                                                    string[] pramname = new string[8];
                                                                    string[] pramvalue = new string[8];
                                                                    SqlDbType[] pramtype = new SqlDbType[8];
                                                                    pramname[0] = "@bill_id";
                                                                    pramname[1] = "@ratio_id";
                                                                    pramname[2] = "@discount_type";
                                                                    pramname[3] = "@ratio";
                                                                    pramname[4] = "@value";
                                                                    pramname[5] = "@total_before_discount";
                                                                    pramname[6] = "@total_after_discount";
                                                                    pramname[7] = "@discount_process";

                                                                    pramvalue[0] = textBox7.Text;
                                                                    pramvalue[1] = textBox9.Text;
                                                                    pramvalue[2] = textBox6.Text;
                                                                    pramvalue[3] = textBox5.Text;
                                                                    pramvalue[4] = textBox2.Text;
                                                                    pramvalue[5] = textBox1.Text;
                                                                    pramvalue[6] = textBox4.Text;
                                                                    pramvalue[7] = textBox8.Text;

                                                                    pramtype[0] = SqlDbType.Int;
                                                                    pramtype[1] = SqlDbType.Int;
                                                                    pramtype[2] = SqlDbType.VarChar;
                                                                    pramtype[3] = SqlDbType.Decimal;
                                                                    pramtype[4] = SqlDbType.Decimal;
                                                                    pramtype[5] = SqlDbType.Decimal;
                                                                    pramtype[6] = SqlDbType.Decimal;
                                                                    pramtype[7] = SqlDbType.VarChar;



                                                                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("drug_discount_add", pramname, pramvalue, pramtype);



                                                                    MessageBox.Show("تم الادخال");
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    MessageBox.Show(ex.Message);
                                                                }
                                                                finally { con.CloseConnection(); }
                                                            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("drug_show");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox8.Enabled = true;
            For33 f33 = new For33(this);
            f33.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // if (textBox6.Text != "غرامات")
            //{ textBox8.Enabled = false; }
            //else
            //    textBox8.Enabled = true;

        }
    }
}