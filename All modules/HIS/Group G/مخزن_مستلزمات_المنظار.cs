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
    public partial class مخزن_مستلزمات_المنظار : Form
    {
        public static int code2 { get; set; }
        public static string name { get; set; }
        
       SqlDataReader dr;
       Connection con1 = new Connection();
       string[] name_input;
       string[] values;
       SqlDbType[] types;
        public مخزن_مستلزمات_المنظار()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Visible = true;
            try
            {
                con1.OpenConection();
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    //create PROCEDURE setescope_inventory_select_with_name_and_code (@aname nvarchar(50),@code int)
                    //as
                    //begin
                    //select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where aname like N'%'+@aname+'%' and code1 = @code ;
                    //end
                    //cmd = new SqlCommand("select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where code1 = '" + textBox1.Text + "' or aname like '" + textBox2.Text + "%';", con);
                    //cmd = new SqlCommand("setescope_inventory_select_with_name_and_code", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@aname", SqlDbType.NVarChar).Value = textBox2.Text;
                    //cmd.Parameters.AddWithValue("@code", Convert.ToInt32(textBox1.Text));
                    types = new SqlDbType[] { SqlDbType.NVarChar ,SqlDbType.Int};
                    name_input = new string[] { "@aname","@code" };
                    values = new string[] { textBox2.Text ,textBox1.Text};
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_inventory_select_with_name_and_code", name_input, values, types);
                }
                else if (textBox1.Text != "")
                {
                    //create PROCEDURE setescope_inventory_select_with_code (@code int)
                    //as
                    //begin
                    //select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where code1 = @code ;
                    //end
                    //cmd = new SqlCommand("select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where code1 = '" + textBox1.Text + "';", con);
                    //cmd = new SqlCommand("setescope_inventory_select_with_code", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@code",Convert.ToInt32(textBox1.Text));
                    types = new SqlDbType[] {  SqlDbType.Int };
                    name_input = new string[] {  "@code" };
                    values = new string[] {  textBox1.Text };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_inventory_select_with_code", name_input, values, types);
                }
                else if (textBox2.Text != "")
                {
                    //create PROCEDURE setescope_inventory_select_with_name (@aname nvarchar(50))
                    //as
                    //begin
                    //select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where aname like N'%'+@aname+'%' ;
                    //end

                   // cmd = new SqlCommand("select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm where aname like '" + textBox2.Text + "%';", con);
                    //cmd = new SqlCommand("setescope_inventory_select_with_name", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@aname", SqlDbType.NVarChar).Value= textBox2.Text;
                    types = new SqlDbType[] { SqlDbType.NVarChar };
                    name_input = new string[] { "@aname" };
                    values = new string[] { textBox2.Text };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_inventory_select_with_name", name_input, values, types);
                }
                else
                {
                    //create PROCEDURE setescope_inventory_selectall 
                    //as
                    //begin
                    //select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm ;
                    //end
                    //cmd = new SqlCommand("select code1 as 'الكود',aname as 'الاسم عربى',lname as 'الاسم انجليزى' from masan_mostlsm ;", con);
                    //cmd = new SqlCommand("setescope_inventory_selectall", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    dr = con1.DataReader("setescope_inventory_selectall");
                }

                dataGridView1.DataSource = null;
                
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con1.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox2.Clear();
            textBox1.Clear();
        }

        private void click(object sender, DataGridViewCellEventArgs e)
        {
            code2 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["الكود"].Value.ToString());
             name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["الاسم عربى"].Value.ToString());
            استكمال_اضافه_غرفه f = new استكمال_اضافه_غرفه();
            //MessageBox.Show(c.ToString());
            this.Close();
            f.Show();
            
        }

        private void مخزن_مستلزمات_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void check_num(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال ارقام فقط ");
            }
        }

        private void check_str(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال حروف فقط");
            }
        }
    }
}
