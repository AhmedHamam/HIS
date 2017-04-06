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
    public partial class For29 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //DataTable dt;
        public For29()
        {
            InitializeComponent();
        }
        public void setV(string c, string d)
        {
            textBox4.Text = c;

            textBox5.Text = d;

        }
        public void setVal(string d, string c,string b, string t)
        {
            textBox8.Text = d;
            textBox7.Text = c;
            textBox2.Text = b;
            textBox2.Text = t;

        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Form29_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] pramname = new string[8];
                string[] pramvalue = new string[8];
                SqlDbType[] pramtype = new SqlDbType[8];
                pramname[0] = "@bill_id";
                pramname[1] = "@ratio_id";
                pramname[2] = "@discount_type";
                pramname[3] = "@ratio";
                pramname[4] = "@value";
                pramname[5] = "@total_before_discount";
                pramname[6] = "@total_after_discount";
                pramname[7] = "@discount_process";

                pramvalue[0] = textBox7.Text;
                pramvalue[1] = textBox9.Text;
                pramvalue[2] = textBox4.Text;
                pramvalue[3] = textBox6.Text;
                pramvalue[4] = textBox5.Text;
                pramvalue[5] = textBox1.Text;
                pramvalue[6] = textBox2.Text;
                pramvalue[7] = textBox8.Text;

                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.Decimal;
                pramtype[4] = SqlDbType.Decimal;
                pramtype[5] = SqlDbType.Decimal;
                pramtype[6] = SqlDbType.Decimal;
                pramtype[7] = SqlDbType.VarChar;



                dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("drug_discount_add", pramname, pramvalue, pramtype);



                MessageBox.Show("تم الادخال");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("drug_discount_add", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //   // cmd.Parameters.AddWithValue("@id", textBox1.Text);
            //    cmd.Parameters.AddWithValue("@bill_id", textBox3.Text);
            //    cmd.Parameters.AddWithValue("@discount_type", textBox8.Text);
            //    cmd.Parameters.AddWithValue("@ratio", textBox2.Text);
            //    cmd.Parameters.AddWithValue("@value", textBox5.Text);
            //    cmd.Parameters.AddWithValue("@total_before_discount", textBox4.Text);
            //    cmd.Parameters.AddWithValue("@total_after_discount", textBox6.Text);
            //    cmd.Parameters.AddWithValue("@discount_process", textBox7.Text);
            //    cmd.Parameters.AddWithValue("@ratio_id", textBox9.Text);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("inserted");

            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally { con.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double a = Double.Parse(textBox2.Text) / 100.0;
            double c = Double.Parse(textBox4.Text);
            double s = (a) * c;
            textBox3.Text = s.ToString();
            double b = c - s;
            textBox6.Text = b.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("drug_show");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
            //dt = new DataTable();
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("drug_show", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally { con.Close(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox2.Text = "";
                    dataGridView1.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            For30 f30 = new For30(this);
            f30.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            For37 f37 = new For37(this);
            f37.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
