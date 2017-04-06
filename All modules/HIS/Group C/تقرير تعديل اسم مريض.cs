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
    public partial class تقرير_تعديل_اسم_مريض : Form
    {


        Connection con = new Connection();
      //  MySqlCommand cmd;
        //MySqlDataAdapter da;
        DataSet ds = new DataSet();

        public تقرير_تعديل_اسم_مريض()
        {
            InitializeComponent();
        }


      
        private void تقرير_تعديل_اسم_مريض_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string[] ss = new string[] { "@x" };
                string[] ss2 = new string[] { textBox1.Text };
                SqlDbType[] ss3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("udatee_name", ss, ss2, ss3);
                //cmd = new MySqlCommand("select * from updatee where patient_id=@x;", con);
                //cmd.Parameters.AddWithValue("@x", textBox1.Text);
                //da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // محرك_البحث_عن_مريض_تقرير ob = new محرك_البحث_عن_مريض_تقرير();
            //if (ob.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = محرك_البحث_عن_مريض_تقرير.Code.ToString();  
            //    //2
            //    //MessageBox.Show();
            //    textBox2.Text = محرك_البحث_عن_مريض_تقرير.Code2;  
            
            //1
            //}

            محرك_البحث_عن_مريض_تعديل_اسم f = new محرك_البحث_عن_مريض_تعديل_اسم(this);
            f.Show();
        }

                public void setValue(int d,String name)
              {

                  textBox1.Text = d.ToString();
                  textBox2.Text = name;

              }

    }
}
