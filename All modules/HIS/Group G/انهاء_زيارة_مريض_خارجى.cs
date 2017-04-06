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
    public partial class انهاء_زيارة_مريض_خارجى : Form
    {
        // SqlCommand cmd;
        // SqlConnection con;
        SqlDataAdapter db;
        DataSet ds;
        DataTable dt;
        int p_id;
        int counte;
        int visit_num;
        DataGridViewCheckBoxColumn cb;
        DataGridViewButtonColumn btn;
        DataGridViewButtonColumn btn1;
        DataGridViewButtonColumn btn2;
        DataGridViewTextBoxColumn col_Result_Chosen1;
        DataGridViewTextBoxColumn col_Result_Chosen2;
        DataGridViewTextBoxColumn col_Result_Chosen3;
        string result_visit;
        string status_type;
        string File_Location;



        Connection con1 = new Connection();
        int count = 0;
        string[] name_input;
        string[] values;
        SqlDbType[] types;


        string update_;

        public انهاء_زيارة_مريض_خارجى()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_المرضى_انهاء f7 = new محرك_البحث_عن_المرضى_انهاء();
            if (f7.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = محرك_البحث_عن_المرضى_انهاء.Code.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //con = new SqlConnection("server=localhost;database=graduationDB;pwd=root;uid=root");
            //cmd = new SqlCommand();
            //cmd.Connection = con;
            //con.Open();
            int pid = 0;
            string query = "";
            DateTime dt = DateTime.Now;
            String date = dt.ToString("yyyy/MM/dd");


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                //cmd = new SqlCommand();
                //cmd.Connection = con;
                DataGridViewRow row = dataGridView1.Rows[i];
                try
                {
                    if ((bool)row.Cells[0].EditedFormattedValue == true)
                    {
                        /*


                            create procedure clinic_patient_visit_update(@pid int, @visit_num int, @e_date date)
                            as
                            begin
                            update Patient_visit set Type2 = 'close', End_date = @e_date where p_id = @pid and num_Of_visit = @visit_num;
                            end

                         * 
                         */


                        visit_num = int.Parse(row.Cells[3].Value.ToString());
                        pid = int.Parse(row.Cells[1].Value.ToString());
                        // query = "update Patient_visit set Type2 = 'close' where p_id = " + pid + " and num_Of_visit = " + visit_num;

                        //cmd.CommandText = "clinic_patient_visit_update";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@pid", pid);
                        //cmd.Parameters.AddWithValue("@visit_num", visit_num);
                        //cmd.Parameters.AddWithValue("@e_date", date);
                        //cmd.ExecuteNonQuery();


                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Date };
                        name_input = new string[] { "@pid", "@visit_num", "@e_date" };
                        values = new string[] { pid.ToString(), visit_num.ToString(), date };
                        con1.ExecuteNonQueryProcedure("clinic_entranceoffice_visit_update", name_input, values, types);
                        con1.CloseConnection();





                        if (row.Cells[6].Value.ToString() != "")
                        {
                            /*create procedure clinic_patient_visit_update_visit_Result(@pid_ int, @visit_num_ int, @result_visit varchar(50))
                                as
                                begin
                                 update Patient_visit set visit_Result = @result_visit where p_id = @pid_ and num_Of_visit = @visit_num_;
                                end

                             * 
                             */
                            result_visit = row.Cells[6].Value.ToString();
                            // update_ = "update Patient_visit set visit_Result  ='" + result_visit + "' where p_id = " + pid + " and num_Of_visit = " + visit_num;
                            //cmd.CommandText = "clinic_patient_visit_update_visit_Result";
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@pid_", pid);
                            //cmd.Parameters.AddWithValue("@visit_num_", visit_num);
                            //cmd.Parameters.AddWithValue("@result_visit", result_visit);
                            //cmd.ExecuteNonQuery();
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar };
                            name_input = new string[] { "@pid_", "@visit_num_", "@result_visit" };
                            values = new string[] { pid.ToString(), visit_num.ToString(), result_visit };
                            con1.ExecuteNonQueryProcedure("clinic_entranceoffice_visit_update_visit_Result", name_input, values, types);
                            con1.CloseConnection();

                        }
                        // result_visit = row.Cells[6].Value.ToString();
                        if (row.Cells[8].Value.ToString() != "")
                        {
                            /*
                             * create procedure clinic_patient_visit_update_type_status(@_pid int, @_visit_num int, @status_type varchar(50))
                                as
                                begin
                                 update Patient_visit set type_status = @status_type  where p_id = @_pid  and num_Of_visit =@_visit_num;
                                end

                             */
                            status_type = row.Cells[8].Value.ToString();
                            //update_ = "update Patient_visit set type_status   ='" + status_type + "' where p_id = " + pid + " and num_Of_visit = " + visit_num;
                            //cmd.CommandText = update_;
                            //cmd.CommandText = "clinic_patient_visit_update_type_status";
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@_pid", pid);
                            //cmd.Parameters.AddWithValue("@_visit_num", visit_num);
                            //cmd.Parameters.AddWithValue("@status_type", status_type);
                            //cmd.ExecuteNonQuery();
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar };
                            name_input = new string[] { "@_pid", "@_visit_num", "@status_type" };
                            values = new string[] { pid.ToString(), visit_num.ToString(), status_type };
                            con1.ExecuteNonQueryProcedure("clinic_entranceoffice_visit_update_type_status", name_input, values, types);
                            con1.CloseConnection();


                        }

                        //if (row.Cells[11].Value.ToString() != "")
                        //{
                        //    /*create procedure clinic_patient_visit_update_file_location(@_pid_ int, @File_Location nvarchar(50))
                        //        as
                        //        begin
                        //        update Patient set file_location = @File_Location where patient_id = @_pid_;
                        //        end

                        //     * 
                        //     */


                        //    File_Location = row.Cells[11].Value.ToString();

                        //    //cmd.CommandText = "clinic_patient_visit_update_file_location";
                        //    //cmd.CommandType = CommandType.StoredProcedure;
                        //    //cmd.Parameters.AddWithValue("@_pid_", pid);

                        //    //cmd.Parameters.AddWithValue("@File_Location", File_Location);
                        //    ////cmd.CommandText = update_;
                        //    //cmd.ExecuteNonQuery();
                        //    con1.OpenConection();
                        //    types = new SqlDbType[] {SqlDbType.Int, SqlDbType.NVarChar };
                        //    name_input = new string[] { "@_pid_", "@File_Location"};
                        //    values = new string[] { pid.ToString(), File_Location };
                        //    con1.ExecuteNonQueryProcedure("clinic_patient_visit_update_file_location", name_input, values, types);
                        //    con1.CloseConnection();



                        //}






                    }


                }
                catch (Exception exp)
                { }

            }


            MessageBox.Show(" تم عملية الحفظ بنجاح ");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.Visible = true;



            String d1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String d2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("التاريخ الاول يجب ان يكون اقل من التاريخ الثاني ");



            }


            else
            {
                //con = new SqlConnection("server=localhost;userid=root;password=root;database=graduationDB;");
                if (textBox1.Text == "")
                {

                    // MessageBox.Show(dateTimePicker1.Value.ToString("yyyy/MM/dd") + "   " + dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    string query = "select patient_id as N'كود المريض',patient_name as N'اسم المريض',visit_id as N'رقم الزيارة' ,date_of_birth as N'تاريخ الميلاد' from Registeration_patientRegisteration,entranceoffice_visit where patient_id=pat_id and type_of_visit=N'خارجي' and entrance_date between '" + d1 + "' and '" + d2 + "'";
                    //db = new SqlDataAdapter(query, con);


                    //ds = new DataSet();
                    //db.Fill(ds);

                    //cb = new DataGridViewCheckBoxColumn();
                    //cb.HeaderText = "اختيار_المريض";
                    //this.dataGridView1.Columns.Add(cb);
                    //dataGridView1.DataSource = ds.Tables[0];

                    con1.OpenConection();
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);
                    //    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.DataSource = dt;
                    con1.CloseConnection();



                    /////////////////////


                    ////////////////////





                    btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "نتيجة_الزيارة";
                    this.dataGridView1.Columns.Add(btn);


                    btn1 = new DataGridViewButtonColumn();
                    btn1.HeaderText = "نوع_الحالة";
                    this.dataGridView1.Columns.Add(btn1);


                    /*    btn2 = new DataGridViewButtonColumn();
                        btn2.HeaderText = "مكان_الملف";
                        this.dataGridView1.Columns.Add(btn2);
                    */


                    col_Result_Chosen1 = new DataGridViewTextBoxColumn();
                    col_Result_Chosen1.HeaderText = " نتيجة _الزيارة";
                    this.dataGridView1.Columns.Insert(6, col_Result_Chosen1);
                    //this.dataGridView1.Rows

                    // this.dataGridView1.Columns[6].Visible = false;


                    col_Result_Chosen2 = new DataGridViewTextBoxColumn();
                    col_Result_Chosen2.HeaderText = "نوع الحالة";
                    this.dataGridView1.Columns.Insert(8, col_Result_Chosen2);
                    //  this.dataGridView1.Columns[8].Visible = false;


                    /*   col_Result_Chosen3 = new DataGridViewTextBoxColumn();
                       col_Result_Chosen3.HeaderText = " مكان_الملف";
                       this.dataGridView1.Columns.Insert(11, col_Result_Chosen3);
                     //  this.dataGridView1.Columns[10].Visible = false;
   */

                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {


                        this.dataGridView1.Rows[i].Cells[0].Value = false;


                        this.dataGridView1.Rows[i].Cells[5].Value = "نتيجة الزيارة";
                        this.dataGridView1.Rows[i].Cells[6].Value = "";

                        this.dataGridView1.Rows[i].Cells[7].Value = "نوع الحالة";
                        this.dataGridView1.Rows[i].Cells[8].Value = "";

                        /*       this.dataGridView1.Rows[i].Cells[10].Value = "مكان الملف";
                               this.dataGridView1.Rows[i].Cells[11].Value = "";
                             */
                    }
                    foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                    {
                        if (dc.Index.Equals(0))
                        {
                            dc.ReadOnly = false;
                        }
                        else
                        {
                            dc.ReadOnly = true;
                        }
                    }



                    dataGridView1.AllowUserToAddRows = false;



                }
                else
                {

                    ds = new DataSet();

                    int s = int.Parse(textBox1.Text.ToString());
                    string query = "select patient_id as 'كودالمريض',patient_name as 'اسم المريض',visit_id as 'رقم الزيارة' ,date_of_birth as 'تاريخ الميلاد' from Registeration_patientRegisteration,entranceoffice_visit where patient_id=pat_id and patient_id='" + s + "'and type_of_visit=N'خارجي' and entrance_date between '" + d1 + "' and '" + d2 + "'";
                    // db = new SqlDataAdapter(query, con);
                    // db.Fill(ds);

                    // cb = new DataGridViewCheckBoxColumn();
                    // cb.HeaderText = "اختيار_المريض";
                    // this.dataGridView1.Columns.Add(cb);
                    //// dataGridView1.ColumnHeadersVisible = false;
                    // dataGridView1.DataSource = ds.Tables[0];


                    con1.OpenConection();
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.DataSource = dt;
                    con1.CloseConnection();

                    /////////////////////






                    btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "نتيجة_الزيارة";
                    this.dataGridView1.Columns.Add(btn);


                    btn1 = new DataGridViewButtonColumn();
                    btn1.HeaderText = "نوع_الحالة";
                    this.dataGridView1.Columns.Add(btn1);


                    /*       btn2 = new DataGridViewButtonColumn();
                           btn2.HeaderText = "مكان_الملف";
                           this.dataGridView1.Columns.Add(btn2);

                       */

                    col_Result_Chosen1 = new DataGridViewTextBoxColumn();
                    col_Result_Chosen1.HeaderText = " نتيجة _الزيارة";
                    this.dataGridView1.Columns.Insert(6, col_Result_Chosen1);
                    // this.dataGridView1.Columns[6].Visible = false;


                    col_Result_Chosen2 = new DataGridViewTextBoxColumn();
                    col_Result_Chosen2.HeaderText = "نوع الحالة";
                    this.dataGridView1.Columns.Insert(8, col_Result_Chosen2);
                    //  this.dataGridView1.Columns[8].Visible = false;


                    /*       col_Result_Chosen3 = new DataGridViewTextBoxColumn();
                           col_Result_Chosen3.HeaderText = " مكان_الملف";
                           this.dataGridView1.Columns.Insert(11, col_Result_Chosen3);
                         //  this.dataGridView1.Columns[10].Visible = false;
                       */

                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = false;
                        this.dataGridView1.Rows[i].Cells[5].Value = "نتيجة الزيارة";

                        this.dataGridView1.Rows[i].Cells[6].Value = "";

                        this.dataGridView1.Rows[i].Cells[7].Value = "نوع الحالة";
                        this.dataGridView1.Rows[i].Cells[8].Value = "";

                        /*       this.dataGridView1.Rows[i].Cells[10].Value = "مكان الملف";
                               this.dataGridView1.Rows[i].Cells[11].Value = "";
                          */
                    }

                    foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                    {
                        if (dc.Index.Equals(0) || dc.Index.Equals(7) || dc.Index.Equals(9) || dc.Index.Equals(11))
                        {
                            dc.ReadOnly = false;
                        }
                        else
                        {
                            dc.ReadOnly = true;
                        }
                    }


                    dataGridView1.AllowUserToAddRows = false;

                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // con = new SqlConnection("server=localhost;userid=root;password=root");
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

        }

        private void انهاء_زيارة_مريض_خارجى_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;


        }


        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex != dataGridView1.Rows.Count)
                {
                    نتيجة_الزيارة f7 = new نتيجة_الزيارة();


                    if (f7.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = نتيجة_الزيارة.Des.ToString();
                    }

                }
                if (e.ColumnIndex == 7 && e.RowIndex >= 0 && e.RowIndex != dataGridView1.Rows.Count)
                {

                    نوع_الحالة f7 = new نوع_الحالة();
                    if (f7.ShowDialog() == DialogResult.OK)
                    {

                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = نوع_الحالة.Des.ToString();
                    }

                }
                /*      if (e.ColumnIndex == 10 && e.RowIndex >= 0 && e.RowIndex != dataGridView1.Rows.Count)
                      {

                          مكان_الملف f7 = new مكان_الملف();
                          if (f7.ShowDialog() == DialogResult.OK)
                          {

                              dataGridView1.Rows[e.RowIndex].Cells[11].Value = مكان_الملف.Des.ToString();
                          }

                      }*/
            }
            catch (Exception ex)
            {

            }

        }



        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            counte = dataGridView1.Rows.Count;
            if (checkBox3.Checked)
            {

                for (int i = 0; i < counte; i++)
                {
                    this.dataGridView1[0, i].Value = true;

                }

            }
            else
            {
                for (int i = 0; i < counte; i++)
                {
                    this.dataGridView1[0, i].Value = false;

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (checkBox1.Checked)
                {
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    button6.Visible = true;

                }
                else
                {

                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    button6.Visible = false;
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            نوع_الحالة f = new نوع_الحالة();

            if (f.ShowDialog() == DialogResult.OK)
            {

                textBox6.Text = نوع_الحالة.Des;
                textBox7.Text = نوع_الحالة.Code.ToString();


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[8].Value = textBox6.Text.ToString();

                }


            }



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            نتيجة_الزيارة f = new نتيجة_الزيارة();

            if (f.ShowDialog() == DialogResult.OK)
            {
                //this.dataGridView1.Columns[6].Visible = true; 

                textBox5.Text = نتيجة_الزيارة.Des;
                textBox4.Text = نتيجة_الزيارة.Code.ToString();


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells[6].Value = textBox5.Text.ToString();

                }

            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (checkBox2.Checked)
                {
                    textBox7.Visible = true;
                    textBox6.Visible = true;
                    button7.Visible = true;


                }
                else
                {
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    button7.Visible = false;
                }
            }


        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        private void header_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            // this.dataGridView1.CancelEdit();// = true;
            counte = dataGridView1.Rows.Count;
            for (int i = 0; i < counte; i++)
            {

                this.dataGridView1.Rows[i].Cells[5].Value = "نتيجة الزيارة";

                this.dataGridView1.Rows[i].Cells[7].Value = "نوع الحالة";

                //  this.dataGridView1.Rows[i].Cells[10].Value = "مكان الملف";

            }

        }

    }
}
