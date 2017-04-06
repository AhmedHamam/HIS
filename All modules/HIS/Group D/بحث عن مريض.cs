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
    public partial class opForm07 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        Connection connect;
        public opForm07()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void opForm07_Load(object sender, EventArgs e)
        {
        }

        private void textBox_patient_code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();


                if (textBox_patient_code.Text != "")
                { // da = new SqlDataAdapter("select * from Registeration_patientRegisteration where patient_id like '" + textBox_patient_code.Text + "%'", con);
                    string pName = "op_patient_searc1";
                    string[] paramNames = { "@patient_id" };
                    string[] paramValues = { textBox_patient_code.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                }
                else
                {
                    string pName = "op_patient_searc2";
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        

        private void textBox_patient_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                if (textBox_patient_name.Text != "")
                { // da = new SqlDataAdapter("select * from Registeration_patientRegisteration where patient_id like '" + textBox_patient_code.Text + "%'", con);
                    string pName = "op_patient_searc3";
                    string[] paramNames = { "@patient_name" };
                    string[] paramValues = { textBox_patient_name.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                }
                else
                {
                    string pName = "op_patient_searc2";
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
