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
    public partial class كشف_خدمات_المريض : Form
    {
        Connection con = new Connection();
        //MySqlConnection con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
        //MySqlCommand cmd;
        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        //BindingSource bs;
        //MySqlDataReader dr;
        public كشف_خدمات_المريض()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          محرك_البحث_عن_مريض_تقرير f = new محرك_البحث_عن_مريض_تقرير();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = محرك_البحث_عن_مريض_تقرير.Code1.ToString();
                textBox2.Text = محرك_البحث_عن_مريض_تقرير.name.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();

            if ((checkBox1.Checked == true && textBox1.Text == ""))
            {
                string[] s = new string[] { "@date1", "@date2" };
                string[] s2 = new string[] { d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report2_discover_services", s, s2, s3);
                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and  arrival_date between @date1 and @date2", con);

                //    cmd.Parameters.AddWithValue("@date1", d);
                //    cmd.Parameters.AddWithValue("@date2", d2);

                //    //da.SelectCommand = cmd;

                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    //con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else if (textBox1.Text != "" && checkBox1.Checked == false)
            {

                string[] s = new string[] { "@pi" };
                string[] s2 = new string[] { textBox1.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report2_discover_service2", s, s2, s3);
            //try
            //{
            //    ds.Tables.Clear();
            //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and patients_id =@pi", con);

            //    cmd.Parameters.AddWithValue("@pi",textBox1.Text);
            //   // cmd.Parameters.AddWithValue("@date2", d2);

            //    //da.SelectCommand = cmd;

            //    da = new MySqlDataAdapter(cmd);
            //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //    da.Fill(ds);
            //    bs = new BindingSource();
            //    bs.DataSource = ds.Tables[0];
            //    dataGridView1.DataSource = bs;
            //    //con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            }
            else if (textBox1.Text != "" && checkBox1.Checked == true)
            {

                string[] s = new string[] { "@pi", "@date1", "@date2" };
                string[] s2 = new string[] { textBox1.Text, d, d2 };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report2_discover_service3", s, s2, s3);

                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and patients_id =@pi and arrival_date between @date1 and @date2", con);

                //    cmd.Parameters.AddWithValue("@pi", textBox1.Text);
                //    cmd.Parameters.AddWithValue("@date1", d);
                //    cmd.Parameters.AddWithValue("@date2", d2);

                //    // cmd.Parameters.AddWithValue("@date2", d2);

                //    //da.SelectCommand = cmd;

                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    //con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else
            {
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report2_discover_service4");

                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code ", con);

                   
                //    // cmd.Parameters.AddWithValue("@date2", d2);

                //    //da.SelectCommand = cmd;

                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    //con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
            dataGridView1.DataSource = null;
          //  ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
          

        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void كشف_خدمات_المريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }
    }
}
