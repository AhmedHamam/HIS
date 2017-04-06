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
    public partial class اعدادات_وسائل_استلام_نتيجه_المعمل : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        public اعدادات_وسائل_استلام_نتيجه_المعمل()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            try
            {

                connection.Open();

                // cmd=new SqlCommand(" update analysis_result set receiving_way=N'"+comboBox1.Text+"' ", connection);
                cmd = new SqlCommand("labAnalysis_analysis_result_update ", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recievingway", comboBox1.Text);
                cmd.ExecuteNonQuery();


                
                MessageBox.Show("تمت عمليه التحديث بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void اعدادات_وسائل_استلام_نتيجه_المعمل_Load(object sender, EventArgs e)
        {

        }
    }
}
