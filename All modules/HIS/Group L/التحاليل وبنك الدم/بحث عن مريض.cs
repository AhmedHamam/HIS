using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{
    public partial class بحث_عن_مريض : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string patientID = "";
        string patientName = "";

        public بحث_عن_مريض()
        {
            InitializeComponent();
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            طلب_عبوات_دم nw = new طلب_عبوات_دم(patientID,patientName);
            nw.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }
        //  cmd = new SqlCommand("insert  into patient(patient_name ,request_place,request_date,age,gender,payment) values(N'احمد',N'assuit','',20,'male','yes')", connection);
        // cmd.ExecuteNonQuery();
        //cmd=new SqlCommand("select*from patient where patient_number='+tbx_patient_number.Text+'",connection);
        //cmd.ExecuteNonQuery();
        //  cmd = new SqlCommand("select*from patient where patient_name='+tbx_patient_name.Text+'", connection);
        // cmd.ExecuteNonQuery();






        //if (tbx_patient_number.Text == "" && tbx_patient_name.Text == "" && txtAge.Text == "" && radioButton1.Checked == false && radioButton2.Checked == false)
        //{
        //    cmd = new SqlCommand("Select * from patient", con);
        //    dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
        //    dataGridView1.DataSource = dt;
        //    dataGridView1.Visible = true;
        //    dr.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //string query = "select * from patient where ";

                //if (tbx_patient_number.Text != "")
                //    query += " and patient_name like '%"+ tbx_patient_name.Text+"%' "; 
                //else if (tbx_patient_name.Text != "")
                //    query += " and patient_number like '%" + tbx_patient_number.Text + "%'  ";
                //else if (txtAge.Text != "")
                //    query += " and age like '%" + txtAge.Text + "%' "; 

                cmd = new SqlCommand("select patient_id,patient_name,gender,age from Registeration_patientRegisteration", connection);
                dr = cmd.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr);
                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
                dr.Close();
                   
                
                //else //(tbx_patient_number.Text == "" && tbx_patient_name.Text == "" && txtAge.Text == "" && radioButton1.Checked == false && radioButton2.Checked == false)
                //{
                //    cmd = new SqlCommand("Select * from patient", con);
                //    dr = cmd.ExecuteReader();
                //    DataTable dt = new DataTable();
                //    dt.Load(dr);
                //    dataGridView1.DataSource = dt;
                //    dataGridView1.Visible = true;
                //    dr.Close();
                //}
                    

                //else if (tbx_patient_name.Text != "")
                //{
                //    cmd = new SqlCommand(query + " gender =" + tbx_patient_number.Text + " ", con);
                //}

                //else
                //{
                //    string gender = "";
                //    if (radioButton1.Checked == true)
                //        gender = "male";
                //    else
                //        gender = "female";

                //    cmd = new SqlCommand("Select*from patient where patient_number = " + tbx_patient_number.Text + " and patient_name = N'" + tbx_patient_name.Text + "' and age = " + txtAge.Text + " and gender = '" + gender + "' ", con);
                //    dr = cmd.ExecuteReader();
                //    DataTable dt = new DataTable();
                //    dt.Load(dr);
                //    dataGridView1.DataSource = dt;
                //    dataGridView1.Visible = true;
                //    dr.Close();
                //}


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"من فضلك قم بادخال كل بيانات المريض");
            }
            connection.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
