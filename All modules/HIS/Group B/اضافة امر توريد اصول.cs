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
    public partial class اضافةامرتوريداصول : Form
    {
        Connection con = new Connection();
    //    SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");

      
    //    SqlCommand cmd;
    //    SqlDataReader dr;
        public اضافةامرتوريداصول()
        {
            InitializeComponent();
        }
        public void setV(string d)
        {
            textBox3.Text = d;

        }
        public void setValue(string d)
        {
            textBox2.Text = d;

        }

        private void Form18_Load(object sender, EventArgs e)
        {
           
           
                // con.Open();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox12.Text = "";
                    textBox3.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox10.Text = "";

                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
              con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showCommand");
            con.CloseConnection();
            //try
            //{
            //    //con.Open();
            //    //cmd = new SqlCommand("select commandsupply_id, preivous_price,previous_supplier, charing_method ,payment_method,request_date,date,department_id," +
            //    //"f_assets_id from command_supply ,fixed_assets, f_assets_id_command_supply where commandsupply_id=command_supply_id  and f_assets_id=fassets_id  ; \n", con);
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("showasset", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            string[] pramname = new string[7];
            string[] pramvalue = new string[7];
            SqlDbType[] pramtype = new SqlDbType[7];
            pramname[0] = "@preprice";
            pramname[1] = "@presupplier";
            pramname[2] = "@chargingmethod";
            pramname[3] = "@paymentmethod";
            pramname[4] = "@requestdate";
            pramname[5] = "@date";
            pramname[6] = "@department_id";



            pramvalue[0] = textBox7.Text;
            pramvalue[1] = textBox8.Text;
            pramvalue[2] = textBox10.Text;
            pramvalue[3] = textBox12.Text;
            pramvalue[4] = dateTimePicker1.Value.ToString();
            pramvalue[5] = dateTimePicker2.Value.ToString();
            pramvalue[6] = textBox2.Text;



            pramtype[0] = SqlDbType.Int;
            pramtype[1] = SqlDbType.VarChar;
            pramtype[2] = SqlDbType.VarChar;
            pramtype[3] = SqlDbType.VarChar;
            pramtype[4] = SqlDbType.VarChar;
            pramtype[5] = SqlDbType.VarChar;
            pramtype[6] = SqlDbType.Int;
            if (textBox1.Text == "")
                MessageBox.Show("من فضلك ادخل كود الامر");
            else if (textBox7.Text == "")
                MessageBox.Show("من فضلك ادخل السعر السابق");

            else if (textBox3.Text == "")
                MessageBox.Show("من فضلك اختر كود الاصول");

            else if (textBox2.Text == "")
                MessageBox.Show("من فضلك اختر رقم القسم");
            else
            {
                dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addcateg", pramname, pramvalue, pramtype);
                MessageBox.Show("inserted");
                con.CloseConnection();
            }

        }

     
            
            ////int a;
            ////if (textBox1.Text == "")
            ////{
            ////    MessageBox.Show("Please Enter values");
            ////}
            
            ////else
            ////    if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out a) && int.TryParse(textBox3.Text, out a))
            ////    {
            //        try
            //        {
            //            con.Open();

            //            /*cmd = new SqlCommand(" insert into command_supply(commandsupply_id,preivous_price,previous_supplier,charing_method,payment_method,request_date,date)" +
            //            "values('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "')", con);*/
            //            //cmd = new SqlCommand(" insert into command_supply ( preivous_price,previous_supplier, charing_method ,payment_method,request_date,date,department_id)" +
            //            //    "values (@preprice,@presupplier,@chargingmethod,@paymentmethod,@requestdate,@date,@department_id );\n" +
            //            //    "insert into  f_assets_id_command_supply (fassets_id,command_supply_id ) values (@fasset,@commid);", con);

            //            //cmd.Prepare();
            //            //cmd.Parameters.AddWithValue("@id", textBox1.Text);
            //            SqlCommand cmd = new SqlCommand("addddasset", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@preprice", textBox7.Text);
            //            cmd.Parameters.AddWithValue("@presupplier", textBox8.Text);
            //            cmd.Parameters.AddWithValue("@chargingmethod", textBox10.Text);
            //            cmd.Parameters.AddWithValue("@paymentmethod", textBox12.Text);
            //            cmd.Parameters.AddWithValue("@requestdate", dateTimePicker1.Value);
            //            cmd.Parameters.AddWithValue("@date", dateTimePicker2.Value);
            //            cmd.Parameters.AddWithValue("@department_id", textBox2.Text);
            //            cmd.Parameters.AddWithValue("@fasset", textBox3.Text);
            //            cmd.Parameters.AddWithValue("@commid", textBox1.Text);
            //            cmd.ExecuteNonQuery();
            //            MessageBox.Show("inserted");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //        finally { con.Close(); }
                
               // else
                   // MessageBox.Show("Invalid data");
        

        private void button3_Click(object sender, EventArgs e)
        {
            امرتوريداصول f34 = new امرتوريداصول(this);
            f34.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            الاقسام f35 = new الاقسام(this);
            f35.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("لا يمكن ادخال ارقام");
            textBox2.Text = "";
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("لا يمكن ادخال ارقام");
            textBox2.Text = "";
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("لا يمكن ادخال ارقام");
            textBox2.Text = "";
        }

       
    }
}
