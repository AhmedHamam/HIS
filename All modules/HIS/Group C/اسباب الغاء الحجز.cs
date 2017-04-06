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
    public partial class اسباب_الغاء_الحجز : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        public اسباب_الغاء_الحجز()
        {
            InitializeComponent();
        }

        private void اسباب_الغاء_الحجز_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                cmd = new SqlCommand("select cause_of_cancel as 'اسباب الغاء الحجز' ,notes as 'ملاحظـــــات' from entranceoffice_cancelreserve", con.con);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
