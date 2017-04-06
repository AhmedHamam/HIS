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
    public partial class مزكرهشراء : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        string c;
        string d;
        //SqlDataAdapter da;
        //DataSet ds;
        استخراجمزكرةشراء c1;
        public مزكرهشراء()
        {
            InitializeComponent();
        }
        public مزكرهشراء(استخراجمزكرةشراء f3)
        {
            InitializeComponent();
            c1 = f3;
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("t11");
            con.CloseConnection();
            //SqlCommand cmd = new SqlCommand("t11", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //da = new SqlDataAdapter(cmd);
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // c = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c1.setValue(row.Cells[0].Value.ToString());
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }
}
