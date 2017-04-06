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
    public partial class A_FRM_Entities_Branchs : Form
    {
        public A_FRM_Entities_Branchs()
        {
            InitializeComponent();
        }


        Connection con = new Connection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        private void A_FRM_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                ds = con.select("select CE_Id,CE_AName from tb_Contracting_Entities ;", "tb_Contracting_Entities");

                DGV1.DataSource = ds.Tables[0];

                DGV1.ReadOnly = true;
                DGV1.Columns[0].Visible = false;
                DGV1.Columns[0].HeaderText = "الكود";
                DGV1.Columns[1].HeaderText = "الاسم العربى ";
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
                 if (con.update(ds1, "tb_Entities_Branches"))
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
                 string ce = DGV1.Rows[DGV1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                 DataRow dr = dt.NewRow();
                 dt.Rows.Add(dr);

                 DGV.Rows[DGV.Rows.Count - 1].Cells[2].Value = ce;
                // DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value = dt.Rows.Count;
                 
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

      

         private void DGV1_SelectionChanged(object sender, EventArgs e)
         {
             try
             {
                 string ce = DGV1.Rows[DGV1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                  ds1 = con.select("select * from tb_Entities_Branches where EB_CE_id= "+ ce +" ;", "tb_Entities_Branches");
                 dt=ds1.Tables[0];
                 DGV.DataSource = dt;

                 DGV.Columns[0].ReadOnly = true;
                 DGV.Columns[2].Visible = false;
                 DGV.Columns[0].HeaderText = "الكود";
                 DGV.Columns[0].Width = 70;
                 DGV.Columns[1].HeaderText = "الاسم العربى ";
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
                 //throw;
             }
         }

     }
 }
 
