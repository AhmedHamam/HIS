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
    public partial class الجهاتالفرعيه1 : Form
    {
        Connection con = new Connection();
        
        /*sqlDataReader dataReader;
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");
        sqlDataAdapter da;
        DataSet ds = new DataSet();*/
         مراجعهاشعاراتالعملاء y;
        مراجعهالمطالباتللعملاء y1;
        public الجهاتالفرعيه1()
        {
            InitializeComponent();
        }

        public الجهاتالفرعيه1(مراجعهاشعاراتالعملاء x)
        {
            InitializeComponent();
            y = x;
        }
        public الجهاتالفرعيه1(مراجعهالمطالباتللعملاء x)
        {
            InitializeComponent();
            y1 = x;
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            /*dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            da = new sqlDataAdapter("select * from subactor", "server=localhost;database=final;uid=root;pwd=root");
            sqlCommandBuilder cb = new sqlCommandBuilder(da);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];*/
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("data_subactor");
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
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
