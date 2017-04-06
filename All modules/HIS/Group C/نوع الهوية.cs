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
    public partial class نوع_الهوية : Form
    {
        Connection con = new Connection();
        public نوع_الهوية()
        {
            InitializeComponent();
        }

        private void نوع_الهوية_Load(object sender, EventArgs e)
        {
            try {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("se_identity");
            
            }
            catch (Exception ex) { ex.ToString(); }
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
                    {


                        string[] pName = { "@x" };

                        string[] Pvalues = { dataGridView1.Rows[Cell.RowIndex].Cells[0].Value.ToString() };

                        SqlDbType[] Ptype = { SqlDbType.VarChar };

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_identity", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }
                }
                MessageBox.Show("deleted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                string[] pName = new string[] { "@y" };

                string[] Pvalues = new string[] { dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value.ToString() };
                                 //  dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[1].Value.ToString() };
                                  
                                

                SqlDbType[] Ptype = new SqlDbType[]{ SqlDbType.VarChar };

                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("Add_identity_type2", pName, Pvalues, Ptype);



                MessageBox.Show("تم اضافة البيانات بنجاح");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
    }
}
