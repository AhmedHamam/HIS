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

    public partial class بحث_العمليه_للمنظار  : Form
    {
        public بحث_العمليه_للمنظار ()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        //DataSet ds=new DataSet();
        //SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
        //SqlDataAdapter da;
        //SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int parsedValue;
                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("يجب ادخال ارقام فقط");
                    return;
                }
            }
            if (textBox2.Text != "")
            {
                int parsedValue;
                if (int.TryParse(textBox2.Text, out parsedValue))
                {
                    MessageBox.Show("يجب ادخال حروف فقط");
                    return;
                }
            }

            //  textBox1.Text = "";
            // textBox2.Text = "";
            
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                con.OpenConection();
                //Form1 f = new Form1();
                //MessageBox.Show(Form1.c.ToString());
                //MessageBox.Show(تعديل_البيانات.x.ToString());
                 
                //تعديل_البيانات f1 = new تعديل_البيانات();
                //if (تعديل_البيانات.x != Form1.c)
                //{
                //   // MessageBox.Show(Form1.c.ToString());
                //    //Form1.c = تعديل_البيانات.x;
                

                try
                {
                    if (textBox1.Text == "" && textBox2.Text == "")
                    {
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@room_code";
                        pramvalue[0] = بحث_عن_عملية_في_تاريخ_معين.c.ToString();
                        pramtype[0] = SqlDbType.Int;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_Endoscope_settings_data_select", pramname, pramvalue, pramtype);

                        //    cmd = new SqlCommand("setescope_Endoscope_settings_data_select", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.AddWithValue("@room_code", Form2.c);
                        //
                    }
                    else
                    {
                        if (textBox1.Text != "")
                        {
                            string[] pramname = new string[2];
                            string[] pramvalue = new string[2];
                            SqlDbType[] pramtype = new SqlDbType[2];
                            pramname[0] = "@room_code";
                            pramvalue[0] = بحث_عن_عملية_في_تاريخ_معين.c.ToString();
                            pramtype[0] = SqlDbType.Int;
                            pramname[1] = "@endscope_code";
                            pramvalue[1] = textBox1.Text;
                            pramtype[1] = SqlDbType.Int;
                            dataGridView1.Visible = true;
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_Endoscope_settings_data_select_endscope_code", pramname, pramvalue, pramtype);

                            //cmd = new SqlCommand("setescope_Endoscope_settings_data_select_endscope_code", con);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@room_code", Form2.c);
                            //cmd.Parameters.AddWithValue("@endscope_code", textBox1.Text);

                        }
                        else if (textBox2.Text != "")
                        {
                            string[] pramname = new string[2];
                            string[] pramvalue = new string[2];
                            SqlDbType[] pramtype = new SqlDbType[2];
                            pramname[0] = "@room_code";
                            pramvalue[0] = بحث_عن_عملية_في_تاريخ_معين.c.ToString();
                            pramtype[0] = SqlDbType.Int;
                            pramname[1] = "@endscope_name";
                            pramvalue[1] = textBox2.Text;
                            pramtype[1] = SqlDbType.VarChar;
                            dataGridView1.Visible = true;
                            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_Endoscope_settings_data_select_endscope_name", pramname, pramvalue, pramtype);

                            //    cmd = new SqlCommand("setescope_Endoscope_settings_data_select_endscope_name", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@room_code", Form2.c);
                            //    cmd.Parameters.AddWithValue("@endscope_name", textBox2.Text);
                            //
                        }

                    }
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //dataGridView1.Visible = true;
                    //dataGridView1.DataSource = dt;
                    //dr.Close();
                    //con.Close();
               }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                    
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        public static int y { get; set; }
        public static string x { get; set; }
        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            y = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            x = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            بحث_عن_عملية_في_تاريخ_معين  f = new بحث_عن_عملية_في_تاريخ_معين ();
            f.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void بحث_العمليه_للمنظار_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void خروج_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    }
}
