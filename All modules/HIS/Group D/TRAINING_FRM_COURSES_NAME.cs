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
    public partial class TRAINING_FRM_COURSES_NAME : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommandBuilder ba;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        TRAINING_FRM_ADVERTISING own = null;
        Connection connect;
        TRAINING_FRM_ADD_COURSE ff;
        public TRAINING_FRM_COURSES_NAME()
        {
            connect = new Connection();
            InitializeComponent();
        }


        public TRAINING_FRM_COURSES_NAME(TRAINING_FRM_ADVERTISING own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection();
        }
        private void TRAINING_FRM_COURSES_NAME_Load(object sender, EventArgs e)
        {
            
        }
        private void label3_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
                     
            string procName = "TRAINING_COURSE_NAMETRAININGCOURSE";
            string[] paramNames = { };//"@cl_name" };
            string[] paramValues = { };//textBox2.Text };
            SqlDbType[] paramType = { };//SqlDbType.VarChar };
            dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(procName);
            /*
             * connect.ShowDataInGridViewUsingStoredProc(procName);
             * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
             * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
             */
            connect.CloseConnection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


            
            if (!Class1.chkArabicName(textBox3.Text))
            {
                MessageBox.Show("قم بادخال الاسم بالعربى");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            this.own.setvalue1(x, y);
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            e.RowIndex.ToString();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ff = new TRAINING_FRM_ADD_COURSE();
            ff.Show();
        }

    }
}
