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
    public partial class طلبات_حجز_اسره_تمت_الموافقه_عليها : Form
    {
        Connection con=new Connection();
       // SqlDataReader dr = new SqlDataReader();
        SqlCommand cmd;
        int id;

        public طلبات_حجز_اسره_تمت_الموافقه_عليها()
        {
            InitializeComponent();
        }
        public طلبات_حجز_اسره_تمت_الموافقه_عليها(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void طلبات_حجز_اسره_تمت_الموافقه_عليها_Load(object sender, EventArgs e)
        {

           
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox2.Text != "")
            {
                con.OpenConection();
                cmd = new SqlCommand("bed_demand");
                try
                {
                    cmd.Connection = con.con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_name", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                  
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }

            else if (textBox3.Text != "")
            {
                con.OpenConection();
                cmd = new SqlCommand("bed_demand2");
                try
                {
                    cmd.Connection = con.con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nursing", textBox3.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }


            else if (textBox1.Text != "")
            {
                con.OpenConection();
                cmd = new SqlCommand("bed_demand3");
                try
                {
                    cmd.Connection = con.con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@n_room", textBox1.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }

            else { MessageBox.Show("ادخل احد الخانات "); }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }
        }
    }
