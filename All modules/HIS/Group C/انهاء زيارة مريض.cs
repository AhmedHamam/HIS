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
    public partial class انهاء_زيارة_مريض : Form
    {
        //MySqlConnection con;
        //MySqlCommand cmd1;
        //MySqlDataAdapter db;
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
        Connection con = new Connection();
        string result_visit;
        string status_type;
        string File_Location;


        string update_;

        public انهاء_زيارة_مريض()
        {
            InitializeComponent();
        }

        private void انهاء_زيارة_مريض_Load(object sender, EventArgs e)
        {
            // con = new MySqlConnection("server=localhost;database=hospital1;uid=root;pwd=root");


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.Visible = true;


            String d1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            String d2 = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            con.OpenConection();
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("التاريخ الاول يجب ان يكون اقل من التاريخ الثاني ");

            }

            else
            {

                if (textBox15.Text != "" && checkBox1.Checked == true)
                {

                    string[] s = new string[] { "@date1", "@date2", "@pi" };
                    string[] s2 = new string[] { d1, d2, textBox15.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };
                    // dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("finish_patient_visit1", s, s2, s3);
                    // MessageBox.Show(dateTimePicker1.Value.ToString("yyyy/MM/dd") + "   " + dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    //string query = "select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit from entranceoffice_visits,Registeration_patientRegisteration where patient_id=pat_id and entrance_date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  and pat_id=" + int.Parse(textBox15.Text) + ";";
                    //db = new MySqlDataAdapter(query, con);


                    //ds = new DataSet();
                    //db.Fill(ds);

                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("finish_patient_visit1", s, s2, s3);



                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {


                        this.dataGridView1.Rows[i].Cells[0].Value = false;

                    }



                    dataGridView1.AllowUserToAddRows = false;



                }
                else if (textBox15.Text == "" && checkBox1.Checked == true)
                {

                    string[] s = new string[] { "@date1", "@date2" };
                    string[] s2 = new string[] { d1, d2 };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                    // MessageBox.Show(dateTimePicker1.Value.ToString("yyyy/MM/dd") + "   " + dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    //string query = "select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit from entranceoffice_visits,Registeration_patientRegisteration where patient_id=pat_id and entrance_date between '"+dateTimePicker1.Text+"' and '"+dateTimePicker2.Text+"';";
                    //db = new MySqlDataAdapter(query, con);


                    //ds = new DataSet();
                    //db.Fill(ds);

                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("finish_patient_visit2", s, s2, s3);



                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {


                        this.dataGridView1.Rows[i].Cells[0].Value = false;

                    }



                    dataGridView1.AllowUserToAddRows = false;



                }
                else if (textBox15.Text != "" && checkBox1.Checked == false)
                {
                    string[] s = new string[] { "@pi" };
                    string[] s2 = new string[] { textBox15.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };

                    // MessageBox.Show(dateTimePicker1.Value.ToString("yyyy/MM/dd") + "   " + dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    //string query = "select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit,name  from entranceoffice_visits,Registeration_patientRegisteration, where patient_id=pat_id and pat_id=" + int.Parse(textBox15.Text) + ";";
                    //db = new MySqlDataAdapter(query, con);


                    //ds = new DataSet();
                    //db.Fill(ds);

                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("finish_patient_visit3", s, s2, s3);


                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {


                        this.dataGridView1.Rows[i].Cells[0].Value = false;

                    }



                    dataGridView1.AllowUserToAddRows = false;



                }
                else
                {


                    //string query = "select patient_id,patient_name,visit_id,entrance_date,expected_exit_date,type_of_visit from entranceoffice_visits,Registeration_patientRegisteration where patient_id=pat_id;";
                    //db = new MySqlDataAdapter(query, con);


                    //ds = new DataSet();
                    //db.Fill(ds);

                    cb = new DataGridViewCheckBoxColumn();
                    cb.HeaderText = "اختيار_المريض";
                    this.dataGridView1.Columns.Add(cb);
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("finish_patient_visit4");


                    counte = dataGridView1.Rows.Count;
                    for (int i = 0; i < counte; i++)
                    {


                        this.dataGridView1.Rows[i].Cells[0].Value = false;

                    }



                    dataGridView1.AllowUserToAddRows = false;

                }


            }
            con.CloseConnection();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            int pid = 0;
            string s = "";
            DateTime d = DateTime.Now;
            string dat = d.ToString("yyyy/MM/dd");
            //   cmd1 = new MySqlCommand();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                try
                {
                    if ((bool)row.Cells[0].EditedFormattedValue == true)
                    {
                        pid = int.Parse(row.Cells[1].Value.ToString());


                        string[] f = new string[] { "@d2", "@id" };
                        string[] f2 = new string[] { dat, pid.ToString() };

                        SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
                        if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("finish_patient_visit_save", f, f2, f3))
                        {
                            MessageBox.Show("لم يتم انهاء الزياره");
                            return;
                        }

                        //string s = "update entranceoffice_visits set entrance_date=@d1,expected_exit_date=@d2,type_of_visit=@v where pat_id=@id;";

                        //cmd = new MySqlCommand(s, con);

                        //cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                        //cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Text);
                        //cmd.Parameters.AddWithValue("@v", textBox18.Text);
                        //cmd.Parameters.AddWithValue("@id", textBox10.Text);
                        //cmd.ExecuteNonQuery();
                        //MessageBox.Show("تم تاكيد فتح زيارة خارجى للمريض");
                        //s = "update entranceoffice_visits set expected_exit_date=@d2 where pat_id =@id ";
                        //cmd1 = new MySqlCommand(s, con);
                        ////  cmd1.Parameters.AddWithValue("@d1",dateTimePicker1.Text);
                        //cmd1.Parameters.AddWithValue("@d2", dat);
                        //cmd1.Parameters.AddWithValue("@id", pid);
                        //cmd1.ExecuteNonQuery();
                        MessageBox.Show("تم انهاء زيارة المريض");
                    }


                }
                catch (Exception )
                {
                }
            }

            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض_الملف_الطبي h = new محرك_البحث_عن_مريض_الملف_الطبي();

            if (h.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = محرك_البحث_عن_مريض_الملف_الطبي.Code1.ToString();
                // textBox1.Text = الخدمات.Code2.ToString();
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox15.Text = "";
            checkBox1.Checked = false;
            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
}
