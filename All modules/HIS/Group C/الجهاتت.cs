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
    public partial class الجهاتت : Form
    {


        public static string Code1 { get; set; }
        public static string Code2 { get; set; }

        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand();
        public الجهاتت()
        {
            InitializeComponent();
        }

        private void الجهاتت_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("dir");
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Code1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                الغاء_خروج_المريض_من_فتره ff = new الغاء_خروج_المريض_من_فتره();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }
    }
}
