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
    public partial class عرض_الخدمات : Form
    {
        Connection con = new Connection();
        الموظفين_المصابين y;
        public عرض_الخدمات()
        {
            InitializeComponent();
        }
        public عرض_الخدمات(الموظفين_المصابين x)
        {
            InitializeComponent();
            y = x;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.SetValue3(row);

            this.Close();
        }

        private void عرض_الخدمات_Load(object sender, EventArgs e)
        {
           
            try
            {
                con.OpenConection();
                con.DataReader("infection_Servicess_select ");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_Servicess_select");
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
