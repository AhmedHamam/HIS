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
    public partial class add_asset : Form
    {
        Connection sqlCon = new Connection();
        public add_asset()
        {
            InitializeComponent();
        }


        private void اضافه_البيانات_الاساسيه_للاصول_Load(object sender, EventArgs e)
        {

            try {
                sqlCon.OpenConection();

                object t1=sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_command_supply");
                comboBox10.DataSource = t1;
                comboBox10.ValueMember = "commandsupply_id";
                comboBox10.DisplayMember = "commandsupply_id";

                object t2 =sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_Inventory_supplier");
                comboBox2.DataSource = t2;
                comboBox2.ValueMember = "supplier_id";
                comboBox2.DisplayMember = "name";
                label32.DataBindings.Add("text", t2, "supplier_id");

                object t3=sqlCon.ShowDataInGridViewUsingStoredProc("asset_asset_condition_select");
                comboBox6.DataSource = t3;
                comboBox6.ValueMember = "code";
                comboBox6.DisplayMember = "arabic_name";
                label33.DataBindings.Add("text", t3, "code");

                object t4=sqlCon.ShowDataInGridViewUsingStoredProc("asset_subcategory_select");
                comboBox3.DataSource = t4;
                comboBox3.ValueMember = "code";
                comboBox3.DisplayMember = "arabic_description";
                label29.DataBindings.Add("text",t4,"code");

                object t5=sqlCon.ShowDataInGridViewUsingStoredProc("asset_asset_category_select");
                comboBox4.DataSource = t5;
                comboBox4.ValueMember = "code";
                comboBox4.DisplayMember = "arabic_description";
                label30.DataBindings.Add("text", t5, "code");

                object t6=sqlCon.ShowDataInGridViewUsingStoredProc("asset_asset_origin_select");
                comboBox1.DataSource = t6;
                comboBox1.ValueMember = "code";
                comboBox1.DisplayMember = "arabic_description";
                label31.DataBindings.Add("text", t6, "code");
             
                object t7=sqlCon.ShowDataInGridViewUsingStoredProc("asset_asset_receive_examin_select");
                comboBox7.DataSource = t7;
                comboBox7.ValueMember = "examination_number";
                comboBox7.DisplayMember = "examination_number";

                object t8=sqlCon.ShowDataInGridViewUsingStoredProc("asset_asset_store_select");
                comboBox8.DataSource = t8;
                comboBox8.ValueMember = "code";
                comboBox8.DisplayMember = "arabic_description";
                label34.DataBindings.Add("text", t8, "code");

                object t9= sqlCon.ShowDataInGridViewUsingStoredProc("asset_get_dep");
                comboBox9.DataSource = t9;
                comboBox9.ValueMember = "code";
                comboBox9.DisplayMember = "name";
                label35.DataBindings.Add("text", t9, "code");

                String[] a = { "@table" };
                String[] b = { "asset" };
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
            finally {
                sqlCon.CloseConnection();
            }            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" ||
                textBox16.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "" ||
                textBox5.Text == "" || textBox4.Text == "" || textBox2.Text == "" || dateTimePicker1.Value == null ||
                comboBox1.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null ||
                comboBox7.SelectedItem == null || comboBox6.SelectedItem == null || comboBox5.SelectedItem == null || comboBox10.SelectedItem == null)
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            } 
            try {

            sqlCon.OpenConection();

            String[] x ={ "@code1", "@barcode1", "@import_order_number1", "@current_value1", "@opening_value1",
              "@document_value1","@salvage_value1", "@subcategory1","@category1","@origin1","@nature1","@condition1",
              "@device_serial1", "@global_barcode1","@arabic_name1","@latin_name1","@acquired_date1","@depreciation_rate1",
              "@Book_life1","@depreciation_calculation1","@depreciation_expenses_account1","@supplier1","@ex","@store","@dep"};
            String[] y = { textBox1.Text, textBox2.Text,comboBox10.SelectedValue.ToString(), textBox4.Text, textBox5.Text, textBox6.Text,
                         textBox16.Text,comboBox3.SelectedValue.ToString(),comboBox4.SelectedValue.ToString(),comboBox1.SelectedValue.ToString(),
                        comboBox5.SelectedItem.ToString(), comboBox6.SelectedValue.ToString(),
                         textBox7.Text,textBox10.Text, textBox9.Text, textBox8.Text,dateTimePicker1.Value.Date.ToString(),
                         textBox13.Text,textBox11.Text,textBox12.Text,textBox14.Text,comboBox2.SelectedValue.ToString(),
                         comboBox7.SelectedValue.ToString(),"0","0"};
            SqlDbType[] z = {SqlDbType.Int ,SqlDbType.Int,SqlDbType.Int ,SqlDbType.Float,SqlDbType.Float,SqlDbType.Float,SqlDbType.Float,SqlDbType.Int ,
                                SqlDbType.Int,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.Int,SqlDbType.Int,SqlDbType.Int,
                                SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Date,SqlDbType.Float,SqlDbType.Int,
                                SqlDbType.Float,SqlDbType.Int,SqlDbType.Int,SqlDbType.Int,SqlDbType.Int,SqlDbType.Int };


            if (radioButton1.Checked)
            {
                y[23] = comboBox8.SelectedValue.ToString();

            }
            else
            {
                y[24] = comboBox9.SelectedValue.ToString();
            }

            sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_asset", x, y, z);
                MessageBox.Show("تم اضافة الاصل بنجاح");
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

        private void label24_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

  



        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox9.Show();
            label34.Hide();
            label35.Show();
            comboBox8.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            comboBox8.Show();
            label35.Hide();
            label34.Show();
            comboBox9.Hide();
        }
  

    }
}
