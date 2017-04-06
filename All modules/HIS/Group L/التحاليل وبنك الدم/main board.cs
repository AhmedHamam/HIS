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
    public partial class main_board : Form
    {
        public main_board()
        {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            التحاليل_الطبية f2 = new التحاليل_الطبية();
            f2.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            بنك_الدم nw = new بنك_الدم();
            nw.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
