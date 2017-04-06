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
    public partial class بحث_عن_عملية_في_تاريخ_معين : Form
    {

        public بحث_عن_عملية_في_تاريخ_معين()
        {
            InitializeComponent();
            showlist();
        }

        //Connection con = new Connection();

        private void خروج_Click(object sender, EventArgs e)
        {
            this.Close();
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



        private void تعديل_Click(object sender, EventArgs e)
        {
            تعديل_البيانات f = new تعديل_البيانات();
            f.Show();
        }
        //SqlCommand cmd;
        //SqlConnection con= new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
        //SqlDataReader dr; 
        //DataTable dt;
        //
        Connection con = new Connection();
        public string d;
        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            //ds.Tables.Clear();

            DateTime dt = dateTimePicker1.Value;
            d = dt.Date.ToString("yyyy-MM-dd");

            DateTime dnow = DateTime.Now.Date;
            //string dnow = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            con.OpenConection();
            // d = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            if (dt >= dnow)
            {

                try
                {
                    //DateTime dtm = dateTimePicker1.Value;
                    // d = dtm.Year.ToString() + '/' + dtm.Month.ToString() + '-' + dtm.Day.ToString();

                    //MessageBox.Show(d);

                    if (textBox3.Text == "" && textBox2.Text == "")
                    {
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@dt";
                        pramvalue[0] = d;
                        pramtype[0] = SqlDbType.NVarChar;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_setescope_operation_by_date", pramname, pramvalue, pramtype);

                        //cmd = new SqlCommand("setescope_setescope_operation_by_date", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@dt",d);

                    }
                    else if (textBox3.Text != "" && textBox2.Text != "")
                    {
                        string[] pramname = new string[3];
                        string[] pramvalue = new string[3];
                        SqlDbType[] pramtype = new SqlDbType[3];
                        pramname[0] = "@dt";
                        pramname[1] = "@endo";
                        pramname[2] = "@d_name";
                        pramvalue[0] = d;
                        pramvalue[1] = textBox2.Text;
                        pramvalue[2] = textBox3.Text;
                        pramtype[0] = SqlDbType.NVarChar;
                        pramtype[1] = SqlDbType.Int;
                        pramtype[2] = SqlDbType.NVarChar;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_setescope_operation_by_DoNameandendcod", pramname, pramvalue, pramtype);
                    }
                    else
                    {
                        if (textBox3.Text != "")
                        {
                            string[] pramname = new string[2];
                            string[] pramvalue = new string[2];
                            SqlDbType[] pramtype = new SqlDbType[2];
                            pramname[0] = "@dt";
                            pramvalue[0] = d;
                            pramtype[0] = SqlDbType.NVarChar;
                            pramname[1] = "@d_name";
                            pramvalue[1] = textBox3.Text;
                            pramtype[1] = SqlDbType.NVarChar;
                            dataGridView1.Visible = true;
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_setescope_operation_by_DoName", pramname, pramvalue, pramtype);

                        }
                        else if (textBox2.Text != "")
                        {
                            string[] pramname = new string[2];
                            string[] pramvalue = new string[2];
                            SqlDbType[] pramtype = new SqlDbType[2];
                            pramname[0] = "@dt";
                            pramname[1] = "@endo";
                            pramvalue[0] = d;
                            pramvalue[1] = textBox2.Text;
                            pramtype[0] = SqlDbType.NVarChar;
                            pramtype[1] = SqlDbType.Int;
                            dataGridView1.Visible = true;
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_setescope_operation_by_endCode", pramname, pramvalue, pramtype);
                        }

                        //cmd = new SqlCommand("setescope_setescope_operation_by_DoName", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@dt",d);
                        //cmd.Parameters.AddWithValue("@d_name",textBox3.Text);    
                    }
                    con.CloseConnection();
                    //dr = cmd.ExecuteReader();
                    //dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.Visible = true;
                    //dataGridView1.DataSource = dt;
                    //dr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { MessageBox.Show("لا يجب اختيار تاريخ ايام سابقة"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox3.Text = "";
            dataGridView1.DataSource = null;
            //dt.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        public static string time { get; set; }
        public static string end_name { get; set; }
        public static int id_op { get; set; }
        public static int id_d { get; set; }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string time1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                id_d = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                end_name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                //.Show(time);
                //MessageBox.Show(id_d.ToString());
                con.CloseConnection();
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@name";
                pramvalue[0] = end_name;
                pramtype[0] = SqlDbType.NVarChar;
                SqlDataReader dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_Endoscope_settings_data_select_id", pramname, pramvalue, pramtype);
                int end_id = 0;
                while (dr.Read())
                {
                    end_id = Convert.ToInt32(dr[0].ToString());
                }

                string[] pramnam = new string[3];
                string[] pramvalu = new string[3];
                SqlDbType[] pramtyp = new SqlDbType[3];
                pramnam[0] = "@dt";
                pramnam[1] = "@st";
                pramnam[2] = "@endo";
                pramvalu[0] = d;
                pramvalu[1] = time1;
                pramvalu[2] = end_id.ToString();
                pramtyp[0] = SqlDbType.NVarChar;
                pramtyp[1] = SqlDbType.NVarChar;
                pramtyp[2] = SqlDbType.Int;
                dr.Close();
                dr = con.ShowDataInGridViewUsingStoredProcDR("setescope_setescope_operation_select_id", pramnam, pramvalu, pramtyp);

                //cmd = new SqlCommand("setescope_setescope_operation_select_id", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@dt", d);
                //cmd.Parameters.AddWithValue("@st", time);
                //cmd.Parameters.AddWithValue("@endo", textBox2.Text); 
                //SqlDataReader dr = cmd.ExecuteReader();-
                while (dr.Read())
                {
                    id_op = Convert.ToInt32(dr[0].ToString());
                    // MessageBox.Show(id_op.ToString());
                }
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        public static int c { get; set; }
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
                c = Convert.ToInt32(dr["Room_code"].ToString());
                //MessageBox.Show(c.ToString());
                roomflag(c);

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
