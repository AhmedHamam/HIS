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
    public partial class enddatte : Form
    {
        تقرير_المرضى_الجدد_عن_فترة y = new تقرير_المرضى_الجدد_عن_فترة();
        public enddatte()
        {
            InitializeComponent();
        }


        public enddatte(تقرير_المرضى_الجدد_عن_فترة x)
        {
            InitializeComponent();
            y = x;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {

            y.setvalue4(dateTimePicker1.Text);

            this.Close();
        }

        private void enddatte_Load(object sender, EventArgs e)
        {

        }

        
    }
}
