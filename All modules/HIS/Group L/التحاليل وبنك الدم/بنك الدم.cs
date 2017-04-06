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
    public partial class بنك_الدم : Form
    {
        public بنك_الدم()
        {
            InitializeComponent();
        }

        private void أضافهعبواتدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تسجيل_بيانات_متبرع nw = new تسجيل_بيانات_متبرع();
            nw.Show();
        }

        private void شاشةالبحثعنمتبرعينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            بحث_عن_متبرع nw = new بحث_عن_متبرع();
            nw.Show();
        }

        private void أضافهعبواتدمToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            اضافه_عبوات_دم nw = new اضافه_عبوات_دم();
            nw.Show();
        }

        private void عرضطلباتنقلالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    عرض_طلبات_نقل_الدم nw = new عرض_طلبات_نقل_الدم();
        //    nw.Show();
        }

        private void أضافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تعديل_تاريخ_الصلاحية nw = new تعديل_تاريخ_الصلاحية();
            nw.Show();
        }

        //private void طلبToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    طلب_عبوات_دم nw = new طلب_عبوات_دم();
        //    nw.Show();
        //}

        private void استرجاعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            استرجاع_عبوات_دم nw = new استرجاع_عبوات_دم();
            nw.Show();
        }

        private void المنصرفمنبنكالدمخلالفترةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            المنصرف_من_بنك_الدم nw = new المنصرف_من_بنك_الدم();
            nw.Show();
        }

        private void تقريرالعبواتمنتيةالصلاحيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            العبوات_منتهية_الصلاحية nw = new العبوات_منتهية_الصلاحية();
            nw.Show();
        }

        private void المتبرعونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            المتبرعون nw = new المتبرعون();
            nw.Show();
        }

        private void الرصيدالحالىلبنكالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الرصيد_الحالى_لبنك_الدم nw = new الرصيد_الحالى_لبنك_الدم();
            nw.Show();
        }

        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تسجيل_بيانات_متبرع nw = new تسجيل_بيانات_متبرع();
            nw.Show();
        }

        private void أسبابتكهينالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اسباب_تكهين_الدم nw = new اسباب_تكهين_الدم();
            nw.Show();
        }

        private void أعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_عامة_لبنك_الدم nw = new اعدادات_عامة_لبنك_الدم();
            nw.Show();
        }

        private void عدادتانواعومكوناتالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_انواع_ومكونات_بنك_الدم nw = new اعدادات_انواع_ومكونات_بنك_الدم();
            nw.Show();
        }

        private void اعداداتمخازنبنكالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_محازن_بنك_الدم nw = new اعدادات_محازن_بنك_الدم();
            nw.Show();
        }

        private void اعداداتوحداتبنكالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_وحدات_بنك_الدم nw = new اعدادات_وحدات_بنك_الدم();
            nw.Show();
        }

        private void نقلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تنفيذ_عبوات_دم nw = new تنفيذ_عبوات_دم();
            nw.Show();
        }

        private void التبرعلمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            التبرع_لمريض nw = new التبرع_لمريض();
            nw.Show();
        }

        private void حجزعبوةدملمريضداخلىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_عبوة_لمريض_داخلى nw = new حجز_عبوة_لمريض_داخلى();
            nw.Show();
        }

        private void ألغاءعبوةدملمريضداخلىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الغاء_عبوة_لمريض_داخلى nw = new الغاء_عبوة_لمريض_داخلى();
            nw.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            بحث_عن_متبرع nw = new بحث_عن_متبرع();
            nw.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            التبرع_لمريض nw = new التبرع_لمريض();
            nw.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            بحث_عن_مريض nw = new بحث_عن_مريض();
            nw.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تنفيذ_عبوات_دم nw = new تنفيذ_عبوات_دم();
            nw.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            بحث_عن_مريض nw = new بحث_عن_مريض();
            nw.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافه_عبوات_دم nw = new اضافه_عبوات_دم();
            nw.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //عرض_طلبات_نقل_الدم nw = new عرض_طلبات_نقل_الدم();
            //nw.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            بحث_عن_مريض nw = new بحث_عن_مريض();
            nw.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            الغاء_عبوة_لمريض_داخلى nw = new الغاء_عبوة_لمريض_داخلى();
            nw.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تعديل_تاريخ_الصلاحية nw = new تعديل_تاريخ_الصلاحية();
            nw.Show();
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //المنصرف_من_بنك_الدم nw = new المنصرف_من_بنك_الدم();
            //nw.Show();

            outcomePackagePrint nw2 = new outcomePackagePrint();
            nw2.Show();
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //العبوات_منتهية_الصلاحية nw = new العبوات_منتهية_الصلاحية();
            //nw.Show();
            expiredPackagePrint nw = new expiredPackagePrint();
            nw.Show();
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            المتبرعون nw = new المتبرعون();
            nw.Show();
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //الرصيد_الحالى_لبنك_الدم nw = new الرصيد_الحالى_لبنك_الدم();
            //nw.Show();

            bloodPackagePrint nw = new bloodPackagePrint();
            nw.Show();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اسباب_تكهين_الدم nw = new اسباب_تكهين_الدم();
            nw.Show();
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اعدادات_عامة_لبنك_الدم nw = new اعدادات_عامة_لبنك_الدم();
            nw.Show();
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اعدادات_انواع_ومكونات_بنك_الدم nw = new اعدادات_انواع_ومكونات_بنك_الدم();
            nw.Show();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اعدادات_محازن_بنك_الدم nw = new اعدادات_محازن_بنك_الدم();
            nw.Show();
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اعدادات_وحدات_بنك_الدم nw = new اعدادات_وحدات_بنك_الدم();
            nw.Show();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تكهين_عبوات_الدم nw = new تكهين_عبوات_الدم();
            nw.Show();
        }

        private void linkLabel8_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافة_عبوات_لبنك_الدم nw = new اضافة_عبوات_لبنك_الدم();
            nw.Show();
        }

        private void طلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            طلب_عبوات_دم nw = new طلب_عبوات_دم();
            nw.Show();
        }

        private void تكهينعبواتالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تكهين_عبوات_الدم nw = new تكهين_عبوات_الدم();
            nw.Show();
        }

        private void اضافةعبواتمباشرةلبنكالدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافة_عبوات_لبنك_الدم nw = new اضافة_عبوات_لبنك_الدم();
            nw.Show();
        }


        
    }
}
