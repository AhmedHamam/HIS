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
    public partial class البحث_حجوزات_المرضي : Form
    {
        public static int Code { get; set; }
        public static string name { get; set; }
        
      
        SqlDataAdapter da;
        string x1;


        Connection con1 = new Connection();
        int count = 0;

        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        public البحث_حجوزات_المرضي()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            rectangleShape2.Visible = false;

            rectangleShape1.Visible = false;
            label2.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label28.Visible = false;
            label27.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label2.Visible = false;
            rectangleShape2.Visible = false;
            rectangleShape1.Visible = false;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

                
                if (textBox1.Text != "")
                {
                    //cmd = new SqlCommand("select patient_id  as 'رقم المريض',concat(fname, ' ' , sname , '  ' , thname , '  ' , lname) as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where patient_id='" + textBox1.Text + "'", con);

                    //SqlDataReader dr = cmd.ExecuteReader();
                    con1.OpenConection();
                    string query = "select patient_id  as 'رقم المريض',fname+ ' ' + sname + '  ' + thname + '  ' + lname as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where patient_id='" + textBox1.Text + "'";
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }
                else if (textBox2.Text != "")
                {
                    //cmd = new SqlCommand("select patient_id  as 'رقم المريض',concat(fname, ' ' , sname , '  ' , thname , '  ' , lname) as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where fname like '" + textBox2.Text + "%' ", con);
                    //SqlDataReader dr = cmd.ExecuteReader();
                    con1.OpenConection();
                    string query = "select patient_id  as 'رقم المريض',fname+ ' ' + sname + '  ' + thname + '  ' + lname as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where fname like '" + textBox2.Text + "%'";
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();

                }
                else if (textBox3.Text != "")
                {
                    // cmd = new SqlCommand("select patient_id  as 'رقم المريض',concat(fname, ' ' , sname , '  ' , thname , '  ' , lname) as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where SSN=" + textBox3.Text + " ", con);
                    // SqlDataReader dr = cmd.ExecuteReader();
                    con1.OpenConection();
                    string query = "select patient_id  as 'رقم المريض',fname+ ' ' + sname + '  ' + thname + '  ' + lname as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient where SSN=" + textBox3.Text + " ";
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    //cmd = new SqlCommand("select patient_id  as 'رقم المريض',concat(fname, ' ' , sname , '  ' , thname , '  ' , lname) as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient", con);
                    //SqlDataReader dr = cmd.ExecuteReader();
                    con1.OpenConection();
                    string query = "select patient_id  as 'رقم المريض',fname+ ' ' + sname + '  ' + thname + '  ' + lname as 'اسم المريض',job as 'الرتبه/اللقب',date_of_birth  as 'تاريخ الميلاد',gender as 'النوع',file_date as 'تاريخ فتح الملف' from patient";
                    SqlDataReader dr = con1.DataReader(query);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }

            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label16.Visible = false;

            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label28.Visible = false;
            label27.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label2.Visible = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            rectangleShape1.Visible = false;
            rectangleShape2.Visible = false;


        }
        //         send data
        private void send(object sender, DataGridViewCellEventArgs e)
        {
            x1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
                rectangleShape2.Visible = false;

                rectangleShape1.Visible = false;
                label2.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;


                con1.OpenConection();
                string query = "select num_Of_visit  as'رقم الزياره',start_date as 'من تاريخ',End_date as'الى تاريخ' from Patient_visit where P_id='" + x1 + "'";
                SqlDataReader dr = con1.DataReader(query);
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con1.CloseConnection();


        }
        // send details about the visit of patient
        private void visit_details(object sender, DataGridViewCellEventArgs e)
        {
            string n = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
           con1.OpenConection();
            string query = "select Type,ordere,patient_status from Patient_visit where num_Of_visit='" + n + "'; select ins_name from institution ,patient where Institution=ins_code and patient_id='" + x1 + "';select r_id,degree,floor from room,patient_visit where r_id=room_id and num_Of_visit='" + n + "' ";
            SqlDataReader dr = con1.DataReader(query);
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Read();
            string type_visit = dr[0].ToString();
            string order = dr[1].ToString();

                label31.Text = dr[2].ToString();
                dr.NextResult(); dr.Read(); string geha = dr[0].ToString();
                dr.NextResult(); dr.Read();
                label27.Text = dr[0].ToString() + "  /" + dr[2].ToString();
                label29.Text = dr[1].ToString();
                dr.Close();
                label19.Text = order;
                label17.Text = type_visit;
                label23.Text = geha;
                label2.Visible = true;
                label17.Visible = true;
                label16.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                if (type_visit == "خارجي")
                {
                    label24.Visible = true;
                    label25.Visible = true;
                    label26.Visible = false;
                    label27.Visible = false;
                    label28.Visible = false;
                    label29.Visible = false;
                    label30.Visible = false;
                    label31.Visible = false;
                }
                else
                {
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = true;
                    label27.Visible = true;
                    label28.Visible = true;
                    label29.Visible = true;
                    label30.Visible = true;
                    label31.Visible = true;
                }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                MessageBox.Show(Code.ToString());
                بحث_حجوزات_المرضى ff = new بحث_حجوزات_المرضى();
                ff.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يجب اختيار مريض ");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }








    }
}