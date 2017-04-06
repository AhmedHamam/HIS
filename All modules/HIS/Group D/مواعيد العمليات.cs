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
    public partial class opForm17 : Form
    {
        string s;
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd,cmd2;
        public SqlDataReader dr;
        Connection connect;
        public opForm17()
        {
            InitializeComponent();
        }
        private void opForm17_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Server = DESKTOP - LSC6L8E\SQLEXPRESS; Database = phis; Integrated Security=true");
                cmd = new SqlCommand();
                cmd.CommandText = "select Room_name  from rooms;";
                cmd.Connection = con;

                if (con.State != ConnectionState.Open) con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["Room_name"]);
                  


                }

                dr.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();
                string[] words = dt.Split(' ');
                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            if (con.State != ConnectionState.Open) con.Open();
            cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText= "insert into rooms(ro_suite_name,ro_english_name ,reserved_date) values ('" +comboBox2.Text+ "','" + comboBox3.Text + "','" + dateTimePicker1.Value.ToShortDateString()+"')";
            
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Room is reserved ");
            dr.Close();
            if (con.State != ConnectionState.Closed) con.Close();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
