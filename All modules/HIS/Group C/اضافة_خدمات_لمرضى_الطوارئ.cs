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
    
    public partial class اضافة_خدمات_لمرضى_الطوارئ : Form
    {
        //MySqlConnection con;
        //MySqlCommand cmd;
        Connection con = new Connection();
        public اضافة_خدمات_لمرضى_الطوارئ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            البحث_عن_مرضى_الطوارئ f = new البحث_عن_مرضى_الطوارئ();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = البحث_عن_مرضى_الطوارئ.Code1.ToString();
                textBox1.Text = البحث_عن_مرضى_الطوارئ.arrive_date.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            عرض_خدمات_الطوارئ f = new عرض_خدمات_الطوارئ();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = عرض_خدمات_الطوارئ.Code1.ToString();
                textBox2.Text = عرض_خدمات_الطوارئ.name.ToString();
            }
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            try
            {
                string[] f = new string[] { "@v1","@v2","@v3","@v4" };
                string[] f2 = new string[] { textBox3.Text, textBox2.Text, textBox15.Text, textBox1.Text };


                SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("adds_ser_to_emer_patient", f, f2, f3))
                    {
                        MessageBox.Show("تمت اضافة هذه الخدمة من قبل ");
                        return;
                    }
                   

                  
                
               
                //string s5 = "insert into  emergency_cases_services(serv_co,serv_nam,pati_code,arriv_dat)"
                //            + "values(@v1,@v2,@v3,@v4)";


                //cmd = new MySqlCommand(s5, con);
                //cmd.Parameters.AddWithValue("@v1", int.Parse(textBox3.Text));
                //cmd.Parameters.AddWithValue("@v2", textBox2.Text);
                //cmd.Parameters.AddWithValue("@v3", int.Parse(textBox15.Text));
                //cmd.Parameters.AddWithValue("@v4", textBox1.Text);

                //cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void اضافة_خدمات_لمرضى_الطوارئ_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
