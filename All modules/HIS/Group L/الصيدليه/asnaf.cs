using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using HIS;
namespace HIS
{
    public partial class asnaf : Form
    {
        public asnaf()
        {
            InitializeComponent();
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^[0-9]");

            if (r.Match(textBox1.Text).Success == true)
            {

                //  DateTime date;
                //date = dateTimePicker1.Value;
                Connection conn = new Connection();
                conn.OpenConection();
                string ss = textBox1.Text;
                dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_select_asnaf", new string[] { "@quantity" }, new string[] { ss }, new SqlDbType[] { SqlDbType.Int });

            }
        }
                
        private void asnaf_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
