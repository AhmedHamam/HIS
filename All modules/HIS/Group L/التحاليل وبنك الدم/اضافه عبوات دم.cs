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
    public partial class اضافه_عبوات_دم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        // bloodPackage data
        string bloodType = "";
        string bloodFaction = "";
        string RH = "";
        string quantity = "";
        string exDate = "";
        public اضافه_عبوات_دم()
        {
            InitializeComponent();
        }

        private void اضافه_عبوات_دم_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("select * from packageSupplying where process_state='no' ", con);
                cmd = new SqlCommand("bloodBank_packageSupplying_select", connection);
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
            connection.Close();
        }
      

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
             // MessageBox.Show(bloodType + bloodFaction + RH + quantity);
                cmd = new SqlCommand("select * from bloodPackage where  bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'  ", connection);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    //cmd = new SqlCommand("update bloodPackage set quntity +=" + quantity + "  where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_update2", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("quntity", quantity);
                    cmd.Parameters.AddWithValue("bloodType", bloodType);
                    cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("RH", RH);
                    
                    cmd.ExecuteNonQuery();

                    //dr.Close();
                    //cmd = new SqlCommand("update packageSupplying set quntity +=" + quantity + " ,process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'", con);
                    //cmd.ExecuteNonQuery();

                    dr.Close();
                    //cmd = new SqlCommand("update packageSupplying set process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'", con);
                    cmd = new SqlCommand("bloodBank_packageSupplying_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("bloodType", bloodType);
                    cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("RH", RH);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تمت عملية الاضافة بنجاح");
                }
                else
                {
                    dr.Close();

                    //cmd = new SqlCommand("insert into bloodPackage(bloodType,bloodFaction,RH,quntity,bloodStoreID,exDate)values(N'" + bloodType + "','" + bloodFaction + "','" + RH + "'," + quantity + ",1,'"+exDate+"')", con);
                    cmd = new SqlCommand("bloodBank_bloodPackage_insert", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("quntity", quantity);
                    cmd.Parameters.AddWithValue("bloodType", bloodType);
                    cmd.Parameters.AddWithValue("bloodFaction", bloodFaction);
                    cmd.Parameters.AddWithValue("RH", RH);

                    cmd.ExecuteNonQuery();

                    //dr.Close();
                    //cmd = new SqlCommand("update packageSupplying set quntity +=" + quantity + " ,process_state='yes' where bloodType =  N'" + bloodType + "' and bloodFaction='" + bloodFaction + "'and RH ='" + RH + "'", con);
                    //cmd.ExecuteNonQuery();

                    dr.Close();
                    cmd = new SqlCommand("bloodBank_packageSupplying_update", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bloodType = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            bloodFaction = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            RH = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            quantity = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            exDate = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
