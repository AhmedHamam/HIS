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
    public partial class عرض_موظفين_تم_لهم_مكافحه_العدوي : Form
    {
        Connection con = new Connection();
        اضافة_مكافحة_عدوى_موظفين y;
        public عرض_موظفين_تم_لهم_مكافحه_العدوي()
        {
            InitializeComponent();
        }
         public عرض_موظفين_تم_لهم_مكافحه_العدوي(اضافة_مكافحة_عدوى_موظفين x)
        {
            InitializeComponent();
            y = x;
        }
       

        private void عرض_موظفين_تم_لهم_مكافحه_العدوي_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                con.DataReader("select_infected_Employee");
                dataGridView1.DataSource = con.ShowDataInGridView("select_infected_Employee");
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValuee(row);
            this.Close();
        }
    }
}
