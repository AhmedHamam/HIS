using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class عمل_خطة_علاجية_لمريض : Form
    {
        Connection con = new Connection();
     // SqlConnection con = new SqlConnection(@"Server=AHMEDHKHALIFA\SQLEXPRESS;Database=physiotherapy;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public int phys_pat_code;
        public int phys_emp_code;
        public عمل_خطة_علاجية_لمريض()
        {
            InitializeComponent();
            fill_Visit();
            fill_Visit1();
        }


        private void عمل_خطة_علاجية_لمريض_Load(object sender, EventArgs e)
        {
 

              }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();







                int service_code = int.Parse(comboBox3.SelectedItem.ToString());
                int deviceCode =int.Parse(comboBox4.SelectedValue.ToString());

                string[] pramname = new string[5];
                string[] pramvalue = new string[5];
                SqlDbType[] pramtype = new SqlDbType[5];
                pramname[0] = "@physiotherapy_patient_code";
                pramname[1] = "@Device_code";
                pramname[2] = "@plan_start";
                pramname[3] = "@plan_end";
                pramname[4] = "@session_number";
                pramvalue[0] = phys_pat_code.ToString();
                pramvalue[1] = deviceCode.ToString();
                pramvalue[2] = dateTimePicker1.Value.ToString();
                pramvalue[3] = dateTimePicker2.Value.ToString();
                pramvalue[4] = numericUpDown1.Value.ToString();
                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.Date;
                pramtype[3] = SqlDbType.Date;
                pramtype[4] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Treatment_Plan", pramname, pramvalue, pramtype);
                cmd = new SqlCommand("select plan_code from physiotherapy_Treatment_Plan where physiotherapy_patient_code=" + phys_pat_code, con.returnObject());
                String x=cmd.ExecuteScalar().ToString();
                int plan_code=int.Parse(x);
                string[] pramname1 = new string[2];
                string[] pramvalue1 = new string[2];
                SqlDbType[] pramtype1 = new SqlDbType[2];
                pramname1[0] = "@service_code";
                pramname1[1] = "@plan_code";
                pramvalue1[0] = service_code.ToString();
                pramvalue1[1] = plan_code.ToString();
                pramtype1[0] = SqlDbType.Int;
                pramtype1[1] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Treatment_Plan2", pramname1, pramvalue1, pramtype1);
                string[] pramname2 = new string[2];
                string[] pramvalue2 = new string[2];
                SqlDbType[] pramtype2 = new SqlDbType[2];
                pramname2[0] = "@doc_code";
                pramname2[1] = "@plan_code";
                pramvalue2[0] = phys_emp_code.ToString();
                pramvalue2[1] = plan_code.ToString();
                pramtype2[0] = SqlDbType.VarChar;
                pramtype2[1] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Treatment_Plan3", pramname2, pramvalue2, pramtype2);

                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void fill_Visit()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                con.OpenConection();
                string query = @"SELECT        SLS_id, SLS_Aname
                                FROM            tb_Second_Level_Service
                                WHERE        (SLS_Service_Category = 'Physiotherapy') AND (SLS_Status = 1)";

                dr = con.DataReader(query);
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                    comboBox1.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = comboBox2.SelectedIndex;
        }
        private void fill_Visit1()
        {
            try
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                comboBox4.Items.Clear();
                comboBox4.Text = "";
                con.OpenConection();
                string query = @"SELECT Device_code, Arabic_name FROM dbo.physiotherapy_Devices";

                dr = con.DataReader(query);
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr[0].ToString());
                    comboBox2.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
          
    }
}