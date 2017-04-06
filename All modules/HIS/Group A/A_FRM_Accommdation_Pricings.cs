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
    public partial class A_FRM_Accommdation_Pricing : Form
    {
        public A_FRM_Accommdation_Pricing()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        public static string id="";
        public static string name="";
        private void A_FRM_Load(object sender, EventArgs e)
        {
            
        }

        private void C_Save_Click(object sender, EventArgs e)
        {
            DGV.EndEdit();
            //MessageBox.Show(DGV.CurrentCell.Value.ToString());
            DGV.RefreshEdit();
            if (check())
            {
                if (con.update(dt))
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

        private void DGV_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[3].Value = false;
        }

        private void DGV1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {                
           // DGV.Rows[DGV1.CurrentCell.RowIndex].Selected = true;
            }
            catch (Exception)
            {
                
                //throw;
            }
           // MessageBox.Show( DGV1.Rows[0].Cells[0].Value.ToString());
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DGV1.Rows[DGV.CurrentCell.RowIndex].Selected = true;
               // DGV.Rows[DGV1.CurrentCell.RowIndex].Selected = true;
            }
            catch (Exception)
            {

               // throw;
            }
        }


        private void btn_RP_Search_Click(object sender, EventArgs e)
        {
            A_FRM_Regulation_Prices frm = new A_FRM_Regulation_Prices();
            frm.C_Delete.Visible = false;
            frm.C_Add.Visible = false;
            frm.C_Save.Visible = false;
            frm.DGV.ReadOnly = true;
            frm.view = false;
            //frm.DGV.Columns[3].Visible = false;
            //frm.DGV.Columns[4].Visible = false;
            //frm.DGV.Columns[5].Visible = false;
            //frm.DGV.Columns[6].Visible = false;
            frm.ShowDialog();
            //this.txt_RP_id.Text = A_FRM_Regulation_Prices.id;
            //this.txt_RP_name.Text = A_FRM_Regulation_Prices.name;
            this.txt_RP_id.Text = frm.id;
            this.txt_RP_name.Text = frm.name;
        }

        private void txt_RP_id_TextChanged(object sender, EventArgs e)
        {
            con.OpenConection();
            dt = con.selectt("select * from tb_Accommodation_Pricing where AP_RP_id = " + Convert.ToInt16(txt_RP_id.Text) + ";", "tb_Accommodation_Pricing");
            ds1 = con.select("select AD_id,AD_Aname from tb_Accommodation_Degrees;", "tb_Accommodation_Dgree");
            // dt = ds.Tables[0];
            DGV.DataSource = dt;
            DGV1.DataSource = ds1.Tables[0];
            DGV1.Columns[0].ReadOnly = true;
            DGV1.Columns[1].ReadOnly = true;
            DGV1.Columns[0].HeaderText = "كود الاقامة";
            DGV1.Columns[1].HeaderText = "درجة الاقامة";

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].Visible = false;

            DGV.Columns[0].ReadOnly = true;
            DGV.Columns[1].ReadOnly = true;
            DGV.Columns[2].ReadOnly = true;
            DGV.Columns[0].HeaderText = "الكود";
            DGV.Columns[1].HeaderText = "كود الاقامة";
            DGV.Columns[2].HeaderText = "كود اللائحة";
            DGV.Columns[3].HeaderText = "إقامة المريض";
            DGV.Columns[4].HeaderText = "المرافق على كرسى ";
            DGV.Columns[5].HeaderText = "االمرافق على سرير";
            DGV.Columns[6].HeaderText = "المتابعة الطبية";
            //DGV.Columns[4].HeaderText = "طلب المطالبة";
            if (dt.Rows.Count < ds1.Tables[0].Rows.Count)
            {
                int n = dt.Rows.Count;
                int x = ds1.Tables[0].Rows.Count - dt.Rows.Count;
                for (int j = 0; j < x; j++)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    //int i = 1;
                    //if (DGV.Rows.Count > 1)
                    //{
                    //    i = (int)DGV.Rows[DGV.Rows.Count - 2].Cells[0].Value;
                    //    DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value = (i + 1);
                    //}
                    //else
                    //{
                    //    DGV.Rows[DGV.Rows.Count - 1].Cells[0].Value = (i);
                    //}

                    DGV.Rows[DGV.Rows.Count - 1].Cells[1].Value = DGV1.Rows[n + j].Cells[0].Value.ToString();
                    //MessageBox.Show(DGV1.Rows[DGV1.Rows.Count - 1].Cells[0].Value.ToString());
                    DGV.Rows[DGV.Rows.Count - 1].Cells[2].Value = txt_RP_id.Text;
                }

            }
        }

    }
}
