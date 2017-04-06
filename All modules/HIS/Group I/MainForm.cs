using HIS;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm f = new OrdersForm();
            f.Show();

        }
        //الاعدادات الرئيسية
        private void button2_Click(object sender, EventArgs e)
        {

            main_setting m_setting = new main_setting();
            m_setting.Show();
        }
        //إدارة الملفات
        private void button1_Click(object sender, EventArgs e)
        {
             frm_manages_files frm = new frm_manages_files();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_scanner frm = new frm_scanner();
            frm.Show();
        }
    }

}