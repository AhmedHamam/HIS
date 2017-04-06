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
    public partial class فريق_العمل1 : Form
    {
        public static string Code1 { get; set; }
        public static string Code2 { get; set; }

        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand();
        public فريق_العمل1()
        {
            InitializeComponent();
        }

        private void فريق_العمل_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("team_work");
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                اعدادات_فريق_العمل_الطبى_بالمستشفى ff = new اعدادات_فريق_العمل_الطبى_بالمستشفى();
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
