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
    public partial class عرض_الموطفين : Form
    {
        Connection con = new Connection();
        اضافة_مكافحة_عدوى_موظفين y;
        public عرض_الموطفين()
        {
            InitializeComponent();
        }
        public عرض_الموطفين(اضافة_مكافحة_عدوى_موظفين x)
        {
            InitializeComponent();
            y = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void عرض_الموطفين_Load(object sender, EventArgs e)
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

                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue(row);
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
