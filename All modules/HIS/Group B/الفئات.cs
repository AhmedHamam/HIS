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
    public partial class الفئات1 : Form
    {
        Connection con = new Connection();
        /*sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");
        sqlDataAdapter da;
        DataSet ds = new DataSet();*/
        مراجعهفواتيرالمرضى y;
        public الفئات1()
        {
            InitializeComponent();
        }
        public الفئات1(مراجعهفواتيرالمرضى x)
        {
            InitializeComponent();
            y = x;
        }
        private void Form44_Load(object sender, EventArgs e)
        {
           /* dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            da = new sqlDataAdapter("select * from grou", "server=localhost;database=final;uid=root;pwd=root");
            sqlCommandBuilder cb = new sqlCommandBuilder(da);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];*/
            try
            {
                con.OpenConection();
              dataGridView1.DataSource = con.ShowDataInGridView("data_grou");
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
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}