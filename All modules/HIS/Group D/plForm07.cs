using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class plForm07 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        Connection connect;
        
       DataTable dt = new DataTable();
        public plForm07()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void plForm07_Load(object sender, EventArgs e)
        {
           
            try
            {
                connect.OpenConection();
                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("planing_titles");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
