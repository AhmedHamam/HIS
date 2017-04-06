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
    public partial class اضافة_تطعيم_جديد : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        static string str;
        BindingSource bs= new BindingSource();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        Connection con = new Connection();
        public اضافة_تطعيم_جديد()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

               
                //ادخال بيانات التطعيم
                string[] pramname = new string[4];
                string[] pramvalue = new string[4];
                SqlDbType[] pramtype = new SqlDbType[4];
                pramname[0] = "@x2";
                pramname[1] = "@x3";
                pramname[2] = "@x4";
                pramname[3] = "@x5";
                pramvalue[0] =textBox2.Text ;
                pramvalue[1] = textBox4.Text;
                pramvalue[2] = comboBox1.SelectedItem.ToString();
                pramvalue[3] = dateTimePicker1.Text;
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                object x = new object();
               
             
                
                //للتاكد ان القيم الداخله لا تساوى null
                if (textBox2.Text.Equals("") || comboBox1.SelectedItem.Equals(""))
                {
                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                }


                else
                {
                    if (ContainsArabicLetters(textBox2.Text))
                    {
                        con.OpenConection();
                        dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("infection_add_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        con.CloseConnection();
                       
                    }
                    else
                    {   //لابد اسم التطعيم العربي ان يكون بللغه العربيه
                        MessageBox.Show("يرجي ادخال اسم التطعيم باللغه العربية");
                    }
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }



           
            
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                con.OpenConection(); 

                 con.DataReader("infection_add_select");
                 dataGridView1.DataSource = con.ShowDataInGridView("infection_add_select");
               con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection(); 

        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    str = dateTimePicker1.Value.ToString();
            
        //}

        private void اضافة_تطعيم_جديد_Load(object sender, EventArgs e)
        {
      
            con.OpenConection();
            dateTimePicker1.Value = DateTime.Now;
            
            try
            {

                con.DataReader("infection_add_select");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_add_select"); 

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        internal static bool ContainsArabicLetters(string text)
        {
            foreach (char character in text.ToCharArray())
            {
                if (character >= 0x600 && character <= 0x6ff)
                    return true;

                if (character >= 0x750 && character <= 0x77f)
                    return true;

                if (character >= 0xfb50 && character <= 0xfc3f)
                    return true;

                if (character >= 0xfe70 && character <= 0xfefc)
                    return true;
            }

            return false;
        }

        private void حذف_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name={"@vaccination_code"};
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type={SqlDbType.VarChar};
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_vaccinationn ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }
              
                
            }
            MessageBox.Show("تم الحذف");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
