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
    public partial class plForm03 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlCommandBuilder ba;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        Connection connect;
        public plForm03()
        {
            InitializeComponent();
            connect = new Connection(); //
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Class1.chkNum(textBox1.Text))
            {

                connect.OpenConection();
                string[] paramNames = { "@emp_id" };
                string[] paramValues = { textBox1.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("planing_detalisOfJobName1", paramNames, paramValues, paramType);

               
            }
            else
                MessageBox.Show("قم بادخال الكود كرقم ");

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }
    
        private void plForm03_Load(object sender, EventArgs e)
        {
           

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }
        //select  prof_code,describ from professio
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
