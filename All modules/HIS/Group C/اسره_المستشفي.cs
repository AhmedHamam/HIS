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
    public partial class اسره_المستشفي : Form
    {
        Connection con = new Connection();
        SqlCommand cmd=new SqlCommand();
        DataSet ds;
        BindingSource bs;
        DataTable dt;
        int count;

        public اسره_المستشفي()
        {
            InitializeComponent();
        }

        private void اسره_المستشفي_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                cmd = new SqlCommand("select number_of_bed ,type_of_bed,being_in,name_of_bed from entranceoffice_bed", con.con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            } catch(Exception t)
            { MessageBox.Show("" + t.Message); }
            con.CloseConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();

        }
    }
}
