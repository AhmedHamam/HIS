using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class plForm06 : Form
    {
        
        SqlCommand cmd;
        SqlDataReader dr;
        Connection connect;
        DataTable dt = new DataTable();

        public plForm006 f6;
        public plForm06()
        {

            InitializeComponent();
            connect = new Connection();
        }

        private void plForm06_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f6 = new plForm006(this);
            f6.Show();

        }
        public void setvalue(string x, string y)
        {
            Console.WriteLine(x + " " + y);
            textBox2.Text = x;
            textBox1.Text = y;





        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {


            
            try
            {

                connect.OpenConection();
                string pName = "planing_job_name";

                string[] paramNames = { "@j_code" };
                string[] paramValues = { textBox2.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };

                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

            }
            catch (Exception)
            {
                MessageBox.Show("قم بادخال الكود للبحث ");
            }
            connect.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

