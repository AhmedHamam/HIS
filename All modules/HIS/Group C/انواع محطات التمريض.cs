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

    public partial class انواع_محطات_التمريض : Form
    {

        Connection con=new Connection();
        SqlCommand cmd;
      
        public انواع_محطات_التمريض()
        {
            InitializeComponent();
        }

        private void انواع_محطات_التمريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                cmd = new SqlCommand("select code ,description_in_arabic from entranceoffice_nursingstation", con.con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
              
            }con.CloseConnection();
        }  

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    } 
}
