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
    public partial class عرض_الطبيب : Form
    {
        Connection con = new Connection();
        الموظفين_المصابين y;
        public عرض_الطبيب()
        {
            InitializeComponent();
        }
        public عرض_الطبيب(الموظفين_المصابين x)
        {
            InitializeComponent();
            y = x;
        }

        private void عرض_الطبيب_Load(object sender, EventArgs e)
        {
          
            try
            {
                con.OpenConection();
                con.DataReader("infection_doctors_select ");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_doctors_select");
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
            y.SetValue5(row);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
