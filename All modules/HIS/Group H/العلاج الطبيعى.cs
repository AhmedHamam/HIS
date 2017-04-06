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
    public partial class العلاج_الطبيعى : Form
    {
        private int childFormNumber = 0;

        public العلاج_الطبيعى()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Reception.Visible = true;
            PlanChange.Visible = true;
            ExecutePlan.Visible = true;
            Rooms.Visible = false;
            Duration.Visible = false;
            Devices.Visible = false;
            ReportOfPlan.Visible = false;
            ReportOfExecutePlan.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportOfPlan.Visible = true;
            ReportOfExecutePlan.Visible = true;
            Reception.Visible = false;
            PlanChange.Visible = false;
            ExecutePlan.Visible = false;
            Rooms.Visible = false;
            Duration.Visible = false;
            Devices.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rooms.Visible = true;
            Duration.Visible = true;
            Devices.Visible = true;
            Reception.Visible = false;
            PlanChange.Visible = false;
            ExecutePlan.Visible = false;
            ReportOfPlan.Visible = false;
            ReportOfExecutePlan.Visible = false;
        }

        private void Reception_Click(object sender, EventArgs e)
        {
            استقبال_العلاج_الطبيعي op = new استقبال_العلاج_الطبيعي();
            //op.MdiParent = this;
            op.Show();
        }

        private void PlanChange_Click(object sender, EventArgs e)
        {
            تعديل_الخطة_العلاجية_للعلاج_الطبيعى op = new تعديل_الخطة_العلاجية_للعلاج_الطبيعى();
            //op.MdiParent = this;
            op.Show();
        }

        private void ExecutePlan_Click(object sender, EventArgs e)
        {
            تنفيذ_خطة_العلاج_الطبيعى op = new تنفيذ_خطة_العلاج_الطبيعى();
            //op.MdiParent = this;
            op.Show();
        }

        private void ReportOfPlan_Click(object sender, EventArgs e)
        {
            تقرير_الخطة_العلاجية_لمريض op = new تقرير_الخطة_العلاجية_لمريض();
            //op.MdiParent = this;
            op.Show();
        }

        private void ReportOfExecutePlan_Click(object sender, EventArgs e)
        {
            تقرير_تنفيذ_خطة_العلاج_الطبيعى op = new تقرير_تنفيذ_خطة_العلاج_الطبيعى();
            op.Show();
        }

        private void Rooms_Click(object sender, EventArgs e)
        {
            غرق_العلاج_الطبيعى op = new غرق_العلاج_الطبيعى();
            //op.MdiParent = this;
            op.Show();
        }

        private void Devices_Click(object sender, EventArgs e)
        {
            اجهزة_العلاج_الطبيعى op = new اجهزة_العلاج_الطبيعى();
           // op.MdiParent = this;
            op.Show();
        }

        private void العلاج_الطبيعى_Load(object sender, EventArgs e)
        {

        }

        private void Duration_Click(object sender, EventArgs e)
        {
            فترات_العلاج_الطبيعى op = new فترات_العلاج_الطبيعى();
            op.Show();
        }
    }
}
