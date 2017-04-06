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
    public partial class For25 : Form
    {
        string c;
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");

        //DataTable dt;
        //SqlCommand cmd;
        public For25()
        {
            InitializeComponent();
        }
        public void setV(string d)
        {
            textBox1.Text = d;


        }

        private void Form25_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t22");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("t22", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
                //cmd = new SqlCommand();
                //cmd.Connection = con;
                // cmd.CommandText = "select bill_id as'رقم الفاتوره',payment_value as 'القيمه المدفوعه',resdual_value as 'القيمه المتبقيه',net_value as 'الصافي',bill_date as 'تاريخ الفاتوره' ,b.supplier_id as 'رقم المورد' ,s.supplier_name as 'اسم المورد' from bill b, suppliers s where s.supplier_id= b.supplier_id";

                // cmd.Prepare();
                //  cmd.Parameters.AddWithValue("@id", textBox1.Text);
              //  SqlDataReader dr = cmd.ExecuteReader();
              //DataTable  dt = new DataTable();
              //  dt.Load(dr);

              //  dataGridView1.DataSource = dt;
              //  con.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("من فضلك ادخل كود المورد ");
                textBox1.Focus();
            }
            else
                if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل كود المورد بشكل صحيح");
                    textBox1.Focus();
                }

                else
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

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t222", pramname, pramvalue, pramtype);

                       
                        //con.Open();
                        ////cmd = new SqlCommand();
                        ////cmd.Connection = con;
                        ////cmd.CommandText = "select bill_id as'رقم الفاتوره',payment_value as 'القيمه المدفوعه',resdual_value as 'القيمه المتبقيه',net_value as 'الصافي',bill_date as 'تاريخ الفاتوره' ,b.supplier_id as 'رقم المورد' ,s.supplier_name as 'اسم المورد' from  bill b, suppliers s where s.supplier_id= b.supplier_id and bill_id=@id";

                        //SqlCommand cmd = new SqlCommand("t222", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Prepare();
                        //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        //SqlDataReader dr = cmd.ExecuteReader();
                        //dt = new DataTable();
                        //dt.Load(dr);

                        //dataGridView1.DataSource = dt;
                        //con.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    //textBox5.Text = "";
                    textBox2.Text = "";
                   // textBox3.Text = "";
                    // textBox8.Text = "";
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
    }

        private void button5_Click(object sender, EventArgs e)
        {

            For3 f3 = new For3();
            f3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        }
}
