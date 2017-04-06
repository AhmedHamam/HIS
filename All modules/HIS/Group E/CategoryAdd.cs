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
    public partial class CategoryAdd : Form
    {
        Connection sqlCon = new Connection();
        public static string x;
        public CategoryAdd()
        {
            InitializeComponent();
        }

       
        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" ||textBox3.Text == "" )
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            try
            {
            sqlCon.OpenConection();
                String[]a={"@code","@arabic","@latin"};
                String[]b={textBox1.Text,textBox2.Text,textBox3.Text};
                SqlDbType[]c={SqlDbType.Int,SqlDbType.NVarChar,SqlDbType.NVarChar};
            sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_Category",a,b,c);
                MessageBox.Show("تمت الاضافة بنجاح");
                this.Hide();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                sqlCon.CloseConnection();
            
            }

        }


        private void CategoryAdd_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@table" };
                String[] b = { "asset_category" };
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
                x = code.ToString();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            finally
            {
                sqlCon.CloseConnection();
            }
        }

    }
}
