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
    public partial class تقريرلحصرالمستندات : Form
    {
      Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        public تقريرلحصرالمستندات()
        {
            InitializeComponent();
        }

      

        private void show_Click(object sender, EventArgs e)
        {
          
            con.OpenConection();
            cmd = new SqlCommand("show_document", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("month",comboMonth.Text);
            cmd.Parameters.AddWithValue("year", comboYear.Text);

           // cmd = new MySqlCommand("select doc_id as 'رقم المستند' ,doc_date as 'تاريخ المستند' ,doc_name as 'اسم صاحب المستند',money_needed as'المبلغ المراد سحبه',particular_authorityFrom as 'الجهة المختصةمن',particular_authorityTo as'الى',item_id as 'رقم البند'  from document_release where MONTH(doc_date)='" + comboMonth.Text + "' and YEAR(doc_date)='" + comboYear.Text + "' order by DAY(doc_date);", con);
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
           cmd = new SqlCommand("show_Alldocument", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd = new MySqlCommand("select doc_id as 'رقم المستند' ,doc_date as 'تاريخ المستند' ,doc_name as 'اسم صاحب المستند',money_needed as'المبلغ المراد سحبه',particular_authorityFrom as 'الجهة المختصة :من',particular_authorityTo as 'الى',item_id as 'رقم البند'  from document_release order by DAY(doc_date);", con);
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
