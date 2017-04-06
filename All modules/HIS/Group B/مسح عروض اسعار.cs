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
    public partial class مسحعروضاسعار : Form
    {
        Connection con = new Connection();
        string c;
        //SqlDataReader dr;

        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
      
        //DataTable dt;
        //SqlCommand cmd;
        public مسحعروضاسعار()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
           // con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

           
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("findpriceoffer");
                //con.Open();
                //SqlCommand cmd = new SqlCommand("findpriceoffer", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                
            //    cmd = new SqlCommand("select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد',commandsupply_id as'كود امر التوريد' ," +
            //"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
            //    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
            //"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from price_offer ", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    dt = new DataTable();
            //    dt.Load(dr);

            //    dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
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
                    MessageBox.Show("من فضلك ادخل رقم عرض السعر");
                else

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("findbriceofferbyid", pramname, pramvalue, pramtype);
                //con.Open();
                //SqlCommand cmd = new SqlCommand("findbriceofferbyid", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                //DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
             //   con.Open();
             //   cmd = new SqlCommand("select price_offer_id  as 'كود عرض السعر ',supplier_id as ' كود المورد',commandsupply_id as'كود امر التوريد' ," +
             //"product_name as 'اسم المنتج',unit_price as'سعر الوحده',product_quantaty as'سعر الكميه'," +
             //    "parcode as'الباركود',lead_time as'المهله',guarantee as'الضمان'," +
             //"product_quality as 'جوده المنتج',permitting_period as 'فتره السماح', reciept_date as 'تاريخ الاستلام' from price_offer  where price_offer_id=@id", con);

             //   cmd.Prepare();
             //   cmd.Parameters.AddWithValue("@id", textBox1.Text);
             //   SqlDataReader dr = cmd.ExecuteReader();
             //   dt = new DataTable();
             //   dt.Load(dr);

             //   dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            MessageBox.Show(c);
            textBox1.Text = c;
            //c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //MessageBox.Show(c);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@id";
                pramvalue[0] = textBox1.Text;
                pramtype[0] = SqlDbType.Int;
                if (textBox1.Text == "")
                    MessageBox.Show("من فضلك ادخل رقم عرض السعر");
                else
                {
                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delpriceofferr", pramname, pramvalue, pramtype);

                    MessageBox.Show("deleted");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {  con.CloseConnection(); }


           
            //int a;
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("Please Enter The Data");
            //}
            //else
            //    if (int.TryParse(textBox1.Text, out a))
            //    {
            //        try
            //        {
            //            con.Open();
            //            SqlCommand cmd = new SqlCommand("delpriceoffer", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            //cmd.Prepare();
            //            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            //            cmd.Connection = con;
            //            cmd.ExecuteNonQuery();
                //     MessageBox.Show("deleted");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //        finally { con.Close(); }
            //    }
            //    else
            //        MessageBox.Show("Invalid data");
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
