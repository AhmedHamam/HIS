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
    public partial class بياناتالمورد1 : Form
    {
        Connection con = new Connection();
        string c;
        string d;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        public بياناتالمورد1()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
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
            c = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            d = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show(c);
            Form10 f10 =new Form10();
            f10.Show();
        }

    }
}
