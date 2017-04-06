using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class move_servisce : Form
    {

        SqlConnection con ;
       
        public move_servisce()
        {
            
            InitializeComponent();
            Connection conn = new Connection();
            string constr = conn.getconstr();
            con = new SqlConnection(constr);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection mycon = new Connection();
            mycon.OpenConection();
            //con.Open();

            string[] pname = {"@id_dif"};
            string[] pvalue = {textBox3.Text};
            SqlDbType[] ptype = {SqlDbType.Int};

            DataTable dt = (DataTable)mycon.ShowDataInGridViewUsingStoredProc("p10", pname, pvalue, ptype);
            //SqlDataReader dr = dt.CreateDataReader();
            for (int i = 0; i < dt.Rows.Count;i++ )
            {

                comboBox1.Items.Add(dt.Rows[i].ItemArray[i].ToString());

            }
            mycon.CloseConnection();
           // rd.Close();

            /*
            conn.Open();
              
            SqlDataReader rd;

            conn.Open();
           SqlCommand cmd = new SqlCommand("p10", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_dif", textBox3.Text);
            //string s = "select select all from differentservices where id_differentservices ="+textBox3.Text+" ;";
            //SqlCommand cmd = new SqlCommand(s, conn);

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                comboBox1.Items.Add(rd["select all"]);

            }

            rd.Close();
            rd.Dispose();
            conn.Close();*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            SqlCommand cmd = new SqlCommand("p10",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@lac_id", textBox3.Text);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = dr["arabic name"].ToString();
            dr.Close();
            con.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
