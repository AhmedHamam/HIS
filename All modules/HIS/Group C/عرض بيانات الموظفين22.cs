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
    public partial class عرض_بيانات_الموظفين22 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=HANADYKHALIFA; DataBase=PHIS; Integrated Security=true;");
        //SqlCommand cmd;
        public عرض_بيانات_الموظفين22()
        {
            InitializeComponent();
        }

        private void Form50_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form47_se");
            //cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            //cmd = new SqlCommand("form47_se", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader dr = cmd.ExecuteReader();
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
                String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


                int c = int.Parse(s);

                // MessageBox.Show(c.ToString());
                تسجيل_ماموريات_موظف ff = new تسجيل_ماموريات_موظف(c);
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
