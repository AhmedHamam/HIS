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
    public partial class employeeEvaluation : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public employeeEvaluation()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("add_employee_evaluation", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emp_id", textBox1.Text);
                cmd.Parameters.AddWithValue("presidence", textBox3.Text);
                cmd.Parameters.AddWithValue("arrival_time", textBox4.Text);
                cmd.Parameters.AddWithValue("work_evaluation", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("apperance_evaluation", comboBox2.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void employeeEvaluation_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("update_employee_evaluation", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                textBox1.Text = comboBox1.SelectedItem.ToString();
                cmd.Parameters.AddWithValue("emp_id", textBox1.Text);
                cmd.Parameters.AddWithValue("presidence", textBox3.Text);
                cmd.Parameters.AddWithValue("arrival_time", textBox4.Text);
                cmd.Parameters.AddWithValue("work_evaluation", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("apperance_evaluation", comboBox2.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;
            string name = this.textBox2.Text;
            employees frm = new employees();
            frm.showdi(ref code, ref name);
            this.textBox2.Text = name;
            this.textBox1.Text = code;
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("fill_evaluation", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emp_id", Int32.Parse(textBox1.Text));
                var b = cmd.Parameters.Add("presidence", SqlDbType.VarChar, 255);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("arrival_time", SqlDbType.VarChar, 255);
                c.Direction = ParameterDirection.Output;
                var d = cmd.Parameters.Add("work_evaluation", SqlDbType.VarChar, 255);
                d.Direction = ParameterDirection.Output;
                var l = cmd.Parameters.Add("apperance_evaluation", SqlDbType.VarChar, 255);
                l.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox3.Text = b.Value.ToString();
                textBox4.Text = c.Value.ToString();
                comboBox1.SelectedItem = d.Value.ToString();
                comboBox2.SelectedItem = l.Value.ToString();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
