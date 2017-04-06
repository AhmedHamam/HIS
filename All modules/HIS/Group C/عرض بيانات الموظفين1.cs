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
    public partial class عرض_بيانات_الموظفين1 : Form
    {
        Connection con = new Connection();
        int c;
        string d;
        public عرض_بيانات_الموظفين1()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form23_se");
         //   con.Open();
         //   //cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
         //   cmd = new SqlCommand("form23_se", con);
         //   cmd.CommandType = CommandType.StoredProcedure;
         //SqlDataReader dr = cmd.ExecuteReader();
         //   DataTable dt = new DataTable();
         //   dt.Load(dr);
         //   dataGridView1.DataSource = dt;
         //   dr.Close();
         //   con.Close();
        }

        private void asd(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s22 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String s3 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String s4 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                c= int.Parse(s);
               // MessageBox.Show(c.ToString());
                بيان_بحضور_الموظف_شهريا ff = new بيان_بحضور_الموظف_شهريا(c,s2,s3,s4);
                ff.Show();
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

    
    }
}
