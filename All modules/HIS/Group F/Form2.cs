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
    public partial class Form2 : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }        
        private void button7_Click(object sender, EventArgs e)
        {
            
            
            //cmd = new SqlCommand("select doctor_name,Temple_Name,application_Date, price from rays where rays.doctor_name='" + textBox3.Text + "'", con);
            SqlCommand cmd = new SqlCommand("show_rays", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker2.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@date2", dateTimePicker1.Value.Date.ToString());
           dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
        }

        

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("select sum(price) from rays where rays.doctor_name='" + textBox3.Text + "' and rays.application_Date between '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'and'" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'" , con);
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlCommand cmd = new SqlCommand("show_result", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker2.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@date2", dateTimePicker1.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@perc", textBox2.Text);
            cmd.Parameters.Add("@sum", SqlDbType.Int);
            cmd.Parameters["@sum"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            label8.Text = cmd.Parameters["@sum"].Value.ToString();

            label8.Text = (((float.Parse(label8.Text) * float.Parse(textBox2.Text))) / 100.0) + "";
            
            
           

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        /*private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/
    }
}
