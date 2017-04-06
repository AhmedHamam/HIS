using System;
using System.Windows.Forms;
using System.Drawing;

namespace HIS
{
    public partial class GroupA_MainForm : Form
    {
        public GroupA_MainForm()
        {
            InitializeComponent();
        }
        private void LAB_MouseHover(object sender, EventArgs e)
        {
            Label LAB = (Label)sender;
            LAB.Font = new Font(LAB.Font.Name, 28, FontStyle.Bold | FontStyle.Underline);
        }

        private void LAB_MouseLeave(object sender, EventArgs e)
        {
            Label LAB = (Label)sender;
            LAB.Font = new Font(LAB.Font.Name, 24, FontStyle.Bold | FontStyle.Regular);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            A_FRM_Access_Mthod frm = new A_FRM_Access_Mthod();
            frm.C_Ok.Visible = false; 
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            A_FRM_Contracting_Entities frm = new A_FRM_Contracting_Entities();
            frm.ShowDialog();
        }


        private void label4_Click(object sender, EventArgs e)
        {
            A_FRM_Accommodation_Degree frm = new A_FRM_Accommodation_Degree();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            A_FRM_Patients_Category frm = new A_FRM_Patients_Category();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
           // A_FRM_Categories_Type frm = new A_FRM_Categories_Type();
            A_FRM_Types_of_Entities frm = new A_FRM_Types_of_Entities();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            A_FRM_Operation_Skills_Desc frm = new A_FRM_Operation_Skills_Desc();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            A_FRM_Preparing_for_Service frm = new A_FRM_Preparing_for_Service();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            A_FRM_Regulation_Prices frm = new A_FRM_Regulation_Prices();
            frm.C_Ok.Visible = false;
            frm.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            A_FRM_Accommdation_Pricing frm = new A_FRM_Accommdation_Pricing();
            frm.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            A_FRM_Region frm = new A_FRM_Region();
            frm.ShowDialog();
        }

         private void label13_Click(object sender, EventArgs e)
        {
            A_FRM_Entities_Branchs frm = new A_FRM_Entities_Branchs();
            frm.ShowDialog();
        }
    }
}
