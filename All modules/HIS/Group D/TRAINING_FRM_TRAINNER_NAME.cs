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
    public partial class TRAINING_FRM_TRAINNER_NAME : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
       TRAINING_FRM_ADVERTISING own = null;
        Connection connect; ///M
        public TRAINING_FRM_TRAINNER_NAME()
        {
             InitializeComponent();
            connect = new Connection(); 
        }

        public TRAINING_FRM_TRAINNER_NAME(TRAINING_FRM_ADVERTISING own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection(); ///M
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

            this.own.setvalue2(x, y);
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


            if (!Class1.chkArabicName(textBox6.Text))
            {
                MessageBox.Show("قم بادخال الاسم بالعربى");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string procName = "Traing_TrainerName";
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

        private void label4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
