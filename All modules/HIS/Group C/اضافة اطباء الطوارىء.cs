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
    public partial class اضافة_اطباء_الطوارىء : Form
    {

        Connection con = new Connection();
        public اضافة_اطباء_الطوارىء()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            الاطباء f = new الاطباء();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = الاطباء.Code1.ToString();
                textBox1.Text = الاطباء.Code2.ToString();
            }
        }

        private void اضافة_اطباء_الطوارىء_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

            con.OpenConection();

               

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && comboBox3.Text != "" && comboBox2.Text != "" && comboBox1.Text != "")
                {
                    //string s = "insert into emergency_emergency_doctors values(@dc,@dn,@p,@ad,@ed)";
                    //cmd = new MySqlCommand(s, con);
                    //cmd.Parameters.AddWithValue("@dc", textBox2.Text);
                    //cmd.Parameters.AddWithValue("@dn", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@p", comboBox1.SelectedItem);
                    //cmd.Parameters.AddWithValue("@ad", comboBox2.SelectedItem);
                    //cmd.Parameters.AddWithValue("@ed", comboBox3.SelectedItem);
                    //cmd.ExecuteNonQuery();

                    string[] f = new string[] { "@dc", "@dn", "@p", "@ad", "@ed" };
                    string[] f2 = new string[] { textBox2.Text, textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text};
                    SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_emegency_doctors", f, f2, f3);
                    
                        MessageBox.Show("تمت الاضافة بنجاح");
                    

                }
                else
                {
                    {
                        MessageBox.Show("قم بادخال البيانات كاملة");
                    }
                }

            }



            catch (Exception )
            {
                //if (textBox1.Text ==""||textBox2.Text ==""||comboBox3.Text == "" ||comboBox2.Text == "" ||comboBox1.Text == "")
                //{
                // MessageBox.Show("قم بادخال البيانات كاملة");
                // }
                // else
                //{
                MessageBox.Show("هذا الطبيب تم اضافته فى هذا اليوم وهذه الفترة ");
                // }

            }


            con.CloseConnection();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            try
            {



                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("add_emegency_doctors_dispaly");

                //string s = "select * from emergency_emergency_doctors;";
                //cmd1 = new MySqlCommand(s, con);
                //dr = cmd1.ExecuteReader();
                //DataTable d = new DataTable();
                //d.Load(dr);
                //dataGridView1.DataSource = d;
                //dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
