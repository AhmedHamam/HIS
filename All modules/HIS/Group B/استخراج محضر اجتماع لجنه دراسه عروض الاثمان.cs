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
    public partial class عروضالاثمان : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        
        //SqlDataReader dr;
        //DataTable dt;
       // Form17 f13;
        public عروضالاثمان()
        {
            InitializeComponent();
        }
        public void setV(string d)
        {
            textBox2.Text = d;

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t31");

           // try
           // {
           //     con.Open();
           //     SqlCommand cmd = new SqlCommand("t31", con);
           //     cmd.CommandType = CommandType.StoredProcedure;
           ////     cmd = new SqlCommand();
           //     cmd.Connection = con;
           //     cmd.CommandText = "select price_offer_id  as 'كود عرض السعر '  ,employee_id as 'رقم الموظف', emp_name as 'اسم الموظف',supplier_id as ' كود المورد', commandsupply_id as'كود امر التوريد' ," +
           //"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
           //    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
           //"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' ,employee_id as 'رقم الموظف'  from  price_offer, employee, Employee_price "+
           //"where employee_id = e_id  and  priceoffer_id= price_offer_id";
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@id";
                pramvalue[0] = textBox2.Text;
                pramtype[0] = SqlDbType.VarChar;
                if (textBox2.Text == "") 
                MessageBox.Show("من فضلك اختر عرض السعر");
                else
                

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t21", pramname, pramvalue, pramtype);
                
            
          
            }

            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            عروضالاسعار f39 = new عروضالاسعار(this);
            f39.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف قم باختيار عرض السعر");
            }
        }
    }
}
