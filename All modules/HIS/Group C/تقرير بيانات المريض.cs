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
    public partial class تقرير_بيانات_المريض : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlDataAdapter da;
        //MySqlCommand cmd;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public تقرير_بيانات_المريض()
        {
            InitializeComponent();
        }

       /* public تقرير_بيانات_المريض(int f,string h)
        {
            InitializeComponent();

            textBox2.Text =f.ToString();
            textBox1.Text = h;
           

        }
     */
        public void setValue(int d,String name)
        {
            textBox2.Text =d.ToString();
            textBox1.Text = name;

        }

      /*  private void button3_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض_تقرير d = new محرك_البحث_عن_مريض_تقرير(this);
            d.Show();
        }*/

        private void تقرير_بيانات_المريض_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {

                string[] s = new string[] { "@x" };
                string[] s2 = new string[] { textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_data", s, s2, s3);
              /*  string s = "select nationality,type_patient,graduation_date ,job ,address_of_patient,visit_code,type_visit"
                    + "from Registeration_patientRegisteration,patientAndVisit,entranceoffice_visit "
                    + "where patt_id=patient_id and code_visit=visit_code and patient_id= @x ";*/

                //string s = "select nationality,graduation_date,address_of_patient,visit_id,job,type_of_visit from Registeration_patientRegisteration,entranceoffice_visit where  and patient_id=@x";
            
                //cmd = new MySqlCommand(s, con);
                //cmd.Parameters.AddWithValue("@x", textBox2.Text);
                
                //da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs;

            
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
         محرك_البحث_عن_مريض_تقر d = new محرك_البحث_عن_مريض_تقر(this);
            d.Show();
        }

       
    }
}
