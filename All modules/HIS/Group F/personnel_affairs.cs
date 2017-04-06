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
    public partial class personnel_affairs : Form
    {
      

        public personnel_affairs()
        {
            InitializeComponent();
        }

        private void اضافةموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addEmployee addEmployee = new addEmployee();
            addEmployee.MdiParent = this;
            addEmployee.Show();
        }

        private void الدوراتالتدريبيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            training training = new training();
            training.MdiParent = this;
            training.Show();
        }

        private void تقييمالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeEvaluation employeevaluation = new employeeEvaluation();
            employeevaluation.MdiParent = this;
            employeevaluation.Show();
        }

        private void اضافةقسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            departments departments = new departments();
            departments.MdiParent = this;
            departments.Show();
        }

        private void المعلوماتالشخصيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emplpersonalInfo emplpersonalinfo = new emplpersonalInfo();
            emplpersonalinfo.MdiParent = this;
            emplpersonalinfo.Show();
        }

        private void الموظفينبالاقسامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            departmentsshow departmentsshow = new departmentsshow();
            departmentsshow.MdiParent = this;
            departmentsshow.Show();
        }

        private void تقييمموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empevalshow empevalshow = new empevalshow();
            empevalshow.MdiParent = this;
            empevalshow.Show();
        }

        private void الدوارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainingshow trainingshow = new trainingshow();
            trainingshow.MdiParent = this;
            trainingshow.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 

       
    }
}
