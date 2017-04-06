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
    public partial class الحجز_بعد_الموافقه : Form
    {
        Connection con = new Connection();
        //MySqlDataAdapter da;
        //DataSet ds = new DataSet();
        //MySqlCommand cmd;
        //MySqlConnection con;
        //DataTable dt;
        //BindingSource bs;
        public الحجز_بعد_الموافقه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patients_visits f = new patients_visits();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = patients_visits.Code1.ToString();
               // textBox1.Text = patients_visits.Code2.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker4.Text.ToString();
            string d2 = dateTimePicker3.Text.ToString();

            if ((textBox15.Text!="" &&textBox1.Text==""&&checkBox1.Checked==false))
      
            {
                try
                {
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] {textBox15.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reservation_after_accept1", s, s2, s3);
                  //  ds.Tables.Clear();
                  //  cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and pat_id=" + int.Parse(textBox15.Text) + ";", con);

                  ////  cmd.Parameters.AddWithValue("@date1", d);
                  ////  cmd.Parameters.AddWithValue("@date2", d2);

                  //  //da.SelectCommand = cmd;

                  //  da = new MySqlDataAdapter(cmd);
                  //  MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                  //  da.Fill(ds);
                  //  bs = new BindingSource();
                  //  bs.DataSource = ds.Tables[0];
                  //  dataGridView1.DataSource = bs;
                    //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((textBox1.Text != "" &&textBox15.Text==""&&checkBox1.Checked==false))
            {
                try
                {

                    string[] s = new string[] { "@y" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reservation_after_accept2", s, s2, s3);
                    //ds.Tables.Clear();

                    //cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and catogrical_code=" + int.Parse(textBox1.Text) + ";", con);

                    ////  cmd.Parameters.AddWithValue("@date1", d);
                    ////  cmd.Parameters.AddWithValue("@date2", d2);

                    ////da.SelectCommand = cmd;

                    //da = new MySqlDataAdapter(cmd);
                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    ////con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (checkBox1.Checked == true && textBox1.Text == ""&&textBox15.Text=="")
            {
                try
                {

                    string[] s = new string[] { "@x","@y" };
                    string[] s2 = new string[] {d,d2 };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reservation_after_accept3", s, s2, s3);
                   // ds.Tables.Clear();

                   // cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and entrance_date between '" + dateTimePicker4.Text + "' and '" + dateTimePicker3.Text + "';", con);

                   //// cmd.Parameters.AddWithValue(" @date1", d);
                   // //cmd.Parameters.AddWithValue(" @date2", d2);

                   // //da.SelectCommand = cmd;

                   // da = new MySqlDataAdapter(cmd);
                   // MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                   // da.Fill(ds);
                   // bs = new BindingSource();
                   // bs.DataSource = ds.Tables[0];
                   // dataGridView1.DataSource = bs;
                   // //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //else if (textBox1.Text !="" && textBox15.Text!=""&& checkBox1.Checked == false)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and  pat_id=" + int.Parse(textBox15.Text) + " and catogrical_code=" + int.Parse(textBox1.Text) + ";", con);

            //        //  cmd.Parameters.AddWithValue("@date1", d);
            //        //  cmd.Parameters.AddWithValue("@date2", d2);

            //        //da.SelectCommand = cmd;

            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        //con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (textBox15.Text != "" && textBox1.Text == "" && checkBox1.Checked == true)
            //{
            //    try
            //    {
            //        ds.Tables.Clear();
            //        cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and  pat_id=" + int.Parse(textBox15.Text) + " and entrance_date between '" + dateTimePicker4.Text + "' and '" + dateTimePicker3.Text + "';", con);

            //        //  cmd.Parameters.AddWithValue("@date1", d);
            //        //  cmd.Parameters.AddWithValue("@date2", d2);

            //        //da.SelectCommand = cmd;

            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        //con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if ((textBox1.Text != "" && textBox15.Text == "" && checkBox1.Checked == true))
            //{
            //    try
            //    {
            //        ds.Tables.Clear();

            //        cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and catogrical_code=" + int.Parse(textBox1.Text) +  " and entrance_date between '" + dateTimePicker4.Text + "' and '" + dateTimePicker3.Text + "';", con);

            //        //  cmd.Parameters.AddWithValue("@date1", d);
            //        //  cmd.Parameters.AddWithValue("@date2", d2);

            //        //da.SelectCommand = cmd;

            //        da = new MySqlDataAdapter(cmd);
            //        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //        da.Fill(ds);
            //        bs = new BindingSource();
            //        bs.DataSource = ds.Tables[0];
            //        dataGridView1.DataSource = bs;
            //        //con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            else if ((textBox1.Text != "" && textBox15.Text != "" && checkBox1.Checked == true))
            {
                try
                {

                    string[] s = new string[] { "@x","@m","@l", "@y" };
                    string[] s2 = new string[] { textBox1.Text,d, d2,textBox15.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reservation_after_accept4", s, s2, s3);
                    //ds.Tables.Clear();

                    //cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code and catogrical_code=" + int.Parse(textBox1.Text) + " and entrance_date between '" + dateTimePicker4.Text + "' and '" + dateTimePicker3.Text + "'and pat_id=" + int.Parse(textBox1.Text) + ";", con);

                    ////  cmd.Parameters.AddWithValue("@date1", d);
                    ////  cmd.Parameters.AddWithValue("@date2", d2);

                    ////da.SelectCommand = cmd;

                    //da = new MySqlDataAdapter(cmd);
                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    ////con.Close();
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
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("reservation_after_accept5");
                    //ds.Tables.Clear();

                    //cmd = new MySqlCommand("select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,catogrical_code from entranceoffice_visits,Registeration_patientRegisteration,catogricals  where patient_id=pat_id and catog_code=catogrical_code ", con);

                    ////  cmd.Parameters.AddWithValue("@date1", d);
                    ////  cmd.Parameters.AddWithValue("@date2", d2);

                    ////da.SelectCommand = cmd;

                    //da = new MySqlDataAdapter(cmd);
                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    ////con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void الحجز_بعد_الموافقه_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
            con.OpenConection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            catogrical_reservation f = new catogrical_reservation();



            if (f.ShowDialog() == DialogResult.OK)
            {
                // textBox2.Text = categorical.Code1.ToString();
                textBox1.Text = catogrical_reservation.Code1.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
          //  ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox15.Text = "";
            textBox1.Text = "";
            checkBox1.Checked = false;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
