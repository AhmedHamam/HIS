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
    public partial class محرك_بحث_فريق_العمل_الطبى_للمنظار : Form
    {
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        SqlDataReader dr;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        Label l1;
        Label l2;
        Label l3;
        Label l4;
        Label l5;
        RowStyle temp;

        public static string Do_id { get; set; }
        public static string Name1 { get; set; }
        public محرك_بحث_فريق_العمل_الطبى_للمنظار()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text == "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                /*
                 * create procedure doc_detail1
                    as
                    select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo 

                 * 
                 */

                //cmd = new SqlCommand("doc_detail1", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("doc_detail1");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text != "" && (textBox2.Text == "" && (textBox3.Text == "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                /*
                 * create procedure doc_detail3(@id int)
                as
                select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where Do_id=@id

                 * 
                 */
                //cmd = new SqlCommand("doc_detail3", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@id" };
                values = new string[] { textBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_detail3", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox2.Text != "" && (textBox1.Text == "" && (textBox3.Text == "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                /*
                 * create procedure doc_detail(@n nvarchar(50))
                as
                select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where name like N''+@n+'%'

                 * 
                 */

                //cmd = new SqlCommand("doc_detail", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@n", textBox2.Text);
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@n" };
                values = new string[] { textBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_detail", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox3.Text != "" && (textBox1.Text == "" && (textBox2.Text == "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
        //                create procedure doc_special(@spec nvarchar(50))
        //as

        //select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where speciality like N''+@spec+'%'


                //cmd = new SqlCommand("doc_special", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@spec", textBox3.Text);
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@spec" };
                values = new string[] { textBox3.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_special", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (comboBox1.Text != "" && (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                /*
                 * create procedure doc_jop(@jop nvarchar(50))
                    as
                    select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where jop =@jop  

                 * 
                 */
                //cmd = new SqlCommand("doc_jop", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@jop", comboBox1.Text);
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@jop" };
                values = new string[] { comboBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_jop", name_input, values, types);

                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (comboBox2.Text != "" && (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text == "" && comboBox1.Text == ""))))
            {
                con1.OpenConection();
                
                //create procedure doc_degree(@deg nvarchar(50))
                //as
                //select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where degree=@deg   

                //cmd = new SqlCommand("doc_degree", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@deg", comboBox2.Text);
                // dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@deg" };
                values = new string[] { comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_degree", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text != "" && (textBox2.Text != "" || (textBox3.Text != "" || (comboBox1.Text != "" || comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd = new SqlCommand("doc_detail3", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@id" };
                values = new string[] { comboBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_detail3", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text != "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                /*
                 * create procedure doc_spe_name(@spec nvarchar(50),@n nvarchar(50))
                    as
                    select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors s_endo where name=@n and speciality=@spec             

                 * 
                 */
                //cmd = new SqlCommand("doc_spe_name, con",con);
                //cmd.CommandType = CommandType.StoredProcedure;
                
                //cmd.Parameters.AddWithValue("@n",textBox2.Text );
                //cmd.Parameters.AddWithValue("@spec", textBox3.Text);
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.NVarChar,SqlDbType.NVarChar };
                name_input = new string[] { "@n","@spec" };
                values = new string[] { textBox2.Text, textBox3.Text};
                dr = con1.ShowDataInGridViewUsingStoredProcDR("doc_spe_name", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text == "" && (comboBox1.Text != "" && comboBox2.Text == ""))))
            {
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text == "" && (comboBox1.Text == "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox1.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox1.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text != "" && (comboBox1.Text != "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text == "" && (comboBox1.Text != "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text != "" && (comboBox1.Text == "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr=con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text != "" && (comboBox1.Text != "" && comboBox2.Text == ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text == "" && (comboBox1.Text != "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr=con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text != "" && (comboBox1.Text != "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }

            if (textBox1.Text == "" && (textBox2.Text != "" && (textBox3.Text != "" && (comboBox1.Text != "" && comboBox2.Text != ""))))
            {
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where name='" + textBox2.Text + "' and jop='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Do_id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Name1 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            فريق_العمل_المنظار f3 = new فريق_العمل_المنظار();
            f3.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //da1 = new SqlDataAdapter("select degree from doctors ;", con);
            //da1.Fill(ds1);
            con1.OpenConection();
            dr = con1.DataReader("select degree from doctors");
            DataTable dt1 = new DataTable();
            dt1.Load(dr);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (!comboBox2.Items.Contains(dt1.Rows[i][0]))
                {
                    comboBox2.Items.Add(dt1.Rows[i][0].ToString());
                }
            }
            dr.Close();
            //da2 = new SqlDataAdapter("select jop from doctors ;", con);
            //da2.Fill(ds2);
            dr = con1.DataReader("select jop from doctors");
            DataTable dt2 = new DataTable();
            dt2.Load(dr);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (!comboBox1.Items.Contains(dt2.Rows[i][0]))
                {
                    comboBox1.Items.Add(dt2.Rows[i][0].ToString());
                }
            }
            dr.Close();
            if (تخدير.selected == "تخدير")
            {
                comboBox1.Text = "Anesthesia";
                comboBox1.Enabled = false;
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Anesthesia'";
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                dr=con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Anesthesia'");
               
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
            }

            if (فريق_العمل_المنظار.selected == "تخدير")
            {
                comboBox1.Text = "Anesthesia";
                comboBox1.Enabled = false;
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Anesthesia'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Anesthesia'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
            }
            if (فريق_العمل_المنظار.selected == "جراح مساعد")
            {
                comboBox1.Text = "surgeon";
                comboBox1.Enabled = false;
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='surgeon'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='surgeon'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
            }
            if (فريق_العمل_المنظار.selected == "تمريض")
            {
                comboBox1.Text = "Nursing";
                comboBox1.Enabled = false;
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd.CommandText = "select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Nursing'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select Do_id as 'الكود', name as 'الاسم' , jop as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctors  where jop='Nursing'");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        

        
        

        }
        
}
   
