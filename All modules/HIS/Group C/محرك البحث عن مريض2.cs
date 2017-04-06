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
    public partial class محرك_البحث_عن_مريض2 : Form
    {
        Connection con = new Connection();
        int id;
        //MySqlCommand cmd2;
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataAdapter da;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //BindingSource bs;
        // BindingSource bs2;
       // MySqlDataAdapter da2;
        DataSet ds2 = new DataSet();
        //MySqlCommand cmd3;
        //MySqlDataReader dr;
        int count = 0;
        int count2 = 0;
        int code1;
        public محرك_البحث_عن_مريض2()
        {
            InitializeComponent();
        }

        private void محرك_البحث_عن_مريض2_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dt.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            con.OpenConection();
           


            if (textBox1.Text != "" && textBox3.Text == "")
            {
                try
                {
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
            else if (textBox3.Text != "" && textBox1.Text == "")
            {
                try
                {
                    con.OpenConection();


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

        private void get(object sender, DataGridViewCellMouseEventArgs e)
        {
            string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            id = int.Parse(c);
            MessageBox.Show(id.ToString());
            try
            {


                string[] f = new string[] { "@x" };
                string[] f2 = new string[] { id.ToString() };
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                textBox7.Text = con.ShowDataInGridViewUsingStoredProc("search_patient6", f, f2, f3).ToString();



            }
            catch (Exception ) { textBox7.Text = "لا يوجد "; }
            //con.Close();
            //try
            //{
           // string s3 = "select name_clin from ddd,clinic,clinic_patient where p_id=pat_code and c_id =clinic_id and p_id=@d;";
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
            catch (Exception ) { textBox6.Text = "ليس لديه  "; }
            con.CloseConnection();

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم المريض ");
                textBox3.Text = null;
                return;
            }

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

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
