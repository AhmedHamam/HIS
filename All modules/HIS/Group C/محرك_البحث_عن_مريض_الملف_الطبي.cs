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
    public partial class محرك_البحث_عن_مريض_الملف_الطبي : Form
    {

        public static int Code1 { get; set; }
        //public static string name { get; set; }
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
        public محرك_البحث_عن_مريض_الملف_الطبي()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1");
            textBox4.Text = dt.Rows[0][0].ToString();
            //SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
            //cmd.CommandText = "search_patient1";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Connection = sql;
            //sql.Open();
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //    textBox4.Text = reader[0].ToString();
            //sql.Close();
            //  =(DataTable)con.ShowDataInGridViewUsingStoredProc("report");


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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Code1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            

            اضافة_خدمات_لمرضى_الطوارئ ff = new اضافة_خدمات_لمرضى_الطوارئ();
            ff.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void محرك_البحث_عن_مريض_الملف_الطبي_Load(object sender, EventArgs e)
        {

        }
    }
}
