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
    public partial class effective_subject : Form
    {
        public effective_subject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pharmacy_select_medecine_effectiveSubject
            Connection conn = new Connection();
            conn.OpenConection();
            //    string ss = textBox1.Text;

            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharmacy_select_medecine_effectiveSubject");

            }

        private void effective_subject_Load(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
