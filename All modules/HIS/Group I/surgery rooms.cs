using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class surgery_rooms : Form
    {
        Connection con1 = new Connection();
        
      
        public surgery_rooms()
        {
            //perant = p;
            InitializeComponent();
        }

        //**************************************الخروج******************************************************************
        private void btn_exit_Click(object sender, EventArgs e)
        {
           // perant.Show();
            this.Close();
        }
        //**************************************Display function*********************************************************
        public void dis_data()
        {
            con1.OpenConection();
            dataGridView1.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingbuilding");
            dataGridView2.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingunit");
            dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingclinc");
        }
        //****************************************************************************************************************
        private void surgery_rooms_Load(object sender, EventArgs e)
        {
          dis_data();
        }
        //****************************************************************************************************************
        void surgery_table ()
        {

          try
            {
                con1.OpenConection();
                dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewinsurgery");
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
          
        }
        //***************************************************************************************************************
        void glass_table()
        {
         try
         {
            con1.OpenConection();
            dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewinglass");
           
         }
          catch (Exception ee)
          {
            MessageBox.Show(ee.Message);
          }
      
        }
        //***************************************************************************************************************
        void clinc_table()
        {

         try
        {
            con1.OpenConection();
            dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingclinc");

        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
        }

    }
   

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         try
          {
            int indx = dataGridView2.CurrentCell.RowIndex;
            switch (indx)
            {
              case 0:
                glass_table();
                break;
              case 1:
                surgery_table();
                break;
              case 2:
                clinc_table();
                break;
            }
          }
          catch (Exception ee)
          {
            MessageBox.Show(ee.Message);
          }
    
    }
    //*******************************************************************************************************************
    private void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            con1.OpenConection();
            if (dataGridView2.CurrentCell.RowIndex == 0)
            {

                string[] paramname = new string[] { "@param1", "@param2", "@param3", "@param4" };
                string[] paramvalue = new string[] { txtId.Text, txtarb_des.Text, txteng_des.Text, txt_Idunit.Text };
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addingglass", paramname, paramvalue, paramtype);
                txtId.Text = "";
                txtarb_des.Text = "";
                txteng_des.Text = "";
                txt_Idunit.Text = "";
                glass_table();
            }
            else if (dataGridView2.CurrentCell.RowIndex == 1)
            {
                string[] paramname = new string[] { "@param1", "@param2", "@param3", "@param4" };
                string[] paramvalue = new string[] { txtId.Text, txtarb_des.Text, txteng_des.Text, txt_Idunit.Text };
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addingsurgery", paramname, paramvalue, paramtype);
                txtId.Text = "";
                txtarb_des.Text = "";
                txteng_des.Text = "";
                txt_Idunit.Text = "";
                surgery_table();
            }
            else
            {
                string[] paramname = new string[] { "@param1", "@param2", "@param3", "@param4" };
                string[] paramvalue = new string[] { txtId.Text, txtarb_des.Text, txteng_des.Text, txt_Idunit.Text };
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addingouterclinic", paramname, paramvalue, paramtype);
                txtId.Text = "";
                txtarb_des.Text = "";
                txteng_des.Text = "";
                txt_Idunit.Text = "";
                clinc_table();
            }

        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
        }
    }
    //******************************************الحذف******************************************************************* 
    private void btn_delete_Click(object sender, EventArgs e)
    {
        try
        {
            con1.OpenConection();
            if (txtarb_des.Text == "")
            { MessageBox.Show("من فضلك اختر الصف المراد حذفه ", "تنبيه"); }
            else
            {
                DialogResult dialogResult = MessageBox.Show("هل انت متأكد من الحذف ؟ ", "تنبيه ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dataGridView2.CurrentCell.RowIndex == 0)
                    {
                        string[] paramname = new string[] { "@param1" };
                        string[] paramvalue = new string[] { txtarb_des.Text };
                        SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                        con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("deletinglass", paramname, paramvalue, paramtype);
                        txtarb_des.Text = "";
                        glass_table();
                    }


                    else if (dataGridView2.CurrentCell.RowIndex == 1)
                    {
                        string[] paramname = new string[] { "@param1" };
                        string[] paramvalue = new string[] { txtarb_des.Text };
                        SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                        con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("deletingsurgary", paramname, paramvalue, paramtype);
                        txtarb_des.Text = "";
                        surgery_table();
                    }
                    else
                    {
                        string[] paramname = new string[] { "@name" };
                        string[] paramvalue = new string[] { txtarb_des.Text };
                        SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                        con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delclinc", paramname, paramvalue, paramtype);
                        txtarb_des.Text = "";
                        clinc_table();
                    }
                }
                if (dialogResult == DialogResult.No)
                {
                    dialogResult = DialogResult.Cancel;
                    txtarb_des.Text = "";
                }


            }
        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
        }
    }
    //***********************************البحث *************************************************************************
    private void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
         con1.OpenConection();
            if (dataGridView2.CurrentCell.RowIndex == 0)
            {

                string[] paramname = new string[] { "@pname" };
                string[] paramvalue = new string[] { txt_search.Text};
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("searchforglass", paramname, paramvalue, paramtype);
                txt_search.Text = "";
            }
            else if (dataGridView2.CurrentCell.RowIndex == 1)
            {
                string[] paramname = new string[] { "@pname" };
                string[] paramvalue = new string[] { txt_search.Text};
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar};
                dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("searchforsergry", paramname, paramvalue, paramtype);
                txt_search.Text = "";
            }
            else 
            {
                 string[] paramname = new string[] { "@pname" };
                string[] paramvalue = new string[] { txt_search.Text};
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar};
                dataGridView3.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("searchforclinic", paramname, paramvalue, paramtype);
                txt_search.Text = "";
            }

        }
    
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
        }
}
    //******************************validate numbers*****************************************************************
    private void txtId_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                btn_add.Enabled = false;
                btn_delete.Enabled = false;
                
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show("الكود يجـب ان يكون رقم", txtId, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btn_delete.Enabled = true;
               
            }
    }
    //******************************validate letters*****************************************************************
    private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
    {

        if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&& !char.IsSeparator(e.KeyChar))
        {

            btn_search.Enabled = false;
            int visabletime = 1000;
            ToolTip t1 = new ToolTip();
            t1.Show("البحث بالاسم يجـب ان يكون مكون من حروف فقط", txt_search, 0, 0, visabletime);
            e.Handled = true;
        }
        else
        {

            btn_search.Enabled = true;
        }
    }
    //******************************validate letters*****************************************************************
    private void txtarb_des_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
        {
            btn_add.Enabled = false;
            btn_delete.Enabled = false;

            int visabletime = 1000;
            ToolTip t1 = new ToolTip();
            t1.Show(" الاسم العربى يجـب ان يكون مكون من حروف فقط", txtarb_des, 0, 0, visabletime);
            e.Handled = true;
        }
        else
        {
            btn_add.Enabled = true;
            btn_delete.Enabled = true;

        }
    }
    //******************************validate letters*****************************************************************
    private void txteng_des_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
        {
            btn_add.Enabled = false;
            btn_delete.Enabled = false;

            int visabletime = 1000;
            ToolTip t1 = new ToolTip();
            t1.Show(" الاسم اللاتينى  يجـب ان يكون مكون من حروف فقط", txteng_des, 0, 0, visabletime);
            e.Handled = true;
        }
        else
        {
            btn_add.Enabled = true;
            btn_delete.Enabled = true;

        }
    }

    private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
    {
        int i = dataGridView3.CurrentCell.RowIndex;

        txtarb_des.Text = dataGridView3.Rows[i].Cells["الاسم العربى"].Value.ToString();
    }

    private void lbId_TextChanged(object sender, EventArgs e)
    {
       
    }

   


    }
}
