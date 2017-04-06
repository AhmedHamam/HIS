using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class salaries : Form
    {
     

        public salaries()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bonusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bonuses bonuses = new bonuses();
            bonuses.MdiParent = this;
            bonuses.Show();
        }

        private void incentivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            incentives incentives = new incentives();
            incentives.MdiParent = this;
            incentives.Show();

        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deductions deductions = new deductions();
            deductions.MdiParent = this;
            deductions.Show();
        }

        private void penalitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            penalities penalities = new penalities();
            penalities.MdiParent = this;
            penalities.Show();
        }

        private void totalsalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            totalsalary totalsalary = new totalsalary();
            totalsalary.MdiParent = this;
            totalsalary.Show();
        }



        private void مفرداتالمرتبToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showtotalsalary showtotalsalary = new showtotalsalary();
            showtotalsalary.MdiParent = this;
            showtotalsalary.Show();
        }

        private void تقاريرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            financial_rep financial_rep = new financial_rep();
            financial_rep.MdiParent = this;
            financial_rep.Show();
        }

      

      

      

     


    
  

     


      
    }
}
