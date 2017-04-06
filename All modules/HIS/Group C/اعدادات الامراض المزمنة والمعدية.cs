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
    public partial class اعدادات_الامراض_المزمنة_والمعدية : Form
    {
        Connection con = new Connection();
         
        public اعدادات_الامراض_المزمنة_والمعدية()
        {
            InitializeComponent();
        }

        private void اعدادات_الامراض_المزمنة_والمعدية_Load(object sender, EventArgs e)
        {
          
            con.OpenConection();

            dataGridView1.DataSource=(DataTable)con.ShowDataInGridViewUsingStoredProc("setting_diseases");
            //cmd = new MySqlCommand("select * from Registeration_settingOfChronicAndContagiousdiseases", con);
           
            //dr = cmd.ExecuteReader();
           
            //dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //da = new MySqlDataAdapter(cmd);
            //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
           
        }
        TextBox tex;
        private void button2_Click(object sender, EventArgs e)
        {
      
           
            for (int i = 0; i < 1; i++)
            {
                tex = new TextBox();
                tex.Location = new Point(richTextBox1.Location.X, richTextBox1.Location.Y+30);
                tex.Size = new Size(tex.Width+670,100);
                this.Controls.Add(tex);
            }
   
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

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_row_diseases", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }
                }
                MessageBox.Show("deleted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tex.Hide();
        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try{
                string[] pName =new string [] { "@x", "@x1", "@x2","@x3" };

                string[] Pvalues = new string[]  {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[2].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString(),
                                   dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[4].Value.ToString() };

                SqlDbType[] Ptype = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_disease", pName, Pvalues, Ptype);



                MessageBox.Show("تم اضافة البيانات بنجاح");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            
        }

    }
    }
