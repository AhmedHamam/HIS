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
    public partial class البحث_بالمستخدمين : Form
    {
        //Connection con = new Connection();
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        //SqlDataAdapter da;
        //BindingSource bs = new BindingSource();
        //DataSet ds = new DataSet();
        Connection con = new Connection();
        محرك_البحث y =new محرك_البحث();
        public البحث_بالمستخدمين()
        {
            InitializeComponent();
        }
        public البحث_بالمستخدمين(محرك_البحث x)
        {
            InitializeComponent();
            y = x;
        }

        public void Setvalue(DataGridViewRow r)
        {
            try
            {
                textBox4.Text = r.Cells[0].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void البحث_بالمستخدمين_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            
            
            try
            {
                

                con.OpenConection();
                con.DataReader("users_select_User_Code_AND_User_Name");
                dataGridView1.DataSource = con.ShowDataInGridView("users_select_User_Code_AND_User_Name");
                con.CloseConnection();

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            البحث_بالمجموعه m = new البحث_بالمجموعه(this);
            m.Show();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(textBox1.Text==""&&textBox2.Text==""&&textBox3.Text==""&&textBox4.Text=="")
            {

                MessageBox.Show("الرجاء ادخال البيانات الناقصه");
            }


            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "")
            {

                
                    if (textBox1.Text != ""&&textBox1.Text.All(char.IsDigit) == false)
                    {
                        try
                        {


                            string[] pramname = new string[1];
                            string[] pramvalue = new string[1];
                            SqlDbType[] pramtype = new SqlDbType[1];
                            pramname[0] = "@x";


                            pramvalue[0] = textBox1.Text;


                            pramtype[0] = SqlDbType.Text;

                            con.OpenConection();
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("users_select_All_use_userName", pramname, pramvalue, pramtype);
                            con.CloseConnection();
                           
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }

                    } ////end1


                    else if (textBox2.Text != ""&&textBox2.Text.All(char.IsDigit) == false)
                    {

                        try
                        {

                            string[] pramname = new string[1];
                            string[] pramvalue = new string[1];
                            SqlDbType[] pramtype = new SqlDbType[1];
                            pramname[0] = "@x";


                            pramvalue[0] = textBox2.Text;


                            pramtype[0] = SqlDbType.VarChar;

                            con.OpenConection();
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("employee_select_by_name", pramname, pramvalue, pramtype);
                            con.CloseConnection();
                           

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                    }//////////end2

                


                
                    else if (textBox3.Text != ""&&textBox3.Text.All(char.IsDigit) == true)
                    {

                        try
                        {
                            string[] pramname = new string[1];
                            string[] pramvalue = new string[1];
                            SqlDbType[] pramtype = new SqlDbType[1];
                            pramname[0] = "@x";


                            pramvalue[0] = textBox3.Text;


                            pramtype[0] = SqlDbType.VarChar;

                            con.OpenConection();
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("employee_select_by_id", pramname, pramvalue, pramtype);
                            con.CloseConnection();
                           

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }

                    } ////end2


                    else if (textBox4.Text != "" && textBox4.Text.All(char.IsDigit) == true)
                    {

                        try
                        {

                            string[] pramname = new string[1];
                            string[] pramvalue = new string[1];
                            SqlDbType[] pramtype = new SqlDbType[1];
                            pramname[0] = "@x";


                            pramvalue[0] = textBox4.Text;


                            pramtype[0] = SqlDbType.Int;

                            con.OpenConection();
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("group_has_user", pramname, pramvalue, pramtype);
                            con.CloseConnection();
                            

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }

                    }



                    else
                        MessageBox.Show("الرجاء ادخال البيانات صحيحه");
                



            }/////////////end



            
            
            

            
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.Setvalue(row);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            البحث_بالمجموعه m = new البحث_بالمجموعه(this);
            m.Show();
        }
    }
}
