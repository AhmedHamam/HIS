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
    public partial class كتابه_اقرار_مناظير : Form
    {

        
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        object ob;
        public كتابه_اقرار_مناظير()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false ;
        }

       
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dataGridView1.DataSource = null ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < dateTimePicker2.Value.Date)
            {
                try
                {
                    con1.OpenConection();
                    if (textBox3.Text != "") 
                    {
                         types = new SqlDbType[] {SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                        name_input = new string[] {"@x","@y","@z"};
                        values = new string[] { dateTimePicker1.Text, dateTimePicker2.Text,textBox3.Text };
                        ob = con1.ShowDataInGridViewUsingStoredProc("setescope_approval_select_withpatientid", name_input, values, types);

                        //cmd = new SqlCommand("setescope_approval_select_withpatientid", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", dateTimePicker1.Text);
                        //cmd.Parameters.AddWithValue("@y", dateTimePicker2.Text);
                        //cmd.Parameters.AddWithValue("@z", Convert.ToInt32(textBox3.Text));
                        }
                    else if (textBox4.Text != "")
                    {
                        types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                        name_input = new string[] { "@x", "@y", "@z" };
                        values = new string[] { dateTimePicker1.Text, dateTimePicker2.Text, textBox4.Text };
                        ob = con1.ShowDataInGridViewUsingStoredProc("setescope_approval_select_withenscopecode", name_input, values, types);

                        //cmd = new SqlCommand("setescope_approval_select_withenscopecode", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", dateTimePicker1.Text);
                        //cmd.Parameters.AddWithValue("@y", dateTimePicker2.Text);
                        //cmd.Parameters.AddWithValue("@z", Convert.ToInt32(textBox4.Text));

                    }
                    else if (textBox3.Text != "" && textBox4.Text != "")
                    {
                        types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int ,SqlDbType.Int};
                        name_input = new string[] { "@x", "@y", "@p","@e"};
                        values = new string[] { dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, textBox4.Text };
                        ob = con1.ShowDataInGridViewUsingStoredProc("setescope_approval_select_withpatientid_andendoscopecode", name_input, values, types);

                        //cmd = new SqlCommand("setescope_approval_select_withpatientid_andendoscopecode", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", dateTimePicker1.Text);
                        //cmd.Parameters.AddWithValue("@y", dateTimePicker2.Text);
                        //cmd.Parameters.AddWithValue("@p", Convert.ToInt32(textBox3.Text));
                        //cmd.Parameters.AddWithValue("@e", Convert.ToInt32(textBox4.Text));
                    }
                    else
                    {
                        
                        types = new SqlDbType[] {SqlDbType.NVarChar,SqlDbType.NVarChar };
                        name_input = new string[] {"@x","@y"};
                        values = new string[] { dateTimePicker1.Text, dateTimePicker2.Text };
                        ob = con1.ShowDataInGridViewUsingStoredProc("setescope_approval_select",name_input,values,types);

                        //cmd = new SqlCommand("setescope_approval_select", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", dateTimePicker1.Text);
                        //cmd.Parameters.AddWithValue("@y", dateTimePicker2.Text);
                        
                    }
                    
                    
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource= ob;
                    con1.CloseConnection();
                    //dr = cmd.ExecuteReader();
                    //dt.Load(dr);
                    //dataGridView1.DataSource = dt;
                    //dr.Close();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("برجاء ادخال تاريخ مناسب");
            }
        }

        public static int c { get; set; }
        public static string opn {get; set;}
        public static string dn { get; set; }
        private void click(object sender, DataGridViewCellEventArgs e)
        {
            c = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["كود المريض"].Value.ToString());
            opn = dataGridView1.Rows[e.RowIndex].Cells["اسم العمليه"].Value.ToString();
            dn = dataGridView1.Rows[e.RowIndex].Cells["اسم الجراح"].Value.ToString();
            كتابة_اقرار_المنظار f = new كتابة_اقرار_المنظار();
            f.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            بحث_عن_عمليه f = new بحث_عن_عمليه();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = بحث_عن_عمليه.y.ToString();
                textBox5.Text = بحث_عن_عمليه.x;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            بحث_عن_مريض1 f = new بحث_عن_مريض1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = بحث_عن_مريض1.y.ToString();
                textBox6.Text = بحث_عن_مريض1.x;
            }
        }
    }
}
