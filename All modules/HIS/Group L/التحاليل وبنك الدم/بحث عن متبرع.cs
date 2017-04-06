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
    public partial class بحث_عن_متبرع : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        /// donator data 
        string ID = "";

        // bloodPackage data
        string bloodType = "";
        string bloodFaction = "";
        string RH = "";

        public بحث_عن_متبرع()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                if (txtSupName.Text == "")
                {
                    //cmd = new SqlCommand("select * from supplier,packageSupplying  where supplierType='donator' and id=supplierID ", con);
                    cmd = new SqlCommand("bloodBank_supplierAndpackageSupplying_select", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();

                }
                else if (txtSupName.Text != "")
                {
                    //MessageBox.Show(txtSupName.Text);
                    //cmd = new SqlCommand("select * from supplier,packageSupplying  where supplierType=N'متبرع' and id=supplierID and name = N'" + txtSupName.Text + "' ", con);
                    cmd = new SqlCommand("bloodBank_supplierAndpackageSupplying_select2", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("name", txtSupName.Text);

                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
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
            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            bloodType = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            bloodFaction = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            RH = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void بحث_عن_متبرع_Load(object sender, EventArgs e)
        {
        
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            
            try
            {
                connection.Open();
                //MessageBox.Show(ID);
                if (ID == "")
                    MessageBox.Show("من فضلك اختر المتبرع");
                else
                {
                    بيانات_التمويل_لمتبرع_موجود nw = new بيانات_التمويل_لمتبرع_موجود(ID,bloodType,bloodFaction,RH);
                    nw.Show();
                    this.Close();
                }

                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void txtSupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }
    }
}
