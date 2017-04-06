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
    public partial class For12 : Form
    {
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
        Connection con = new Connection();
        public For12()
        {
            InitializeComponent();
        }
        public void setV(string c)
        {
            textBox3.Text = c;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            For13 f13 = new For13(this);
            f13.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("tt1");
              
                //SqlCommand cmd = new SqlCommand("tt1", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                ////cmd = new SqlCommand();
                ////cmd.Connection = con;
                ////cmd.CommandText = "select discount_id as 'رقم الخصم' ,discount_type as 'نوع الخصم' ,ratio 'نسبه الخصم', value as 'قيمه الخصم', total_before_discount as 'الاجمالي قبل الخصم',total_after_discount as 'الاجمالي بعد الخصم',bill.supplier_id as 'رقم المورد' , suppliers.supplier_name as  'اسم المورد'  from bill ,discount, suppliers where suppliers.supplier_id= bill.supplier_id and bill.bill_id=discount.bill_id  ";
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل كود المورد ");
                textBox3.Focus();
            }
            else
                if (textBox3.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل كود المورد بشكل صحيح");
                    textBox3.Focus();
                }

                else
                {
                    try
                    {




                        //cmd = new SqlCommand();
                        //cmd.Connection = con;
                        /*  cmd.CommandText = "select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد', commandsupply_id as'كود امر التوريد' ," +
                     "product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
                         "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
                     "product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from  price_offer where price_offer_id=@id ";*/

                        // cmd.CommandText = "select discount_id as 'رقم الخصم' ,discount_type as 'نوع الخصم' ,ratio 'نسبه الخصم', value as 'قيمه الخصم', total_before_discount as 'الاجمالي قبل الخصم',total_after_discount as 'الاجمالي بعد الخصم',supplier_id as 'رقم المورد'  from bill ,discount where   bill.bill_id=discount.bill_id and supplier_id=@id ";
                        //con.Open();
                        //SqlCommand cmd = new SqlCommand("searchbyidd", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Prepare();
                        //cmd.Parameters.AddWithValue("@id", textBox3.Text);
                        //dr = cmd.ExecuteReader();
                        //dt = new DataTable();
                        //dt.Load(dr);

                        //dataGridView1.DataSource = dt;
                        con.OpenConection();
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@id";
                        pramvalue[0] = textBox3.Text;
                        pramtype[0] = SqlDbType.VarChar;

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("searchbyidd", pramname, pramvalue, pramtype);

                       

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally { con.CloseConnection(); }
                }
        }


        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {

                    textBox3.Text = "";
                    // textBox8.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

