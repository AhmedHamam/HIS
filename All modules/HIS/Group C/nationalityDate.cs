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
    public partial class nationalityDate : Form
    {
        تقرير_قائمة_المرضى_طبقا_للجنسيات y=new تقرير_قائمة_المرضى_طبقا_للجنسيات();
        public nationalityDate()
        {
            InitializeComponent();
        }
        public nationalityDate(تقرير_قائمة_المرضى_طبقا_للجنسيات x)
        {
            InitializeComponent();
            y = x;
        }

        private void nationalityDate_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            y.setvalue2(dateTimePicker1.Text);
            this.Close();
        }
    }
}
