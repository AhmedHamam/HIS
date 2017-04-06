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
    public partial class النظام_الغذائى : Form
    {

        Connection con = new Connection();
        //MySqlDataAdapter da;
        //DataSet ds = new DataSet();
        //MySqlCommand cmd;
        //MySqlConnection con;
        DataTable dt;
        BindingSource bs;
        public النظام_الغذائى()
        {
            InitializeComponent();
        }

        private void النظام_الغذائى_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");

            con.OpenConection();

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string[] pName = new string[] { "@id", "@x", "@y", "@z", "@w" };

                string[] Pvalues = new string[] {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[0].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[2].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[4].Value.ToString()};



                SqlDbType[] Ptype = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_feed_kicken", pName, Pvalues, Ptype);



                MessageBox.Show("تم اضافة البيانات بنجاح");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

          
            
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewCell Cell in dataGridView1.SelectedCells)
                {
                    if (Cell.Selected)
                    {


                        string[] pName = { "@x" };

                        string[] Pvalues = { dataGridView1.Rows[Cell.RowIndex].Cells[0].Value.ToString() };

                        SqlDbType[] Ptype = { SqlDbType.VarChar };

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_feed", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }
                }
                MessageBox.Show("deleted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {




            dataGridView1.DataSource = null;
           // ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
           // da = new MySqlDataAdapter();
            dt = new DataTable();
            if (textBox2.Text != "" || textBox1.Text != "")
            {

                try
                {

                    string[] a = new string[] { "@code", "@name" };
                    string[] a2 = new string[] { textBox1.Text, textBox2.Text };
                    SqlDbType[] a3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar};
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("feeed2", a, a2, a3);
                    //cmd = new MySqlCommand("select * from Feed_kitchen where  meal_id=@code or meal_name=@name;", con);
                    //cmd.Parameters.AddWithValue("@code", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    //da.SelectCommand = cmd;

                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    //con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                try
                {
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("feeeed");
                    //cmd = new MySqlCommand("select * from Feed_kitchen", con);
                    //da = new MySqlDataAdapter(cmd);

                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);
                    //bs = new BindingSource();
                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;
                    //con.Close();


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم  ");
                textBox1.Text = null;
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int x;
           
            if (int.TryParse(textBox2.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم  ");
                textBox2.Text = null;
                return;
            }

        }
    }
}
