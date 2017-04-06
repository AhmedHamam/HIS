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
    public partial class عرض_بيانات_الموظفين19 : Form
    {
        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        Connection con = new Connection();
        public عرض_بيانات_الموظفين19()
        {
            InitializeComponent();
        }
         

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            
        }

        private void Form47_Load(object sender, EventArgs e)
        {
            con.OpenConection();
           dataGridView1.DataSource=(DataTable)con.ShowDataInGridViewUsingStoredProc("form47_se");
            ////cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            //cmd = new SqlCommand("form47_se", con);
           
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String s2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               
                int c = int.Parse(s);

                // MessageBox.Show(c.ToString());
                تسجيل_حضور ff = new تسجيل_حضور(c, s2);
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
