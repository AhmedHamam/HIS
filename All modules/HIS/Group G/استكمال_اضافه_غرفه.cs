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
    public partial class استكمال_اضافه_غرفه : Form
    {
        int code=اضافه_غرفه.c;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        DataTable dt = new DataTable();
        
        SqlDataReader dr;
        public استكمال_اضافه_غرفه()
        {
            InitializeComponent(); 
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
           
            try
            {
                con1.OpenConection();

                //create PROCEDURE setescope_rooms_select_name_and_code (@code int)
                //as
                //begin
                //select RoomCode,ArabicName from Endoscope_room where RoomCode= @code
                //end
                //cmd = new SqlCommand("select RoomCode,ArabicName from Endoscope_room where RoomCode=" + code + ";", con);
                //cmd = new SqlCommand("setescope_rooms_select_name_and_code", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@code", Convert.ToInt32(code));
                //dr = cmd.ExecuteReader();

                types = new SqlDbType[] {  SqlDbType.Int };
                name_input = new string[] {  "@code" };
                values = new string[] { Convert.ToString(code)};
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_rooms_select_name_and_code", name_input, values, types);
                dt.Load(dr);
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox5.Text = dt.Rows[0][1].ToString();
                textBox6.Text = اداره.code3.ToString();
                textBox7.Text = اداره.name1;
                textBox8.Text = مخزن_مستلزمات_المنظار.code2.ToString();
                textBox9.Text = مخزن_مستلزمات_المنظار.name; 
                con1.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }


       private void button1_Click_1(object sender, EventArgs e)
       {
           مخزن_مستلزمات_المنظار f = new مخزن_مستلزمات_المنظار();
           f.Show();
           this.Close();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           اداره f = new اداره();
           f.Show();
           this.Close();

       }


       private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
       {
           try
           {
               //create PROCEDURE setescope_rooms_update_inventory_and_dep (@code1 int,@code2 int,@roomcode int)
               // as
               // begin
               // update Endoscope_room set code1 =@code1 , code2 =@code2 where RoomCode= @roomcode
               // end
               con1.OpenConection();
              // cmd = new SqlCommand("update Endoscope_room set code1 = " + Convert.ToInt32(textBox6.Text) + ", code2 = " + Convert.ToInt32(textBox8.Text) + " where RoomCode=" + code + ";", con);
               //cmd = new SqlCommand("setescope_rooms_update_inventory_and_dep", con);
               //cmd.CommandType = CommandType.StoredProcedure;
               //cmd.Parameters.AddWithValue("@roomcode", Convert.ToInt32(code));
               //cmd.Parameters.AddWithValue("@code2", Convert.ToInt32(textBox6.Text));
               //cmd.Parameters.AddWithValue("@code1", Convert.ToInt32(textBox8.Text));
               //cmd.ExecuteNonQuery();

               types = new SqlDbType[] { SqlDbType.Int ,SqlDbType.Int,SqlDbType.Int};
               name_input = new string[] {"@roomcode","@code2", "@code1" };
               values = new string[] { Convert.ToString(code),textBox6.Text,textBox8.Text };
               con1.ExecuteNonQueryProcedure("setescope_rooms_update_inventory_and_dep", name_input, values, types);
               MessageBox.Show("تم الحفظ");
               con1.CloseConnection();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

       }

      
        
    }
}
