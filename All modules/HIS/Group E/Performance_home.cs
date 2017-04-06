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
    public partial class Performance_home : Form
    {
        public Performance_home()
        {
            InitializeComponent();
        }

        private void احصائيةالمرضىلسنةمعينةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistical_patients_given_year spgy = new Statistical_patients_given_year();
            spgy.WindowState = FormWindowState.Maximized;
            spgy.MdiParent = this;
            spgy.Show();
        }

        private void احصائياتزياراتالمرضىالداخلىالشهرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistics_Monthly_visiting_of_entered_patients sm = new Statistics_Monthly_visiting_of_entered_patients();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        private void احصائياتزياراتالمرضىالخارجىالشهرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistics_Monthly_visiting_of_outed_patients sm = new Statistics_Monthly_visiting_of_outed_patients();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        

        
        private void احصائياتمعدلالاشغالللمرضىالداخلىالشهرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistic_internal_rate_of_occupancy_for_patients_Monthly sm = new Statistic_internal_rate_of_occupancy_for_patients_Monthly();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
            
        }

        private void احصائياتمعدلالاشغالللمرضىالخارجىالشهرىللاطباءToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistics_occupancy_rate_for_patients_outside_the_monthly_Doctors sm = new Statistics_occupancy_rate_for_patients_outside_the_monthly_Doctors();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            Statistivally_patients_to_compare_several_years sm = new Statistivally_patients_to_compare_several_years();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            monthy_clinic_report sm = new monthy_clinic_report();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            monthly_operation_report sm = new monthly_operation_report();
            sm.WindowState = FormWindowState.Maximized;
            sm.MdiParent = this;
            sm.Show();
        }

        


    }
}