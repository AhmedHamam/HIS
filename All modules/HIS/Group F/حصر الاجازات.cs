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
    public partial class حصر_الاجازات : Form
    {
        Connection con = new Connection();

        SqlCommand cmd;
        SqlDataAdapter da;
        
        DataTable dt_departs = new DataTable();
        
        int dep_id;


        public حصر_الاجازات()
        {
            InitializeComponent();
        }

        private void حصر_الاجازات_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            da = new SqlDataAdapter("select * from departement", con.con);
            da.Fill(dt_departs);
            comboBox3.DataSource = dt_departs;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "code";
            con.CloseConnection();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            con.OpenConection();
            SqlCommand com = new SqlCommand("button_totaly", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", comboBox3.Text);
            com.Parameters.AddWithValue("start_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            com.Parameters.AddWithValue("end_date", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"));

            try
            {
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            con.CloseConnection();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("button_detalied", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", comboBox3.Text);
            com.Parameters.AddWithValue("start_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            com.Parameters.AddWithValue("end_date", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"));

            try
            {
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            con.CloseConnection();

        }

       

        
    }
}
