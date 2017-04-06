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
    public partial class البحث_عن_مرضى_الطوارئ : Form
    {
        public static int Code1 { get; set; }
        public static string arrive_date { get; set; }
        Connection con = new Connection();

        //MySqlConnection con;
        //MySqlCommand cmd;

        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        //BindingSource bs;
        //MySqlDataReader dr; 
        public البحث_عن_مرضى_الطوارئ()
        {
            InitializeComponent();
        }

        private void البحث_عن_مرضى_الطوارئ_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox15.Text!= ""))
            {
                try
                {
                    string[] s = new string[] { "@pn" };
                    string[] s2 = new string[] { textBox15.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_for_emergrncy_patient", s, s2, s3);
                    //ds.Tables.Clear();
                    //cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',accident_date as'تاريخ الحادثه',arrival_date as'تاريخ الوصول',accident_kind as'نوع الحادثه' from emergency_cases_accident_emergency,Registeration_patientRegisteration where patient_id=patients_id and patient_name='" + textBox15.Text + "'; ", con);



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
                    //ds.Tables.Clear();
                    //cmd = new MySqlCommand("select patients_id as 'كود المريض',patient_name as 'اسم المريض',accident_date as'تاريخ الحادثه',arrival_date as'تاريخ الوصول',accident_kind as'نوع الحادثه' from emergency_cases_accident_emergency,Registeration_patientRegisteration where patient_id=patients_id ; ", con);

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_for_emergrncy_patient2");

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

       /* private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                arrive_date = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                اضافة_خدمات_لمرضى_الطوارئ ff = new اضافة_خدمات_لمرضى_الطوارئ();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            int x;
            if (int.TryParse(textBox15.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox15.Text = null;
                return;
            }//strin
        }
    }
}
