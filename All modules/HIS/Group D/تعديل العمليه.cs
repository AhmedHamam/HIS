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
    public partial class تعديل_العمليه : Form
    {
        اعدادات_متقدمه_للعمليه f;
        public SqlDataAdapter da;
        SqlConnection con;
        DataSet ds = new DataSet();
        Connection connect;
        public تعديل_العمليه()
        {
            InitializeComponent();
            connect = new Connection();
            string ConnectionString = connect.getconstr();
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        private void تعديل_العمليه_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            
            da = new SqlDataAdapter("select* from operations where op_code='"+اعدادات_متقدمه_للعمليه.y+"'", con);
            // cmd.Parameters.AddWithValue("@u", textBox2.Text);
           // SqlCommandBuilder cb = new SqlCommandBuilder(da);
            ds.Clear();
            da.Fill(ds);


            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["op_code"].ReadOnly = true;
            dataGridView1.Columns["OS_id"].ReadOnly = true;
            dataGridView1.Columns["doc_ssn"].ReadOnly = true;
            dataGridView1.Columns["visit_id"].ReadOnly = true;
            dataGridView1.Columns["Room_code"].ReadOnly = true;
            dataGridView1.Columns["r_code"].ReadOnly = true;
            dataGridView1.Columns["p_code"].ReadOnly = true;

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            da.Update(ds);
            MessageBox.Show("تم تعديل البيانات بنجاح");


        }
    }
}
