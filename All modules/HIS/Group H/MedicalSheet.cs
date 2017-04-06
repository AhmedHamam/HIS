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
    public partial class MedicalSheet : Form
    {
        private int childFormNumber = 0;

        public MedicalSheet()
        {
            InitializeComponent();
        }

        private void MedicalSheet_Load(object sender, EventArgs e)
        {

        }

        private void SearchEngine_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Design_Sheet.Visible = true;
            Print_Sheet.Visible = false;
            SheetSetting.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print_Sheet.Visible = true;
            SheetSetting.Visible = false;
            Design_Sheet.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SheetSetting.Visible = true;
            Design_Sheet.Visible = false;
            Print_Sheet.Visible = false;
        }

        private void Design_Sheet_Click(object sender, EventArgs e)
        {
            تصميم_الشيتات_التفاعلية op = new تصميم_الشيتات_التفاعلية();
            op.Show();
        }

        private void Print_Sheet_Click(object sender, EventArgs e)
        {
            طباعة_شيت op = new طباعة_شيت();
            op.Show();
        }

        private void SheetSetting_Click(object sender, EventArgs e)
        {
            اعداد_الشيتات op = new اعداد_الشيتات();
            op.Show();
        }
    }
}
