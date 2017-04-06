using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HIS;
using System.Text.RegularExpressions;

namespace HIS
{
    public partial class توريد__ادويه_الي__الصيدليه : Form
    {

        
        public توريد__ادويه_الي__الصيدليه()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
           dataGridView1.DataSource= con.ShowDataInGridViewUsingStoredProc("pharmacy_select_SupplierName");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex num = new Regex("^[0-9]");
            Regex txt = new Regex("(?i)^[a-z]+");

            if (num.Match(txtQuantity.Text).Success && num.Match(txtPrice.Text).Success && txt.Match(txtDawa3i.Text).Success && txt.Match(txtFa3ala.Text).Success && txt.Match(txt_medicinename.Text).Success && txt.Match(txtmethod.Text).Success)
            {
                Connection conn = new Connection();
                conn.OpenConection();
                int quantity = int.Parse(txtQuantity.Text);
                float price = float.Parse(txtPrice.Text);
                string name = txt_medicinename.Text;
                string mada = txtFa3ala.Text;
                string use = txtDawa3i.Text;
                string taking = txtmethod.Text;
                DateTime date = dateTimePicker1.Value;
                conn.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharmacy_insert_medicine", new string[] { "@quantity", "@med_name", "@eff_subject", "@useability", "@price", "@taking_meth", "@ex_date" },
                new string[] { quantity.ToString(), name, mada, use, price.ToString(), taking, date.ToString() },
                new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Float, SqlDbType.NVarChar, SqlDbType.Date });
                MessageBox.Show("تمت الاضافه");

            }

            else
            {
                MessageBox.Show("يجب ادخال بينانات صحيحة");
            }
        

        }

        private void توريد__ادويه_الي__الصيدليه_Load(object sender, EventArgs e)
        {

        }
    }
}
