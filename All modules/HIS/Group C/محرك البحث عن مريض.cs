﻿using System;
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
    public partial class محرك_البحث_عن_مريض : Form
    {
        Connection con = new Connection();
        int id;
        //MySqlCommand cmd2;
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataAdapter da;
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //BindingSource bs;
        //// BindingSource bs2;
        //MySqlDataAdapter da2;
        //DataSet ds2 = new DataSet();
        //MySqlCommand cmd3;
        //MySqlDataReader dr;
        int count = 0;
        int count2 = 0;
        int code1;
        public محرك_البحث_عن_مريض()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            // ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            count = 0;
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void محرك_البحث_عن_مريض_Load(object sender, EventArgs e)
        {

           // con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    dataGridView1.DataSource = null;
        //    dt.Rows.Clear();
        //    dataGridView1.Refresh();
        //    dataGridView1.Rows.Clear();
        //    con.Open();
        //    cmd3 = new MySqlCommand("select count(*) from Registeration_patientRegisteration;", con);
        //    count2 = int.Parse(cmd3.ExecuteScalar().ToString());
        //    textBox4.Text = count2.ToString();
        //    //  textBox5.Text = count.ToString();
        //    con.Close();
            // SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            //SqlConnection sql = new SqlConnection(@"Server=HanadyKhalifa; DataBase=PHIS; Integrated Security=true;");
            //cmd.CommandText = "search_patient1";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Connection = sql;
            //sql.Open();
            //reader = cmd.ExecuteReader();
            //while(reader.Read())
            //textBox4.Text = reader[0].ToString();
            //sql.Close();
            con.OpenConection();
            DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1");
            textBox4.Text = dt.Rows[0][0].ToString();
            con.CloseConnection();
            if (textBox1.Text != "" && textBox3.Text == "")
            {
                try
                {
                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient2", s, s2, s3);

                    //string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_id=@x";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@x", Int32.Parse(textBox1.Text));

                    //dr = cmd.ExecuteReader();

                    //dt.Load(dr);

                    //dataGridView1.DataSource = dt;


                    //dr.Close();
                    //string s1 = "select visit_id ,entrance_date  from entranceoffice_visit,Registeration_patientRegisteration where pat_id=patient_id and pat_id=@x;";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@x", Int32.Parse(textBox1.Text));
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();
                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox1.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient4", s, s2, s3);


                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else if (textBox3.Text != "" && textBox1.Text == "")
            {
                try
                {
                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient5", s, s2, s3);

                    //    con.Open();

                    //    string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_name=@x";
                    //    cmd = new MySqlCommand(s, con);
                    //    cmd.Parameters.AddWithValue("@x", textBox3.Text);
                    //    dr = cmd.ExecuteReader();
                    //    dt.Load(dr);
                    //    dataGridView1.DataSource = dt;
                    // dr.Close();

                    //string s1 = "select code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code=visit_code and patient_name=@x";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@x", textBox3.Text);
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();

                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox3.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3);


                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else if (textBox3.Text != "" && textBox1.Text == "")
            {
                try
                {
                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient5", s, s2, s3);

                    //    con.Open();

                    //    string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_name=@x";
                    //    cmd = new MySqlCommand(s, con);
                    //    cmd.Parameters.AddWithValue("@x", textBox3.Text);
                    //    dr = cmd.ExecuteReader();
                    //    dt.Load(dr);
                    //    dataGridView1.DataSource = dt;
                    // dr.Close();

                    //string s1 = "select code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code=visit_code and patient_name=@x";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@x", textBox3.Text);
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();

                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox3.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3);


                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                try
                {

                    con.OpenConection();
                    string[] s = new string[] { "@x", "@y" };
                    string[] s2 = new string[] { textBox3.Text, textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient7", s, s2, s3);

                    //con.Open();
                    //string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_name=@x and patient_id=@y";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@y", Int32.Parse(textBox1.Text));
                    //cmd.Parameters.AddWithValue("@x", textBox3.Text);
                    //dr = cmd.ExecuteReader();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt
                    //dr.Close();

                    //string s1 = "select code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code=visit_code and patient_name=@x and patient_id=@y";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@y", Int32.Parse(textBox1.Text));
                    //cmd1.Parameters.AddWithValue("@x", textBox3.Text);
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();

                    string[] f = new string[] { "@x", "@y" };
                    string[] f2 = new string[] { textBox3.Text, textBox1.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient8", f, f2, f3);



                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else
            {
                try
                {

                    con.OpenConection();
                    //    con.Open();
                    //    string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration";
                    //    cmd = new MySqlCommand(s, con);
                    //    dr = cmd.ExecuteReader();

                    //    dt.Load(dr);
                    //    dataGridView1.DataSource = dt;

                    //    dr.Close();

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient10");


                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient9");





                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox1.Text, out number2))
            {

            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox1.Text = null;
                return;
            }//string validation

           //string validation
            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[\u0621-\u064A\040]+$"))
            //{
            //    MessageBox.Show("This textbox accepts only alphabetical characters");
            //    //textBox3.Text.Remove(textBox3.Text.Length - 1);
            //}

        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            //if (checkBox1.Checked == true)
            //{
            //    panel7.Show();

            //}
            //else
            //{
            //    panel7.Hide();

            //}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

     /*   private void fill(object sender, DataGridViewCellMouseEventArgs e)
        {


           // MessageBox.Show("asad");
            string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            id = int.Parse(a);
            string b = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string c = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            // h = int.Parse(c);
            حجز_حالات_الحوادث_بالطوارىء d = new حجز_حالات_الحوادث_بالطوارىء(id, b);
            d.Show();

        }
        */

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show("asad");
            // MessageBox.Show("asad");
            try
            {
                string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                id = int.Parse(a);
                string b = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string c = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                // h = int.Parse(c);
                حجز_حالات_الحوادث_بالطوارىء d = new حجز_حالات_الحوادث_بالطوارىء(id, b);
                d.Show();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            تسجيل_بيانات__مريض f = new تسجيل_بيانات__مريض();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            تعديل_بيانات_مريض f = new تعديل_بيانات_مريض();
            f.Show();

        }

       
    }
}
