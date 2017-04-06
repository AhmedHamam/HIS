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
    public partial class asset_reevaluation : Form
    {
        Connection sqlCon = new Connection();
      
        public static string x;
        reasons_search r;
        public asset_reevaluation( reasons_search r)

        {
            this.r = r;
            InitializeComponent();

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
            
            String[] a = { "@code3","@arabic_description3","@latin_description3"}; 
            String[] b = {textBox1.Text,textBox2.Text,textBox3.Text };
            SqlDbType[] c = { SqlDbType.Int,SqlDbType.NVarChar,SqlDbType.NVarChar};
            sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_reason",a,b,c);
            
                MessageBox.Show("تم اضافة السبب بنجاح");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.CloseConnection();
                
            }
            
        
            
            
        }


        private void asset_reevaluation_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@table" };
                String[] b = { "asset_re_evaluation_reasons" };
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
            catch (Exception ec) { MessageBox.Show(ec.Message); }
            finally
            {
                sqlCon.CloseConnection();
            }
        }





    
    }
}
