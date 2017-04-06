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
    public partial class عرض_التطعيم : Form
    {
        Connection con = new Connection();
        الموظفين_المصابين y;
        public عرض_التطعيم()
        {
            InitializeComponent();
        }
        public عرض_التطعيم(الموظفين_المصابين x)
        {
            InitializeComponent();
            y = x;
        }

        private void عرض_التطعيم_Load(object sender, EventArgs e)
        {
        
            try
            {
                //infection_vaccinations_select
                con.OpenConection();
                con.DataReader("infection_add_select");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_add_select ");
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.SetValue(row);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
