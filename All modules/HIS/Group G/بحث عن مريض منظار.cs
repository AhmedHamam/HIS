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
    public partial class بحث_عن_مريض1 : Form
    {
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        SqlDataReader dr;
        public بحث_عن_مريض1()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        
       
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            try
            {
                con1.OpenConection();
                if (textBox1.Text != "")
                {
                    //cmd = new SqlCommand("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient where id=" + textBox1.Text, con);
                dr=con1.DataReader("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient where id=" + textBox1.Text);
                
                }
                else if (textBox3.Text != "")
                {
                    try
                    {
                        //cmd = new SqlCommand("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient where name='" + textBox3.Text + "'", con);
                        dr = con1.DataReader("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient where name='" + textBox3.Text + "'");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    //cmd = new SqlCommand("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient", con);
                    dr = con1.DataReader("select id as 'الكود', name as'الاسم' , type_of_visit as 'نوع الزياره'  from patient");
                }

               // SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void بحث_عن_مريض_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        public static int y { get; set; }
        public static string x { get; set; }
        private void click(object sender, DataGridViewCellEventArgs e)
        {
            y = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["الكود"].Value.ToString());
            x = dataGridView1.Rows[e.RowIndex].Cells["الاسم"].Value.ToString();
            كتابه_اقرار_مناظير f = new كتابه_اقرار_مناظير();
            f.Focus();
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
