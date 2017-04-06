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
    public partial class عرض_خدمات_الطوارئ : Form
    {
        public static int Code1 { get; set; }
        public static string name { get; set; }
        public static string peri { get; set; }
        //MySqlConnection con;
        //MySqlCommand cmd1;
        //MySqlDataReader dr;
        Connection con=new Connection();


        public عرض_خدمات_الطوارئ()
        {
            InitializeComponent();
        }


        private void عرض_خدمات_الطوارئ_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

          
            con.OpenConection();
            try
            {
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("disp_emergency_services");
            //    string s = "select serv_code as 'كود الخدمة',serv_name as 'اسم الخدمة',serv_time as 'توقيت الخدمة' from emergency_emergency_services;";
            //    cmd1 = new MySqlCommand(s, con);
            //    dr = cmd1.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Code1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                peri = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
               // name = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                اضافة_خدمات_لمرضى_الطوارئ ff= new اضافة_خدمات_لمرضى_الطوارئ();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
