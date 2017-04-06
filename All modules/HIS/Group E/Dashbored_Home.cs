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
    public partial class Dashbored_Home : Form
    {
        int dcount = 0;
        int count = 0;
        int account = 0;
        public Dashbored_Home()
        {
            InitializeComponent();
        }

        private void داخلىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            occupation_rate f= new occupation_rate();
            f.WindowState=FormWindowState.Maximized;
            f.MdiParent=this;
            f.Show();
            
        }

        private void صيدليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            pharmacy f = new pharmacy();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void اشعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            radiology f = new radiology();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void عملياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            operation f = new operation();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void عددالمرضيجديدةالمتابعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (ActiveMdiChild != null)
            ActiveMdiChild.Close();

            newly f = new newly();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void عددالمرضيبالجنسياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            national f = new national();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void معملToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مكانالطلبللمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            lab_orderPlace f = new lab_orderPlace();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void اقسامالمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            lab_serviceName f = new lab_serviceName();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void خدماتالToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

             lab_serviceStatus f = new lab_serviceStatus();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void مطالباتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            customer_accounts f = new customer_accounts();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void سداداتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            payback_account f = new payback_account();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }

        private void مرفوضاتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            refused_account f = new refused_account();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
            
        }


       



 
    }
}
