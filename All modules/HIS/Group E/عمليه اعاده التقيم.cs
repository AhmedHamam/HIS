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
    public partial class reevaluate : Form
    {
        Connection sqlCon = new Connection();
        public reevaluate()
        {
            InitializeComponent();
        }

        private void عمليه_اعاده_التقيم_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();
                comboBox1.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_reason_select");
                comboBox1.DisplayMember = "arabic_description";
                comboBox1.ValueMember = "code";
                object dt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_report");
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "arabic_name";
                comboBox2.ValueMember = "code";
                label8.DataBindings.Add("text", dt, "code");
                textBox1.DataBindings.Add("text", dt, "current_value");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem==null||dateTimePicker1.Value==null)
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } try
            {
                sqlCon.OpenConection();
              
                
                String[] a = { "@asset_code1","@re_evaluation_date1","@current_value1","@new_value1","@reason_code1","@notes1"};
                String[] b = { comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.ToShortDateString(), 
                                 textBox1.Text,textBox3.Text,comboBox1.SelectedValue.ToString(),richTextBox1.Text };
                SqlDbType[]c={SqlDbType.Int,SqlDbType.Date,SqlDbType.Float,SqlDbType.Float,SqlDbType.Int,SqlDbType.NVarChar};
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("re_evaluate",a,b,c);
                MessageBox.Show("تم اضافة التقييم");
                this.Hide();
            }

            catch (NullReferenceException ee)
            {
                MessageBox.Show("ادخل جميع البيانات");
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



    }
}
