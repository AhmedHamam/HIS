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
    public partial class استقبال_HIS : Form
    {
        //static string str;
        //SqlCommand cmd;
        //SqlDataReader dr;
        Connection con = new Connection();
        static string str;

        public استقبال_HIS()
        {
            InitializeComponent();
        }

        private void استقبال_HIS_Load(object sender, EventArgs e)
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
            //try
            //{
               
            //    con.OpenConection();
            //    dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_PatientReception_select");


            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
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

                pramvalue[0] = patient_Code.Text;
                pramvalue[1] = monthCalendar1.TodayDate.Date.ToShortDateString();
                pramvalue[2] = comboBox2.SelectedItem.ToString();
             
                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.VarChar;
               
                if (patient_Code.Text.Equals("") || comboBox2.SelectedItem.Equals(""))
                {
                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                }

                else
                {
                      con.OpenConection();
                      dataGridView1.DataSource = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Hemodialysis_PatientReception_inserte", pramname, pramvalue, pramtype);
                      MessageBox.Show("تم ادخال البيانات بنجاح");
                      con.CloseConnection();
                }
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    //try
                    //{
                    //    //dataGridView1.DataSource = null;
                    //    //ds.Tables.Clear();
                    //    //dataGridView1.Rows.Clear();
                    //    //dataGridView1.Refresh();

                    //    con.OpenConection();
                    //    dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_PatientReception_select");

                  

                    //}

                    //catch (Exception ex)
                    //{

                    //    MessageBox.Show(ex.Message);
                    //}

                
               
            
        }
   

        private void خروج_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //    str = 
        //}

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

             if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@code" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.Int};

                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Hemodialysis_PatientReception  ", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                }

            }


            MessageBox.Show("تم الحذف");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_المرضى_للغسل_الكلوى f = new عرض_المرضى_للغسل_الكلوى(this);
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void setValue(DataGridViewRow r)
        {

            patient_Code.Text = r.Cells[0].Value.ToString();

            // textBox5.Text = r.Cells[1].Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
