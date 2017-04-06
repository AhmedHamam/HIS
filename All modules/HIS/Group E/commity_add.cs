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
    public partial class commity_add : Form
    {
        Connection sqlCon = new Connection();
        judgement x;
        String ex_no;
        public commity_add( String y, judgement x)
        {
            this.x = x;
            ex_no = y;
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || textBox1.Text == "") {

                MessageBox.Show("بعض الخانات مفقودة !");
                return; 
            }

            try
            {
                sqlCon.OpenConection();
                String[] a = { "@code1", "@missions1", "@head1", "@ex" };
                String[] b = { textBox1.Text, textBox1.Text,(Convert.ToInt32(checkBox1.Checked)).ToString(), ex_no };
                SqlDbType[] c = {  SqlDbType.Int,SqlDbType.NVarChar, SqlDbType.Bit, SqlDbType.Int };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Add_commity", a, b, c);
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            x.generate_reports();
            
        }

        private void commity_add_Load(object sender, EventArgs e)
        {
            try
            {

                sqlCon.OpenConection();
                comboBox1.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_employees");
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "emp_id";
             
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

  
    }
}
