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

    
    public partial class تقرير_باستكمال_بيانات_المرضي : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        public تقرير_باستكمال_بيانات_المرضي()
        {
            InitializeComponent();
        }

        private void طباعةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
           //complete_data d=new complete_data(this);
           end_complete_date d = new end_complete_date(this);
            d.Show();
      
            }
            catch (Exception ) { MessageBox.Show("لم يتم العثور عليها"); }
        }
        public void setvalue3(string x) {
            textBox1.Text = x;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                end_complete_date d = new end_complete_date(this);
                d.Show();
            }
            catch (Exception ) { MessageBox.Show("لم يتم العثور عليها"); }
        }
        public void setvalue4(string s) {
            textBox2.Text = s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void تقرير_باستكمال_بيانات_المرضي_Load(object sender, EventArgs e)
        {

            //con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string[] s = new string[] {"@x","@y"};
                         string[] s2 = new string[] {textBox1.Text,textBox2.Text};
                         SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar, SqlDbType.VarChar };
                         dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_rewite_complete", s, s2, s3);
            //cmd = new MySqlCommand("select patient_id, patient_name,date_of_birth,date_Regist,gender,nationality from  Registeration_patientRegisteration where  graduation_date='' or gualified_name='' or  religion='' or  village_name='' or  provinence_name='' or  country_name='' or  communication_way_value='' or communication_way_name='' or  address_of_patient='' or  address_working='' or  catogrical_code='' or marital_status='' or  age='' or place_of_birth='' or    date_of_birth='' or  patient_name='' or   gender='' or job='' or  nationality='' and  date_Regist between @x and @y ;", con);
            //cmd.Parameters.AddWithValue("@x",textBox1.Text);
            //cmd.Parameters.AddWithValue("@y",textBox2.Text);
            //MySqlDataAdapter da =new MySqlDataAdapter(cmd);
            //da.Fill(ds);

        
            // dataGridView1.DataSource=ds.Tables[0];

         

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
           // ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
