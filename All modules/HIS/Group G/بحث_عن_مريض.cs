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
    public partial class بحث_عن_مريض_منظار_1 : Form
    {
        
        SqlDataReader dr;
        public static string t1;

        public static string t2;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        int c;
        string name;
        DataTable dt = new DataTable();
        public بحث_عن_مريض_منظار_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              // con.Open();
                if (textBox1.Text != "")
                {
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Int };
                        name_input=new string[]{"@x"};
                        values = new string[] { textBox1.Text };
                        object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_code", name_input, values, types);
                        dataGridView1.DataSource = ob;
                        con1.CloseConnection();
                    //cmd = new SqlCommand("search_patient_code", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@x", textBox1.Text);              ///////////////pro
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                    //dr.Close();
                }
                else if (textBox2.Text != "")
                {
                    string v = textBox2.Text;
                    string[] tx1 = v.Split(' ');

                    if (tx1.Length == 4)
                    {
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.NVarChar};
                        name_input = new string[] {"@x","@y","@z","@f"};
                        values = new string[] {tx1[0],tx1[1],tx1[2],tx1[3] };
                        object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_with_four_parmetr",name_input, values, types);
                        dataGridView1.DataSource = ob;
                        con1.CloseConnection();
                        //cmd = new SqlCommand("search_patient_with_four_parmetr", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", tx1[0]);              ///////////////pro
                        //cmd.Parameters.AddWithValue("@y", tx1[1]);
                        //cmd.Parameters.AddWithValue("@z", tx1[2]);
                        //cmd.Parameters.AddWithValue("@f", tx1[3]);
                    }
                    else if (tx1.Length == 3)
                    {
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar};
                        name_input=new string[] {"@x","@y","@z"};
                        values = new string[] {tx1[0], tx1[1], tx1[2]};
                        object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_with_three_parmetr",name_input,values,types);
                        dataGridView1.DataSource = ob;
                        con1.CloseConnection();
                        //cmd = new SqlCommand("search_patient_with_three_parmetr", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", tx1[0]);              ///////////////pro
                        //cmd.Parameters.AddWithValue("@y", tx1[1]);
                        //cmd.Parameters.AddWithValue("@z", tx1[2]);
                    }
                    else if (tx1.Length == 2)
                    {
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar};
                        name_input = new string[] { "@x", "@y"};
                        values = new string[] { tx1[0], tx1[1]};
                        object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_with_two_parmetr",name_input, values, types);
                        dataGridView1.DataSource = ob;
                        con1.CloseConnection();
                        //cmd = new SqlCommand("search_patient_with_two_parmetr", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", tx1[0]);              ///////////////pro
                        //cmd.Parameters.AddWithValue("@y", tx1[1]);
                    }
                    else
                    {
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar};
                        name_input = new string[] {"@x"};
                        values = new string[] { tx1[0]};
                        object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_with_one_parmetr",name_input,values,types);
                        dataGridView1.DataSource = ob;
                        con1.CloseConnection();

                    //    cmd = new SqlCommand("search_patient_with_one_parmetr", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@x", tx1[0]);
                    }
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                    //dr.Close();

                }
                else if (textBox3.Text != "")
                {
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Int};
                    name_input = new string[] {"@x"};
                    values = new string[] { textBox3.Text };
                    object ob = con1.ShowDataInGridViewUsingStoredProc("search_patient_with_ssn_number",name_input, values, types);
                    dataGridView1.DataSource = ob;
                    con1.CloseConnection();

                    //cmd = new SqlCommand("search_patient_with_ssn_number", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@x", textBox3.Text);              ///////////////pro
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                    //dr.Close();
                }
                else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    con1.OpenConection();
                    types = new SqlDbType[] {};
                    name_input = new string[] {};
                    values = new string[] { textBox3.Text };
                    SqlDataReader dr = con1.DataReader("search_patient_with_all");
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    con1.CloseConnection();


                    //cmd = new SqlCommand("search_patient_with_all", con);
                    //cmd.CommandType = CommandType.StoredProcedure;             ///////////////pro
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                    //dr.Close();
                }

            
           
        }
        
    
    
        private void Form10_Load(object sender, EventArgs e)
        
        {
            con1.OpenConection();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
}

        private void datagridviewcell(object sender, DataGridViewCellEventArgs e)
        {
            
            c = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            t2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            t1 = Convert.ToString(c);
                متابعة_حركة_المريض f9 = new متابعة_حركة_المريض(c, name);
                this.Close();
                f9.Show();

            
        }

     
        private void k(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { 
               e.Handled=true;
               MessageBox.Show("رقم المريض");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("اسم المريض");

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { 
               e.Handled=true;
               MessageBox.Show("الرقم القومي");
            }
        }

       

     
    }
}
