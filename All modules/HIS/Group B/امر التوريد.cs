﻿using System;
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
    public partial class امرالتوريد : Form
    {
        Connection con = new Connection();
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        اضافةعروضاسعار c;
        public امرالتوريد()
        {
            InitializeComponent();
        }
         public امرالتوريد (اضافةعروضاسعار f3)
        {
            InitializeComponent();
             c=f3;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setV(row.Cells[0].Value.ToString());
            this.Close();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showcommandsupplay");
            con.CloseConnection();
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //da = new SqlDataAdapter("select * from command_supply", @"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
