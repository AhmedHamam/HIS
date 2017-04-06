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
    public partial class تخدير : Form
    {
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        SqlDataAdapter da3;
        
        SqlDataReader dr;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        public static string selected { get; set; }

        string check;
        public تخدير()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            محرك_بحث_فريق_العمل_الطبى_للمنظار f7 = new محرك_بحث_فريق_العمل_الطبى_للمنظار();
            if (f7.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Do_id;
                textBox5.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Name1;
            }
        }

        private void تخدير_Load(object sender, EventArgs e)
        {
            selected = "تخدير";
            textBox1.Text = الصفحه_الرئيسيه_للمنظار.pid;
            textBox6.Text = الصفحه_الرئيسيه_للمنظار.pname;
            textBox3.Text = الصفحه_الرئيسيه_للمنظار.op;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (radioButton3.Checked)
                check = "pos";
            if (radioButton4.Checked)
                check = "full";
            if (radioButton5.Checked)
                check = "half";
            con1.OpenConection();


            //create procedure setescope_select_doc_id_doc_name(@op int)
            //as
            //select o.Do_id ,d.name from doctor_operation o,doctors d where o.op_id=@op and o.Do_id=d.doc_ssn and type='Anesthesia'

            //cmd = new SqlCommand("setescope_select_doc_id_doc_name", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@op", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
            //da1 = new SqlDataAdapter(cmd);
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@op" };
            values = new string[] { الصفحه_الرئيسيه_للمنظار.opid };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_select_doc_id_doc_name", name_input, values, types);
            //DataSet ds1 = new DataSet();
            DataTable dt=new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count == 0)
            {
                //cmd = new SqlCommand("ins", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id1", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@id2", Convert.ToInt32(textBox4.Text));

                //// cmd.CommandText = "insert into doctor_operation values (" + Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid) + "," + Convert.ToInt32(textBox4.Text) +")";
                //cmd.ExecuteNonQuery();
                //create procedure ins(@id1 int,@id2 int)
                //    as
                //    insert into doctor_operation values(@id1,@id2)
                dr.Close();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                name_input = new string[] { "@id1", "@id2" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, textBox4.Text };
                con1.ExecuteNonQueryProcedure("ins", name_input, values, types);

                //cmd = new SqlCommand("setescope_select_doc_name", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@op", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //da3 = new SqlDataAdapter(cmd);
            //                create procedure setescope_select_doc_name(@op int)
            //as
            //select d.name from doctor_operation o,doctors d where o.op_id=@op  and o.Do_id=d.doc_ssn and type='Anesthesia'


                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@op" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_select_doc_name", name_input, values, types);

                //  da3 = new SqlDataAdapter("select d.name from doctor_operation o,doctor d where o.op_id=" + Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid) + " and o.Do_id=d.Do_id and type='Anesthesia';", con);
                DataTable dt2 = new DataTable();
                dt2.Load(dr);
                panel1.Visible = true;
                label9.Text = dt2.Rows[0][0].ToString();
                label13.Text = dt2.Rows[0][0].ToString();
                label12.Text = dateTimePicker1.Value.ToString();
            }
            else
            {
                panel1.Visible = true;
                label9.Text = dt.Rows[0][1].ToString();

                //cmd = new SqlCommand("setescope_update_doc_id", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@op", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));

                //cmd.Parameters.AddWithValue("@d_id", Convert.ToInt32(textBox4.Text));

                //cmd.Parameters.AddWithValue("@doc", Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString()));

                ////  cmd.CommandText = "update doctor_operation set Do_id=" + Convert.ToInt32(textBox4.Text) + " where op_id=" + Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid) + " and Do_id=" + Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());
                //cmd.ExecuteNonQuery();

            //                create procedure setescope_update_doc_id(@d_id int,@op int ,@doc int)
            //as
            //update doctor_operation set Do_id=@d_id where op_id=@op and Do_id=@doc  

                dr.Close();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int ,SqlDbType.Int};
                name_input = new string[] { "@d_d1","@op", "@doc" };
                values = new string[] { textBox4.Text, الصفحه_الرئيسيه_للمنظار.opid, dt.Rows[0][0].ToString() };
                con1.ExecuteNonQueryProcedure("setescope_update_doc_id", name_input, values, types);


                //cmd = new SqlCommand("setescope_select_doc_name", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@op", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //da2 = new SqlDataAdapter(cmd);
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@op" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_select_doc_name", name_input, values, types);

                // da2 = new SqlDataAdapter("select d.name from doctor_operation o,doctor d where o.op_id=" + Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid) + " and o.Do_id=d.Do_id and type='Anesthesia';", con);
                //DataSet ds2 = new DataSet();
                //da2.Fill(ds2);
                DataTable dt3 = new DataTable();
                label13.Text = dt3.Rows[0][0].ToString();
                label12.Text = dateTimePicker1.Value.ToString();
            }
            dr.Close();
            con1.CloseConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
