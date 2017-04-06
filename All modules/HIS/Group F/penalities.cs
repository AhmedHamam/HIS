using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections;

namespace HIS
{
    public partial class penalities : Form
    {
        SqlDataReader dr;
        ArrayList code = new ArrayList();

        public penalities()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            con.OpenConection();
        }


        Connection con = new Connection();
        private void add_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            SqlCommand cmd = new SqlCommand("add_penalty");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@t", comboBox1.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@v", float.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@note", textBox4.Text);
                cmd.Parameters.AddWithValue("@n", comboBox2.SelectedItem);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم اضافه الجزاء");
                comboBox2.SelectedItem = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }

            catch (Exception)
            {
                MessageBox.Show("خطأ في الادخال");
            }
            con.CloseConnection();
          
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            SqlCommand cmd = new SqlCommand("del_penalty");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@n", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@t", comboBox1.Text);


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("تم حذف الجزاء");
                    comboBox2.SelectedItem = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("خطأ في الادخال");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ في الادخال");
            }
            con.CloseConnection();
        }

        private void modify_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            SqlCommand cmd = new SqlCommand("modify_penalty");
            try
            {
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@t", comboBox1.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@v", float.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@note", textBox4.Text);
                cmd.Parameters.AddWithValue("@n", comboBox2.SelectedItem);


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show("تم تعديل الجزاء");
                    comboBox2.SelectedItem = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }

                else
                {
                    MessageBox.Show("خطأ في الادخال");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ في ادخال قيمة الجزاء");
            }
            con.CloseConnection();
        }

        private void penalities_Load(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox2.Items.Add(dr[0].ToString());
            dr.Close();
        }

       

      
       
    }
}
