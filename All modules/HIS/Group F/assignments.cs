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
    public partial class assignments : Form
    {
        

        public assignments()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }


      
        

        private void بياناتالمتقدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applicantdata applicantdata = new applicantdata();
            applicantdata.MdiParent = this;
            applicantdata.Show();
        }

        private void المقابلةالشخصيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interview interview = new interview();
            interview.MdiParent = this;
            interview.Show();
        }

        private void مصوغاتالتعيينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employment_documents employment_documents = new employment_documents();
            employment_documents.MdiParent = this;
            employment_documents.Show();
        }

        private void تقريرالمقابلةالشخصيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportview reportview = new reportview();
            reportview.MdiParent = this;
            reportview.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     


    }
}
