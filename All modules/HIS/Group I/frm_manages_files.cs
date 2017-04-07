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
    public partial class frm_manages_files : Form
    {
        Connection con = new Connection();
        public frm_manages_files()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search(object sender, EventArgs e)
        {

        }

        private void txt_employee_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_activity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_patiant_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void time_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_name_Click(object sender, EventArgs e)
        {
           
           
                try
                {
                    con.OpenConection();
                    string[] s = new string[] {"@patientname" };
                    string[] s1 = new string[] { txt_patiant_name.Text };
                    SqlDbType[] s3 = new SqlDbType[] {SqlDbType.NVarChar };
                    patient_data.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("ManageFilesPatientdata", s, s1, s3);
                   /////////////////////////////////////////////////////////////////////////
                    string[] s4 = new string[] {"@patientname" };
                    string[] s5 = new string[] { txt_patiant_name.Text };
                    SqlDbType[] s6 = new SqlDbType[] { SqlDbType.NVarChar };
                    DataTable d = new DataTable();
                    examination.DataSource= (DataTable)con.ShowDataInGridViewUsingStoredProc("ManageFilesPatientProcess", s4, s5, s6);  
                    con.CloseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_date_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@date" };
                string[] s1 = new string[] { date.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date };
                patient_data.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("managefilesdatePatient", s, s1, s3);
                /////////////////////////////////////////////////////////////////////////
                string[] s4 = new string[] { "@date" };
                string[] s5 = new string[] { date.Text };
                SqlDbType[] s6 = new SqlDbType[] { SqlDbType.Date };
                DataTable d = new DataTable();
                examination.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("managefilesdateemployee", s4, s5, s6);
                con.CloseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@empname" };
                string[] s1 = new string[] { txt_employee_name.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                patient_data.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("managefileseployee", s, s1, s3);
                con.CloseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btn_task_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] {"@empname" };
                string[] s1 = new string[] { txt_employee_name.Text};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                examination.DataSource= (DataTable)con.ShowDataInGridViewUsingStoredProc("managefileseployee", s, s1, s3);
                con.CloseConnection();
            }
                
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_employee_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }

        }

        private void txt_patiant_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&!char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void txt_activity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void إنشاءنسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_backup frm = new frm_backup();
            frm.Show();
        }

        private void إستعادةنسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_restore frm = new frm_restore();
            frm.Show();
        }
    }
}
