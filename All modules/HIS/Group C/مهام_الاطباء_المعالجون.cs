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
    public partial class مهام_الاطباء_المعالجون : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;

        public مهام_الاطباء_المعالجون()
        {
            InitializeComponent();
        }
          public مهام_الاطباء_المعالجون(int c)
        {
            InitializeComponent();
            textBox1.Text = c.ToString();
        }
        private void مهام_الاطباء_المعالجون_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            cmd = new SqlCommand("select emp_id as 'كود الموظف' ,name  as'اسم الموظف',career_name as 'الوظيفة' from employee where emp_id=@x", con.con);
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            فرررريق_العمل f = new فرررريق_العمل();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = فرررريق_العمل.Code1.ToString();
             
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }


        }
    }
}
