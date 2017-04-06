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
    public partial class frm_backup : Form
    {
        SqlConnection con = new SqlConnection(@"server=(localdb)\projects ;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        public frm_backup()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            { txt_find_name.Text = folderBrowserDialog1.SelectedPath; }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txt_find_name.Text == "")
            { MessageBox.Show("رجاء اختر المكان اولا", "خطأ"); }
            else
            {
                try
                {
                    //مع استبدال الداش بشئ اخر مقبول 
                    string fileName = txt_find_name.Text + "\\PHIS" + DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + DateTime.Now.ToLongTimeString().Replace(':', '-');
                    string strQuery = "Backup database PHIS to disk ='" + fileName + ".bak'";
                    cmd = new SqlCommand(strQuery, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم انشاء النسخة الاحتياطية بنجاح ", "إنشاء نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
