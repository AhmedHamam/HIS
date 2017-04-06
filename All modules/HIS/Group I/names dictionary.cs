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
    public partial class names_dictionary : Form
    {
        Connection con1 = new Connection();
        
        public names_dictionary()
        {
            
            InitializeComponent();
        }

        //**************************************Display function*********************************************************
        public void dis_data()
        {
            con1.OpenConection();
            dataGridView2.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("viewingdectionarynames");

        }
        //**************************************الاضافــة**************************************************************
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con1.OpenConection();


                //****************** check empty fields*************************
                if (txt_ardes.Text == "" || txt_endes.Text == "")
                {
                    MessageBox.Show("بعض الحقول فارغة الرجاء اعادة المحاولة");
                    txt_ardes.Text = "";
                    txt_endes.Text = "";
                }
                else
                {


                    //**********************insert into database****************

                    string[] paramname = new string[] { "@param1", "@param2", "@param3" };
                    string[] paramvalue = new string[] { txt_ardes.Text, txt_endes.Text, cb_gendar.Text };
                    SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                    con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addingdectionaryname", paramname, paramvalue, paramtype);

                    txt_ardes.Text = "";
                    txt_endes.Text = "";
                    cb_gendar.Text = "   ";
                    dis_data();
                    MessageBox.Show("تمت الاضافة");

                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }

        }

        //**********************************************الحذف **********************************************************
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txt_ardes.Text == "")
            { MessageBox.Show("من فضلك اختر الصف المراد حذفه ", "تنبيه"); }
            else
            {
                DialogResult dialogResult = MessageBox.Show("هل انت متأكد من الحذف ؟ ", "تنبيه ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    string[] paramname = new string[] { "@param1" };
                    string[] paramvalue = new string[] { txt_ardes.Text };
                    SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                    con1.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("deletingdectionarynames", paramname, paramvalue, paramtype);
                
                    txt_ardes.Text = "";
                    txt_endes.Text = "";

                    dis_data();

                }
                if (dialogResult == DialogResult.No)
                {
                    dialogResult = DialogResult.Cancel;
                    
                    txt_ardes.Text = "";
                    txt_endes.Text = "";
                }

            }

        }
        //***************************************************************************************************************
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            int i = dataGridView2.CurrentCell.RowIndex;
            txt_endes.Text = dataGridView2.Rows[i].Cells["الاسم اللاتينى"].Value.ToString();
            txt_ardes.Text = dataGridView2.Rows[i].Cells["الاسم العربى"].Value.ToString();
        }
        //***************************************************************************************************************
        private void names_dictionary_Load(object sender, EventArgs e)
        {
            dis_data();
        }
        //**********************************************البحث **********************************************************
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                con1.OpenConection();
                string[] paramname = new string[] { "@param1" };
                string[] paramvalue = new string[] { txt_name.Text };
                SqlDbType[] paramtype = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView2.DataSource = (DataTable)con1.ShowDataInGridViewUsingStoredProc("searchdectionaryname1", paramname, paramvalue, paramtype);
                txt_name.Text = "";

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }

        }
        //**********************************************الخروج **********************************************************
        private void btn_exit_Click(object sender, EventArgs e)
        {
            //perant.Show();
            this.Close();
        }
        //******************************validate letters*****************************************************************
        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                btn_add.Enabled = false;
                btndelete.Enabled = false;
                btn_search.Enabled = false;
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show(" الاسم يجـب ان يكون مكون من حروف فقط", txt_name, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btndelete.Enabled = true;
                btn_search.Enabled = true;
            }
        }
        //******************************validate letters*****************************************************************
        private void txt_ardes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                btn_add.Enabled = false;
                btndelete.Enabled = false;
                btn_search.Enabled = false;
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show("  الاسم العربى يجـب ان يكون مكون من حروف فقط", txt_ardes, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btndelete.Enabled = true;
                btn_search.Enabled = true;
            }
        }
        //******************************validate letters*****************************************************************
        private void txt_endes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                btn_add.Enabled = false;
                btndelete.Enabled = false;
                btn_search.Enabled = false;
                int visabletime = 1000;
                ToolTip t1 = new ToolTip();
                t1.Show(" الاسم اللاتينى يجـب ان يكون مكون من حروف فقط", txt_endes, 0, 0, visabletime);
                e.Handled = true;
            }
            else
            {
                btn_add.Enabled = true;
                btndelete.Enabled = true;
                btn_search.Enabled = true;
            }

        }

      
    }
    
}