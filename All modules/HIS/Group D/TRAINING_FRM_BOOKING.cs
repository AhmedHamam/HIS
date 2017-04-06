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
    public partial class TRAINING_FRM_BOOKING : Form
    {
        TRAINING_FRM_TRAINNER_NAME f1;
        TRAINING_FRM_JOBS f5;
        TRAINING_FRM_COURSES_NAME f7;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommandBuilder ba;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        Connection connect; ///M


        public TRAINING_FRM_BOOKING()
        {
            InitializeComponent();
            connect = new Connection(); ///M
        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox3.Text = x;
            textBox4.Text = y;

        }
        public void setvalue1(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox5.Text = x;
            textBox6.Text = y;

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            f1 = new TRAINING_FRM_TRAINNER_NAME();
            f1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f5 = new TRAINING_FRM_JOBS();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f7 = new TRAINING_FRM_COURSES_NAME();
            f7.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (!Class1.chkEmpty(textBox1.Text) && !Class1.chkEmpty(textBox5.Text))
            {


                connect.OpenConection();
                string procName = "Traing_insertBooking";
                string[] paramNames = { "@trainee_code", "@trainee_name", "@c_name" };
                string[] paramValues = { textBox2.Text, textBox1.Text, textBox6.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                /*
                 * connect.ShowDataInGridViewUsingStoredProc(procName);
                 * connect.ShowDataInGridViewUsingStoredProc(procName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(procName, paramNames, paramValues, paramType);
                 */
                connect.CloseConnection();


                MessageBox.Show("تم الحجز");
            }
            else
            {
                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!Class1.chkArabicName(textBox4.Text))
            {
                MessageBox.Show("قم بادخال الاسم بالعربى");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TRAINING_FRM_BOOKING_Load(object sender, EventArgs e)
        {
            connect.OpenConection();
        }
    }
}
