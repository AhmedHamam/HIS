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
    public partial class team_E_home : Form
    {
        public team_E_home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashbored_Home f = new Dashbored_Home();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hospital_obligations f = new Hospital_obligations();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Performance_home f = new Performance_home();
            f.Show();
        }

    }
}
