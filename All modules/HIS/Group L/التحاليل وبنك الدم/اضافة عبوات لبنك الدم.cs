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
    public partial class اضافة_عبوات_لبنك_الدم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public اضافة_عبوات_لبنك_الدم()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();SqlConnection connection = new SqlConnection(constr);

            
            if (txtQuntity.Text == "")
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");
            else
            {
                try
                {
                    connection.Open();
                    string bloodType = cbBloodType.Text = cbBloodType.SelectedItem.ToString();
                    string bloodFaction = cbBloodFaction.Text = cbBloodFaction.SelectedItem.ToString();
                    string RH = cbRH.Text = cbRH.SelectedItem.ToString();
                    string quantity = txtQuntity.Text;
                    string exDate = dtExDate.Value.ToString();

                    cmd = new SqlCommand("select * from bloodPackage where  bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'  ", connection);
                    //cmd = new SqlCommand("bloodBank_bloodPackage_select3", con);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("bloodType", bloodType);
                    //cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    //cmd.Parameters.AddWithValue("RH", RH);

                    //cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("العبوة موجوده");
                        dr.Close();
                        //cmd = new SqlCommand("update bloodPackage set quntity +=" + quantity + "  where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'", con);
                        cmd = new SqlCommand("bloodBank_bloodPackage_update2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("quntity", quantity);
                        cmd.Parameters.AddWithValue("bloodType", bloodType);
                        cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                        cmd.Parameters.AddWithValue("RH", RH);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت عملية الاضافة بنجاح");
                    }
                    else
                    {
                        dr.Close();

                        //cmd = new SqlCommand("insert into bloodPackage(bloodType,bloodFaction,RH,quntity,bloodStoreID,exDate)values(N'" + bloodType + "','" + bloodFaction + "','" + RH + "'," + quantity + ",1,'" + exDate + "')", con);
                        cmd = new SqlCommand("bloodBank_bloodPackage_insert", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("quntity", quantity);
                        cmd.Parameters.AddWithValue("bloodType", bloodType);
                        cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                        cmd.Parameters.AddWithValue("RH", RH);


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("هذه العبوه جديده وتمت اضافتها");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void اضافة_عبوات_لبنك_الدم_Load(object sender, EventArgs e)
        {
            this.cbBloodType.Text = "دم كامل";
            this.cbBloodFaction.Text = "A";
            this.cbRH.Text = "+";
        }
    }
}
