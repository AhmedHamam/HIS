using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class opForm02 : Form
    {
        string s, periority;
        public opForm002 op;
        public opForm0002 op1;
        public opForm03 op2;
        public SqlDataAdapter da;
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlCommand cmd;
        public SqlDataReader dr;
        Connection connect;
        public opForm02()
        {
            InitializeComponent();
            connect = new Connection();

        }
        private void Form02_Load(object sender, EventArgs e)
        {
            try
            {
                //Hide colored buttons 
                btn_ordinary_color.Hide();
                btn_Emergency_color.Hide();
                btn_urgent_color.Hide();

                ////////////////

                /**
                cmd.CommandText = "select Room_name   from rooms;";
                cmd.Connection = con;

                if (con.State != ConnectionState.Open) con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["Room_name"]);
                    


                }

                dr.Close();
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
         


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_dotor_search_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_urgent_color_Click(object sender, EventArgs e)
        {

        }

        private void btn_ordinary_color_Click(object sender, EventArgs e)
        {

        }

        private void btn_emergency_color_Click(object sender, EventArgs e)
        {

        }

       
        private void btn_ordinary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btn_ordinary_color.Show();
                btn_urgent_color.Hide();
                btn_Emergency_color.Hide();
                periority = "ordinary";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void btn_urgent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btn_urgent_color.Show();
                btn_ordinary_color.Hide();
                btn_Emergency_color.Hide();
                periority = "urgent";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void btn_Emergency_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btn_Emergency_color.Show();
                btn_ordinary_color.Hide();
                btn_urgent_color.Hide();
                periority = "emergency";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.ToString();

                //  string[] words = dt.Split('/');
                //  string s = words[2] +"-"+ words[0] + "-" + words[1];
                string[] words = dt.Split(' ');

                string[] dat = words[2].Split('/');
                s = dat[2];
                if (dat[0].Length == 1)
                    s += "-0" + dat[0];
                else
                    s += "-" + dat[0];
                if (dat[1].Length == 1)
                    s += "-0" + dat[1];
                else
                    s += "-" + dat[1];




                MessageBox.Show(s);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
               string  d =  comboBox3.Items[comboBox3.SelectedIndex].ToString();
                string op_type = comboBox1.Items[comboBox3.SelectedIndex].ToString();
                string ss = "no";
                string s = dateTimePicker1.Value.ToShortDateString();
                string pName = "operation_reservation2";
                string[] paramNames = { "@doc_ssn", "@visit_id", "@req_date ", "@op_name","@r_side", "@req_periority", "@r_status" ,"@op_type"};
                string[] paramValues = { textBox3.Text, textBox1.Text, dateTimePicker1.Value.ToShortDateString(), textBox6.Text, d, periority,ss,op_type };
                SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                /*
                string sql = "insert into requests(r_acceptance_date,doc_ssn,visit_id,req_date,op_suite_name,r_status ,req_periority)values (null,'";
                sql += textBox3.Text + "','";
                sql += textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','";
         
                sql += comboBox2.Items[comboBox2.SelectedIndex] + "','no'" + ",'"; 
                sql += periority +"')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();*/
                MessageBox.Show("requests is saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
/*
        private void button5_Click(object sender, EventArgs e)
        {

          
            cmd = new SqlCommand();
            cmd.CommandText = "select doctor_code from doctor where name='" + comboBox3.Items[comboBox3.SelectedIndex]+"'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr[0].ToString();

            }
            
            dr.Close();
         
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "select opl_code from operation_list where opl_english_name='" + comboBox6.Items[comboBox6.SelectedIndex] + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox5.Text = dr[0].ToString();

            }

            dr.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand();
            cmd.CommandText = "select pat_id from patient where name='" + comboBox4.Items[comboBox4.SelectedIndex] + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();

            }

            dr.Close();
        }
        */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void setvalue(string x, string y)
        {
            try
            {
                Console.WriteLine(x + " " + y);
                textBox1.Text = x;
                textBox2.Text = y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void setvalue1(string x, string y)
        {
            try
            {
                Console.WriteLine(x + " " + y);
                textBox3.Text = x;
                textBox4.Text = y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void setvalue2(string x, string y)
        {
            try
            {
                Console.WriteLine(x + " " + y);
                textBox5.Text = x;
                textBox6.Text = y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }


        private void btn_spicialization_Click(object sender, EventArgs e)
        {
            try
            {
                op = new opForm002(this);
                op.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                op1 = new opForm0002(this);
                op1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                op2 = new opForm03(this);
                op2.ShowDialog();

                textBox5.Text = op2.OperationCode;
                textBox6.Text = op2.OperationName;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}