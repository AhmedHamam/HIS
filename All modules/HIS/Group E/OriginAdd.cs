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
    public partial class OriginAdd : Form
    {
        Connection sqlCon = new Connection();
        public static string x;
        public OriginAdd()
        {
            InitializeComponent();
        }


        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||textBox2.Text=="")
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } try
            {
            sqlCon.OpenConection();
            String[] a = { "@c", "@arabic", "@latin" };
            String[] b = { textBox1.Text, textBox2.Text, textBox3.Text };
            SqlDbType[] c = {SqlDbType.Int,SqlDbType.NVarChar,SqlDbType.NVarChar };
            sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_Origin",a,b,c);
                MessageBox.Show("تمت الاضافة بنجاح");
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                sqlCon.CloseConnection();
                this.Hide();
            }
        }

        private void OriginAdd_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();
                
                String[] a = { "@table" };
                String[] b = { "asset_Origin" };
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                sqlCon.CloseConnection();
            }
        }





    }
}
