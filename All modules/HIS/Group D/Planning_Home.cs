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
    
    public partial class Planning_Home : Form
    {
        public plForm02 PlanningProfession;
        public plForm03 planningProfessionNamesDetails;
        public plForm04 planningStructureOrgnization;
        public plForm05 planningProfessionReport;
        public plForm06 professionNmaes;
        public plForm07 plannigPrerequestsProfessoinTitles;
        public Planning_Home()
        {
            InitializeComponent();
        }

        private void lab_PlanningProfession_MouseHover(object sender, EventArgs e)
        {

            lab_PlanningProfession.Font = new Font(lab_PlanningProfession.Font, FontStyle.Underline);
            lab_PlanningProfession.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_PlanningProfession_MouseLeave(object sender, EventArgs e)
        {

            lab_PlanningProfession.Font = new Font(lab_PlanningProfession.Font, FontStyle.Regular);
            lab_PlanningProfession.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_planningProfessionNamesDetails_MouseHover(object sender, EventArgs e)
        {
            lab_planningProfessionNamesDetails.Font = new Font(lab_planningProfessionNamesDetails.Font, FontStyle.Underline);
            lab_planningProfessionNamesDetails.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_planningProfessionNamesDetails_MouseLeave(object sender, EventArgs e)
        {

            lab_planningProfessionNamesDetails.Font = new Font(lab_planningProfessionNamesDetails.Font, FontStyle.Regular);
            lab_planningProfessionNamesDetails.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_planningStructureOrgnization_MouseHover(object sender, EventArgs e)
        {
            lab_planningStructureOrgnization.Font = new Font(lab_planningStructureOrgnization.Font, FontStyle.Underline);
            lab_planningStructureOrgnization.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_planningStructureOrgnization_MouseLeave(object sender, EventArgs e)
        {

            lab_planningStructureOrgnization.Font = new Font(lab_planningStructureOrgnization.Font, FontStyle.Regular);
            lab_planningStructureOrgnization.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_planningProfessionReport_MouseHover(object sender, EventArgs e)
        {
            lab_planningProfessionReport.Font = new Font(lab_planningProfessionReport.Font, FontStyle.Underline);
            lab_planningProfessionReport.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_planningProfessionReport_MouseLeave(object sender, EventArgs e)
        {

            lab_planningProfessionReport.Font = new Font(lab_planningProfessionReport.Font, FontStyle.Regular);
            lab_planningProfessionReport.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_professionNmaes_MouseHover(object sender, EventArgs e)
        {
            lab_professionNmaes.Font = new Font(lab_professionNmaes.Font, FontStyle.Underline);
            lab_professionNmaes.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_professionNmaes_MouseLeave(object sender, EventArgs e)
        {

            lab_professionNmaes.Font = new Font(lab_professionNmaes.Font, FontStyle.Regular);
            lab_professionNmaes.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_plannigPrerequestsProfessoinTitles_MouseHover(object sender, EventArgs e)
        {
             lab_plannigPrerequestsProfessoinTitles.Font = new Font( lab_plannigPrerequestsProfessoinTitles.Font, FontStyle.Underline);
             lab_plannigPrerequestsProfessoinTitles.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_plannigPrerequestsProfessoinTitles_MouseLeave(object sender, EventArgs e)
        {

             lab_plannigPrerequestsProfessoinTitles.Font = new Font( lab_plannigPrerequestsProfessoinTitles.Font, FontStyle.Regular);
             lab_plannigPrerequestsProfessoinTitles.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_PlanningProfession_Click(object sender, EventArgs e)
        {
            PlanningProfession = new plForm02();
            PlanningProfession.Show();
        }

        private void lab_planningProfessionNamesDetails_Click(object sender, EventArgs e)
        {
            planningProfessionNamesDetails = new plForm03();
            planningProfessionNamesDetails.Show();
        }

        private void lab_planningStructureOrgnization_Click(object sender, EventArgs e)
        {
            planningStructureOrgnization = new plForm04();
            planningStructureOrgnization.Show();
        }

        private void lab_planningProfessionReport_Click(object sender, EventArgs e)
        {
            planningProfessionReport = new plForm05();
            planningProfessionReport.Show();
        }

        private void lab_professionNmaes_Click(object sender, EventArgs e)
        {
            professionNmaes = new plForm06();
            professionNmaes.Show();
        }

        private void lab_plannigPrerequestsProfessoinTitles_Click(object sender, EventArgs e)
        {
            plannigPrerequestsProfessoinTitles = new plForm07();
            plannigPrerequestsProfessoinTitles.Show();
        }

        private void Planning_Home_Load(object sender, EventArgs e)
        {

      
        }
    }
}
