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

namespace HIS
{
    public partial class medicineComany : Form
    {
        //string supp_id = "";
        public medicineComany()
        {
            InitializeComponent();
        }

        private void medicineComany_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharmacy_select_SupplierName");
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection("Data Source=NANCY-TOSH;Initial Catalog=pharmacy;Integrated Security=True");
            //SqlCommand cmd;
            //SqlDataReader dr;
            //connection.Open();
            //try
            //{
            //    string date;
            //    date = dateTimePicker1.Value.ToString();
            //    cmd = new SqlCommand("insert into supplier (name,imort_date) values ('" + txtName.Text + "','" + date + "')", connection);
            //    dr = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //connection.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }
       


        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //SqlConnection connection = new SqlConnection("Data Source=NANCY-TOSH;Initial Catalog=pharmacy;Integrated Security=True");
            //SqlCommand cmd;
            //if (supp_id != "")
            //{
            //    connection.Open();
            //    try
            //    {
            //        cmd = new SqlCommand("delete from supplier where id='" + supp_id + "'", connection);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("تم الحذف");


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    connection.Close();
            //}

            //foreach (DataGridViewRow o in dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.Remove(o);
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection("Data Source=NANCY-TOSH;Initial Catalog=pharmacy;Integrated Security=True");
            //SqlCommand cmd;
            //if (supp_id != "")
            //{

            //        connection.Open();
            //        cmd = new SqlCommand("delete from supplier where id='" + supp_id + "'", connection);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("تم الحذف");
            //        connection.Close();
            //}

            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  supp_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           
        }
    }
}

