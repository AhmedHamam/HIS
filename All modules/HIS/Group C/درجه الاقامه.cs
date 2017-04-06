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
    public partial class درجه_الاقامه : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        BindingSource bs;
        DataTable dt;
        int count;
        public درجه_الاقامه()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void درجه_الاقامه_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            cmd = new SqlCommand("select degree_of_establishment from entranceoffice_bed", con);
            con.Open();
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con.Close();
        }
    }
}
