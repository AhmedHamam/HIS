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
    public partial class التمريض : Form
    {
        public static int Code { get; set; }
        public static string name { get; set; }
        Connection con = new Connection();

        public التمريض()
        {
            InitializeComponent();
        }

        private void التمريض_Load(object sender, EventArgs e)
        {


            con.OpenConection();

            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("nurse");
            //MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=emergency");
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("select * from employees  where job_kind='nurse'", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
            con.CloseConnection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ادارة_عربات_الاسعاف1 f = new ادارة_عربات_الاسعاف1();
                // ادارة عرباتff = new تسجيل_بيانات__مريض();
                //تقرير1 f = new تقرير1();
                f.Focus();
                //  ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }
    }
}
