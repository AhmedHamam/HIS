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
    public partial class تسجيل_بيانات__مريض : Form
    {
        
        Connection con = new Connection();
        SqlDataReader dr;
        //MySqlCommand cmd;
        //MySqlCommand cmd1;
        SqlDataReader dr1;
        //MySqlConnection con;
        //MySqlCommand cmd4;
        //MySqlCommand cmd5;
        public تسجيل_بيانات__مريض()
        {
            InitializeComponent();
        }


        public تسجيل_بيانات__مريض(int d)
        {
            InitializeComponent();
            textBox2.Text = d.ToString();
            textBox3.Text = d.ToString();
        }

        public تسجيل_بيانات__مريض(int f, int w)
        {
            InitializeComponent();
            textBox19.Text = f.ToString();
            textBox18.Text = w.ToString();
        }
      /*  public void setvalue(string x, string y)
        {
            textBox11.Text = x;
            textBox1.Text = y;
        }*/
        public void setvalue2(string x)
        {
            textBox16.Text = x;
        }

        public void setvalues(int id, String name, String identity_type,string gender,string address,string comm_way,string dateb)
        {
            textBox5.Text = id.ToString();
            textBox6.Text = name;
            textBox4.Text = identity_type;
            comboBox20.Text = gender;
            textBox25.Text = address;
            textBox22.Text = comm_way;
            textBox1.Text = dateb;

        }
        private void تسجيل_بيانات__مريض_Load(object sender, EventArgs e)
        {


           

           





            DateTime d = DateTime.Now;
            textBox16.Text = d.ToString("yyyy/MM/dd");
            // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
            /*  if (textBox5.Text == "")
              {
                  textBox5.Text = 1+ "";
              }
              else
              {*/
            con.OpenConection();
            try
            {
                //////////نوع الهويه
                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("identity_type");
                comboBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());

                //////////الوظيفة

              // DataTable dt= new DataTable();

                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("setting_Of_nickname");
                comboBox16.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox16.Items.Add(dt.Rows[i][1].ToString());
                /////////////////// البلاد
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("country_in");
                comboBox12.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox12.Items.Add(dt.Rows[i][0].ToString());
                ///////////province


                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("prov_in");
                comboBox14.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox14.Items.Add(dt.Rows[i][0].ToString());



                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("findpatientId");

                string st = "0";
                if (dt.Rows.Count > 0)
                    st = dt.Rows[dt.Rows.Count - 1][0].ToString();
                st = (Convert.ToInt16(st) + 1).ToString();
                textBox5.Text = st;
            }
            catch (Exception )
            {
                textBox5.Text = 1 + "";

          
               

              //  dr.Close();
                /* con.Close();
             }*/
                
                //     con.CloseConnection();
                //     con.OpenConection();
                //     cmd1 = new MySqlCommand("select english_description from Registeration_settingOfNicknamePatient", con);
                //     dr1 = cmd1.ExecuteReader();
                //     while (dr1.Read())
                //     {

                //         comboBox16.Items.Add(dr1["english_description"]);

                //     }

                //     dr1.Close();
                //     con.CloseConnection();

                //     MySqlCommand cmd3;
                //     MySqlDataReader dr3;
                //     con.OpenConection();
                //     cmd3 = new MySqlCommand("select county_name from country", con);
                //     dr3 = cmd3.ExecuteReader();

                //     while (dr3.Read())
                //     {

                //         comboBox12.Items.Add(dr3["county_name"]);

                //     }


                //     dr3.Close();
                //     con.close


                //     MySqlCommand cmd4;
                //     MySqlDataReader dr4;
                //     con.Open();
                //     cmd4 = new MySqlCommand("select name_province from province", con);
                //     dr4 = cmd4.ExecuteReader();

                //     while (dr4.Read())
                //     {

                //         comboBox14.Items.Add(dr4["name_province"]);
                //         comboBox4.Items.Add(dr4["name_province"]);
                //     }


                //     dr4.Close();
                //con.CloseConnection();

            }
        }

        public void setvalue(string x, string y)
        {
            textBox1.Text = x;
            textBox15.Text = y;

        }
       
    

    

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee ob = new employee();
            if (ob.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = employee.Code1.ToString();
                textBox2.Text = employee.Code2.ToString();
            }
        }

   

        private void اضافهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            //textBox5.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
            comboBox20.Text = "";
            textBox11.Text = "";
            textBox1.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            //  textBox12.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox21.Text = "";
            textBox25.Text = "";
            comboBox9.Text = "";
            textBox22.Text = "";
            comboBox12.Text = "";
            comboBox14.Text = "";
            comboBox2.Text = "";
            comboBox6.Text = "";
            comboBox16.Text = "";
            comboBox17.Text = "";
            textBox15.Text = "";
            //textBox16.Text = "";
           // textBox20.Text = "";
            textBox19.Text = "";
            textBox17.Text = "";
            //textBox16.Text = "";
            // textBox13.Text = "";
           // radioButton1.Checked = false;
