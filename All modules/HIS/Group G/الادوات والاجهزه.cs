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
    public partial class الادوات_والاجهزه : Form
    {
        public الادوات_والاجهزه()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            بحث_الجهاز f = new بحث_الجهاز();
            if (f.ShowDialog() == DialogResult.OK)
            {
                //textBox9.Text = بحث_الجهاز.Code.ToString();
                //textBox10.Text = بحث_الجهاز.Arabic_name;
            }
          
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
