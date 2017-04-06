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
    public partial class تنفيذ_خطه_HIS : Form
    {
      
        Connection con = new Connection();
        static string str;
        public تنفيذ_خطه_HIS()
        {
            InitializeComponent();
        }

        private void تنفيذ_خطه_HIS_Load(object sender, EventArgs e)
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
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Plan_select");

             

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
                

                string[] pramname = new string[5];
                string[] pramvalue = new string[5];
                SqlDbType[] pramtype = new SqlDbType[5];
                pramname[0] = "@x2";
                pramname[1] = "@x3";
                pramname[2] = "@x4";
                pramname[3] = "@x5";
                pramname[4] = "@x6";
                pramvalue[0] = patient_code.Text;
                pramvalue[1] = doc_type.Text;
                pramvalue[2] = Room_Num.Text;
                pramvalue[3] = Service_Code.Text;
                pramvalue[4] = str;
                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.Int;
                pramtype[3] = SqlDbType.Int;
                pramtype[4] = SqlDbType.VarChar;
                if (patient_code.Text.Equals("") || doc_type.Text.Equals("") || Room_Num.Text.Equals("") || Service_Code.Text.Equals(""))
                {
                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                }
                else
                {
                       con.OpenConection();
                       dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Hemodialysis_Plan_inserte", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        con.CloseConnection();
                   
                }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


                 try
                 {
                     con.OpenConection();
                     dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Plan_select");

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

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
           
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@code" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.Int };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Hemodialysis_Plan  ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");



        

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            str = monthCalendar1.SelectionStart.ToString();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_المرضى_لعمل_خطة_علاجية f = new عرض_المرضى_لعمل_خطة_علاجية(this);
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            عرض_الطبيب_للغسيل f = new عرض_الطبيب_للغسيل(this);
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            عرض_الغرف f = new عرض_الغرف(this);
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            عرض_خدمات_الغسيل_الكلوى f = new عرض_خدمات_الغسيل_الكلوى(this);
            f.Show();
        }
        public void setValue(DataGridViewRow r)
        {

            patient_code.Text = r.Cells[0].Value.ToString();

           // textBox5.Text = r.Cells[1].Value.ToString();
        }
        public void setValue1(DataGridViewRow r)
        {

            doc_type.Text = r.Cells[0].Value.ToString();

            // textBox5.Text = r.Cells[1].Value.ToString();
        }
        public void setValue2(DataGridViewRow r)
        {

            Room_Num.Text = r.Cells[0].Value.ToString();

            // textBox5.Text = r.Cells[1].Value.ToString();
        }
        public void setValue3(DataGridViewRow r)
        {

            Service_Code.Text = r.Cells[0].Value.ToString();

            // textBox5.Text = r.Cells[1].Value.ToString();
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
