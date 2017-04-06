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
    public partial class Budgets : Form
    {
        

        public Budgets()
        {
            InitializeComponent();
        }

       

        private void الابوابToolStripMenuItem_Click(object sender, EventArgs e)
        {

            الابواب الابواب = new الابواب();
            الابواب.MdiParent = this;
            الابواب.Show();
        }

        private void البنودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البنود البنود = new البنود();
            البنود.MdiParent = this;
            البنود.Show();
        }

        private void دفاترالموازناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            دفترالموازنات دفترالموازنات = new دفترالموازنات();
            دفترالموازنات.MdiParent = this;
            دفترالموازنات.Show();
        }

        private void بيانالمستندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            بيانمستند بيانمستند = new بيانمستند();
            بيانمستند.MdiParent = this;
            بيانمستند.Show();
        }

        private void حصرالبنودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقريرلحصرالبنود تقريرلحصرالبنود = new تقريرلحصرالبنود();
            تقريرلحصرالبنود.MdiParent = this;
            تقريرلحصرالبنود.Show();
        }

        private void حصرالموازنةToolStripMenuItem_Click(object sender, EventArgs e)
        {

            تقريرلحصرالموازن تقريرلحصرالموازن = new تقريرلحصرالموازن();
            تقريرلحصرالموازن.MdiParent = this;
            تقريرلحصرالموازن.Show();
        }

        private void حصرالابوابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقريرلحصرالابواب تقريرلحصرالابواب = new تقريرلحصرالابواب();
            تقريرلحصرالابواب.MdiParent = this;
            تقريرلحصرالابواب.Show();
        }

        private void حصرالمستندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقريرلحصرالمستندات تقريرلحصرالمستندات = new تقريرلحصرالمستندات();
            تقريرلحصرالمستندات.MdiParent = this;
            تقريرلحصرالمستندات.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
