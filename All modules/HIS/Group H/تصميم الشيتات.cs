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
    public partial class تصميم_الشيتات : Form
    {
        private int childFormNumber = 0;

        public تصميم_الشيتات()
        {
            InitializeComponent();
        }

       
        private void تصميم_الشيتات_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Human_Photo.Visible = true;
            HumanComponent.Visible = true;
            SearchEngine.Visible = true;
            Measurement_Units.Visible = false;
            Setting_Of_Fields.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Measurement_Units.Visible = true;
            Setting_Of_Fields.Visible = true;
            Human_Photo.Visible = false;
            HumanComponent.Visible = false;
            SearchEngine.Visible = false;

        }

        private void Human_Photo_Click(object sender, EventArgs e)
        {
            صور_مكونات_جسم_الانسان op = new صور_مكونات_جسم_الانسان();
            //op.MdiParent= this;
            op.Show();
        }

        private void SearchEngine_Click(object sender, EventArgs e)
        {
            محرك_البحث op = new محرك_البحث();
            //op.MdiParent = this;
            op.Show();
        }

        private void HumanComponent_Click(object sender, EventArgs e)
        {
            مكونات_جسم_الانسان op = new مكونات_جسم_الانسان();
            //op.MdiParent = this;
            op.Show();
        }

        private void Measurement_Units_Click(object sender, EventArgs e)
        {
            اعداد_وحدات_القياس op = new اعداد_وحدات_القياس();
          //  op.MdiParent = this;
            op.Show();
        }

        private void Setting_Of_Fields_Click(object sender, EventArgs e)
        {
            اعداد_فئات_الشتات_الطبيه op = new اعداد_فئات_الشتات_الطبيه();
        //    op.MdiParent = this;
            op.Show();
        }
    }
}
