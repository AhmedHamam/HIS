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
    public partial class relgion : Form
    {
        Connection con = new Connection();
        

        public relgion()
        {
           

            InitializeComponent();
        }

        public void display()
        {

            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("rel_religion");
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

            
             
        }
        private void relgion_Load(object sender, EventArgs e)
        {
            display();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
