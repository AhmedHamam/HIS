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
    public partial class applicantdata : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        public applicantdata()
        {
            InitializeComponent();
        }

        private void applicantdata_Load(object sender, EventArgs e)
        {
            con.OpenConection();

            //con = new SqlConnection(@"server=god;Initial Catalog=final;Integrated Security=True");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                cmd = new SqlCommand("applicantdata_select", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicant_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@applicant_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@languages", textBox2.Text);
                cmd.Parameters.AddWithValue("@courses", textBox3.Text);
                cmd.Parameters.AddWithValue("@qualifications", textBox4.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@experince_years", textBox5.Text);
                cmd.Parameters.AddWithValue("@nationality", textBox6.Text);
                cmd.Parameters.AddWithValue("@job_name", textBox7.Text);

                // cmd = new SqlCommand("insert into applicant_data (applicant_name,applicant_date,languages,courses,qualifications,gender,experince_years,nationality,job_name) values ('" + textBox1.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("لقد تم ادخال البيانات بنجاح");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;

            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
            con.CloseConnection();
        }
    }
}
