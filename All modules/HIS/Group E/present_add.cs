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
    public partial class present_add : Form
    {judgement x;
    Connection sqlCon = new Connection();
        String ex_no;
        public present_add( String y, judgement x)
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
            if (textBox1.Text==""||textBox2.Text==""||textBox5.Text=="")
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            try
            {
                sqlCon.OpenConection();
               
                String[] a = { "@name", "@unit", "@quantity","@ex" };
                String[] b = { textBox1.Text, textBox5.Text, textBox2.Text, ex_no };
                SqlDbType[] c = { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_present", a, b, c);
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            x.generate_reports();
            
        }

        private void present_add_Load(object sender, EventArgs e)
        {

        }

  
    }
}
