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

    public partial class Main_Pharma_Details : Form
    {
        string med_id;
        public Main_Pharma_Details()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //pharamacy_some__med_credit
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_select_all_medicines");
           // conn.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharamacy_select_all_medicines", new string[] { "@med_id" }, new string[] { med_id }, new SqlDbType[] { SqlDbType.Int });
         

            //connection.Close();
            dataGridView1.Visible =true;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Main_Pharma_Details_Load(object sender, EventArgs e)
        {

        }

        private void txtDawa3i_TextChanged(object sender, EventArgs e)
        {

        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regex num = new Regex("^[0-9]");
         Regex txt  =new Regex("(?i)^[a-z]+");

         if (num.Match(txtQuantity.Text).Success && num.Match(txtPrice.Text).Success && txt.Match(txtDawa3i.Text).Success && txt.Match(txtFa3ala.Text).Success && txt.Match(txrArabicName.Text).Success && txt.Match(txtmethod.Text).Success)
         {
             Connection conn = new Connection();
             conn.OpenConection();
             int quantity = int.Parse(txtQuantity.Text);
             float price = float.Parse(txtPrice.Text);
             string name = txrArabicName.Text;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (med_id != string.Empty)
            {
                Connection conn = new Connection();
                conn.OpenConection();
                conn.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharmacy_delect_medicine", new string[] { "@med_id" }, new string[] { med_id.ToString() }, new SqlDbType[] { SqlDbType.Int });
                MessageBox.Show("تم الحذف");
            }
            else
            {
                MessageBox.Show("من فضلك اختر الدواء");
            }
        }

        private void txrArabicName_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}

