using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HIS;
namespace HIS
{
    public partial class ph_credit_prices : Form
    {
        public ph_credit_prices()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();

            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("select_all_prices");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();
            //    string ss = textBox1.Text;

            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("select_sum_prices");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string med_id = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            Connection conn = new Connection();
            conn.OpenConection();
            //    string ss = textBox1.Text;

            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("select_medecine_quantity_price", new string[] { "@med_id" }, new string[] { med_id }, new SqlDbType[] { SqlDbType.Int });



        }

        private void ph_credit_prices_Load(object sender, EventArgs e)
        {

        }
    }
}
