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
    public partial class الاطباء : Form
    {
        public static string Code1 { get; set; }
        public static string Code2 { get; set; }
        Connection con = new Connection();

       // MySqlConnection con;
       // MySqlCommand cmd;
        public الاطباء()
        {
            InitializeComponent();
        }

        private void الاطباء_Load(object sender, EventArgs e)

        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("emergency_doctor1");
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

            //con.Open();
            //string s = "select doctor_code as 'كود الطبيب',doctor_name as 'اسم الطبيب' from doctors;";
            //cmd = new MySqlCommand(s, con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable d = new DataTable();
            //d.Load(dr);
            //dataGridView1.DataSource = d;
            //dr.Close();
            //con.Close();
            con.CloseConnection();

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Code1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                اضافة_اطباء_الطوارىء ff = new اضافة_اطباء_الطوارىء();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
