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
    public partial class pop : Form
    {
        Connection conn = new Connection();
        public pop()
        {
            InitializeComponent();
        }
       
        string str1 = "";
        string str2 = "";
       
        public void showdi(ref string code,string query,string tit)
        {
            _title.Text = tit;
            
            conn.OpenConection();
            DataTable dt = new DataTable();
            SqlDataReader dr = conn.DataReader(query);
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.CloseConnection();

            this.ShowDialog();
            if (str1 != "")
            {
                code = str1;
                
            }
        }
        public void showdidi(ref string code, ref string name, string query, string tit)
        {
            _title.Text = tit;
            
            conn.OpenConection();
            DataTable dt = new DataTable();
            SqlDataReader dr = conn.DataReader(query);
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.CloseConnection();
            
            this.ShowDialog(); 
            if (str1 != "" && str2 != "")
            {
                code = str1;
                name = str2;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            string searchValue = "";
            int cellnum = 0;
            if (_code.Text != "")
            {
                cellnum = 0;
                searchValue = _code.Text;
            }
            else
            {
                searchValue = _Name.Text;
                cellnum = 1;
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[cellnum].Value.ToString().Contains(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                str1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                str2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
            this.Close();
        }

        private void _code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();

                tt.Show(" الرجاء ادخال أرقام", this, ((Control)sender).Location.X, ((Control)sender).Location.Y, VisibleTime);
            }



        }

        private void _Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();

                tt.Show(" الرجاء ادخال حروف", this, ((Control)sender).Location.X, ((Control)sender).Location.Y, VisibleTime);
            }
        }

    }
}
