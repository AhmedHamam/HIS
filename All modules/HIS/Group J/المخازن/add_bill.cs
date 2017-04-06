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
    public partial class add_bill : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");
        public add_bill()
        {

            InitializeComponent();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            
           
        
            /*
             create table Inventory_bill(
                                bill_id int primary key,
                                dismisalpermition varchar(250),
                                importDuration varchar(250),
                                totalCost float,
                                sendingAuthority varchar(250),
                                Date date,
                                employee_id int foreign key references employee(employee_id) on update cascade on delete cascade
                                )
             */
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Inventory_bill (importDuration,totalCost,sendingAuthority,date,emp_id) values ('" + import_duration.Text + "','" + total_cost.Text + "','" + sendingAuthority.Text + "','" + Date.Value.Date.ToString("yyyy-MM-dd") + "','" + employee_id.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("yes");
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void add_bill_Load(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=Inventories; Integrated Security=true");
           

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select bill_id as 'رقم الفاتورة',importDuration as 'مدة التوريد',totalCost as 'التكلفة الكلية',sendingAuthority as 'طلبات المراسلة',date as 'تاريخ الفاتورة',emp_id as 'كود الموظف المختص' from Inventory_bill", con);
                SqlDataReader dr;
                DataTable dt = new DataTable();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                con.Close();
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            category a = new category();
            a.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //.inventory_employee a = new المخازن.inventory_employee();
           // a.Show();
        }
    }
}
