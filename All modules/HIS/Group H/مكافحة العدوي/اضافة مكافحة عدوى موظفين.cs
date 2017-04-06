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
    public partial class اضافة_مكافحة_عدوى_موظفين : Form
    {
       
     
        static string str;
       
        int check = 0;
        Connection con = new Connection();
        
        public اضافة_مكافحة_عدوى_موظفين()
        {
            InitializeComponent();
        }

        private void اضافة_مكافحة_عدوى_موظفين_Load(object sender, EventArgs e)
        {
        //    dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

        //    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

        //    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

        //    dataGridView1.EnableHeadersVisualStyles = false;

        //    dataGridView1.BorderStyle = 0;
        //    dataGridView1.RowHeadersVisible = false;

        //    dataGridView1.BackgroundColor = Color.Snow;

            try
            {
                con.OpenConection();
                con.DataReader("select_Employee");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_employee_show");
                con.CloseConnection();
                //select_Employee
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
          


            if (check == 2)
            {

                try
                {

                    //infection_adminstration_search
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@x2";
                    pramvalue[0] = textBox9.Text;
                    pramtype[0] = SqlDbType.Int;
                    
                    con.OpenConection();
                
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("infection_adminstration_search", pramname, pramvalue, pramtype);

                    
                    con.CloseConnection();
                   
                    


                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }


            }
            else if (check == 1)
            {

                try
                {
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@x1";
                    pramvalue[0] = textBox6.Text;
                    pramtype[0] = SqlDbType.Int;
                    object x = new object();
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("infection_employee_search_selectionn", pramname, pramvalue, pramtype);
                   
                    
                    con.CloseConnection();
                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else if (check == 3)
            {

                try
                {
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@x3";
                    pramvalue[0] = textBox8.Text;
                    pramtype[0] = SqlDbType.Int;
                    object x = new object();
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("infection_dap_employee_select", pramname, pramvalue, pramtype);

                    con.CloseConnection();
                    


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {

                MessageBox.Show("يرجي اخال اللازمه حتي تتم عمليه البحث");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            عرض_موظفين_تم_لهم_مكافحه_العدوي f = new عرض_موظفين_تم_لهم_مكافحه_العدوي(this);
           
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            عرض_الادارة f = new عرض_الادارة(this);
            f.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            عرض_الاقسام f4 = new عرض_الاقسام(this);
            f4.Show();
        }


        public void Sett(DataGridViewRow r)
        {
            try
            {

                textBox9.Text = r.Cells[0].Value.ToString();
                textBox4.Text = r.Cells[1].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void Sett2(DataGridViewRow r)
        {
            try
            {

                textBox8.Text = r.Cells[0].Value.ToString();
                textBox3.Text = r.Cells[1].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            الموظفين_المصابين r = new الموظفين_المصابين();
            r.Show();
        }



        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            check = 3;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            check = 2;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            check = 1;
        }
        public void setValue(DataGridViewRow r)
        {

            textBox6.Text = r.Cells[0].Value.ToString();

           
        }
        public void setValuee(DataGridViewRow r)
        {

            textBox6.Text = r.Cells[1].Value.ToString();

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        

   
    }
}