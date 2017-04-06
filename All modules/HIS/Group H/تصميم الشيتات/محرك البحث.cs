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
    public partial class محرك_البحث : Form
    {
        Connection con = new Connection();

       
        public محرك_البحث()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void بحث_Click(object sender, EventArgs e)
        {
            البحث_بالمستخدمين m = new البحث_بالمستخدمين(this);
            m.Show();
        }


        public void Setvalue(DataGridViewRow r)
        {
            try
            {
                textBox3.Text = r.Cells[1].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void محرك_البحث_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            

            
            con.OpenConection();
            con.DataReader("MedicalSheet_SheetSetup_select_All");
            dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_SheetSetup_select_All");
            con.CloseConnection();

           
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox4.Text == "" && textBox3.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("الرجاء ادخال البيانات الناقصه");
            }


            if (textBox1.Text != "" || textBox4.Text != "" || textBox3.Text != "" || textBox2.Text != "")
            {
              

                if (textBox1.Text != ""&&textBox1.Text.All(char.IsDigit) == true)
                {
                    try
                    {

                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@x";


                        pramvalue[0] = textBox1.Text;


                        pramtype[0] = SqlDbType.Int;

                        con.OpenConection();
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_SheetSetup_select_All_using_Sheet_Id", pramname, pramvalue, pramtype);
                        con.CloseConnection();
                       

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                } //end inner if

                else if (textBox4.Text != "" && textBox4.Text.All(char.IsDigit) == false && ContainsArabicLetters(textBox4.Text)==false)
                {
                    try
                    {
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@x";


                        pramvalue[0] = textBox4.Text;


                        pramtype[0] = SqlDbType.VarChar;

                        con.OpenConection();
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_SheetSetup_select_All_using_EN_Sheet_name", pramname, pramvalue, pramtype);
                        con.CloseConnection();



                        

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }   ///end inner if

                else if (textBox2.Text != "" && textBox2.Text.All(char.IsDigit) == false && ContainsArabicLetters(textBox2.Text) == true)
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
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_SheetSetup_select_All_using_AR_Sheet_name", pramname, pramvalue, pramtype);
                        con.CloseConnection();
                        

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                } 
                    ///end inner if
                    ///

                else if (textBox3.Text != "" && textBox3.Text.All(char.IsDigit) == false)
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
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("users_select_All_use_userName", pramname, pramvalue, pramtype);
                        con.CloseConnection();


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }

                else
                    MessageBox.Show("الرجاء ادخال البيانات صحيحه");
        
            } //end outer if

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }



        

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@code" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.VarChar };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_sheet_from_serch_engin  ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            البحث_بالمستخدمين m = new البحث_بالمستخدمين(this);
            m.Show();
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
    

