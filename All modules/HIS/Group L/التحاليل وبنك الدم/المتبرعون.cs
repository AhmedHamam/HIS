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
    public partial class المتبرعون : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public المتبرعون()
        {
            InitializeComponent();
        }

        private void المتبرعون_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            connection.Open();
            try
            {
                //cmd = new SqlCommand("select * from supplier where supplierType='donator'", con);
                cmd = new SqlCommand("bloodBank_supplier_select", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                supplierPrint nw = new supplierPrint(dt);
                nw.Show();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}
