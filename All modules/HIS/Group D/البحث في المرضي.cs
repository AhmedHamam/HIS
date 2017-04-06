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
    public partial class opForm002 : Form
    {
        opForm02 own = null;
        //SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        Connection connect;
        public opForm002()
        {
            InitializeComponent();
            connect = new Connection();
        }
        public opForm002(opForm02 own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void opForm002_Load(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                string pName = "patient_research4";
              
               
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);
               // cmd = new SqlCommand("select visit_id as 'الكود',patient_name as 'اسم المريض ' from Registeration_patientRegisteration,entranceoffice_visit where  Registeration_patientRegisteration.patient_id=entranceoffice_visit.pat_id ", con);
               
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                cmd = new SqlCommand("select visit_id as 'الكود',patient_name as 'اسم المريض ' from Registeration_patientRegisteration,entranceoffice_visit where  Registeration_patientRegisteration.patient_id=entranceoffice_visit.pat_id  and patient_name ='" + textBox2.Text + "'");
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                cmd = new SqlCommand(" select visit_id as 'الكود',patient_name as 'اسم المريض ' from Registeration_patientRegisteration,entranceoffice_visit where  Registeration_patientRegisteration.patient_id=entranceoffice_visit.pat_id and patient_name like'" + textBox2.Text + "%'");
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                e.RowIndex.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                string x = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                string y = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

                this.own.setvalue(x, y);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();

                textBox2.Text = " ";
                
                cmd = new SqlCommand("select visit_id as 'الكود',patient_name as 'اسم المريض ' from Registeration_patientRegisteration,entranceoffice_visit where  Registeration_patientRegisteration.patient_id=entranceoffice_visit.pat_id ");
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
