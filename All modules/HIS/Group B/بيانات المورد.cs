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
    public partial class بياناتالمورد : Form
    {
        string c;
        Connection con = new Connection();
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        public بياناتالمورد()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("suppshow");
            con.CloseConnection();
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //da = new SqlDataAdapter("select * from suppliers", "server=localhost;database=PHIS;uid=root;pwd=root");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //c = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show(c);
            تعديلعروضاسعار f14 = new تعديلعروضاسعار(c);
            f14.Show();

        }
    }
}
