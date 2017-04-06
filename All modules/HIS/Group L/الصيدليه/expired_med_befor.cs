using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HIS;

namespace HIS
{
    public partial class expired_med_befor : Form
    {
        public expired_med_befor()
        {
            InitializeComponent();
        }


        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime date;
              date = dateTimePicker1.Value;
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_expired_med_befor" , new string[] {"@date"}, new string[] { date.ToString()},new SqlDbType  [] {SqlDbType.DateTime});  
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}