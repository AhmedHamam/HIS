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
    public partial class الموظفين_المصابين : Form
    {
        
        static string str;
        static string str2;
        static string str3;
        Connection con = new Connection();
        اضافة_مكافحة_عدوى_موظفين x;
        public الموظفين_المصابين()
        {
            InitializeComponent();
        }
        public الموظفين_المصابين(اضافة_مكافحة_عدوى_موظفين y)
        {
            InitializeComponent();
            this.x=y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void الموظفين_المصابين_Load(object sender, EventArgs e)
        {
            
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
        }
        public void SetValue(DataGridViewRow r)
        {
            try
            {

                this.textBox3.Text = r.Cells[0].Value.ToString();
             

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void SetValue4(DataGridViewRow r)
        {
            try
            {

                this.textBox5.Text = r.Cells[0].Value.ToString();
           

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void SetValue3(DataGridViewRow r)
        {
            try
            {

                textBox7.Text = r.Cells[0].Value.ToString();
               


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void SetValue5(DataGridViewRow r)
        {
            try
            {

                textBox10.Text = r.Cells[0].Value.ToString();
               

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@code" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.VarChar };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_infected_Employe  ", name, value, type);

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

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            str3 = dateTimePicker3.Value.ToString();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
           
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            string[] pramname = new string[12];
            string[] pramvalue = new string[12];
            SqlDbType[] pramtype = new SqlDbType[12];
            pramname[0] = "@x2";
            pramname[1] = "@x3";
            pramname[2] = "@x4";

            pramname[3] = "@x5";
            pramname[4] = "@x7";
            pramname[5] = "@x8";
            pramname[6] = "@x9";
            pramname[7] = "@x10";
            pramname[8] = "@x12";
            pramname[9] = "@x14";
            pramname[10] = "@x16";
            pramname[11] = "@x17";

            pramvalue[0] = textBox1.Text;
            pramvalue[1] = textBox2.Text;
            pramvalue[2] = str2;
            //pramvalue[3] = checkBox1.Select;
            //pramvalue[4] = checkBox2.Checked;
            //pramvalue[5] = checkBox3.Checked;
            //pramvalue[6] = checkBox4.Checked;
             
            pramvalue[7] = textBox5.Text;
            pramvalue[8] = textBox7.Text;
            pramvalue[9] =  textBox3.Text;
            pramvalue[10] = str3;
            pramvalue[11] = textBox10.Text;

            pramtype[0] = SqlDbType.VarChar;
            pramtype[1] = SqlDbType.VarChar;
            pramtype[2] = SqlDbType.VarChar;
            pramtype[3] = SqlDbType.VarChar;
            pramtype[4] = SqlDbType.VarChar;
            pramtype[5] = SqlDbType.VarChar;
            pramtype[6] = SqlDbType.VarChar;

            pramtype[7] = SqlDbType.VarChar;

            pramtype[8] = SqlDbType.VarChar;
            pramtype[9] = SqlDbType.VarChar;
            pramtype[10] = SqlDbType.VarChar;
            pramtype[11] = SqlDbType.VarChar;

            
           

            try
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox5.Text.Equals("") || textBox7.Text.Equals("") || textBox10.Text.Equals(""))
                {
                    MessageBox.Show("يرجي ادخال البيانات كاملة");
                }

                else
                {
                    if (checkBox4.Checked)
                    {
                        pramvalue[6] = "yes";
                    }
                    else
                    {
                        pramvalue[6] = "No";

                    }

                    if (checkBox2.Checked)
                    {
                        pramvalue[4] = "Yes";
                    }
                    else
                    {
                        pramvalue[4] = "No";
                    }
                    if (checkBox3.Checked)
                    {
                        pramvalue[5] = "Yes";
                    }
                    else
                    {
                        pramvalue[5] = "No";
                    }

                    if (checkBox1.Checked)
                    {
                        pramvalue[3] = "Yes";
                    }
                    else
                    {
                        pramvalue[3] = "No";
                    }

                    if (ContainsArabicLetters(textBox2.Text) && ContainsArabicLetters(textBox1.Text))
                    {

                        pramvalue[0] = textBox1.Text;
                        pramvalue[1] = textBox2.Text;
                        pramvalue[2] = str2;
                        pramvalue[7] = textBox5.Text;
                        pramvalue[8] = textBox7.Text;
                        pramvalue[9] = textBox3.Text;
                        pramvalue[10] = str3;
                        pramvalue[11] = textBox10.Text;
                        con.OpenConection();
                        dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_infected_Employe", pramname, pramvalue, pramtype);
                        
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();

                    }

                    else
                    {

                        MessageBox.Show("يرجي ادخال المشاكل الجراحية والطبيه باللغة العربية");
                    }
                    

                   
                }
               

            }



            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


            try
            {
                con.OpenConection();
                con.DataReader("select_infected_Employee");
                dataGridView1.DataSource = con.ShowDataInGridView("select_infected_Employee");
                con.CloseConnection();
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
           
        }

       

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            عرض_التطعيم s = new عرض_التطعيم(this);
            s.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_الخدمات ss = new عرض_الخدمات(this);
            ss.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            الموظفين f = new الموظفين(this);
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            عرض_الطبيب f = new عرض_الطبيب(this);
            f.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        { 

        }

        private void label3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox10.Clear();
            
            
        }


    }
     

}

       

       

