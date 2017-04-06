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
    public partial class تنفيذ_خطة_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();
       // SqlConnection con = new SqlConnection(@"Server=AHMEDHKHALIFA\SQLEXPRESS;Database=physiotherapy;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public تنفيذ_خطة_العلاج_الطبيعى()
        {
            InitializeComponent();
            fill_Visit1();
        }

        private void تنفيذ_خطة_العلاج_الطبيعى_Load(object sender, EventArgs e)
        {   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int device_code = int.Parse(comboBox3.SelectedValue.ToString());
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@Device_code";
                pramvalue[0] = device_code.ToString() ;
                pramtype[0] = SqlDbType.Int;
                con.OpenConection();
                dt.Clear();
                object x = new object();
                x = con.ShowDataInGridViewUsingStoredProc("physiotherapy_execute_plan_select", pramname, pramvalue, pramtype); ;
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
        }
        private void fill_Visit1()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                con.OpenConection();
                string query = @"SELECT Device_code, Arabic_name FROM dbo.physiotherapy_Devices";

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

    }
}
