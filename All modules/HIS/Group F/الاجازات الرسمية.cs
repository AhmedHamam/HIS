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
    public partial class الاجازات_الرسمية : Form
    {
       Connection con = new Connection();
        public الاجازات_الرسمية()
        {
            InitializeComponent();
        }

        private void الاجازات_الرسمية_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            
                  con.OpenConection();
                  if (textBox2.TextLength != 0 && textBox3.TextLength != 0)
                  {
                      SqlCommand com = new SqlCommand("insert_off_vac", con.con);
                      com.CommandType = CommandType.StoredProcedure;
                      com.Parameters.AddWithValue("name", textBox2.Text);
                      com.Parameters.AddWithValue("start_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                      com.Parameters.AddWithValue("end_date", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                      com.Parameters.AddWithValue("length", textBox3.Text);
                      com.ExecuteNonQuery();
                      MessageBox.Show("تم إضافة الأجازة");
                  }
                  else
                  {
                   
                      MessageBox.Show("الرجاء ادخال اسم الأجازة");
                  } 
                  

            con.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_off_vac", con.con);

            try
            {
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch 
            {
                MessageBox.Show("تأكد من البيانات");
            }
            con.CloseConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "")
            {
                MessageBox.Show("الرجاء ادخال رقم الأجازة");
            }
            else
            {
                con.OpenConection();
                SqlCommand com = new SqlCommand("delete_off_vac", con.con);
                
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("id", textBox1.Text);
                    com.ExecuteNonQuery();

                    MessageBox.Show("تم حذف الأجازة");
            }
            con.CloseConnection();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }
        }

       

       
    }
}
