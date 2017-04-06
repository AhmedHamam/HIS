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
    public partial class بياناتالموردين2 : Form
    {
        string c;
        string d;
        اضافةعروضاسعار f13;
        Connection con = new Connection();
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        public بياناتالموردين2()
        {
            InitializeComponent();
        }
        public بياناتالموردين2(اضافةعروضاسعار f3)
        {
            InitializeComponent();
            f13 = f3;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("suppshow");
            con.CloseConnection();
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //da = new SqlDataAdapter("select * from suppliers", @"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];

        }
       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // c = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
           // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            f13.setValue(row.Cells[0].Value.ToString());
            this.Close();
            
           
          
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
