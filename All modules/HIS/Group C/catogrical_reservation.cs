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
    public partial class catogrical_reservation : Form
    {
        //MySqlConnection con;
        //MySqlCommand cmd;
        public static string Code1 { get; set; }
        public static string Code2 { get; set; }
        Connection con = new Connection();
        public catogrical_reservation()
        {
            InitializeComponent();
        }

        private void catogrical_reservation_Load(object sender, EventArgs e)
        {

           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

            con.OpenConection();


            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("cateogirical_reservation");
            //string s = "select catog_code  as 'كود الجهه',name as 'اسم الجهه' from catogricals;";
            //cmd = new MySqlCommand(s, con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable d = new DataTable();
            //d.Load(dr);
            //dataGridView1.DataSource = d;
            //dr.Close();
            //con.Close();
            con.CloseConnection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                الحجز_بعد_الموافقه ff = new الحجز_بعد_الموافقه();
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
