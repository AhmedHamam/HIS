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
        
    public partial class مسحبياناتمورد : Form
    {
        Connection con = new Connection();
        string c;
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataReader dr;
        //SqlCommand cmd;
        //DataTable dt;
        public مسحبياناتمورد()
        {
            InitializeComponent();
          
           
        }

        private void Form12_Load(object sender, EventArgs e)
        {

          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {


            con.OpenConection();
            string[] pramname = new string[1];
            string[] pramvalue = new string[1];
            SqlDbType[] pramtype = new SqlDbType[1];
            pramname[0] = "@id";
            pramvalue[0] = textBox1.Text;
            pramtype[0] = SqlDbType.VarChar;
            if (textBox1.Text == "")
                MessageBox.Show("من فضلك ادخل رقم المورد");
            else
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("supf", pramname, pramvalue, pramtype);

            con.CloseConnection();
                
            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("supf", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@id", textBox1.Text);
            //    //cmd = new SqlCommand("select supplier_id as 'كود المورد ',supplier_name as 'اسم المورد',supplier_activity as'نشاط المورد' ,supplier_address as'عنوان المورد',tax_number as 'الرقم الضريبى',account_number as'رقم الحساب',tax_card as'البطاقه الضريبيه',commmerical_record as'السجل التجارى',contracting_type as'نوع التعاقد',bank_name as'اسم البنك',branch  as'الفرع',responsablities_names as'اسم المسؤل',paymeny_method  as'طريقه الدفع',fax as'الفاكس',email as'الايميل',deal_date as 'تاريخ التعامل' from suppliers;", con);
            //    DataTable dt = new DataTable();
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;

                
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            //finally {  con.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            //co
            //SqlDataReader dr = con.DataReader("supshow");
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("suppshow");

            //MessageBox.Show("تم ادخال البيانات بنجاح");
            con.CloseConnection();
            //try
            //{

            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("supshow", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    //cmd = new SqlCommand("select supplier_id as 'كود المورد ',supplier_name as 'اسم المورد',supplier_activity as'نشاط المورد' ,supplier_address as'عنوان المورد',tax_number as 'الرقم الضريبى',account_number as'رقم الحساب',tax_card as'البطاقه الضريبيه',commmerical_record as'السجل التجارى',contracting_type as'نوع التعاقد',bank_name as'اسم البنك',branch  as'الفرع',responsablities_names as'اسم المسؤل',paymeny_method  as'طريقه الدفع',fax as'الفاكس',email as'الايميل',deal_date as 'تاريخ التعامل' from suppliers;", con);
            //    DataTable dt = new DataTable();
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;

            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally { con.Close(); }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            MessageBox.Show(c);
            textBox1.Text = c;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
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
                            MessageBox.Show("من فضلك ادخل رقم المورد");
                        else
                        {

                            dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("dele", pramname, pramvalue, pramtype);
                            MessageBox.Show("deleted");
                        }
                        //con.Open();
                        //SqlCommand cmd = new SqlCommand("delesup", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        ////cmd.Prepare();
                        //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        //cmd.Connection = con;
                        //cmd.ExecuteNonQuery();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { con.CloseConnection(); }
                }
               
       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك قم بادخال رقم");
            }
        }
        }

       
    }