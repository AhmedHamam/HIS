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
    public partial class حصر_رصيد_الاجازات : Form
    {
        Connection con = new Connection();
        SqlCommand com;

        public حصر_رصيد_الاجازات()
        {
            InitializeComponent();
        }

        private void حصر_رصيد_الاجازات_Load(object sender, EventArgs e)
        {
            con.OpenConection();

        }

        private void click_text(object sender, EventArgs e)
        {
            con.OpenConection();
            com = new SqlCommand("select_name_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", textBox1.Text);
            var a = com.Parameters.Add("name", SqlDbType.VarChar, 255);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox2.Text = a.Value.ToString();
            textBox4.Text = b.Value.ToString();
            con.CloseConnection();
        }

        private void click2_text(object sender, EventArgs e)
        {
            con.OpenConection();
            com = new SqlCommand("select_id_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", textBox2.Text);
            var a = com.Parameters.Add("id", SqlDbType.Int);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox1.Text = a.Value.ToString();
            textBox4.Text = b.Value.ToString();
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            com = new SqlCommand("countless_vacation", con.con);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("emp_id", textBox1.Text);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("ادخل البيانات صحيحة");
            }
            con.CloseConnection();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }            	
        }
    }
}
