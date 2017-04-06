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
    public partial class استخراجمزكرةشراء : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
        
        public استخراجمزكرةشراء()
        {
            InitializeComponent();
        }
         
         public void setValue(string c)
         {
             textBox2.Text = c;
 
         }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          /* 
            da = new SqlDataAdapter("select * from suppliers", "server=localhost;database=PHIS;uid=root;pwd=root");
       
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];*/
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // c = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //f13.setValue(row.Cells[0].Value.ToString());
            this.Close();


        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            string[] pramname = new string[1];
            string[] pramvalue = new string[1];
            SqlDbType[] pramtype = new SqlDbType[1];
            pramname[0] = "@id";
            pramvalue[0] = textBox2.Text;
            pramtype[0] = SqlDbType.VarChar;
            if (textBox2.Text == "")
                MessageBox.Show("من فضلك كود امر التوريد");
            else
            {

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t1", pramname, pramvalue, pramtype);

                con.CloseConnection();
            }
            //int a;
            //if (textBox1.Text == "" && textBox2.Text == "")
            //{
            //    MessageBox.Show("Please Enter values");
            //}
            //else if (int.Parse(textBox2.Text) < 0)
            //{
            //    MessageBox.Show("Invalid Value");
            //}
            //else
            //    if (int.TryParse(textBox2.Text, out a))
            //    {
            //        try
            //        {


            //            con.Open();
            //            SqlCommand cmd = new SqlCommand("t1", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
                        //cmd = new SqlCommand();
                        //cmd.Connection = con;
                        //cmd.CommandText = "select commandsupply_id ,request_date,date,p_parcode,quantity,pname,quality " +
                        //  "from command_supply,product,prod_command_supply where prod_parcode=p_parcode and command_supply_id=commandsupply_id and commandsupply_id=@id ";

                        //cmd.Prepare();
                //        cmd.Parameters.AddWithValue("@id", textBox2.Text);
                //        dr = cmd.ExecuteReader();
                //        dt = new DataTable();
                //        dt.Load(dr);
                //        dataGridView1.DataSource = dt;


                //    }
                //    catch (Exception ex)
                //    {

                //        MessageBox.Show(ex.Message);
                //    }
                //    finally { con.Close(); }
                //}
                //else
                //    MessageBox.Show("Invalid data");
                
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            مزكرهشراء f24 = new مزكرهشراء(this);
            f24.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }
    }
}
