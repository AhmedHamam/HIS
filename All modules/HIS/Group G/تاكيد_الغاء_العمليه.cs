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
    public partial class تاكيد_الغاء_العمليه : Form
    {
        public تاكيد_الغاء_العمليه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            سبب_الالغاء_المنظار1 f = new سبب_الالغاء_المنظار1();

            this.Close();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
