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
    public partial class For33 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true"); 
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        For15 c;
        public For33()
        {
            InitializeComponent();
        }
        public For33(For15 f7)
        {
            InitializeComponent();
            c = f7;
        }
        private void Form33_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("ratio_show");
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
            //SqlCommand cmd = new SqlCommand("ratio_show", con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //da = new SqlDataAdapter(cmd); 
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setVal(row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
