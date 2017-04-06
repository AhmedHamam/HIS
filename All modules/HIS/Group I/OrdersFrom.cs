using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HIS
{
    public partial class OrdersForm : Form
    {
         
         public OrdersForm()
        {
             
            InitializeComponent();

        }
       
        private void label1_Click(object sender, EventArgs e)
        {
            //PatientSearchForm pSearch = new PatientSearchForm(this);
            
            ////this.Hide();
            //pSearch.Show();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //PatientSearchForm pSearch = new PatientSearchForm(this);
            //pSearch.Show();
        }

        private void label4_Click(object sender, EventArgs e){
        //{
        //    RequestBloodForm RBlood = new RequestBloodForm(this);
        //   // this.Hide();
        //    RBlood.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
         //   permissionExchangeForm pExcahnge = new permissionExchangeForm(this);
         ////   this.Hide();
         //   pExcahnge.Show(); 

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Request_a_mealForm rmeal = new Request_a_mealForm(this);
            //rmeal.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            //OrdersNotExecuteForm OrdeNotE = new OrdersNotExecuteForm(this);
            //OrdeNotE.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OrdersAddedForm oAddedF = new OrdersAddedForm();
            oAddedF.Show();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            //PatientSearchForm pSearch = new PatientSearchForm(this); 
            //pSearch.Show();
 
        }

        private void linlblLabRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // PatientSearchForm pSearch = new PatientSearchForm(this);
           // pSearch.Show();
            ServiceLabForm sLabForm = new ServiceLabForm();
            sLabForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PatientSearchForm pSearch = new PatientSearchForm(this);
            //pSearch.Show();
        }

        private void linkLblRayRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PatientSearchForm pSearch = new PatientSearchForm(this);
          // pSearch.Show();
            Service_Ray sRay = new Service_Ray(this);
          sRay.Show();
        }

        private void linkLblMealRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Request_a_mealForm rmeal = new Request_a_mealForm(this);
            rmeal.Show();
        }

        private void linkLblBloodReq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //RequestBloodForm RBlood = new RequestBloodForm(this);
            //RBlood.Show();
        }

        private void linkLblpermissionExch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //permissionExchangeForm pExcahnge = new permissionExchangeForm(this);
            //pExcahnge.Show(); 
        }

        private void linkLblOrderExe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ////PatientSearchForm pSearch = new PatientSearchForm(this);
            //OrderExecutionForm oExeForm = new OrderExecutionForm(this);
            //oExeForm.Show();
            
        }

        private void linkLblPendingOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           //// PatientSearchForm pSearch = new PatientSearchForm(this);
           // //pSearch.Show();
           // PenddingOrdersForm penOrderForm = new PenddingOrdersForm();
           // penOrderForm.Show();
        }

        private void linkLblShortcutOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          ////  PatientSearchForm pSearch = new PatientSearchForm(this);
          // // pSearch.Show();
          //  ShortcutCommandsForm shortcutCform = new ShortcutCommandsForm(this);
          //  shortcutCform.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OrdersCancelledForm oCancelF = new OrdersCancelledForm(this);
            oCancelF.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //OrderExecutionForm oExeForm = new OrderExecutionForm(this);
           // oExeForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //PatientSearchForm psearch = new PatientSearchForm(this);
            //psearch.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            lbl_Executed.Enabled = false;
            lbl_visited.Enabled = false;
            lbl_notExecuted.Enabled = false;
        }

       

    }
}