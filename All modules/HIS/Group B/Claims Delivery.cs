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
    public partial class ClaimsDelivery : Form
    {
        Connection con = new Connection();
        public ClaimsDelivery()
        {
            InitializeComponent();
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

        public void setValue(string d, string c)
        {
            textBox2.Text = d;
            textBox4.Text = c;
        }

        public void setV(string e, string f)
        {
            textBox1.Text = e;
            textBox5.Text = f;

            //int.TryParse();
            
        } 

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {

                con.OpenConection();
                //not find table [0]
                string[] pramname = new string[6];
                string[] pramvalue = new string[6];
                SqlDbType[] pramtype = new SqlDbType[6];
                pramname[0] = "@x1";
                pramname[1] = "@x2";
                pramname[2] = "@x3";
                pramname[3] = "@x4";
                pramname[4] = "@x5";
                pramname[5] = "@x6";

                pramvalue[0] = comboBox2.SelectedItem.ToString(); 
                pramvalue[1] = textBox1.Text;
                pramvalue[2] = comboBox1.SelectedItem.ToString(); 
                pramvalue[3] = dateTimePicker4.Value.ToString();
                pramvalue[4] = dateTimePicker1.Value.ToString();
                pramvalue[5] = textBox3.Text;
               
                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.Int;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                pramtype[4] = SqlDbType.VarChar;
                pramtype[5] = SqlDbType.Int;



                //con.OpenConection();

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("Claims_Delivery", pramname, pramvalue, pramtype);
                //MessageBox.Show("");
                con.CloseConnection();
            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }
        //        try
        //        {

        //            con.Open();
        //            cmd = new sqlCommand();
        //            cmd.CommandText = "select claims.claim_id as 'رقم المطالبه' , actor_name as 'الجهه' , claims.date_from as 'من' , claims.date_to as 'الى' , claim_total as 'اجمالى المطالبه' , claim_state  as 'حاله المطالبه' , Total_payment as 'اجمالي السداد' from claims , actor , notice , subactor where actor.actor_code = subactor.actor_code  and claims.payment_claim_type=@x1 and actor.actor_code=@x2 and claim_type=@x3 and claims.date_from between @x4 and @x5 and claims.claim_id=@x6 ";
        //            cmd.Connection = con;

        //            cmd.Prepare();
        //            cmd.Parameters.AddWithValue("@x1", comboBox2.Text);
        //            cmd.Parameters.AddWithValue("@x2", textBox1.Text);
        //            cmd.Parameters.AddWithValue("@x3", comboBox1.Text);
        //            cmd.Parameters.AddWithValue("@x4", dateTimePicker4.Value.ToString());
        //            cmd.Parameters.AddWithValue("@x5", dateTimePicker1.Value.ToString());
        //            cmd.Parameters.AddWithValue("@x6", textBox3.Text);


        //            dataReader = cmd.ExecuteReader();
        //            dt = new DataTable();
        //            dt.Load(dataReader);
        //            dataGridView1.DataSource = dt;
        //            dataReader.Close();
        //            con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
         
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
                comboBox1.Text = "";
                comboBox2.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
