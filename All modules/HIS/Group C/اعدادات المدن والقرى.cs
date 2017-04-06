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
    public partial class اعدادات_المدن_والقرى : Form
    {
        Connection con =    new Connection();
      
        public اعدادات_المدن_والقرى()
        {
            InitializeComponent();
        }

        private void اعدادات_المدن_والقرى_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            DataTable dt = new DataTable();
            dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("contry_atribute");
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; ++i)
                comboBox1.Items.Add(dt.Rows[i][0].ToString());

            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");
            //con.Open();
            //cmd = new MySqlCommand("select county_name from country", con);
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{

            //    comboBox1.Items.Add(dr["county_name"]);

            //}
            //dr.Close();
            //con.Close();

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell Cell in dataGridView2.SelectedCells)
                {
                    if (Cell.Selected)
                    {


                        string[] pName = { "@code" };

                        string[] Pvalues = { dataGridView2.Rows[Cell.RowIndex].Cells[0].Value.ToString() };

                        SqlDbType[] Ptype = { SqlDbType.VarChar };

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_NickName", pName, Pvalues, Ptype);

                        dataGridView2.Rows.RemoveAt(Cell.RowIndex);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            DataTable dt = new DataTable();
            try
            {
                   string[] s = new string[] {"@name"};
                   string[] s2 = new string[] {comboBox1.Text};
                   SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar };
                   dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("setting_country_name", s, s2, s3);
         

                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
