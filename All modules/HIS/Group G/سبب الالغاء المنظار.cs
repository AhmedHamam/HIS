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
    public partial class Form9 : Form
    {

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
               
                con1.OpenConection();
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" ادخل اسم الدكتور المسئول عن الالغاء");
                }
                else
                {
            //create procedure select_doc_details(@d nvarchar(50),@s nvarchar(50),@endo nvarchar(50))
            //    as
            //    delete from doctor_operation where op_id in(select id from setescope_operation where start_time=@s  and Datee=@d and EndoscopeCode in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@endo))
            //peration where id_op in(select id from setescope_operation where start_time=@s  and Datee=@d and EndoscopeCode in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@endo))


                    //cmd = new SqlCommand("select_doc_details", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@d", الصفحه_الرئيسيه_للمنظار.d);
                    //cmd.Parameters.AddWithValue("@s", الصفحه_الرئيسيه_للمنظار.start);
                    //cmd.Parameters.AddWithValue("@endo", الصفحه_الرئيسيه_للمنظار.endo);
                    //cmd.ExecuteNonQuery();
                    types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                    name_input = new string[] {  "@d", "@s", "@endo" };
                    values = new string[] {  الصفحه_الرئيسيه_للمنظار.d,  الصفحه_الرئيسيه_للمنظار.start, الصفحه_الرئيسيه_للمنظار.endo };
                    con1.ExecuteNonQueryProcedure("select_doc_details", name_input, values, types);
                    
                //  create procedure select_delete_setescope(@d nvarchar(50),@s nvarchar(50),@id int)
                //as

                //delete from setescope_operation where id=@id and Datee=@d and start_time=@s



                       //cmd = new SqlCommand("select_delete_setescope", con);
                       //cmd.CommandType = CommandType.StoredProcedure;
                       //cmd.Parameters.AddWithValue("@d", الصفحه_الرئيسيه_للمنظار.d);
                       //cmd.Parameters.AddWithValue("@s", الصفحه_الرئيسيه_للمنظار.start);
                       //cmd.Parameters.AddWithValue("@id", الصفحه_الرئيسيه_للمنظار.opid);
                       //cmd.ExecuteNonQuery();
                    types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                    name_input = new string[] { "@d", "@s", "@id" };
                    values = new string[] { الصفحه_الرئيسيه_للمنظار.d, الصفحه_الرئيسيه_للمنظار.start, الصفحه_الرئيسيه_للمنظار.opid };
                    con1.ExecuteNonQueryProcedure("select_delete_setescope", name_input, values, types);
                    this.Close();
                    MessageBox.Show("لقد تم الغاء الحجز ");

                }


            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
            finally
            {
                con1.CloseConnection();
            }
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
