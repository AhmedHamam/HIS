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
    public partial class TRAINING_FRM_CLOSING_TRAIN : Form
    {
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd;
        public SqlDataReader dr;
        DataTable dt = new DataTable();
        Connection connect; ///M
        public TRAINING_FRM_COURSES_NAME f1;
        public TRAINING_FRM_CLOSING_TRAIN()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1 = new TRAINING_FRM_COURSES_NAME();
            f1.Show();
        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox4.Text = x;
            textBox3.Text = y;



        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (!Class1.chkEmpty(textBox4.Text))
            {
                connect.OpenConection();
                string procName = "Traing_CloseCourse";
                string[] paramNames = { "@course_code" };
                string[] paramValues = { textBox4.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                /*
                 * connect.ShowDataInGridViewUsingStoredProc(procName);
                 * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                 */
                connect.CloseConnection();

                MessageBox.Show("تم حذف الدورة ");
            }
            else
            {
                MessageBox.Show("ادخل البيانات كاملة");
            }
            
        }

        private void TRAINING_FRM_CLOSING_TRAIN_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"Server=DESKTOP-FNSTU7T; Database=PHIS; Integrated Security=true");
            //con.Open();
            connect.OpenConection();
        }
    }
}
