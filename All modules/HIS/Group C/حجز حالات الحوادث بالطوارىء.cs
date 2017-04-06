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
    public partial class حجز_حالات_الحوادث_بالطوارىء : Form
    {
        Connection con = new Connection();
     
        int id;
      
        //MySqlCommand cmd;
        //MySqlCommand cmd1;
        //MySqlCommand cmd2;
        //MySqlConnection con;
        //MySqlDataReader dr;

       string doc_code;
        string day_name;
        string period;
        int cod_serv;
        string name_serv;
        string time_serv;
        
       // string doc_name;
        public حجز_حالات_الحوادث_بالطوارىء()
        {
            InitializeComponent();
        }
        public حجز_حالات_الحوادث_بالطوارىء(int s,string g)
        {
            InitializeComponent();
            id = s;
        }
        public حجز_حالات_الحوادث_بالطوارىء(string code, string day_n,string per ,string nam)
        {
            InitializeComponent();
           
        }
        public حجز_حالات_الحوادث_بالطوارىء(int cods_erve, string name_serve,string time_s)
        {
            InitializeComponent();

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            con.OpenConection();
            try
            {
               // con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc();
                //string s1 = "yes";
                //string s2 = "no";
                if (textBox10.Text != "" && textBox15.Text != "" && comboBox1.Text != "")
                {
                    string[] f = new string[] { "@d1", "@d2","@d3","@d4","@d5" ,"@d6","@d7","@d8","@d9"};
                    string[] f2 = new string[] {textBox1.Text, textBox10.Text, dateTimePicker2.Text, textBox18.Text, comboBox1.Text,
                     comboBox3.Text,comboBox4.Text,comboBox2.Text,textBox3.Text,comboBox3.Text};
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("blocks_Casess_Accidents1", f, f2, f3))
                    {
                        MessageBox.Show("تمت اضافة هذا المريض في هذا اليوم ");
                        return;
                    }
                    //string s3 = "insert into emergency_cases_accident_emergency"
                    //    + "(patients_id,account_number,accident_date,arrival_date,accident_kind,told_police,told_family,required_Told_police,telephone_number)"
                    //    + "values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";

                    //cmd = new MySqlCommand(s3, con);
                    //cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@d1", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@d2", textBox10.Text);
                    //cmd.Parameters.AddWithValue("@d3", dateTimePicker2.Text);
                    //cmd.Parameters.AddWithValue("@d4", textBox18.Text);
                    //cmd.Parameters.AddWithValue("@d5", comboBox1.SelectedItem);
                    //cmd.Parameters.AddWithValue("@d6", comboBox3.SelectedItem);
                    //cmd.Parameters.AddWithValue("@d7", comboBox4.SelectedItem);
                    //cmd.Parameters.AddWithValue("@d8", comboBox2.SelectedItem);
                    //cmd.Parameters.AddWithValue("@d9", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@d6",comboBox3.SelectedItem);
                    //cmd.ExecuteNonQuery();


                    //string s4 = "insert into emergency_cases_doctors(doctor_ode, per,ar_day,pati_code,arriv_dat)"
                    //    + "values(@x1,@x2,@x3,@x4,@x5)";
                    //cmd1 = new MySqlCommand(s4, con);
                    //cmd1.Parameters.AddWithValue("@x1", doc_code);

                    //cmd1.Parameters.AddWithValue("@x2", period);

                    //cmd1.Parameters.AddWithValue("@x3", day_name);

                    //cmd1.Parameters.AddWithValue("@x4", textBox1.Text);
                    //cmd1.Parameters.AddWithValue("@x5", textBox18.Text);

                    //cmd1.ExecuteNonQuery();
                    /*string s5 = "insert into  emergency_cases_services(serv_co,serv_nam,pati_code,arriv_dat)"
                        + "values(@v1,@v2,@v3,@v4)";


                    cmd2 = new MySqlCommand(s5, con);
                    cmd2.Parameters.AddWithValue("@v1", cod_serv);
                    cmd2.Parameters.AddWithValue("@v2", textBox16.Text);
                    cmd2.Parameters.AddWithValue("@v3", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@v4", textBox18.Text);
                     * 

                    cmd2.ExecuteNonQuery();
                     */



                    /*
                     * string name = "Qname"
                    string[] s = { "@x1", "@x2", "@x3", "@x4","@x5" };
                    string[] s2 = {doc_code, period, day_name, textBox1.Text,textBox18.Text};
                    SqlDbType[] s3 = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc(name, s, s2, s3);
                     //for textBox dt = (DataTable) con.ShowDataInGridViewUsingStoredProc(name, s, s2, s3);
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(name, s, s2, s3);
                     
                     */


                    string[] s = { "@x1", "@x2", "@x3", "@x4","@x5" };
                    string[] s2 = {doc_code, period, day_name, textBox1.Text,textBox18.Text};

                    SqlDbType[] s3 = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };


                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("blocks_casesses2_Acciden2", s, s2, s3))
                    {
                      //  MessageBox.Show("تمت اضافة هذا المريض في هذا اليوم ");
                        return;
                    }
                    
                    int pati_id = int.Parse(textBox1.Text);
                    string n = textBox2.Text;
                    int age = int.Parse(textBox5.Text);
                    int code_dir = int.Parse(textBox12.Text);
                    string dircto = textBox11.Text;
                    تاكيد_فتح_زياره_خارجي fr = new تاكيد_فتح_زياره_خارجي(pati_id, n, age, code_dir, dircto);
                    string[] m = { "@d" };
                    string[] m2 = {  textBox1.Text };
                    SqlDbType[] m3 = { SqlDbType.Int };

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("emergency_open_visit", m, m2, m3))
                    {
                        MessageBox.Show("قم بتسجيل زيارة للمريض اولا ");
                        return;
                    }

                    fr.Show();
                }
                else
                {
                    MessageBox.Show("قم بادخال البيانات كاملة");
                }
            }

            catch(Exception ){
                MessageBox.Show("تمت اضافة هذا المريض في هذا اليوم ");
            }
            con.CloseConnection();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void حجز_حالات_الحوادث_بالطوارىء_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            textBox18.Text = d.ToString("yyyy/MM/dd");
            //con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
            con.OpenConection();

            textBox1.Text = id.ToString();
            try
            {
                /*string s = 
                cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@d", id);
                string n = cmd.ExecuteScalar().ToString();
                textBox2.Text = n;
                //MM
                */
               /* SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                cmd.CommandText = "block_case_Accidents3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patient_id", id);
                cmd.Connection = sql;
                sql.Open();*/
                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox2.Text = con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents3", s, s2, s3).ToString();

                con.OpenConection();
                string[] s = new string[] { "@d" };
                string[] s2 = new string[] { id.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt= (DataTable)con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents3", s, s2, s3);
                textBox2.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();
                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_cases_Accidents3";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d",id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox2.Text = reader[0].ToString();
                //sql.Close();

              
            }
            catch(Exception ex){
                //MessageBox.Show(ex.Message);
            }
            try
            {
                //string s1 = "select communication_way_value from Registeration_patientRegisteration where patient_id=@d1;";
                //cmd = new MySqlCommand(s1, con);
                //cmd.Parameters.AddWithValue("@d1", id);
                //string n1 = cmd.ExecuteScalar().ToString();
                //textBox3.Text = n1;

                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox3.Text = con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents4", s, s2, s3).ToString();

                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_cases_Accidents4";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox3.Text = reader[0].ToString();
                //sql.Close();

                con.OpenConection();
                string[] s = new string[] { "@d" };
                string[] s2 = new string[] { id.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents4", s, s2, s3);
                textBox3.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            try
            {
                //string s2 = "select date_of_birth from Registeration_patientRegisteration where patient_id=@d2;";
                //cmd = new MySqlCommand(s2, con);
                //cmd.Parameters.AddWithValue("@d2", id);
                //string n2 = cmd.ExecuteScalar().ToString();
                //textBox4.Text = n2;

                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox4.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents5", s, s2, s3).ToString();


                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents5";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox4.Text = reader[0].ToString();
                //sql.Close();


                con.OpenConection();
                string[] s = new string[] { "@d" };
                string[] s2 = new string[] { id.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents5", s, s2, s3);
                textBox4.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //string s3 = "select age from Registeration_patientRegisteration where patient_id=@d3;";
                //cmd = new MySqlCommand(s3, con);
                //cmd.Parameters.AddWithValue("@d3", id);
                //string n3 = cmd.ExecuteScalar().ToString();
                //textBox5.Text = n3;
                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox5.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents6", s, s2, s3).ToString();

                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents6";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox5.Text = reader[0].ToString();
                //sql.Close();
                con.OpenConection();
                string[] s = new string[] { "@d" };
                string[] s2 = new string[] { id.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents6", s, s2, s3);
                textBox5.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();
            
              

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            try
            {
                //string s4 = "select identity_type from Registeration_patientRegisteration where patient_id=@d4;";
                //cmd = new MySqlCommand(s4, con);
                //cmd.Parameters.AddWithValue("@d4", id);
                //string n4= cmd.ExecuteScalar().ToString();
                //textBox6.Text = n4;

                string[] s = new string[] { "@d" };
                string[] s2 = new string[] { id.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                textBox6.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents7", s, s2, s3).ToString();



                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents7";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox6.Text = reader[0].ToString();
                //sql.Close();
                con.OpenConection();
                string[] f = new string[] { "@d" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents7", f, f2, f3);
                textBox6.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //string s5 = "select provinence_name from Registeration_patientRegisteration where patient_id=@d5;";
                //cmd = new MySqlCommand(s5, con);
                //cmd.Parameters.AddWithValue("@d5", id);
                //string n5 = cmd.ExecuteScalar().ToString();
                //textBox7.Text = n5;

                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox7.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents8", s, s2, s3).ToString();


                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents8";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox7.Text = reader[0].ToString();
                //sql.Close();

                con.OpenConection();
                string[] f = new string[] { "@d" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents8", f, f2, f3);
                textBox7.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //string s6 = "select country_name from Registeration_patientRegisteration where patient_id=@d6;";
                //cmd = new MySqlCommand(s6, con);
                //cmd.Parameters.AddWithValue("@d6", id);
                //string n6 = cmd.ExecuteScalar().ToString();
                //textBox8.Text = n6;
                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox8.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents9", s, s2, s3).ToString();



                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents9";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox8.Text = reader[0].ToString();
                //sql.Close();
                con.OpenConection();
                string[] f = new string[] { "@d" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents9", f, f2, f3);
                textBox8.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                //string s7 = "select name from  catogricals,Registeration_patientRegisteration where catogrical_code=catog_code and patient_id=@d7 ;";
                //cmd = new MySqlCommand(s7, con);
                //cmd.Parameters.AddWithValue("@d7", id);
                //string n7 = cmd.ExecuteScalar().ToString();
                //textBox9.Text = n7;
                //textBox11.Text = n7;

                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox8.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents10", s, s2, s3).ToString();


                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents10";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox9.Text = reader[0].ToString();
                //sql.Close();
                con.OpenConection();
                string[] f = new string[] { "@d" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents10", f, f2, f3);
                textBox9.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //string s7 = "select name from  catogricals,Registeration_patientRegisteration where catogrical_code=catog_code and patient_id=@d7 ;";
                //cmd = new MySqlCommand(s7, con);
                //cmd.Parameters.AddWithValue("@d7", id);
                //string n7 = cmd.ExecuteScalar().ToString();
                //textBox9.Text = n7;
                //textBox11.Text = n7;

                //string[] s = new string[] { "@d" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox8.Text = con.ShowDataInGridViewUsingStoredProc("block_case_Accidents10", s, s2, s3).ToString();


                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_case_Accidents10";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox11.Text = reader[0].ToString();
                //sql.Close();

                con.OpenConection();
                string[] f = new string[] { "@d" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_case_Accidents10", f, f2, f3);
                textBox11.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //string[] s = new string[] { "@d8" };
                //string[] s2 = new string[] { id.ToString() };
                //SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                //textBox12.Text = con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents122", s, s2, s3).ToString();



                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "block_cases_Accidents122";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d8", id);
                //cmd.Connection = sql;
                //sql.Open();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox12.Text = reader[0].ToString();
                //sql.Close();

                con.OpenConection();
                string[] f = new string[] { "@d8" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("block_cases_Accidents122", f, f2, f3);
                textBox12.Text = dt.Rows[0][0].ToString();
                con.CloseConnection();

            //    string s8 = "select catogrical_code from Registeration_patientRegisteration where patient_id=@d8 ;";
            // cmd = new MySqlCommand(s8, con);
            //    cmd.Parameters.AddWithValue("@d8", id);
            //    string n8 = cmd.ExecuteScalar().ToString();
            //    textBox12.Text = n8;
            //   // textBox11.Text = n8;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {

                //string s9 = " select diroctor_code from diroctorys,catogricals,Registeration_patientRegisteration where catog_code=catogrical_code and diroctor_code=dir_code and patient_id=@d9;";
                //cmd = new MySqlCommand(s9, con);
                //cmd.Parameters.AddWithValue("@d9", id);
                //string n9 = cmd.ExecuteScalar().ToString();
                //textBox13.Text = n9;
                //// textBox11.Text = n8;


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //try
            //{
            //    //string s10 = " select name_diroctory from diroctorys,catogricals,Registeration_patientRegisteration where catog_code=catogrical_code and diroctor_code=dir_code and patient_id=@d10;";
            //    //cmd = new MySqlCommand(s10, con);
            //    //cmd.Parameters.AddWithValue("@d10", id);
            //    //string n10 = cmd.ExecuteScalar().ToString();
            //    //textBox14.Text = n10;
            //    //// textBox11.Text = n8;


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
           }
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
            catch(Exception ex){
              MessageBox.Show(ex.Message);
            }
            ////con.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* عرض_خدمات_الطوارئ f = new عرض_خدمات_الطوارئ();


            if (f.ShowDialog() == DialogResult.OK)
            {
                
                cod_serv = int.Parse(عرض_خدمات_الطوارئ.Code1.ToString());
                name_serv = عرض_خدمات_الطوارئ.name.ToString();
                time_serv = عرض_خدمات_الطوارئ.peri.ToString();
                textBox16.Text = name_serv+"";
                textBox17.Text = time_serv+"";

                
            }*/
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            عرض_أطباء_الطوارئ f = new عرض_أطباء_الطوارئ();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = عرض_أطباء_الطوارئ.name.ToString();
                //textBox15.Text = doc_name;
                day_name = عرض_أطباء_الطوارئ.day.ToString();
                period = عرض_أطباء_الطوارئ.per.ToString();
                doc_code = عرض_أطباء_الطوارئ.Code1.ToString();

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox10.Text, out number2))
            {

            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

       
    }
}
