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
    public partial class صيانه_الاصل : Form
    {
        Connection sqlCon = new Connection();
        public صيانه_الاصل()
        {
            InitializeComponent();
        }

        private void صيانه_الاصل_Load(object sender, EventArgs e)
        {

            try
            {
                sqlCon.OpenConection();
                object xx=sqlCon.ShowDataInGridViewUsingStoredProc("asset_report");
                comboBox1.DataSource = xx;
                comboBox1.ValueMember = "code";
                comboBox1.DisplayMember = "arabic_name";
                label8.DataBindings.Add("text",xx,"code");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""||
                dateTimePicker1.Value==null||comboBox1.SelectedItem==null)
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@code1", "@maintenance_date1", "@visit_number1", "@visit_type1", "@responsible_engineer1", "@visit_report1", "@recommendations1" };
                String[] b = { comboBox1.SelectedValue.ToString(), dateTimePicker1.Value.ToString(), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text };
                SqlDbType[] c = { SqlDbType.Int, SqlDbType.Date, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };

                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("maintinance1", a, b, c);
                MessageBox.Show("تمت اضافة الصيانة");
                this.Hide();

            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("ادخل جميع البيانات");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlCon.CloseConnection(); }
            
            
        }

  
    }
}
