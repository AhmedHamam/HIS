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
    public partial class addsub : Form
    {

        Connection sqlCon = new Connection();
        sub a;
        public static string x;
        public addsub(sub a)
        {
            this.a = a;
            InitializeComponent();
        }
      

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox3.Text == "" || comboBox1.SelectedItem.ToString() == "" ||
                comboBox2.SelectedValue == null || comboBox3.SelectedValue == null || comboBox4.SelectedValue == null)
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return; 
            }

            try
            {
                sqlCon.OpenConection();
                String[] paramName = { "@code", "@latin_description1", "@arabic_description1", "@annual_depreciation_rate1", "@stop_depreciation_at1", "@depreciation_method1", "@ac1", "@ac2", "@ac3" };
                String[] x = { textBox1.Text, textBox3.Text, textBox2.Text, textBox5.Text, textBox7.Text, comboBox1.SelectedValue.ToString(),comboBox2.SelectedValue.ToString(),comboBox3.SelectedValue.ToString(),
                             comboBox4.SelectedValue.ToString()};
                SqlDbType[] y = { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Float, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_sub", paramName, x, y);
             
                MessageBox.Show("تم الاضافة بنجاح");
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

        private void addsub_Load(object sender, EventArgs e)
        {
            var items = new[] { 
    new { Text = "شهرى", Value = "monthly" }, 
    new { Text = "سنوى", Value = "annually" } 
};
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = items;
           
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@table" };
                String[] b = { "asset_subcategory" };
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



                object dttt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_tb_Accounts_select");
                comboBox2.DataSource = dttt;
                comboBox2.ValueMember = "Ac_id";
                comboBox2.DisplayMember = "Ac_id";

                comboBox3.DataSource = dttt;
                comboBox3.ValueMember = "Ac_id";
                comboBox3.DisplayMember = "Ac_id";
                comboBox4.DataSource = dttt;
                comboBox4.ValueMember = "Ac_id";
                comboBox4.DisplayMember = "Ac_id";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {

                sqlCon.CloseConnection();
            }
  


        }

    }
}
