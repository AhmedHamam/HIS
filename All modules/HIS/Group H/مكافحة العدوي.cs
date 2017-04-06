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
    public partial class مكافحة_العدوي : Form
    {
        private int childFormNumber = 0;

        public مكافحة_العدوي()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Emp_Infection.Visible = true;
            report_patient_onPeriod.Visible = false;
            reportvaccination.Visible = false;
            add_vaccination.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            report_patient_onPeriod.Visible = true;
            reportvaccination.Visible = true;
            add_vaccination.Visible = false;
            Emp_Infection.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_vaccination.Visible = true;
            report_patient_onPeriod.Visible = false;
            reportvaccination.Visible = false;
            Emp_Infection.Visible = false;
        }

        private void Emp_Infection_Click(object sender, EventArgs e)
        {
            اضافة_مكافحة_عدوى_موظفين op = new اضافة_مكافحة_عدوى_موظفين();
          //  op.MdiParent = this;
            op.Show();
        }

        private void reportvaccination_Click(object sender, EventArgs e)
        {
            تقرير_التطعيماتالتى_حصل_عيها_خلال_فتره_معينه op = new تقرير_التطعيماتالتى_حصل_عيها_خلال_فتره_معينه();
            //op.MdiParent = this;
            op.Show();
        }

        private void report_patient_onPeriod_Click(object sender, EventArgs e)
        {
            تقرير_للمرضى_المصابين_خلال_فتره_معينه op = new تقرير_للمرضى_المصابين_خلال_فتره_معينه();
            //op.MdiParent = this;
            op.Show();
        }

        private void add_vaccination_Click(object sender, EventArgs e)
        {
            اضافة_تطعيم_جديد op = new اضافة_تطعيم_جديد();
            //op.MdiParent = this;
            op.Show();
        }

        private void مكافحة_العدوي_Load(object sender, EventArgs e)
        {

        }

        
    }
}
