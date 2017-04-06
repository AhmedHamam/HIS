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
    public partial class اضافة_خدمات_الطوارىء : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlCommand cmd1;
        //MySqlDataReader dr;
        public static int Code1 { get; set; }
        public static string Code2 { get; set; }
        public اضافة_خدمات_الطوارىء()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            الخدمات h = new الخدمات();

            if (h.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = الخدمات.Code1.ToString();
                textBox1.Text = الخدمات.Code2.ToString();

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void اضافة_خدمات_الطوارىء_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            try
            {
                if (textBox3.Text != "" && textBox1.Text != "" && comboBox1.Text != "")
                {
                    string[] f = new string[] { "@c", "@n", "@t" };
                    string[] f2 = new string[] { textBox3.Text, textBox1.Text, comboBox1.Text };
                   
                    
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                    if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("adds_emergency_services", f, f2, f3))
                    {
                        MessageBox.Show("تمت اضافة هذه الخدمة من قبل ");
                        return;
                    }
                    //string s = "insert into emergency_emergency_services values(@c,@n,@t);";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@c", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@n", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@t", comboBox1.SelectedItem);
                    //cmd.ExecuteNonQuery();

                    MessageBox.Show("تمت الاضافة بنجاح");
                }
                else
                {
                    MessageBox.Show("قم باكمال البيانات");
                }

            }
            catch (Exception )
            {
                MessageBox.Show("تمت اضافة هذه الخدمة من قبل");
            }
            con.CloseConnection();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            try
            {
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("disp_emergency_services");
            //    string s = "select serv_code as 'كود الخدمة',serv_name as 'اسم الخدمة',serv_time as 'توقيت الخدمة' from emergency_emergency_services;";
            //    cmd1 = new MySqlCommand(s, con);
            //    dr = cmd1.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

