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
    public partial class مستلزمات_العملية : Form
    {
        public مستلزمات_العملية()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            مخزن_مستلزمات f = new مخزن_مستلزمات();
           // f.Show();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = مخزن_مستلزمات.Code.ToString();
                textBox1.Text = مخزن_مستلزمات.Arabic_name;
            }
        }

        

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مستلزمات_العملية_Load(object sender, EventArgs e)
        {

        }
    }
}
