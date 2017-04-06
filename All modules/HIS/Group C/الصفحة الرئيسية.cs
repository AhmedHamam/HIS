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
    public partial class الصفحة_الرئيسية : Form
    {
        public الصفحة_الرئيسية()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            تسجيل_بيانات__مريض d = new تسجيل_بيانات__مريض();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مررريض d = new محرك_البحث_عن_مررريض();
            d.Show();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void الصفحة_الرئيسية_Load(object sender, EventArgs e)
        {

        }
    }
}
