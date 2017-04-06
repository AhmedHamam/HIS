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
    public partial class الجهات11 : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
        //MySqlDataAdapter da;
         DataSet ds = new DataSet();
        //DataTable dt;
        //BindingSource bs;
        االغاء_تسجيل_مريض y=new االغاء_تسجيل_مريض();
       
      


        public الجهات11()
        {
            InitializeComponent();

        }
        public الجهات11(االغاء_تسجيل_مريض x)
        {
            InitializeComponent();
            y = x;

        }
      

        private void الجهات1_Load(object sender, EventArgs e)
        {
             //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");

           /* comboBox1.Items.Add("نقدى");
            comboBox1.Items.Add("تقصيد");*/
            con.OpenConection();

        }

   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            

        }

       /* public void  asd(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            
            string str = this.dataGridView1.Rows [e.RowIndex ].Cells [1].Value .ToString ();

            b.setValue4(str);
            this.Close();
           // البطاقة_العلاجية1 s = new البطاقة_العلاجية1(str);
            //s.Show();
           // MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void asd1(object sender, DataGridViewCellMouseEventArgs e)
        {

            string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int id = int.Parse(c);
            MessageBox.Show(id.ToString());
            string str = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            MessageBox.Show(str);
            try
            {
                y.setValue1(id, str);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            this.Close();
           // االغاء_تسجيل_مريض h = new االغاء_تسجيل_مريض(id, str);
           //h.Show();


          }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            con.OpenConection();
            if (textBox1.Text != "" || textBox3.Text != "")
            {
                string[] s = new string[] { "@x", "@y" };
                string[] s2 = new string[] { textBox1.Text, textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("display_entity1", s, s2, s3);

                //da = new MySqlDataAdapter("select * from tb_Types_of_Entities where diroctor_code='" + textBox1.Text + "' or name_diroctory='" + textBox3.Text + "'", con);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(ds);
                //bs = new BindingSource();
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = bs ;

            }
            else
            {
                dataGridView1.DataSource = null;
                ds.Tables.Clear();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("display_entity_all");
                //da = new MySqlDataAdapter("select * from diroctorys", con);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(ds);
                //bs = new BindingSource();
                //bs.DataSource = ds.Tables[0];
                //dataGridView1.DataSource =bs;

               
            }

            //con.CloseConnection();
           /* cmd = new MySqlCommand("select * from diroctorys", con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource=ds.Tables[0];*/

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }

        private void حذفToolStripMenuItem_Click_1(object sender, EventArgs e)
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

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_entity", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }

                    MessageBox.Show("تم الحذف بنجاح");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        
        
        }
        private void حفظToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                //bs.EndEdit();
                //da.Update(ds);
                //MessageBox.Show("succ");
                string[] pName = { "@x", "@y", "@z" ,"w"};

               
                string[] Pvalues = {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[2].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[4].Value.ToString()};


               // Boolean t1 = Convert.ToBoolean[dataGridView1.Rows.Count - 2].Cells[3].Value.ToString();
                //Boolean t2 = Convert.ToBoolean(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value.ToString());
                //MessageBox.Show(t2.ToString());
             
                SqlDbType[] Ptype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Bit, SqlDbType.Bit };

                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("entities_insert1", pName, Pvalues, Ptype);



                MessageBox.Show("نم حفظ البيانات");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox1.Text = null;
                return;
            }  

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(textBox3.Text, out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox3.Text = null;
                return;
            }
        }

       
        }
    }

