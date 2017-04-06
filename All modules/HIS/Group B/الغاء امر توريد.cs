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
    public partial class الغاءامرتوريد : Form
    {
        string c;
        Connection con = new Connection();
        //SqlCommand cmd;
        //SqlDataReader dr;
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");

        //DataTable dt;

        public الغاءامرتوريد()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //cmd = new SqlCommand();


            //cmd.Connection = con;
            //cmd.CommandText = "select commandsupply_id as 'كود امر التوريد ' ,preivous_price as 'الاسعار السابقه', previous_supplier as 'المورد السابق',"+
            //        "charing_method as 'طريقه الشحن' ,request_date as ' تاريخ الطلب' ,date as 'تاريخ الامر'  ,payment_method as 'طريقه الدفع'  ,department_id as 'رقم القسم' from command_supply where commandsupply_id";
            //SqlDataReader dr = cmd.ExecuteReader();
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("showcommandsupplay", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    DataTable dt = new DataTable();
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;



            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }

            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showCommand");
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {

                    textBox3.Text = "";

                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            con.OpenConection();
            string[] pramname = new string[1];
            string[] pramvalue = new string[1];
            SqlDbType[] pramtype = new SqlDbType[1];
            pramname[0] = "@id";
            pramvalue[0] = textBox3.Text;
            pramtype[0] = SqlDbType.VarChar;
            if (textBox3.Text == "")
                MessageBox.Show("من فضلك ادخل كود الامر");
            else
            {

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showcommandsupplaybyid", pramname, pramvalue, pramtype);

                con.CloseConnection();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = c;
            MessageBox.Show(c);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@id";
                pramvalue[0] = textBox3.Text;
                pramtype[0] = SqlDbType.Int;
                if (textBox3.Text == "")
                    MessageBox.Show("من فضلك ادخل كود الامر");
                else
                {

                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delcommandsuplayy", pramname, pramvalue, pramtype);

                    MessageBox.Show("deleted");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }

        }
    }
}
