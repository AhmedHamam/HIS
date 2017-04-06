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
    public partial class All_Modules : Form
    {

        /// <summary>
        /// Group D
        /// </summary>
        public Operations_Home operations;
        public Planning_Home planning;
        public  mail mail;
        public TRAINING_HOME_PAGE train;
        /// <summary>
        /// Group K
        /// </summary>
        public Intial_Assessment assesment;
        public Examination examin;
        public follow_up_sheet follow;
        public Case_Sheet patient_case;
        public Progress_Note note;

        /// <summary>
        /// Group L
        /// </summary>
        public الصيدليه pharmacy;
        public بنك_الدم bloodbank;
        public التحاليل_الطبية analysis;
        /// <summary>
        /// Group F
        /// </summary>
        public salaries salary;

        /// <summary>
        /// Group E
        /// </summary>
        /// 
        public first fst;
        /// <summary>
        /// Group A
        /// </summary>
        /// 

        public GroupA_MainForm mainff;
        public GroupA_Patient_Bill_MainForm patientBillff;

        public All_Modules()
        {
            InitializeComponent();
        }
        private void All_Modules_Load(object sender, EventArgs e)
        {

        }

        private void LAB_MouseHover(object sender, EventArgs e)
        {
            Label LAB = (Label)sender;
            LAB.Font = new Font(LAB.Font.Name,28,FontStyle.Bold | FontStyle.Underline);
        }

        private void LAB_MouseLeave(object sender, EventArgs e)
        {
            Label LAB = (Label)sender;
            LAB.Font = new Font(LAB.Font.Name, 24, FontStyle.Bold | FontStyle.Regular);
        }

        private void lab_planning_MouseClick(object sender, MouseEventArgs e)
        {
            planning = new Planning_Home();
            planning.Show();
        }


        private void lab_operations_Click(object sender, EventArgs e)
        {

            operations = new Operations_Home();
            operations.Show();
        }

        private void lab_mail_Click(object sender, EventArgs e)
        {
            mail = new mail();
            mail.Show();
        }

        private void lab_training_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            assesment = new Intial_Assessment();
            assesment.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            examin = new Examination();
            examin.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            follow = new follow_up_sheet();
            follow.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            patient_case = new Case_Sheet();
            patient_case.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            note = new Progress_Note();
            note.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            pharmacy = new الصيدليه();
            pharmacy.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            bloodbank = new بنك_الدم();
            bloodbank.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            analysis = new التحاليل_الطبية();
            analysis.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            salary = new salaries();
            salary.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            fst = new first();
            fst.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            mainff = new GroupA_MainForm();
            mainff.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            patientBillff = new GroupA_Patient_Bill_MainForm(1);
            patientBillff.ShowDialog();

        }

        private void label17_Click(object sender, EventArgs e)
        {
            General General = new General();
            General.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            General General = new General();
            General.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            General General = new General();
            General.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            خدمات_العيادات mainff = new خدمات_العيادات();
            mainff.ShowDialog();

        }

        private void label21_Click(object sender, EventArgs e)
        {
            خدمات_العيادات mainff = new خدمات_العيادات();
            mainff.ShowDialog();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            MedicalSheet op = new MedicalSheet();
            op.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            العلاج_الطبيعى OP = new العلاج_الطبيعى();

            OP.ShowDialog();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            الغسيل_الكلوى op = new الغسيل_الكلوى();
            op.Show();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            مكافحة_العدوي op = new مكافحة_العدوي();
            op.Show();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            تصميم_الشيتات op = new تصميم_الشيتات();
            op.Show();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            OrdersForm f = new OrdersForm();
            f.ShowDialog();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            main_setting m_setting = new main_setting();
            m_setting.ShowDialog();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            frm_manages_files frm = new frm_manages_files();
            frm.ShowDialog();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            frm_scanner frm = new frm_scanner();
            frm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            assignments assignments = new assignments();
            assignments.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Budgets budget = new Budgets();
            budget.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            personnel_affairs per_aff = new personnel_affairs();
            per_aff.Show();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            Dashbored_Home f = new Dashbored_Home();
            f.Show();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            Hospital_obligations f = new Hospital_obligations();
            f.Show();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            Performance_home f = new Performance_home();
            f.Show();
        }

        private void label34_Click(object sender, EventArgs e)
        {
            حضور_و_انصراف f = new حضور_و_انصراف();
            f.Show();
        }

        private void label36_Click(object sender, EventArgs e)
        {
            buy f = new buy();
            f.Show();
        }

        private void label37_Click(object sender, EventArgs e)
        {
            حساباتالموردين f = new حساباتالموردين();
            f.Show();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            بب f = new بب();
            f.Show();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            main f = new main();
            f.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Doc_fees doc_fees = new Doc_fees();
            doc_fees.Show();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            vacations vacation = new vacations();
            vacation.Show();
        }

        private void label40_Click(object sender, EventArgs e)
        {
            مكتب_الدخول f = new مكتب_الدخول();
            f.Show();
        }

        private void label41_Click(object sender, EventArgs e)
        {
            استقبال_طوارئ f = new استقبال_طوارئ();
            f.Show();
        }

        private void label42_Click(object sender, EventArgs e)
        {
            التسجيل1 f = new التسجيل1();
            f.Show();
        }

        private void label43_Click(object sender, EventArgs e)
        {
            train = new TRAINING_HOME_PAGE();
            train.Show();
        }
    }
}
