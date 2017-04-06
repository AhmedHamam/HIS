using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class judgement : Form
    {
        public static Boolean added ;
        Connection sqlCon = new Connection();
        public judgement()
        {
            InitializeComponent();
        }



        private void label8_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
               
                class_add x = new class_add(label7.Text, this);
                x.Show();
            }
            else if (tabControl1.SelectedIndex == 1) {
                present_add x = new present_add(label7.Text, this);
                x.Show();
            }
            else if (tabControl1.SelectedIndex == 2) { refused_add x = new refused_add(label7.Text,this);
            x.Show();
            }
            else if (tabControl1.SelectedIndex == 3) { commity_add x = new commity_add(label7.Text,this);
            x.Show();
            }
        }

        private void judgement_Load(object sender, EventArgs e)
        {
            ((first)this.MdiParent).menuStrip1.Visible = false;

            sqlCon.OpenConection();
            
            try {
                object dt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_ex_no");
                DataTable dtt = (DataTable)dt;
                int code = 0;

                if (dtt.Rows.Count != 0)
                {
                    code = Convert.ToInt32(dtt.Rows[0][0]) + 1;
                }

                else
                    code = 1;
                label7.Text = code.ToString();
                /////////////////////
                String[] a = { "@ex_no" };
                String[] b = { code.ToString()};
                SqlDbType[] c = {SqlDbType.Int };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_ex_no", a, b, c);

                comboBox4.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_bills");
                comboBox4.DisplayMember = "bill_id";
                comboBox4.ValueMember = "bill_id";

               comboBox2.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_command_supply");
               comboBox2.DisplayMember = "commandsupply_id";
               comboBox2.ValueMember = "commandsupply_id";




            }
            catch (Exception ex) { MessageBox.Show(ex.Message);
            }
            finally { 
                sqlCon.CloseConnection(); 
           }
            

        }

        public void generate_reports() {
            try
            {
               sqlCon.OpenConection();
               String[] a = { "@table","@ex" };
               String[] b = { "asset_class", label7.Text };
               SqlDbType[] c = {SqlDbType.NVarChar,SqlDbType.NVarChar };
               dataGridView1.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_judg_reports", a, b, c);

                b[0] = "asset_present";
                dataGridView2.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_judg_reports", a, b, c);
                
                b[0] = "asset_refused";
                dataGridView3.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_judg_reports", a, b, c);

                b[0] = "asset_commity";
                dataGridView4.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("asset_judg_reports", a, b, c);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

 

        private void label17_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null || comboBox3.SelectedValue == null ||
                comboBox4.SelectedValue == null||dateTimePicker1.Value==null||textBox1.Text=="")
            {

                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            try
            {
                sqlCon.OpenConection();
                
                String[] a = {  "@date", "@ex_no", "@sub_num","@pur_o_k","@im_no","@ex_state"};
                String[] b = { dateTimePicker1.Value.ToString(), label7.Text, comboBox4.SelectedValue.ToString(), textBox1.Text, comboBox2.SelectedValue.ToString(), comboBox3.SelectedText };
                SqlDbType[] c = { SqlDbType.Date, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.NVarChar };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("update_ex",a,b,c);
                MessageBox.Show("تم الحفظ");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            ((first)this.MdiParent).menuStrip1.Visible = true;
            this.Hide();
        }

        private void label24_Click(object sender, EventArgs e)
        {


            try
            {
                sqlCon.OpenConection();
                String[] a = { "@ex_no" };
                String[] b = { label7.Text };
                SqlDbType[] c = { SqlDbType.Int };
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("undo_examination", a, b, c);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            ((first)this.MdiParent).menuStrip1.Visible = true;
            this.Hide();

        }

    }
}
