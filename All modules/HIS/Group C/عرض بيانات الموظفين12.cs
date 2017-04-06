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
    public partial class عرض_بيانات_الموظفين12 : Form
    {
        Connection con = new Connection();
        public عرض_بيانات_الموظفين12()
        {
            InitializeComponent();
        }

        private void Form34_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form34_se");
            //con.Open();
            //// TODO: This line of code loads data into the 'DataSet12.DataTable1' table. You can move, or remove it, as needed.
           
            ////cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            //cmd = new MySqlCommand("select career_name as 'الوظيفة' ,adm_name as 'الادارة',dep_name as 'القسم'  from employee,adminstration,department where emp_id=adminstration.employee_id and emp_id=department.employee_id", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


                // MessageBox.Show(c.ToString());
                حصر_بالماموريات ff = new حصر_بالماموريات(s, s2, s3);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
