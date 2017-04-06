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
    public partial class For13 : Form
    {

        Connection con = new Connection();
        For12 c;
        public For13()
        {
            InitializeComponent();
        }
          public For13(For12 f6)
        {
            InitializeComponent();
            c= f6;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            try{
                con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showsupplier");
              
            //SqlCommand cmd = new SqlCommand("showsupplier", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da = new SqlDataAdapter(cmd);
            //    SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //    ds = new DataSet();
            //    da.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
                //cmd = new SqlCommand("select supplier_id as 'كود المورد ',supplier_name as 'اسم المورد',supplier_activity as'نشاط المورد' ,supplier_address as'عنوان المورد',tax_number as 'الرقم الضريبى',account_number as'رقم الحساب',tax_card as'البطاقه الضريبيه',commmerical_record as'السجل التجارى',contracting_type as'نوع التعاقد',bank_name as'اسم البنك',branch  as'الفرع',responsablities_names as'اسم المسؤل',paymeny_method  as'طريقه الدفع',fax as'الفاكس',email as'الايميل',deal_date as 'تاريخ التعامل' from suppliers;", con);
                //DataTable dt = new DataTable();
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setV(row.Cells[0].Value.ToString());
            this.Close();
        }

      
    }
}
