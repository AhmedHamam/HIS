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
    public partial class بحث_عن_عمليه : Form
    {
        public بحث_عن_عمليه()
        {
            InitializeComponent();
        }

       
         SqlDataReader dr;
        DataTable dt;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //MessageBox.Show(code.ToString());
            dataGridView1.Visible = true;
            con1.OpenConection();
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                //create PROCEDURE setescope_search_operation_select_all
                //as
                //select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data ;


                //cmd = new SqlCommand("select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data ;",con);
                //cmd = new SqlCommand("setescope_search_operation_select_all", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                dr = con1.DataReader("setescope_search_operation_select_all");

            }
            else
            {
                if (textBox1.Text != "")
                {
                   // cmd = new SqlCommand("select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeCode=" + textBox1.Text,con);
                    //cmd = new SqlCommand("setescope_search_operation_select_endosopecode", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@code", Convert.ToInt32(textBox1.Text));
                    //create PROCEDURE setescope_search_operation_select_endosopecode (@code int)
                    //as
                    //select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeCode=@code ;

                    types = new SqlDbType[] { SqlDbType.Int };
                    name_input = new string[] { "@code" };
                    values = new string[] { textBox1.Text };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_search_operation_select_endosopecode", name_input, values, types);
                }
                else if (textBox2.Text != "")
                {
                    
                    //cmd = new SqlCommand("select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeName='" + textBox2.Text+"'",con);
                    //cmd = new SqlCommand("setescope_search_operation_select_aname", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@aname", SqlDbType.NVarChar).Value = textBox2.Text;

                    //create PROCEDURE setescope_search_operation_select_aname (@aname nvarchar(30))
                    //as
                    //select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeName=@aname ;

                    types = new SqlDbType[] { SqlDbType.NVarChar };
                    name_input = new string[] { "@aname" };
                    values = new string[] { textBox2.Text };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_search_operation_select_aname", name_input, values, types);
                }
                else
                {
                    
                    //cmd = new SqlCommand("select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeCode=" + textBox1.Text + "and EndoscopeName=" + textBox2.Text, con);
                    //cmd = new SqlCommand("setescope_search_operation_select_endosopecode_and_aname", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@aname", SqlDbType.NVarChar).Value = textBox2.Text;
                    //cmd.Parameters.AddWithValue("@code", Convert.ToInt32(textBox1.Text));
                    //create PROCEDURE setescope_search_operation_select_endosopecode_and_aname (@code int,@aname nvarchar(30))
                    //as
                    //select EndoscopeCode as 'كود العمليه',EndoscopeName as 'اسم العمليه عربى',DescriptionLatino as 'اسم العمليه لاتينى' from Endoscope_settings_data where EndoscopeCode=@code and EndoscopeName=@aname ;

                    types = new SqlDbType[] { SqlDbType.NVarChar ,SqlDbType.Int};
                    name_input = new string[] { "@aname" ,"@code"};
                    values = new string[] { textBox2.Text ,textBox1.Text};
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_search_operation_select_endosopecode_and_aname", name_input, values, types);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            con1.CloseConnection();
            
        }

        private void بحث_عن_عمليه_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;    
        }

        public static int y { get; set; }
        public static string x { get; set; }
        private void click(object sender, DataGridViewCellEventArgs e)
        {
            y = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["كود العمليه"].Value.ToString());
            x = dataGridView1.Rows[e.RowIndex].Cells["اسم العمليه عربى"].Value.ToString();
            كتابه_اقرار_مناظير f = new كتابه_اقرار_مناظير();
            f.Focus();
            this.DialogResult = DialogResult.OK;
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

        private void check_string(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال حروف فقط");
            }
        }

        
    }
}
