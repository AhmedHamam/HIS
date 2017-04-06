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
    public partial class طلب_اجازة : Form
    {
        Connection con = new Connection();
        DataTable dt_category = new DataTable();
        

        public طلب_اجازة()
        {
            InitializeComponent();
        }

        private void طلب_اجازة_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            SqlCommand com=new SqlCommand ("select_vactype", con.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "vac_name";
            comboBox1.ValueMember = "vactype_id";
            dr.Close();
            con.CloseConnection();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.OpenConection();
            dt_category.Clear();
            SqlCommand com = new SqlCommand("select_category", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("vac_name", comboBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            dt_category.Load(dr);
            comboBox2.DataSource = dt_category;
            comboBox2.DisplayMember = "category_name";
            comboBox2.ValueMember = "category_id";
            dr.Close();
            con.CloseConnection();
        }
      

        private void text_click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_name_dep",con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id",textBox4.Text);
            var a=com.Parameters.Add("name",SqlDbType.VarChar,255);
            a.Direction = ParameterDirection.Output;
            var b=com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox3.Text = a.Value.ToString();
            textBox5.Text = b.Value.ToString();
            con.CloseConnection();

        }

        private void text_click2(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_id_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name",textBox3.Text);
            var a=com.Parameters.Add("id",SqlDbType.Int);
            a.Direction = ParameterDirection.Output;
            var b=com.Parameters.Add("dep_name", SqlDbType.VarChar,255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox4.Text = a.Value.ToString();
            textBox5.Text = b.Value.ToString();
            con.CloseConnection();
        }
        
       

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

      
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            e.Graphics.DrawString("طلب أجازة", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(400, 90));
            e.Graphics.DrawString("رقم الموظف:" + textBox4.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 180, format);
            e.Graphics.DrawString("اسم الموظف:" + textBox3.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 250, format);
            e.Graphics.DrawString("القسم:" + textBox5.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 320, format);
            e.Graphics.DrawString("نوع الأجازة:" + comboBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 390, format);
            e.Graphics.DrawString("فئة الأجازة:" + comboBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 460, format);
            e.Graphics.DrawString("تاريخ البداية:", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 530, format);
            e.Graphics.DrawString("تاريخ الإنتهاء:", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 800, 600, format);
            e.Graphics.DrawString("توقيع:", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 300, 670, format);

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }
        }
    }
}
