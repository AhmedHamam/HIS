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
    public partial class الموظفين : Form
    {
        Connection con = new Connection();
        الموظفين_المصابين y;
        public الموظفين()
        {
            InitializeComponent();
        }
        public الموظفين(الموظفين_المصابين x)
        {
            InitializeComponent();
            y = x;
        }

        private void الموظفين_Load(object sender, EventArgs e)
        {

            try
            {


                con.OpenConection();

                con.DataReader("infection_Employee_select;");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_Employee_select;");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.SetValue4(row);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
