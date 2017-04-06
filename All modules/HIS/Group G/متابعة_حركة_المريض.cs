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
    public partial class متابعة_حركة_المريض : Form
    {
       
        SqlDataReader dataReader;
        int Clinic_code;
        string English_name;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public متابعة_حركة_المريض(int c, string n)
        {
            InitializeComponent();
            Clinic_code = c;
            English_name = n;
            
            
                textBox1.Text = Clinic_code.ToString();
                textBox2.Text = English_name;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            بحث_عن_مريض_منظار_1 f10 = new بحث_عن_مريض_منظار_1();
            this.Close();
            f10.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           

            textBox1.Text = بحث_عن_مريض_منظار_1.t1;
            textBox2.Text = بحث_عن_مريض_منظار_1.t2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Columns.Clear();
         
            
                string d1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string d2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
             // int i= int.Parse(textBox1.Text);
                

              //create procedure select_patient_from_visit(@x int,@y varchar(40))
              //  as
              //  begin
              //              select visit_id from entranceoffice_visit where pat_id=@x and entrance_date=@y
              //  end
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.VarChar};
                name_input = new string[] {"@x","@y"};
                values = new string[] { textBox1.Text, d1 };
                object ob = con1.ShowDataInGridViewUsingStoredProc("select_patient_from_visit", name_input, values, types);
                dataGridView1.DataSource = ob;
                con1.CloseConnection();
                //SqlCommand cmd = new SqlCommand("show_description_patient", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x", int.Parse(textBox1.Text));
               //cmd.Parameters.AddWithValue("@y",d1);
                //cmd.Parameters.AddWithValue("@z",d2);
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                //dr.Close();
                
             

            
        }

    

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         textBox1.Text ="";
          textBox2.Text ="";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') || !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
           
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') || !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
               
            }
        }
       
    }
}
