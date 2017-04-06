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
    public partial class فئة_المريض : Form
    {
        Connection con = new Connection();
        DataSet ds = new DataSet();
        BindingSource bs=new BindingSource();
        االغاء_تسجيل_مريض y;

        public فئة_المريض()
        {
            InitializeComponent();
        }

        public فئة_المريض(االغاء_تسجيل_مريض x)
        {

            InitializeComponent();
            y = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                dataGridView1.DataSource = null;
                ds.Tables.Clear();
                dataGridView1.Refresh();
                dataGridView1.Rows.Clear();
                if (textBox1.Text != "" || textBox2.Text != "")
                {


                    string[] s = new string[] { "@x", "@y" };
                    string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("display_entities", s, s2, s3);


                    //cmd = new MySqlCommand("select * from catogricals where catog_code =@x or name=@y;", con);
                    //cmd.Parameters.AddWithValue("@x", textBox2.Text);
                    //cmd.Parameters.AddWithValue("@y", textBox1.Text);
                    //da = new MySqlDataAdapter(cmd);
                    //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    //da.Fill(ds);

                    //bs.DataSource = ds.Tables[0];
                    //dataGridView1.DataSource = bs;


                    // dataGridView1.DataSource = ds.Tables[0];

                }
                else
                {

                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("dispaly_categorical1");

                    /*cmd = new MySqlCommand("select * from catogricals;", con);
                    da = new MySqlDataAdapter(cmd);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    da.Fill(ds);
                    bs = new BindingSource();

                    bs.DataSource = ds.Tables[0];

                    dataGridView1.DataSource = bs;*/

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

        private void فئة_المريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

  

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell Cell in dataGridView1.SelectedCells)
                {
                    if (Cell.Selected)
                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                }
                MessageBox.Show("deleted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

      

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try

            {
                bs.EndEdit();
               // da.Update(ds);
                MessageBox.Show("updated");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void asd(object sender, DataGridViewCellMouseEventArgs e)
        {
            string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int id = int.Parse(c);
          //  MessageBox.Show(id.ToString());
            string str = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            MessageBox.Show(str);
           // y.setValue(id, str);

            this.Close();
            //االغاء_تسجيل_مريض h = new االغاء_تسجيل_مريض(id, str);
           // h.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox1.Text = null;
                return;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخالاسم المريض ");
                textBox1.Text = null;
                return;
            }

        }
    }
}
