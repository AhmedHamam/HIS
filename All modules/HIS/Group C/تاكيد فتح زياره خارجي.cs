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
    public partial class تاكيد_فتح_زياره_خارجي : Form
    {
        int id;
        string name;
        int age;
        int code_dirc;
        string directory;
        //MySqlConnection con;
        //MySqlCommand cmd;
        SqlCommand cmd;
       Connection con = new Connection();
        public تاكيد_فتح_زياره_خارجي()
        {
            InitializeComponent();
        }
        public تاكيد_فتح_زياره_خارجي(int i,string j,int a,int cdir,string d)
        {

            InitializeComponent();
            id = i;
            name = j;
            age = a;
            code_dirc = cdir;
            directory = d;
        }

        private void تاكيد_فتح_زياره_خارجي_Load(object sender, EventArgs e)
        {
            textBox10.Text = id.ToString();
            textBox1.Text = name;
            textBox3.Text = age.ToString();
            textBox13.Text = code_dirc.ToString();
            textBox14.Text = directory;
            con.OpenConection();
            //con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");
            //con.Open();
            try
            {
            //    cmd = new MySqlCommand("select visit_id from entranceoffice_visits where pat_id=@d", con);
            //    cmd.Parameters.AddWithValue("@d", int.Parse(textBox10.Text));
            //    int v_id = int.Parse(cmd.ExecuteScalar().ToString());
            //    textBox2.Text = v_id.ToString();
            //    SqlCommand cmd = new SqlCommand();
            //    SqlDataReader reader;

                //SqlCommand cmd = new SqlCommand();
                //SqlDataReader reader;

                //SqlConnection sql = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=PHIS; Integrated Security=true;");
                //cmd.CommandText = "emergency_open_visit";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = sql;
              
                //sql.Open();

                //cmd.Parameters.AddWithValue("@d", textBox2.Text); 
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //    textBox2.Text = reader[0].ToString();
                //sql.Close();

                string[] s = { "@d" };
                string[] s2 = { textBox10.Text};
                SqlDbType[] s3 = { SqlDbType.VarChar};
                DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("emergency_open_visit", s, s2, s3);
                textBox2.Text = dt.Rows[0][0].ToString();

            }
            catch (Exception )
            {
           
                MessageBox.Show(" لم يتم فتح زيارة لهذا المريض");
                return;
            }
            //con.Close();
            con.CloseConnection();
        }
            

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {


           // con.Open();
            con.OpenConection();
            try
            {

                string[] f = new string[] { "@d1", "@d2", "@d", "@v"};
                string[] f2 = new string[] { dateTimePicker1.Text, dateTimePicker3.Text, textBox10.Text, textBox18.Text };
              
                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar };
                if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("emergency_open_visit2_saves", f, f2, f3))
                {
                    MessageBox.Show(" لم يتم فتح زيارة لهذا المريض من قبل");
                    return;
                }

                //string s = "update entranceoffice_visits set entrance_date=@d1,expected_exit_date=@d2,type_of_visit=@v where pat_id=@id;";

                //cmd = new MySqlCommand(s, con);

                //cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                //cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Text);
                //cmd.Parameters.AddWithValue("@v", textBox18.Text);
                //cmd.Parameters.AddWithValue("@id", textBox10.Text);
                //cmd.ExecuteNonQuery();
                MessageBox.Show("تم تاكيد فتح زيارة خارجى للمريض");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            con.CloseConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int number2;
            if (int.TryParse(textBox2.Text, out number2))
            {
                textBox2.Text = null;
            }
            else { MessageBox.Show("قم بادخال رقم"); }

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

            int x;
            if (int.TryParse(textBox18.Text, out x))
            {


                MessageBox.Show("قم بادخال حروف  ");
                textBox18.Text = null;
                return;
            }
        }
    }
}
