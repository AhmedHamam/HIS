using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class opForm20 : Form
    {
       
        SqlConnection con;
        SqlCommand cmd;
        Connection connect;
        public opForm20()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void opForm20_Load(object sender, EventArgs e)
        {/*
            con = new SqlConnection(@"Server=DESKTOP-LSC6L8E\SQLEXPRESS; Database=phis; Integrated Security=true");
            if (con.State!=ConnectionState.Open)con.Open();
            cmd = new SqlCommand("select * from employee ; ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            if(con.State!=ConnectionState.Closed)con.Close();
           */

            connect.OpenConection();
            dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("mediacal_team1");


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
