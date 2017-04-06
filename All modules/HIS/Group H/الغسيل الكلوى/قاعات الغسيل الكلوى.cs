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
    public partial class قاعات_HIS : Form
    {
        Connection con = new Connection();
       
        public قاعات_HIS()
        {
            InitializeComponent();
        }

        private void قاعات_HIS_Load(object sender, EventArgs e)
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
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Room_select3");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.CloseConnection();
            try
            {
                
                con.OpenConection();
                dataGridView1.DataSource = con.DataReader("Hemodialysis_Room_select3");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {


                string[] pramname = new string[3];
                string[] pramvalue = new string[3];
                SqlDbType[] pramtype = new SqlDbType[3];
                pramname[0] = "@x2";
                pramname[1] = "@x3";
                pramname[2] = "@x4";

                pramvalue[0] = RAR.Text.ToString();
                pramvalue[1] = RRN.Text.ToString();
                pramvalue[2] = period_code.Text;

                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.Int;

                if (period_code.Text.Equals("") || RAR.Text.Equals("") || RRN.Text.Equals(""))
                    {
                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                    }



                else
                {
                    if (ContainsArabicLetters(RAR.Text))
                    {
                        con.OpenConection();
                        dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Hemodialysis_Room_inserte", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        con.CloseConnection();
                    }
                    else
                    {
                        MessageBox.Show("يرجي ادخال اسم الغرفه باللغه العربية");
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
                        dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Room_select3");

                       
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
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Hemodialysis_Room  ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }
                MessageBox.Show("تم الحذف "); 
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
        public void setValue(DataGridViewRow r)
        {

            period_code.Text = r.Cells[0].Value.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            كود_الفتره f = new كود_الفتره(this);
            f.Show();
        }
    }
}
