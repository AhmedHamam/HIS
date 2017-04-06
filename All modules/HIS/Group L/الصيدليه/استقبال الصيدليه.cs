using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HIS;
namespace HIS

{
  
     
    public partial class استقبال_الصيدليه : Form
    {
    
        
       int inventry_id ;
        
        public استقبال_الصيدليه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
              {
             Connection con =new Connection ();
            con.OpenConection();
            if (con.DataReader("pharmacy_select_patientDescription").HasRows)
            {
                con.ShowDataInGridViewUsingStoredProc("pharmacy_select_patientDescription");
            }
            else
                MessageBox.Show("لا يوجد مرضى.....");
        
                //cmd = new SqlCommand("select visit_id as 'رقم الزيارة', entranceoffice_visit.pat_id As '  رقم المريض ', Registeration_patientRegisteration.patient_name  as ' اسم المريض' from follow_up_sheet_slected_med, follow_up_sheet, entranceoffice_visit,Registeration_patientRegisteration where follow_up_sheet_slected_med.inventry_id=follow_up_sheet.inventry_id and follow_up_sheet.inventry_id=entranceoffice_visit.visit_id and entranceoffice_visit.pat_id=Registeration_patientRegisteration.patient_id", connection);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                //dr.Close();
                }
            
    
        private void استقبال_الصيدليه_Load(object sender, EventArgs e)
        {
           
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharmacy_update_medicineQuantityAfterElsarf", new string[] { "@med_id" }, new string[] { inventry_id.ToString() }, new SqlDbType[] { SqlDbType.Int});
            MessageBox.Show("لقد تمت عمليه صرف الروشته بنجاح  ");
         }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inventry_id = int .Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            effective_subject es = new effective_subject();
            es.Show();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this .Close();
        }
       
    }
}
