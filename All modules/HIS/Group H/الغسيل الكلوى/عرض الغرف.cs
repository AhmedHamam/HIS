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
    public partial class عرض_الغرف : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        Connection con = new Connection();
        تنفيذ_خطه_HIS y;
        public عرض_الغرف(تنفيذ_خطه_HIS x)
        {
            InitializeComponent();
            this.y = x;
        }

        private void عرض_الغرف_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"Server=MYDOCUMENTS-PC;Database=FHIS;Integrated Security=true");
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Room_selects");

                //con.Open();
                //cmd = new SqlCommand("Room_select", con);
                //cmd.CommandType = CommandType.StoredProcedure;
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
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue2(row);
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
