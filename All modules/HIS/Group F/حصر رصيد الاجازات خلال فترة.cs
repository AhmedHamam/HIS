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
    public partial class حصر_رصيد_الاجازات_خلال_فترة : Form
    {

      Connection con = new Connection();
        SqlDataAdapter da;
        DataTable dt_types = new DataTable();
        DataTable dt_category = new DataTable();

        public حصر_رصيد_الاجازات_خلال_فترة()
        {
            InitializeComponent();
        }



        private void حصر_رصيد_الاجازات_خلال_فترة_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_vactype", con.con);
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

        private void click_taxt(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_name_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", textBox2.Text);
            var a = com.Parameters.Add("name", SqlDbType.VarChar, 255);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox1.Text = a.Value.ToString();
            textBox4.Text = b.Value.ToString();
            con.CloseConnection();

        }

        private void click2_text(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_id_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", textBox1.Text);
            var a = com.Parameters.Add("id", SqlDbType.Int);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox2.Text = a.Value.ToString();
            textBox4.Text = b.Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("following_periodic", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("emp_id", textBox2.Text);
            com.Parameters.AddWithValue("vac_id", comboBox1.SelectedValue);
            com.Parameters.AddWithValue("category_id", comboBox2.SelectedValue);
            com.Parameters.AddWithValue("date_start_vacation", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            com.Parameters.AddWithValue("date_end_vacation", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"));


            try
            {
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch 
            {
                MessageBox.Show("الرجاء كتابة البيانات كاملة");
            }
            con.CloseConnection();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }            }

        

    }
}

