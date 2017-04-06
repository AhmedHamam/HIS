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
    public partial class خدمات_العيادات : Form
    {
        
        public خدمات_العيادات()
        {
            InitializeComponent();
        }

        

        //For حجز عياده خارجيه
        private void حجزالعياداتالخارجيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_العياده f = new حجز_العياده();
            f.MdiParent = this;
            f.Show();
        }

        
        /// <summary>
        /// اعدادات الخدمات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void خدماتالعياداتالخارجيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            خدمات f = new خدمات();
            f.MdiParent = this;
            f.Show();
        }
        //عطلات_الاطباء
        private void عطلاتالاطباءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            عطلات_الاطباء f = new عطلات_الاطباء();
            f.MdiParent = this;
            f.Show();
        }
        //محرك_البحث_عن_المرضى
        private void البحثعنالمرضىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_المرضى f = new محرك_البحث_عن_المرضى();
            f.MdiParent = this;
            f.Show();
        }
        //تاكيد_تعديل_الفئه_الماليه
        private void تعديلالفئةالماليةلمريضخارجىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث1 f = new محرك_البحث1();
            f.MdiParent = this;
            f.Show();
        }

        /// <summary>
        /// متابعه تحركات المريض
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void متابعةتحركاتالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {

            بحث_عن_مريض_منظار_1 f = new بحث_عن_مريض_منظار_1();
            f.MdiParent = this;
            f.Show();
        }
        //اعدادات_العيادات_الخارجية add new clinic
        private void اعدادتالعياداتالخارجيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_العيادات_الخارجية f = new اعدادات_العيادات_الخارجية();
            f.MdiParent = this;
            f.Show();
        }
        //اعداد_عطلات_العيادات for add vaction for clinic in setting
        private void عطلاتالعياداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعداد_عطلات_العيادات f = new اعداد_عطلات_العيادات();
            f.MdiParent = this;
            f.Show();
        }
        //غرف_العيادات_الخارجية for setting 
        private void غرفالعياداتالخارجيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            غرف_العيادات_الخارجية f = new غرف_العيادات_الخارجية();
            f.MdiParent = this;
            f.Show();
        }
        //محرك_البحث_عن_المرضى_الغاء for program
        private void الغاءزيارةمريضخارجىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_المرضى_الغاء f = new محرك_البحث_عن_المرضى_الغاء();
            f.MdiParent = this;
            f.Show();

        }
        //البحث_حجوزات_المرضي for program
        private void بحثحجوزاتالمرضىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البحث_حجوزات_المرضي f = new البحث_حجوزات_المرضي();
            f.MdiParent = this;
            f.Show();

        }
        //انهاء_زيارة_مريض_خارجى for program
        private void انهاءزيارةمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            انهاء_زيارة_مريض_خارجى f = new انهاء_زيارة_مريض_خارجى();
            f.MdiParent = this;
            f.Show();

        }

        private void حالةموافقةالخدماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            دخول_تحركات_المريض f = new دخول_تحركات_المريض();
            f.MdiParent = this;
            f.Show();
        }
        //جدوله عمليات المنظار
        private void جدولعملياتالمناظيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الصفحه_الرئيسيه_للمنظار f = new الصفحه_الرئيسيه_للمنظار();
            f.MdiParent = this;
            f.Show();

        }
        //طلب_حجز_منظار 
        private void طلبحجزالمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            طلب_حجز_منظار f = new طلب_حجز_منظار();
            f.MdiParent = this;
            f.Show();
        }
        //حجز_عملية_مستقبلية for setescope module
        private void الحجزالمستقبليللمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_عملية_مستقبلية f = new حجز_عملية_مستقبلية();
            f.MdiParent = this;
            f.Show();
        }
        //صيانة_طلب_غرفة_منظار
        private void طلبصيانهغرفهمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            صيانة_طلب_غرفة_منظار f = new صيانة_طلب_غرفة_منظار();
            f.MdiParent = this;
            f.Show();
        }
        //اعدادات_المناظير for setescope module
        private void اعدادالمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_المناظير f = new اعدادات_المناظير();
            f.MdiParent = this;
            f.Show();
        }

        private void استقبالطلباتالمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            استقبال_طلبات_مناظير f = new استقبال_طلبات_مناظير();
            f.MdiParent = this;
            f.Show();
        }

        private void تاكيدالحجزالمستقبليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            بحث_عن_عملية_في_تاريخ_معين f = new بحث_عن_عملية_في_تاريخ_معين();
            f.MdiParent = this;
            f.Show();
        }

        private void اعدادغرفالمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافه_غرفه f = new اضافه_غرفه();
            f.MdiParent = this;
            f.Show();
        }

        private void كتابهاقرارالمنظارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            كتابه_اقرار_مناظير f = new كتابه_اقرار_مناظير();
            f.MdiParent = this;
            f.Show();
        }

        

       

       
    }
}
