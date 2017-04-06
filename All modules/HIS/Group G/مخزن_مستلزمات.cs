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
    public partial class مخزن_مستلزمات : Form
    {
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        SqlDataReader dr;
        DataTable dt;

        public static int Code { set; get; }
        public static string Arabic_name { set; get; }

        public مخزن_مستلزمات()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void مخزن_مستلزمات_Load(object sender, EventArgs e)
        {
            try
            {

                con1.OpenConection();
                dr = con1.DataReader("select category_id , categoryName from Inventory_categories");
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "  error");
            }
            con1.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con1.OpenConection();
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                //
                dr = con1.DataReader("select category_id , categoryName from  Inventory_categories");
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();

            }
            else if (textBox1.Text == "")
            {

                dr = con1.DataReader("select category_id , categoryName  from Inventory_categories where categoryName = '" + textBox2.Text + "'");
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();

            }
            else if (textBox2.Text == "")
            {

                dr = con1.DataReader("select category_id , categoryName  from Inventory_categories where code = " + int.Parse(textBox1.Text));
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            else
            {

                dr = con1.DataReader("select category_id , categoryName  from Inventory_categories where category_id = " + int.Parse(textBox1.Text) + " and categoryName = '" + textBox2.Text + "'");

                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();

            }

            con1.CloseConnection();


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Arabic_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                //مستلزمات_العملية f = new مستلزمات_العملية();
                //f.Focus();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("يجب اختيار مستلزم ");
            }


        }

    }
}
