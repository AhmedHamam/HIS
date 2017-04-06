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
    public partial class employees : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public employees()
        {
            InitializeComponent();
        }
        public void showdi(ref string code, ref string name)
        {
            this.ShowDialog();
            if (str1 != "" && str2 != "")
            {
                code = str1;
                name = str2;
            }
        }
        string str1 = "";
        string str2 = "";

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            str1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            str2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Close();

        }

        private void employees_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select emp_id,name from employee", con.con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con.CloseConnection();
        }
       
    }
}
