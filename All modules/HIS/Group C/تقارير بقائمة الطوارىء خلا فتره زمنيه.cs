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
    public partial class تقارير_بقائمة_الطوارىء_خلا_فتره_زمنيه : Form
    {

        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        //MySqlConnection con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
        //MySqlCommand cmd;
        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        //BindingSource bs;
        //MySqlDataReader dr;
        public تقارير_بقائمة_الطوارىء_خلا_فتره_زمنيه()
        {
            InitializeComponent();
        }

        private void تقارير_بقائمة_الطوارىء_خلا_فتره_زمنيه_Load(object sender, EventArgs e)
        {
            con.OpenConection();


            try
            {

                ////    cmd = new MySqlCommand("select acc_arabic_name from emergency_accident_kinds", con);
                ////    dr = cmd.ExecuteReader();

                ////    while (dr.Read())
                ////    {

                ////        comboBox1.Items.Add(dr["acc_arabic_name"]);

                ////    }
                //    dr.Close();
                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("emergency_acc_kind");
                comboBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

             
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();

            if ((checkBox1.Checked == true &&comboBox1.Text==""))
            {
                string[] s = new string[] { "@date1", "@date2"};
                string[] s2 = new string[] { d, d2};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report1_frist_search",s,s2,s3);
                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and arrival_date between @date1 and @date2",con);

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
                //catch(Exception ex){
                //    MessageBox.Show(ex.Message);
                //}
            }
            else if(comboBox1.Text!=""&&checkBox1.Checked==false){
                string[] s = new string[] { "@acc" };
                string[] s2 = new string[] {comboBox1.Text};
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report1_second_search", s, s2, s3);
                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and accident_kind =@acc", con);

                //    cmd.Parameters.AddWithValue("@acc",comboBox1.SelectedItem);

                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;

                //}
                //catch(Exception ex){
                //    MessageBox.Show(ex.Message);
                //}
            }


            else if (comboBox1.Text != ""&&checkBox1.Checked == true)
            {
                //try
                //{
                    string[] s = new string[] { "@acc","@date1","@date2" };
                    string[] s2 = new string[] { comboBox1.Text,d,d2};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report1_third_search", s, s2, s3);
                    //ds.Tables.Clear();
                    //cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and accident_kind =@acc and arrival_date between @date1 and @date2", con);

                    //cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
                    //cmd.Parameters.AddWithValue("@date1", d);
                    //cmd.Parameters.AddWithValue("@date2", d2);


                    //da = new MySqlDataAdapter(cmd);
                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    //con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            //else if (textBox6.Text!=""&&comboBox1.Text==""&&checkBox1.Checked==false)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and name=@ddd", con);

            //        //cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
            //        cmd.Parameters.AddWithValue("@ddd", textBox6.Text);
            //        //cmd.Parameters.AddWithValue("@date2", d2);


            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (textBox6.Text != "" && comboBox1.Text == "" && checkBox1.Checked == true)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and name=@ddd and arrival_date between @date1 and @date2", con);

            //        cmd.Parameters.AddWithValue("@date1", d);
            //        cmd.Parameters.AddWithValue("@date2", d2);

            //        //cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
            //        cmd.Parameters.AddWithValue("@ddd", textBox6.Text);
            //        //cmd.Parameters.AddWithValue("@date2", d2);


            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (textBox6.Text != "" && comboBox1.Text != "" && checkBox1.Checked ==false)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and name=@ddd and accident_kind =@acc", con);

            //       // cmd.Parameters.AddWithValue("@date1", d);
            //        //cmd.Parameters.AddWithValue("@date2", d2);

            //       cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
            //        cmd.Parameters.AddWithValue("@ddd", textBox6.Text);
            //        //cmd.Parameters.AddWithValue("@date2", d2);


            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (textBox6.Text != "" && comboBox1.Text != "" && checkBox1.Checked == true)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code and name=@ddd and accident_kind =@acc and arrival_date between @date1 and @date2", con);

            //       cmd.Parameters.AddWithValue("@date1", d);
            //       cmd.Parameters.AddWithValue("@date2", d2);

            //        cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
            //        cmd.Parameters.AddWithValue("@ddd", textBox6.Text);
            //        //cmd.Parameters.AddWithValue("@date2", d2);


            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            else  
            {
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report1_8_searc");
  
                //try
                //{
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',date_of_birth as 'تاريخ الميلاد',gender as 'النوع',name as 'الجهه',date_Regist as 'تاريخ التسجيل',arrival_date as 'تاريخ الوصول' from Registeration_patientRegisteration,emergency_cases_accident_emergency,catogricals where patient_id=patients_id and catog_code=catogrical_code ", con);

                //    //cmd.Parameters.AddWithValue("@acc", comboBox1.SelectedItem);
                //    cmd.Parameters.AddWithValue("@ddd", textBox6.Text);
                //    //cmd.Parameters.AddWithValue("@date2", d2);


                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }

            con.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
           // textBox6.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }


        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
