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
    public partial class اعداد_وحدات_القياس : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        ////SqlDataReader dr;
        //SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //BindingSource bs = new BindingSource();
        //DataGridCell cell = new DataGridCell();


        Connection con = new Connection();
        
        public اعداد_وحدات_القياس()
        {
            InitializeComponent();
        }

        private void اعداد_وحدات_القياس_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;

           



            con.OpenConection();

            con.DataReader("MedicalSheet_MeasurementUnits_select_names");
            dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_MeasurementUnits_select_names");
            con.CloseConnection();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("MedicalSheet_MeasurementUnits_deleting ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");
            
            
            
            
            
           
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            string[] pramname = new string[2];
            string[] pramvalue = new string[2];
            SqlDbType[] pramtype = new SqlDbType[2];
            pramname[0] = "@x";
            pramname[1] = "@y";

            pramvalue[0] = textBox2.Text;
            pramvalue[1] = textBox1.Text;

            pramtype[0] = SqlDbType.VarChar;
            pramtype[1] = SqlDbType.VarChar;

            if (ContainsArabicLetters(textBox2.Text) == true && ContainsArabicLetters(textBox1.Text) == false)
            {
                con.ShowDataInGridViewUsingStoredProc("MedicalSheet_MeasurementUnits_inserting", pramname, pramvalue, pramtype);
                MessageBox.Show("تم ادخال البيانات بنجاح");

                con.CloseConnection();

                con.OpenConection();

                con.DataReader("MedicalSheet_MeasurementUnits_select_names");
                dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_MeasurementUnits_select_names");
                con.CloseConnection();
            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات بشكل صحيح");
            }

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    
    
    
    
    }
}
