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
    public partial class تسجيل_بيانات_متبرع : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        //SqlDataReader dr;
       // SqlDataAdapter da;
        public تسجيل_بيانات_متبرع()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //Connection conn = new Connection(); string constr = conn.getconstr();
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            //string supplierType = cbSupType.Text = cbSupType.SelectedItem.ToString();
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
                MessageBox.Show("من فضلك ادخل البيانات الناقصة");
            else
            {
                try
                {
                    connection.Open();
                    //string supplierType = "";
                    //if (rbDonator.Checked == true)
                    //    supplierType = "donator";
                    //else if(rbSupplier.Checked == true)
                    //    supplierType = "supplier";
                    string supplierType = cbSupType.Text = cbSupType.SelectedItem.ToString();
                    cmd = new SqlCommand("bloodBank_bloodSupplier_insert", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@supplierType", supplierType);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                    cmd.ExecuteNonQuery();
                

                    //    //MessageBox.Show("من فضلك ادخل البيانات الناقصة");
                    //else
                    //    MessageBox.Show("");

                    بيانات_التمويل nw = new بيانات_التمويل();
                    nw.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }

            connection.Close();
        }

        private void تسجيل_بيانات_متبرع_Load(object sender, EventArgs e)
        {
            this.cbSupType.Text = "متبرع";
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    con.Open();

        //    try
        //    {
        //        cmd = new SqlCommand("select * from supplier", con);
        //        dr = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);
        //        dataGridView1.DataSource = dt;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    con.Close();
        //}

        
    }
}
