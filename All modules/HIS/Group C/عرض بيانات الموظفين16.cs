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
    public partial class عرض_بيانات_الموظفين16 : Form
    {
        Connection con = new Connection();
        public عرض_بيانات_الموظفين16()
        {
            InitializeComponent();
        }

        private void Form41_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form23_se");
            
            ////cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            //cmd = new MySqlCommand("select emp_id as'كود الموظف' ,name as'اسم الموظف',adm_name as 'الادارة',dep_name as 'القسم',career_name as 'الوظيفة' from employee,adminstration,department where emp_id=adminstration.employee_id and emp_id=department.employee_id", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s5 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
               
               

                // MessageBox.Show(c.ToString());
                تقرير_بطرق_الحضور_خلال_فترة ff = new تقرير_بطرق_الحضور_خلال_فترة( s2, s3, s4, s5);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }
    }
}
