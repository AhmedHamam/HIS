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
    public partial class عرض_بيانات_الموظفين_3 : Form
    {
        Connection con = new Connection();
        public عرض_بيانات_الموظفين_3()
        {
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            //cmd = new MySqlCommand("select _idee.emp_id=v.employee_id and employee.emp_id=p.employee_id and employee.emp_id=r.employee_id and employee.emp_id='" + textBox3.Text + "' and  register_attending= '" + dateTimePicker2.Value.ToShortDateString() + "' ", con);
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("form_26");
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        }
    }

