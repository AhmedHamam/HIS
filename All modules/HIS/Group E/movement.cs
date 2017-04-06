using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class movement : Form
    {
        int to_kin = 0;
        Connection sqlcon = new Connection();
        public movement()
        {
            InitializeComponent();
        }

        private void movement_Load(object sender, EventArgs e)
        {
          
            try{
            sqlcon.OpenConection();
                object xx=sqlcon.ShowDataInGridViewUsingStoredProc("asset_report");
                comboBox1.DataSource = xx;
            comboBox1.ValueMember = "code";
            comboBox1.DisplayMember = "arabic_name";
            label4.DataBindings.Add("text", xx, "code");

                object tt=sqlcon.ShowDataInGridViewUsingStoredProc("asset_asset_store_select");
                comboBox8.DataSource = tt;
            comboBox8.ValueMember = "code";
            comboBox8.DisplayMember = "arabic_description";
            label5.DataBindings.Add("text", tt, "code");
                object ttt= sqlcon.ShowDataInGridViewUsingStoredProc("asset_get_dep");
            comboBox9.DataSource =ttt;
            comboBox9.ValueMember = "code";
            comboBox9.DisplayMember = "name";
            label6.DataBindings.Add("text", ttt, "code");
            object dt = sqlcon.ShowDataInGridViewUsingStoredProc("asset_get_mov_code");
                DataTable dtt = (DataTable)dt;
                int code = 0;

                if (dtt.Rows.Count != 0)
                 code = Convert.ToInt32(dtt.Rows[0][0]) + 1;
                else
                    code = 1;
                textBox2.Text = code.ToString();

            }
                catch(Exception ex) {MessageBox.Show(ex.Message);}
                finally{sqlcon.CloseConnection();}
        }

      

 

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.SelectedItem == null || dateTimePicker1.Value == null ||
                 ((!radioButton1.Checked || comboBox8.SelectedItem == null) && (!radioButton2.Checked || comboBox9.SelectedItem == null)))
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            
            
            try{
            sqlcon.OpenConection();

            String[] a = {"@code","@code_transaction" ,"@to_place" ,"@to_kind" ,"@transmit_date"};
            String[] b = {comboBox1.SelectedValue.ToString(), textBox2.Text,"t1","t2",dateTimePicker1.Value.ToString()};
            SqlDbType[] c = { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.Date};
            if (to_kin == 0) { b[2] = comboBox8.SelectedValue.ToString(); b[3] = "مخزن"; }
            else { b[2] = comboBox9.SelectedValue.ToString(); b[3] = "قسم"; }

            sqlcon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("asset_movement",a,b,c);
            MessageBox.Show("تم نقل الاصل");
            this.Hide();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { sqlcon.CloseConnection(); }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            to_kin =1;
            comboBox9.Show();
            label6.Show();
            label5.Hide();
            comboBox8.Hide();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
           
            to_kin =0;
            label5.Show();
            label6.Hide();
            comboBox8.Show();
            comboBox9.Hide();
        
        }
    }
}
