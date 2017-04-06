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
    public partial class انواع_التحاليل : Form
    {

        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr2;

        // pass patient data from grid view 1
        string patientID = "";
        string patientName = "";
        string patientAge = "";
        string patientGender = "";

        // pass sample data from grid view 2
        string sample_id = "";

        // pass sample information from grid view 3
        string analID = "";
        string analName = "";
        string analPrice = "";
        string analNote = "";
        string analQuantity = "";

        string reqDate = "";
        string reqPlace = "";


        public انواع_التحاليل()
        {

            InitializeComponent();
            

        }

        public انواع_التحاليل(string a, string b, string c, string d,string e,string f)
        {
            
            InitializeComponent();
            patientID = a;
            patientName = b;
            patientAge = c;
            patientGender = d;
            reqDate=e;
            reqPlace=f;
            fillListbox();

        }
        void fillListbox()
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            cmd = new SqlCommand("select sample_name from analysis_samples", connection);
            SqlDataReader dr;
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string servName = dr.GetString(0);
                    lb1.Items.Add(servName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }


        private void انواع_التحاليل_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            try
            {
                connection.Open();


                labID.Text = patientID;
                labName.Text = patientName;
                labAge.Text = patientAge;
                labGender.Text = patientGender;
                labReqDate.Text = reqDate;
                labReqPlace.Text = reqPlace;
                cmd = new SqlCommand("labAnalysis_analysis_info_select1 ", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr2 = cmd.ExecuteReader();
               // cmd = new SqlCommand("select * from analysis_info ", connection);
               // dr2 = cmd.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView3.DataSource = dt2;      
                             


                connection.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            int s=lb1.SelectedIndex;
         
            //if(s == 0)
            //{
            //    cmd = new SqlCommand("labAnalysis_analysis_info_select2 ", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    dr2 = cmd.ExecuteReader();
            //    //cmd = new SqlCommand("select * from analysis_info where sample_id =1 ", connection);
            //   // dr2 = cmd.ExecuteReader();
            //    DataTable dt2 = new DataTable();
            //    dt2.Load(dr2);
            //    dataGridView3.DataSource = dt2;
            //}
            //if (s == 1)
            //{
            //    cmd = new SqlCommand("labAnalysis_analysis_info_select3 ", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //   // dr2 = cmd.ExecuteReader();
            //    //cmd = new SqlCommand("select * from analysis_info where sample_id =2 ", connection);
            //    dr2 = cmd.ExecuteReader();
            //    DataTable dt2 = new DataTable();
            //    dt2.Load(dr2);
            //    dataGridView3.DataSource = dt2;
            //}
            //if (s == 2)
            //{
            //    cmd = new SqlCommand("labAnalysis_analysis_info_select4  ", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //   // cmd = new SqlCommand("select * from analysis_info where sample_id =3  ", connection);
            //    dr2 = cmd.ExecuteReader();
            //    DataTable dt2 = new DataTable();
            //    dt2.Load(dr2);
            //    dataGridView3.DataSource = dt2;
            //}
            //if (s == 3)
            //{
            //    cmd = new SqlCommand("labAnalysis_analysis_info_select5 ", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //   // dr2 = cmd.ExecuteReader();
            //   // cmd = new SqlCommand("select * from analysis_info where sample_id =4 ", connection);
            //    dr2 = cmd.ExecuteReader();
            //    DataTable dt2 = new DataTable();
            //    dt2.Load(dr2);
            //    dataGridView3.DataSource = dt2;
            //}
            //if (s == 4)
            //{
            //    cmd = new SqlCommand("labAnalysis_analysis_info_select6 ", connection);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //   // dr2 = cmd.ExecuteReader();
            //   // cmd = new SqlCommand("select * from analysis_info where sample_id =5  ", connection);
            //    dr2 = cmd.ExecuteReader();
            //    DataTable dt2 = new DataTable();
            //    dt2.Load(dr2);
            //    dataGridView3.DataSource = dt2;

            //}

            for (int i = s; i <= lb1.Items.Count; i++)
            {
                //MessageBox.Show(s.ToString() + "   " +i.ToString());
                cmd = new SqlCommand("select * from analysis_info where sample_id ="+(i+1)+" ", connection);
                i = 100;
                //MessageBox.Show((i+1).ToString());
            }
            dr2 = cmd.ExecuteReader();
            //cmd = new SqlCommand("select * from analysis_info where sample_id =1 ", connection);
            // dr2 = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView3.DataSource = dt2;
            connection.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            analID = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            analName = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            analPrice = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            analQuantity = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            analNote = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            sample_id = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString(); 
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            

            try
            {
                connection.Open();
                cmd = new SqlCommand("labAnalysis_analysis_request_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_number_patient", patientID);
                cmd.Parameters.AddWithValue("@order_number_analysis_samples", sample_id);
                cmd.Parameters.AddWithValue("@request_date", reqDate);
                cmd.Parameters.AddWithValue("@request_place", reqPlace);
                cmd.Parameters.AddWithValue("@payment", analPrice);
                // cmd = new SqlCommand("insert into analysis_request(patient_number_patient,order_number_analysis_samples,request_date,request_place,payment) values('" + patientID + "','" + sample_id + "','" + reqDate + "',N'" + reqPlace + "','" + analPrice + "')", connection);
                cmd.ExecuteNonQuery();
               // cmd = new SqlCommand("insert into analysis_request1(patient_number_patient,order_number_analysis_samples,request_date,request_place,payment) values('" + patientID + "','" + sample_id + "','" + reqDate + "','" + reqPlace + "','" + analPrice + "')", connection);
               // cmd.ExecuteNonQuery();
                MessageBox.Show("تم طلب تحاليل بنجاح");

                الروشتة nw = new الروشتة(analID, analName, analPrice, analQuantity, analNote, patientID, patientName, patientAge, patientGender, reqDate, reqPlace);
                nw.Show();

                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
               MessageBox.Show("لقد طلبت هذا النوع من التحاليل مسبقاً");
            }

            connection.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frontContainer_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
