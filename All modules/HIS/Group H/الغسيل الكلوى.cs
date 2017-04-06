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
    public partial class الغسيل_الكلوى : Form
    {
        private int childFormNumber = 0;

        public الغسيل_الكلوى()
        {
            InitializeComponent();
        }

        

        private void الغسيل_الكلوى_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reception.Visible = true;
            Planexecute.Visible = true;
            Rooms.Visible = false;
            Duration.Visible = false;
            Devices.Visible = false;
            ReportOfservices.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportOfservices.Visible = true;
            Rooms.Visible = false;
            Duration.Visible = false;
            Devices.Visible = false;
            Reception.Visible = false;
            Planexecute.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rooms.Visible = true;
            Duration.Visible = true;
            Devices.Visible = true;
            Reception.Visible = false;
            Planexecute.Visible = false;
            ReportOfservices.Visible = false;
        }

        private void Reception_Click(object sender, EventArgs e)
        {
            استقبال_HIS op = new استقبال_HIS();
            //op.MdiParent = this;
            op.Show();
        }

        private void Planexecute_Click(object sender, EventArgs e)
        {
            تنفيذ_خطه_HIS op = new تنفيذ_خطه_HIS();
            //op.MdiParent = this;
            op.Show();
        }

        private void ReportOfservices_Click(object sender, EventArgs e)
        {
            تقرير_تفصيلى_بخدمات_HIS op = new تقرير_تفصيلى_بخدمات_HIS();
            //op.MdiParent = this;
            op.Show();
        }

        private void Rooms_Click(object sender, EventArgs e)
        {
            قاعات_HIS op = new قاعات_HIS();
            //op.MdiParent = this;
            op.Show();
        }

        private void Devices_Click(object sender, EventArgs e)
        {
            اجهزة_HIS op = new اجهزة_HIS();
            //op.MdiParent = this;
            op.Show();
        }

        private void Duration_Click(object sender, EventArgs e)
        {
            الفترات_اليومية op = new الفترات_اليومية();
           // op.MdiParent = this;
            op.ShowDialog();
        }
    }
}
