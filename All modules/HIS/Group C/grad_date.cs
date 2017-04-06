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
    public partial class grad_date : Form
    {
        تسجيل_بيانات__مريض y=new تسجيل_بيانات__مريض();
        public grad_date()
        {
            InitializeComponent();
        }

        public grad_date(تسجيل_بيانات__مريض x)
        {
            InitializeComponent();
            y = x;
        }
        private void grad_date_Load(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            y.asd(dateTimePicker1.Text);
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
