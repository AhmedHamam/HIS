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
    public partial class Operations_Home : Form
    {
        public opForm02 FutureRequestsOfOperations;
        // public Operations_displayFutureRequestsOfOperations displayFutureRequestsOfOperations;
        public opForm03 searchForOperation;
        public opForm11 operationsTable;
        public opForm20 medicalTeamSearchEngine;
        public opForm07 patientsSearchEngine;
        public opForm10 searchPreordersOfOperation;
        public اعدادات_متقدمه_للعمليه AdvancedSettingsOfOperation;
        public opForm15 recieveOperationRequests;
        //public Operations_operationRoomSettings operationRoomSettings;
        //public Operations_writeApprovalOfOperaton writeApprovalOfOperaton;
        //public Operations_SettingsofOperationTimeTable SettingsofOperationTimeTable;
        public opForm12 ordersBeforeOperations;
        //public Operations_reportOfSurgeryRelatedToFinantials reports;
        public Operations_Home()
        {
            InitializeComponent();
        }

        //Underline and change color of the lables 
        private void lab_futureRequestOfOperations_MouseHover(object sender, EventArgs e)
        {

              lab_futureRequestOfOperations.Font = new Font(  lab_futureRequestOfOperations.Font, FontStyle.Underline);
              lab_futureRequestOfOperations.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_futureRequestOfOperations_MouseLeave(object sender, EventArgs e)
        {

              lab_futureRequestOfOperations.Font = new Font(  lab_futureRequestOfOperations.Font, FontStyle.Regular);
              lab_futureRequestOfOperations.ForeColor = Color.FromArgb(47, 72, 120);
        }

       
        private void lab_operationTable_MouseHover(object sender, EventArgs e)
        {

              lab_operationTable.Font = new Font(  lab_operationTable.Font, FontStyle.Underline);
              lab_operationTable.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_operationTable_MouseLeave(object sender, EventArgs e)
        {

              lab_operationTable.Font = new Font(  lab_operationTable.Font, FontStyle.Regular);
              lab_operationTable.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_searchForOperation_MouseHover(object sender, EventArgs e)
        {

              lab_searchForOperation.Font = new Font(  lab_searchForOperation.Font, FontStyle.Underline);
              lab_searchForOperation.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_searchForOperation_MouseLeave(object sender, EventArgs e)
        {

              lab_searchForOperation.Font = new Font(  lab_searchForOperation.Font, FontStyle.Regular);
              lab_searchForOperation.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_medicalTeamSearchEngine_MouseHover(object sender, EventArgs e)
        {

              lab_medicalTeamSearchEngine.Font = new Font(  lab_medicalTeamSearchEngine.Font, FontStyle.Underline);
              lab_medicalTeamSearchEngine.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_medicalTeamSearchEngine_MouseLeave(object sender, EventArgs e)
        {

              lab_medicalTeamSearchEngine.Font = new Font(  lab_medicalTeamSearchEngine.Font, FontStyle.Regular);
              lab_medicalTeamSearchEngine.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_patientsSearchEngine_MouseHover(object sender, EventArgs e)
        {

              lab_patientsSearchEngine.Font = new Font(  lab_patientsSearchEngine.Font, FontStyle.Underline);
              lab_patientsSearchEngine.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_patientsSearchEngine_MouseLeave(object sender, EventArgs e)
        {

              lab_patientsSearchEngine.Font = new Font(  lab_patientsSearchEngine.Font, FontStyle.Regular);
              lab_patientsSearchEngine.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_searchPreordersOfOperation_MouseHover(object sender, EventArgs e)
        {

              lab_searchPreordersOfOperation.Font = new Font(  lab_searchPreordersOfOperation.Font, FontStyle.Underline);
              lab_searchPreordersOfOperation.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_searchPreordersOfOperation_MouseLeave(object sender, EventArgs e)
        {

              lab_searchPreordersOfOperation.Font = new Font(  lab_searchPreordersOfOperation.Font, FontStyle.Regular);
              lab_searchPreordersOfOperation.ForeColor = Color.FromArgb(47, 72, 120);
        }

        private void lab_AdvancedSettingsOfOperation_MouseHover(object sender, EventArgs e)
        {

              lab_AdvancedSettingsOfOperation.Font = new Font(  lab_AdvancedSettingsOfOperation.Font, FontStyle.Underline);
              lab_AdvancedSettingsOfOperation.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_AdvancedSettingsOfOperation_MouseLeave(object sender, EventArgs e)
        {

              lab_AdvancedSettingsOfOperation.Font = new Font(  lab_AdvancedSettingsOfOperation.Font, FontStyle.Regular);
              lab_AdvancedSettingsOfOperation.ForeColor = Color.FromArgb(47, 72, 120);
        }
       


        private void lab_Operations_recieveOperationRequests_MouseHover(object sender, EventArgs e)
        {
            lab_Operations_recieveOperationRequests.Font = new Font(lab_Operations_recieveOperationRequests.Font, FontStyle.Underline);
            lab_Operations_recieveOperationRequests.ForeColor = Color.FromArgb(136, 136, 136);
        }
        private void lab_Operations_recieveOperationRequests_MouseLeave(object sender, EventArgs e)
        {
            lab_Operations_recieveOperationRequests.Font = new Font(lab_Operations_recieveOperationRequests.Font, FontStyle.Regular);
            lab_Operations_recieveOperationRequests.ForeColor = Color.FromArgb(47, 72, 120);
        }
        private void lab_ordersBeforeOperations_MouseHover(object sender, EventArgs e)
        {

            lab_ordersBeforeOperations.Font = new Font(lab_ordersBeforeOperations.Font, FontStyle.Underline);
            lab_ordersBeforeOperations.ForeColor = Color.FromArgb(136, 136, 136);
        }

        private void lab_ordersBeforeOperations_MouseLeave(object sender, EventArgs e)
        {

            lab_ordersBeforeOperations.Font = new Font(lab_ordersBeforeOperations.Font, FontStyle.Regular);
            lab_ordersBeforeOperations.ForeColor = Color.FromArgb(47, 72, 120);
        }


        // Show Forms 
        private void lab_futureRequestOfOperations_Click(object sender, EventArgs e)
        {
            FutureRequestsOfOperations = new opForm02();
            FutureRequestsOfOperations.Show();
        }

        private void lab_display_FutureRequestsOfOperations_Click(object sender, EventArgs e)
        {
            //displayFutureRequestsOfOperations = new Operations_displayFutureRequestsOfOperations();
            //displayFutureRequestsOfOperations.Show();
            
        }
        private void lab_operationTable_Click(object sender, EventArgs e)
        {
            operationsTable = new opForm11();
            operationsTable.Show();
        }
        private void lab_planningStructureOrgnization_Click(object sender, EventArgs e)
        {
            searchForOperation = new opForm03();
            searchForOperation.Show();
        }

        private void lab_medicalTeamSearchEngine_Click(object sender, EventArgs e)
        {
            medicalTeamSearchEngine = new opForm20();
            medicalTeamSearchEngine.Show();
        }

        private void lab_Operations_recieveOperationRequests_Click(object sender, EventArgs e)
        {
            recieveOperationRequests = new opForm15();
            recieveOperationRequests.Show();
        }

        private void lab_searchPreordersOfOperation_Click(object sender, EventArgs e)
        {
            searchPreordersOfOperation = new opForm10();
            searchPreordersOfOperation.Show();
        }

        private void lab_AdvancedSettingsOfOperation_Click(object sender, EventArgs e)
        {
            AdvancedSettingsOfOperation = new اعدادات_متقدمه_للعمليه();
            AdvancedSettingsOfOperation.Show();

        }

        private void lab_patientsSearchEngine_Click(object sender, EventArgs e)
        {
            patientsSearchEngine = new opForm07();
            patientsSearchEngine.Show();
        }

        private void lab_ordersBeforeOperations_Click(object sender, EventArgs e)
        {
            ordersBeforeOperations = new opForm12();
            ordersBeforeOperations.Show();
        }

        //private void lab_patientsSearchEngine_Click(object sender, EventArgs e)
        //{
        //    patientsSearchEngine = new Operations_patientsSearchEngine();
        //    patientsSearchEngine.Show();
        //}

        //private void lab_searchPreordersOfOperation_Click(object sender, EventArgs e)
        //{
        //    searchPreordersOfOperation = new Operations_searchPreordersOfOperation();
        //    searchPreordersOfOperation.Show();
        //}

        //private void lab_AdvancedSettingsOfOperation_Click(object sender, EventArgs e)
        //{
        //    AdvancedSettingsOfOperation = new Operations_AdvancedSettingsOfOperation();
        //    AdvancedSettingsOfOperation.Show();



        //private void lab_operationRoomSettings_Click(object sender, EventArgs e)
        //{
        //    operationRoomSettings = new Operations_operationRoomSettings();
        //    operationRoomSettings.Show();
        //}

        //private void lab_writeApprovalOfOperaton_Click_1(object sender, EventArgs e)
        //{
        //    writeApprovalOfOperaton = new Operations_writeApprovalOfOperaton();
        //    writeApprovalOfOperaton.Show();
        //}

        //private void lab_SettingsofOperationTimeTable_Click(object sender, EventArgs e)
        //{
        //    SettingsofOperationTimeTable = new Operations_SettingsofOperationTimeTable();
        //    SettingsofOperationTimeTable.Show();

        //}

        //private void lab_ordersBeforeOperations_Click(object sender, EventArgs e)
        //{
        //    ordersBeforeOperations = new Operations_ordersBeforeOperations();
        //    ordersBeforeOperations.Show();

        //}

        //private void lab_reports_Click(object sender, EventArgs e)
        //{
        //    reports = new Operations_reportOfSurgeryRelatedToFinantials();
        //    reports.Show();
        //}








    }
}
