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
    public partial class عرض_الادارة : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        Connection con = new Connection();
        اضافة_مكافحة_عدوى_موظفين y;
        public عرض_الادارة()
        {
            InitializeComponent();
        }
        public عرض_الادارة(اضافة_مكافحة_عدوى_موظفين x)
        {
            InitializeComponent();
            y = x;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void عرض_الادارة_Load(object sender, EventArgs e)
        {

            try
            {

                con.OpenConection();

                con.DataReader("infection_adminstration_Display");
                dataGridView1.DataSource = con.ShowDataInGridView("infection_adminstration_Display");
                con.CloseConnection();
               
                //con.Open();
                //cmd = new SqlCommand("select * from  administration;", con);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                //dr.Close();
                //con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.Sett(row);

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
