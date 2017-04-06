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
    public partial class For2 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
        //SqlDataAdapter da;
        //DataSet ds;
        string c;
        public For2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                                    con.OpenConection();

                                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showratio");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { con.CloseConnection(); }
                                //con.Open();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            MessageBox.Show(c);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                //// cmd = new SqlCommand();
                // SqlCommand cmd = new SqlCommand("deletratio", con);
                // cmd.CommandType = CommandType.StoredProcedure;
                // //cmd.Prepare();
                // cmd.Parameters.AddWithValue("@id", c);
                // cmd.Connection = con;
                // cmd.ExecuteNonQuery();
                //    MessageBox.Show("deleted");
                //}
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //finally { con.Close(); }
        
        }
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    da.Update(ds);
        //}

        private void label5_Click(object sender, EventArgs e)
        {

            //if (String.IsNullOrEmpty(textBox1.Text))
            //{
            //    MessageBox.Show("من فضلك ادخل كود النسبه ");
            //    textBox1.Focus();
            //}
            //else
            //    if (textBox1.Text.Any(c => Char.IsLetter(c)))
            //    {
            //        MessageBox.Show("من فضلك ادخل كود النسبه بشكل صحيح");
            //        textBox1.Focus();
            //    }

            //    else
                    if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("من فضلك ادخل نوع الخصم ");
                        textBox2.Focus();
                    }
                    else
                        if (textBox2.Text.Any(c => Char.IsNumber(c)))
                        {
                            MessageBox.Show("من فضلك ادخل نوع الخصم بشكل صحيح");
                            textBox2.Focus();
                        }

                        else

                            if (String.IsNullOrEmpty(textBox3.Text))
                            {
                                MessageBox.Show("من فضلك  ادخل عملية الخصم ");
                                textBox3.Focus();
                            }


                            else

                                if (String.IsNullOrEmpty(textBox4.Text))
                                {
                                    MessageBox.Show("من فضلك ادخل نسبه الخصم   ");
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
                                         try
                                            {
                                                con.OpenConection();
                                                string[] pramname = new string[3];
                                                string[] pramvalue = new string[3];
                                                SqlDbType[] pramtype = new SqlDbType[3];
                                                pramname[0] = "@discount_kind";
                                                pramname[1] = "@ratio";
                                                pramname[2] = "@discount_process";
                                                
                                                pramvalue[0] = textBox2.Text;
                                                pramvalue[1] = textBox4.Text;
                                                pramvalue[2] = textBox3.Text;
                                               

                                                pramtype[0] = SqlDbType.VarChar;
                                                pramtype[1] = SqlDbType.Decimal;
                                                pramtype[2] = SqlDbType.VarChar;





                                                dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addratio", pramname, pramvalue, pramtype);



                                                MessageBox.Show("تم الادخال");
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            finally { con.CloseConnection(); }
                                            ////con.Open();
                                            ////SqlCommand cmd = new SqlCommand("addratio", con);
                                            ////cmd.CommandType = CommandType.StoredProcedure;

                                            //////cmd.Parameters.AddWithValue("@ratio_id", textBox1.Text);
                                            ////cmd.Parameters.AddWithValue("@discount_kind", textBox2.Text);

                                            ////cmd.Parameters.AddWithValue("@ratio", textBox4.Text);
                                            ////cmd.Parameters.AddWithValue("@discount_ratio", textBox3.Text);

                                            ////cmd.ExecuteNonQuery();
                                          
                                    }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
