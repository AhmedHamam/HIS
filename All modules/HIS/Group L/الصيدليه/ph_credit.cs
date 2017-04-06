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
    public partial class ph_credit : Form
    {
         string med_id = "";
        public ph_credit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_ph_ALL_med_credit");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy__med_credit");
    }
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Connection conn = new Connection();
            conn.OpenConection();
         dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_some__med_credit", new string[] { "@med_id" }, new string[] {  med_id }, new SqlDbType[] { SqlDbType.Int });
        }
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ph_credit_Load(object sender, EventArgs e)
        {

        }
    }
}
