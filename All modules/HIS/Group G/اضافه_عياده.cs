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
    public partial class اضافه_عياده : Form
    {
        SqlDataAdapter da;
        SqlDataReader dr;
        
        DataSet ds = new DataSet();

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        List<string> l1 = new List<string>();
        public اضافه_عياده()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            الادرات_و_الاقسام f3 = new الادرات_و_الاقسام();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = الادرات_و_الاقسام.Code;
                textBox10.Text = الادرات_و_الاقسام.Arab;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //create procedure clinic_اضافه_عياده_speciality
            //    as
            //    begin
            //    select arabic_des from speciality
            //    end

            //da = new SqlDataAdapter("select arabic_des from speciality;", con);
            //da.Fill(ds);
            
            //dt = ds.Tables[0];


            con1.OpenConection();

            dr = con1.DataReader("clinic_اضافه_عياده_speciality");
            DataTable dt = new DataTable();
            dt.Load(dr);
                
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!comboBox2.Items.Contains(dt.Rows[i][0]))
                {
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            dr.Close();
            con1.CloseConnection();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                l1.Add(textBox1.Text);
                l1.Add(textBox4.Text);
                l1.Add(textBox5.Text);
                l1.Add(textBox9.Text);
                l1.Add(comboBox2.Text);
            for (int i = 0; i < l1.Count; i += 5)
            {
                /*
                    create procedure clinic_اضافه_عياده_clinic_insert(@c nvarchar(50),@sep nvarchar(100),@arabic nvarchar(100),@english nvarchar(50),@d nvarchar(50))
                    as
                    begin
                    insert into clinic values(@c,@sep,@arabic,@english,@d)
                    end
                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "insert into clinic values('" + l1[i] + "','" + l1[i + 4] + "','" + l1[i + 1] + "','" + l1[i + 2] + "','" + l1[i + 3] + "')";
                //cmd.CommandText = "clinic_اضافه_عياده_clinic_insert";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@c", SqlDbType.NVarChar).Value = l1[i];
                //cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = l1[i + 4];
                //cmd.Parameters.Add("@arabic", SqlDbType.NVarChar).Value = l1[i + 1];
                //cmd.Parameters.Add("@english", SqlDbType.NVarChar).Value = l1[i + 2];
                //cmd.Parameters.Add("@d", SqlDbType.NVarChar).Value = l1[i + 3];
                //cmd.ExecuteNonQuery();
                //con.Close();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@c", "@sep", "@arabic", "@english", "@d" };
                values = new string[] { l1[i], l1[i + 4], l1[i + 1], l1[i + 2], l1[i + 3] };
                con1.ExecuteNonQueryProcedure("clinic_اضافه_عياده_clinic_insert", name_input, values, types);
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
        //validatin
        private void check_number_code(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_aname(object sender, KeyPressEventArgs e)
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

        private void check_number_edara(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }

        }

        private void check_string_name_edara(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
}
