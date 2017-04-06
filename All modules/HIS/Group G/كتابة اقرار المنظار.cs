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
    public partial class كتابة_اقرار_المنظار : Form
    {
         
        SqlDataReader dr;
        DataTable dt ;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public كتابة_اقرار_المنظار()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void كتابة_اقرار_المنظار_Load(object sender, EventArgs e)
        {
            try
            {
               
                con1.OpenConection();

                /*
                 * create PROCEDURE setescope_approval_select_patienName_and_id (@id int)
                    as
                    select name , type_of_visit from patient_endo where id=@id
                 */
                //cmd = new SqlCommand("setescope_approval_select_patienName_and_id", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", كتابه_اقرار_مناظير.c);
                //dr = cmd.ExecuteReader();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@id" };
                values = new string[] { Convert.ToString(كتابه_اقرار_مناظير.c) };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_approval_select_patienName_and_id", name_input, values, types);
                dt = new DataTable();
                dt.Load(dr);
                textBox1.Text = كتابه_اقرار_مناظير.c.ToString();
                textBox2.Text = dt.Rows[0][0].ToString();
                textBox11.Text = dt.Rows[0][1].ToString();
                dr.Close();
                con1.CloseConnection();
                con1.OpenConection();

                //cmd = new SqlCommand("setescope_approval_select_doctorName", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@doctorName", كتابه_اقرار_مناظير.dn);
                //dr = cmd.ExecuteReader();
                //create PROCEDURE setescope_approval_select_doctorName (@doctorName nvarchar(30))
                //as
                //select Do_id  from doctors where name = @doctorName
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@doctorName" };
                values = new string[] { Convert.ToString(كتابه_اقرار_مناظير.dn) };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_approval_select_doctorName", name_input, values, types);
                dt = new DataTable();
                dt.Load(dr);
                textBox5.Text = كتابه_اقرار_مناظير.dn.ToString();
                textBox6.Text = dt.Rows[0][0].ToString();
                dr.Close();
                con1.CloseConnection();
                con1.OpenConection();
               
                //cmd = new SqlCommand("setescope_approval_select_EndoscopeName", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@EndoscopeName", كتابه_اقرار_مناظير.opn);
                //dr = cmd.ExecuteReader();
                //create PROCEDURE setescope_approval_select_EndoscopeName (@EndoscopeName nvarchar(50))
                //as
                //select EndoscopeCode  from Endoscope_settings_data where EndoscopeName = @EndoscopeName
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@EndoscopeName" };
                values = new string[] { Convert.ToString(كتابه_اقرار_مناظير.opn) };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_approval_select_EndoscopeName", name_input, values, types);
                dt = new DataTable();
                dt.Load(dr);
                textBox3.Text = كتابه_اقرار_مناظير.opn.ToString();
                textBox4.Text = dt.Rows[0][0].ToString();
                dr.Close();
                con1.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void check_num(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال ارقام فقط فى كود الغرفه");
            }
        }

       
    }
}
