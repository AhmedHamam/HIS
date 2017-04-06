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
    public partial class بحث_حجوزات_المرضى : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;

        public بحث_حجوزات_المرضى()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            العيادة_الخارجية f = new العيادة_الخارجية();
       
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = العيادة_الخارجية.id.ToString();
                textBox5.Text = العيادة_الخارجية.name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            الطبيب f = new الطبيب();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = الطبيب.id.ToString();
                textBox6.Text = الطبيب.name;
            }
        }

        private void بحث_حجوزات_المرضى_Load(object sender, EventArgs e)
        {
            textBox1.Text = البحث_حجوزات_المرضي.Code.ToString();
            textBox4.Text = البحث_حجوزات_المرضي.name; 
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.Columns.Clear();
            //con = new SqlConnection("server=localhost;database=graduationDB;uid=root;pwd=root");
            //con.Open();
            string begin = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string end = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("التاريخ الاول يجب ان يكون اقل من التاريخ الثاني ");
            }
            else
            {
                if (textBox2.Text == "" && textBox3.Text == "" && textBox5.Text == "" && textBox6.Text == "")
                {

                    /*create procedure clinic_search_patient_visit_select(@pid int , @begin date, @end date)
                        as
                        begin
                         select num_of_visit , start_date ,service_name from patient_visit where p_id = @pid and start_date between @begin and  @end
                        end
                     * 
                     */
                   
                    int y =Convert.ToInt32(textBox1.Text);
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Date, SqlDbType.Date};
                    name_input = new string[] { "@pid", "@begin", "@end" };
                    values = new string[] { y.ToString(), begin, end };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_search_patient_visit_select", name_input, values, types);
                    dt = new DataTable();
                    dt.Load(dr);
                    
                    dataGridView1.Visible = true;
                   // con1.CloseConnection();

                    DataGridViewTextBoxColumn tex1 = new DataGridViewTextBoxColumn();
                    tex1.HeaderText = "كود_المريض";
                    dataGridView1.Columns.Add(tex1);

                    DataGridViewTextBoxColumn tex2 = new DataGridViewTextBoxColumn();
                    tex2.HeaderText = "اسم_المريض";
                    dataGridView1.Columns.Add(tex2);


                    dataGridView1.DataSource = dt;
                    dr.Close();

                    DateTime begin1 = dateTimePicker1.Value;
                    DateTime end1 = dateTimePicker2.Value;

                    //       cmd.CommandText = "select english_name  as اسم_العيادة ,doc_name as اسم_الدكتور  from clinic,doctor, shift_time"
                    //+ " where clinic_code=shift_time.c_code and doctor_id = d_id and CAST(Start_Time AS DATE )  between '"
                    //+ begin1 + "' and '" + end1 + "'  and shift_time.c_code  = any(select c_code from Treat_Patient where PId = "
                    //+ int.Parse(textBox1.Text) + " ) and start_time = any(select start_date from patient_visit where p_id ="
                    //+ int.Parse(textBox1.Text) + " )";

                    /*
                     * 

                    
                        create procedure clinic_search_patient_visit_select_1(@begin1 datetime, @end1 datetime, @pid int)
                        as
                        begin
                          select english_name ,doc_name from clinic,doctor, shift_time
                                 where clinic_code=shift_time.c_code and doctor_id = d_id and CAST(Start_Time AS DATE )  between
                                 @begin1 and @end1 and shift_time.c_code  = any(select c_code from Treat_Patient where PId =@pid) and start_time = any(select start_date from patient_visit where p_id = @pid);
        
                        end

                     * 
                     */
                    
                     y = Convert.ToInt32(textBox1.Text);
                    types = new SqlDbType[] { SqlDbType.DateTime, SqlDbType.DateTime, SqlDbType.Int };
                    name_input = new string[] { "@begin1", "@end1", "@pid" };
                    values = new string[] {begin1.ToString(),end1.ToString() ,y.ToString()};
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_search_patient_visit_select_1", name_input, values, types);
                   
                    int i = 0;

                    DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                    tbc.HeaderText = "اسم_العيادة";
                    dataGridView1.Columns.Add(tbc);
                    DataGridViewTextBoxColumn tbc2 = new DataGridViewTextBoxColumn();
                    tbc2.HeaderText = "اسم_الدكتور";
                    dataGridView1.Columns.Add(tbc2);
                    //after reading datareader have exception
                    try
                    {
                        while (dr.Read())
                        {

                            dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                            dataGridView1.Rows[i].Cells[1].Value = textBox4.Text;
                            dataGridView1.Rows[i].Cells[5].Value = dr[0].ToString();
                            dataGridView1.Rows[i].Cells[6].Value = dr[1].ToString();
                            i++;
                        }
                    }
                    catch (Exception ex) { }
                    dr.Close();
                    con1.CloseConnection();

                }

                else if (textBox6.Text == "" && textBox3.Text == "")
                {

                    /*
                     * create procedure clinic_search_patient_visit_select_2(@begin date, @end date, @pid int, @c_code int)
                            as
                            begin
                             select distinct num_of_visit, start_date,service_name ,english_name, doc_name
                             from clinic, doctor, patient_visit,treat_patient,shift_time
                             where clinic_code = shift_time.c_code and doctor_id = d_id and shift_time.c_code = treat_patient.c_code 
                             and  p_id = pid and p_id =pid and start_date between @begin and @end and treat_patient.c_code = @c_code and start_date = start_time;
                            end

                     */


                    con1.OpenConection();
                    int y = Convert.ToInt32(textBox1.Text);
                    int y1 = Convert.ToInt32(textBox2.Text);
                    types = new SqlDbType[] {SqlDbType.Date, SqlDbType.Date,SqlDbType.Int,  SqlDbType.Int };
                    name_input = new string[] {  "@begin", "@end","@pid" ,"@c_code"};
                    values = new string[] {  begin, end,y.ToString(),y1.ToString() };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_search_patient_visit_select_2", name_input, values, types);
                    
                    
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.Visible = true;
                    con1.CloseConnection();
                    DataGridViewTextBoxColumn tex1 = new DataGridViewTextBoxColumn();
                    tex1.HeaderText = "كود_المريض";
                    dataGridView1.Columns.Add(tex1);

                    DataGridViewTextBoxColumn tex2 = new DataGridViewTextBoxColumn();
                    tex2.HeaderText = "اسم_المريض";
                    dataGridView1.Columns.Add(tex2);

                    dataGridView1.DataSource = dt;
                    dr.Close();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                        dataGridView1.Rows[i].Cells[1].Value = textBox4.Text;

                    }

                }

                else if (textBox2.Text == "" && textBox5.Text == "")
                {
                    /*create procedure clinic_search_patient_visit_select_3(@begin date, @end date, @pid int, @d_code int)
                        as
                        begin
                         select distinct num_of_visit, start_date,service_name,english_name, doc_name 
                         from clinic, doctor, patient_visit,treat_patient,shift_time 
                         where clinic_code = shift_time.c_code and doctor_id = d_id and shift_time.c_code = treat_patient.c_code 
                         and  p_id = pid and p_id = pid and start_date between @begin and @end and d_id = @d_code and start_date = start_time;
                        end

                     */




                    con1.OpenConection();
                    int y = Convert.ToInt32(textBox1.Text);
                    int y1 = Convert.ToInt32(textBox3.Text);
                    types = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date, SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@pid", "@begin", "@end", "@d_code" };
                    values = new string[] { y.ToString(), begin, end, y1.ToString() };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_search_patient_visit_select_3", name_input, values, types);
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.Visible = true;
                    con1.CloseConnection();
                    DataGridViewTextBoxColumn tex1 = new DataGridViewTextBoxColumn();
                    tex1.HeaderText = "كود_المريض";
                    dataGridView1.Columns.Add(tex1);

                    DataGridViewTextBoxColumn tex2 = new DataGridViewTextBoxColumn();
                    tex2.HeaderText = "اسم_المريض";
                    dataGridView1.Columns.Add(tex2);


                    dataGridView1.DataSource = dt;
                    dr.Close();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                        dataGridView1.Rows[i].Cells[1].Value = textBox4.Text;

                    }

                }

                else
                {
                    /*create procedure clinic_search_patient_visit_select_4(@begin date, @end date, @pid int, @d_code int, @c_code int)
                            as
                            begin
                             select distinct num_of_visit, start_date ,service_name ,english_name , doc_name 
                             from clinic, doctor, patient_visit,treat_patient,shift_time 
                             where clinic_code = shift_time.c_code and doctor_id = d_id and shift_time.c_code = treat_patient.c_code 
                             and  p_id = pid and p_id = pid and start_date between  @begin  and  @end  and d_id =@d_code and treat_patient.c_code = @c_code and start_date = start_time;
                            end

                     * 
                     */
                    //cmd = new SqlCommand();
                    //cmd.Connection = con;
                    ////cmd.CommandText = "select distinct num_of_visit as رقم_الزيارة, start_date as تاريخ_الخدمة ,service_name as اسم_الخدمة ,english_name as اسم_العيادة, doc_name as اسم_الدكتور from clinic, doctor, patient_visit,treat_patient,shift_time where clinic_code = shift_time.c_code and doctor_id = d_id and shift_time.c_code = treat_patient.c_code and  p_id = pid and p_id = " + int.Parse(textBox1.Text) + " and start_date between '" + begin + "' and '" + end + "' and d_id = " + int.Parse(textBox3.Text) + " and treat_patient.c_code = " + int.Parse(textBox2.Text) + " and start_date = start_time;";
                    //cmd.CommandText = "clinic_search_patient_visit_select_4";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
                    //cmd.Parameters.AddWithValue("@begin", begin);
                    //cmd.Parameters.AddWithValue("@end", end);
                    //cmd.Parameters.AddWithValue("@d_code", int.Parse(textBox3.Text));
                    //cmd.Parameters.AddWithValue("@c_code", int.Parse(textBox2.Text));
                    //dr = cmd.ExecuteReader();
                    //cmd.Parameters.RemoveAt("@pid");
                    //cmd.Parameters.RemoveAt("@begin");
                    //cmd.Parameters.RemoveAt("@end");
                    //cmd.Parameters.RemoveAt("@d_code");
                    //cmd.Parameters.RemoveAt("@c_code");

                    con1.OpenConection();
                    int y = Convert.ToInt32(textBox1.Text);
                    int y2 = Convert.ToInt32(textBox2.Text);
                    int y3 = Convert.ToInt32(textBox3.Text);
                    types = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date, SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@pid", "@begin", "@end", "@d_code","@c_code" };
                    values = new string[] { y.ToString(), begin, end, y3.ToString(),y2.ToString() };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_search_patient_visit_select_4", name_input, values, types);
                    
                    
                    dt = new DataTable();
                    dt.Load(dr);
                    //dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.Visible = true;
                    con1.CloseConnection();
                    DataGridViewTextBoxColumn tex1 = new DataGridViewTextBoxColumn();
                    tex1.HeaderText = "كود_المريض";
                    dataGridView1.Columns.Add(tex1);

                    DataGridViewTextBoxColumn tex2 = new DataGridViewTextBoxColumn();
                    tex2.HeaderText = "اسم_المريض";
                    dataGridView1.Columns.Add(tex2);


                    dataGridView1.DataSource = dt;
                    dr.Close();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                        dataGridView1.Rows[i].Cells[1].Value = textBox4.Text;

                    }

                }
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           // textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void header_click(object sender, DataGridViewCellMouseEventArgs e)
        {

           
           /* for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                this.dataGridView1.Rows[i].Cells[0].Value = "كود_المريض";

                this.dataGridView1.Rows[i].Cells[1].Value = "اسم_المريض";

                this.dataGridView1.Rows[i].Cells[5].Value = "اسم_العيادة";
                this.dataGridView1.Rows[i].Cells[6].Value = "اسم_الدكتور";


            }
            * */
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
