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
    public partial class تعديل_موعد_العمليه : Form
    {

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public static string t1;
        public static string t2;
        DataSet ds = new DataSet();
        public تعديل_موعد_العمليه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                t1 = textBox2.Text;
                t2 = textBox1.Text;
                الصفحه_الرئيسيه_للمنظار f = new الصفحه_الرئيسيه_للمنظار();
                con1.OpenConection();
                //create procedure update_time(@s nvarchar(50),@end nvarchar(50) ,@d nvarchar(50),@ss nvarchar(50),@n nvarchar(50))
                //    as
                //    update setescope_operation set start_time=@s,end_time=@end where Datee=@d and start_time=@ss and EndoscopeCode 
                //    in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@n );

                 
                //cmd = new SqlCommand("update_time", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@end", t2);
                //cmd.Parameters.AddWithValue("@d", الصفحه_الرئيسيه_للمنظار.d);
                //cmd.Parameters.AddWithValue("@s", t1);
                //cmd.Parameters.AddWithValue("@ss", الصفحه_الرئيسيه_للمنظار.start);
                //cmd.Parameters.AddWithValue("@n", الصفحه_الرئيسيه_للمنظار.endo);
                //cmd.ExecuteNonQuery();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@end", "@d", "@s", "@ss", "@n" };
                values = new string[] { t2, الصفحه_الرئيسيه_للمنظار.d, t1, الصفحه_الرئيسيه_للمنظار.start, الصفحه_الرئيسيه_للمنظار.endo };
                con1.ExecuteNonQueryProcedure("update_time", name_input, values, types);
                الصفحه_الرئيسيه_للمنظار ff6 = new الصفحه_الرئيسيه_للمنظار();
                ff6.Focus();
                this.DialogResult = DialogResult.OK;
                ff6.Focus();
               

            }
            catch (Exception v) { MessageBox.Show(v.Message); }
            finally { con1.CloseConnection();}
        }

        private void Form10_Load(object sender, EventArgs e)
        {
           
        
        }

        }
    }

