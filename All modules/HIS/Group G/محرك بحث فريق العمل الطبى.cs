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
    public partial class محرك_بحث_فريق_العمل_الطبى : Form
    {
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        SqlDataReader dr;
        
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;

        Label l1;
        Label l2;
        Label l3;
        Label l4;
        Label l5;
        RowStyle temp;

        public static string Code { get; set; }
        public static string Name1 { get; set; }
        public محرك_بحث_فريق_العمل_الطبى()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            التخصصات_الطبية f3 = new التخصصات_الطبية();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = التخصصات_الطبية.Arab;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (textBox1.Text == "" && (textBox2.Text == "" && (textBox3.Text == "" && (comboBox1.Text == "" && comboBox2.Text == ""))))
            {
                /*
                 *  create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_select
                    as
                    begin
                    select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor
                    end
                 * */
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor";
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                dr = con1.DataReader("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_select");
               
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


                /*
                   create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_id_select(@id int)
                    as
                     begin
                    select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doctor_id=@id
                    end

                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doctor_id='" + textBox1.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_id_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox1.Text;
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                types=new SqlDbType[]{SqlDbType.Int};
                name_input=new string[]{"@id"};
                values=new string[]{textBox1.Text};
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_id_select",name_input,values,types);
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
                /*
                 * 
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_select(@name nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%'
                        end
                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
               // dr = cmd.ExecuteReader();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@name" };
                values = new string[] { textBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_select", name_input, values, types);
                
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
                /*              
                    create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sepciality_select(@sep nvarchar(50))
                    as
                    begin
                   select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where specialization like N'%'+@sep+'%'
                   end
                 * 
                 * 
                 * */
               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where specialization='" + textBox3.Text + "'";
               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sepciality_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@sep" };
                values = new string[] { textBox3.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sepciality_select", name_input, values, types);
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
                /*
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_select(@job nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type like N'%'+@job+'%'
                        end

                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type='" + comboBox1.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@job" };
                values = new string[] { comboBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_select", name_input, values, types);
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
                /*
                 * 
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_degree_select(@deg nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where degree like N'%'+@deg+'%'
                        end

                 * 
                 * */

                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where degree='" + comboBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_degree_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@deg" };
                values = new string[] { comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_degree_select", name_input, values, types);
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
               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doctor_id='" + textBox1.Text + "'";
               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_id_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox1.Text;
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@id" };
                values = new string[] { textBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_id_select", name_input, values, types);
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
                /*
                 * 
                    create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_sep_select(@name nvarchar(50),@sep nvarchar(50))
                    as
                    begin
                    select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%' + @name + '%' and specialization like N'%' + @sep + '%';
                    end
                 * 
                 */
               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox2.Text + "' and specialization='" + textBox3.Text + "'";

               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_sep_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
               // cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar,SqlDbType.NVarChar };
                name_input = new string[] { "@name","@sep" };
                values = new string[] { textBox2.Text, textBox3.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_sep_select", name_input, values, types);
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
                /* 
                create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_select(@name nvarchar(50),@job nvarchar(50))
                as
                begin
                select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%' and job_type like N'%'+@job+'%'
                end

                 */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox2.Text + "' and job_type='" + comboBox1.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@name", "@job" };
                values = new string[] { textBox2.Text, comboBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_select", name_input, values, types);
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
                /*
                 * 
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_degree_select(@name nvarchar(50),@deg nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%' and degree like N'%'+@deg+'%'
                        end

                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox1.Text + "' and degree='" + comboBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_degree_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                //cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@name", "@deg" };
                values = new string[] { textBox2.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_degree_select", name_input, values, types);
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
                /*
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_select(@job nvarchar(50),@sep nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type like N'%'+@job+'%' and specialization like N'%'+@sep+'%'
                        end

                 * */

                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type='" + comboBox1.Text + "' and specialization='" + textBox3.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@job", "@sep" };
                values = new string[] {  comboBox1.Text ,textBox3.Text};
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_select", name_input, values, types);
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
                /*
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_deg_select(@job nvarchar(50),@deg nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type like  N'%'+@job+'%' and degree like N'%'+@deg+'%'
                        end

                 * */

               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'";
               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_deg_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
               // cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@job", "@deg" };
                values = new string[] { comboBox1.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_deg_select", name_input, values, types);
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
                /*
                 * 
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sep_deg_select(@sep nvarchar(50),@deg nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where specialization like N'%'+@sep+'%' and degree like N'%'+@deg+'%'
                        end
                  */
               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where specialization='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sep_deg_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
               // cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@sep", "@deg" };
                values = new string[] { textBox3.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_sep_deg_select", name_input, values, types);
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
                /*
                 * 
                    create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_select(@name nvarchar(50),@job nvarchar(50),@sep nvarchar(50))
                    as
                    begin
                    select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%' and job_type like N'%'+@job+'%' and specialization like N'%'+@sep+'%'
                    end

                 * */
               // con.Open();
               // cmd.Connection = con;
               //// cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox2.Text + "' and job_type='" + comboBox1.Text + "' and specialization='" + textBox3.Text + "'";
               // cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
               // cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
               // cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
               // dr = cmd.ExecuteReader();


                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@name","@job","@sep" };
                values = new string[] { textBox2.Text, comboBox1.Text, textBox3.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_select", name_input, values, types);
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
                /*
                create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_deg_select(@name nvarchar(50),@job nvarchar(50),@deg nvarchar(50))
                as
                begin
                select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%' and job_type like N'%'+@job+'%' and degree like N'%'+@deg+'%'
                end

                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name='" + textBox2.Text + "' and job_type='" + comboBox1.Text + "' and degree='" + comboBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_deg_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
                //dr = cmd.ExecuteReader();


                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@name", "@job", "@deg" };
                values = new string[] { textBox2.Text, comboBox1.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_deg_select", name_input, values, types);
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
                /*
                 * 
                        create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_deg_select(@job nvarchar(50),@sep nvarchar(50),@deg nvarchar(50))
                        as
                        begin
                        select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type like N'%'+@job+'%' and specialization like N'%'+@sep+'%' and degree like N'%'+@deg+'%'
                        end

                 * 
                 */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where job_type='" + comboBox1.Text + "' and specialization='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_deg_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
                //cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@job", "@sep", "@deg" };
                values = new string[] { comboBox1.Text, textBox3.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_sep_deg_select", name_input, values, types);
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
                /*

                    create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_deg_select(@name nvarchar(50),@job nvarchar(50),@sep nvarchar(50),@deg nvarchar(50))
                    as
                    begin
                    select doctor_id as 'الكود', doc_name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , specialization as 'التخصص' from doctor where doc_name like N'%'+@name+'%' and job_type like N'%'+@job+'%' and specialization like N'%'+@sep+'%' and degree like N'%'+@deg+'%'
                    end

                 * */
                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "select code as 'الكود', name as 'الاسم' , job_type as 'نوع العمل' , degree as 'الفئة' , speciality as 'التخصص' from doctor where name='" + textBox2.Text + "' and job_type='" + comboBox1.Text + "' and speciality='" + textBox3.Text + "' and degree='" + comboBox2.Text + "'";
                //cmd.CommandText = "clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_deg_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                //cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = comboBox1.Text;
                //cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = textBox3.Text;
                //cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = comboBox2.Text;
                //dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@name","@job", "@sep", "@deg" };
                values = new string[] { textBox2.Text,comboBox1.Text, textBox3.Text, comboBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_name_job_sep_deg_select", name_input, values, types);
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            عطلات_الاطباء f1 = new عطلات_الاطباء();
            f1.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Code = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Name1 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*
             * 
                create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_deg_select
                as
                begin
                select degree from doctor
                end

             * */
            //da1 = new SqlDataAdapter("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_deg_select", con);
            ////da1 = new SqlDataAdapter("select degree from doctor;", con);
            //da1.Fill(ds1);

            con1.OpenConection();
            dr = con1.DataReader("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_deg_select");
            DataTable dt1 = new DataTable();
           // dt1 = ds1.Tables[0];
            dt1.Load(dr);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (!comboBox2.Items.Contains(dt1.Rows[i][0]))
                {
                    comboBox2.Items.Add(dt1.Rows[i][0].ToString());
                }
            }
            dr.Close();
            /*
             * 
            create procedure clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_All_select
            as
            begin
            select job_type from doctor
            end

             * */
            //da2 = new SqlDataAdapter("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_All_select", con);
            ////da2 = new SqlDataAdapter("select job_type from doctor;", con);
            //da2.Fill(ds2);

            con1.OpenConection();
            dr = con1.DataReader("clinic_محرك_بحث_فريق_العمل_الطبى_doctor_job_All_select");
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
            con1.CloseConnection();
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

        private void check_sting_name(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_sep(object sender, KeyPressEventArgs e)
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

            
    
