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
    public partial class كود_الفتره : Form
    {
        Connection con = new Connection();

        قاعات_HIS y;
        public كود_الفتره(قاعات_HIS x)
        {
            InitializeComponent();
            this.y = x;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue(row);
            this.Close();
        }

        private void كود_الفتره_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_Priod_select3");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           // finally { con.CloseConnection(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
