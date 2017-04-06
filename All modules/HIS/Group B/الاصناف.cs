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
    public partial class الاصناف : Form
    {
        Connection con = new Connection();
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        اضافةامرتوريداصناف c;
        اضافةامرتوريدادوية c1;
       //SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        public الاصناف()
        {
            InitializeComponent();
        }
        public الاصناف (اضافةامرتوريداصناف f5)
        {
            InitializeComponent();
            c= f5;
           
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("productt");
            con.CloseConnection();
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //SqlCommand cmd = new SqlCommand("productt", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //da = new SqlDataAdapter(cmd);
            
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setValue(row.Cells[0].Value.ToString());
           
            this.Close();
        }
    }
}
