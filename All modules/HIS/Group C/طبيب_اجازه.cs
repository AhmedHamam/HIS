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
    public partial class طبيب_اجازه : Form
    {


        public static string Code1 { get; set; }
        public static string Code2 { get; set; }

        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand();
        public طبيب_اجازه()
        {
            InitializeComponent();
        }

        private void طبيب_اجازه_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("doc");
            con.CloseConnection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                رجوع_مريض_من_اجازه ff = new رجوع_مريض_من_اجازه();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }
    }
}
