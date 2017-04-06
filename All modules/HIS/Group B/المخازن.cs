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
    public partial class المخازن1 : Form
    {
        Connection con = new Connection();
        /*sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");
        sqlDataAdapter da;
        DataSet ds = new DataSet();*/
        مراجعهحركهالمخازن y;
        مراجعهحركهالصيدليات y1;
        اذونالصرفللمخازن y2;
        public المخازن1()
        {
            InitializeComponent();
        }
        public المخازن1(مراجعهحركهالمخازن x)
        {
            InitializeComponent();
            y = x;
        }
        public المخازن1(مراجعهحركهالصيدليات x)
        {
            InitializeComponent();
            y1 = x;
        }
        public المخازن1(اذونالصرفللمخازن x)
        {
            InitializeComponent();
            y2 = x;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            /*dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            da = new sqlDataAdapter("select * from store", "server=localhost;database=final;uid=root;pwd=root");
            sqlCommandBuilder cb = new sqlCommandBuilder(da);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];*/
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("data_store");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (y != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y1 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y1.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y2 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y2.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
