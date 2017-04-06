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
    public partial class حجز_عبوة_لمريض_داخلى : Form
    {
        public حجز_عبوة_لمريض_داخلى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            المرضى nw = new المرضى();
            nw.Show();
        }

        

       
    }
}
