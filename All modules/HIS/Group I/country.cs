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
    public partial class country : Form
    {
        Connection con1 = new Connection();
       
        
        public country()
        {
           
            InitializeComponent();
        }

       
        //**************************************Display function*********************************************************
        public void dis_data()
        {
            con1.OpenConection();
            dataGridView1.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingcountry");
           
        }

        
        //***************************************************************************************************************
        private void country_Load(object sender, EventArgs e)
        {
            dis_data();
        }

       
        //**************************************الخروج*******************************************************************
        private void btn_exit_Click(object sender, EventArgs e)
        { 
            //خروج
            //parent.Show();
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                txteng_des.Text = dataGridView1.Rows[i].Cells["الاسم اللاتينى"].Value.ToString();
                txtarb_des.Text = dataGridView1.Rows[i].Cells["الاسم العربى"].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //*******************************************الاضافة*************************************************************
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con1.OpenConection();
               
                //****************** check empty fields*************************
                if ( txtarb_des.Text == "" ||txteng_des.Text=="")
                {
                    MessageBox.Show("بعض الحقول فارغة الرجاء اعادة المحاولة");
                    txteng_des.Text = "";
                    txtarb_des.Text = "";
                   
                }
                
                else
                {
                   
                    //**********************insert into database****************

                    string[] paramname = new string[] { "@param1", "@param2" };
                    string[] paramvalue = new string[] { txtarb_des.Text, txteng_des.Text };
                    SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                        con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addingcountry", paramname, paramvalue, paramtype);
                        txteng_des.Text = "";
                        txtarb_des.Text = "";
                        
                        dis_data();
                        MessageBox.Show("تمت الاضافة");  
                    
                }
            }

            catch (Exception ee) { MessageBox.Show(ee.Message); }
           
        }

        //**********************************************الحذف **********************************************************
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (txtarb_des.Text == "")
            { MessageBox.Show("من فضلك اختر الصف المراد حذفه ", "تنبيه"); }
            else
            {
                DialogResult dialogResult = MessageBox.Show("هل انت متأكد من الحذف ؟ ", "تنبيه ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string[] paramname = new string[] { "@param1" };
                    string[] paramvalue = new string[] { txtarb_des.Text };
                    SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                    con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("deletingcountry", paramname, paramvalue, paramtype);
                    
                    txtarb_des.Text = "";
                    txteng_des.Text = "";
                    dis_data();

                }
                if (dialogResult == DialogResult.No)
                {
                    dialogResult = DialogResult.Cancel;
                   
                    txtarb_des.Text = "";
                    txteng_des.Text = "";
                }

            }
          
        }

        //***************************************************البحث ******************************************************
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                con1.OpenConection();
                string[] paramname = new string[] { "@param1" };
                string[] paramvalue = new string[] { txtarb_des.Text };
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView1.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("searchforcountry", paramname, paramvalue, paramtype);
                txtarb_des.Text = "";

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
           
            
        }
        
        //******************************validate letters*****************************************************************
        private void txtarb_des_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                btn_add.Enabled = false;
                btn_del.Enabled = false;
                btn_search.Enabled = false;
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show(" الاسم العربى" + "يجـب ان يكون مكون من حروف فقط", txtarb_des, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btn_del.Enabled = true;
                btn_search.Enabled = true;
            }
        }
        //******************************validate letters*****************************************************************
        private void txteng_des_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                btn_add.Enabled = false;
                btn_del.Enabled = false;
                btn_search.Enabled = false;
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show(" الاسم اللاتينى يجـب ان يكون مكون من حروف فقط ",txteng_des, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btn_del.Enabled = true;
                btn_search.Enabled = true;
            }
        }
    }
}
