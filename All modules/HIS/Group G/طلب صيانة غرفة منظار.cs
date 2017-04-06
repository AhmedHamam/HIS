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

    public partial class صيانة_طلب_غرفة_منظار : Form
    {
        public static string item { get; set; }

        public صيانة_طلب_غرفة_منظار()
        {
            InitializeComponent();
            showlist();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            اختيار_غرفة f = new اختيار_غرفة();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = اختيار_غرفة.x.ToString();
            }
        }
        Connection con = new Connection();
        //  SqlCommand cmd;
        //  SqlConnection con;
        ////  DataSet ds=new DataSet();
        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        string s = "";
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (s == "" || s == "tashhia")
            {
                s = "wekaya";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (s == "" || s == "wekaya")
            {
                s = "tashhia";
            }
        }
        string x = "";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (x == "" || x != "")
            {
                x += "تكيف";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (x == "" || x != "")
            {
                x += " و" + "سباكة";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (x == "" || x != "")
            {
                x += " و" + "نجارة";
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (x == "" || x != "")
            {
                x += "و" + "دهانات";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (x == " " || x != "")
            {
                x += "و" + "اخري";
            }
        }
        private void مساعدةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            string d = dt.Year.ToString() + '-' + dt.Month.ToString() + '-' + dt.Day.ToString();
            if (textBox2.Text == "")
            {
                MessageBox.Show("يجب اختيار غرفة");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("يجب اختيار موظف  ");
            }
            else
            {
                try
                {
                    string[] pramname = new string[9];
                    string[] pramvalue = new string[9];
                    SqlDbType[] pramtype = new SqlDbType[9];
                    pramname[0] = "@code";
                    pramname[1] = "@mt";
                    pramname[2] = "@mf";
                    pramname[3] = "@arb_name";
                    pramname[4] = "@latin_name";
                    pramname[5] = "@dt";
                    pramname[6] = "@n";
                    pramname[7] = "@em_id";
                    pramname[8] = "@room_code";

                    pramvalue[0] = textBox1.Text;
                    pramvalue[1] = s;
                    pramvalue[2] = x;
                    pramvalue[3] = textBox6.Text;
                    pramvalue[4] = textBox3.Text;
                    pramvalue[5] = d;
                    pramvalue[6] = textBox9.Text;
                    pramvalue[7] = textBox11.Text;
                    pramvalue[8] = textBox2.Text;


                    pramtype[0] = SqlDbType.Int;
                    pramtype[1] = SqlDbType.NVarChar;
                    pramtype[2] = SqlDbType.NVarChar;
                    pramtype[3] = SqlDbType.NVarChar;
                    pramtype[4] = SqlDbType.NVarChar;
                    pramtype[5] = SqlDbType.NVarChar;
                    pramtype[6] = SqlDbType.NVarChar;
                    pramtype[7] = SqlDbType.Int;
                    pramtype[8] = SqlDbType.Int;

                    con.OpenConection();
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("setescope_Room_maintenance_insert", pramname, pramvalue, pramtype);

                    MessageBox.Show("تم طلب الصيانة");

                    con.CloseConnection();
                    con.OpenConection();
                    SqlDataReader dr = con.DataReader("setescope_Room_maintenance_count");
                    dr.Read();
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    textBox1.Text = c.ToString();
                    //cmd = new SqlCommand("setescope_Room_maintenance_insert", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@code", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@mt",s);
                    //cmd.Parameters.AddWithValue("@mf", x);
                    //cmd.Parameters.AddWithValue("@arb_name",textBox6.Text);
                    //cmd.Parameters.AddWithValue("@latin_name", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@dt", d);
                    //cmd.Parameters.AddWithValue("@n",textBox9.Text);
                    //cmd.Parameters.AddWithValue("@em_id",textBox11.Text);
                    //cmd.Parameters.AddWithValue("@room_code",textBox2.Text );
                    //cmd.ExecuteNonQuery();
                    //c++;
                    //textBox1.Text = c.ToString();
                    con.CloseConnection();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int c;

        private void صيانة_طلب_غرفة_منظار_Load(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                SqlDataReader dr = con.DataReader("setescope_Room_maintenance_count");
                dr.Read();
                c = Convert.ToInt32(dr[0]);
                c++;
                textBox1.Text = c.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        void showlist()
        {
            try
            {
                con.OpenConection();
                SqlDataReader dr = con.DataReader("setescope_employee_career_name");
                //con = new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
                //con.Open();
                //cmd = new SqlCommand("setescope_employee_job", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string job = dr["career_name"].ToString();
                    comboBox1.Items.Add(job);
                }
                dr.Close();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("يجب اختيار وظيفة");
            }
            else
            {
                بحث_موظف f = new بحث_موظف();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    textBox11.Text = بحث_موظف.x.ToString();
                    textBox10.Text = بحث_موظف.y;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = comboBox1.SelectedItem.ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
