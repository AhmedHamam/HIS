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
    public partial class انواع_الحوادث : Form
    {
        //   MySqlDataAdapter da;
        // DataSet ds = new DataSet();
        // MySqlCommand cmd;
        // MySqlConnection con;
        //DataTable  dt;
        //BindingSource bs;

        Connection con = new Connection();
        public انواع_الحوادث()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void انواع_الحوادث_Load(object sender, EventArgs e)
        {





            con.OpenConection();
            try
            {

                // bs.EndEdit();
                //dataGridView1.Rows[dataGridView1.Rows.Count-1]

                //string[] pName =  {"@arabic_description","@english_description","@gender"};

                //string[] Pvalues = {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString(),
                //                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[2].Value.ToString(),
                //                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString()};

                //SqlDbType[] Ptype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };



                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("rewrite_accident1");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           // con.CloseConnection();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


            // string s = "select acc_arabic_name as 'الاسم بالعربيه',acc_English_name as 'الاسم بالانجليزيه' from emergency_accident_kinds;";
            //// con = new MySqlConnection("server=localhost;uid=root;password=root;database=emergency");

            // con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

            // dataGridView1.DataSource = null;
            // ds.Tables.Clear();
            // dataGridView1.Refresh();
            // dataGridView1.Rows.Clear();
            // da = new MySqlDataAdapter();
            // dt = new DataTable();

            //     try
            //     {
            //         cmd = new MySqlCommand(s, con);
            //        // cmd.Parameters.AddWithValue("@code", textBox1.Text);
            //         //cmd.Parameters.AddWithValue("@name", textBox2.Text);
            //         da.SelectCommand = cmd;

            //         MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            //         da.Fill(ds);
            //         bs = new BindingSource();
            //         bs.DataSource = ds.Tables[0];
            //         dataGridView1.DataSource = bs;
            //         con.Close();

            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show(ex.Message);
            //     }


        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    try
        //    {
                //bs.EndEdit();

                //da.Update(ds);
                //MessageBox.Show("udated");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           // con.OpenConection();
            string[] pName = { "@arName","@enname" };

            string[] Pvalues = {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[0].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString()};

            SqlDbType[] Ptype = { SqlDbType.VarChar, SqlDbType.VarChar};

            if (-1 == con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc2("rewrite_accident2", pName, Pvalues, Ptype))
            {
                MessageBox.Show("does not update");
                return;
            }
            MessageBox.Show("updated");
            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


