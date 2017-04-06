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
    public partial class For18 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;

        public For18()
        {
            InitializeComponent();
        }
        public void setV(string c, string d)
        {
            textBox7.Text = c;
            textBox1.Text = d;
        }

        public void setVal(string c, string b, string d, string t)
         {
             textBox4.Text = c;
             textBox8.Text = b;
             textBox6.Text = d;
             textBox9.Text = t;

         }

        private void Form18_Load(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            For19 f19 = new For19(this);
            f19.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            /*Form20 f20 = new Form20(this);
            f20.Show();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /*  if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("من فضلك ادخل نوع الخصم ");
                textBox4.Focus();
            }
            else
                if (textBox4.Text.Any(c => Char.IsNumber(c)))
                {
                    MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                    textBox4.Focus();
                }

                else*/

                    if (String.IsNullOrEmpty(textBox8.Text))
                    {
                        MessageBox.Show("من فضلك  ادخل عملية الخصم ");
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
                                    MessageBox.Show("من فضلك ادخل الاجمالى  قبل الخصم بشكل صحيح");
                                    textBox1.Focus();
                                }

                                else
                                    if (String.IsNullOrEmpty(textBox6.Text))
                                    {
                                        MessageBox.Show("من فضلك ادخل  نسبه الخصم   ");
                                        textBox6.Focus();
                                    }
                                    else
                                        if (textBox6.Text.Any(c => Char.IsLetter(c)))
                                        {
                                            MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                            textBox6.Focus();
                                        }

             if (textBox4.Text == "نسبه واضافه" && textBox8.Text == "من 50 الي 250" || textBox4.Text == "نسبه واضافه" && textBox8.Text == "من 250الي 500" || textBox4.Text == "نسبه واضافه" && textBox8.Text == "من 500الي 1000" || textBox4.Text == "نسبه واضافه" && textBox8.Text == "من 1000الي 5000" || textBox4.Text == "نسبه واضافه" && textBox8.Text == "من 5000الي 10000")
             {
                 double b = Double.Parse(textBox6.Text) / 100.0;
                 double d = Double.Parse(textBox1.Text);
                 double f = (b) * d;
                 f = (f + 160) * 3;
                 textBox5.Text = f.ToString();
                 double q = Double.Parse(textBox5.Text) - Double.Parse(textBox1.Text);
                 textBox2.Text = q.ToString();
             }

             else
             {
                 double a = Double.Parse(textBox6.Text) / 100.0;

                 double c = Double.Parse(textBox1.Text);
                 double s = (a) * c;
                 textBox5.Text = s.ToString();
                 double t = Double.Parse(textBox1.Text) - Double.Parse(textBox5.Text);
                 textBox2.Text = t.ToString();
             }
               
           
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
                    if (String.IsNullOrEmpty(textBox4.Text))
                    {
                        MessageBox.Show("من فضلك ادخل نوع الخصم ");
                        textBox4.Focus();
                    }
                    else
                        if (textBox4.Text.Any(c => Char.IsNumber(c)))
                        {
                            MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                            textBox4.Focus();
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
                                            if (String.IsNullOrEmpty(textBox6.Text))
                                            {
                                                MessageBox.Show("من فضلك نسبه الخصم   ");
                                                textBox6.Focus();
                                            }
                                            else
                                                if (textBox6.Text.Any(c => Char.IsLetter(c)))
                                                {
                                                    MessageBox.Show("من فضلك ادخل نسبه الخصم  بشكل صحيح");
                                                    textBox6.Focus();
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
                                                                                pramvalue[2] = textBox4.Text;
                                                                                pramvalue[3] = textBox6.Text;
                                                                                pramvalue[4] = textBox5.Text;
                                                                                pramvalue[5] = textBox1.Text;
                                                                                pramvalue[6] = textBox2.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox4.Text = "";
                    textBox8.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*con.Open();
            cmd = new SqlCommand("select ratio from ratio where ratio_id=@ratio and discount_kind=@kind ; ", con);
            cmd.Parameters.AddWithValue("@ratio", textBox4.Text);
            cmd.Parameters.AddWithValue("@kind", comboBox1.Text);
            cmd.Parameters.AddWithValue("@koperation", comboBox2.Text);
            double Count = Double.Parse(cmd.ExecuteScalar().ToString());
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add(Count);*/
                }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            textBox6.Enabled = true;
            textBox8.Enabled = true;
            For16 f16 = new For16(this);
            f16.Show();
        }
            }
        }
