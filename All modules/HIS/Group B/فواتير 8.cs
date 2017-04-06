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
    public partial class For22 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        For21 c;
        public For22()
        {
            InitializeComponent();
        }
         public For22(For21 f6)
        {
            InitializeComponent();
            c= f6;
        }
        private void Form22_Load(object sender, EventArgs e)
         {
             try
             {
                 con.OpenConection();
                 dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("bill_show");
                 con.CloseConnection();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally { con.CloseConnection(); }
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //da = new SqlDataAdapter("bill_show", con);
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
