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
    public partial class فئة_المريض_1 : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataAdapter da = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        تسجيل_بيانات__مريض  y=new تسجيل_بيانات__مريض();
        public static int Code { get; set; }
        public static int Code2 { get; set; }




        public فئة_المريض_1()
        {
            InitializeComponent();
        }

        public فئة_المريض_1(تسجيل_بيانات__مريض x)
        {
            InitializeComponent();
            y = x;
        }

        private void فئة_المريض_1_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
            con.OpenConection();

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


                    string[] s = new string[] { "@x","@y"};
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
               // bs.EndEdit();
               // da.Update(ds);
                MessageBox.Show("updated");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



           
        }

       private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
       {
           try
           {
               Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               Code2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

               تسجيل_بيانات__مريض ff = new تسجيل_بيانات__مريض();
              // تقرير1 f = new تقرير1();
              // f.Focus();
               ff.Focus();
               this.DialogResult = DialogResult.OK;

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message + " dfff");
           }
       }

       private void textBox2_TextChanged(object sender, EventArgs e)
       {
           int x;
           if (!int.TryParse(textBox2.Text, out x))
           {


               MessageBox.Show("قم بادخال رقم ");
               textBox2.Text = null;
               return;
           }

       }

       private void textBox1_TextChanged(object sender, EventArgs e)
       {
           int x;
           if (int.TryParse(textBox1.Text, out x))
           {


               MessageBox.Show("قم بادخال اسم المريض ");
               textBox1.Text = null;
               return;
           }

       }
       /* private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }*/
    }
}
