using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using TestHIS;
using HIS;

namespace HIS
{
      
    public partial class تعديل_تاريخ_الصلاحيه_لصنف : Form
    

    {
        string med_id = "";
     
        public تعديل_تاريخ_الصلاحيه_لصنف()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
              Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_select_all_medecine");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
            if (med_id != "")
            {
                Connection conn = new Connection();
                conn.OpenConection();
                conn.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharamacy_update_expireDate", new string[] { "@med_id", "@e_date" }, new string[] { med_id, date.ToString() }, new SqlDbType[] { SqlDbType.Int, SqlDbType.Date });
                MessageBox.Show("لقد تمت عمليه تحديث تاريخ الصلاحيه بنجاح");
            }





            else MessageBox.Show("من فضلك اختر طلب علي الاقل ليتم التعديل عليه");
        }
        private void تعديل_تاريخ_الصلاحيه_لصنف_Load(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
//public  string med_id { get; set; }
    }
}
