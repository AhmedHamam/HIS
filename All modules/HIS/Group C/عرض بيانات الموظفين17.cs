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
    public partial class عرض_بيانات_الموظفين17 : Form
    {
        Connection con = new Connection();
        //MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
        //MySqlCommand cmd;
        public عرض_بيانات_الموظفين17()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s5 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String s6 = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                String s7 = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();



                // MessageBox.Show(c.ToString());
                كشف_بعدد_الورديات_التي_حضرها_الموظف ff  = new كشف_بعدد_الورديات_التي_حضرها_الموظف(s2, s3, s4, s5,s6,s7);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }

        private void Form42_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form42_se");
            //con.Open();
            ////cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            //cmd = new MySqlCommand("select emp_id as 'كود الموظف' ,name as 'اسم الموظف' ,adm_name as 'الادارة',status as 'حالة الموظف' ,career_name as 'الوظيفة',time_rosacea as 'وقت الوردية',dep_name as 'القسم' from employee,department ,adminstration,attending_leaving_rosacea as rr where emp_id=adminstration.employee_id and emp_id=rr.employee_id and emp_id=department.employee_id", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
        }
    }
}
