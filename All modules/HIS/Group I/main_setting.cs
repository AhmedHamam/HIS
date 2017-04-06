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
    public partial class main_setting : Form
    {
        public main_setting()
        {
            InitializeComponent();
        }

        private void administration_Click(object sender, EventArgs e)
        {
            administration resForm = new administration();
           resForm.Show();
        }
       
        private void nursing_statio_Click(object sender, EventArgs e)
        {
            nursing_statio nurForm = new nursing_statio();
           nurForm.Show();
        }
        private void bedsetting_Click(object sender, EventArgs e)
        {
           bedsetting bedForm = new bedsetting();
            bedForm.Show();
        }

        private void move_servisce_Click(object sender, EventArgs e)
        {
           move_servisce movForm = new move_servisce();
           movForm.Show();
        }

        private void work_direction_Click(object sender, EventArgs e)
        {
           work_direction wdForm = new work_direction();
          wdForm.Show();
        }

        private void shifts_Click(object sender, EventArgs e)
        {
           shifts shForm = new shifts();
           shForm.Show();
        }

        private void branch_disease_Click(object sender, EventArgs e)
        {
           branch_disease brForm = new branch_disease();
           brForm.Show();
        }

        private void hospitalsetting_Click(object sender, EventArgs e)
        {
            //hospitalsetting hsForm = new hospitalsetting(this);
            //hsForm.Show();
        }

        private void differentservicse_Click(object sender, EventArgs e)
        {
           differentservicse difForm = new differentservicse();
           difForm.Show();
        }

        private void printing_devices_Click(object sender, EventArgs e)
        {
            printing_devices prForm = new printing_devices();
            prForm.Show();
        }

        private void delete_and_merging_doctors_Click(object sender, EventArgs e)
        {
           //delete_and_merging_doctors dmForm = new delete_and_merging_doctors(this);
           //dmForm.Show();
        }

        private void patient_statues_Click(object sender, EventArgs e)
        {
          patient_statues patForm = new patient_statues();
          patForm.Show();
        }

        private void relgion_Click(object sender, EventArgs e)
        {
           relgion reForm = new relgion();
           reForm.Show();
        }

        private void patient_category_Click(object sender, EventArgs e)
        {
            //patient_category patForm = new patient_category(this);
           // patForm.Show();
        }

        private void regions_Click(object sender, EventArgs e)
        {
            A_FRM_Region frm = new A_FRM_Region();
            frm.Show();
        }

        private void nationalities_Click(object sender, EventArgs e)
        {
           nationalities nForm = new nationalities();
           nForm.Show();
        }

        private void country_Click(object sender, EventArgs e)
        {
           country counForm = new country();
           counForm.Show();
        }

        private void zone_Click(object sender, EventArgs e)
        {
            A_FRM_Region frm = new A_FRM_Region();
            frm.Show();
            //zone zForm = new zone();
            //zForm.Show();
        }

        private void city_Click(object sender, EventArgs e)
        {
           // A_frm_city frm = new A_frm_city();
           // frm.Show();
        }
        private void kind_of_address_Click_1(object sender, EventArgs e)
        {
           kind_of_address addrForm = new kind_of_address();
           addrForm.Show();
        }

        private void ways_to_contact_Click(object sender, EventArgs e)
        {
           ways_to_contact contForm = new ways_to_contact();
           contForm.Show();
        }

        private void names_dictionary_Click(object sender, EventArgs e)
        {
            names_dictionary dicForm = new names_dictionary();
            dicForm.Show();
        }

        private void reasons_of_exit_Click(object sender, EventArgs e)
        {
            reasons_of_exit reForm = new reasons_of_exit();
            reForm.Show();
        }

        private void outer_clinic_Click(object sender, EventArgs e)
        {
            //outer_clinic clinicForm = new outer_clinic(this);
           // clinicForm.Show();
        }

        private void responsibilities_of_doctor_Click(object sender, EventArgs e)
        {
            //responsibilities_of_doctor resForm = new responsibilities_of_doctor(this);
            //resForm.Show();
        }

        private void surgery_rooms_Click(object sender, EventArgs e)
        {
            surgery_rooms surgeryForm = new surgery_rooms();
            surgeryForm.Show();
        }

    }
}
