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
    public partial class opForm0002 : Form
    {
        public opForm02 own2 = null;
       
        
        Connection connect;
        public opForm0002()
        {
            InitializeComponent();
            connect = new Connection();
        }

        public opForm0002(opForm02 own)
        {
            InitializeComponent();
            this.own2 = own;
            connect = new Connection();
        }


        private void opForm0002_Load(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();

                string pName = "op_doctor_search1";
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                string pName = "op_doctor_search2";
                string[] paramNames = { "@full_name" };
                string[] paramValues = { textBox2.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                // cmd = new SqlCommand("select doc_ssn as 'الكود' , full_name as 'اسم الدكتور' from doctors where full_name ='" + textBox2.Text + "'", con);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                string x = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                string y = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

                this.own2.setvalue1(x, y);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                e.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                string pName = "op_doctor_search3";
                string[] paramNames = { "@full_name" };
                string[] paramValues = { textBox2.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                //
               // cmd = new SqlCommand("select doc_ssn as 'الكود' , full_name as 'اسم الدكتور' from doctors where full_name like'" + textBox2.Text + "%'", con);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                string pName = "op_doctor_search1";
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
