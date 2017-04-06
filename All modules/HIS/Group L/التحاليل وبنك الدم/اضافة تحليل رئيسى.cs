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
    public partial class اضافة_تحليل_رئيسى : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public اضافة_تحليل_رئيسى()
        {
            InitializeComponent();
        }

        private void اضافة_تحليل_رئيسى_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                connection.Open();
                cmd = new SqlCommand("select order_number,sample_name from analysis_samples", connection);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            try
            {
                connection.Open();
                cmd = new SqlCommand("insert into analysis_samples(sample_name) values('" + txtServName.Text+ "')", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم اضافة تحليل رئيسى بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
