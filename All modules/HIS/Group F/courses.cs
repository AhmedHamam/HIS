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
    public partial class courses : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public courses()
        {
            InitializeComponent();
        }
        public void showdi(ref string name)
        {
            this.ShowDialog();
            if (str2 != "")
            {
                
                name = str2;
            }
        }
        string str2 = "";

        private void courses_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select name from training_course", con.con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con.CloseConnection();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            str2 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }
    }
}
