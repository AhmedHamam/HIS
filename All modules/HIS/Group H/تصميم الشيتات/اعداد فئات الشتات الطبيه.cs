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
    public partial class اعداد_فئات_الشتات_الطبيه : Form
    {
        Connection con = new Connection();
        
        public اعداد_فئات_الشتات_الطبيه()
        {
            InitializeComponent();
        }

        private void اعداد_فئات_الشتات_الطبيه_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            
            con.OpenConection();
            con.DataReader("MedicalSheet_Category_select_All");
            dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_Category_select_All");
            con.CloseConnection();
           
        }

        //private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string[] pramname = new string[2];
        //    string[] pramvalue = new string[2];
        //    SqlDbType[] pramtype = new SqlDbType[2];
        //    pramname[0] = "@x1";
        //    pramname[1] = "@x2";
            
        //    pramvalue[0] = textBox2.Text;
        //    pramvalue[1] = textBox3.Text;
            
        //    pramtype[0] = SqlDbType.VarChar;
        //    pramtype[1] = SqlDbType.VarChar;
            
        //    object x = new object();

        //    con.OpenConection();
        //    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Category_insert", pramname, pramvalue, pramtype);
        //    MessageBox.Show("تم ادخال البيانات بنجاح");
        //    con.CloseConnection();
          
        //}



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
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("MedicalSheet_Category_delete ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");
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

         
             if (textBox1.Text == ""&& textBox2.Text==""&& textBox3.Text=="")
             {
                     MessageBox.Show("الرجاء ادخال البيانات الناقصه");
             }


             else if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
             {
                 if (textBox1.Text != "" && textBox1.Text.All(char.IsDigit) == true)
                 {
            
                            string[] pramname = new string[1];
                            string[] pramvalue = new string[1];
                            SqlDbType[] pramtype = new SqlDbType[1];
                            pramname[0] = "@x";
                            

                            pramvalue[0] = textBox1.Text;
                            

                            pramtype[0] = SqlDbType.Int;
                            
                          con.OpenConection();
                          dataGridView1.DataSource =con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Category_select_All_by_id",pramname,pramvalue,pramtype);
                           con.CloseConnection();
                 }
                 else if(textBox2.Text != ""&&textBox2.Text.All(char.IsDigit) == false)
                 {
                     if (ContainsArabicLetters(textBox2.Text) == false)
                     {
                         string[] pramname = new string[1];
                         string[] pramvalue = new string[1];
                         SqlDbType[] pramtype = new SqlDbType[1];
                         pramname[0] = "@x";


                         pramvalue[0] = textBox2.Text;


                         pramtype[0] = SqlDbType.VarChar;

                         con.OpenConection();
                         dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Category_select_All_by_EN_Name", pramname, pramvalue, pramtype);
                         con.CloseConnection();
                     }
                     else { MessageBox.Show("يرجي ادخال اسم الفئه باللغه الانجليزيه"); }

                 }

                  else if(textBox3.Text != ""&&textBox3.Text.All(char.IsDigit) == false)
                    
                 {
                     if (ContainsArabicLetters(textBox3.Text) == true)
                     {
                         string[] pramname = new string[1];
                         string[] pramvalue = new string[1];
                         SqlDbType[] pramtype = new SqlDbType[1];
                         pramname[0] = "@x";


                         pramvalue[0] = textBox3.Text;


                         pramtype[0] = SqlDbType.VarChar;

                         con.OpenConection();
                         dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Category_select_All_by_AR_Name", pramname, pramvalue, pramtype);
                         con.CloseConnection();
                     }
                     else { MessageBox.Show("يرجي ادخال اسم الفئه باللغه العربيه"); }
                 }


                 else
                 {
                     MessageBox.Show("يرجي ادخال البيانات بشكل صحيح");
                 }


             }
            
             
             





        }

             
             
        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string[] pramname = new string[2];
            string[] pramvalue = new string[2];
            SqlDbType[] pramtype = new SqlDbType[2];
            pramname[0] = "@x";
            pramname[1] = "@y";

            pramvalue[0] = textBox2.Text;
            pramvalue[1] = textBox3.Text;

            pramtype[0] = SqlDbType.VarChar;
            pramtype[1] = SqlDbType.VarChar;
            object x = new object();




            
                if (ContainsArabicLetters(textBox2.Text) == false&&ContainsArabicLetters(textBox3.Text) == true)
                {
                
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Category_insert", pramname, pramvalue, pramtype);
                    MessageBox.Show("تم ادخال البيانات بنجاح");
                    con.CloseConnection();
                    con.OpenConection();
                    con.DataReader("MedicalSheet_Category_select_All");
                    dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_Category_select_All");
                    con.CloseConnection();
                }

                else
                {
                    MessageBox.Show("الرجاء ادخال البيانات بشكل صحيح");
                }


            }
            
       

        private void خروجToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
