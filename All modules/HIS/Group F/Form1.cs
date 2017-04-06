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
    public partial class Form1 : Form
    {
       
        SqlCommand cmd;
        Connection con = new Connection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand cm = new SqlCommand("select DepNumber from income_report", con.con);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("add_opReward", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@op_dep", textBox1.Text);
            cmd.Parameters.AddWithValue("@op_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@op_rep", textBox3.Text);
            cmd.Parameters.AddWithValue("@rew_value", textBox4.Text);
            cmd.Parameters.AddWithValue("@dep_number", comboBox1.Text);

            cmd.ExecuteNonQuery();


            con.CloseConnection();
            MessageBox.Show("تم ادخال البيانات بنجاح");



        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


    }
}
