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



    public partial class mainmail : Form
    {
        string m_date;
        SqlCommand cmd;
        SqlDataReader drr;
        SqlConnection con;
        Connection connect;

        string b;
        mail f1 = new mail();
        public mainmail()
        {

            InitializeComponent();//"server=;database=h;Integrated Security=true"
            connect = new Connection();
            connect.OpenConection();
            con = new SqlConnection("server=DESKTOP-FNSTU7T;database=PHIS;Integrated Security=true");
            /*  cmd = new SqlCommand();
              cmd.CommandText = "select mem_mail from members;";
              cmd.Connection = con;

              con.Open();
              drr = cmd.ExecuteReader();
              while (drr.Read())
              {
                 to.Items.Add(drr["mem_mail"]);



              }

              drr.Close();
              con.Close();*/


        }

        private void mainmail_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            function();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if (con.State != ConnectionState.Open)
                m_date = DateTime.Now.ToShortDateString();

            if (to.Text != "")
            {

                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mess";
                cmd.Parameters.AddWithValue("@from", mail.a);
                cmd.Parameters.AddWithValue("@to", to.Text);
                cmd.Parameters.AddWithValue("@body", about.Text);
                //cmd.Parameters.AddWithValue("@attach", attach.Text);
                cmd.Parameters.AddWithValue("@message_date", m_date);
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Message sent");
                con.Close();

            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel1.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel2.Show();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "received_messages";
            cmd.Parameters.AddWithValue("@to", mail.a);

            if (con.State != ConnectionState.Open)
                con.Open();

            drr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(drr);
            dataGridView1.DataSource = dt;
            drr.Close();
            con.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sent_messages";
            cmd.Parameters.AddWithValue("@from", mail.a);

            if (con.State != ConnectionState.Open)
                con.Open();

            drr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(drr);
            dataGridView2.DataSource = dt;
            drr.Close();
            con.Close();


            /*  sent.BringToFront();
              con.Open();
              inbox.BringToFront();

              string b = Form1.a;


              cmd = new SqlCommand("select m_to,m_about,m_datetime from message where m_from= '" + b + "'", con);

              drr = cmd.ExecuteReader();
              DataTable dt = new DataTable();
              dt.Load(drr);
              dataGridView1.DataSource = dt;
              drr.Close();
              con.Close();*/
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void neww_Paint(object sender, PaintEventArgs e)
        {

        }
        void function()
        {
            con.Open();
            cmd = new SqlCommand("mail_members", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string[] stringArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
                stringArray[i] = dt.Rows[i][0].ToString();
            AutoCompleteStringCollection obj = new AutoCompleteStringCollection();
            obj.AddRange(stringArray);
            to.AutoCompleteCustomSource = obj;
            con.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void to_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
