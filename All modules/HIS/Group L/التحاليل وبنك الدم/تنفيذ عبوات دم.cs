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
    public partial class تنفيذ_عبوات_دم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        /// blood data //// 
        string bloodType = "";
        string bloodFaction = "";
        string RH = "";
        string quantity = "";
        //string exDate = "";


        public تنفيذ_عبوات_دم()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            if (cbProcessType.Text == "")
            {
                try
                {
                    connection.Open();
                    //cmd = new SqlCommand("select * from whichProcess where process_state='no'", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_select2", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    connection.Open();
                    //cmd = new SqlCommand("select * from whichProcess where process_state='no' and processType=N'"+cbProcessType.Text+"'", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_select3", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("processType", cbProcessType.Text);

                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bloodType = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            bloodFaction = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            RH = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            quantity = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //exDate = dataGridView1.Rows[e.RowIndex].Cells[].Value.ToString();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //MessageBox.Show(bloodType + bloodFaction + RH + quantity);
                cmd = new SqlCommand("select * from bloodPackage where  bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity >= " + quantity + " ", connection);
            
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    // update process state from no to yes if exists
                    //cmd = new SqlCommand("update whichProcess set process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity =" + quantity + " ", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("hello");


                    //////////////////////////////
                    // delete the blood packages 
                    //cmd = new SqlCommand("update bloodPackage set quntity -=" + quantity + " where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "' ", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_update3", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("hello");
                  
                    MessageBox.Show("العبوه موجوده بالفعل");
                }
                else
                    MessageBox.Show("عفوا العبوه غير موجوده");
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //MessageBox.Show(bloodType + bloodFaction + RH + quantity);
                cmd = new SqlCommand("select * from bloodPackage where  bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity >= " + quantity + " ", connection);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    // update process state from no to yes if exists
                    //cmd = new SqlCommand("update whichProcess set process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity =" + quantity + " ", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    
                    cmd.ExecuteNonQuery();

                    // delete the blood packages 
                    //cmd = new SqlCommand("update bloodPackage set quntity -=" + quantity + " where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "' ", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_update3", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    
                    cmd.ExecuteNonQuery();

                    // update reserveQun to requested quntity 
                    //cmd = new SqlCommand("update bloodPackage set reserveQuantity +=" + quantity + " where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "' ", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_update5", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تم حجز العبوة بنجاح");
                }
                else
                    MessageBox.Show("عفوا العبوه غير موجوده");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                //MessageBox.Show(bloodType + bloodFaction + RH + quantity);
                cmd = new SqlCommand("select * from bloodPackage where  bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity >= " + quantity + " ", connection);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    // update process state from no to yes if exists
                    //cmd = new SqlCommand("update whichProcess set process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity =" + quantity + " ", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    cmd.Parameters.AddWithValue("@quntity", quantity);
                    
                    cmd.ExecuteNonQuery();

                    // delete the blood packages 
                    //cmd = new SqlCommand("update bloodPackage set quntity +=" + quantity + " where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "' ", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_update2", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("quntity", quantity);
                    cmd.Parameters.AddWithValue("bloodType", bloodType);
                    cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("RH", RH);
                    
                    cmd.ExecuteNonQuery();

                    //// update reserveQun to requested quntity 
                    //cmd = new SqlCommand("update bloodPackage set reserveQuantity +=" + quantity + " where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "' ", con);
                    //cmd.ExecuteNonQuery();

                    MessageBox.Show("تم ارتجاع العبوة بنجاح");
                }
                else
                {
                    dr.Close();
                    // update process state from no to yes if exists
                    //cmd = new SqlCommand("update whichProcess set process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'and quntity =" + quantity + " ", con);
                    cmd = new SqlCommand("bloodBank_whichProcess_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@bloodType", bloodType);
                    cmd.Parameters.AddWithValue("@bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("@RH", RH);
                    cmd.Parameters.AddWithValue("@quntity", quantity);

                    cmd.ExecuteNonQuery();


                    //cmd = new SqlCommand("insert into bloodPackage(bloodType,bloodFaction,RH,quntity,bloodStoreID,exDate,reserveQuantity) values", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_insert", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("quntity", quantity);
                    cmd.Parameters.AddWithValue("bloodType", bloodType);
                    cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("RH", RH);
                    //cmd.Parameters.AddWithValue("exDate", );

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم ارتجاع العبوة بنجاح");
                }
                   


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
