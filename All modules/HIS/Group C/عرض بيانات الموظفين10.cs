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
    public partial class عرض_بيانات_الموظفين_10 : Form
    {
        Connection con = new Connection();
        int c;
        public عرض_بيانات_الموظفين_10()
        {
            InitializeComponent();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form23_se");
            
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s22 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                c = int.Parse(s);
                // MessageBox.Show(c.ToString());
                مراجعة_الحضور_للموظفين_لفترة ff = new مراجعة_الحضور_للموظفين_لفترة(c, s2, s3,s4);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }
    }
}
