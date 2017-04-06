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
    public partial class frm_restore : Form
    {
       //ربط الاتصال مع قاعدة البياناالرئيسية لانه اذا لم توجد قاعدة البيانات علي السيرفر سوف يحدث مشكلة 
        ////علي فرض ان قاعدة البيانات محذوف علي السيرفر
        SqlConnection con = new SqlConnection(@"server=(localdb)\projects ;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd;
    
        public frm_restore()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txt_find_name.Text == "")
            { MessageBox.Show("رجاء اختر الملف اولا", "خطأ ");
            btn_browse.Focus();
            }
            else
            {
                try
                { 
                    //نقوم اولا ب اغلاق اتصال بقاعدة البيانات اولا لانه سوف يحدث مشكلة عند عمل استعادة النسخة الاحتياطية 
                    // اذا كانت قاعدة البيانات قيد الاستعمال فانه لا يمكن استعادة البيانات 
                    string strQuery = " ALTER DATABASE PHIS SET OFFLINE WITH ROLLBACK IMMEDIATE ;Restore database PHIS from Disk ='" + txt_find_name.Text + "'";
                    cmd = new SqlCommand(strQuery, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم إستعادة النسخة الاحتياطية بنجاح ", "إستعادة نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { txt_find_name.Text = openFileDialog1.FileName; }
        }
    }
}
