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
    public partial class تعديلعروضاسعار : Form
    {
        Connection con = new Connection();
        //SqlCommand cmd;
        //SqlDataAdapter dsa;
        //DataTable dt;
        //SqlDataReader dr;
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataAdapter da;
        //DataSet ds;

        DataSet dts;
        public تعديلعروضاسعار(string c)
        {
            InitializeComponent();
            textBox1.Text = c;
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            //con.Open();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //da = new SqlDataAdapter("select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد',commandsupply_id as'كود امر التوريد' ," +
            // "product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
            //     "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
            // "product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from price_offer where price_offer_id ="+textBox1.Text+";",con);

            try
            {
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@id";
                pramvalue[0] = textBox1.Text;
                pramtype[0] = SqlDbType.VarChar;
                if (textBox1.Text == "")
                    MessageBox.Show("من فضلك ادخل رقم عروض الاسعار");

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("findbriceofferbyid", pramname, pramvalue, pramtype);

                
                //con.Open();
                //SqlCommand cmd = new SqlCommand("findbriceofferbyid", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                //dsa = new SqlDataAdapter(cmd);

                //dts = new DataSet();
                //SqlCommandBuilder cb = new SqlCommandBuilder(dsa);
                //dsa.Fill(dts);
                //dataGridView1.DataSource = dts.Tables[0];
                //DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            finally { con.CloseConnection(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dsa.Update(dts);
        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {
           // con.Open();
            
            //da = new SqlDataAdapter("select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد',commandsupply_id as'كود امر التوريد' ," +
            //"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
            //    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
            //"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from price_offer ", @"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");


            try

            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("findpriceoffer");
                
            //    SqlCommand cmd = new SqlCommand("findpriceoffer", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //dsa= new SqlDataAdapter(cmd);
                
            //    dts = new DataSet();
            //    SqlCommandBuilder cb = new SqlCommandBuilder(dsa);
            //    dsa.Fill(dts);
            //    dataGridView1.DataSource = dts.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
                
                
                //con.Close();
            }
          
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

     
    }
}
