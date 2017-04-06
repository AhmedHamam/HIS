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
    public partial class عرض_بيانات_الموظفين4 : Form
    {
        Connection con = new Connection();

        public عرض_بيانات_الموظفين4()
        {
            InitializeComponent();
        }

        private void Form26_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form28_se");
            //cmd = new SqlCommand("select emp_id as 'كود الموظف',name as 'اسم الموظف',gender as 'النوع' ,career_state as 'حالة العمل', status as'حالة الموظف',career_name as 'الوظيفة',adm_code as 'كود الادارة',dep_code as 'كود القسم',qualification as 'المؤهل التعليمى'  from employee,adminstration,department where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id ", con);
           // cmd = new SqlCommand("select emp_id as 'كود الموظف',name as 'اسم الموظف',gender as 'النوع' ,career_state as 'حالة العمل', status as'حالة الموظف',career_name as 'الوظيفة',adm_code as 'كود الادارة',dep_code as 'كود القسم',qualification as 'المؤهل التعليمى'  from employee,adminstration,department where employee.emp_id=department.employee_id and employee.emp_id=adminstration.employee_id ", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void f(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s5 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                String s6 = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                String s7 = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                String s8= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                String s9 = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
               
                اذونات_خروج_موظف ff = new اذونات_خروج_موظف(s2,s3,s4,s5,s6,s7,s8,s9);
                ff.Show();
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
    }
}
