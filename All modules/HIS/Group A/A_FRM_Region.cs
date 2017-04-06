using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class A_FRM_Region : Form
    {
        public A_FRM_Region()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static string id="";
        public static string name="";
        public bool view = true;
        private void A_FRM_Load(object sender, EventArgs e)
        {
            try
            {
                if (view)
                {
                    con.OpenConection();
                    ds = con.select("select * from tb_Region ;", "tb_Region");

                    dt = ds.Tables[0];
                    DGV.DataSource = dt;
                    C_Ok.Visible = false;
                    DGV.Columns[0].Width = 70;
                    DGV.Columns[0].ReadOnly = true;
                    DGV.Columns[0].HeaderText = "الكود";
                    DGV.Columns[1].HeaderText = "الاسم العربى ";
                    DGV.Columns[2].HeaderText = "الاسم اللاتينى";
                }
                else
                {
                    con.OpenConection();
                    ds = con.select("select * from tb_Region ;", "tb_Region");

                    dt = ds.Tables[0];
                    DGV.DataSource = dt;

                    DGV.ReadOnly = true;
                    DGV.Columns[0].HeaderText = "الكود";
                    DGV.Columns[0].Width = 70;
                    DGV.Columns[1].HeaderText = "الاسم العربى ";
                    DGV.Columns[2].HeaderText = "الاسم اللاتينى";
                    C_Add.Visible = false;
                    C_Save.Visible = false;
                    C_Delete.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void C_Save_Click(object sender, EventArgs e)
        {
            DGV.EndEdit();
            //MessageBox.Show(DGV.CurrentCell.Value.ToString());
            DGV.RefreshEdit();
            if (check())
            {
                if (con.update(ds, "tb_Region"))
                {
                    MessageBox.Show("Updated");
                     this.A_FRM_Load(sender, e);
                }
            }
        }
        private bool check()
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (DGV.Rows[i].Cells[1].Value.ToString() == "" || DGV.Rows[i].Cells[2].Value.ToString() == "")
                {
                    MessageBox.Show("ادخل البيانات الناقصة");
                    return false;
                }              
            }
           
            return true;
        }
        private void C_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DGV.SelectedRows.Count > 0)
                {
                    DGV.Rows.RemoveAt(this.DGV.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void C_Add_Click(object sender, EventArgs e)
        {
            try
            {                
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                int i = 1;
                if (DGV.Rows.Count > 1)
                {
                    i = (int)DGV.Rows[DGV.Rows.Count - 2].Cells[0].Value;
                    DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value = (i + 1);
                }
                else
                {
                    DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value = (i);
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void C_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_Ok_Click(object sender, EventArgs e)
        {
            id = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            name = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
            this.Close();
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            C_Ok_Click(sender,e);
        }

      
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DGV.CurrentCell.ColumnIndex == 1 || DGV.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void DGV_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[3].Value = false;
        }

        private void DGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!view)
                {
                    C_Ok_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}

