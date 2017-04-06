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
    public partial class TRAINING_FRM_COURSES_ADVERTISING : Form
    {
        TRAINING_FRM_JOBS f1;

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds;
        Connection connect; ///M
        public TRAINING_FRM_COURSES_ADVERTISING()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1 = new TRAINING_FRM_JOBS();
            f1.Show();
        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox5.Text = x;
            textBox6.Text = y;

        }

        private void TRAINING_FRM_COURSES_ADVERTISING_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"Server=DESKTOP-FNSTU7T; Database=PHIS; Integrated Security=true");
            //con.Open();
            connect.OpenConection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string procName = "Traing_TrainingCourseForJobs";
            string[] paramNames = { "@career_name" };
            string[] paramValues = { textBox6.Text };
            SqlDbType[] paramType = { SqlDbType.VarChar };
            dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
            /*
             * connect.ShowDataInGridViewUsingStoredProc(procName);
             * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
             * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
             */
            connect.CloseConnection();
        }
    }
}
