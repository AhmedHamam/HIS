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
    public partial class تقرير_قائمة_طبقا_للجنس : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        DataSet ds = new DataSet();
       // MySqlDataAdapter da;
        BindingSource bs;
        public تقرير_قائمة_طبقا_للجنس()
        {
            InitializeComponent();
        }

        private void تقرير_قائمة_طبقا_للجنس_Load(object sender, EventArgs e)
        {

          //  con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");

            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "ذكر";
            string s2 = "أنثى";

           // da = new MySqlDataAdapter();
            string d = dateTimePicker1.Text.ToString();
            string d2 = dateTimePicker2.Text.ToString();
            

                if (d.Length != 0 & d2.Length != 0)
                {
                    if (radioButton4.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                    {



                        try
                        {
                            if (radioButton2.Checked == true)
                            {

                                string[] a = new string[] { "@x", "@y", "@z" };
                                string[] a2 = new string[] { d,d2,s1 };
                                SqlDbType[] a3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date, SqlDbType.VarChar };
                                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_gender", a, a2, a3);

                            //     cmd = new MySqlCommand("select patient_id as 'رقم الملف',patient_name as 'اسم المريض',gender as 'الجنس',date_of_birth as 'تاريخ الميلاد',nationality as'الجنسيه'"

                            //+ ",date_Regist as 'تاريخ التسجيل',emp_name as 'اسم الموظف',name_diroctory as 'الجهه الماليه',name as 'الفئه'"
                            //+ "from  Registeration_patientRegisteration,employees,diroctorys,catogricals where emp_code=employ_code and "
                            //+ "diroctor_code=dir_code and catog_code=catogrical_code and date_Regist between @date1 and @date2 and gender=@g;", con);

                                //cmd = new MySqlCommand("select patient_name from Registeration_patientRegisteration where date_Regist between @date1 and @date2 and gender=@g; ", con);

                                //cmd.Parameters.AddWithValue("@date1", d);
                                //cmd.Parameters.AddWithValue("@date2", d2);
                                //cmd.Parameters.AddWithValue("@g", s1);
                                //da.SelectCommand = cmd;


                                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                                //da.Fill(ds);
                                //bs = new BindingSource();
                                //bs.DataSource = ds.Tables[0];
                                //dataGridView1.DataSource = bs;
                                //con.Close();
                            }
                            else if (radioButton3.Checked == true)
                            {

                                string[] a = new string[] { "@x", "@y", "@z" };
                                string[] a2 = new string[] { d, d2, s2 };
                                SqlDbType[] a3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date, SqlDbType.VarChar };
                                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_gender", a, a2, a3);

                            //    cmd = new MySqlCommand("select patient_id as 'رقم الملف',patient_name as 'اسم المريض',gender as 'الجنس',date_of_birth as 'تاريخ الميلاد',nationality as'الجنسيه'"

                            //+ ",date_Regist as 'تاريخ التسجيل',emp_name as 'اسم الموظف',name_diroctory as 'الجهه الماليه',name as 'الفئه'"
                            //+ "from  Registeration_patientRegisteration,employees,diroctorys,catogricals where emp_code=employ_code and "
                            //+ "diroctor_code=dir_code and catog_code=catogrical_code and date_Regist between @date1 and @date2 and gender=@g ;", con);


                            //    cmd.Parameters.AddWithValue("@date1", d);
                            //    cmd.Parameters.AddWithValue("@date2", d2);
                            //    cmd.Parameters.AddWithValue("@g", s2);
                            //    da.SelectCommand = cmd;


                            //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                            //    da.Fill(ds);
                            //    bs = new BindingSource();
                            //    bs.DataSource = ds.Tables[0];
                            //    dataGridView1.DataSource = bs;
                            //    con.Close();
                            }
                            else if (radioButton4.Checked==true)
                            {

                                string[] a = new string[] { "@x", "@y" };
                                string[] a2 = new string[] { d, d2};
                                SqlDbType[] a3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date};
                                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_gender1", a, a2, a3);
                            //    cmd = new MySqlCommand("select patient_id as 'رقم الملف',patient_name as 'اسم المريض',gender as 'الجنس',date_of_birth as 'تاريخ الميلاد',nationality as'الجنسيه'"

                            //+ ",date_Regist as 'تاريخ التسجيل',emp_name as 'اسم الموظف',name_diroctory as 'الجهه الماليه',name as 'الفئه'"
                            //+ "from  Registeration_patientRegisteration,employees,diroctorys,catogricals where emp_code=employ_code and "
                            //+ "diroctor_code=dir_code and catog_code=catogrical_code and date_Regist between @date1 and @date2;", con);


                            //    cmd.Parameters.AddWithValue("@date1", d);
                            //    cmd.Parameters.AddWithValue("@date2", d2);
                            //    // cmd.Parameters.AddWithValue("@g", s2);
                            //    da.SelectCommand = cmd;


                            //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                            //    da.Fill(ds);
                            //    bs = new BindingSource();
                            //    bs.DataSource = ds.Tables[0];
                            //    dataGridView1.DataSource = bs;
                            //    con.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }


        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
