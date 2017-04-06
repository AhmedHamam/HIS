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
    public partial class عرض_بيانات_الموظفين13 : Form
    {
    Connection con=new Connection();

        //MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
        //MySqlCommand cmd;
        public عرض_بيانات_الموظفين13()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s22 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                int c = int.Parse(s);

                // MessageBox.Show(c.ToString());
                حصر_تاخير_واضافي_وخروج_مبكر_للموظفين ff = new حصر_تاخير_واضافي_وخروج_مبكر_للموظفين(c, s2, s3);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }

        private void Form35_Load_1(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form23_se");
        //    con.Open();
        //    //cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
        //    cmd = new MySqlCommand("select emp_id as 'كود الموظف',name as 'اسم الموظف',adm_name as 'الادارة',dep_name as 'القسم'  from employee,adminstration,department where emp_id=adminstration.employee_id and emp_id=department.employee_id", con);
        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
        //    dataGridView1.DataSource = dt;
        //    dr.Close();
        //    con.Close();
        }
    }
}
