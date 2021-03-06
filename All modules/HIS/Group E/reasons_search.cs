﻿using System;
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
    public partial class reasons_search : Form
    {
        int selectedrow;
         Connection sqlCon = new Connection();
        public reasons_search()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.OpenConection();

                String[] a = { "@t", "@c", "@ar", "@la", "@flag" };
                String[] b = { "asset_re_evaluation_reasons", "0", textBox2.Text, textBox3.Text, "0" };
                if (textBox1.Text != "")
                {
                    b[4] = "1";
                    b[1] = textBox1.Text;
                }
                SqlDbType[] c = { SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                dataGridView1.DataSource = sqlCon.ShowDataInGridViewUsingStoredProc("search_conditional1", a, b, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlCon.CloseConnection(); }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                sqlCon.OpenConection();

                String[] a = { "@t", "@c" };
                String[] b = { "asset_re_evaluation_reasons", dataGridView1.Rows[selectedrow].Cells[0].Value.ToString() };

                SqlDbType[] c = { SqlDbType.NVarChar, SqlDbType.Int };
                dataGridView1.Rows.RemoveAt(selectedrow);
                sqlCon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_conditional", a, b, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlCon.CloseConnection(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrow = e.RowIndex;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            asset_reevaluation x = new asset_reevaluation(this);
            x.Show();
        }


        private void reasons_search_Load(object sender, EventArgs e)
        {

        }

    }
}
