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
    public partial class مصادر_الحجز : Form
    {

        Connection con = new Connection();
        SqlCommand cmd;
        public مصادر_الحجز()
        {
            InitializeComponent();
        }

        private void lineShape6_Click(object sender, EventArgs e)
        {

        }

        private void lineShape5_Click(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                cmd = new SqlCommand("select code as 'كود_مصدر_الحجز' ,name_in_arabic as 'اسم مصدر الحجز' from entranceoffice_sourceofreservation", con.con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            } con.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
