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
    public partial class refused_add : Form
    {
        Connection sqlCon = new Connection();
        judgement x;
        String ex_no;
        public refused_add( String y ,judgement x)
        {
            ex_no = y;
            this.x = x;
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@name", "@unit", "@quantity", "@ex","@reason" };
                String[] b = { textBox1.Text, textBox5.Text, textBox2.Text, ex_no,textBox3.Text };
                SqlDbType[] c = { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_refused", a, b, c);
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            x.generate_reports();
            
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void refused_add_Load(object sender, EventArgs e)
        {

        }


    }
}
