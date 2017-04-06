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
    public partial class قائمه_الوحدات_المستخدمه_بالمعمل : Form
    {

        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public قائمه_الوحدات_المستخدمه_بالمعمل()
        {
            InitializeComponent();
        }

        private void قائمه_الوحدات_المستخدمه_بالمعمل_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            // cmd = new SqlCommand("select*from unit_list_in_lab", connection);
            cmd = new SqlCommand("labAnalysis_unit_list_in_lab_select", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            connection.Close();
            dataGridView1.Visible = true;
        }
    }
}
