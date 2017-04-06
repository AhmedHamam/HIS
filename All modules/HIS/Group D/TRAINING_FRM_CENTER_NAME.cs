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
    public partial class TRAINING_FRM_CENTER_NAME : Form
    {
        Connection connect;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        TRAINING_FRM_ADVERTISING own = null;

        public TRAINING_FRM_CENTER_NAME()
        {
            InitializeComponent();
            connect = new Connection();
        }

        public TRAINING_FRM_CENTER_NAME(TRAINING_FRM_ADVERTISING own)
        {
             InitializeComponent();
            this.own = own;
            connect = new Connection();
        }

        private void TRAINING_FRM_CENTER_NAME_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //con.Open();
            connect.OpenConection();
            cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from training_center";
            try
            {

                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            this.own.setvalue(x, y);
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            e.RowIndex.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            connect.OpenConection();
            cmd = new SqlCommand();

            cmd.CommandText = "select * from training_center where center_name like '" + textBox6.Text + "%'";
            try
            {

                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            connect.CloseConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
