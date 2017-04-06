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
    public partial class التبرع_لمريض : Form
    {
        public التبرع_لمريض()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            تسجيل_بيانات_متبرع nw = new تسجيل_بيانات_متبرع();
            nw.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            المرضى nw = new المرضى();
            nw.Show();
        }

    }
}
