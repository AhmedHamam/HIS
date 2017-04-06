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
    public partial class تعديل_بيانات_مريض : Form
    {
        Connection con = new Connection();
        public static List<string> val;
        int count;
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlCommand cmd4;
        //MySqlDataAdapter da;
        DataSet ds = new DataSet();
        public تعديل_بيانات_مريض()
        {
            InitializeComponent();
        }

       //public void setValue(int id, String name)
       // {

       //     textBox1.Text = id.ToString();
       //     textBox5.Text = name;

       // }

        public static void setvalue(List<string> a)
        {

            val = a;

       
        }






        public تعديل_بيانات_مريض(int x,string y)
        {
            InitializeComponent();
            textBox1.Text = x.ToString();

            textBox5.Text = y;
            //textBox2.Text = p.ToString(); 

            count = x;
        }
        private void تعديل_بيانات_الاسم_Load(object sender, EventArgs e)
        {  

              if (val != null)
            {
                textBox1.Text = val[0];
                textBox5.Text = val[1];
                textBox9.Text = val[1];
                textBox2.Text = val[2];
                textBox6.Text = val[7];
                textBox3.Text = val[3];
                textBox7.Text = val[4];
               // textBox4.Text = val[6];
                textBox11.Text =val[5];
                textBox15.Text = val[6];
            
            }


        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ///////////// name
               con.OpenConection();

               string[] f = new string[] { "@n", "@b" };
               string[] f2 = new string[] {textBox9.Text,textBox1.Text};
               SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update1", f, f2, f3);

              // SqlCommand cmd;

               //SqlConnection conn = new SqlConnection(@"Server=ASD-PC\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
               //try
               //{
               //    conn.Open();
               //    cmd = new SqlCommand("update Registeration_patientRegisteration set patient_name = "+f2[0]+" where patient_id = "+f2[1] , conn);
               //    cmd.ExecuteNonQuery();
               //}
               //catch (Exception ex) { 
               //MessageBox.Show(ex.ToString());
               //}

            ////    string s = "update Registeration_patientRegisteration set patient_name=@n where patient_id =@b";
            ////    cmd = new MySqlCommand(s, con);
            ////    cmd.Parameters.AddWithValue("@n", textBox9.Text);
            ////    cmd.Parameters.AddWithValue("@b", count);
            ////    cmd.ExecuteNonQuery();
            ////    ///////////// telephon

            ////    string s11 = "update Registeration_patientRegisteration set communication_way_value=@x where patient_id =@y";
            ////    cmd = new MySqlCommand(s11, con);
            ////    cmd.Parameters.AddWithValue("@x", textBox10.Text);
            ////    cmd.Parameters.AddWithValue("@y", count);
            ////    cmd.ExecuteNonQuery();
              string[] ff = new string[] { "@x", "@y" };
              string[] ff2 = new string[] { textBox10.Text, textBox1.Text };
              SqlDbType[] ff3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update2", ff, ff2, ff3);
            ////    /////////////province
            //   string[] h1 = new string[] { "@f", "@h" };
            //   string[] h2 = new string[] { textBox12.Text, textBox1.Text };
            //   SqlDbType[] h3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
            //   con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update3", h1, h2, h3);
            ////    string s31 = "update Registeration_patientRegisteration set provinence_name=@f where patient_id =@h";
            ////    cmd = new MySqlCommand(s31, con);
            ////    cmd.Parameters.AddWithValue("@f", textBox12.Text);
            ////    cmd.Parameters.AddWithValue("@h", count);
            ////    cmd.ExecuteNonQuery();
            ////    //////////// country
              string[] hh1 = new string[] { "@d", "@p" };
              string[] hh2 = new string[] { textBox14.Text, textBox1.Text };
              SqlDbType[] hh3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update4", hh1, hh2, hh3);
            ////    string s41 = "update Registeration_patientRegisteration set country_name=@d where patient_id =@p";
            ////    cmd = new MySqlCommand(s41, con);
            ////    cmd.Parameters.AddWithValue("@d", textBox14.Text);
            ////    cmd.Parameters.AddWithValue("@p", count);
            ////    cmd.ExecuteNonQuery();
            ////    /////////////
              string[] s1 = new string[] { "@d", "@p" };
              string[] s2 = new string[] { textBox13.Text, textBox1.Text };
              SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update5", s1, s2, s3);
            ////    string s51 = "update Registeration_patientRegisteration set marital_status=@d where patient_id =@p";
            ////    cmd = new MySqlCommand(s51, con);
            ////    cmd.Parameters.AddWithValue("@d", textBox13.Text);
            ////    cmd.Parameters.AddWithValue("@p", count);
            ////    cmd.ExecuteNonQuery();
              string[] ss1 = new string[] { "@d", "@p" };
              string[] ss2 = new string[] { textBox16.Text, textBox1.Text };
              SqlDbType[] ss3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update6", ss1, ss2, ss3);
            ////    string s61 = "update Registeration_patientRegisteration set identity_type=@d where patient_id =@p";
            ////    cmd = new MySqlCommand(s61, con);
            ////    cmd.Parameters.AddWithValue("@d", textBox16.Text);
            ////    cmd.Parameters.AddWithValue("@p", count);
            ////    cmd.ExecuteNonQuery();
              string[] c1 = new string[] { "@x", "@y", "@z", "@d1", "@d2", "@m1", "@m2" };
              string[] c2 = new string[] { textBox1.Text, textBox5.Text, textBox9.Text, textBox2.Text, textBox10.Text, textBox11.Text, textBox13.Text };
              SqlDbType[] c3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
              con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("edit_patient_data_insert", c1, c2, c3);


             string[] x1 = new string[] { "@nam", "@tel", "@province", "@old_country", "@old_mat", "@identity", "@w" };
               string[] x2 = new string[] { textBox5.Text, textBox2.Text, textBox3.Text, textBox7.Text, textBox11.Text, textBox15.Text, textBox1.Text };
               SqlDbType[] x3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
               dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("edit_patient_data", x1, x2, x3);

            //    string s2 = "select patient_id,patient_name,communication_way_value,@nam as old_name,@tel as old_telephone,provinence_name,@province as old,country_name ,@old_country,marital_status,@old_mat,identity_type,@identity from Registeration_patientRegisteration where patient_id=@w ";
                
            //    cmd = new MySqlCommand(s2, con);
            //    cmd.Parameters.AddWithValue("@nam", textBox5.Text);
            //    cmd.Parameters.AddWithValue("@tel", textBox2.Text);
            //    cmd.Parameters.AddWithValue("@province",textBox3.Text);
            //    cmd.Parameters.AddWithValue("@old_country", textBox7.Text);
            //    cmd.Parameters.AddWithValue("@old_mat", textBox11.Text);
            //    cmd.Parameters.AddWithValue("@identity", textBox15.Text);
            //    cmd.Parameters.AddWithValue("@w", count);
               
            //    MySqlDataReader dr = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    try
            //    {
              
            //        string d = "insert into updatee (patient_id,old_name,new_name,old_communication_way_name,new_communication_way_name,old_marital_status,new_marital_status)values (@x,@y,@z,@d1,@d2,@m1,@m2)";
            //        cmd4 = new MySqlCommand(d, con);
            //        cmd4.Parameters.AddWithValue("@x", textBox1.Text);
            //        cmd4.Parameters.AddWithValue("@y", textBox5.Text);
            //        cmd4.Parameters.AddWithValue("@z", textBox9.Text);
            //        cmd4.Parameters.AddWithValue("@d1", textBox2.Text);
            //        cmd4.Parameters.AddWithValue("@d2", textBox10.Text);
            //        cmd4.Parameters.AddWithValue("@m1", textBox11.Text);
            //        cmd4.Parameters.AddWithValue("@m2", textBox13.Text);
            //        cmd4.Prepare();
            //        cmd4.ExecuteNonQuery();
            //        MessageBox.Show("good");
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }

            //}
            //catch(Exception ex){MessageBox.Show(ex.Message);}
            //finally { con.Close(); }

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Text = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox16.Text = comboBox2.SelectedItem.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox1.Text, out number2))
            {

            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox2.Text, out number2))
            {

            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox8.Text, out number2))
            {

            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        //private void تعديل_بيانات_مريض_MouseHover(object sender, EventArgs e)
        //{

        //    if (val != null)
        //    {
        //        textBox1.Text = val[0];
        //        textBox5.Text = val[1];
        //        textBox2.Text = val[3];
        //        textBox6.Text = val[7];
        //        textBox3.Text = val[3];
        //        textBox7.Text = val[4];
        //       // textBox4.Text = val[6];
        //        textBox11.Text =val[5];
        //        textBox15.Text = val[6];
            
        //    }
            
        }

      
    }

