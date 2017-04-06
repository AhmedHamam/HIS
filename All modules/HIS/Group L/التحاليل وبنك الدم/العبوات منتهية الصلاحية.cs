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
    public partial class العبوات_منتهية_الصلاحية : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public العبوات_منتهية_الصلاحية()
        {
            InitializeComponent();
        }

        private void العبوات_منتهية_الصلاحية_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            connection.Open();
            try
            {
                //cmd = new SqlCommand("select * from bloodpackage where exDate <'" + dtNow.Value + "'", con);
                cmd = new SqlCommand("bloodBank_bloodPackage_select", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("exDate", dtNow.Value);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();

                expiredPackagePrint nw = new expiredPackagePrint(dt);
                nw.Show();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
    }
}
