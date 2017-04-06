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
    public partial class بحث_دكتور : Form
    {
        public بحث_دكتور()
        {
            InitializeComponent();
        }
        private void بحث_دكتور_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
        Connection con = new Connection();
        //SqlCommand cmd;
        //DataSet ds = new DataSet();
        //SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
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

            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            con.OpenConection();
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_doctors_select");
                    //    cmd = new SqlCommand("setescope_doctors_select",con);
                    //    cmd.CommandType = CommandType.StoredProcedure; 
                    //
                }
                else
                {
                    if (textBox1.Text != "")
                    {
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@d_id";
                        pramvalue[0] = textBox1.Text;
                        pramtype[0] = SqlDbType.Int;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_doctors_select_do_id", pramname, pramvalue, pramtype);

                        //    cmd = new SqlCommand("setescope_doctors_select_do_id", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.AddWithValue("@d_id", textBox1.Text);
                        //
                    }
                    else if (textBox2.Text != "")
                    {
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@do_name";
                        pramvalue[0] = textBox2.Text;
                        pramtype[0] = SqlDbType.VarChar;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_doctors_select_do_name", pramname, pramvalue, pramtype);

                        //    cmd = new SqlCommand("setescope_doctors_select_do_name", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.AddWithValue("@do_name", textBox2.Text);
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.Visible = true;
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();

        }
        public static int y { get; set; }
        public static string x { get; set; }
        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {

            y = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            x = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            حجز_عملية_مستقبلية f = new حجز_عملية_مستقبلية();
            f.Focus();
            this.DialogResult = DialogResult.OK;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void خروج_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
