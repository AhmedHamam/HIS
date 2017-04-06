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
    public partial class عرض_الطبيب_للغسيل : Form
    {
    //    SqlConnection con;
    //    SqlCommand cmd;
    //    SqlDataReader dr;
        Connection con=new Connection();
        تنفيذ_خطه_HIS y;
        public عرض_الطبيب_للغسيل(تنفيذ_خطه_HIS x)
        {
            InitializeComponent();
            this.y = x;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue1(row);
            this.Close();
        }

        private void عرض_الطبيب_للغسيل_Load_1(object sender, EventArgs e)
        {
           
           try
            {
            con.OpenConection();

            dataGridView1.DataSource = con.ShowDataInGridView("doctors_select");

            //con = new SqlConnection(@"Server=MYDOCUMENTS-PC;Database=FHIS;Integrated Security=true");
            //try
            //{
            //    con.Open();
            //    cmd = new SqlCommand("doctors_select", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();
            //    con.Close();

           }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
