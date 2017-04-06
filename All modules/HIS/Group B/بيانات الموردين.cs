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
    public partial class For14 : Form
    {
        Connection con = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=KERMENA\SQLEXPRESS;Database=PHIS;integrated security=true");
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        For11 c;
        public For14()
        {
            InitializeComponent();
        }
         public For14(For11 f6)
        {
            InitializeComponent();
            c= f6;
        }
        private void Form14_Load(object sender, EventArgs e)
         {
             try
             {
                 con.OpenConection();

                 dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("showsupplier");
             }
             
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.CloseConnection(); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // f13 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c.setV(row.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
