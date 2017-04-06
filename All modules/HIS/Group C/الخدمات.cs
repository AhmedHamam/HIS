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
    public partial class الخدمات : Form
    {
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataReader dr;
        Connection con = new Connection();
        public static int Code1 { get; set; }
        public static string Code2 { get; set; }
        public الخدمات()
        {
            InitializeComponent();
        }

        private void الخدمات_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try
            {
                //dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("");


                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("servisec1_xray1");
                //string s = "select ser_code as 'كود الخدمة',serv_name as 'اسم الخدمة' from services_A;";
                //cmd = new MySqlCommand(s, con);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;
                //dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.CloseConnection();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try
            {


                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("servisec1_lab");
                //string s = "select serv_code as 'كود الخدمة',servs_name as 'اسم الخدمة' from services_T;";
                //cmd = new MySqlCommand(s, con);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;
                //dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try
            {


                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("servisec1_operation");
                //string s = "select serv_code as 'كود الخدمة',servs_name as 'اسم الخدمة' from services_L;";
                //cmd = new MySqlCommand(s, con);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;
                //dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try
            {



                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("servisec1_glass");

                //string s = "select serv_code as 'كود الخدمة',servs_name as 'اسم الخدمة' from services_M;";
                //cmd = new MySqlCommand(s, con);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;
                //dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                اضافة_خدمات_الطوارىء ff = new اضافة_خدمات_الطوارىء();
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
