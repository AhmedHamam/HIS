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
    public partial class For3 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataAdapter da;
        //DataSet ds=new DataSet();
        For25 c;
        public For3()
        {
            InitializeComponent();
        }
        public For3(For25 ft)
        {
            c = ft;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //SqlCommand cmd = new SqlCommand("showbilll", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //da = new SqlDataAdapter(cmd);
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];

            try
            {
                con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showbilll");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setV(row.Cells[0].Value.ToString());

            this.Close();
        }
    }
}
