using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class تقريرلحصرالبنود : Form
    {
        public تقريرلحصرالبنود()
        {
            InitializeComponent();
        }
        Connection con = new Connection();

        private void button1_Click(object sender, EventArgs e)
        {
         
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("show_item", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
          //  MySqlCommand cmd = new MySqlCommand("select item_id as 'رقم البند' ,item_name as 'اسم البند' ,credit_value as 'قيمة الاعتماد ',section_id as 'رقم الباب'  from items ;", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
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
