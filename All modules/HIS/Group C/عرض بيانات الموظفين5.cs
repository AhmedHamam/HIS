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
    public partial class عرض_بيانات_الموظفين5 : Form
    {
        Connection con = new Connection();
        public عرض_بيانات_الموظفين5()
        {
            InitializeComponent();
        }

        private void Form27_Load(object sender, EventArgs e)
        {
         
            con.OpenConection();
            //cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form27_se ");

          
           

        }

        private void fun(object sender, DataGridViewCellEventArgs e)
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

                String s8 = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                String s9 = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                ماموريات_موظف ff = new ماموريات_موظف(s2, s3, s4, s5, s6, s7, s8, s9);
                ff.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
