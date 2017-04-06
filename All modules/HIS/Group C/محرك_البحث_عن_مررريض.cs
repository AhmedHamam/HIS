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
    public partial class محرك_البحث_عن_مررريض : Form
    {

        تعديل_بيانات_مريض y=new تعديل_بيانات_مريض();
        public static string Code1 { get; set; }
        public static string name { get; set; }
        Connection con = new Connection();
        int id;
        int count;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataSet ds2 = new DataSet();
       
        public محرك_البحث_عن_مررريض()
        {
            InitializeComponent();
        }

        public محرك_البحث_عن_مررريض(تعديل_بيانات_مريض x)
        {
            InitializeComponent();
            y = x;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void محرك_البحث_عن_مريض_Load(object sender, EventArgs e)
        {
       
            con.OpenConection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            count = 0;
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewCell Cell in dataGridView1.SelectedCells)
                {
                    if (Cell.Selected)
                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                }
                MessageBox.Show("تم حذف البيانات");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           // MessageBox.Show("هل تريد تاكيد الحذف");

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dt.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            con.OpenConection();
            //cmd3 = new MySqlCommand("select count(*) from Registeration_patientRegisteration;", con);
            //count2 = int.Parse(cmd3.ExecuteScalar().ToString());
            //textBox4.Text = count2.ToString();

           /* SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            SqlConnection sql = new SqlConnection(@"Server=HanadyKhalifa; DataBase=PHIS; Integrated Security=true;");
            cmd.CommandText = "search_patient1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sql;
            sql.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
                textBox4.Text = reader[0].ToString();
            sql.Close();*/


          //  textBox5.Text = count.ToString();
            //con.Close();
            //if (textBox1.Text != "")

            if (textBox1.Text != "" && textBox3.Text == "")
            {
                try
                {
                    //con.Open();

                    //string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_id=@x";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@x", Int32.Parse(textBox1.Text));
                   
                    //dr = cmd.ExecuteReader();
                  
                    //dt.Load(dr);
                   
                    //dataGridView1.DataSource = dt;
                   
                   
                    //dr.Close();
                    //string s1 = "select visit_code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code_visit=visit_code and patt_id=@x;";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@x", Int32.Parse(textBox1.Text));
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();

                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient2", s, s2, s3);

                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox1.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient4", s, s2, s3);


                
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            //else if (textBox3.Text != "")
            else if (textBox3.Text != "" && textBox1.Text == "")
            {
                try
                {
                    con.OpenConection();

                //    string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_name=@x";
                //    cmd = new MySqlCommand(s, con);
                //    cmd.Parameters.AddWithValue("@x", textBox3.Text);
                //    dr = cmd.ExecuteReader();
               
                //    dt.Load(dr);
                //    dataGridView1.DataSource = dt;

                   
                //    dr.Close();
                //    string s1 = "select visit_code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code_visit=visit_code and patient_name=@x";
                //    MySqlCommand cmd1 = new MySqlCommand(s1, con);
                //    cmd1.Parameters.AddWithValue("@x", textBox3.Text);
                //    MySqlDataReader dr1 = cmd1.ExecuteReader();
                //    DataTable dt1 = new DataTable();
                //    dt1.Load(dr1);
                //    dataGridView3.DataSource = dt1;
                //    dr1.Close();
                


               }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }

            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                try
                {



                    con.OpenConection();
                    string[] s = new string[] { "@x" };
                    string[] s2 = new string[] { textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient5", s, s2, s3);



                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { textBox3.Text };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3);

                    //con.Open();

                    //string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration where patient_name=@x and patient_id=@y";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@y",Int32.Parse(textBox1.Text));
                    //cmd.Parameters.AddWithValue("@x", textBox3.Text);
                    //dr = cmd.ExecuteReader();

                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;


                    //dr.Close();
                    //string s1 = "select visit_code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code_visit=visit_code and patient_name=@x and patient_id=@y";
                    //MySqlCommand cmd1 = new MySqlCommand(s1, con);
                    //cmd1.Parameters.AddWithValue("@y", Int32.Parse(textBox1.Text));
                    //cmd1.Parameters.AddWithValue("@x", textBox3.Text);
                    //MySqlDataReader dr1 = cmd1.ExecuteReader();
                    //DataTable dt1 = new DataTable();
                    //dt1.Load(dr1);
                    //dataGridView3.DataSource = dt1;
                    //dr1.Close();


                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }
            else
            {
                try
                {

                    con.OpenConection();

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient10");


                    dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient9");








                //    con.Open();

                //    string s = "select patient_id,patient_name,job,date_of_birth,gender from Registeration_patientRegisteration";
                //    cmd = new MySqlCommand(s, con);
                //    dr = cmd.ExecuteReader();

                //    dt.Load(dr);
                //    dataGridView1.DataSource = dt;

                //    dr.Close();
                //    string s1 = "select visit_code,dat  from entranceoffice_visit,Registeration_patientRegisteration,patientAndVisit where patt_id=patient_id and code_visit=visit_code ";
                //    MySqlCommand cmd1 = new MySqlCommand(s1, con);
                //    MySqlDataReader dr1 = cmd1.ExecuteReader();
                //    DataTable dt1 = new DataTable();
                //    dt1.Load(dr1);
                //    dataGridView3.DataSource = dt1;
                //    dr1.Close();





                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.CloseConnection(); }
            }


          }  

        


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true) 
            {
                panel7.Show();

            }
            else 
            {
                panel7.Hide();
            
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void get(object sender, DataGridViewCellMouseEventArgs e)
        {

            string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            id = int.Parse(c);
            MessageBox.Show(id.ToString());
            try
            {
                //          string s = "select doctor_name from ddd,doctors,patient_doctor where p_id=pat_code and Doc_id =doctor_code and p_id=@d;";
                //          con.Open();
                //          cmd2 = new SqlCommand(s, con);
                //          cmd2.Parameters.AddWithValue("@d", id);
                //          string res = cmd2.ExecuteScalar().ToString();
                //          textBox7.Text = res;



                string[] f = new string[] { "@x" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                textBox7.Text = con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3).ToString();



            }
            catch (Exception ) { textBox7.Text = "لا يوجد "; }
            //con.Close();
            //try
            //{
                string s3 = "select name_clin from ddd,clinic,clinic_patient where p_id=pat_code and c_id =clinic_id and p_id=@d;";
                //      //MessageBox.Show(id + "");
                //      con.Open();
                //      cmd2 = new MySqlCommand(s3, con);
                //      cmd2.Parameters.AddWithValue("@d", id);
                //      string res2 = cmd2.ExecuteScalar().ToString();
                //      textBox10.Text = res2;
                //      con.Close();*/
                try
                {
                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { id.ToString() };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                    textBox9.Text = con.ShowDataInGridViewUsingStoredProc("num_patient", f, f2, f3).ToString();

                    // string s4 = "select count_num from patient_data, where pat_code=@d;";
                    //MessageBox.Show(id + "");
                    //con.Open();
                    //cmd2 = new SqlCommand(s4, con);
                    //cmd2.Parameters.AddWithValue("@d", id);
                    //string res3 = cmd2.ExecuteScalar().ToString();
                    //textBox9.Text = res3;

                    //         dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("se_data");

                    //         string st = "0";
                    //         if (dt.Rows.Count > 0)
                    //             st = dt.Rows[dt.Rows.Count - 1][0].ToString();
                    //         st = (Convert.ToInt16(st) + 1).ToString();
                    //         textBox9.Text = st;
                }
                catch (Exception ex) { textBox9.Text = "ليس لديه حساب مسبق "; }
                // con.CloseConnection();
                try
                {
                    string[] f = new string[] { "@x" };
                    string[] f2 = new string[] { id.ToString() };
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
                    textBox6.Text = con.ShowDataInGridViewUsingStoredProc("display_visit_type", f, f2, f3).ToString();
                    /*string s5 = "select type_of_visit from Registeration_patientRegisteration as p,entranceoffice_visit as r where r.pat_id=p.patient_id and pat_id=@x;";
                   con.Open();
                 cmd2 = new MySqlCommand(s5, con);
                   cmd2.Parameters.AddWithValue("@d", id);
                   string res4 = cmd2.ExecuteScalar().ToString();
               textBox6.Text = res4;*/
                }
                catch (Exception ex) { textBox6.Text = "ليس لديه  "; }
                con.CloseConnection();

            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           // if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[\u0621-\u064A\040]+$"))
           // {
           //     MessageBox.Show("This textbox accepts only alphabetical characters");
           //     //textBox3.Text.Remove(textBox3.Text.Length - 1);
           // }
           ///* else {
           //     if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
           //     {
           //         MessageBox.Show("This textbox accepts only alphabetical characters");
           //        // textBox1.Text.Remove(textBox1.Text.Length - 1);
           //     }
           // }*/




            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم المريض ");
                textBox3.Text = null;
                return;
            }


        }



        private void button5_Click(object sender, EventArgs e)
        {
            تسجيل_بيانات__مريض re = new تسجيل_بيانات__مريض();
            re.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            تعديل_بيانات_مريض update = new تعديل_بيانات_مريض();
            update.Show();
        }

        private void fill(object sender, DataGridViewCellMouseEventArgs e)
        {

            MessageBox.Show("قم بتعديل البيانات");
             string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//p_id
               id = int.Parse(a);
               string b = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();//p_name
               string c = this.dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();//phone
               string d = this.dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();//city
               string f = this.dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();//country
               string g = this.dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();//matrial _sstatus
               string yy = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();//identity_type
               //string z = this.dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();//cat_cod
               //int   cat_code = int.Parse(z);

             string m = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();//date_ofbirth



             // string c = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
              // h = int.Parse(c);

           // تعديل_بيانات_مريض  l = new تعديل_بيانات_مريض();

             List<string> bd = new List<string>();
             bd.Add(id.ToString());
             bd.Add(b.ToString());
             bd.Add(c.ToString());
             bd.Add(d.ToString());
             bd.Add(f.ToString());
             bd.Add(g.ToString());
             bd.Add(yy.ToString());
             //bd.Add(cat_code.ToString());
             bd.Add(m.ToString());
            

            //, b, c, d, f, g, y, cat_code,m};

             تعديل_بيانات_مريض.setvalue(bd);
             y.Show();
            // l.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox1.Text = null;
                return;
            }


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
       /* private void asd(object sender, DataGridViewCellMouseEventArgs e)
        {
            تعديل_بيانات_مريض d = new تعديل_بيانات_مريض();
            d.Show();
        }*/

       
    }
}
