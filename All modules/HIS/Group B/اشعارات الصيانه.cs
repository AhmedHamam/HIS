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
    public partial class For26 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
        public For26()
        {
            InitializeComponent();
        }

        public void setV(string d, string c, string b, string t)
        {
            textBox8.Text = d;
            textBox7.Text = c;
            textBox2.Text = b;
            textBox9.Text = t;

        }
        public void setVal(string d, string c)
        {
            textBox4.Text = d;
            textBox5.Text = c;

        }
        private void Form26_Load(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
            textBox2.Enabled = false;
            textBox8.Enabled = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

            /*if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل كود الخصم   ");
                textBox1.Focus();
            }
            else
                if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل كود الخصم بشكل صحيح");
                    textBox1.Focus();
                }

                else*/
            if (String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("من فضلك ادخل نوع الخصم ");
                textBox8.Focus();
            }
            else
                if (textBox8.Text.Any(c => Char.IsNumber(c)))
                {
                    MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                    textBox8.Focus();
                }

                else

                    if (String.IsNullOrEmpty(textBox7.Text))
                    {
                        MessageBox.Show("من فضلك عملية الخصم ");
                        textBox7.Focus();
                    }


                    else
                        if (String.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("من فضلك الاجمالى قبل الخصم   ");
                            textBox5.Focus();
                        }
                        else
                            if (textBox5.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  بشكل صحيح");
                                textBox5.Focus();
                            }

                            else
                                if (String.IsNullOrEmpty(textBox2.Text))
                                {
                                    MessageBox.Show("من فضلك  ادخل نسبه الخصم   ");
                                    textBox2.Focus();
                                }
                                else
                                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
                                    {
                                        MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                        textBox2.Focus();
                                    }

                                    else
                                        if (String.IsNullOrEmpty(textBox4.Text))
                                        {
                                            MessageBox.Show("من فضلك رقم الفاتورة   ");
                                            textBox4.Focus();
                                        }
                                        else
                                            if (textBox4.Text.Any(c => Char.IsLetter(c)))
                                            {
                                                MessageBox.Show("من فضلك ادخل رقم الفاتورة بشكل صحيح");
                                                textBox4.Focus();
                                            }
                                            else
                                                if (String.IsNullOrEmpty(textBox3.Text))
                                                {
                                                    MessageBox.Show("من فضلك قيمه الخصم   ");
                                                    textBox3.Focus();
                                                }
                                                else
                                                    if (textBox3.Text.Any(c => Char.IsLetter(c)))
                                                    {
                                                        MessageBox.Show("من فضلك ادخل قيمه الخصم بشكل صحيح");
                                                        textBox3.Focus();
                                                    }
                                                    else
                                                        if (String.IsNullOrEmpty(textBox6.Text))
                                                        {
                                                            MessageBox.Show("من فضلك الاجمالى بعد الخصم   ");
                                                            textBox6.Focus();
                                                        }
                                                        else
                                                            if (textBox6.Text.Any(c => Char.IsLetter(c)))
                                                            {
                                                                MessageBox.Show("من فضلك ادخل الاجمالى بعد الخصم بشكل صحيح");
                                                                textBox6.Focus();
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

                                                                        pramvalue[0] = textBox4.Text;
                                                                        pramvalue[1] = textBox9.Text;
                                                                        pramvalue[2] = textBox8.Text;
                                                                        pramvalue[3] = textBox2.Text;
                                                                        pramvalue[4] = textBox3.Text;
                                                                        pramvalue[5] = textBox5.Text;
                                                                        pramvalue[6] = textBox6.Text;
                                                                        pramvalue[7] = textBox7.Text;

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
                                                                    //    con.Open();
                                                                    //    cmd = new SqlCommand("drug_discount_add", con);
                                                                    //    cmd.CommandType = CommandType.StoredProcedure;
                                                                    //   // cmd.Parameters.AddWithValue("@id", textBox1.Text);
                                                                    //    cmd.Parameters.AddWithValue("@bill_id", textBox4.Text);
                                                                    //    cmd.Parameters.AddWithValue("@discount_type", textBox8.Text);
                                                                    //    cmd.Parameters.AddWithValue("@ratio_id", textBox9.Text);
                                                                    //    cmd.Parameters.AddWithValue("@ratio", textBox2.Text);
                                                                    //    cmd.Parameters.AddWithValue("@value", textBox3.Text);
                                                                    //    cmd.Parameters.AddWithValue("@total_before_discount", textBox5.Text);
                                                                    //    cmd.Parameters.AddWithValue("@total_after_discount", textBox6.Text);
                                                                    //    cmd.Parameters.AddWithValue("@discount_process", textBox7.Text);

                                                                    //    cmd.ExecuteNonQuery();
                                                                    //    MessageBox.Show("inserted");

                                                                    //}
                                                                    //catch (Exception ex) { MessageBox.Show(ex.Message); }
                                                                    //finally { con.Close(); }
                                                                }
                                                            }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("من فضلك ادخل نوع الخصم ");
                textBox8.Focus();
            }
            else
                if (textBox8.Text.Any(c => Char.IsNumber(c)))
                {
                    MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                    textBox8.Focus();
                }

                else

                    if (String.IsNullOrEmpty(textBox7.Text))
                    {
                        MessageBox.Show("من فضلك عملية الخصم ");
                        textBox8.Focus();
                    }


                    else
                        if (String.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  ");
                            textBox5.Focus();
                        }
                        else
                            if (textBox5.Text.Any(c => Char.IsLetter(c)))
                            {
                                MessageBox.Show("من فضلك ادخل الاجمالى قبل الخصم  بشكل صحيح");
                                textBox5.Focus();
                            }

                            else
                                if (String.IsNullOrEmpty(textBox2.Text))
                                {
                                    MessageBox.Show("من فضلك نسبه الخصم   ");
                                    textBox2.Focus();
                                }
                                else
                                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
                                    {
                                        MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                        textBox2.Focus();
                                    }
                                    else
                                    {
                                        double a = Double.Parse(textBox2.Text) / 100.0;
                                        double c = Double.Parse(textBox4.Text);
                                        double s = (a) * c;
                                        textBox3.Text = s.ToString();
                                        double b = c - s;
                                        textBox6.Text = b.ToString();
                                    }
        }
        private void button1_Click(object sender, EventArgs e)
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
            //dt = new DataTable();
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("drug_show", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally { con.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox2.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox2.Enabled = true;
            textBox8.Enabled = true;
            For36 f36 = new For36(this);
            f36.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            For31 f31 = new For31(this);
            f31.Show();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
