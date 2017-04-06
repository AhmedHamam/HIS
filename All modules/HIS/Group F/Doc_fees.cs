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
    public partial class Doc_fees : Form
    {
       

        public Doc_fees()
        {
            InitializeComponent();
        }

        

        private void طلباتالعملياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            العمليات العمليات = new العمليات();
            العمليات.MdiParent = this;
            العمليات.Show();
        }

        private void مكافأةالعملياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void تقاريرالايرادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقاريرالايراد تقاريرالايراد = new تقاريرالايراد();
            تقاريرالايراد.MdiParent = this;
            تقاريرالايراد.Show();
        }

        private void اشعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void المعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }

        private void المناظيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            المناظير المناظير = new المناظير();
            المناظير.MdiParent = this;
            المناظير.Show();
        }

        private void عرضالبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form4 form4 = new Form4();
            form4.MdiParent = this;
            form4.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
