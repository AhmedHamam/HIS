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
    public partial class تقرير_قائمة_المرضى_طبقا_للجنسيات : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        DataSet ds = new DataSet();
        //MySqlDataAdapter da;
        //BindingSource bs;
        public تقرير_قائمة_المرضى_طبقا_للجنسيات()
        {
            InitializeComponent();
        }

        private void تقرير_قائمة_المرضى_طبقا_للجنسيات_Load(object sender, EventArgs e)
        {
           // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");

            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // da = new MySqlDataAdapter();
            try
            {
                string[] a = new string[] { "@x", "@y", "@z" };
                string[] a2 = new string[] { textBox4.Text,textBox5.Text,comboBox2.Text };
                SqlDbType[] a3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("report_nationality", a, a2, a3);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            nationalityDate1 d = new nationalityDate1(this);
            d.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            nationalityDate d = new nationalityDate(this);
            d.Show();
        }
        public void setvalue1(string x)
        {
            textBox4.Text = x;

        }
        public void setvalue2(string x)
        {
            textBox5.Text = x;

        }

    }
}
