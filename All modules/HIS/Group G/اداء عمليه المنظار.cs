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
    public partial class اداء_عمليه_المنظار : Form
    {
        
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public static string end;
        public اداء_عمليه_المنظار()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
           
            textBox1.Text = الصفحه_الرئيسيه_للمنظار.start;
            textBox2.Text = الصفحه_الرئيسيه_للمنظار.end;
            textBox1.ReadOnly = true;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                end = textBox2.Text;
                con1.OpenConection();
                //create procedure setescope_flag_finish(@end nvarchar(50),@d nvarchar(50),@s nvarchar(50),@id int)
                //as
                //update  setescope_operation set flag='finish',end_time=@end where Datee =@d and start_time=@s and id=@id

                //cmd = new SqlCommand("update  setescope_operation set flag= 'finish' ,end_time='" + end + "' where Datee = '" + الصفحه_الرئيسيه_للمنظار.d + "' and start_time='" + الصفحه_الرئيسيه_للمنظار.start + "' and id='" + الصفحه_الرئيسيه_للمنظار.opid + "'", con);
                //cmd.ExecuteNonQuery();
                //cmd = new SqlCommand("setescope_flag_finish", con);

                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@end", end);
                //cmd.Parameters.AddWithValue("@d", الصفحه_الرئيسيه_للمنظار.d);
                //cmd.Parameters.AddWithValue("@s", الصفحه_الرئيسيه_للمنظار.start);
                //cmd.Parameters.AddWithValue("@id", الصفحه_الرئيسيه_للمنظار.opid);
                //cmd.ExecuteNonQuery();
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                name_input = new string[] { "@end", "@d", "@s", "@id" };
                values = new string[] { end, الصفحه_الرئيسيه_للمنظار.d, الصفحه_الرئيسيه_للمنظار.start, الصفحه_الرئيسيه_للمنظار.opid };
                con1.ExecuteNonQueryProcedure("setescope_flag_finish", name_input, values, types);
                الصفحه_الرئيسيه_للمنظار.flag = "finish";
                الصفحه_الرئيسيه_للمنظار ff6 = new الصفحه_الرئيسيه_للمنظار();
                ff6.Focus();
                this.DialogResult = DialogResult.OK;
                ff6.Focus();
            }
            catch (Exception v)
            {
                MessageBox.Show(v.Message);
            }
            finally
            {
                con1.CloseConnection();
            }

               

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
