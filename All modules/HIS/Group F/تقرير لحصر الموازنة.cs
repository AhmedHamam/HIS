using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class تقريرلحصرالموازن : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        public تقريرلحصرالموازن()
        {
            InitializeComponent();
        }



        private void show_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            cmd = new SqlCommand("show_budget", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("month", comboMonth.Text);
            cmd.Parameters.AddWithValue("year", comboYear.Text);
           // cmd = new MySqlCommand("select serial_num as 'رقم المسلسل' ,expense as 'المنصرف من الاعتماد' ,credit_value as 'قيمة الاعتماد',particular_authorityFrom as 'الجهة المختصة : من',particular_authorityTo as'الى',item_id as 'رقم البند',it_name as 'اسم البند',doc_entryDate as 'تاريخ دخول المستند'  from book_budget where MONTH(doc_entryDate)='" + comboMonth.Text + "'  and YEAR(doc_entryDate)='" + comboYear.Text+ "' order by DAY(doc_entryDate);", con);
            try
            {
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            con.CloseConnection();
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("show_Allbudget", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd = new MySqlCommand("select serial_num as 'رقم المسلسل' ,expense as 'المنصرف من الاعتماد' ,credit_value as 'قيمة الاعتماد',particular_authorityFrom as 'الجهة المختصة: من',particular_authorityTo as 'الى',item_id as 'رقم البند',it_name as 'اسم البند',doc_entryDate as 'تاريخ دخول المستند'  from book_budget order by DAY(doc_entryDate);", con);
            try
            {
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            con.CloseConnection();
        }

       


  
    }
}
