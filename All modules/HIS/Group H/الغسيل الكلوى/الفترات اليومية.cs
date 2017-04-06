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
    public partial class الفترات_اليومية : Form
    {
       
        Connection con = new Connection();
        static string str1;
        static string str2;
        public الفترات_اليومية()
        {
            InitializeComponent();
        }

        private void الفترات_اليومية_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.GhostWhite;
            
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Priod_select");

               
           

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



            try
            {
                
                con.OpenConection();

                string[] pramname = new string[4];
                string[] pramvalue = new string[4];
                SqlDbType[] pramtype = new SqlDbType[4];
                pramname[0] = "@x2";
                pramname[1] = "@x3";
                pramname[2] = "@x4";
                pramname[3] = "@x5";

                pramvalue[0] = textBox2.Text.ToString();
                pramvalue[1] = textBox3.Text.ToString();
                pramvalue[2] = str1;

                pramvalue[3] = str2;

                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                if ( textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                }



                else
                {
                    if (ContainsArabicLetters(textBox2.Text))
                      {
               
                    con.OpenConection();
                    dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Hemodialysis_Priod_inserte", pramname, pramvalue, pramtype);
                    MessageBox.Show("تم ادخال البيانات بنجاح");
                    con.CloseConnection();
                      }
                     else
                      {
                        MessageBox.Show("يرجي ادخال اسم الفتره باللغه العربية");
                      }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
                try
                {
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Priod_select");

               

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@code" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.Int };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Hemodialysis_Priod  ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");



        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            str2 = dateTimePicker2.Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            str1 = dateTimePicker1.Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
    }
}
