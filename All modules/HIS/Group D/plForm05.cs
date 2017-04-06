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
    public partial class plForm05 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
       
        public plForm006 f4;

        public plForm05()
        {
            InitializeComponent();
        }
        private void plForm05_Load(object sender, EventArgs e)
        {
           
        }


        public void setval(string x)
        {

            

        }

        public void setvalue(string x)
        {

            textBox2.Text = x;

        }
        private void btn_spicialization_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f4= new plForm006(this);
            f4.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
           
            cmd.CommandText = "select p_code as 'الكود' ,describ as 'الوصف ' ,year as 'السنه ' ,profession_job as 'وصف التخطيط ' ,p_state as 'حاله التخطيط ' ,date as 'التاريخ' ,employee_state as 'حاله الموظف' ,p_kind as 'حاله التخطيط' ,j_code as 'كود الموظف' from p_profession where j_code like'" + textBox2.Text + "%'" ;
            try
            {
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("enter the code to search ");
            }
            con.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
           
            dataGridView1.DataSource = null;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_detailed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

