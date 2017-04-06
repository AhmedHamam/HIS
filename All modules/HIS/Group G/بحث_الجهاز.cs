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
    public partial class بحث_الجهاز : Form
    {
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        SqlDataReader dr;
        DataTable dt;
        public static string Code { set; get; }
        public static string Arabic_name { set; get; }

        public بحث_الجهاز()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con1.OpenConection();

                if (textBox5.Text == "" && textBox6.Text == "")
                {

                    dr = con1.DataReader("select code as كود_الجهاز, arabic_name as الاسم_العربى from asset , asset_category where asset_category.code = asset.code and arabic_description = 'مناظير'");
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }
                else if (textBox5.Text == "")
                {

                    dr = con1.DataReader("select code as كود_الجهاز, arabic_name as الاسم_العربى from asset , asset_category where asset_category.code = asset.code and arabic_description = 'مناظير'  and  code = '" + (textBox6.Text) + "'");
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }
                else if (textBox6.Text == "")
                {

                    dr = con1.DataReader("select code as كود_الجهاز, arabic_name as الاسم_العربى  from asset , asset_category where asset_category.code = asset.code and arabic_description = 'مناظير' and  DeviceArabicName = '" + textBox5.Text + "'");
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }

                else
                {
                    //cmd.CommandText = "select code as كود_الجهاز, DeviceArabicName as الاسم_العربى, DeviceLatinName as الاسم_اللاتينى  from Instruments_and_tools where DeviceArabicName = '" + textBox5.Text + "' and code = '" + (textBox6.Text) + "'";
                    //dr = cmd.ExecuteReader();
                    //select code , arabic_name , from asset , asset_category where asset_category.code = asset.code and arabic_description = 'مناظير' and  DeviceArabicName = '" + textBox5.Text + "' and code = '" + (textBox6.Text) + "'"
                    dr = con1.DataReader("select code as كود_الجهاز, arabic_name as الاسم_العربى from asset , asset_category where asset_category.code = asset.code and arabic_description = 'مناظير' and  DeviceArabicName = '" + textBox5.Text + "' and code = '" + (textBox6.Text) + "'");
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    con1.CloseConnection();
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "  error");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Arabic_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                //مستلزمات_العملية f = new مستلزمات_العملية();
                //f.Focus();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("يجب اختيار جهاز");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void بحث_الجهاز_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
