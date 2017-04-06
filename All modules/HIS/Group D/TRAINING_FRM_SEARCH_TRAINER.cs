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
    public partial class TRAINING_FRM_SEARCH_TRAINER : Form
    {
       
        string s;
        public TRAINING_FRM_COURSES_NAME tr;

        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd;
        public SqlDataReader dr;
        DataTable dt = new DataTable();
        Connection connect;
        public TRAINING_FRM_SEARCH_TRAINER()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tr = new TRAINING_FRM_COURSES_NAME();
            tr.Show();
        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox6.Text = x;
            textBox5.Text = y;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                textBox5.Text = " ";

                cmd = new SqlCommand("select trainee_name  as 'اسم الموظف المتدرب' from booking,course where booking.trainee_code=course.training_code  and course_code ='" + textBox6.Text + "'", con);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

    }
}
