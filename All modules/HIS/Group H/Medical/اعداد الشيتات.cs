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
    public partial class اعداد_الشيتات : Form
    {
        Connection con = new Connection();
        public اعداد_الشيتات()
        {
            InitializeComponent();
        }

        private void اعداد_الشيتات_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            con.OpenConection();

            SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select1");
            DataTable dt = new DataTable();
               dt.Load(dr);
                dataGridView1.DataSource = dt;
            con.CloseConnection();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") && textBox2.Text.Equals(""))
            {

                MessageBox.Show("يرجي ادخال البيانات حتي تتم عمليه البحث");
            }
            else
            {

                if (textBox1.Text != "")
                {
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();


                        con.OpenConection();
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@x";
                        pramvalue[0] = textBox1.Text;
                        pramtype[0] = SqlDbType.VarChar;
                        if (ContainsArabicLetters(textBox1.Text))
                        {
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Desgin_Select3", pramname, pramvalue, pramtype);
                            con.CloseConnection();

                        }
                        else
                        {
                            MessageBox.Show("يرجي ادخال اسم الشيت باللغة العربية");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                if (textBox2.Text != "")
                {
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();


                        con.OpenConection();

                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@x";
                        pramvalue[0] = textBox2.Text;
                        pramtype[0] = SqlDbType.VarChar;

                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_Desgin_Select4", pramname, pramvalue, pramtype);



                        con.CloseConnection();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
            }






            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                textBox1.Text ="";
            }
             if (textBox2.Text !="")
            {
                textBox2.Text ="";
            }
       
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                
                DataTable dt = new DataTable();
                dt.Load(con.DataReader("MedicalSheet_SheetSetup_Select5"));
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
       



        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        


        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select6");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {



            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select7");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

       
        }

       private void button5_Click_1(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select8");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select9");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

           
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select14");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select12");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select10");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

           

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select10");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select15");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select13");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select16");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select17");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select18");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Select19");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void اضافةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
         اضافة_شيت a = new اضافة_شيت();
            a.Show();
        
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@x" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.VarChar };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Sheet", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");

        }
    
   }
}