//radioButton2.Checked = false;
            textBox21.Text = "";
            textBox6.Text = "";
           // con.OpenConection();
            try
            {










                /*cmd = new MySqlCommand("select max(patient_id) from Registeration_patientRegisteration;", con);
               int c2 = int.Parse(cmd5.ExecuteScalar().ToString());
                int p_id1 = c2 + 1;
                textBox5.Text = p_id1.ToString();
                con.OpenConection();*/
               
                //DataTable dt = new DataTable();
                //dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("findpatientId");
                
                //string st="0";
                //if(dt.Rows.Count>0)
                //    st=dt.Rows[dt.Rows.Count-1][0].ToString();

                //st = (Convert.ToInt16(st) + 1).ToString();
                //textBox5.Text = st ;
            }
            catch(Exception ){
                textBox5.Text = 1 + "";
            }
            con.CloseConnection();
        }

        
             private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {


           

        }

        private void button3_Click(object sender, EventArgs e)
        {
             البطاقة_العلاجية1 f = new البطاقة_العلاجية1();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            اعدادات_الامراض_المزمنة_والمعدية f = new اعدادات_الامراض_المزمنة_والمعدية();
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        { 
            نوع_الهوية  d=new نوع_الهوية();
            d.Show();
        
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //textBox4.Text = comboBox1.SelectedItem.ToString();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox8.Text + " " + textBox9.Text + " " + textBox10.Text + " " + textBox7.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            birthdate f = new birthdate(this);
            f.Show();
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            grad_date f = new grad_date(this);
            f.Show();
        
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            فئة_المريض_1 ob = new فئة_المريض_1();
            if (ob.ShowDialog() == DialogResult.OK)
            {
                textBox19.Text = فئة_المريض_1.Code.ToString();
                textBox18.Text = فئة_المريض_1.Code2.ToString();
            };

        }

        private void button5_Click(object sender, EventArgs e)
        {
            grad_date d = new grad_date(this);
            d.Show();
        }

      

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }


        public void asd(string x)
        {
            textBox11.Text = x;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            employee ob = new employee();
            if (ob.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = employee.Code1.ToString();
                textBox2.Text = employee.Code2.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            //textBox22.Text = comboBox9.SelectedItem.ToString();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBox22.Text = comboBox9.SelectedItem.ToString();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text)
                 || string.IsNullOrEmpty(textBox25.Text))
            {
                MessageBox.Show("قم باكمال البيانات");
                return;
            }
            // try
            {
                con.OpenConection();
                try
                {
                   //int d = int.Parse(textBox15.Text);

                    //int d1 = Int32.Parse(textBox19.Text);
                     string[] s = new string[] {"@em", "@iden", "@pnam", "@gen", "@dob", "@pob", "@ag",
                        "@datreg", "@ms", "@catcod", "@addw", "@addp", "@comwn", "@comwv", "@conn", 
                        "@prov", "@vill", "@nat", "@rel", "@jo", "@qual", "@gdat" };

                     string[] s2 = new string[] {textBox3.Text,textBox4.Text,textBox6.Text,comboBox20.Text,textBox1.Text,comboBox4.Text,textBox15.Text,
                       textBox16.Text,comboBox5.Text,textBox19.Text,textBox21.Text,textBox25.Text,comboBox9.Text,textBox22.Text,comboBox12.Text,
                       comboBox14.Text,textBox17.Text,comboBox2.Text,comboBox6.Text,comboBox16.Text,comboBox17.Text,textBox11.Text};

                     SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,
                       SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,
                       SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar};
                 // string[] s2 = new string[] { textBox3.Text.ToString(), textBox4.Text, textBox6.Text, comboBox20.Text, textBox1.Text, comboBox4.Text, d.ToString(), textBox16.Text, comboBox5.Text, d1.ToString(), textBox21.Text, textBox25.Text, comboBox9.Text, textBox22.Text, comboBox12.Text, comboBox14.Text, textBox17.Text, comboBox2.Text, comboBox6.Text, comboBox16.Text, comboBox17.Text, textBox11.Text };
                 // SqlDbType[] s3 = new SqlDbType[] {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };



                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertPatient", s, s2,s3);
                    
                    MessageBox.Show("تم حفظ البيانات بنجاح");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                // string s1 = "outer";
                // string s2 = "inner";

                /*  string s = "insert into Registeration_patientRegisteration(employ_code,identity_type,patient_name,gender,date_of_birth,place_of_birth"
                + ",age,date_Regist ,marital_status,catogrical_code,address_working,address_of_patient,communication_way_name,communication_way_value"
                + ",country_name,provinence_name ,vcomboBox16.Textillage_name,nationality,religion,job,gualified_name,graduation_date) values(@em,@iden,@pnam,@gen,@dob,"
            + "@pob,@ag,@datreg,@ms,@catcod,@addw,@addp,@comwn,@comwv,@conn,@prov,@vill,@nat,@rel,@jo,@qual,@gdat)";

                  */


                //    cmd4 = new MySqlCommand("insertPatient", con);
                //    cmd4.CommandType = CommandType.StoredProcedure;


                //   // cmd4 = new MySqlCommand(s, con);
                //    cmd4.Prepare();

                //    cmd4.Parameters.AddWithValue("@em", 1);//1 as a random value
                //    cmd4.Parameters.AddWithValue("@iden", textBox4.Text);
                //    // cmd4.Parameters.AddWithValue("@pi", Int32.Parse(textBox5.Text));
                //    //if (textBox6.Text.Length == 0)
                //    //{
                //    //    MessageBox.Show("قم بادخال الاسم");
                //    //    }
                //    cmd4.Parameters.AddWithValue("@pnam", textBox6.Text);
                //    cmd4.Parameters.AddWithValue("@gen", comboBox20.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@dob", textBox1.Text);
                //    cmd4.Parameters.AddWithValue("@pob", comboBox4.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@ag", Int32.Parse(textBox15.Text));
                //    cmd4.Parameters.AddWithValue("@datreg", textBox16.Text);
                //    cmd4.Parameters.AddWithValue("@ms", comboBox5.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@catcod", Int32.Parse(textBox19.Text));
                //    cmd4.Parameters.AddWithValue("@addw", textBox21.Text);
                //    cmd4.Parameters.AddWithValue("@addp", textBox25.Text);
                //    cmd4.Parameters.AddWithValue("@comwn", comboBox9.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@comwv", textBox22.Text);
                //    cmd4.Parameters.AddWithValue("@conn", comboBox12.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@prov", comboBox14.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@vill", textBox17.Text);
                //    cmd4.Parameters.AddWithValue("@nat", comboBox2.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@rel", comboBox6.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@jo", comboBox16.Text);
                //    cmd4.Parameters.AddWithValue("@qual", comboBox17.SelectedItem);
                //    cmd4.Parameters.AddWithValue("@gdat", textBox11.Text);
                //    cmd4.ExecuteNonQuery();
                //    MessageBox.Show("تم حفظ البيانات بنجاح");

                ///*   
                //    try
                //     {
                //         if (radioButton1.Checked == true)
                //         {
                //             cmd4.Parameters.AddWithValue("@tp", "enter");
                //         }
                //         else if (radioButton2.Checked == true)
                //         {
                //             cmd4.Parameters.AddWithValue("@tp", "out");
                //         }
                //         cmd4.ExecuteNonQuery();
                //     }
                //     catch (Exception ex) { MessageBox.Show(ex.Message); }
                //     MessageBox.Show("sucess");*/
                // }
                //// catch (Exception ex)
                // {
                //  //   MessageBox.Show(ex.ToString());

                // }

                // /*validation*/
                // /*end of validation*/
                // con.CloseConnection();






            }
        }
      

     
        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox8.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox8.Text = null;
                return;
            }
            else
            {



                textBox6.Text = textBox8.Text;
            }
            
           




   
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {


            int x;
            if (int.TryParse(textBox9.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox9.Text = null;
                return;
            }

            else
            {
                textBox6.Text = textBox8.Text + " " + textBox9.Text;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            int x;
            if (int.TryParse(textBox6.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم  ");
                textBox6.Text = null;
                return;
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {


            int x;
            if (int.TryParse(textBox10.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox10.Text = null;
                return;
            }
            else
            {


                textBox6.Text = textBox8.Text + " " + textBox9.Text + " " + textBox10.Text;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox7.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox7.Text = null;
                return;
            }
            else
            {


                textBox6.Text = textBox8.Text + " " + textBox9.Text + " " + textBox10.Text + " " + textBox7.Text;
            }

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox17.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم الحي  ");
                textBox17.Text = null;
                return;
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox21.Text, out x))
            {


                MessageBox.Show("قم بادخال عنوان وليس ارقام ");
                textBox21.Text = null;
                return;
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox25.Text, out x))
            {


                MessageBox.Show("قم بادخال عنوان المريض وليس ارقام ");
                textBox25.Text = null;
                return;
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void dt_to_combo()
        {
            DataTable dt = new DataTable();
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; ++i)
                comboBox1.Items.Add(dt.Rows[i].ToString());
        }
      
       
    }
}
