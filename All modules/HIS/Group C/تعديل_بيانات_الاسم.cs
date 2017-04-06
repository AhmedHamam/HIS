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
    public partial class تعديل_بيانات_الاسم : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        int id;
        public تعديل_بيانات_الاسم()
        {
            InitializeComponent();
        }

        public تعديل_بيانات_الاسم(int i)
        {

            InitializeComponent();
            id = i;

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                
                     string[] f = new string[] { "@n", "@b"};
                string[] f2 = new string[] { textBox1.Text, id.ToString() };
              
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("rewrite_patient_name", f, f2, f3);
               
                //string s = "update Registeration_patientRegisteration set patient_name=@n where patient_id =@b";
                //cmd = new MySqlCommand(s, con);
                //cmd.Parameters.AddWithValue("@n", textBox1.Text);

                //cmd.Parameters.AddWithValue("@b",id );
                //cmd.ExecuteNonQuery();


            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            try
            {
               // con.Open();
                
                     string[] f = new string[] { "@d1"};
                string[] f2 = new string[] {id.ToString() };
              
                SqlDbType[] f3 = new SqlDbType[] {SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("rewrite_patient_name2", f, f2, f3);
                label5.Text = dt.Rows[0][0].ToString();

               // string s1 = "select patient_name from Registeration_patientRegisteration where patient_id=@d1";
               // cmd = new MySqlCommand(s1, con);

               //// cmd.Parameters.AddWithValue("@n", textBox1.Text);

               // cmd.Parameters.AddWithValue("@d1", id);
               //string m1= cmd.ExecuteScalar().ToString();
               //label5.Text = m1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
            
        }

        private void تعديل_بيانات_الاسم_Load(object sender, EventArgs e)
        {

           // con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
            con.OpenConection();
            label7.Text = id + "";
            try
            {
                string[] f = new string[] { "@d1" };
                string[] f2 = new string[] { id.ToString() };

                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("rewrite_patient_name2", f, f2, f3);
                label6.Text = dt.Rows[0][0].ToString();

                //string s = "select patient_name from Registeration_patientRegisteration where patient_id=@d";
                //cmd = new MySqlCommand(s, con);
                //cmd.Parameters.AddWithValue("@d", id);
                //string m = cmd.ExecuteScalar().ToString();
                //label6.Text = m;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
