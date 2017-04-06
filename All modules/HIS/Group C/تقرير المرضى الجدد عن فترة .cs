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
    public partial class تقرير_المرضى_الجدد_عن_فترة : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        BindingSource bs;

        public تقرير_المرضى_الجدد_عن_فترة()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string[] s = new string[] { "@date1", "@date2" };
                string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report11", s, s2, s3);
                //da = new MySqlDataAdapter();
                //try
                //{
                //    cmd = new MySqlCommand("select patient_id as 'رقم الملف',patient_name as 'اسم المريض',gender as 'الجنس',date_of_birth as 'تاريخ الميلاد',nationality as'الجنسيه'"

                // + ",date_Regist as 'تاريخ التسجيل',name as 'اسم الموظف',TE_Aname as 'الجهه الماليه',CE_AName as 'الفئه'"
                // + "from  Registeration_patientRegisteration,employee,tb_Types_of_Entities,tb_Contracting_Entities,tb_Entities_Branches where emp_id=employ_code and "
                // + "EB_CE_id=CE_Id and EC_EB_id=EB_id and date_Regist between @date1 and @date2;", con);

                //    cmd.Parameters.AddWithValue("@date1", textBox1.Text);
                //    cmd.Parameters.AddWithValue("@date2", textBox2.Text);
                //    da.SelectCommand = cmd;

                //    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //    da.Fill(ds);
                //    bs = new BindingSource();
                //    bs.DataSource = ds.Tables[0];
                //    dataGridView1.DataSource = bs;
                //    con.Close();
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                datte f = new datte(this);
                f.Show();
            }
            catch (Exception r) {

                MessageBox.Show(r.Message);
            
            
            }


            
        }

        public void setvalue3(string x)
        {
            textBox1.Text = x;

        }


        public void setvalue4(string x)
        {
            textBox2.Text = x;

        }

        //public void setvalue1(string x)
        //{
        //    textBox1.Text = x;

        //}
        public void setvalue2(string x)
        {
            textBox2.Text = x;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            enddatte f = new enddatte(this);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
           // ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void تقرير_المرضى_الجدد_عن_فترة_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
             con.OpenConection();
        }
      

       

    }
}
