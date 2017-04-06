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
    public partial class بيانات_التمويل : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;

        public بيانات_التمويل()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void بيانات_التمويل_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            this.cbBloodType.Text = "دم كامل";
            this.cbBloodFaction.Text = "A";
            this.cbRH.Text = "+";

            
            try
            {
                connection.Open();
                da = new SqlDataAdapter("select top 1*from bloodSupplier order by id desc", connection);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                BindingSource bs = new BindingSource();
                bs.DataSource = ds.Tables[0];
                txtID.DataBindings.Add("text", bs, "id").ToString();    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            

            if (txtID.Text == "" || txtEmpID.Text == "" || txtQuntity.Text == "")
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");

            try 
            {
                connection.Open();
                string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString(); ;
                string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                string RH = cbRH.Text = cbRH.SelectedItem.ToString();


                //if (rbFullBlood.Checked == true)
                //    bloodType = "full blood";
                //else if (rbPlazma.Checked == true)
                //    bloodType = "plazma";

                
                //if(rbA.Checked==true)
                //    bloodFaction="A";
                //else if(rbB.Checked==true)
                //    bloodFaction="B";
                //else if(rbO.Checked==true)
                //    bloodFaction="O";
                //else if(rbAB.Checked==true)
                //    bloodFaction="AB";

                
                //if(rbPlus.Checked == true)
                //    RH="+";
                //else if(rbNegative.Checked == true)
                //    RH="-";

                //cmd = new SqlCommand("insert into packageSupplying set supplierID =" + txtID.Text + " ,employeeID=" + txtEmpID.Text + ", processType='supplying', processDate='" + dateTimePicker2.Value + "',bloodType=N'" + bloodType + "' , bloodFaction='" + bloodFaction + "' , RH = '" + RH + "' , quntity=" + txtQuntity.Text+ " ", con);
                cmd = new SqlCommand("bloodBank_packageSupplying_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("supplierID", txtID.Text);
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

        private void txtQuntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
