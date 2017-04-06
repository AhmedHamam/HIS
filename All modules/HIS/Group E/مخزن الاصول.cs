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
    public partial class store : Form
    {
        Connection sqlCon = new Connection();
        public static string x;
        search_store ss;
        public store( search_store ss)
        {
            this.ss = ss;
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon.OpenConection();
            String[] a = { "@table" };
            String[] b = { "asset_store" };
            SqlDbType[] c = { SqlDbType.NVarChar };
            object dt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_code", a, b, c);
            DataTable dtt = (DataTable)dt;
            int code = 0;

            if (dtt.Rows.Count != 0)
            {
                code = Convert.ToInt32(dtt.Rows[0][0]) + 1;
            }

            else
                code = 1;
            textBox1.Text = code.ToString();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "")
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@code1", "@arabic_description1", "@latin_description1" };
                String[] b = { textBox1.Text, textBox2.Text, textBox3.Text };
                SqlDbType[] c = { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_store", a, b, c);
                
                MessageBox.Show("تم اضافة المخزن");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.CloseConnection();
            }
            
            this.Hide();
         

        }
        
    }


}