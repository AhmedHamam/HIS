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
    public partial class اضافةعروضاسعار : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        public اضافةعروضاسعار()
        {
            InitializeComponent();
           
        }
        public void setValue(string d)
        {
            textBox2.Text = d;
            
        }
        public void setV(string d)
        {
            textBox4.Text = d;

        }

        private void Form13_Load(object sender, EventArgs e)
        {
           
           
                 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.Controls.Count; i++)
            {
              
                textBox2.Text = "";

                textBox16.Text = "";

                textBox3.Text = "";
                textBox4.Text = "";

                textBox9.Text = "";
                textBox7.Text = "";

                dataGridView1.DataSource = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("findpriceoffer");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
                //con.Close(); }
        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            بياناتالموردين2 f9 = new بياناتالموردين2(this);
            f9.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            امرالتوريد f24 = new امرالتوريد(this);
            f24.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[11];
                string[] pramvalue = new string[11];
                SqlDbType[] pramtype = new SqlDbType[11];
                pramname[0] = "@pcode";
                pramname[1] = "@prodname";
                pramname[2] = "@uprice";
                pramname[3] = "@prodquantaty";
                pramname[4] = "@prodquality";
                pramname[5] = "@guarantee";
                pramname[6] = "@recepttime";
                pramname[7] = "@leadtime";
                pramname[8] = "@perperiod";
                pramname[9] = "@supplier_id";
                pramname[10] = "@command_id";

                pramvalue[0] = textBox9.Text;
                pramvalue[1] = textBox16.Text;
                pramvalue[2] = textBox10.Text;
                pramvalue[3] = textBox3.Text;
                pramvalue[4] = textBox7.Text;
                pramvalue[5] = textBox15.Text;
                pramvalue[6] = dateTimePicker3.Value.ToString();
                pramvalue[7] = dateTimePicker2.Value.ToString();
                pramvalue[8] = dateTimePicker1.Value.ToString();
                pramvalue[9] = textBox2.Text;
                pramvalue[10] = textBox4.Text;

                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.Decimal;
                pramtype[3] = SqlDbType.Int;
                pramtype[4] = SqlDbType.VarChar;
                pramtype[5] = SqlDbType.VarChar;
                pramtype[6] = SqlDbType.VarChar;
                pramtype[7] = SqlDbType.VarChar;
                pramtype[8] = SqlDbType.VarChar;
                pramtype[9] = SqlDbType.VarChar;
                pramtype[10] = SqlDbType.Int;
                pramtype[0] = SqlDbType.Int;
                if (textBox2.Text == "")
                { MessageBox.Show("من فضلك اختر رقم المورد"); }
                else if (textBox4.Text == "")
                { MessageBox.Show("من فضلك اختر رقم امر التوريد"); }
                else if (textBox9.Text == "")
                { MessageBox.Show("من فضلك ادخل الباركود "); }
                else if (textBox3.Text == "")
                { MessageBox.Show("من فضلك ادخل سعر الكميه "); }
                else if (textBox10.Text == "")
                { MessageBox.Show("من فضلك ادخل سعر الوحده "); }


                else
                {
                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addpriceoffer", pramname, pramvalue, pramtype);

                   
                    
                }
                MessageBox.Show("inserted");
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { con.CloseConnection(); }
            //int a;
            //if (textBox1.Text == "")
            //{
              // MessageBox.Show("Please Enter values");
            //}
            
            //else
            //    if (int.TryParse(textBox1.Text, out a) )
            //    {
            /*
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("addpriceoffer", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        // con = new SqlConnection("server=localhost;userid=root;password=root;database=PHIS;");
                        //cmd = new SqlCommand(" insert into price_offer(parcode ,product_name,unit_price,product_quantaty,product_quality,guarantee,reciept_date,lead_time," +
                        //    "permitting_period,supplier_id,commandsupply_id)" +
                        //"values(@pcode,@prodname,@uprice,@prodquantaty,@prodquality,@guarantee,@recepttime,@leadtime,@perperiod,@supplier_id,@command_id )", con);
                        //cmd.Prepare();
                        //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pcode", textBox9.Text);
                        cmd.Parameters.AddWithValue("@prodname", textBox16.Text);
                        cmd.Parameters.AddWithValue("@uprice",textBox10.Text);
                        cmd.Parameters.AddWithValue("@prodquantaty", textBox3.Text);
                        cmd.Parameters.AddWithValue("@prodquality", textBox7.Text);
                        cmd.Parameters.AddWithValue("@guarantee", textBox15.Text);
                        cmd.Parameters.AddWithValue("@recepttime", dateTimePicker3.Value.ToString());
                        cmd.Parameters.AddWithValue("@leadtime", dateTimePicker2.Value.ToString());
                        cmd.Parameters.AddWithValue("@perperiod", dateTimePicker1.Value.ToString());
                        cmd.Parameters.AddWithValue("@supplier_id", textBox2.Text);
                        cmd.Parameters.AddWithValue("@command_id", textBox4.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally { con.Close(); }*/
                }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }
                //else
                //    MessageBox.Show("Invalid data");
        }

       
    }

