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
    public partial class asset_salvage : Form
    {
        Connection sqlCon = new Connection();
        public asset_salvage()
        {
            InitializeComponent();
        }

        private void asset_salvage_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();
                object dt= sqlCon.ShowDataInGridViewUsingStoredProc("asset_existed_assets");
                comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "arabic_name";
            comboBox1.ValueMember = "code";
            label4.DataBindings.Add("text", dt, "code");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||  comboBox1.SelectedValue == null || dateTimePicker1.Value==null)
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            try
            {
                sqlCon.OpenConection();
                String[] x = { "@code", "@sal_value", "@sal_date" };
                String[] y = { comboBox1.SelectedValue.ToString(),textBox1.Text,dateTimePicker1.Value.ToString() };
                SqlDbType [] z={SqlDbType.Int,SqlDbType.Float,SqlDbType.Date};
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("set_salvage",x,y,z);
              
                MessageBox.Show("تم التخريد بنجاح");
            
                this.Hide();
            
            }
            catch (NullReferenceException ex) { MessageBox.Show("ادخل جميع البيانات"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }


      



    }
}
