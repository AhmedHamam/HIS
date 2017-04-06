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
    public partial class اضافه_غرفه : Form
    {
        public static int c { get; set; }
        
        SqlDataReader dr;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        DataTable dt = new DataTable();
        public اضافه_غرفه()
        {
            InitializeComponent();
        }

        

        private void click(object sender, DataGridViewCellEventArgs e)
        {
            c = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["كود الغرفه"].Value.ToString());
            استكمال_اضافه_غرفه f = new استكمال_اضافه_غرفه();
            //MessageBox.Show(c.ToString());
            f.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                /*create PROCEDURE setescope_rooms_select_for_check (@roomcode int)
                    as
                    begin
                    select RoomCode,ArabicName from Endoscope_room where RoomCode =@roomcode
                    end
                 * 
                 */ 
                    //con = new SqlConnection(@"server=ENGY\SQLEXPRESS;database=setescope;Integrated Security=true;");
                    //con.Open();
                    ////cmd = new SqlCommand("select RoomCode,ArabicName from Endoscope_room where RoomCode = '"+textBox1.Text+"';", con);
                    //cmd = new SqlCommand("setescope_rooms_select_for_check", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@roomcode", textBox1.Text);
                    //dr = cmd.ExecuteReader();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@roomcode" };
                values = new string[] { textBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_rooms_select_for_check", name_input, values, types);

                    if (dr.Read())
                    {
                        MessageBox.Show("هذه الغرفه موجوده بالفعل");
                        dr.Close();
                    }
                    else if(textBox1.Text==""||textBox2.Text=="")
                    {
                        MessageBox.Show("برجاء استكمال بيانات الغرفه");
                    }
                    else
                    {
                        dr.Close();
                        //create PROCEDURE setescope_rooms_insert_new_room (@roomcode int,@aname nvarchar(30))
                        //as
                        //begin
                        //insert into Endoscope_room (RoomCode,ArabicName) values (@roomcode,@aname)
                        //end
                       //// cmd = new SqlCommand("insert into Endoscope_room (RoomCode,ArabicName) values ('" + textBox1.Text + "',N'" + textBox2.Text + "');", con);
                       // cmd = new SqlCommand("setescope_rooms_insert_new_room", con);
                       // cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.Parameters.Add("@aname", SqlDbType.NVarChar).Value = textBox2.Text;
                       // cmd.Parameters.AddWithValue("@roomcode", Convert.ToInt32( textBox1.Text));
                       // cmd.ExecuteNonQuery();
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.Int ,SqlDbType.NVarChar};
                        name_input = new string[] { "@roomcode","@name" };
                        values = new string[] { textBox1.Text ,textBox2.Text};
                         con1.ExecuteNonQueryProcedure("setescope_rooms_insert_new_room", name_input, values, types);
                        
                        MessageBox.Show("تم اضافه الغرفه");
                    }
                    con1.CloseConnection();
                    con1.OpenConection();
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dt.Clear();
                    
                //create PROCEDURE setescope_rooms_selectall 
                //as
                //begin
                //select RoomCode as 'كود الغرفه',ArabicName as 'الاسم عربى' from Endoscope_room;
                //end
                //cmd = new SqlCommand("select RoomCode as 'كود الغرفه',ArabicName as 'الاسم عربى' from Endoscope_room;", con);
                    //cmd = new SqlCommand("setescope_rooms_selectall", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //dr = cmd.ExecuteReader();
                    dr = con1.DataReader("setescope_rooms_selectall");
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void check_number(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال ارقام فقط فى كود الغرفه");
            }
        }

        private void check_string(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("برجاء ادخال حروف فقط");
            }
        } 
    }
}
