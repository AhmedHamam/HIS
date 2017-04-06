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
    public partial class حجز_عمليه_منظار : Form
    {
        public حجز_عمليه_منظار()
        {
            InitializeComponent();
            showlist();
        }

        
        Connection con = new Connection();
        private void حفظ_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label11.Text = textBox2.Text;
            label12.Visible = true;
            label12.Text = textBox6.Text;
            label13.Visible = true;
            label13.Text = dateTimePicker1.Text;
            label14.Visible = true;
            label14.Text = textBox3.Text;

           
            con.OpenConection();
            DateTime tm1 = dateTimePicker2.Value;
            string t1 = tm1.Hour.ToString() + ':' + tm1.Minute.ToString();
         
            DateTime dt = dateTimePicker1.Value;
            string d = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            
            DateTime tm2 = dateTimePicker3.Value;
            string t2= tm2.Hour.ToString() + ':' + tm2.Minute.ToString();
            
            try
            {
                //create procedure setescope_setescope_operation_select_id(@dt nvarchar(30),@st nvarchar(30),@endo int)
                //as
                //begin
                //select id from setescope_operation where Datee=@dt and start_time=@st and EndoscopeCode=@endo;
                //end
                con.CloseConnection();
                string[] pramnam = new string[3];
                string[] pramvalu = new string[3];
                SqlDbType[] pramtyp = new SqlDbType[3];
                pramnam[0] = "@dt";
                pramnam[1] = "@st";
                pramnam[2] = "@endo";
                pramvalu[0] = d;
                pramvalu[1] = t1;
                pramvalu[2] = textBox2.Text;
                pramtyp[0] = SqlDbType.VarChar;
                pramtyp[1] = SqlDbType.VarChar;
                pramtyp[2] = SqlDbType.Int;
                con.OpenConection();
                SqlDataReader dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_setescope_operation_select_id", pramnam, pramvalu, pramtyp);
                
               
               while (dr.Read())
               {
                   int id_op_prev = Convert.ToInt32(dr[0].ToString());
               }
               if (!dr.HasRows)
               {

                   
                   con.CloseConnection();
                   con.OpenConection();
                   string[] pramname = new string[6];
                   string[] pramvalue = new string[6];
                   SqlDbType[] pramtype = new SqlDbType[6];
                   pramname[0] = "@st";
                   pramname[1] = "@dt";
                   pramname[2] = "@et";
                   pramname[3] = "@p";
                   pramname[4] = "@endc";
                   pramname[5] = "@p_id";


                   pramvalue[0] = t1;
                   pramvalue[1] = d;
                   pramvalue[2] = t2;
                   pramvalue[3] = s;
                   pramvalue[4] = textBox2.Text;
                   pramvalue[5] = طلب_حجز_منظار.c.ToString();

                   pramtype[0] = SqlDbType.VarChar;
                   pramtype[1] = SqlDbType.VarChar;
                   pramtype[2] = SqlDbType.VarChar;
                   pramtype[3] = SqlDbType.VarChar;
                   pramtype[4] = SqlDbType.Int;
                   pramtype[5] = SqlDbType.Int;

                   //create procedure setescope_setescope_operation_insert(@st nvarchar(30),@dt nvarchar(30),@et nvarchar(30),@p nvarchar(30),@endc int,@p_id int)
                   // as
                   // begin
                   // insert into setescope_operation(start_time,Datee,end_time,piroirty_order,EndoscopeCode,patient_id) values(@st,@dt,@et,@p,@endc,@p_id);
                   // end
                   con.OpenConection();
                   con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("setescope_setescope_operation_insert", pramname, pramvalue, pramtype);
                   con.CloseConnection();


                   //create procedure setescope_setescope_operation_select_id(@dt nvarchar(30),@st nvarchar(30),@endo int)
                   // as
                   // begin
                   // select id from setescope_operation where Datee=@dt and start_time=@st and EndoscopeCode=@endo;
                   // end
                   con.OpenConection();
                   dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_setescope_operation_select_id", pramnam, pramvalu, pramtyp);

                   
                   int id_op = 0;
                   while (dr.Read())
                   {
                       id_op = Convert.ToInt32(dr[0].ToString());
                       
                   }
                 
                   con.CloseConnection();
                   con.OpenConection();

                   string[] pramna = new string[2];
                   string[] pramval = new string[2];
                   SqlDbType[] pramty = new SqlDbType[2];
                   pramna[0] = "@oper_id";
                   pramna[1] = "@doctor_id";
                   pramval[0] = id_op.ToString();
                   pramval[1] = textBox4.Text;
                   pramty[0] = SqlDbType.Int;
                   pramty[1] = SqlDbType.Int;
                   //create procedure setescope_doctor_operation_insert(@oper_id int,@doctor_id int)
                   // as
                   // begin
                   // insert into doctor_operation(id_op,Do_id) values(@oper_id,@doctor_id);
                   // end
                   int rfd = con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("setescope_doctor_operation_insert", pramna, pramval, pramty);


                   MessageBox.Show("تمت العملية بنجاح");

                   
                   con.CloseConnection();

               }
               else
               { MessageBox.Show("توجد عملية في هذا الوقت"); }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            بحث_دكتور f = new بحث_دكتور();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = بحث_دكتور.y.ToString();
                textBox3.Text = بحث_دكتور.x;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("يجب اختيار غرفة");
            }
            else
            {
                بحث_العمليه_للمنظار f = new بحث_العمليه_للمنظار();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = بحث_العمليه_للمنظار.y.ToString();
                    textBox6.Text = بحث_العمليه_للمنظار.x;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
        }
        string s = "";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            s = "";
            s = "عادي";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            s = "";
            s = "مستعجل";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            s = "";
            s = "طارئ";
        }
        void showlist()
        {
            try
            {
               
                con.OpenConection();

                //create procedure setescope_Endoscope_room_select
                //as
                //begin
                //select RoomCode as 'الكود',ArabicName as 'الوصف العربي' from Endoscope_room;
                //end
                 SqlDataReader dr = con.DataReader("setescope_Endoscope_room_select");
                
               
                while (dr.Read())
                {
                    string a_name = dr["ArabicName"].ToString();
                    comboBox2.Items.Add(a_name);
                }
                dr.Close();
                
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static int c {get;set;}
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            string Arabicname = comboBox2.Text;
            try
            {
                //create procedure setescope_Endoscope_room_select_code(@arb_name nvarchar(30))
                //    as
                //    begin
                //    select RoomCode from Endoscope_room where ArabicName=@arb_name;
                //    end
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@arb_name";
                pramvalue[0] = Arabicname;
                pramtype[0] = SqlDbType.NVarChar;

                 SqlDataReader dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_Endoscope_room_select_code", pramname, pramvalue, pramtype);
              
                
                 dr.Read();
                 
                 c = Convert.ToInt32(dr["RoomCode"]);
                 roomflag(c);
                 
                
                 dr.Close();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        SqlDataReader dr;
        string flag="";
        void roomflag(int x)
        {

            try
            {
                //create procedure setescope_Endoscope_room_select_flag(@room_code nvarchar(30))
                //as
                //begin
                //select flag from Room_maintenance where RoomCode=@room_code
                //end

                con.CloseConnection();
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@room_code";
                pramvalue[0] = x.ToString();
                pramtype[0] = SqlDbType.Int;

                dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_Endoscope_room_select_flag", pramname, pramvalue, pramtype);

               
                while (dr.Read())
                {
                    flag = dr[0].ToString();
                }


                if (flag == "no")
                {
                    MessageBox.Show(" الغرفة تحت الصيانة");
                    button1.Visible = false;
                }

                else if (flag == "true")
                {
                    
                    button1.Visible = true;
                }
                else if (!dr.HasRows)
                {
                    
                    button1.Visible = true;
                }
                flag = "";
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
            finally
            {

                dr.Close();
            }
            con.CloseConnection();
        }
        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
