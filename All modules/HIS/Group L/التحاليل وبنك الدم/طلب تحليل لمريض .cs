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
  
    public partial class طلب_تحليل_لمريض : Form
    {
        string patientID = "";
        string patientName = "";
        string patientAge = "";
        string patientGender = "";

        string reqDate = "";
     string reqPlace = "";


        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
       // SqlDataReader dr1;

        public طلب_تحليل_لمريض()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void بيانات_المريض_Load(object sender, EventArgs e)
        {

        }

       // private void button3_Click(object sender, EventArgs e)
       // {
       //try
       //     {
               
       //         connection.Open();
            
         
       //    //  cmd = new SqlCommand("insert  into patient(patient_name ,request_place,request_date,age,gender,payment) values(N'احمد',N'assuit','',20,'male','yes')", connection);
       //     // cmd.ExecuteNonQuery();
       //       //cmd=new SqlCommand("select*from patient where patient_number='+tbx_patient_number.Text+'",connection);
       //       //cmd.ExecuteNonQuery();
       //     //  cmd = new SqlCommand("select*from patient where patient_name='+tbx_patient_name.Text+'", connection);
       //      // cmd.ExecuteNonQuery();
       //         cmd = new SqlCommand("Select*from patient", connection);
       //         dr = cmd.ExecuteReader();
       //         DataTable dt = new DataTable();
       //         dt.Load(dr);
       //         dataGridView1.DataSource = dt;
       //         dataGridView1.Visible = true;
              

             


       //     }
       //     catch (Exception ex)
       //     {
       //         MessageBox.Show(ex.Message);
       //     }
        
    
       // }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {

                connection.Open();
                if (tbx_patient_number.Text == "" && tbx_patient_name.Text == "" && txtAge.Text == "" && radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    cmd = new SqlCommand("labAnalysis_patient_select1", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   // cmd = new SqlCommand("Select*from patient", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                    dr.Close();
                }
                else
                {
                    string gender = "";
                    if (radioButton1.Checked == true)
                        gender = "male";
                    else
                        gender = "female";
                    cmd = new SqlCommand("labAnalysis_patient_select2 ", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patient_number", tbx_patient_number.Text);
                    cmd.Parameters.AddWithValue("@patient_name", tbx_patient_name.Text);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@gender", gender);
                  //  cmd = new SqlCommand("Select*from patient where patient_number = " + tbx_patient_number.Text + " and patient_name = N'" + tbx_patient_name.Text + "' and age = " + txtAge.Text + " and gender = '" + gender + "' ", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                    dr.Close();
                }
                

            }
            catch 
            {
                MessageBox.Show("من فضلك قم بادخال كل بيانات المريض");
            }
            connection.Close();
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            if (patientID != string.Empty && patientAge != string.Empty && patientAge != string.Empty && patientGender != string.Empty)
            {
                try
                {
                    reqDate = dateTimePicker2.Value.ToString();
                    reqPlace = comboBox1.Text = comboBox1.SelectedItem.ToString();

                    انواع_التحاليل nw = new انواع_التحاليل(patientID, patientName, patientAge, patientGender, reqDate,reqPlace);
                    nw.Show();
                }
                catch
                {
                    MessageBox.Show("من فضلك اختر مريض");
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر مريض علي الاقل ليتم اجراء التحاليل عليه");
            }
            /*
            connection.Open();
            //backContainer.Visible = false;
            frontContainer.Visible = true;
            try
            {


                if (dataGridView1.SelectedRows.Count == 1)
                {
                    labID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    labName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    labPlace.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    labDate.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    labAge.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    labGender.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                }
                cmd = new SqlCommand("select analysis_type from analysis_type", connection);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                //string s="";

                string s1 =dataGridView2.Rows[0].Cells[0].Value.ToString();
                string s2 = dataGridView2.Rows[0].Cells[0].Value.ToString();
                //MessageBox.Show(s1);
               
                if (s1 == "clinical_chemistry")
                {
                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info where typeId=1", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(dr);
                    dataGridView3.DataSource = dt2;
                    dr.Close();
                }
                else if (s2 == "micropology")
                {
                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info where typeId=2", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(dr);
                    dataGridView3.DataSource = dt2;
                    dr.Close();
                }
                else
                {
                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info", connection);
                dr = cmd.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr);
                dataGridView3.DataSource = dt4;
                dr.Close();
 
                }*/



                /*

                //string s2 =dataGridView2.SelectedRows[1].Cells[1].Value.ToString();
                switch(s)
                {
                    case "s1" : 

                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info where typeId=1", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(dr);
                    dataGridView3.DataSource = dt2;
                    dr.Close();
                        break;

                    case "s2" : 

                    cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info where typeId=2", connection);
                    dr = cmd.ExecuteReader();
                    DataTable dt3 = new DataTable();
                    dt3.Load(dr);
                    dataGridView3.DataSource = dt3;
                    dr.Close();
                        break;


                }

                
                //if(dataGridView2.SelectedRows[0].)
                cmd = new SqlCommand("select id,serv_name,price,quantity,notices from analysis_info", connection);
                dr = cmd.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr);
                dataGridView3.DataSource = dt4;
                dr.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();*/
        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientName= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            patientAge = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            patientGender = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
