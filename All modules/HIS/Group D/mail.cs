using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{

    public partial class mail : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader drd;

        public static string a;

        public mail()
        {
            con = new SqlConnection("server=DESKTOP-FNSTU7T;database=PHIS;Integrated Security=true");
            InitializeComponent();
        }



        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      


        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {

            if ((textBox2.Text.ToString() == "") || (uid.Text.ToString() == ""))
            {
                MessageBox.Show("please enter your username and password");
            }
            else
            {
                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UserValid";
                cmd.Parameters.AddWithValue("@user", uid.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                a = uid.Text;

                con.Open();
                drd = cmd.ExecuteReader();
                if (drd.HasRows)
                {
                    drd.Read();

                    drd.Close();
                    this.Hide();
                    mainmail m = new mainmail();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("invalid username or password");
                }
                con.Close();

            }

        }

        private void mail_Load(object sender, EventArgs e)
        {

        }
    }
}
