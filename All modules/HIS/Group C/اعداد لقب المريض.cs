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
    public partial class اعداد_لقب_المريض : Form
    {
        Connection con = new Connection();
        //MySqlConnection con;
      
       // MySqlDataAdapter da;
       // MySqlDataReader dr;
        DataSet ds;
        DataTable dt=new DataTable();
        BindingSource bs;

        public اعداد_لقب_المريض()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void اعداد_لقب_المريض_Load(object sender, EventArgs e)
        {


            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("setting_Of_nickname");
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
                        

                        string[] pName = { "@code" };

                        string[] Pvalues = { dataGridView1.Rows[Cell.RowIndex].Cells[0].Value.ToString() };

                        SqlDbType[] Ptype = { SqlDbType.VarChar };

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_NickName", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }
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
               //dataGridView1.Rows[dataGridView1.Rows.Count-1]
                
                string[] pName =  {"@arabic_description","@english_description","@gender"};

                string[] Pvalues = {dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[2].Value.ToString(),
                                  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString()};

                SqlDbType[] Ptype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_NickName", pName, Pvalues, Ptype);



                MessageBox.Show("updated");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
