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
    public partial class بيانات_التمويل_لمتبرع_موجود : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        //SqlDataAdapter da;
        SqlCommand cmd;

        // donator data
        string ID = "";

        // bloodPackage data
        string bloodType = "";
        string bloodFaction = "";
        string RH = "";

        public بيانات_التمويل_لمتبرع_موجود(string a,string b,string c,string d)
        {
            InitializeComponent();
            ID = a;
            bloodType = b;
            bloodFaction = c;
            RH = d;
        }

        private void بيانات_التمويل_لمتبرع_موجود_Load(object sender, EventArgs e)
        {
            txtID.Text = ID;
            txtBloodType.Text = bloodType;
            txtBloodFaction.Text = bloodFaction;
            txtRH.Text = RH;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                //string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString(); ;
                //string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                //string RH = cbRH.Text = cbRH.SelectedItem.ToString();

                connection.Open();
                //cmd = new SqlCommand("insert into packageSupplying(supplierID,employeeID,processType,processDate,bloodType,bloodFaction,RH,quntity,exDate) values(" + txtID.Text + " ," + txtEmpID.Text + ", 'supplying','" + dateTimePicker2.Value + "', N'" + bloodType + "' , '" + bloodFaction + "' , '" + RH + "' , " + txtQuntity.Text + ",'" + dtExDate.Value + "') ", con);
                cmd = new SqlCommand("bloodBank_packageSupplying_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("supplierID", ID);
                cmd.Parameters.AddWithValue("employeeID", txtEmpID.Text);
                cmd.Parameters.AddWithValue("processType", dtDate.Value);
                cmd.Parameters.AddWithValue("processDate", dtDate.Value);
                cmd.Parameters.AddWithValue("bloodType", bloodType);
                cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                cmd.Parameters.AddWithValue("RH", RH);
                cmd.Parameters.AddWithValue("quntity", txtQuntity.Text);
                cmd.Parameters.AddWithValue("exDate", dtExDate.Value);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الاضافة بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
