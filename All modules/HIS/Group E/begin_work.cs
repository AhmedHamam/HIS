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
    public partial class begin_work : Form
    {
        Connection sqlCon = new Connection();
        public begin_work()
        {
            InitializeComponent();
        }

        private void begin_work_Load(object sender, EventArgs e)
        {
            
         
            try
            {
                sqlCon.OpenConection();
                object xx = sqlCon.ShowDataInGridViewUsingStoredProc("asset_unworked");

                comboBox1.DataSource = xx;
                comboBox1.DisplayMember = "arabic_name";
                comboBox1.ValueMember = "code";
                label3.DataBindings.Add("text", xx, "code");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if ( comboBox1.SelectedValue == null ||dateTimePicker1.Value==null)
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            try
            {
                sqlCon.OpenConection();
                String[]a={"@code" ,"@bdate" };
                String[]b={comboBox1.SelectedValue.ToString(),dateTimePicker1.Value.ToString()};
                SqlDbType[]c={SqlDbType.Int,SqlDbType.Date};
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("asset_begin",a,b,c);
            MessageBox.Show("تم حفظ معادالتشغيل");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally {
                sqlCon.CloseConnection();
            }
            this.Hide();
          
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
         
        }

    
    }
}
