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
    public partial class خدمات : Form
    {
        SqlDataAdapter da;
        SqlDataReader dr;
       
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        
       
        DataSet ds = new DataSet();
        List<string> l1 = new List<string>();
        public خدمات()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            العياده f2 = new العياده();
            
            if (f2.ShowDialog() == DialogResult.OK)
            {
                
                textBox9.Text = العياده.Code;
                textBox10.Text = العياده.Arab;
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*create procedure clinic_خدمات_doctor_select
                as
                begin
                select degree from doctor
                end
             */

           // class_con.OpenConection();
            //class_con.ExecuteQueries("clinic_خدمات_doctor_select");
           // da = new SqlDataAdapter("clinic_خدمات_doctor_select", con);
           // da = new SqlDataAdapter("select degree from doctor;", con);
           // da.Fill(ds);
            con1.OpenConection();
            dr = con1.DataReader("clinic_خدمات_doctor_select");
            
            DataTable dt = new DataTable();
            //dt = ds.Tables[0];
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!comboBox2.Items.Contains(dt.Rows[i][0]))
                {
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            con1.CloseConnection();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
               /*  
                create procedure clinic_خدمات_clinic_service_insert(@c nvarchar(50),@arabic nvarchar(100),@english nvarchar(100),@co nvarchar(50),@degree nvarchar(100))
                as 
                begin
                insert into clinic_service values(@c,@arabic,@english,@co,@degree)
                end
             */

            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("من فضلك قم بادخال البيانات");
            }
            else
            {
                l1.Add(textBox1.Text);
                l1.Add(textBox4.Text);
                l1.Add(textBox5.Text);
                l1.Add(textBox9.Text);
                l1.Add(comboBox2.Text);
                for (int i = 0; i < l1.Count; i += 5)
                {
                    //class_con.OpenConection();
                    //cmd.Connection = con;
                    //cmd.CommandText = "clinic_خدمات_clinic_service_insert";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@c", l1[i]);
                    //cmd.Parameters.AddWithValue("@arabic", l1[i+1]);
                    //cmd.Parameters.AddWithValue("@english", l1[i+2]);
                    //cmd.Parameters.AddWithValue("@co", l1[i+3]);
                    //cmd.Parameters.AddWithValue("@degree", l1[i+4]);
                    ////cmd.CommandText = "insert into clinic_service values('" + l1[i] + "','" + l1[i + 1] + "','" + l1[i + 2] + "','" + l1[i + 3] + "','" + l1[i + 4] + "')";
                    //cmd.ExecuteNonQuery();
                    //class_con.CloseConnection();
                    ////con.Close();
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                    name_input = new string[] { "@c", "@arabic", "@english", "@co", "@degree" };
                    values = new string[] { l1[i], l1[i + 1], l1[i + 2], l1[i + 3], l1[i + 4] };
                    con1.ExecuteNonQueryProcedure("clinic_خدمات_clinic_service_insert", name_input, values, types);
                    con1.CloseConnection();
                }
                MessageBox.Show("تم الحفظ");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                comboBox2.Text = "";
                l1.Clear();
            }
        }
        //exit
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        //Validation
        private void check_number_code(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }

        }

        private void chech_string_arabic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }

        }

        private void check_string_english(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_number_clinic(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }

        }

        private void check_string_clinic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }


    }
}
