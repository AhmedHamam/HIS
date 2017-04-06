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
    public partial class plForm006 : Form
    {
        
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        plForm06 ownerForm = null;
        plForm05 ownerForm1 = null;
        Connection connect;

        public plForm006()
        {
            InitializeComponent();
            connect = new Connection();
        }
        public plForm006(plForm06 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            connect = new Connection();
            
        }
        public plForm006(plForm05 ownerForm)
        {
            InitializeComponent();
            this.ownerForm1 = ownerForm;
            connect = new Connection();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         

        private void plForm006_Load(object sender, EventArgs e)
        {

            connect.OpenConection();
            
          
            try
            {
            

                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("planing_job1");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            connect.OpenConection();
            if (Class1.chkNum(textBox2.Text))
            {
                connect.OpenConection();
                
                try
                {
                    string pName = "planing_job2";
                    string[] paramNames = { "@emp_id" };
                    string[] paramValues = { textBox2.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
                MessageBox.Show("قم بادخال الكود كرقم ");
            connect.CloseConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (Class1.chkName(textBox1.Text))
            {
                connect.OpenConection();
                try
                {
                    string pName = "planing_job3";
                    string[] paramNames = { "@career_name" };
                    string[] paramValues = { textBox1.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
                MessageBox.Show("قم بادخال الوظيفه بالعربي");
            connect.CloseConnection();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            e.RowIndex.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (ownerForm != null)
                {
                    this.ownerForm.setvalue(x, y);
                }
                else
                {
                    this.ownerForm1.setvalue(x);
                }


                this.Close();
            }
            catch (Exception ee)
            {

                MessageBox.Show("الصف غير صحيح");
                MessageBox.Show(ee.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}


