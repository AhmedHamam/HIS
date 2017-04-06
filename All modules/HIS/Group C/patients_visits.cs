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
    public partial class patients_visits : Form
    {
        public static string Code1 { get; set; }
       // public static string Code2 { get; set; }
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;

        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        //BindingSource bs;
        //MySqlDataReader dr;
        public patients_visits()
        {
            InitializeComponent();
        }

        private void patients_visits_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
            con.OpenConection();
     
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                الحجز_بعد_الموافقه ff = new الحجز_بعد_الموافقه();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != ""))
            {
                try
                {

                    string[] s = new string[] { "@pn" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("patient_visit", s, s2, s3);
                    //ds.Tables.Clear();
                    //cmd = new MySqlCommand("select pat_id as 'كود المريض',patient_name as 'اسم المريض' from entranceoffice_visits,Registeration_patientRegisteration where patient_id=pat_id and patient_name='"+textBox1.Text+"'; ", con);



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



                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("patient_visit1");
                //    ds.Tables.Clear();
                //    cmd = new MySqlCommand("select pat_id as 'كود المريض',patient_name as 'اسم المريض' from entranceoffice_visits,Registeration_patientRegisteration where patient_id=pat_id; ", con);



                //    //da.SelectCommand = cmd;

                //    da = new MySqlDataAdapter(cmd);
                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox1.Text = null;
                return;
            }
        }
    }
}
