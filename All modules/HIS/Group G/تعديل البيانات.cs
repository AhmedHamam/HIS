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
    public partial class تعديل_البيانات : Form
    {
        public تعديل_البيانات()
        {
            InitializeComponent();
            showlist();
        }

        private void تعديل_البيانات_Load(object sender, EventArgs e)
        {

        }
        Connection con = new Connection();
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

        private void خروج_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //SqlConnection con;
        //SqlCommand cmd;
        private void حفظ_Click(object sender, EventArgs e)
        {
            DateTime tm1 = dateTimePicker2.Value;
            string t1 = tm1.Hour.ToString() + ':' + tm1.Minute.ToString();
            //MessageBox.Show(t);
            DateTime dt = dateTimePicker1.Value;
            string modifiedd = dt.Date.ToString("yyyy-MM-dd");
            DateTime dnow = DateTime.Now.Date;
            DateTime tm2 = dateTimePicker3.Value;
            string t2 = tm2.Hour.ToString() + ':' + tm2.Minute.ToString();

            if (textBox2.Text == "")
            {
                MessageBox.Show("يجب اختيار عملية");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("يجب اختيار طبيب");
            }
            //MessageBox.Show(بحث_عن_عملية_في_تاريخ_معين.id_op.ToString());
            //MessageBox.Show(t);
            else
            {
                if (بحث_عن_عملية_في_تاريخ_معين.id_op != 0)
                {
                    if (dt >= dnow)
                    {
                        string[] pramname = new string[3];
                        string[] pramvalue = new string[3];
                        SqlDbType[] pramtype = new SqlDbType[3];
                        pramname[0] = "@dt";
                        pramname[1] = "@st";
                        pramname[2] = "@endo";

                        pramvalue[0] = modifiedd;
                        pramvalue[1] = t1;
                        pramvalue[2] = textBox2.Text;

                        pramtype[0] = SqlDbType.NVarChar;
                        pramtype[1] = SqlDbType.NVarChar;
                        pramtype[2] = SqlDbType.NVarChar;

                        con.OpenConection();
                        dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_setescope_operation_select_id", pramname, pramvalue, pramtype);
                        //con.Open();
                        //cmd = new SqlCommand("setescope_setescope_operation_select_id", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@dt", modifiedd);
                        //cmd.Parameters.AddWithValue("@st", modifiedt);
                        //cmd.Parameters.AddWithValue("@ endo",textBox2.Text);
                        //dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            int id_op_prev = Convert.ToInt32(dr[0].ToString());
                        }

                        if (tm1 <= tm2)
                        {
                            if (!dr.HasRows)
                            {
                                dr.Close();
                                con.CloseConnection();
                                بحث_عن_عملية_في_تاريخ_معين f = new بحث_عن_عملية_في_تاريخ_معين();
                                con.OpenConection();
                                string[] pramna = new string[6];
                                string[] pramv = new string[6];
                                SqlDbType[] pramt = new SqlDbType[6];
                                pramna[0] = "@st";
                                pramna[1] = "@et";
                                pramna[2] = "@dt";
                                pramna[3] = "@endc";
                                pramna[4] = "@id_oper";
                                pramna[5] = "@d_id";

                                pramv[0] = t1;
                                pramv[1] = t2;
                                pramv[2] = modifiedd;
                                pramv[3] = textBox2.Text;
                                pramv[4] = بحث_عن_عملية_في_تاريخ_معين.id_op.ToString();
                                pramv[5] = بحث_عن_عملية_في_تاريخ_معين.id_d.ToString();

                                pramt[0] = SqlDbType.NVarChar;
                                pramt[1] = SqlDbType.NVarChar;
                                pramt[2] = SqlDbType.NVarChar;
                                pramt[3] = SqlDbType.NVarChar;
                                pramt[4] = SqlDbType.Int;
                                pramt[5] = SqlDbType.Int;
                                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("setescope_setescope_operation_update", pramna, pramv, pramt);
                                //cmd = new SqlCommand("setescope_setescope_operation_update", con);
                                //cmd.CommandType = CommandType.StoredProcedure;
                                //cmd.Parameters.AddWithValue("@st", modifiedt);
                                //cmd.Parameters.AddWithValue("@dt", modifiedd);
                                //cmd.Parameters.AddWithValue("@endc", textBox2.Text);
                                //cmd.Parameters.AddWithValue("@id_oper", بحث_عن_عملية_في_تاريخ_معين.id_op);
                                //cmd.Parameters.AddWithValue("@d_id", بحث_عن_عملية_في_تاريخ_معين.id_d);
                                //cmd.ExecuteNonQuery();
                                con.CloseConnection();
                                MessageBox.Show("تمت العملية بنجاح");
                            }
                            else
                            {
                                MessageBox.Show("توجد عملية في هذ الوقت");
                            }
                        }
                        else
                        {
                            MessageBox.Show("يجب اختيار وقت النهاية اكبر من وقت البداية بنصف ساعة");
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا يجب اختيار تاريخ ايام سابقة");
                    }
                }
                else { MessageBox.Show("لا يمكن التعديل قبل اختيار عملية  للتعديل"); }

            }
        }
        void showlist()
        {
            try
            {
                //con=new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
                con.OpenConection();
                SqlDataReader dr = con.DataReader("setescope_rooms_select");

                //cmd = new SqlCommand("setescope_Endoscope_room_select", con);
                //cmd.CommandType = CommandType.StoredProcedure; 
                //dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string a_name = dr[1].ToString();
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

        //public static int x { get; set; }
        بحث_عن_عملية_في_تاريخ_معين f = new بحث_عن_عملية_في_تاريخ_معين();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Arabicname = comboBox2.Text;
            try
            {
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@arb_name";
                pramvalue[0] = Arabicname;
                pramtype[0] = SqlDbType.NVarChar;

                SqlDataReader dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_rooms_select_code", pramname, pramvalue, pramtype);

                //cmd = new SqlCommand("setescope_Endoscope_room_select_code", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@arb_name", Arabicname); 
                //dr = cmd.ExecuteReader();
                dr.Read();
                //  while (dr.Read())
                // {
                بحث_عن_عملية_في_تاريخ_معين.c = Convert.ToInt32(dr["Room_code"].ToString());
                //بحث_عن_عملية_في_تاريخ_معين f = new بحث_عن_عملية_في_تاريخ_معين();
                //if (x != f.c)
                //{
                //    f.c =x;
                //}
                roomflag(بحث_عن_عملية_في_تاريخ_معين.c);
                //MessageBox.Show(c.ToString());
                //  }
                dr.Close();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        SqlDataReader dr;
        public string flag = "";
        void roomflag(int x)
        {
            try
            {
                con.CloseConnection();
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@room_code";
                pramvalue[0] = x.ToString();
                pramtype[0] = SqlDbType.Int;

                dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_Room_maintenance_select_flag", pramname, pramvalue, pramtype);

                //cmd = new SqlCommand("setescope_Endoscope_room_select_flag", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@room_code",x ); 
                //dr = cmd.ExecuteReader();
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
                    //MessageBox.Show(" الغرفة جاهزة");
                    button1.Visible = true;
                }
                else if (!dr.HasRows)
                {
                    //MessageBox.Show(" الغرفة جاهزة");
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
    }
}
