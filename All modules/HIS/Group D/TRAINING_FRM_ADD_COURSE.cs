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
    public partial class TRAINING_FRM_ADD_COURSE : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        TRAINING_FRM_ADVERTISING own = null;
        Connection connect; ///M
        public TRAINING_FRM_ADD_COURSE()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (!Class1.chkEmpty(textBox3.Text) && !Class1.chkEmpty(textBox4.Text))
            {
                connect.OpenConection();
                string procName = "TRAINING_Insert_CourseList_TrainingCourseName";
                string[] paramNames = { " @cl_code", "@cl_name" };
                string[] paramValues = { textBox3.Text, textBox4.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                /*
                 * connect.ShowDataInGridViewUsingStoredProc(procName);
                 * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                 */
                connect.CloseConnection();
                if (con.State != ConnectionState.Closed)

                    MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (!Class1.chkNum(textBox4.Text))
            {
                MessageBox.Show("قم بادخال رقم");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkArabicName(textBox3.Text))
            {
                MessageBox.Show("قم بادخال الاسم بالعربى");
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string procName = "Traing_AddCourse1";
            string[] paramNames = { "@cl_name" };
            string[] paramValues = { textBox3.Text };
            SqlDbType[] paramType = { SqlDbType.VarChar };
            connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
            /*
             * connect.ShowDataInGridViewUsingStoredProc(procName);
             * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
             * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
             */
            connect.CloseConnection();
            MessageBox.Show("تم الحذف بنجاح");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
