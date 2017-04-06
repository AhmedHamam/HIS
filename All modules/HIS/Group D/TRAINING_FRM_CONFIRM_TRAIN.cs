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
    public partial class TRAINING_FRM_CONFIRM_TRAIN : Form
    {
        public TRAINING_FRM_COURSES_NAME f9;
        public TRAINING_FRM_COURSES_NAME tr;
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd;
        public SqlDataReader dr;
        DataTable dt = new DataTable();
        Connection connect; ///M
       
        public TRAINING_FRM_CONFIRM_TRAIN()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }
        


        private void label2_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string procName = "Traing_SureStartTrainingCourse";
            string[] paramNames = { "@course_code " };
            string[] paramValues = { textBox6.Text };
            SqlDbType[] paramType = { SqlDbType.VarChar };
            connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
            /*
             * connect.ShowDataInGridViewUsingStoredProc(procName);
             * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
             * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
             */
            connect.CloseConnection();
            if (!Class1.chkEmpty(textBox6.Text) && !Class1.chkEmpty(textBox5.Text))
            {
                MessageBox.Show("تم تاكيد الدورة ");


            }
            else
            {
                MessageBox.Show("ادخل البيانات كاملة");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f9 = new TRAINING_FRM_COURSES_NAME();
            f9.Show();
        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox6.Text = x;
            textBox5.Text = y;

        }

        private void TRAINING_FRM_CONFIRM_TRAIN_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"Server=DESKTOP-FNSTU7T; Database=PHIS; Integrated Security=true");
            //con.Open();
            connect.OpenConection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox6.Text = " ";
            textBox2.Text = " ";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox2.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkNum(textBox1.Text))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox1.Text = "";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
