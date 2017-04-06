using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class مراجعة_الحضور_والغياب_للموظفين_لليوم_الحالي : Form
    {
        Connection con = new Connection();
      
        public مراجعة_الحضور_والغياب_للموظفين_لليوم_الحالي()
        {
            InitializeComponent();
        }
         public مراجعة_الحضور_والغياب_للموظفين_لليوم_الحالي(int d,string ss,string s33)
        {
            InitializeComponent();

            textBox3.Text = d.ToString();
            textBox1.Text = ss.ToString();
            textBox4.Text = s33.ToString();
            

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("قم بادخال رقم");
                textBox3.Text = null;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = new string[] { "@x"};
                string[] s2 = new string[] { textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_revision_attending_leaving_p1", s, s2, s3);
                //cmd = new MySqlCommand("reg_revision_attending_leaving_p1", con);
                //cmd.Parameters.AddWithValue("@x", textBox2.Text);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            try
            {
                string[] s = new string[] { "@x" };
                string[] s2 = new string[] { textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reg_revision_attending_leaving_p2", s, s2, s3);
               // cmd = new MySqlCommand("reg_revision_attending_leaving_p2", con);
               //// cmd = new MySqlCommand("select emp_id as 'رقم الموظف',name as'الاسم', no_rosacea  as'عدد الورديات' from employee as e,attending_leaving_rosacea as r ,register_attending_leaving as z  where e.emp_id=r.employee_id and  e.emp_id=z.employee_id  and register_attending !=@x", con);
               // cmd.Parameters.AddWithValue("@x", textBox2.Text);
               // MySqlDataReader dr2 = cmd.ExecuteReader();
               // DataTable dt2 = new DataTable();
               // dt2.Load(dr2);
               // dataGridView2.DataSource = dt2;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            textBox2.Text = d.ToString("dd-MM-yyyy"); 
            con.OpenConection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            عرض_بيانات_الموظفين9 d = new عرض_بيانات_الموظفين9();
            d.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            
        }
    }
}
