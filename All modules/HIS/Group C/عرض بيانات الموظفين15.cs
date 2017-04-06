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
    public partial class عرض_بيانات_المظفين15 : Form
    {
        Connection con = new Connection();
        public عرض_بيانات_المظفين15()
        {
            InitializeComponent();
        }

        private void Form38_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form38_se");

                      con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s5 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String s6 = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                int c = int.Parse(s);

                // MessageBox.Show(c.ToString());
                كشف_الحضور_والانصراف_اليومي ff = new كشف_الحضور_والانصراف_اليومي(c, s2, s3, s4,s5,s6);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
