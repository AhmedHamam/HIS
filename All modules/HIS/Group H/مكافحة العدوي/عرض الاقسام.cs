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
    public partial class عرض_الاقسام : Form
    {
        Connection con = new Connection();
        اضافة_مكافحة_عدوى_موظفين y;
        public عرض_الاقسام()
        {
            InitializeComponent();
        }
        public عرض_الاقسام(اضافة_مكافحة_عدوى_موظفين x)
        {
            InitializeComponent();
            y = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void عرض_الاقسام_Load(object sender, EventArgs e)
        {
           
            try
            {
                con.OpenConection();
                con.DataReader("infection_department_select");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_department_select");
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
            y.Sett2(row);
            this.Close();
        }
    }
}
