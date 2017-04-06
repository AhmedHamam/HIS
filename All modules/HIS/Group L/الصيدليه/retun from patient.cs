using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using HIS;
namespace HIS
{
    public partial class retun_from_patient : Form
    {
        public retun_from_patient()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.OpenConection();
            dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy__med_quantity");
        

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //SqlConnection connection = new SqlConnection("Data Source=NANCY-TOSH;Initial Catalog=pharmacy;Integrated Security=True");
            //SqlCommand cmd;
            //SqlDataReader dr;
            //connection.Open();
            //try
            //{

            //    cmd = new SqlCommand("select Sum(price * quantity) as totalprice from med_medicine ", connection);
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
        string med_id = "";

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();




            Connection conn = new Connection();
            conn.OpenConection();
            string xx = textBox1.Text;
            dataGridView1.DataSource = conn.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharmacy_update_medecineQuantity",
                new string[] { "@quantity","@med_id" }, new string[] { xx,med_id }, new SqlDbType[] { SqlDbType.Int, SqlDbType.Int });
   
            MessageBox.Show("تم الارتجاع");
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void retun_from_patient_Load(object sender, EventArgs e)
        {

        }
    }
}
