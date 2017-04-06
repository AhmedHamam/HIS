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
    public partial class  TRAINING_HOME_PAGE: Form
    {
        TRAINING_FRM_ADVERTISING f1;
        TRAINING_FRM_COURSES_ADVERTISING f2;
        TRAINING_FRM_BOOKING f3;
        TRAINING_FRM_CONFIRM_TRAIN f4;
        TRAINING_FRM_CLOSING_TRAIN f5;
        TRAINING_FRM_SEARCH_TRAINER f6;
        TRAINING_FRM_CENTER_NAME f01;
        TRAINING_FRM_REPORT_COURSE f7;
        TRAINING_FRM_REPORT_ADVERTISING_COURSE f8;

        public TRAINING_HOME_PAGE()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            f1 = new TRAINING_FRM_ADVERTISING();
            f1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            f2 = new TRAINING_FRM_COURSES_ADVERTISING();
            f2.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void label12_Click(object sender, EventArgs e)
        {
           
        }

        private void label13_Click(object sender, EventArgs e)
        {
           
        }

        private void label14_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void label16_Click(object sender, EventArgs e)
        {
           
        }

        private void label15_Click(object sender, EventArgs e)
        {
            f2 = new TRAINING_FRM_COURSES_ADVERTISING();
            f2.Show();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            f3 = new TRAINING_FRM_BOOKING();
            f3.Show();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            f4 = new TRAINING_FRM_CONFIRM_TRAIN();
            f4.Show();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            f5 = new TRAINING_FRM_CLOSING_TRAIN();
            f5.Show();
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            f6 = new TRAINING_FRM_SEARCH_TRAINER();
            f6.Show();

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            f01 = new TRAINING_FRM_CENTER_NAME();
            f01.Show();

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            f6 = new TRAINING_FRM_SEARCH_TRAINER();
            f6.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            f6 = new TRAINING_FRM_SEARCH_TRAINER();
            f6.Show();
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            f7 = new TRAINING_FRM_REPORT_COURSE();
            f7.Show();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            f2 = new TRAINING_FRM_COURSES_ADVERTISING();
            f2.Show();
        }

        private void label16_Click_1(object sender, EventArgs e)
        {
            f8 = new TRAINING_FRM_REPORT_ADVERTISING_COURSE();
            f8.Show();
        }
    }
}
