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
    public partial class تعديلبياناتمورد : Form
    {
        Connection con = new Connection();
        
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        // SqlDataAdapter da;
        // DataSet ds;
        
        // SqlDataReader dr; 
     
        public تعديلبياناتمورد()
        {
            InitializeComponent();
           
        }

       
        private void Form11_Load(object sender, EventArgs e)
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
            {
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("supf", pramname, pramvalue, pramtype);
            }
            con.CloseConnection();
            //try
            //{

            //    con.OpenConection();
            //    //not find table [0]
            //    string[] pramname = new string[1];
            //    string[] pramvalue = new string[1];
            //    SqlDbType[] pramtype = new SqlDbType[1];
            //    pramname[0] = "@id";
            //    pramvalue[0] = textBox1.Text;
            //    pramtype[0] = SqlDbType.Int;
             


            //    //con.OpenConection();

            //    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc(" supf", pramname, pramvalue, pramtype);
            //    //MessageBox.Show("");
            //    con.CloseConnection();

            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            //}

            // try
            //{

                //cmd.CommandText = "select commandsupply_id as 'كود امر التوريد ' ,preivous_price as 'الاسعار السابقه', previous_supplier as 'المورد السابق'," +
                //        "charing_method as 'طريقه الشحن' ,request_date as ' تاريخ الطلب' ,date as 'تاريخ الامر'  ,payment_method as 'طريقه الدفع'  ,department_id as 'رقم القسم' from command_supply where commandsupply_id=@id";

                //cmd.Prepare();
                //con.Open();
                //SqlCommand cmd = new SqlCommand("supf", con);
                //cmd.CommandType = CommandType.StoredProcedure;



                //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                //da = new SqlDataAdapter(cmd);
                //SqlCommandBuilder cb = new SqlCommandBuilder(da);
                //ds = new DataSet();
                //da.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
                ////DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                //cmd.ExecuteNonQuery();

                //SqlDataReader dr = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }

            

        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("suppshow");
            con.CloseConnection();
            //SqlDataReader dr = con.DataReader("supshow");
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            
            //MessageBox.Show("تم ادخال البيانات بنجاح");
            
            //con.Open();
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("supshow", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da = new SqlDataAdapter(cmd);
            //    SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //    ds = new DataSet();
            //    da.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
                //DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
        }

        private void label21_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
                    dateTimePicker1.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
            SqlDataAdapter da;
            DataSet ds;
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("suppshow", con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                DataTable dt = new DataTable();
               
                dataGridView1.DataSource = dt;
                da.Update(ds);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
           
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

