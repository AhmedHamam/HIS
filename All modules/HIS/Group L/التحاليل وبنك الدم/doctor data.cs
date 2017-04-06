using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{
    public partial class doctor_data : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public doctor_data()
        {
            InitializeComponent();
        }

        private void doctor_data_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            cmd = new SqlCommand("select * from doctor", connection);
            dr = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr);
            dataGridView1.DataSource = dt2;
            //dataGridView1.Visible = true;
            dr.Close();
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = "";
            string b = "";
            طلب_عبوات_دم nw = new طلب_عبوات_دم(a,b);
            nw.txtDoctorID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
