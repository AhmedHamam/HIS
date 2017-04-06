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
    public partial class Outpatientclaim : Form
    {
        Connection con = new Connection();
       
        public Outpatientclaim()
        {
            InitializeComponent();
        }
        public void setValue(string d, string c)
        {
            textBox2.Text = d;
            textBox4.Text = c;
        }

        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox5.Text = f;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            الجهات f = new الجهات(this);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            الجهاتالفرعيه f = new الجهاتالفرعيه(this);
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                con.OpenConection();
                //not find table [0]
                string[] pramname = new string[5];
                string[] pramvalue = new string[5];
                SqlDbType[] pramtype = new SqlDbType[5];
                pramname[0] = "@x1";
                pramname[1] = "@x2";
                pramname[2] = "@x3";
                pramname[3] = "@x4";
                pramname[4] = "@x5";

                pramvalue[0] = textBox1.Text;
                pramvalue[1] = textBox2.Text;
                pramvalue[2] = dateTimePicker4.Value.ToString();
                pramvalue[3] = dateTimePicker1.Value.ToString();
                pramvalue[4] = textBox3.Text;
               
                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                pramtype[4] = SqlDbType.Int;
                




 //con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("Outpatient_claim", pramname, pramvalue, pramtype);
                    //MessageBox.Show("");
                    con.CloseConnection();

                

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }






            con.CloseConnection(); 
                
           
            //try
            //{
            //    int x1 = int.Parse(textBox2.Text);
            //    int x2 = int.Parse(textBox1.Text);
            //    int x3 = int.Parse(textBox3.Text);
            //    con.Open();
            //    cmd = new sqlCommand();
            //    cmd.CommandText = "select claims.claim_id as 'رقم المطالبه' , claims.claim_date as 'تاريخ المطالبة' , claims.date_from as 'من' , claims.date_to as 'الى' , claims.claim_total as 'اجمالى المطالبه' , actor.actor_code as ' كود الجهه ' , bill.Total_remaining_patient as 'الاجمالي بعد الخصم' , bill.Total_payment as 'اجمالي السداد' , bill.delay_value as 'المطلوب سداده' from claims , actor , subactor , bill where actor.actor_code = subactor.actor_code  and actor.actor_code=@x1 and subactor.sub_code=@x2 and claims.date_from between @x3 and @x4 and claims.claim_id=@x5";
            //    cmd.Connection = con;

            //    cmd.Prepare();
            //    cmd.Parameters.AddWithValue("@x1", textBox1.Text);
            //    cmd.Parameters.AddWithValue("@x2", textBox2.Text);
            //    cmd.Parameters.AddWithValue("@x3", dateTimePicker4.Value.ToString());
            //    cmd.Parameters.AddWithValue("@x4", dateTimePicker1.Value.ToString());
            //    cmd.Parameters.AddWithValue("@x5", textBox3.Text);

            //    dataReader = cmd.ExecuteReader();
            //    dt = new DataTable();
            //    dt.Load(dataReader);
            //    dataGridView1.DataSource = dt;
            //    dataReader.Close();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
           
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try { con.OpenConection(); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
