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
    public partial class طلبشراء : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
       // Form17 f13;
        public طلبشراء()
        {
            InitializeComponent();
        }
        public void setV(string d)
        {
            textBox2.Text = d;

        }


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@id";
                pramvalue[0] = textBox2.Text;
                pramtype[0] = SqlDbType.VarChar;
                if (textBox2.Text == "")
                    MessageBox.Show("من فضلك اختر رقم التوريد");
                else
                {
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t21", pramname, pramvalue, pramtype);

                    con.CloseConnection();
                }
            }
            catch( Exception ex)
            {
            MessageBox.Show(ex.Message);
            
            }
            finally

            {con.CloseConnection();}
                //     con.Open();
                //     //cmd = new SqlCommand();
                //     //cmd.Connection = con;
                ////     cmd.CommandText = "select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد', commandsupply_id as'كود امر التوريد' ," +
                ////"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
                ////    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
                ////"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from  price_offer where commandsupply_id=@id ";


                //     SqlCommand cmd = new SqlCommand("t21", con);
                //     cmd.CommandType = CommandType.StoredProcedure;
                //         cmd.Prepare();
                //         cmd.Parameters.AddWithValue("@id", textBox2.Text);
                //         dr = cmd.ExecuteReader();
                //         dt = new DataTable();
                //         dt.Load(dr);

                //         dataGridView1.DataSource = dt;


                // }
                // catch (Exception ex)
                // {

                //     MessageBox.Show(ex.Message);
                // }
                // finally { con.Close(); }
            }
     
        private void button3_Click(object sender, EventArgs e)
        {
             try
             {
                 con.OpenConection();
                 dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t12");
                 
           // {
           //     con.Open();
           ////     cmd = new SqlCommand();
           ////     cmd.Connection = con;
           ////     cmd.CommandText = "select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد', commandsupply_id as'كود امر التوريد' ," +
           ////"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
           ////    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
           ////"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from  price_offer ; ";
           //     SqlCommand cmd = new SqlCommand("t12", con);
           //     cmd.CommandType = CommandType.StoredProcedure;
           //     dr = cmd.ExecuteReader();
           //     DataTable dt = new DataTable();
           //     dt.Load(dr);
           //     dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            امرالتوريد1 f38 = new امرالتوريد1(this);
            f38.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox2.Text = "";
                    
                    dateTimePicker1.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف قم باختيار كود امر التوريد");
            }
        }
        }
    }

