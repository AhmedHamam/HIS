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
    public partial class تاكيد_تعديل_الفئه : Form
    {
        


        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public تاكيد_تعديل_الفئه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string g_n = الجهه_الخاص_بالمريض_الخارجى.v1;
            string g_f_n = الجهه_الخاص_بالمريض_الخارجى.x3;
              
            
           string f = الجهه_الخاص_بالمريض_الخارجى.x5;
            int p_id= int.Parse(محرك_البحث1.xx1);
            
               
                
                   // SqlCommand cmd = new SqlCommand("update  patient set Institution='" + g_n + "',sub_Institution='" + g_f_n + "',family='" + f + "' where patient_id=" + p_id + " ", con);
                //SqlCommand cmd = new SqlCommand("clinic_update_p_family", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@g_n", g_n);
                //cmd.Parameters.AddWithValue("@g_f_n", g_f_n);
                //cmd.Parameters.AddWithValue("@f", f);
                //cmd.Parameters.AddWithValue("@p_id", p_id);
                //cmd.ExecuteNonQuery();

                //create procedure clinic_update_p_family(@g_n int,@g_f_n int,@f  nvarchar(10),@p_id int)
                //as
                //update  Registeration_patientRegisteration set catogrical_code=@g_n,sub_Institution=@g_f_n,family=@f  where patient_id=@p_id ;	

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int,SqlDbType.NVarChar,SqlDbType.Int };
                name_input = new string[] { "@g_n", "@g_f_n","@f","@p_id" };
                values = new string[] { g_n, g_f_n, f, p_id.ToString() };
                con1.ExecuteNonQueryProcedure("clinic_update_p_family", name_input, values, types);
                con1.CloseConnection();
               
               this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
