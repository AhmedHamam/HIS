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
    public partial class طلب_عبوات_دم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;

        string patientID = "";
        string patientName = "";

        public طلب_عبوات_دم()
        {
            InitializeComponent();
        }

        public طلب_عبوات_دم(string a, string b)
        {
            InitializeComponent();
            patientID = a;
            patientName = b;
        }

        private int randomN(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
           
            try
            {
                connection.Open();
                string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString(); 
                string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                string RH = cbRH.Text = cbRH.SelectedItem.ToString();
                string processType = cbProcessType.Text = cbProcessType.SelectedItem.ToString();


                int empID = randomN(1, 4);
                //MessageBox.Show(empID.ToString());


                //cmd = new SqlCommand("insert into whichProcess values(" + txtDoctorID.Text + " ," + empID + ", N'"+ processType +"','" + dateTimePicker2.Value + "', N'" + bloodType + "' , '" + bloodFaction + "' , '" + RH + "' , " + txtQuntity.Text + " , "+patientID+",N'"+patientName+"','no') ", con);
                cmd = new SqlCommand("bloodBank_whichProcess_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("doctorID", txtDoctorID.Text);
                cmd.Parameters.AddWithValue("employeeID", empID);
                cmd.Parameters.AddWithValue("processType", processType);
                cmd.Parameters.AddWithValue("processDate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("bloodType", bloodType);
                cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                cmd.Parameters.AddWithValue("RH", RH);
                cmd.Parameters.AddWithValue("quntity", txtQuntity.Text);
                cmd.Parameters.AddWithValue("patientID", patientID);
                cmd.Parameters.AddWithValue("patientName", patientName);

                cmd.ExecuteNonQuery();
                MessageBox.Show("تم عملية الطلب بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");
                //MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void طلب_عبوات_دم_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(patientID+patientName);
            this.cbBloodType.Text = "دم كامل";
            this.cbBloodFaction.Text = "A";
            this.cbRH.Text = "+";
            this.cbProcessType.Text = "طلب";
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString();
                string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                string RH = cbRH.Text = cbRH.SelectedItem.ToString();
                string processType = cbProcessType.Text = cbProcessType.SelectedItem.ToString();


                int empID = randomN(1, 4);
                //MessageBox.Show(processType);


                //cmd = new SqlCommand("insert into whichProcess values(" + txtDoctorID.Text + " ," + empID + ", N'" + processType + "','" + dateTimePicker2.Value + "', N'" + bloodType + "' , '" + bloodFaction + "' , '" + RH + "' , " + txtQuntity.Text + " , " + patientID + ",N'" + patientName + "','no') ", con);
                cmd = new SqlCommand("bloodBank_whichProcess_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("doctorID", txtDoctorID.Text);
                cmd.Parameters.AddWithValue("employeeID", empID);
                cmd.Parameters.AddWithValue("processType", processType);
                cmd.Parameters.AddWithValue("processDate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("bloodType", bloodType);
                cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                cmd.Parameters.AddWithValue("RH", RH);
                cmd.Parameters.AddWithValue("quntity", txtQuntity.Text);
                cmd.Parameters.AddWithValue("patientID", patientID);
                cmd.Parameters.AddWithValue("patientName", patientName);
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم عملية الحجز بنجاح");
 
            }
            catch (Exception ex)
            {
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");
                //MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString();
                string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                string RH = cbRH.Text = cbRH.SelectedItem.ToString();
                string processType = cbProcessType.Text = cbProcessType.SelectedItem.ToString();


                int empID = randomN(1, 4);
                //MessageBox.Show(empID.ToString());


                //cmd = new SqlCommand("insert into whichProcess values(" + txtDoctorID.Text + " ," + empID + ", N'" + processType + "','" + dateTimePicker2.Value + "', N'" + bloodType + "' , '" + bloodFaction + "' , '" + RH + "' , " + txtQuntity.Text + " , " + patientID + ",N'" + patientName + "','no') ", con);
                cmd = new SqlCommand("bloodBank_whichProcess_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("doctorID", txtDoctorID.Text);
                cmd.Parameters.AddWithValue("employeeID", empID);
                cmd.Parameters.AddWithValue("processType", processType);
                cmd.Parameters.AddWithValue("processDate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("bloodType", bloodType);
                cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                cmd.Parameters.AddWithValue("RH", RH);
                cmd.Parameters.AddWithValue("quntity", txtQuntity.Text);
                cmd.Parameters.AddWithValue("patientID", patientID);
                cmd.Parameters.AddWithValue("patientName", patientName);

                cmd.ExecuteNonQuery();

                MessageBox.Show("تم عملية الارتجاع بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");
                //MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doctor_data nw = new doctor_data();
            nw.Show();
            txtDoctorID.Text = nw.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtQuntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void txtDoctorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
