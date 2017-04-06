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
    public partial class Form10 : Form
    {
        Connection con = new Connection();
      //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
      //  SqlCommand cmd;
      //  SqlDataReader dr;

        public Form10()
        {
            InitializeComponent();

        }


        private void Form10_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                   
                    textBox2.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
           
                try
                {
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("suppshow");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }

                //con.Open();
                //SqlCommand cmd = new SqlCommand("supshow", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                ////cmd = new SqlCommand("select supplier_id as 'كود المورد ',supplier_name as 'اسم المورد',supplier_activity as'نشاط المورد' ,supplier_address as'عنوان المورد',tax_number as 'الرقم الضريبى',account_number as'رقم الحساب',tax_card as'البطاقه الضريبيه',commmerical_record as'السجل التجارى',contracting_type as'نوع التعاقد',bank_name as'اسم البنك',branch  as'الفرع',responsablities_names as'اسم المسؤل',paymeny_method  as'طريقه الدفع',fax as'الفاكس',email as'الايميل',deal_date as 'تاريخ التعامل' from suppliers;", con);
                //DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;

            
           // finally { dr.Close(); con.Close(); }

        }








        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void label20_Click(object sender, EventArgs e)
        //{

        //    if (String.IsNullOrEmpty(textBox3.Text))
        //    {
        //        MessageBox.Show("من فضلك ادخل اسم المورد   ");
        //        textBox3.Focus();
        //    }
        //    else
        //        if (textBox3.Text.Any(c => Char.IsLetter(c)))
        //        {
        //            MessageBox.Show("من فضلك ادخل اسم المورد بشكل صحيح");
        //            textBox3.Focus();
        //        }

        //        else
        //            if (String.IsNullOrEmpty(textBox8.Text))
        //            {
        //                MessageBox.Show("من فضلك ادخل عنوان المورد ");
        //                textBox8.Focus();
        //            }
        //            else
        //                if (textBox8.Text.Any(c => Char.IsNumber(c)))
        //                {
        //                    MessageBox.Show("من فضلك ادخل عنوان المورد بشكل صحيح");
        //                    textBox8.Focus();
        //                }

        //                else

        //                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
        //                    {
        //                        MessageBox.Show("من فضلك الرقم الضريبى ");
        //                        textBox2.Focus();
        //                    }


        //                    else
        //                        if (String.IsNullOrEmpty(textBox7.Text))
        //                        {
        //                            MessageBox.Show("من فضلك ادخل نشاط المورد    ");
        //                            textBox7.Focus();
        //                        }
        //                        else
        //                            if (textBox7.Text.Any(c => Char.IsLetter(c)))
        //                            {
        //                                MessageBox.Show("من فضلك ادخل نشاط المورد قبل الخصم بشكل صحيح");
        //                                textBox7.Focus();
        //                            }

        //                            else
        //                                if (String.IsNullOrEmpty(textBox4.Text))
        //                                {
        //                                    MessageBox.Show("من فضلك ادخل رقم حساب المورد  ");
        //                                    textBox4.Focus();
        //                                }
        //                                else
        //                                    if (textBox4.Text.Any(c => Char.IsLetter(c)))
        //                                    {
        //                                        MessageBox.Show("من فضلك ادخل رقم الحساب بشكل صحيح");
        //                                        textBox4.Focus();
        //                                    }

        //                                    else
        //                                        if (String.IsNullOrEmpty(textBox7.Text))
        //                                        {
        //                                            MessageBox.Show("من فضلك رقم الفاتورة   ");
        //                                            textBox7.Focus();
        //                                        }
        //                                        else
        //                                            if (textBox7.Text.Any(c => Char.IsLetter(c)))
        //                                            {
        //                                                MessageBox.Show("من فضلك ادخل رقم الفاتورة بشكل صحيح");
        //                                                textBox7.Focus();
        //                                            }
        //                                            else
        //                                                if (String.IsNullOrEmpty(textBox2.Text))
        //                                                {
        //                                                    MessageBox.Show("من فضلك قيمه الخصم   ");
        //                                                    textBox2.Focus();
        //                                                }
        //                                                else
        //                                                    if (textBox2.Text.Any(c => Char.IsLetter(c)))
        //                                                    {
        //                                                        MessageBox.Show("من فضلك ادخل قيمه الخصم بشكل صحيح");
        //                                                        textBox2.Focus();
        //                                                    }
        //                                                    else
        //                                                        if (String.IsNullOrEmpty(textBox4.Text))
        //                                                        {
        //                                                            MessageBox.Show("من فضلك الاجمالى بعد الخصم   ");
        //                                                            textBox4.Focus();
        //                                                        }
        //                                                        else
        //                                                            if (textBox4.Text.Any(c => Char.IsLetter(c)))
        //                                                            {
        //                                                                MessageBox.Show("من فضلك ادخل الاجمالى بعد الخصم بشكل صحيح");
        //                                                                textBox4.Focus();
        //                                                            }

                                                                   
        //                                                            //{
        //                                                            //    try
        //                                                            //    {
        //                                                                    //con.Open();
        //                                                                    //SqlCommand cmd = new SqlCommand("sup", con);
        //                                                                    //cmd.CommandType = CommandType.StoredProcedure;

        //                                                                    //cmd.Parameters.AddWithValue("@name", textBox3.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@act", textBox7.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@adds", textBox8.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@tax", textBox2.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@account", textBox4.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@taxcard", textBox18.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@recordext", textBox17.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@type", comboBox1.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@bank", textBox11.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@branch", textBox9.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@rname", textBox16.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@pay", comboBox2.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@fax", textBox6.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@email", textBox5.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
        //                                                                    //cmd.Parameters.AddWithValue("@phone", textBox12.Text);
        //                                                                    ////     cmd = new SqlCommand(" insert into suppliers(supplier_name,supplier_activity,supplier_address,tax_number,account_number,tax_card,commmerical_record,contracting_type,bank_name,branch,responsablities_names,paymeny_method,fax,email,deal_date,supplier_phone)" +
        //                                                                    //"values( @name ,@act ,@adds ,@tax ,@account,@taxcard,@recordext,@type,@bank,@branch,@rname,@pay,@fax,@email,@date,@phone) ", con);
        //                                                                    //     cmd.Prepare();

        //                                                                    //     cmd.Parameters.AddWithValue("@name", textBox3.Text);
        //                                                                    //     cmd.Parameters.AddWithValue("@act", textBox7.Text);
        //                                                                    //     cmd.Parameters.AddWithValue("@adds", textBox8.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@tax", textBox2.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@account", textBox4.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@taxcard", textBox18.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@recordext", textBox17.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@type", comboBox1.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@bank", textBox11.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@branch", textBox9.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@rname", textBox16.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@pay", comboBox2.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@fax", textBox6.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@email", textBox5.Text);
        //                                                                    //cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
        //                                                                    //cmd.Parameters.AddWithValue("@phone", textBox12.Text);
        //                                                                    // cmd.Parameters.AddWithValue("@id", textBox1.Text);

        //                                                                    //    cmd.ExecuteNonQuery();
        //                                                                        MessageBox.Show("inserted");
        //                                                                    //}
        //                                                                    //catch (Exception ex)
        //                                                                    //{
        //                                                                    //    MessageBox.Show(ex.Message);
        //                                                                    //}
        //                                                                    //finally { con.Close(); }
        //                                                                }
                                                                    

        


        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
            // else if (textBox2.Text=="")
            //{ MessageBox.Show("من فضلك ادخل الرقم الضريبي"); }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[16];
                string[] pramvalue = new string[16];
                SqlDbType[] pramtype = new SqlDbType[16];

                pramname[0] = "@name";
                pramname[1] = "@act";
                pramname[2] = "@adds";
                pramname[3] = "@tax";
                pramname[4] = "@account";
                pramname[5] = "@taxcard";
                pramname[6] = "@recordext";
                pramname[7] = "@type";
                pramname[8] = "@bank";
                pramname[9] = "@branch";
                pramname[10] = "@rname";
                pramname[11] = "@pay";
                pramname[12] = "@fax";
                pramname[13] = "@email";
                pramname[14] = "@date";
                pramname[15] = "@phone";



                pramvalue[0] = textBox3.Text;
                pramvalue[1] = textBox7.Text;
                pramvalue[2] = textBox8.Text;
                pramvalue[3] = textBox2.Text;
                pramvalue[4] = textBox4.Text;
                pramvalue[5] = textBox18.Text;
                pramvalue[6] = textBox17.Text;
                pramvalue[7] = comboBox1.Text;
                pramvalue[8] = textBox11.Text;
                pramvalue[9] = textBox9.Text;
                pramvalue[10] = textBox16.Text;
                pramvalue[11] = comboBox2.Text;
                pramvalue[12] = textBox6.Text;
                pramvalue[13] = textBox5.Text;
                pramvalue[14] = dateTimePicker1.Value.ToString();
                pramvalue[15] = textBox12.Text;



                
                
                
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.Int;
                pramtype[4] = SqlDbType.Int;
                pramtype[5] = SqlDbType.VarChar;
                pramtype[6] = SqlDbType.VarChar;
                pramtype[7] = SqlDbType.VarChar;
                pramtype[8] = SqlDbType.VarChar;
                pramtype[9] = SqlDbType.VarChar;
                pramtype[10] = SqlDbType.VarChar;
                pramtype[11] = SqlDbType.VarChar;
                pramtype[12] = SqlDbType.VarChar;
                pramtype[13] = SqlDbType.VarChar;
                pramtype[14] = SqlDbType.VarChar;
                pramtype[15] = SqlDbType.Int;




                if (textBox2.Text == "")
                { MessageBox.Show("من فضلك ادخل الرقم الضريبي"); }
                else if (textBox12.Text == "")
                { MessageBox.Show("من فضلك ادخل رقم التليفون"); }
                else if (textBox4.Text == "")
                { MessageBox.Show("من فضلك ادخل رقم الحساب"); }

                else
                {
                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("suppp", pramname, pramvalue, pramtype);

                    MessageBox.Show("inserted");
                    con.CloseConnection();
                }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }
        }

        

}}   
    





