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
    public partial class  التسجيل1: Form
    {
        public التسجيل1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
        private void تسجيلالحضوروالأنصرافToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            تسجيل_الحضور_والانصراف f = new تسجيل_الحضور_والانصراف();
            f.Show();
        }

        private void تسجيلأذنموظفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            تسجيل_اذن_موظف f = new تسجيل_اذن_موظف();
            f.Show();
        }

        private void تسجيلمأمورياتموظفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            تسجيل_ماموريات_موظف f = new تسجيل_ماموريات_موظف();
            f.Show();
        }

        private void تسجيلوردياتموظفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            الورديات f = new الورديات();
            f.Show();
        }

        private void حصراذوناتالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حصر_اذونات_الخروج f = new حصر_اذونات_الخروج();
            f.Show();
        }

        private void حصربالمأمورياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حصر_بالماموريات f = new حصر_بالماموريات();
            f.Show();
        }

        private void حصرتأخيرواضافيوخروجمبكرللموظفينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            حصر_تاخير_واضافي_وخروج_مبكر_للموظفين f = new حصر_تاخير_واضافي_وخروج_مبكر_للموظفين();
            f.Show();
        }

        private void تقريرمراقبةالتعديلفيطرقالحضوروالانصرافلموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تعديل_في_طرق_الحضور_والانصراف_لموظف f = new تعديل_في_طرق_الحضور_والانصراف_لموظف();
            f.Show();
        }

        private void كشفالحضوروالانصرافاليوميToolStripMenuItem_Click(object sender, EventArgs e)
        {
            كشف_الحضور_والانصراف_اليومي f = new كشف_الحضور_والانصراف_اليومي();
            f.Show();
        }

        private void بيانبحضورالموظفشهرياToolStripMenuItem_Click(object sender, EventArgs e)
        {
            بيان_بحضور_الموظف_شهريا f = new بيان_بحضور_الموظف_شهريا();
            f.Show();
        }

        private void بيانبحضورالموظفشهرياToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            تقرير_بطرق_الحضور_خلال_فترة f = new تقرير_بطرق_الحضور_خلال_فترة();
            f.Show();
        }

        private void كشفبعددالوردياتالتيحضرهاالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            كشف_بعدد_الورديات_التي_حضرها_الموظف f = new كشف_بعدد_الورديات_التي_حضرها_الموظف();
            f.Show();
        }

        private void اذوناتخروجموظفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            اذونات_خروج_موظف f = new اذونات_خروج_موظف();
            f.Show();
        }

        private void مأمورياتموظفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ماموريات_موظف f = new ماموريات_موظف();
            f.Show();
        }

        private void اذنتأخيرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            اذونات_تأخير f = new اذونات_تأخير();
            f.Show();
        }

        private void تعديلطرقالحضورللموظفينخلالشهرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            تعديل_طرق_الحضور_للموظفين_خلال_شهر f = new تعديل_طرق_الحضور_للموظفين_خلال_شهر();
               f.Show();
        }

        private void مراجعةالحضوروالغيابللموظفينلليومالحاليToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            مراجعة_الحضور_والغياب_للموظفين_لليوم_الحالي f = new مراجعة_الحضور_والغياب_للموظفين_لليوم_الحالي();
            f.Show();
        }

        private void مراجعةالحضورللموظفينلفترةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            مراجعة_الحضور_للموظفين_لفترة f = new مراجعة_الحضور_للموظفين_لفترة();
            f.Show();
        }

        private void اعداداتطرقالحضوروالأنصرافToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            طرق_الحضور_والانصراف f = new طرق_الحضور_والانصراف();
            f.Show();
        }

        private void حضوروانصرافToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void حجزروتينيبالطوارئToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض fr = new محرك_البحث_عن_مريض();
            fr.Show();
        }

        private void تعديلبياناتالاسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن__مريض1 f = new محرك_البحث_عن__مريض1();
            f.Show();
        }

        private void البحثعنمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البحث_عن_مريييض22 f = new البحث_عن_مريييض22();
            f.Show();
        }

        private void انهاءزيارةمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            انهاء_زيارة_مريض f = new انهاء_زيارة_مريض();
            f.Show();
        }

        private void الحجزبعدالموافقهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الحجز_بعد_الموافقه f = new الحجز_بعد_الموافقه();
            f.Show();

        }

        private void اضافةخدماتلمرضىالطوارئToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافة_خدمات_لمرضى_الطوارئ ff = new اضافة_خدمات_لمرضى_الطوارئ();
            ff.Show();
        }

        private void تقاريربقائمةالطوارىءخلالفترهزمنيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقارير_بقائمة_الطوارىء_خلا_فتره_زمنيه f = new تقارير_بقائمة_الطوارىء_خلا_فتره_زمنيه();
            f.Show();
        }

        private void كشفخدماتالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            كشف_خدمات_المريض f = new كشف_خدمات_المريض();
            f.Show();
        }

        private void انواعالحوادثToolStripMenuItem_Click(object sender, EventArgs e)
        {
            انواع_الحوادث f = new انواع_الحوادث();
            f.Show();
        }

        private void ادارةعرباتالاسعافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ادارة_عربات_الاسعاف1 fr = new ادارة_عربات_الاسعاف1();
            fr.Show();
        }

        private void خدماتالطوارىءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافة_خدمات_الطوارىء f = new اضافة_خدمات_الطوارىء();
            f.Show();
        }

        private void اطباءالطوارىءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافة_اطباء_الطوارىء f = new اضافة_اطباء_الطوارىء();
            f.Show();
        }

        private void استقبالوطوارئToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void بلبلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تسجيلبياناتمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الصفحة_الرئيسية d = new الصفحة_الرئيسية();
            d.Show();
        }

        private void البحثعنمريضToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض2 f = new محرك_البحث_عن_مريض2();
            f.Show();
        }

        private void الغاءتسجيلمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            االغاء_تسجيل_مريض f = new االغاء_تسجيل_مريض();
            f.Show();
        }

        private void تعديلالبطاقةالعلاجيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مريض_تعديل_البطاقة_العلاجية f = new محرك_البحث_عن_مريض_تعديل_البطاقة_العلاجية();
            f.Show();

        }

        private void تعديلبياناتمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_عن_مررريض d = new محرك_البحث_عن_مررريض();
            d.Show();
        }

        private void تقريرالمرضيالجددعنفترةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_المرضى_الجدد_عن_فترة f = new تقرير_المرضى_الجدد_عن_فترة();
            f.Show();
        }

        private void تقريربياناتالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_بيانات_المريض f = new تقرير_بيانات_المريض();
            f.Show();
        }

        private void تقريرتعديلاسممريضToolStripMenuItem_Click(object sender, EventArgs e)
        {

            تقرير_تعديل_اسم_مريض f = new تقرير_تعديل_اسم_مريض();
            f.Show();
        }

        private void تقريرقائمةالمرضيطبقاللجنسياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_قائمة_المرضى_طبقا_للجنسيات f = new تقرير_قائمة_المرضى_طبقا_للجنسيات();
            f.Show();
        }

        private void تقريرقائمةالمرضيطبقالتوزيعالاعمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            قائمة_المرضى_طبقا_لتوزيع_الاعمار f = new قائمة_المرضى_طبقا_لتوزيع_الاعمار();
            f.Show();
        }

        private void تقريرقائمةالمرضىطبقاللجنسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_قائمة_طبقا_للجنس d = new تقرير_قائمة_طبقا_للجنس();
            d.Show();
        }

        private void تقريرباستكمالبياناتالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_باستكمال_بيانات_المرضي d = new تقرير_باستكمال_بيانات_المرضي();
            d.Show();
        }

        private void اعداداتلقبالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعداد_لقب_المريض f = new اعداد_لقب_المريض();
            f.Show();
        }

        private void اعداداتالمدنوالقريToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_المدن_والقرى f = new اعدادات_المدن_والقرى();
            f.Show();
        }

        private void اعداداتالأمراضالمزمنةوالمعديةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_الامراض_المزمنة_والمعدية f = new اعدادات_الامراض_المزمنة_والمعدية();
            f.Show();
        }

        private void نوعالهويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            نوع_الهوية f = new نوع_الهوية();
            f.Show();
        }

        private void النظامالغذائىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            النظام_الغذائى t = new النظام_الغذائى();
            t.Show();
        }

        private void اجازهمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {

            اجازه_مريض m = new اجازه_مريض(1);
            m.Show();
        }

        private void التصفيهالماليهلخروجمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            التصفيه_الماليه_لخروج_مريض m = new التصفيه_الماليه_لخروج_مريض(2);
            m.Show();
        }

        private void الغاءحجزمريضداخلىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الغاء_حجز_مريض_داخلى m = new الغاء_حجز_مريض_داخلى(3);
            m.Show();
        }

        private void الغاءخروجالمريضمنفترهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الغاء_خروج_المريض_من_فتره m = new الغاء_خروج_المريض_من_فتره(4);
            m.Show();
        }

        private void الغاءنقلمريضلسريراخرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الغاء_نقل_مريض_لسرير_اخر m = new الغاء_نقل_مريض_لسرير_اخر(5);
            m.Show();
        }

        private void تسجيلالوفياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تسجيل_الوفيات m = new تسجيل_الوفيات(6);
            m.Show();
        }

        private void تعديلبياناتخروجمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تعديل_بيانات_خروج_مريض m = new تعديل_بيانات_خروج_مريض(7);
            m.Show();
        }

        private void تعديلبياناتالحجزلمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تعديل_بيانات_الحجز_لمريض m = new تعديل_بيانات_الحجز_لمريض(8);
            m.Show();
        }

        private void حجزمريضفىوحدهثانويهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_مريض_فى_وحده_ثانويه m = new حجز_مريض_فى_وحده_ثانويه(9);
            m.Show();
        }

        private void حجزمريضداخلىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_مريض_داخلى m = new حجز_مريض_داخلى(10);
            m.Show();
        }

        private void حجزوتعديلالمرافقينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حجز_وتعديل_المرافقين
               m = new حجز_وتعديل_المرافقين(11);
            m.Show();
        }

        private void خروجمرافقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            خروج_مرافق m = new خروج_مرافق(12);
            m.Show();
        }

        private void خروجمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            خروج_مريض m = new خروج_مريض(13);
            m.Show();
        }

        private void خروجالمريضمنوحدهثانويهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            خروج_المريض_من_وحده_ثانويه m = new خروج_المريض_من_وحده_ثانويه(14);
            m.Show();
        }

        private void رجوعمريضمناجازهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            رجوع_مريض_من_اجازه m = new رجوع_مريض_من_اجازه(15);
            m.Show();
        }

        private void نقلمرافقمنسريرلاخرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            نقل_مرافق_من_سرير_لاخر m = new نقل_مرافق_من_سرير_لاخر(16);
            m.Show();
        }

        private void نقلالمريضمنسريرلاخرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            نقل_المريض_من_سرير_لاخر m = new نقل_المريض_من_سرير_لاخر(17);
            m.Show();
        }

        private void حالهموافقاتالحجزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حاله_موافقات_الحجز
             m = new حاله_موافقات_الحجز();
            m.Show();
        }

        private void زياراتالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            زيارات_المريض m = new زيارات_المريض();
            m.Show();
        }

        private void طلباتحجزاسرهتمتالموافقهعليهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            طلبات_حجز_اسره_تمت_الموافقه_عليها m = new طلبات_حجز_اسره_تمت_الموافقه_عليها();
            m.Show();
        }

        private void اسبابالغاءالحجزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اسباب_الغاء_الحجز m = new اسباب_الغاء_الحجز();
            m.Show();
        }

        private void اسرهالمستشفيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اسره_المستشفي m = new اسره_المستشفي();
            m.Show();
        }

        private void اعداداتفريقالعملالطبيبالمستشفيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_فريق_العمل_الطبى_بالمستشفى m = new اعدادات_فريق_العمل_الطبى_بالمستشفى();
            m.Show();
        }

        private void انواعمحطاتالتمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            انواع_محطات_التمريض m = new انواع_محطات_التمريض();
            m.Show();
        }

        private void مصادرالحجزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            مصادر_الحجز m = new مصادر_الحجز();
            m.Show();
        }

        private void مهامالاطباءالمعالجونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            مهام_الاطباء_المعالجون m = new مهام_الاطباء_المعالجون(1);
            m.Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}

