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
    public partial class المتابعة_الشهرية_للاجازات : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt_types = new DataTable();
        DataTable dt_category = new DataTable();
        public المتابعة_الشهرية_للاجازات()
        {
            InitializeComponent();
        }

        private void المتابعة_الشهرية_للاجازات_Load(object sender, EventArgs e)
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
            SqlCommand com = new SqlCommand("month_following", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("vactype_id", comboBox1.SelectedValue);
            com.Parameters.AddWithValue("category_id", comboBox2.SelectedValue);
            com.Parameters.AddWithValue("month", comboBox3.Text);
            com.Parameters.AddWithValue("year", comboBox4.Text);
            try
            {
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("الرجاء التأكد من البيانات");
            }
            con.CloseConnection();
        }

      
    }
}
