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
    public partial class end_complete_date : Form
    {
        تقرير_باستكمال_بيانات_المرضي d = new تقرير_باستكمال_بيانات_المرضي();
        public end_complete_date()
        {
            InitializeComponent();
        }
        public end_complete_date(تقرير_باستكمال_بيانات_المرضي x)
        {
            InitializeComponent();
            d = x;
        }

        private void end_complete_date_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            d.setvalue4(dateTimePicker1.Text);

            this.Close();
        }
    }
}
