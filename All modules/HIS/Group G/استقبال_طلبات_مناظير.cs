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
    public partial class استقبال_طلبات_مناظير : Form
    {
        
        SqlDataReader dr;
        
        
        int endo_id, p_id,request_id;


        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public استقبال_طلبات_مناظير()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
             
           dataGridView1.Visible = false;
           
           

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dateTimePicker1.Value.Date < dateTimePicker2.Value.Date)
                {

                //    create PROCEDURE setescope_receive_request_select (@d1 date ,@d2 date)
                //as
                //begin
                //select req_id as 'رقم الطلب', req_date as 'تاريخ الطلب' ,pid as 'كودالمريض' , patient_endo.name as 'اسم المريض',
                //doctors.name as 'اسم الطبيب' ,EndoscopeCode as 'كود العمليه',EndoscopeName as 'العمليه' , ArabicName as 'غرفه العمليه',accept_date as 'تاريخ الموافقه' ,commentes as 'ملاحظات'
                //from receive_request ,patient_endo ,doctors ,Endoscope_settings_data as s ,Endoscope_room as e
                //where patient_endo.id = receive_request.pid
                //and doctors.Do_id = did
                //and s.EndoscopeCode = endo_id
                //and e.RoomCode = rid
                //and receive_request.flag like 'no'
                //and req_date between @d1 and @d2
                //end

                //con.Open();
                //cmd = new SqlCommand("setescope_receive_request_select", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                //cmd.Parameters.AddWithValue("@d2", dateTimePicker2.Text);
                    string d1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string d2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Date, SqlDbType.Date };
                    name_input = new string[] { "@d1", "@d2" };
                    values = new string[] { d1,d2 };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_receive_request_select", name_input, values, types);
                    DataTable dt = new DataTable();
                dataGridView1.Visible = true;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                //dt.Clear();
               
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                con1.CloseConnection();
                }
                else
                {
                    MessageBox.Show("برجاء ادخال تاريخ مناسب");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            endo_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["كود العمليه"].Value.ToString());
            p_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["كودالمريض"].Value.ToString());
            request_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["رقم الطلب"].Value.ToString());
        }

        private void تأكيدToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //create PROCEDURE setescope_receive_request_select_end_time 
            //as
            //begin
            //select end_time from setescope_operation where id = ( select max(id) from setescope_operation )
            //end


            con1.OpenConection();
            DataTable ddt = new DataTable();
            
            //cmd = new SqlCommand("setescope_receive_request_select_end_time", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //dr = cmd.ExecuteReader();
          
           
            dr = con1.DataReader("setescope_receive_request_select_end_time");
            ddt.Load(dr);
            string end_time = ddt.Rows[0][0].ToString();
            
            DateTime d = DateTime.Today;
            string s = d.ToShortDateString() + " " + end_time;
            DateTime dtt = Convert.ToDateTime(s);
            
            con1.CloseConnection();


            //create PROCEDURE setescope_confirm_operation_insert_update (@start_time time ,@Datee date ,@end_time time ,@flag varchar(30),@EndoscopeCode int,@patient_id int,@req_id int) 
            //as
            //begin
            //insert into setescope_operation (start_time,Datee,end_time,flag,EndoscopeCode,patient_id)  values
            //(@start_time,@Datee,@end_time,@flag,@EndoscopeCode,@patient_id) ;
            //update receive_request set flag = 'confirm' where req_id = @req_id ;
            //end
            con1.OpenConection();
           
            types = new SqlDbType[] { SqlDbType.Time, SqlDbType.Date ,SqlDbType.Time,SqlDbType.VarChar,SqlDbType.Int,SqlDbType.Int,SqlDbType.Int};
            name_input = new string[] { "@start_time", "@Datee", "@end_time", "@flag", "@EndoscopeCode", "@patient_id", "@req_id" };
            values = new string[] { end_time, d.ToShortDateString(), Convert.ToString(dtt.AddMinutes(30)), "no", Convert.ToString(endo_id), Convert.ToString(p_id), Convert.ToString(request_id) };
            con1.ExecuteNonQueryProcedure("setescope_confirm_operation_insert_update", name_input, values, types);
            MessageBox.Show("تم تأكيد العمليه");
            con1.CloseConnection();
        }
        
    }
}
