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
    public partial class training : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public training()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void training_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("add_course", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("daate", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("perioud", textBox4.Text);
                cmd.Parameters.AddWithValue("experinced_gained", richTextBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الاضافة");
                richTextBox1.Text="";
                    textBox1.Text="";
                    textBox4.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل تريد حذف الدوره؟", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("delete_course", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحذف");
                richTextBox1.Text = "";
                textBox1.Text = "";
                textBox4.Text = "";
                con.CloseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("لم يتم حذف الدوره");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("add_emp_has_course", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emp_id", textBox2.Text);
                cmd.Parameters.AddWithValue("name", textBox3.Text );
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الاضافة");
                 textBox2.Text="";
                      textBox3.Text="";
                      textBox5.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل تريد حذف الموظف من الدوره؟", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    con.OpenConection();
                    SqlCommand cmd = new SqlCommand("delete_emp_has_course", con.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("emp_id", textBox2.Text);
                    cmd.Parameters.AddWithValue("name", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحذف");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    con.CloseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("لم يتم حذف الموظف من الدوره");
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = this.textBox2.Text;
            string name = this.textBox5.Text;
            employees frm = new employees();
            frm.showdi(ref code, ref name);
            this.textBox5.Text = name;
            this.textBox2.Text = code;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            string name = this.textBox3.Text;
            courses frm = new courses();
            frm.showdi(ref name);
            this.textBox3.Text = name;
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            courses frm = new courses();
            frm.showdi(ref name);
            this.textBox1.Text = name;
        }
    }
}
