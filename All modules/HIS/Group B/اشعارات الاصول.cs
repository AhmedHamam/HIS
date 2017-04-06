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
    public partial class For21 : Form
    {
        Connection con = new Connection();
      
        public For21()
        {
            InitializeComponent();
        }
        public void setV(string c,string d)
        {
            textBox7.Text = c;
             textBox1.Text = d;
        }
        public void setVal(string c, string d, string b, string a)
        {
            textBox8.Text = c;
             textBox6.Text = d;
             textBox4.Text = b;
             textBox9.Text = a;

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

                            if (String.IsNullOrEmpty(textBox6.Text))
                            {
                                MessageBox.Show("من فضلك عملية الخصم ");
                                textBox6.Focus();
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
                                        if (String.IsNullOrEmpty(textBox4.Text))
                                        {
                                            MessageBox.Show("من فضلك نسبه الخصم   ");
                                            textBox4.Focus();
                                        }
                                        else
                                            if (textBox4.Text.Any(c => Char.IsLetter(c)))
                                            {
                                                MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                                textBox4.Focus();
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
                                                        if (String.IsNullOrEmpty(textBox5.Text))
                                                        {
                                                            MessageBox.Show("من فضلك قيمه الخصم   ");
                                                            textBox5.Focus();
                                                        }
                                                        else
                                                            if (textBox5.Text.Any(c => Char.IsLetter(c)))
                                                            {
                                                                MessageBox.Show("من فضلك ادخل قيمه الخصم بشكل صحيح");
                                                                textBox5.Focus();
                                                            }
                                                            else
                                                                if (String.IsNullOrEmpty(textBox2.Text))
                                                                {
                                                                    MessageBox.Show("من فضلك الاجمالى بعد الخصم   ");
                                                                    textBox2.Focus();
                                                                }
                                                                else
                                                                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
                                                                    {
                                                                        MessageBox.Show("من فضلك ادخل الاجمالى بعد الخصم بشكل صحيح");
                                                                        textBox2.Focus();
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
                                                                            pramvalue[2] = textBox8.Text;
                                                                            pramvalue[3] = textBox4.Text;
                                                                            pramvalue[4] = textBox5.Text;
                                                                            pramvalue[5] = textBox1.Text;
                                                                            pramvalue[6] = textBox2.Text;
                                                                            pramvalue[7] = textBox6.Text;

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
        private void Form21_Load(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        { try
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
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("fixed_show",con);
        //        cmd.Connection = con;
        //       // cmd.CommandText = "select discount_id as 'رقم الخصم' ,discount_type as 'نوع الخصم' ,discount_process as'عمليه الخصم',ratio as 'نسبه الخصم', value as 'قيمه الخصم', total_before_discount as 'الاجمالي قبل الخصم',total_after_discount as 'الاجمالي بعد الخصم'  from bill ,discount where   bill.bill_id=discount.bill_id  ";
        //        dr = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);
        //        dataGridView1.DataSource = dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally { con.Close(); }
        //}

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
                    textBox8.Text = "";
                    textBox6.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            For22 f22 = new For22(this);
            f22.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Form23 f23 = new Form23(this);
            f23.Show();*/
        }

        private void button2_Click(object sender, EventArgs e)
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

                    if (String.IsNullOrEmpty(textBox6.Text))
                    {
                        MessageBox.Show("من فضلك عملية الخصم ");
                        textBox6.Focus();
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
                                    MessageBox.Show("من فضلك ادخل الاجمالى  قبل الخصم بشكل صحيح");
                                    textBox1.Focus();
                                }

                                else
                                    if (String.IsNullOrEmpty(textBox4.Text))
                                    {
                                        MessageBox.Show("من فضلك نسبه الخصم   ");
                                        textBox4.Focus();
                                    }
                                    else
                                        if (textBox4.Text.Any(c => Char.IsLetter(c)))
                                        {
                                            MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                            textBox4.Focus();
                                        }
                                        else
                                        {

                                            double a = Double.Parse(textBox4 .Text) / 100.0;
                                            double c = Double.Parse(textBox1.Text);
                                            double s = (a) * c;
                                            textBox5.Text = s.ToString();
                                            double b = c - s;
                                            textBox2.Text = b.ToString();
                                        }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            textBox6.Enabled = true;
            textBox8.Enabled = true;
            For7 f7 = new For7(this);
            f7.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
