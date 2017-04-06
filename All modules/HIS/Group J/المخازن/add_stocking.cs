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
    public partial class add_stocking : Form
    {
        Connection conn = new Connection();
        public add_stocking()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
 
            string[] a = { "@ES_date", "@inventoryName", "@type", "@result", "@emp_id" };
            SqlDbType[] b = { SqlDbType.Date, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };
            string[] c = { ES_date.Text, inventoryName.Text, "stocking", result.Text, employee_id.Text };
            conn.OpenConection();
            conn.ShowDataInGridViewUsingStoredProc("stocking_add", a, c, b);
            conn.CloseConnection();
            string[] aa = {"@stoking" };
            SqlDbType[] bb = {SqlDbType.VarChar};
            string[] cc = {"stocking"};
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("stocking_show",aa,cc,bb);
            conn.CloseConnection();
            /*

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            /*create table Inventory_examinationAndStocking(
                                  ES_id int primary key,
                                  ES_date date,
                                  inventoryName varchar(250),
                                  type varchar(250),
                                  result text,
                                  employee_id int foreign key references employee(employee_id) on update cascade on delete cascade
                                  ) */
                     
            //try
            //{

            //    con.Open();
            //    SqlCommand cmd2 = new SqlCommand("select inventoryName from Inventory_examinationAndStocking", con);
            //    SqlDataReader da;
            //    DataTable dt = new DataTable();
            //    da = cmd2.ExecuteReader();
            //    dt.Load(da);
            //    dataGridView1.DataSource = dt;
            //    da.Close();



            //}
            //catch (Exception exe) { MessageBox.Show(exe.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //المخازن.inventory_employee ee = new المخازن.inventory_employee();
            string code = this.employee_id.Text;
          
        
           // ee.showdi(ref code);
            

           this.employee_id.Text = code;
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_inventory a = new add_inventory();
            string name = inventoryName.Text;
            a.showdi(ref name);
            inventoryName.Text = name;

        }

        private void add_stocking_Load(object sender, EventArgs e)
        {
            string[] aa = { "@stoking" };
            SqlDbType[] bb = { SqlDbType.VarChar };
            string[] cc = { "stocking" };
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("stocking_show", aa, cc, bb);
            conn.CloseConnection();
        }
    }
}
