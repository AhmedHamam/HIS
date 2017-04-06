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
    public partial class empevalshow : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public empevalshow()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("emp_evaluation", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("code",Int32.Parse(textBox1.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;
            string name = this.textBox2.Text;
            employees frm = new employees();
            frm.showdi(ref code, ref name);
            this.textBox2.Text = name;
            this.textBox1.Text = code;
        }
    }
}
