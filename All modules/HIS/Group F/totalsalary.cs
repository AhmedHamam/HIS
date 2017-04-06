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
    public partial class totalsalary : Form
    {
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        Connection con = new Connection();
        public totalsalary()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            con.OpenConection();
        }
     
    
        private void add_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            
            try
                {

                  
                SqlCommand cmd = new SqlCommand("add_totalsalary");
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@n1",comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@b1", textBox1.Text);
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value);
                var a = cmd.Parameters.Add("@inc1", SqlDbType.Float);
                a.Direction = ParameterDirection.Output;
                var b = cmd.Parameters.Add("@de1", SqlDbType.Float);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("@total1", SqlDbType.Float);
                c.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

              textBox2.Text = a.Value.ToString();
               textBox3.Text = b.Value.ToString();
               textBox4.Text = c.Value.ToString();
                MessageBox.Show("تم بنجاح");
               
            }
         
                    catch (Exception )
                {
                    MessageBox.Show("خطأ في الادخال");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            

            con.CloseConnection();


        }

        private void totalsalary_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Clear();

            dr = con.DataReader("select name  from employee  ");
            while (dr.Read())
                comboBox1.Items.Add(dr[0].ToString());
            dr.Close();
        }

      
     
    }
}

     

       

       
    
