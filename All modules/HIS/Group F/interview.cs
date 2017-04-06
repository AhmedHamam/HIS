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
    public partial class interview : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        public interview()
        {
            InitializeComponent();
            fill_employee();
        }


        private void fill_employee()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                con.OpenConection();
                string query = @"SELECT   applicant_id, applicant_name FROM   applicant_data";

               SqlDataReader  dr = con.DataReader(query);
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                    comboBox1.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            con.OpenConection();
            cmd = new SqlCommand("interview_select", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@interviewer_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@interview_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@interview_evaluate", textBox2.Text);
            cmd.Parameters.AddWithValue("@applicant_id", comboBox2.SelectedItem);
                //textBox1.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "','" + textBox2.Text + "')", con);
        
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("لقد تم ادخال البيانات بنجاح");


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("لقد حدث خطأ فى ادخال البيانات");


            }
            con.CloseConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
        }
    }
}
