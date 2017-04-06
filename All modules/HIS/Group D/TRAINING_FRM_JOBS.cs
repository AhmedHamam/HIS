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
    public partial class TRAINING_FRM_JOBS : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds;
        TRAINING_FRM_COURSES_ADVERTISING own = null;
        Connection connect; ///M
        public TRAINING_FRM_JOBS()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }
        public TRAINING_FRM_JOBS(TRAINING_FRM_COURSES_ADVERTISING own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection(); ///M
        }


        private void TRAINING_FRM_JOBS_Load(object sender, EventArgs e)
        {
            connect.OpenConection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string procName = "Traing_Jobs";
            string[] paramNames = { };
            string[] paramValues = { };
            SqlDbType[] paramType = { };
            dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(procName);
            /*
             * connect.ShowDataInGridViewUsingStoredProc(procName);
             * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
             * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
             */
            connect.CloseConnection();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            e.RowIndex.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            this.own.setvalue(x, y);
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
