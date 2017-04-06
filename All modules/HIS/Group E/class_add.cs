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
    public partial class class_add : Form
    {
        Connection sqlCon = new Connection();
        judgement x;
        String ex_no;
        
        public class_add( String y, judgement x)
        {
            this.x = x;
            ex_no = y;
            InitializeComponent();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" ||textBox1.Text=="")
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            try {

                sqlCon.OpenConection();
                String[] a = { "@name", "@unit", "@quantity", "@accepted", "@refused", "@ex" };
                String[] b = { textBox1.Text, textBox5.Text, textBox2.Text, textBox3.Text, textBox4.Text,ex_no };
                SqlDbType[] c = { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_class", a, b, c);
            this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            x.generate_reports();
            

        }

        private void class_add_Load(object sender, EventArgs e)
        {

        }

    }
}
