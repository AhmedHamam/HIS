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
    public partial class النتيجة : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
       // SqlDataReader dr;
        SqlCommand cmd;
        string resultID = "";
        string resultNote = "";
        string patientID = "";
        string patientName = "";
        public النتيجة()
        {
            InitializeComponent();
            
        }

        public النتيجة(string a, string b,string c,string d)
        {
            InitializeComponent();
            resultID=a;
            resultNote=b;
            patientID=c;
            patientName=d;

            
        }

        private void النتيجة_Load(object sender, EventArgs e)
        {
            labrResultID.Text = resultID;
            labResultNote.Text = resultNote;
            labPatientName.Text = patientName;
            labPatientID.Text = patientID;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                cmd = new SqlCommand("truncate table print_result", connection);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("deleted");
                
                cmd = new SqlCommand("insert into print_result(patientName,patientID ,resultNote,resultID)values(N'" + patientName + "'," + patientID + ",N'" + resultNote + "'," + resultID + ")", connection);
                cmd.ExecuteNonQuery();

                طباعه_النتيجة___التحاليل nw = new طباعه_النتيجة___التحاليل();
                nw.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            
           // this.Close();
        }
    }
}
